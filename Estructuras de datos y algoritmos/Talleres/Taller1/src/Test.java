import edu.princeton.cs.algs4.StdOut;

public class Test {
	public static void main(String [] args) {
		try {
			Pacman p = new Pacman(); //Pacman en 0,0 ->
			Laberinto l = new Laberinto(); //MAtriz por defecto 5x5
			
			assert(p.Mover(l)); //Si se puede mover ->
			assert(p.CambiarDireccion('S')); // Se cambia de direccion
			p.Mover(l);
			p.CambiarDireccion('A');
			assert( !p.Mover(l)); // No se puede mover <-
			assert(!l.ValidarPosicion(new Pacman(1,0))); //Ese nuevo pacman no puede tener es posicion en ese laberinto
			
		}
		catch (Exception e) {
			StdOut.println(e.getMessage());
		}
	}
}
