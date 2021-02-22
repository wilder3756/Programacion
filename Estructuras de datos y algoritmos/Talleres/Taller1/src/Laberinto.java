import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdDraw;

public class Laberinto implements ILaberinto{
	private int[][] Matriz;
	private int NroFilas, NroColumnas;
	
	public Laberinto() { // Constructor para laberinto por defecto
		NroFilas = 5;
		NroColumnas = 5;
		int[][] m = {{0,0,1,0,1},{1,0,1,0,1},{1,0,0,0,0},{0,0,1,1,0},{1,1,1,0,1}};
		Matriz = m;
	}
	
	public Laberinto(int[][] m) throws Exception { // Constructor con laberinto enviado
		if(m == null) throw new Exception("La matriz no puede estar nula");
		if(m[0][0] != 0) throw new Exception("La matriz del laberinto debe iniciar con 0");
		for(int i = 0; i < m.length; i++) {
			for(int j = 0; j < m[0].length; j++) {
				if(m[i][j] != 0 && m[i][j] != 1) throw new Exception("La matriz del laberinto solo puede contener 0 y/o 1");
			}
		} //Despues de todas las validaciones se llenan los atributos
		Matriz = m;
		NroFilas = Matriz.length;
		NroColumnas = Matriz[0].length;
	}
	
	public Laberinto(String ruta) throws Exception { //Laberinto desde una archivo con libreria In
		In Arc = new In(ruta); //Archivo
		String[] lineas;
		int F=0, C=0;
		
		lineas = Arc.readAllLines(); //Leerlo todo, cada posicion es una linea
		Arc.close(); 
		
		F = lineas.length;
		C = lineas[0].length();
		
		int[][] m = new int[F][C];
		
		for(int i = 0; i < F; i++) {
			for(int j = 0; j < C; j++) {
				//Validacion de ' ' y 'X'
				if(lineas[i].charAt(j) == ' ') m[i][j] = 0;
				else if(lineas[i].toUpperCase().charAt(j) == 'X') m[i][j] = 1;
				else throw new Exception("Error la matriz del laberinto");
			}
		}
		if(m[0][0] != 0) throw new Exception("La matriz del laberinto debe iniciar con 0");
		//Despues de las validaciones se iguala
		Matriz = m;
		NroFilas = F;
		NroColumnas = C;
	}
	
	public int[][] getMatriz(){
		return Matriz;
	}
	
	public int getNroFilas() {
		return NroFilas;
	}
	
	public int getNroColumnas() {
		return NroColumnas;
	}
	
	public boolean ValidarPosicion(IPacman p) { //Se validad que el pacman ingresado pueda estar en las coordenadas de este en el laberinto
		if(Matriz[p.getX()][p.getY()] == 0) return true;
		return false;
	}
	
	public void pintar() {
		StdDraw.setXscale(-1, NroColumnas); //Eje negativo de las X
		StdDraw.setYscale(-NroFilas, 1); // Eje negativo de las Y
		
		for(int i = 0; i < Matriz[0].length; i++) {
			for(int j = 0; j < Matriz.length; j++) {
				if(Matriz[j][i] == 1) {
					StdDraw.setPenColor(8, 7, 97);
					StdDraw.filledSquare(i, -j, 0.5); //Solo se dibuja las paredes
				}
				else {
					StdDraw.setPenColor(255 , 255, 255);
					StdDraw.filledCircle(i, -j, 0.05);
				}
			}
		}
	}
	
	@Override
	public String toString() {
		String sal = "";
		for(int i = 0; i < Matriz.length; i++) {
			for(int j = 0; j < Matriz[0].length; j++) {
				sal += Matriz[i][j];
			}
			sal += "\n";
		}
		return sal;
	}
}
