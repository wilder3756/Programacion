/*
 * Wilder Valencia Ocampo ID 000375627
 * Luis Esteban Santamaria ID 000255600
 * Emilio Martinez Rivera ID 000291800
 */

import java.awt.Color;
import java.awt.List;
import java.util.ArrayList;
import java.util.Arrays;

import edu.princeton.cs.algs4.StdDraw;
import edu.princeton.cs.algs4.StdOut;
import edu.princeton.cs.algs4.StdRandom;
import edu.princeton.cs.algs4.Stopwatch;

public class Taller3 {
	
	//Metodo para generar Puntos aleatorios segerido por el profesor y modificado, para que directamente genere puntos con 2 cordenadas
	public static double[][] generarPuntos(int k, int n) {
        double[][] datapoints = new double[k*n][];
        int pos=0;
        double[] mu = new double[2];
        double[] sigma = new double[2];
        double min=Double.POSITIVE_INFINITY, max=Double.NEGATIVE_INFINITY;
        for(int i=0; i<k; i++) {
            for(int l=0; l<2; l++) {
                mu[l] = 2*(StdRandom.uniform() - 0.5);
                sigma[l] = StdRandom.uniform() / 3;
            }
            for(int j=0; j<n; j++) {
                double[] sample = new double[2];
                for(int l=0; l<2; l++) {
                    sample[l] = StdRandom.gaussian(mu[l], sigma[l]);
                    min = sample[l]<min ? sample[l] : min;
                    max = sample[l]>max ? sample[l] : max;
                }
                datapoints[pos++] = sample;
                //StdOut.println(Arrays.toString(sample));
            }
        }
        //StdOut.println("min = "+min+", max="+max);
        return datapoints;
    }
	//metodo para pintar los puntos sin asignarles clusters
    public static void pintarPuntos(double[][] datapoints) {
        StdDraw.setScale(-2,2);
        StdDraw.setPenRadius(0.005);
        StdDraw.setPenColor(StdDraw.BLACK);
        for(int i=0; i<datapoints.length; i++) {
            StdDraw.point(datapoints[i][0], datapoints[i][1]);
        }
    }
  //metodo para pintar los puntos de diferente color segun el cluster 
    public static void pintarPuntos(double[][] datapoints, int[][] clusters) throws Exception {
    	//Se generan los colores nesesarios para pintar los n clusters
    	int[][] color=new int[nroClusters (clusters)][3];
    	for(int i=0;i<color.length;i++) {
    			color[i][0]=StdRandom.uniform(255);
        		color[i][1]=StdRandom.uniform(255);
        		color[i][2]=StdRandom.uniform(255);
    	}
    
    	StdDraw.setScale(-2,2);
        StdDraw.setPenRadius(0.01);
        
        int[] aux = renombrarClusters(clusters, color.length);
        
        for(int i=0; i < datapoints.length; i++) {
        	StdDraw.setPenColor(color[aux[i]][0],color[aux[i]][1],color[aux[i]][2]);
        	StdDraw.point(datapoints[i][0], datapoints[i][1]);
        }
    }
    
    //Metodo Utilizado para ayudar a pintarPuntos, y facilitar el trabajo
    private static int[] renombrarClusters(int[][] clusters, int MAX) {
    	int[] aux = new int [clusters.length];
    	for(int i=0; i < clusters.length; i++) 
    		aux[i]=-1;
    	
    	for(int j=0, i = 0; j < clusters.length; j++, i++) {
    		if(i == MAX-1)
    			i=0;
        	for(int k=0; k < clusters.length; k++) {
    			if(clusters[j][0] == clusters[k][0]) {
    				if(aux[k] == -1) aux[k]=i;
    			}
        	}
        }
    	
    	return aux;
    }
    
