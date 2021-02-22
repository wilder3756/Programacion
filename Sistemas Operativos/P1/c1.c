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
 
 punteroCV = (struct claveValor *) malloc(sizeof(struct claveValor)*nroLineas);
 if(punteroCV == NULL) exit(0);
 //LeerRegistros
 FILE *Fin = fopen(argv[1], "r");
 int lectura=0;
 if(Fin==NULL) perror("Error: ");
 while(nroLineas>nroRegistros){
 lectura=fscanf(Fin,"%s %d",(punteroCV + nroRegistros)->clave,&(punteroCV + nroRegistros)->valor);
 if((punteroCV + nroRegistros)->valor<-1000 || (punteroCV + nroRegistros)->valor>1000) perror("EL valor debe estar entre -1000 y 1000");
 if(lectura<=0) break;
 nroRegistros++;
 }
 fclose(Fin);
 //Organizar Registros de mayor a menor
 struct claveValor aux;
 for(int j=0;j<nroRegistros;j++){
 for(int k=0;k<nroRegistros-1;k++){
 if((punteroCV + k+1)->valor>(punteroCV + k)->valor){
 aux=punteroCV[k];
 punteroCV[k]=punteroCV[k+1];
 punteroCV[k+1]=aux;
 }
 }
 }
 //Escribir Archivo Salida
 FILE *Fout = fopen(argv[2], "w");
 if(Fout==NULL) perror("Error: ");
 int i=0, escritura=0;
 while(i<nroRegistros){
 escritura=fprintf(Fout,"%s %d\n",(punteroCV + i)->clave,(punteroCV + i)->valor);
 if(escritura<=0) perror("Error al escribir");
 i++;
 }
 return 0;
}