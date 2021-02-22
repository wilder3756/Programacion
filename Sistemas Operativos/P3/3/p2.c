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
  int nroRegistro=0;

  if (argc != 3 ){
    printf("error de ejecucion la entrada debe terner 2 parametros ejm: %s Out1 Out2\n", argv[0]);
    exit(EXIT_FAILURE);
  }

  printf("P2: Se Abre semaforo para %s ...\n",argv[1]);
  //Abrir el semaforo para Out1
  sem_t *semOut1= sem_open("semaforoOut1", 0); 
  if(semOut1 == SEM_FAILED){
    perror("p2 abrir semaforoOut1: ");
    exit(EXIT_FAILURE);
  }

  printf("P2: Se Abre semaforo para %s ...\n",argv[2]);
  //Abrir el semaforo para Out2
  sem_t *semOut2= sem_open("semaforoOut2", 0); 
  if(semOut2 == SEM_FAILED){
    perror("p2 abrir semaforoOut2: ");
    exit(EXIT_FAILURE);
  }

  printf("P2: Pidiendo acceso a %s ...\n",argv[1]);

  if(sem_wait(semOut1) == -1){ //Pido la llave para Out1
    perror("p2 sem_wait Ou1: ");
    exit(EXIT_FAILURE);
  }

  //Debo leer y organizar toda la informacion de Out1 para Out2 por ello inicio el semaforo de Out2 bloqueado
  FILE *Fout1 = fopen(argv[1], "r");
	if (Fout1 == NULL) {
		perror("p2 Error: ");
		exit(EXIT_FAILURE);
	}

  printf("P2: Leyendo %s ...\n",argv[1]);
  //Leer y guardar
  while(1){
		if(fgets(linea,sizeof(linea),Fout1)==NULL){
			fclose(Fout1);
			break;
		}
		sscanf(linea,"%s %s %d", (char *)registros[nroRegistro].nombre,(char *)registros[nroRegistro].ocupacion,&registros[nroRegistro].edad);
    nroRegistro++;
	}

  printf("P2: Desbloqueando acceso a %s ...\n",argv[1]);

  if(sem_post(semOut1) == -1){ //Desbloqueo el semaforo porque ya lei Out1
    perror("p2 sem_post Out1: ");
    exit(EXIT_FAILURE);
  }

  printf("P2: Cerrando semaforo para %s ...\n",argv[1]);

  if(sem_close(semOut1) == -1){//Cerrar semaforo pero sigue disponible para otros procesos
    perror("p2 sem_close Out1: ");
    exit(EXIT_FAILURE);
  }
  //Eliminar el semafoto de Out1 ya que nadie mas lo requiere
  printf("P2: Eliminando semaforo para %s ...\n",argv[1]);
  if(sem_unlink("semaforoOut1") == -1){ 
    perror("p2 sem_unlink: ");
    exit(EXIT_FAILURE);
  }

//Organizo
  struct Registro aux;
	for(int i=0;i<nroRegistro;i++){ 
    for(int j=0;j<nroRegistro-1;j++){
      if(registros[j+1].edad < registros[j].edad){
        	aux=registros[j];
        	registros[j]=registros[j+1];
        	registros[j+1]=aux;
      }
    }
  }

  FILE *Fout2 = fopen(argv[2], "w");
	if (Fout2 == NULL) {
		perror("p2 Error: ");
		exit(EXIT_FAILURE);
	}

  printf("P2: Escribiendo %s ...\n",argv[2]);

  for(int i=0;i<nroRegistro;i++) //Escribo en el archivo de salida
    fprintf(Fout2,"%s %s %d\n",registros[i].nombre, registros[i].ocupacion,registros[i].edad);
  fclose(Fout2);

  printf("P2: Desbloqueando acceso a %s ...\n",argv[2]);

  if(sem_post(semOut2) == -1){ //Desbloqueo el semaforo porque ya escribi Out2
    perror("p2 sem_post Out2: ");
    exit(EXIT_FAILURE);
  }

  if(sem_close(semOut2) == -1){//Cerrar semaforo de Out2
    perror("p2 sem_close Out2: ");
    exit(EXIT_FAILURE);
  }
  printf("Fin del programa\n");
  exit(EXIT_SUCCESS);
}