    //Metodo para calcular el numero de clusters para un conjunto de datos
    private static int nroClusters (int[][] clusters) {
    	int nro=0;
    	ArrayList<Integer> aux=new ArrayList<Integer>(); //se aprovecha las listas para meter elementos y rapidamente saber si un elemento esta repetido con contains()
    	
    	for(int i=0;i<clusters.length;i++) 
    		if(!aux.contains(new Integer(clusters[i][0]))) {
    			nro++;
    			aux.add(new Integer(clusters[i][0]));
    		}

    	return nro;
    }
    //Metodo que calcula los clusters de un conjunto de datos, teniendo encuenta una distancia maxima
    public static int[][] clusters(double[][] data, double DMAX){
    	
    	int[][] cluster = new int[data.length][1];
    	double distancia = 0, ditanciaAux = 0;
    	int i;
    	
    	for(i=0; i < data.length; i++)
    		cluster[i][0] = i;
    	
    	for(i = 0; i < data.length; i++) {
    		for(int j = 0; j < data.length; j++) {
    			distancia = Math.sqrt( (data[cluster[i][0]][0]-data[j][0])*(data[cluster[i][0]][0]-data[j][0]) + (data[cluster[i][0]][1]-data[j][1])*(data[cluster[i][0]][1]-data[j][1]));
	    		if(distancia <= DMAX) {
	    			if( cluster[j][0] != j ) {
	    				ditanciaAux = Math.sqrt( (data[cluster[j][0]][0]-data[j][0])*(data[cluster[j][0]][0]-data[j][0]) + (data[cluster[j][0]][1]-data[j][1])*(data[cluster[j][0]][1]-data[j][1]));
	    				if(distancia < ditanciaAux)
	    					cluster[j][0] = cluster[i][0];
	    			}
	    			else
	    				cluster[j][0] = cluster[i][0];
	    		}
    		}
    	}
    	return cluster;
    }

    
    public static void main(String[] args) {
        try {
        	StdRandom.setSeed(656);
        	
        	double[][] puntos = generarPuntos(100,8);
        	//Punto 1
            int[][] clusters = clusters(puntos, 0.7);
            StdOut.println("El Numero de clusters es: "+nroClusters(clusters));
            //Punto 2
            pintarPuntos(puntos, clusters);
            StdOut.println("FIN");
            
        	//Medir Tiempo para clusterizacion, Punto 4
            /*
        	for(int i=0;i<10;i++)	
            	StdOut.println("100: "+medirClusterizacion(10,10));
        	for(int i=0;i<10;i++)
            	StdOut.println("200: "+medirClusterizacion(20,10));
        	for(int i=0;i<10;i++)
            	StdOut.println("400: "+medirClusterizacion(20,20));
        	for(int i=0;i<10;i++)
            	StdOut.println("800: "+medirClusterizacion(40,20));
        	for(int i=0;i<10;i++)
            	StdOut.println("1600: "+medirClusterizacion(100,16));
        	for(int i=0;i<10;i++)
            	StdOut.println("3200: "+medirClusterizacion(100,32));
        	for(int i=0;i<10;i++)
            	StdOut.println("6400: "+medirClusterizacion(100,64));
        	for(int i=0;i<10;i++)
            	StdOut.println("12800: "+medirClusterizacion(100,128));
        	for(int i=0;i<10;i++)
            	StdOut.println("25600: "+medirClusterizacion(256,100));
        	for(int i=0;i<10;i++)
            	StdOut.println("51200: "+medirClusterizacion(512,100));
        	for(int i=0;i<10;i++)
            	StdOut.println("102400: "+medirClusterizacion(1024,100));
            */	
        	
            
		} catch (Exception e) {
			e.printStackTrace();
		}
    }
    
    //Metodo auxiliar utilizado para facilitar las pruebas del punto numero 4
    public static double medirClusterizacion(int n, int k) throws Exception {
    	double[][] puntos = generarPuntos(k,n);
		Stopwatch tem = new Stopwatch();
		clusters(puntos, 0.9);
		return tem.elapsedTime();
	}
}
