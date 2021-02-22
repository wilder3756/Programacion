import java.awt.List;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Random;

import edu.princeton.cs.algs4.Bag;
import edu.princeton.cs.algs4.Stack;
import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdOut;

public class Juego {

	public static int tamaño=20;
	public static void main (String[]args) {
		
		try {
			Cannon cañon = new Cannon(10);
			Bag<Invasor> invasores = new Bag<Invasor>();
			ArrayList<DisparoLaser> disparosCannon=new ArrayList<DisparoLaser>();
			ArrayList<DisparoLaser> disparosInvasores=new ArrayList<DisparoLaser>();
			Random r=new Random();
			boolean f=false;;
			Stack<Invasor> a=new Stack<Invasor>();

			invasores.add(new Invasor(0, 0, "A",'d'));
			invasores.add(new Invasor(tamaño-3, 0, "B",'a'));
			invasores.add(new Invasor(7, 0, "A",'d'));
			invasores.add(new Invasor(tamaño-7, 0, "B",'a'));
			invasores.add(new Invasor(10, 0, "A",'d'));
			invasores.add(new Invasor(tamaño-10, 0, "B",'a'));
			invasores.add(new Invasor(4, 1, "B",'d'));
			invasores.add(new Invasor(tamaño-1, 1, "A",'a'));

			
			StdDraw.clear(StdDraw.BLACK);
			StdDraw.setXscale(-1, tamaño+1); //Eje negativo de las X
			StdDraw.setYscale(-tamaño, 1); // Eje negativo de las Y
			StdDraw.setPenColor(248, 255, 31);
			//StdDraw.filledRectangle(10, -20, 0.5, 0.5);
			cañon.pintar();
			while(!StdDraw.isKeyPressed(27) && f==false) {
				//StdDraw.pause(20); 
				
				//Cañon
				//Mover cañon a la izquierda
				if(StdDraw.isKeyPressed(65)) {
					StdDraw.setPenColor(StdDraw.BLACK);
					cañon.pintar();
					cañon.mover('a');
				}
				//mover cañon a la derecha
				if(StdDraw.isKeyPressed(68)) {
					StdDraw.setPenColor(StdDraw.BLACK);
					cañon.pintar();
					cañon.mover('d');
				}
				//pintar el cañon
				StdDraw.setPenColor(248, 255, 31);
				cañon.pintar();
				
				//Borrar la poscion anterior del invasor
				for(int i=0;i<=tamaño;i++) {
					for(int j=0;j<tamaño/3;j++) {
						StdDraw.setPenColor(StdDraw.BLACK);
						StdDraw.filledSquare(i, -j, 0.5);
					}
					
				}
				//pintar los invasores
				for(Invasor i: invasores) {
					i.mover();
					if(i.isEstado()) {
						i.pintar();
					}
					
					
				}
				//DispararCañon
				if(StdDraw.isKeyPressed(32)) {
					disparosCannon.add(new DisparoLaser(cañon.getX(),cañon.getY()));
				}
				
				//DisparosInvasor con una probabilidad de disparo
				for(Invasor i: invasores) {
					if(r.nextDouble()<0.05) {
						disparosInvasores.add(new DisparoLaser(i.getX(),i.getY()));
					}
					
				}
				
				// Pintar los Disparos Cañon
				
				for(DisparoLaser i: disparosCannon ) {
					StdDraw.setPenColor(StdDraw.BLACK);
					i.pintar();
					i.moverDC();
					if(i.getY()==0) {
						for(Invasor j: invasores) {
							if(i.validarDisparoI(j)) {
								j.setEstado(false);
								break;
							}
						}
						//disparosCannon.remove(i);
						continue;
					}
					StdDraw.setPenColor(StdDraw.WHITE);
					i.pintar();
					
				}
				//pintar los disparos Invasor
				for(DisparoLaser i: disparosInvasores ) {
					StdDraw.setPenColor(StdDraw.BLACK);
					i.pintar();
					i.moverDI();
					if(i.validarDisparoC(cañon)) {
						f=true;
						break;
					}
					if(i.getY()==-20 ) {
						i.setY(0);
						continue;
					}
					if(i.getY()==0)continue;
					
					//i.moverDI();
					StdDraw.setPenColor(StdDraw.ORANGE);
					i.pintar();
					
										
				}
				
			}
				
				
			
			StdDraw.clear(StdDraw.BLACK);
			StdDraw.setPenColor(248, 255, 31);
			StdDraw.text(10,-10, "Fin del juego");
			
		}
		catch(Exception e){
			
			StdOut.println(e.getMessage());
			
		}
	}
}
