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
struct msgbuf {
   long mtype;
   char mtext[400];
};
struct msgbuf buffer[2];
struct proceso
{
    char pid[10];
    int colaMensaje;
    char ubicacionCola[10];
};

//Procesos
pthread_t chats[20];
int nroChats=0;
struct proceso infoChats[20];
int nroFaltanLeer;
char * nuevoProceso;
//Semaforos
sem_t *semProcesos; 
sem_t *semMensajes; 

//Memoria
int mapProceso;
void* mapPunteroProceso;

//Firmas Funciones
void *recibirUsuario(void* args);
void *recibirMensaje(void *args);
void *recibirUsuario(void* args);
void crearSemaforos();
void crearMemoria();
void cerrarMemoria();
void cerrarSemaforos();
void cerrarColas();
void enviarMensajesProcesos();
int crearColaMensajes(char * nropid);
int finalizar=0;

int main(int argc, char *argv[]) {
    char *comand;
    crearSemaforos();
    crearMemoria();
    pthread_t aprov;
    pthread_create(&aprov,NULL,recibirUsuario,NULL);
    while (1)
    {
        scanf("%s",comand);
        //el servidor se cierra controladamente
        if(strncmp(comand,"exit",4)==0 ||finalizar==1){
            finalizar=1;
            printf("Cerrando recursos del sistema\n");
            sleep(3);
            cerrarSemaforos();
            cerrarMemoria();
            cerrarColas();
            printf("Finaliza\n");
            return EXIT_SUCCESS;
        }
    }
    
    pthread_join(aprov,NULL);
    cerrarMemoria();
    cerrarColas();
    cerrarSemaforos();
    return EXIT_SUCCESS;
}
void cerrarColas(){
    if(nroChats==0) return;
    for(int i=0;i<nroChats;i++) 
    {
        msgctl(infoChats[i].colaMensaje, IPC_RMID, NULL);
        char comando[15]="rm ";
        strcat(comando,infoChats[i].ubicacionCola);
        system(comando);
    }
}
void cerrarMemoria(){
    //Memoria Nuevos Procesos
    if (munmap(mapPunteroProceso, 11) < 0) {
    perror("Unmapping failed: ");
    exit(EXIT_FAILURE);
    }

    if (close(mapProceso) < 0) { 
        perror("Closing shared memory fd failed: ");
        exit(EXIT_FAILURE);
    }

    if (shm_unlink("mapProceso") < 0) {
        perror("Fallo en eliminar memoria compartida1: ");
        exit(EXIT_FAILURE);
    }

}

void cerrarSemaforos(){
    if(sem_close(semProcesos) == -1){
        perror("Semaforo Procesos: ");
        exit(EXIT_FAILURE);
    }
    if(sem_unlink("semaforoProcesos") == -1){ 
        perror("p2 sem_unlink: ");
        exit(EXIT_FAILURE);
    }
    if(sem_close(semMensajes) == -1){
        perror("Semaforo Procesos: ");
        exit(EXIT_FAILURE);
    }
    if(sem_unlink("semaforoMensajes") == -1){ 
        perror("p2 sem_unlink: ");
        exit(EXIT_FAILURE);
    }

}
void crearMemoria(){
    //Memoria Nuevos Procesos
    mapProceso = shm_open("mapProceso", O_CREAT | O_RDWR, 0666); 
    ftruncate(mapProceso , 11); 
    mapPunteroProceso = mmap(NULL, 11, PROT_READ | PROT_WRITE,  MAP_SHARED, mapProceso , 0);
}
void crearSemaforos(){
    mode_t perms = 0666;
    int flags = O_CREAT;
    unsigned int value = 1; //Valor por defeteco cerrado
    unsigned int value1 = 1; 
    semProcesos = sem_open("semaforoProcesos", flags, perms, value); 
    if(semProcesos == SEM_FAILED){
        perror("sem_open semProcesos:  ");
        exit(EXIT_FAILURE);
    }
    semMensajes= sem_open("semaforoMensajes", flags, perms, value1); //Abrir el semaforo para Out2
    if(semMensajes == SEM_FAILED){
        perror("sem_open semMensajes: ");
        exit(EXIT_FAILURE);
    }
}


void *recibirUsuario(void* args){
    int semValor;
    printf("Inicia Server \n");

    while(finalizar==0){
        sem_getvalue(semProcesos,&semValor);
        if(semValor == 0){
            //como el semaforo esta en cero, alguien consumio el recurso y por tanto hay un nuevo usuario
            char *mens=(char*)mapPunteroProceso;
            if(nroChats<20){
                //Se guarda el pid del nuevo usuario
                sprintf(infoChats[nroChats].pid,"%s",(char*)mapPunteroProceso);
                nroChats++;
                //se crea un hilo para asegurar el canal de comunicacion con el nuevo usuario
                pthread_create(&chats[nroChats-1],NULL,&recibirMensaje,NULL);
                //se libera el recurso, par que nuevos usuarios puedan 'registarse'
                sem_post(semProcesos);
            }
            //la cantidiad de usuarios maximo es superada
            else {
                sem_post(semProcesos);
                finalizar=1;
            } 
        } 

    }
    for(int i=0; i<nroChats;i++) pthread_join(chats[i],NULL);
    pthread_exit(NULL);
}
void* recibirMensaje(void *args){
    //creacion de la cola, hacerlo dinamicamnete es un poco complejo, por ello codigo spaguetti
    int colaMensaje;
    key_t key;
    char comando[15]="touch ";
    char identificador[400]="User ";
    int len=strlen(infoChats[nroChats-1].pid); 
    char aux[len];
    for(int i=0;i<len;i++)aux[i]=infoChats[nroChats-1].pid[i];
    strcat(comando, aux);
    strcat(comando, ".txt\0");
    system(comando);
    strcat(identificador,aux);
    strcat(aux,".txt");
    sprintf(infoChats[nroChats-1].ubicacionCola,"%s",aux);
    
    //printf("%s %s\n",comando,aux);
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
    infoChats[nroChats-1].colaMensaje=colaMensaje;
    int semValor;
    //para recuperar mensajes y evitar que todos envien al mismo tiempo al server se usa un semaforo
    while(finalizar==0){
        sem_getvalue(semMensajes,&semValor);
        if(semValor == 0){ // alguien ha consumido el resurso (escrito al server)
            //recuperar los mensajes del proceso cuyo identificador de tipo es 10
            msgrcv(colaMensaje, &buffer[1], sizeof(buffer[1].mtext), 10, 0);
            //se recibe el mensaje y se hace el bradcast
            enviarMensajesProcesos();
            //se libera el recurso para que otros usuarios puedan enviar informacion al servidor
            sem_post(semMensajes);
        }
        
  }
  return NULL;
}
void enviarMensajesProcesos(){
    int len;
    buffer[0].mtype = 20; //el server envia mensajes cuyo tipo es 20
    len=strlen(buffer[1].mtext);
    //se copia el mensaje leido al paquete que se va enviar
    for(int i=0;i<len;i++) buffer[0].mtext[i]=buffer[1].mtext[i];
    //Se envia la informacion a todos los usuarios que estan conectados con el server
    for(int i=0;i<nroChats;i++) 
    {
        msgsnd(infoChats[i].colaMensaje, &buffer[0], len+1, 0);
    }
    //Se limpian los buffer para los mensajes
    len=strlen(buffer[1].mtext);
    memset( buffer[1].mtext, 0, len);
    len=strlen(buffer[0].mtext);
    memset( buffer[0].mtext, 0, len);
    
}