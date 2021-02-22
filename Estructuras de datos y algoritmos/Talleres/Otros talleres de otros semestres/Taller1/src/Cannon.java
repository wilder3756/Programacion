import edu.princeton.cs.algs4.StdDraw;

public class Cannon implements ICannon {
	public static int tamaño=20;
	private int x;
	private int y;
	
	public int getX() {
		return x;
	}
	public int getY() {
		return y;
	}
	public Cannon() {}
	
	public Cannon(int x) throws Exception {
		if(x<0 || x>tamaño ) throw new Exception("Las posiciones en x No son validas");
		this.x=x;
		y=-tamaño;
	}
	public boolean mover(char direccion) {
		if(direccion=='d' && x<tamaño){x++; return true;}
		if(direccion=='a' && x>0){x--; return true;}
		return false;
	}
	
	public void pintar() {
		StdDraw.filledRectangle(x, y, 0.5, 0.5);
	}

}
