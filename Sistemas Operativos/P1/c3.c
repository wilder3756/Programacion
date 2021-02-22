#include <stdio.h>
#include <stdlib.h>
#include <string.h>
struct claveValor{
 char clave[20];
 int valor;
};
struct claveValor *punteroCV;
int nroLineas=100;
int nroRegistros=0;
 
int main(int argc, char *argv[]) {
 pid_t h1,h2; 
 //Empaquetar los argumentos para cada proceso
 char* a1=argv[2];
 char* a2=argv[3];
 
  h1=fork(); 
  if(h1==-1){ 
    perror("Error, proceso no creado: ");
    return EXIT_FAILURE;
  }
 else if(h1==0){ 
    execv("./p1",argv); 
    perror("Error: "); 
    return EXIT_FAILURE;
  }
 
 argv[2]=argv[3];
 h2=fork();
 if(h2==-1){ 
    perror("Error, proceso no creado: ");
    return EXIT_FAILURE;
  }
 else if(h2==0){ 
    execv("./p2",argv); 
    perror("Error: "); 
    return EXIT_FAILURE;
  }
 wait(NULL);
 wait(NULL);
 
 char clave[20], linea[100];
  int valor;
 
 FILE *Fin1 = fopen(a1, "r");
  if (Fin1 == NULL) {
    perror("Error: ");
    return EXIT_FAILURE;
  }
 
 FILE *Fin2 = fopen(a2, "r");
  if (Fin2 == NULL) {
    perror("Error: ");
    return EXIT_FAILURE;
  }
  while(1){
    if(fgets(linea,sizeof(linea),Fin1)==NULL){
      fclose(Fin1);
      break;
    }
    sscanf(linea,"%s %d", (char *)clave,&valor);
    printf("%s %d\n",clave,valor);
  }
 printf("\n\n");
  while(1){
    if(fgets(linea,sizeof(linea),Fin2)==NULL){
      fclose(Fin2);
      break;
    }
    sscanf(linea,"%s %d", (char *)clave,&valor);
    printf("%s %d\n",clave,valor);
  }
 return 0;
}