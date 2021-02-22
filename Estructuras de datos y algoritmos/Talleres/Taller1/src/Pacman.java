import edu.princeton.cs.algs4.StdDraw;

public class Pacman implements IPacman{
	private int X,Y;
	private char Direccion;
	
	public Pacman() { //Constructo por defecto
		X=0;
		Y=0;
		Direccion='D';
	}
	
	public Pacman(int x, int y) throws Exception { //Constructor con coordenadas
		if(x < 0) throw new Exception("La posicion en x no puede ser negativo.");
		if(y < 0) throw new Exception("La posicion en y no puede ser negativo.");
		X=x;
		Y=y;
		Direccion='D';
	}
	
	public int getX() {
		return X;
	}
	
	public int getY() {
		return Y;
	}
	
	public char getDireccion() {
		return Direccion;
	}
	
	public boolean Mover(ILaberinto l) { // Mover el pacman en un laberinto
		if(l == null) return false;
		try { // Se mira cual es la direccion y según esa validar la nueva posicion que tendrá el pacman
			if(Direccion == 'W') {
				if(X == 0 && l.ValidarPosicion(new Pacman(l.getNroFilas()-1, Y))) {
					X = l.getNroFilas() -1;
					return true;
				}
				else if(l.ValidarPosicion(new Pacman(X-1, Y))){
					X--;
					return true;
				}
			}
			else if(Direccion == 'S') {
				if(X == l.getNroFilas()-1 && l.ValidarPosicion(new Pacman(0, Y))){
					X = 0;
					return true;
				}
				else if(l.ValidarPosicion(new Pacman(X+1, Y))){
					X++;
					return true;
				}
			}
			else if(Direccion == 'A') {
				if(Y == 0 && l.ValidarPosicion(new Pacman(X, l.getNroColumnas()-1))) {
					Y = l.getNroColumnas()-1;
					return true;
				}
				else if (l.ValidarPosicion(new Pacman(X, Y-1))) {
					Y--;
					return true;
				}
			}
			else if(Direccion == 'D'){
				if(Y == l.getNroColumnas()-1 && l.ValidarPosicion(new Pacman(X, 0))) {
					Y = 0;
					return true;
				}
				else if (l.ValidarPosicion(new Pacman(X, Y+1))) {
					Y++;
					return true;
				}
			}
		}
		catch (Exception e) {
		}
		return false; // Si ninguna dió o hay un error devuelve falso
	}
	
	public boolean CambiarDireccion(char d) {
		d = (d+"").toUpperCase().charAt(0); //Se convierte la direccion en mayuscula
		if(d != 'W' && d != 'A' && d != 'S' && d != 'D') return false;
		Direccion = d; //Se valida que solo hayan direcciones correctas
		return true;
	}
	
	public void pintar() { //Se pinta el pacman
		StdDraw.setPenColor(248, 255, 31);
		StdDraw.filledCircle(Y, -X, 0.45);
		StdDraw.setPenColor(StdDraw.BLACK);
		switch(Direccion) {
			case 'W':
				StdDraw.filledCircle(Y-0.1, -X+0.1, 0.05);
				double[] xw = { Y+0.2, Y-0.1, Y+0.3};
				double[] yw = {-X, -X+0.5, -X+0.4};
				StdDraw.filledPolygon(xw, yw);
				break;
			case 'S':
				StdDraw.filledCircle(Y+0.1, -X-0.1, 0.05);
				double[] xs = { Y-0.2, Y+0.1, Y-0.3};
				double[] ys = {-X, -X-0.5, -X-0.4};
				StdDraw.filledPolygon(xs, ys);
				break;
			case 'D':
				StdDraw.filledCircle(Y+0.1, -X+0.1, 0.05);
				double[] xd = { Y-0.1, Y+0.5, Y+0.5};
				double[] yd = {-X, -X, -X-0.3};
				StdDraw.filledPolygon(xd, yd);
				break;
			case 'A':
				StdDraw.filledCircle(Y-0.1, -X+0.1, 0.05);
				double[] xa = { Y+0.1, Y-0.5, Y-0.5};
				double[] ya = {-X, -X, -X-0.3};
				StdDraw.filledPolygon(xa, ya);
				break;
		}
		/*Se tiene que graficar el pacman en el cuarto cuadrante del plano cartesiano
		 * que sería el espejo del primer y tercer cuadrante de un plano cartesiano
		 * por eso se envia Y,-X en vez de X,Y
		 */
	}
	
	public void clear() { //Se borra el pacman pintando un cuadro del color del fondo
		StdDraw.setPenColor(0, 0, 0);
		StdDraw.filledSquare(Y, -X, 0.5);
	}
	
	@Override
	public String toString() {
		return "(" + X + "," + Y +") " + Direccion;
	}
}
