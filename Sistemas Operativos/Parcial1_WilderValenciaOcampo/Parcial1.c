/*
    Wilder Valencia Ocampo
    ID 000375627
    Fecha: 20/08/2019
    Parcial 1
*/

 #include <stdio.h>
 #include <stdlib.h>
 #include <stdint.h>
 #include <string.h>

char commando[12];

 char nombreBD[11];
 int tamaBD;
 int contadorBD = 0;

struct estudiante
 {
     int cedula;
     char nombre[30];
     int semestre;
 };

 struct estudiante *punteroEstructura;

 void mkdb(void);
 void readall(void);
 void mkreg(void);
 void readreg(void);

 void salir(void); 
 void savedb(void);
 void readsize(void);
 void loaddb(void);

 int main(void) {
     int ret,salir1=0;

     while(salir1==0){
         // get the command
         printf("~$ ");
         scanf("%s", commando);

         ret = strcmp(commando, "mkdb");
         if(ret == 0) mkdb();

         ret = strcmp(commando, "readall");
         if(ret == 0) readall();
         
         ret = strcmp(commando, "mkreg");
         if(ret == 0) mkreg();

         ret = strcmp(commando, "readreg");
         if(ret == 0) readreg();

         ret = strcmp(commando, "readsize");
         if(ret == 0) readsize();

         ret = strcmp(commando, "savedb");
         if(ret == 0) savedb();

         ret = strcmp(commando, "loaddb");
         if(ret == 0) loaddb();

         ret = strcmp(commando, "exit");
         if(ret == 0){
             salir();
             salir1=1;
         } 

     }
     free(punteroEstructura);
     printf("Fin del programa\n");
     return EXIT_SUCCESS;
 }

void mkdb(void){
    printf("Ingrese el nombre de la base de datos: ");
     scanf("%s", nombreBD);
     printf("Ingrese el tamaño de la base de datos: ");
     scanf("%d",&tamaBD);
     getc(stdin); //remove \n

     punteroEstructura = (struct estudiante *) malloc(sizeof(struct estudiante)*tamaBD);
     contadorBD = 0;
     if(punteroEstructura == NULL) {
         printf("No se dispone de memoria suficiente para crear la base de datos, por lo tanto el programa termina su ejecucion\n");
         exit(0);
     }
     printf("Creacion Exitosa\n");
 }

 void readall(void){
     int ret;
     if(punteroEstructura != NULL){
             for(int i= 0; i < contadorBD;i++){
                 ret = strcmp((punteroEstructura + i)->nombre, "");
                 if(0 != ret) printf("Cedeula: %d Nombre:%s Semestre: %d\n",(punteroEstructura + i)->cedula,(punteroEstructura + i)->nombre,(punteroEstructura + i)->semestre);
             }
         }
     else{
         printf("La base de datos aun no ha sido creada\n");
     }
 }
 void mkreg(void){
     if(punteroEstructura != NULL){
         if(contadorBD < tamaBD){
             printf("Ingrese la cedula: ");
             scanf("%d", &((punteroEstructura + contadorBD)->cedula));
             printf("Ingrese el nombre: ");
             scanf("%s", (punteroEstructura + contadorBD)->nombre);
            printf("Ingrese el semestre: ");
             scanf("%d", &((punteroEstructura + contadorBD)->semestre));
             getc(stdin); //remove \n

             contadorBD++;
             printf("Registro creado con exito\n");
             if(contadorBD == tamaBD){
                 printf("Base de datos llena\n");
             }
         }
         else printf("Base de datos Llena, no es posible almacenar otro registro\n");
     }
     else{
         printf("La base de datos aun no ha sido creada\n");
     }
 }
 void readreg(void){
     if(punteroEstructura != NULL){
         int tmpCedula;
        printf("Ingrese la cedula del registrpo que desea leer: ");
        scanf("%d", &tmpCedula);
        getc(stdin); //remove \n

        if(punteroEstructura != NULL){
         for(int i= 0; i < contadorBD;i++){
             if(tmpCedula==((punteroEstructura+i)->cedula)){
                 printf("Cedeula: %d Nombre: %s Semestre: %d\n",(punteroEstructura + i)->cedula,(punteroEstructura + i)->nombre,(punteroEstructura + i)->semestre);
                 return;
             }
         }
         printf("Registro no encontrado\n");
     }
     }
     else{
         printf("La base de datos aun no ha sido creada\n");
     }
     
 }
void readsize(void){
    printf("La cantidad actual del registros es: %d, para mas detalle de los registros ingrese el comando readall\n",contadorBD);
}

void loaddb(void){
    char FILE_NAME[15];
    int tmp;
    
    printf("Ingrese el nombre del archivo de entrada: ");
    scanf("%s",FILE_NAME);
    //printf("Cantidad Registros: %d",canRegArchivo(FILE_NAME));
    contadorBD=0;
    strcpy(nombreBD,FILE_NAME);
    tmp=canRegArchivo(FILE_NAME);
    tamaBD=tmp+20;

    FILE *in_file;
    in_file=fopen(FILE_NAME,"r");
    
    if(in_file==NULL){
        printf("No se pudo crear el archivo1 %s\n",FILE_NAME);
        exit(8);
    }
    

    punteroEstructura = (struct estudiante *) malloc(sizeof(struct estudiante)*tamaBD);
     if(punteroEstructura == NULL) {
         printf("No se dispone de memoria suficiente para crear la base de datos, por lo tanto el programa termina su ejecucion\n");
         exit(0);
         fclose(in_file);
     }
     
    for(int i= 0; i < tmp;i++){
        
        fscanf (in_file, "%d,%d,%s", &((punteroEstructura + i)->cedula),&((punteroEstructura + i)->semestre),(punteroEstructura + i)->nombre);
        contadorBD++;
        
        //readsize()
    }
    fclose(in_file);
    printf("Creacion Exitosa\n");
}

int canRegArchivo(char *ruta){
    FILE *in_file;
    int count=0, tmp;
    
    in_file=fopen(ruta,"r");
    
    if(in_file==NULL){
        printf("No se pudo crear el archivo %s\n",ruta);
        exit(8);
    }

    while(1){
        
        tmp =fgetc(in_file);
        if (tmp==32) count++;
        if(tmp==EOF){
            return count;
        }
        
       
    }
    fclose(in_file);
}

void savedb(void){
    char FILE_NAME[15];

    printf("Ingrese el nombre del archivo de salida: ");
    scanf("%s",FILE_NAME);

    FILE *in_file;
    
    in_file=fopen(FILE_NAME,"w+");
    if(in_file==NULL){
        printf("No se pudo crear el archivo %s",FILE_NAME);
        exit(8);
    }

    for(int i= 0; i < contadorBD;i++){
        fprintf (in_file, "%d,%d,%s ", (punteroEstructura + i)->cedula,(punteroEstructura + i)->semestre,(punteroEstructura + i)->nombre);
    }
    fclose(in_file);

}

 void salir (void){
     int ret;
     printf("Antes de salir del programa desea guardar la base de datos: \n 1. SI\n 2. NO\n");
     scanf("%d",&ret);

     if(ret==1){
         savedb();
     }
     

 }


