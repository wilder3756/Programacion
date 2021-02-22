import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdDraw;
/*	NOTA: En cuanto a las direcciones del pacman, se hacen las siguientes aclaraciones:
 * 		Arrriba: con la tecla 'w'
 * 		Abajo: con la tecla 's'
 * 		Derecha: con la tecla 'd'
 * 		Izquierda: con la tecla 'a' */
public class Principal {
	public static void main(String [] args) {
		try {
			Pacman pac = new Pacman(); //Pacman 0,0
			Laberinto lab = new Laberinto(".\\Matriz.txt"); //Matriz cargada desde el archivo en bin
			char dir=pac.getDireccion(); //Direccion por defecto
			
			StdDraw.clear(StdDraw.BLACK); //Color de fondo de los graficos
			lab.pin+tar(); // Pintar el laberinto
			pac.pintar(); // Pintar el pacman en la posicion inicial
			
			while(!StdDraw.isKeyPressed(27)) { //Condicion de salir del ciclo
				//Si se teclea algo se toma esa tecla y se convierte a un char en mayuscula
				if(StdDraw.hasNextKeyTyped()) dir = (StdDraw.nextKeyTyped()+"").toUpperCase().charAt(0);
				
				pac.CambiarDireccion(dir); // Se cambia la direccion segun se haya escrito
				pac.clear(); //Se "borra" el pacman que esta
				pac.Mover(lab); // Se mueve el pacman
				pac.pintar(); //Se vuelve a pintar en la nueva posicion
				StdDraw.pause(250); //La pausa
			}
			StdDraw.clear(StdDraw.BLACK);
			StdDraw.setPenColor(8, 7, 97);
			StdDraw.text(lab.getNroColumnas()/2 - 0.5, -(lab.getNroFilas()/2), "Fin del juego");
		}
		catch (Exception e) {
			StdOut.println(e.getMessage());
		}
	}
}