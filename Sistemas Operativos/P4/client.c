#include <stdio.h>
#include <stdlib.h>
#include <semaphore.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <string.h>
#include <sys/mman.h>
#include <sys/shm.h> 
#include <unistd.h>
#include <sys/types.h>
#include <pthread.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include <errno.h>

//Envio y recepcion de informacion
struct msgbuf {
   long mtype;
   char mtext[400];
};
struct msgbuf buffer[2];

//Procesos
char *nroPid;
int colaMensaje;
char ubicacionCola[10];

//Memoria
int mapProceso;
void* mapPunteroProceso;

//Semaforos
sem_t *semProcesos; 
sem_t *semMensajes;

//Firmas Funciones
void crearMemoria();
void crearSemaforos();
void desconectarse();
void *enviarMensaje(void* args);
void *recibirMensaje(void* args);

pthread_t hilos[2];
int chatActivo=0;
char comand[10];
int main() 
{ 
    
    crearSemaforos();
    crearMemoria();
    
    int semValor;
    char *mensajePid;
    //Se obtiene el pid del proceso, sera clave para el desarrolo de todo el programa
    sprintf(mensajePid, "%d\0", getpid()); 
    nroPid=mensajePid;
    //strcat(mensajePid,"\0");
    
    while(strncmp(comand,"q",1)!=0){ //se comprueba la condicion de salida
        printf("Ingrese el comando ('conect' para ingresar al chat y 'q' para cerrar el cliente)\n");
        scanf("%s",comand);
        //el usuario decide conectarse al chat
        if(strncmp(comand,"conect",5)==0){
            //se notifica al servidor la llegada para que genere el canal de comunicacion
            while(1){
                sem_getvalue(semProcesos,&semValor);
                if(semValor == 1){
                    memcpy(mapPunteroProceso, mensajePid, 6);
                    sem_wait(semProcesos);
                    break;
                    
                }    
            }
            //se crean dos hilos, uno para enviar informacion y el otro para recibir informacion
            pthread_create(&hilos[0],NULL,&enviarMensaje,NULL);
            pthread_create(&hilos[1],NULL,&recibirMensaje,NULL);
            pthread_join(hilos[0],NULL);
            pthread_join(hilos[1],NULL);
        }
        
    }
    printf("Exito\n");
	return 0; 
} 



