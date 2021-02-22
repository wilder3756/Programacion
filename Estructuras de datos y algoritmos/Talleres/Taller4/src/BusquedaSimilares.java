/*
 * Wilder Valencia Ocampo ID 000375627
 * Luis Esteban Santamaria ID 000255600
 * Emilio Martinez Rivera ID 000291800
 */


import java.util.ArrayList;
import java.util.Iterator;
import edu.princeton.cs.algs4.Bag;
import edu.princeton.cs.algs4.BoyerMoore;
import edu.princeton.cs.algs4.KMP;
import edu.princeton.cs.algs4.RabinKarp;
import edu.princeton.cs.algs4.StdOut;

public class BusquedaSimilares implements BusquedasSimilaresInterfaz {
	private Bag<String> coleccion;
	private int N;
	
	public BusquedaSimilares() {
		coleccion=new Bag<String>();
		N=0;
	}
	
    public Bag<String> get(String termino){
    	//Algoritmo Extraido y adecuado al problema de Brute.java from 5.3 Substring Search de Algorithms, 4th Edition.
        Bag<String> similares=new Bag<String>();
        String S;
        termino=termino.toLowerCase();
        int m = termino.length();
        for(String N: coleccion) {
        	S=N.toLowerCase();
        	int n = S.length();
            for(int i=0;i<=n-m;i++) {
            	int j;
                for(j=0;j<m;j++) {
                    if(termino.charAt(j)!=S.charAt(i+j))break;
                }
                if(j==m) {similares.add(N);  break; }
            }
        }
        return similares;
    }
    
    public Bag<String> getRK(String termino){
        Bag<String> similares=new Bag<String>();
        RabinKarp patron = new RabinKarp(termino);
        for(String N: coleccion) {
        	if(patron.search(N)!=N.length()) similares.add(N);
        }
        return similares;
    }
    public Bag<String> getKMP(String termino){
        Bag<String> similares=new Bag<String>();
        KMP patron = new KMP(termino);
        for(String N: coleccion) {
        	if(patron.search(N)!=N.length()) similares.add(N);
        }
        return similares;
    }
    public Bag<String> getBM(String termino){
        Bag<String> similares=new Bag<String>();
        BoyerMoore patron = new BoyerMoore(termino);
        for(String N: coleccion) {
        	if(patron.search(N)!=N.length()) similares.add(N);
        }
        return similares;
    }
	public void add(String termino) {
		coleccion.add(termino);
		N++;
	}
	public void add(String[] terminos) {
		for(int i=0;i<terminos.length;i++) {
			coleccion.add(terminos[i]);
		}
		N+=terminos.length;
	}
	public Iterator<String> similares(String termino){
	 	
	 	return get(termino).iterator();
		}
	
	
}
	
