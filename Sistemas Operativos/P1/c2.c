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
 
 //Escribir Archivo Salida
 FILE *Fout = fopen(argv[2], "w");
 if(Fout==NULL) perror("Error: ");
 int i=nroRegistros-1, escritura=0;
 while(i>=0){
 escritura=fprintf(Fout,"%s %d\n",(punteroCV + i)->clave,(punteroCV + i)->valor);
 if(escritura<=0) perror("Error al escribir");
 i--;
 }
 fclose(Fout);
 return 0;
}