void *enviarMensaje(void* args){
    chatActivo=1;
    key_t key;
    
    char comando[15]="touch ";
    char identificador[100]="User ";
    int len=strlen(nroPid); 
    char aux[len];
    for(int i=0;i<len;i++)aux[i]=nroPid[i];
    strcat(comando, aux);

    strcat(comando, ".txt\0");
    
    system(comando);
    strcat(identificador,aux);
    strcat(aux,".txt");
    sprintf(ubicacionCola,"%s",aux);
    //se crea un llave 
    if ((key = ftok(aux, 'A')) == -1) { 
        perror("creacion del token : ");
        exit(EXIT_FAILURE);
    }
    colaMensaje = msgget(key, IPC_CREAT | 0666 );
    if (colaMensaje == -1) { 
        perror("creacion de la cola: ");
        exit(EXIT_FAILURE);
    }
    strcat(identificador,": ");
    len=strlen(identificador);
    buffer[0].mtype = 10; 
    char Mensaje[400-len];
    char auxIdentificador[len];
    for(int i=0;i<len;i++)auxIdentificador[i]=identificador[i];
    int semValor;
    printf("se ha conectado al chat Grupal, a continuacion los mensajes que escribas los recibiran lo demas usuarios (para enviar archivos uticice el comando 'send' seguido de la ruta del archivo ej 'send arch.txt')\n");
    while(1) {
        sem_getvalue(semMensajes,&semValor);
        if(semValor == 1){
            //Leer de la entrada estandar
            if(fgets(Mensaje, sizeof(Mensaje), stdin) != NULL){
                if(strncmp(Mensaje,"exit",4)==0){
                    sprintf(buffer[0].mtext,"%s SE HA DESCONECTADO",auxIdentificador);
                    len=strlen(buffer[0].mtext);
                    printf("%s \n",buffer[0].mtext);
                    //if (msgsnd(colaMensaje, &buffer[0], len+1, 0) == -1) perror("msgsnd: ");
                    sem_wait(semMensajes);
                    break;
                }
                if(strncmp(Mensaje,"send",4)==0){
                    len=strlen(Mensaje);
                    char archivo[15];
                    for(int i=0;i<len-6;i++)archivo[i]=Mensaje[i+5];
                    //printf("Archivo: %s %d %d\n",archivo,len, strlen("In.txt"));
                    
                    FILE *Fin = fopen(archivo, "r");
                    if (Fin == NULL) {
                        perror("error Leer archivo: ");
                    }
                    char linea[50];
                    sprintf(buffer[0].mtext,"%s envia ARCHIVO --> %s,\n Contenido: \n",auxIdentificador,archivo);
                    while(fgets(linea,sizeof(linea),Fin)!=NULL){
                        strcat(buffer[0].mtext,linea);
                    }
                    fclose(Fin);
                    strcat(buffer[0].mtext,"\n Fin del archivo\n");
                    len=strlen(buffer[0].mtext);
                    //printf("%s \n",buffer[0].mtext);
                    msgsnd(colaMensaje, &buffer[0], len+1, 0);
                    sem_wait(semMensajes);
                }
                else{
                    len = strlen(Mensaje); //numero de caracteres leidos
                    if (buffer[0].mtext[len-1] == '\n') buffer[0].mtext[len-1] = '\0';
                    strcat(auxIdentificador,Mensaje);
                    sprintf(buffer[0].mtext,"%s",auxIdentificador);
                    len=strlen(buffer[0].mtext);
                    //printf("%s \n",buffer[0].mtext);
                    if (msgsnd(colaMensaje, &buffer[0], len+1, 0) == -1) perror("msgsnd: ");
                    sem_wait(semMensajes);
                    //limpiar variables
                    memset( buffer[0].mtext, 0, len);
                    len=strlen(auxIdentificador);
                    memset( auxIdentificador, 0, len);
                    len = strlen(Mensaje); 
                    memset( Mensaje, 0, len);
                    len=strlen(identificador);
                    for(int i=0;i<len;i++)auxIdentificador[i]=identificador[i];
                }
            }
        }
    }
    desconectarse();
    return NULL;
} 
void *recibirMensaje(void* args){
    //abrir la cola, hacerlo dinamicamnete es un poco complejo, por ello codigo spaguetti
    key_t key;
    char comando[15]="touch ";
    char identificador[100]="User ";
    int len=strlen(nroPid); 
    char aux[len];
    for(int i=0;i<len;i++)aux[i]=nroPid[i];
    strcat(comando, aux);
    strcat(comando, ".txt\0");
    system(comando);
    strcat(aux,".txt");
    //se crea un llave 
    if ((key = ftok(aux, 'A')) == -1) { 
        perror("creacion del token : ");
        exit(EXIT_FAILURE);
    }
    colaMensaje = msgget(key, IPC_CREAT | 0666 );
    if (colaMensaje == -1) { 
        perror("creacion de la cola: ");
        exit(EXIT_FAILURE);
    }
  while(chatActivo==1){
    //recuperar los mensajes del servidor cuyo identificador de tipo es 20
    if (msgrcv(colaMensaje, &buffer[1], sizeof(buffer[1].mtext), 20, 0) == -1 && chatActivo==1) {
      perror("msgrcv: ");
      exit(EXIT_FAILURE);
    }
    //se recibe el mensaje y lo muestra en pantalla
    printf("\n%s",buffer[1].mtext);
    //limpian variables
    len=strlen(buffer[1].mtext);
    memset( buffer[1].mtext, 0, len);
  }
  return NULL;
}
//cuando el usuario decide desconectarse se debe liberar los recursos que se estan usando del SO
void desconectarse(){
    chatActivo=0;
    if (msgctl(colaMensaje, IPC_RMID, NULL) == -1) { //Eliminar cola
        perror("msgctl:");
        exit(EXIT_FAILURE);
    }
    char comando[15]="rm ";
    strcat(comando,ubicacionCola);
    system(comando);
}
//se abren los semaforos para los recursos criticos (mapProceso y comunicacion con el server)
void crearSemaforos(){

    semProcesos = sem_open("semaforoProcesos",O_RDWR);
    if(semProcesos == SEM_FAILED){perror("sem_open semProcesos: ");exit(EXIT_FAILURE);}
    semMensajes = sem_open("semaforoMensajes",O_RDWR);
    if(semMensajes== SEM_FAILED){perror("sem_open semMensajes: ");exit(EXIT_FAILURE);}
}
//se crea la zona de Memoria compartida para los nuevos usuarios(procesos)
void crearMemoria(){
    mapProceso = shm_open("mapProceso", O_CREAT | O_RDWR, 0666); 
    ftruncate(mapProceso , 11); 
    mapPunteroProceso = mmap(NULL, 11, PROT_READ | PROT_WRITE,  MAP_SHARED, mapProceso , 0);

}