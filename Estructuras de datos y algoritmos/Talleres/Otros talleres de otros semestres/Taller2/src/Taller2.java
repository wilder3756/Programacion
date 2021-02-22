//Integrantes
//Juan Esteban Herrera Tapia
//Andres Felipe Parra Sierra

import edu.princeton.cs.algs4.Quick;
import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.Stopwatch;

public class Taller2 {
	//Punto a
	public static int hashCode(String id1,String id2) {
		
		String id=id1+id2;
		return id.hashCode()%5;
	}
	public  static double medirAlgoritmoQuickSort(int n) {
		String[] vector=Taller2.generarVectorLetras(n);
		Stopwatch tem = new Stopwatch();
		Quick.sort(vector);
		return tem.elapsedTime();
	}
	public static String[] generarVectorLetras(int n) {
		String[] vector=new String[n];
		char[] a= {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
		for(int i=0;i<n;i++) {
			vector[i]=String.valueOf(a[i%26]);
		}
		StdRandom.shuffle(vector);
		return vector;
		
	}
	public static double[][] pruebasAlgoritmoQuickSort(){
		double[][] resultados=new double[13][11];
		int N=1000;
		for(int i=0;i<13;i++) {
			for(int j=0;j<11;j++) {
				if (j!=0)resultados[i][j]=Taller2.medirAlgoritmoQuickSort(N);
				else resultados[i][j]=N;
			}
			N*=2;
		}
		return resultados;
	}
	//Punto b
	public static double[] generarDoubleAleatorio(int n) {
		if(n>0) {
			double[] vector=new	double[n];
			
			for(int i=0;i<n;i++) {
				vector[i]=StdRandom.cauchy();
			}
			return vector;
		}
		else return null;
		
		
	}
	//Punto c
	public static double medirDoubleAleatorio(int n) {
		double[] aux;
		Stopwatch tem = new Stopwatch();
		aux=generarDoubleAleatorio( n);
		return tem.elapsedTime();
	}
	public static double[][] pruebasDoubleAleatorio(){
		double[][] resultados=new double[12][21];
		int N=10000;
		for(int i=1;i<=12;i++) {
			for(int j=0;j<21;j++) {
				if(j!=0) {
					if(i==11) resultados[i-1][j]=Taller2.medirDoubleAleatorio(N*20);
					else if(i==12) resultados[i-1][j]=Taller2.medirDoubleAleatorio(N*50);
					else resultados[i-1][j]=Taller2.medirDoubleAleatorio(N*i);
				}
				else {
					if(i==11) resultados[i-1][j]=N*20;
					else if(i==12) resultados[i-1][j]=N*50;
					else resultados[i-1][j]=N*i;
				}
			}
		}
		return resultados;
	}
	//Funcion auxiliar para imprimir pruebas.
	public static void imprimirResultados(double [][] matriz) {
		StdOut.println("   N   |Prueba1|Prueba2|Prueba2|...|PruebaN\n");
		for(int i=0;i<matriz.length;i++) {
			for(int j=0;j<matriz[0].length;j++) {
				StdOut.print("|"+matriz[i][j]);
			}
			StdOut.println("\n");
		}
	}
	public static void main(String[] args) {
		try {
			//punto a
			StdOut.println("El hashCode es: "+Taller2.hashCode("000373085", "000361408"));
			StdOut.println("El resultado experimental de QuickSort es:\n");
			Taller2.imprimirResultados(Taller2.pruebasAlgoritmoQuickSort());
			//Punto b-c
			StdOut.println("\n\n");
			StdOut.println("El resultado experimental de generarDoubleAleatorio es :\n");
			Taller2.imprimirResultados(Taller2.pruebasDoubleAleatorio());
			
			//PD: la ejecucion se demora, pero termina.
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
