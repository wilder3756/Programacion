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

char * myfifo = "/tmp/myfifo";
char * myfifo1 = "/tmp/myfifo1";

void *leerFIFO(void* arg);

int main(int argc, char const *argv[])
{
    
    mkfifo(myfifo, 0666);
    mkfifo(myfifo1, 0666);

    int fd;
    char arr2[80]; 
    pthread_t leer;
    //pthread_create(&leer,NULL,&leerSFIFO,NULL);
    pthread_create(&leer, NULL, leerFIFO, NULL);

    //Escribir
    while (1) 
    {  //Sincronizar
        fd = open(myfifo, O_WRONLY); 
        fgets(arr2, 80, stdin); 
        write(fd, arr2, strlen(arr2)+1); 
        close(fd);
        //sleep(1000);
    } 
    pthread_join(leer, NULL); 
    return 0;
}

void *leerFIFO(void* arg){
    char arr1[80];
    int fd;
    while (1)
    {
        //sleep(1000);
        fd = open(myfifo1, O_RDONLY);  
        read(fd, arr1, sizeof(arr1)); 
        printf("Usuario: %s\n", arr1); 
        close(fd);
    }
    return NULL;
}