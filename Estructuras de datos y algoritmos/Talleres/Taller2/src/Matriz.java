import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.Stopwatch;

public class Matriz implements IMatriz{

	private int Filas, Columnas;
	private double[][] matriz;
	private static double Tol = 1E-8;
	
	public Matriz(int N, int M) throws Exception {
		if(N <= 0 || M <= 0)throw new Exception("Las dimensiones deben ser mayores de cero");
		matriz = new double[N][M];
		Filas = N;
		Columnas = M;
		for(int i=0; i < Filas; i++) 
			for(int j=0; j < Columnas; j++) 
				matriz[i][j] = 0;
		
	}
	
	public Matriz(double[][] m) {
		matriz = m;
		Filas = matriz.length;
		Columnas  = matriz[0].length;
	}
	
	public int getFilas() {
		return Filas;
	}
	
	public int getColumnas() {
		return Columnas;
	}

	public double[][] getMatriz(){
		return matriz;
	}
	
	public Matriz sumar(IMatriz b) throws Exception {
		if(Filas != b.getFilas() || Columnas != b.getColumnas()) throw new Exception("Las matrices deben ser del mismo orden");
		double[][] c = new double[Filas][Columnas], aux= b.getMatriz();
		for(int i=0; i < Filas; i++)
			for(int j=0; j < Columnas; j++)
				c[i][j] = matriz[i][j] + aux[i][j];
	
		return new Matriz(c);
	}

	public Matriz multiplicar(double r) throws Exception{
		double[][] c = new double[Filas][Columnas];
		for(int i=0; i < Filas; i++)
			for(int j=0; j < Columnas; j++)
				c[i][j] = r* matriz[i][j];
		
		return new Matriz(c);
	}

	public Matriz multiplicar(IMatriz b) throws Exception {
		if(Columnas != b.getFilas()) throw new Exception("Las filas de la primera deben ser iguales a las columnas de la segunda");
		double[][] c = new double[Filas][b.getColumnas()], aux = b.getMatriz();
		double item = 0;
		for(int i=0; i < Filas; i++) {
			for(int j=0; j < b.getColumnas(); j++) {
				for(int k=0; k < b.getFilas(); k++) 
					item += matriz[i][k] * aux[k][j];
				c[i][j] = item;
				item = 0;
			}
		}
		return new Matriz(c);
	}

	public double[] eliminacionGauss(double[] b) throws Exception {
		if(Filas != Columnas || Filas != b.length) throw new Exception("La matriz debe ser NxN y el tamaño del vector debe ser N");
		int k, i , j;
		
		for(i=0; i < Filas; i++)
			if(matriz[i][i] == 0) throw new Exception("La diagonal principal no puede contener ceros");
		
		double s = 0;
		double[] x = new double[Filas];
		double[][] temp = matriz;
		
		for(i = 0; i < Filas - 1; i++) {
			for(j = i + 1; j < Filas; j++) {
				b[j] = temp[i][i]*b[j] - temp[j][i]*b[i];
				for(k = Filas - 1; k >= 0; k--)
					temp[j][k] = temp[i][i]*temp[j][k] - temp[j][i]*temp[i][k];
			}
		}
		
		for(i = Filas - 1; i >= 0; i--, s = 0) {
			for(j = i + 1; j < Filas; j++)
				s += temp[i][j]*x[j];
			x[i] = (b[i] - s) / temp[i][i];
		}
		return x;
	}
	
	public String toString() {
		String s="";
		for(int i=0; i < Filas; i++) {
			for(int j=0; j < Columnas; j++)
				s += matriz[i][j]+" | ";
			s +="\n";
		}
		return s;
	}
	
	public boolean equals(Matriz b) throws Exception{
		if(Filas != Columnas) return false;
		double[][] b2 = b.getMatriz();
		for(int i=0; i < Filas; i++)
			for(int j=0; j < Columnas; j++)
				 if(Math.abs(matriz[i][j] - b2[i][j]) > Tol) return false;
		
		return true;
	}
	
	public static Matriz generarMatrizIdentidad(int N) throws Exception {
		double[][] m = new double[N][N];
		for(int i=0; i < N; i++)
			m[i][i] = 1;
		
		return new Matriz(m);
	}
	
	public static Matriz generarMatrizAleatoria(int N, int M) throws Exception {
		double[][] m = new double[N][M];
		for(int i=0; i < N; i++)
			for(int j=0; j< M; j++) {
				m[i][j] = (int)(StdRandom.gaussian()*10);
				if (m[i][j] == 0) m[i][j] ++;
			}
		
		return new Matriz(m);
	}

	public static double medirSuma(int N) throws Exception {
		Matriz a = generarMatrizAleatoria(N, N), b = generarMatrizAleatoria(N, N);
		Stopwatch tem = new Stopwatch();
		a.sumar(b);
		return tem.elapsedTime();
	}
	
	public static double medirProducto(int N) throws Exception {
		Matriz a = generarMatrizAleatoria(N, N), b = generarMatrizAleatoria(N, N);
		Stopwatch tem = new Stopwatch();
		a.multiplicar(b);
		return tem.elapsedTime();
	}
	
	public static double medirElimGaus(int N) throws Exception {
		Matriz a = generarMatrizAleatoria(N, N);
		double[] b = new double[N];
		for(int i=0; i < N; i++)
			b[i] = (int)(StdRandom.gaussian()*10);
		Stopwatch tem = new Stopwatch();
		a.eliminacionGauss(b);
		return tem.elapsedTime();
	}
}
