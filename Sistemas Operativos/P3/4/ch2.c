#include <stdio.h> 
#include <stdlib.h> 
#include <string.h> 
#include <sys/mman.h>
#include <fcntl.h> 
#include <sys/shm.h> 
#include <sys/stat.h>
#include <unistd.h>
#include <sys/types.h>
#include <pthread.h>
#include <semaphore.h>

void *enviarMensaje(void* args);
void *recibirMensaje(void* args);



int main() 
{ 
	pthread_t hilos[2];

    pthread_create(&hilos[0],NULL,enviarMensaje,NULL);
    pthread_create(&hilos[0],NULL,recibirMensaje,NULL);
    pthread_join(hilos[0],NULL);
    pthread_join(hilos[1],NULL);
	return 0; 
} 

void *recibirMensaje(void* args){
    int mapCh1_Ch2 = shm_open("map12", O_RDWR, 0666); 
	void* mapPuntero = mmap(0, 4096, PROT_READ, MAP_SHARED, mapCh1_Ch2, 0);
    
    sem_t *sem12 = sem_open("semaforoCh1ch2",O_RDWR);
    int sem12Valor;

    printf("Inicia Cliente 2 (Recibir) Rx\n");
    while(1){
        sem_getvalue(sem12,&sem12Valor);
        if(sem12Valor == 1){
            printf("Mensaje Recibido: %s",(char *)mapPuntero);
            sem_wait(sem12);
        }    
    }
    if (munmap(mapPuntero, 4096) < 0) {
    perror("Unmapping failed: ");
    exit(EXIT_FAILURE);
    }

    if (close(mapCh1_Ch2) < 0) { 
        perror("Closing shared memory fd failed: ");
        exit(EXIT_FAILURE);
    }

}

void* enviarMensaje(void * pdata){
    
	int mapCh2_Ch1 = shm_open("map21", O_RDWR, 0666); 
	void* mapPuntero = mmap(0, 4096, PROT_WRITE, MAP_SHARED, mapCh2_Ch1, 0);
    sem_t *sem21 = sem_open("semaforoCh2ch1",O_RDWR, 0666, 0);

    char * status;
    int sem21Valor;
    
    printf("Inicia Cliente 2 (Enviar)\n");

    while(1){
        sem_getvalue(sem21,&sem21Valor);
        if(sem21Valor == 0){
            status = fgets( (char *) mapPuntero, 4096, stdin);   
            if( status == NULL){
                break;
            }
            sem_post(sem21);
        }
    }
     if (munmap(mapPuntero, 4096) < 0) {
    perror("Unmapping failed: ");
    exit(EXIT_FAILURE);
    }

    if (close(mapCh2_Ch1) < 0) { 
        perror("Closing shared memory fd failed: ");
        exit(EXIT_FAILURE);
    }

    pthread_exit(NULL);
}