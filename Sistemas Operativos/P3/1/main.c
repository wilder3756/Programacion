//Carolina Monsalve
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <ctype.h>
#include <sys/types.h>
#include <sys/wait.h>
//se define el tamaño del buffer de comunicacion
#define tamano 30

int main(int argc, char *argv[]) {
  
  int pipePadreHijo[2], pipeHijoPadre[2];
  char bufferPadre[tamano], bufferHijo[tamano];
  ssize_t tamanoLeidoPadre, tamanoLeidoHijo;
  pid_t procesoHijo;

  //los arreglos para la manejar la informacion pueden contener basura, asi que procedemos a limpiarlos
  for(int i=0;i<tamano;i++){ bufferPadre[i]=0; bufferHijo[i]=0; }
  //Creacion de las pipes, para seguir ejecucion ambas se deben crear exitosamente
  if (pipe(pipePadreHijo) == -1 || pipe(pipeHijoPadre) == -1){ 
    perror("creacion pipe:");
    exit(EXIT_FAILURE);
  }
  //se comunica como se termina la ejecuccion
  printf("Para terminar la ejecuccion ingrese la letra 'q'\n");

  //Creacion del proceso Hijo
  procesoHijo = fork();
  if(procesoHijo==-1){
    perror("fork hijo: ");
    exit(EXIT_FAILURE);
  }
  //Codigo hijo
  if(procesoHijo==0){ 
    //el proceso hijo cierra los canales que no puede usar, remitirse al grafico
    if (close(pipePadreHijo[1]) == -1 || close(pipeHijoPadre[0]) == -1){ 
      perror("proceso hijo cierra los canales que no puede usar: ");
      exit(EXIT_FAILURE);
    }
    
    while(1){ 
      //Leer del padre
      tamanoLeidoHijo = read(pipePadreHijo[0], bufferHijo, tamano);
      if (tamanoLeidoHijo == -1){
        perror("leer padre hijo: ");
        exit(EXIT_FAILURE);
      }
      //No hay mas que leer y nadie esta escribiendo
      if (tamanoLeidoHijo == 0)  break; 
         
      //Convertir a mayusculas
      for(int i=0; bufferHijo[i]; i++) bufferHijo[i] = toupper(bufferHijo[i]); 
      //Escribir al padre desde el hijo y comprobar si se pudo escribir todo
      if (write(pipeHijoPadre[1], bufferHijo, strlen(bufferHijo)+1) != strlen(bufferHijo)+1){ 
        perror("escritura hijo padre: ");
        exit(EXIT_FAILURE);
      }
    }
    //Como el hijo ya no tienne mas que leer o ya nadie escribe procede a cerrar los canales de comunicacion
    if (close(pipeHijoPadre[1]) == -1 || close(pipePadreHijo[0]) == -1){ 
      perror("hijo cierra sus canales de comunicacion: ");
      exit(EXIT_FAILURE);
    }
    //El hijo termina su ejecuccion, por lo que debe indicar que acaba la ejecuccion y ademas para que el padre pueda terminar, pues lo esta esperando wait(NULL)
    exit(EXIT_SUCCESS);
  }


  //Codigo padre

  //el proceso padre cierra los canales que no puede usar, remitirse al grafico
  if (close(pipePadreHijo[0]) == -1 || close(pipeHijoPadre[1]) == -1){ 
    perror("proceso padre cierra los canales que no puede usar: ");
    exit(EXIT_FAILURE);
  }

  
  while(1){
   //Leo de la entrada estandar
    fgets(bufferPadre, tamano, stdin);
    //No me interesa tener el enter, asi que lo elimino
    bufferPadre[strcspn(bufferPadre, "\n")]=0;
    //Termino la ejecucion si ingresan 'q'
    if(strcasecmp(bufferPadre, "q")==0)break;
    //Convertir en minusculas 
    for(int i=0;bufferPadre[i];i++)bufferPadre[i] = tolower(bufferPadre[i]);
    //El padre le pasa el texto a su hijo
    if (write(pipePadreHijo[1], bufferPadre, strlen(bufferPadre)+1) != strlen(bufferPadre)+1){ 
      perror("escritura padre hijo: ");
      exit(EXIT_FAILURE);
    }
    //el padre lee el contenido que le envia su hijo
    tamanoLeidoPadre = read(pipeHijoPadre[0], bufferPadre, tamano); //Leer hijo
    if (tamanoLeidoPadre == -1){
      perror("leer hijo padre: ");
      exit(EXIT_FAILURE);
    }
    //No hay mas que leer y nadie esta escribiendo
    if (tamanoLeidoPadre == 0) break;
    //finalmente reporto en pantalla el texto que recibo de mi hijo
    printf("%s\n",bufferPadre);
  }
  if (close(pipePadreHijo[1]) == -1 || close(pipeHijoPadre[0]) == -1){ //Cerrar la escritura del padre en el pipe padre hijo
    perror("padre cierra sus canales de comunicacion: ");
    exit(EXIT_FAILURE);
  }
  //El padre esperar a su hijo
  wait(NULL); 
  return EXIT_SUCCESS;
}