import edu.princeton.cs.algs4.StdOut;

public class Test {
	
	public static void main(String[] args) {
		
		try {
		
		Invasor I = new Invasor(1,1,"A",'a');
		Cannon c = new Cannon (1);
		
		DisparoLaser y =new DisparoLaser(I.getX(),I.getY());
		
		assert(y.validarDisparoI(I));//el invasor i genero un nuevo disparo inicialmente esta en la misma posicion
		assert(y.moverDI());
		assert(y.getY()==-2);
		
		assert(c.mover('a'));
		assert(c.mover('a')==false);
		assert(c.getX()==0);
		
		I.mover();
		assert(I.getX()==0);
		I.mover();
		assert(I.getX()==1);
		assert(I.cambiarDireccion('C')==false);
		assert(I.cambiarDireccion('a'));
		assert(I.cambiarDireccion('d'));
		
		}
		catch (Exception e) {
			StdOut.println(e.getMessage());
		}
		
	}

}
