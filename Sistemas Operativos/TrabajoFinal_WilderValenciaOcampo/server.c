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





int main(int argc, char const *argv[])
{
    //Creacion de las variables utilizada para permitir la comunicacion y sincronizacion
    //Memoria Compartida
    int mapRx_fd = shm_open("mapTx", O_CREAT | O_RDWR, 0666); 
	void* mapRx_ptr = mmap(0, 4096, PROT_WRITE, MAP_SHARED, mapRx_fd, 0);
    int mapTx_fd = shm_open("mapRx", O_CREAT | O_RDWR, 0666); 
	void* mapTx_ptr = mmap(0, 4096, PROT_WRITE, MAP_SHARED, mapTx_fd, 0);
    //Semaforos
    sem_t *semTx = sem_open("semRx",O_CREAT | O_RDWR, 0666, 0);
    sem_t *semRx = sem_open("semTx",O_CREAT | O_RDWR);
    if(semTx==SEM_FAILED || SEM_FAILED==SEM_FAILED){ //Utilizada para comprobar la creacion de los semaforos
        perror("Error:\n");
    }
    int semRxValue;

    while(1){
        //Funcionamiento de los semaforos para adquirir acceso al recurso
        //, es decir el server trata de accrder a la zona de recepcion de mensajes
        // para posteriormente  comuniucarse con los clientes
        sem_getvalue(semRx,&semRxValue); 
        if(semRxValue == 1){
            

            char * status;
            int semTxValue;
            //posterior el server enviara la informacion disponible a los cleintes
             do{
                sem_getvalue(semTx,&semTxValue); //acceso a la zona de memoria de envio
                if(semTxValue == 0){
                    //Envia a la zona de envio el mensaje broadcast
                    status = fgets( (char *) mapTx_ptr, 4096, mapRx_ptr);   
                    if( status == NULL){ //controla que si se pudo envia el mesnaje a la zona compartida
                        break;
                    }
                    sem_post(semTx);//libera el recurso
                }
            }while(status==0);
        }
          
    }
    return 0;
}
