#include <stdio.h>
#include <stdlib.h>
#include <semaphore.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <string.h>

struct Registro{
  char nombre[20];
  char ocupacion[20];
  int edad;
};



int main(int argc, char *argv[]) {
  char linea[200];
  struct Registro registros[100];
  mode_t perms = 0666;
  int flags = O_CREAT,nroRegistro=0;
  unsigned int value = 0; //Valor por defeteco cerrado

  if (argc != 4 ){
    printf("error de ejecucion la entrada debe terner 3 parametros ejm: %s In Out1 Out2\n", argv[0]);
    exit(EXIT_FAILURE);
  }
  //Crear semaforo bloqueado
  sem_t *semOut1 = sem_open("semaforoOut1", flags, perms, value); 
  if(semOut1 == SEM_FAILED){
    perror("p1 creacion semaforo Out1: ");
    exit(EXIT_FAILURE);
  }
  printf("P1: Se crea Semaforo para %s creado\n",argv[2]);
  //Crear semaforo para Out2
  sem_t *semOut2= sem_open("semaforoOut2", flags, perms, value); //Abrir el semaforo para Out2
  if(semOut2 == SEM_FAILED){
    perror("p1 creacion semaforo Out2: ");
    exit(EXIT_FAILURE);
  }
  printf("P1: Se crea Semaforo para %s \n",argv[3]);
  
  //Primero debo leer y organizar toda la informacion de In para escribir Out1 por ello debo de inciar el semaforo bloqueado
  FILE *Fin = fopen(argv[1], "r");
	if (Fin == NULL) {
		perror("p1 Archivo Error: ");
		return EXIT_FAILURE;
	}

  while(1){//Leer y guardar
		if(fgets(linea,sizeof(linea),Fin)==NULL){
			fclose(Fin);
			break;
		}
		sscanf(linea,"%s %s %d", (char *)registros[nroRegistro].nombre,(char *)registros[nroRegistro].ocupacion,&registros[nroRegistro].edad);
    nroRegistro++;
	}

  printf("P1: Se lee el archivo %s \n",argv[1]);

  struct Registro aux;
	for(int i=0;i<nroRegistro;i++){ //Organizo
    for(int j=0;j<nroRegistro-1;j++){
	    int cmp = strcasecmp(registros[j].nombre,registros[j+1].nombre);
      if(cmp>0){
        	aux=registros[j];
        	registros[j]=registros[j+1];
        	registros[j+1]=aux;
      }
    }
  }

  printf("P1: Escribiendo en  %s ...\n",argv[2]);

  FILE *Fout1 = fopen(argv[2], "w");
	if (Fout1 == NULL) {
		perror("p1 Archivo Error: ");
		exit(EXIT_FAILURE);
	}
  //Escribo en el archivo de salida
  for(int i=0;i<nroRegistro;i++) fprintf(Fout1,"%s %s %d\n",registros[i].nombre, registros[i].ocupacion,registros[i].edad);
  fclose(Fout1);

  printf("P1: %s escrito\n",argv[2]);

  printf("P1: Desbloqueando acceso a %s ...\n",argv[2]);
  //Desbloqueo el semaforo porque ya esta listo Out1
  if(sem_post(semOut1) == -1){ 
    perror("p1 sem_post Out1: ");
    exit(EXIT_FAILURE);
  }

  printf("P1: Cerrando semaforo para %s ...\n",argv[2]);
//Cerrar semaforo pero sigue disponible para otros procesos
  if(sem_close(semOut1) == -1){
    perror("p1 sem_close Out1: ");
    exit(EXIT_FAILURE);
  }

  printf("P1: Pidiendo acceso a %s ...\n",argv[3]);
  //Pido la llave del segundo semaforo
  if(sem_wait(semOut2) == -1){ 
    perror("p1 sem_wait Out2: ");
    exit(EXIT_FAILURE);
  }

  FILE *Fout2 = fopen(argv[3], "r");
	if (Fout2 == NULL) {
		perror("p1 Error: ");
		exit(EXIT_FAILURE);
	}

  printf("P1: Leyendo %s ...\n",argv[3]);

  nroRegistro=0;
  while(1){//Leer y escribir
		if(fgets(linea,sizeof(linea),Fout2)==NULL){
			fclose(Fout2);
			break;
		}
    sscanf(linea,"%s %s %d", (char *)registros[nroRegistro].nombre,(char *)registros[nroRegistro].ocupacion,&registros[nroRegistro].edad);
    printf("%s %s %d\n", (char *)registros[nroRegistro].nombre,(char *)registros[nroRegistro].ocupacion,registros[nroRegistro].edad);
    nroRegistro++;
	}

  printf("P1: Desbloqueo acceso a %s ...\n",argv[3]);

  if(sem_post(semOut2) == -1){ //Desbloqueo el semaforo porque ya esta procese semOut2
    perror("p2 sem_post Out2: ");
    exit(EXIT_FAILURE);
  }

  printf("P1: Cierro semaforo %s ...\n",argv[3]);
  //Cerrar semaforo de Out2
  if(sem_close(semOut2) == -1){
    perror("p1 sem_close Out2: ");
    exit(EXIT_FAILURE);
  }

  printf("P1: Eliminando semaforo %s ...\n",argv[3]);

  if(sem_unlink("semaforoOut2") == -1){ //Eliminar el semafoto de Out2 ya que nadie mas lo requiere
    perror("p1 sem_unlink: ");
    exit(EXIT_FAILURE);
  }

  printf("Fin del programa\n");

  exit(EXIT_SUCCESS);
}