#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>
struct Registro{
 char Nombre[20];
 char Ocupacion[20];
 int edad;
};
struct Registro *punteroRegistro;
int nroLineas=100;
int nroRegistros=0;
 
struct parametros{
    struct Registro *punteroRegistro;
 char *archivoSalida;
};
void* funcionHilo1(void* args);
void* funcionHilo2(void* args);
int main(int argc, char *argv[]) {
 
 punteroRegistro = (struct Registro *) malloc(sizeof(struct Registro)*nroLineas);
 if(punteroRegistro == NULL) exit(0);
 //LeerRegistros
 FILE *Fin = fopen(argv[1], "r");
 int lectura=0;
 if(Fin==NULL) perror("Error: ");
 while(nroLineas>nroRegistros){
 lectura=fscanf(Fin,"%s %s %d",(punteroRegistro + nroRegistros)->Nombre,(punteroRegistro + nroRegistros)->Ocupacion,&(punteroRegistro +nroRegistros)->edad);
 if(lectura<=0) break;
 nroRegistros++;
 }
 fclose(Fin);
 //Imprimir structura
 printf("\n Orden Normal %d\n",nroRegistros);
 printf("%20s %20s %4s\n","Nombre","Ocupacion","Edad");
 for(int i=0;i<nroRegistros;i++){
 printf("%20s %20s %4d\n",(punteroRegistro + i)->Nombre,(punteroRegistro + i)->Ocupacion,(punteroRegistro + i)->edad);
 }
 //creacion de hilos
 pthread_t hilos[2];
  struct parametros p[2];
 p[0].punteroRegistro=punteroRegistro;
 p[0].archivoSalida=argv[2];
 p[1].punteroRegistro=punteroRegistro;
 p[1].archivoSalida=argv[3];
  pthread_create(&hilos[0], NULL, &funcionHilo1,&p[0]); 
  pthread_create(&hilos[1], NULL, &funcionHilo2,&p[1]); 
  for(int i=0; i<2; i++){
    pthread_join(hilos[i], NULL);
  }
 //Imprimir los archivos finales
 char Nombre[20];
 char Ocupacion[20];
 int edad;
 //Imprimir salida 1
 printf("\n Orden Inverso %d\n",nroRegistros);
 printf("%20s %20s %4s\n","Nombre","Ocupacion","Edad");
 FILE *Fin1 = fopen(argv[2], "r");
 lectura=0;
 if(Fin1==NULL) perror("Error: ");
 for(int i=0;i<nroRegistros;i++){
 lectura=fscanf(Fin1,"%s %s %d",Nombre,Ocupacion,&edad);
 if(lectura<=0) break;
 printf("%20s %20s %4d\n",Nombre,Ocupacion,edad);
 
 }
 fclose(Fin1);
 //Imprimir salida 2
 printf("\n Orden alfabetico por ocupacion\n");
 printf("%20s %20s %4s\n","Nombre","Ocupacion","Edad");
 FILE *Fin2 = fopen(argv[3], "r");
 lectura=0;
 if(Fin2==NULL) perror("Error: ");
 for(int i=0;i<nroRegistros;i++){
 lectura=fscanf(Fin2,"%s %s %d",Nombre,Ocupacion,&edad);
 if(lectura<=0) break;
 printf("%20s %20s %4d\n",Nombre,Ocupacion,edad);
 }
 fclose(Fin2);
 return 0;
}
void* funcionHilo1(void* args){
    struct parametros* p = (struct parametros*)args;
 struct Registro *punteroRegistro=p->punteroRegistro;
 //Imprimir en orden inverso
 FILE *Fout = fopen(p->archivoSalida, "w");
 if(Fout==NULL) perror("Error: ");
 int i=nroRegistros, escritura=0;
 while(i>1){
 escritura=fprintf(Fout,"%s %s %d\n",(punteroRegistro + i-1)->Nombre,(punteroRegistro + i-1)->Ocupacion,(punteroRegistro + i-1)->edad);
 if(escritura<=0) perror("Error al escribir");
 i--;
 }
 fclose(Fout);
    return NULL;
}
void* funcionHilo2(void* args){
    struct parametros* p = (struct parametros*)args;
 struct Registro *punteroRegistro=p->punteroRegistro;
 //Organizar alfabeticamente
 struct Registro aux;
 for(int j=0;j<nroRegistros;j++){
 for(int k=0;k<nroRegistros-1;k++){
 if(strcasecmp((punteroRegistro + k)->Ocupacion, (punteroRegistro + k+1)->Ocupacion)>0){
 aux=punteroRegistro[k];
 punteroRegistro[k]=punteroRegistro[k+1];
 punteroRegistro[k+1]=aux;
 }
 }
 }
 //Imprimir
 FILE *Fout = fopen(p->archivoSalida, "w");
 if(Fout==NULL) perror("Error: ");
 int i=0, escritura=0;
 while(i<nroRegistros){
 escritura=fprintf(Fout,"%s %s %d\n",(punteroRegistro + i)->Nombre,(punteroRegistro + i)->Ocupacion,(punteroRegistro + i)->edad);
 if(escritura<=0) perror("Error al escribir");
 i++;
 }
 fclose(Fout);
    return NULL;
}