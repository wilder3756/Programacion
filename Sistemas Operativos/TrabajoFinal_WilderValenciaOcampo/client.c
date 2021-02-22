#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include <fcntl.h> 
#include <sys/stat.h> 
#include <unistd.h> 
#include <pthread.h> 
#include <sys/mman.h>
#include <fcntl.h> 
#include <sys/shm.h> 
#include <sys/stat.h>
#include <unistd.h>
#include <pthread.h>
#include <semaphore.h>



void *leer(void* arg);
void *escribir(void* arg);

int main(int argc, char const *argv[])
{
    
    //Creacion de los 2 hilos; uno para recibir mensajes de la entrada estandary enviarlos al server y otro para recibir mensajes del sever
    pthread_t le,es;
    pthread_create(&le,NULL,&leer,NULL);
	pthread_create(&es,NULL,&escribir,NULL);
    if(pthread_join(le, NULL)==0 || pthread_join(es, NULL)==0);
    //pthread_join(leer, NULL); 
	//pthread_join(escribir, NULL);
    return 0;
}
//Hilo encargado de tomas los mensajes del cliente en pantalla
void *escribir(void* arg){
    //Conexion a la zona de memoria compartida
    int mapTx_fd = shm_open("mapTx", O_RDWR, 0666); 
    ftruncate(mapTx_fd, 4096); 
	void* mapTx_ptr = mmap(0, 4096, PROT_WRITE, MAP_SHARED, mapTx_fd, 0);
    sem_t *semTx = sem_open("semTx",O_RDWR, 0666, 0);

    char * status;
    int semTxValue;
    
    //printf("Init client 1 Tx\n");

    while(1){
        //printf("0\n");
        sem_getvalue(semTx,&semTxValue);
        if(semTxValue == 0){
            printf("0\n");
            //strcat(strcat(strcat("User (",(int)getppid),")"),stdin
            status = fgets( (char *) mapTx_ptr, 4096, stdin);   //Envio de informacion al server de un nuevo mensaje de la entrada estandar
            
            if( status == NULL){
                break;
            }   
            sem_post(semTx);//libera el recurso
        }
    }
    return NULL;
}
void *leer(void* arg){
   //Conexion a la zona de memoria compartida
    int mapRx_fd = shm_open("mapRx", O_RDWR, 0666); 
    ftruncate(mapRx_fd, 4096); 
	void* mapRx_ptr = mmap(0, 4096, PROT_READ, MAP_SHARED, mapRx_fd, 0);
    char *aux;
    sem_t *semRx = sem_open("semRx",O_RDWR, 0666, 0);
    int semRxValue;

    //printf("Init client 1 Rx\n");
    while(1){
        //pide acceso a la zona de recepcion de mesnaajes.
        sem_getvalue(semRx,&semRxValue);
        if(semRxValue == 1){
            
            if(strcmp(aux,(char *)mapRx_ptr)!=0){ //comprobacion para no imprimir un mensaje 2 veces
                printf("%s",(char *)mapRx_ptr); //recepcion del mensaje del server  e impresion en pantalla
                aux=(char *)mapRx_ptr;
            }
            
            sem_wait(semRx); //libera el recurso
        }    
    }
    shm_unlink("mapRx");
    return NULL;
}