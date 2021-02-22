#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>
#include <pthread.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>


//Variable para la cola de mensajes
int colaMensajes;

struct msgbuf {
   long mtype;
   char mtext[200];
};

struct msgbuf buffer[2];

void *enviarMensaje(void* args);
void *recibirMensaje(void* args);


int main(void) {
  key_t key;
  pthread_t hilos[2];
  system("touch colaMensajes.txt");
  //se crea un llave 
  if ((key = ftok("colaMensajes.txt", 'A')) == -1) { 
    perror("creacion de la token: ");
    exit(EXIT_FAILURE);
  }
  //Crear cola de mensajes
  if ((colaMensajes = msgget(key, IPC_CREAT | 0666 )) == -1) { 
    perror("creacion de la cola: ");
    exit(EXIT_FAILURE);
  }
  
  printf("Chat abierto (para finalizar escribe 'q'):\n");
  
  pthread_create(&hilos[0], NULL, &enviarMensaje,NULL); 
  pthread_create(&hilos[1], NULL, &recibirMensaje,NULL); 

  pthread_join(hilos[0], NULL);
  pthread_join(hilos[1], NULL);

  if (msgctl(colaMensajes, IPC_RMID, NULL) == -1) { //Eliminar cola
    perror("msgctl:");
    exit(EXIT_FAILURE);
  }
  printf("Chat Finalizado.\n");
  system("rm colaMensajes.txt");
  return EXIT_SUCCESS;
}

void *enviarMensaje(void* args){
  int len;
  buffer[0].mtype = 20; //el chat 1 envia mensajes cuyo tipo es 20
  while(1) {
    //Leer de la entrada estandar
    if(fgets(buffer[0].mtext, sizeof(buffer[0].mtext), stdin) != NULL){
      len = strlen(buffer[0].mtext); //numero de caracteres leidos
      if (buffer[0].mtext[len-1] == '\n') buffer[0].mtext[len-1] = '\0'; //Eliminar el enter
      if (msgsnd(colaMensajes, &buffer[0], len+1, 0) == -1) perror("msgsnd: ");
      //Condicion para terminar
      if(strcasecmp(buffer[0].mtext,"q")==0 || strcasecmp(buffer[1].mtext,"q")==0) break;
    }
  }
  return NULL;
}

void* recibirMensaje(void *args){
  while(1){
    //recuperar los mensajes del chat2 cuyo identificador de tipo es 10
    if (msgrcv(colaMensajes, &buffer[1], sizeof(buffer[1].mtext), 10, 0) == -1) {
      perror("msgrcv: ");
      exit(EXIT_FAILURE);
    }
    //se recibe el mensaje y lo muestra en pantalla
    printf("\nCh2: %s\n",buffer[1].mtext);
    //Condicion para terminar
    if(strcasecmp(buffer[1].mtext,"q")==0 || strcasecmp(buffer[0].mtext,"q")==0) break;
  }
  return NULL;
}