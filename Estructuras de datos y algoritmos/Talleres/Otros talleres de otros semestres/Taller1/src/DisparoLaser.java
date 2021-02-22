import edu.princeton.cs.algs4.StdDraw;

public class DisparoLaser implements IDisparoLaser {
	private int x;
	private int y;
	

	public void setY(int y) {
		this.y = y;
	}

	public static int tamaño=20;
	
	public DisparoLaser() {}
	public DisparoLaser(int x, int y) throws Exception {
		if(y>0 || y<-tamaño)throw new Exception("La posicion del disparo no puede sobrepasar los limites del juego,1");
		if(x<0 || x>tamaño)throw new Exception("La posicion del disparo no puede sobrepasar los limites del juego,2");
		this.y=y;
		this.x=x;
		
	}
	

	
	public int getX() {
		return x;
	}



	public int getY() {
		return y;
	}



	public boolean validarDisparoI(Invasor x) {
		if(this.x==x.getX() && this.y==x.getY()) return true;
		return false;
	}

	
	public boolean validarDisparoC(Cannon x) {
		if(this.x==x.getX() && this.y==x.getY()) return true;
		return false;
	}

	
	public boolean moverDI() {
		if(y==-tamaño) {	
			return false;
			}
			else {
				y--;
				return true;
			}
	}

	
	public boolean moverDC() {
		if(y==tamaño) {	
			return false;
			}
			else {
				y++;
				return true;
			}
	}
	
	public void pintar() {
		StdDraw.filledCircle(x, y, 0.15);
	}

}
