import edu.princeton.cs.algs4.StdDraw;

public class Invasor implements IInvasor {
	public static int tamaño=20;
	private int x;
	private int y;
	private String especie;
	private boolean estado;
	public boolean isEstado() {
		return estado;
	}
	public void setEstado(boolean estado) {
		this.estado = estado;
	}
	
	public int getX() {
		return x;
	}
	
	public int getY() {
		return y;
	}
	

	private char direccion;
	
	public Invasor(int x,int y, String especie,char direccion) throws Exception {
		if(x<0 || x>tamaño || y<0 || y>tamaño) throw new Exception("Las posiciones en x y y No son validas");
		especie=especie.toUpperCase();
		if(!(especie.equals("A") || especie.equals("B")))throw new Exception("La especie no es valida");
		if(direccion!='a' && direccion!= 'd')throw new Exception("La direcion solo puede ser derecha o izquierda");
		
		this.x=x;
		this.y=-y;
		this.especie=especie;
		this.direccion=direccion;
		estado=true;
	}
	public void mover() {
		if(direccion=='a' && x>0) {x--;return;}
		if(direccion=='d' && x<tamaño) {x++;return;}
		
		if(x==0 && cambiarDireccion('d')) mover();
		if(x==tamaño && cambiarDireccion('a')) mover();
	}

	public boolean cambiarDireccion(char direccion) {
		if(direccion=='d' || direccion=='a'){this.direccion=direccion;return true;}
		return false;
	}
	
	public void pintar() {
		if(this.especie.equals("A")) {
			StdDraw.setPenColor(StdDraw.BLUE);
			StdDraw.filledSquare(x, y, 0.5);
		}
		else {
			StdDraw.setPenColor(StdDraw.GREEN);
			StdDraw.filledSquare(x, y, 0.5);
		}
	}

}
