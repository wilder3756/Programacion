import java.util.ArrayList;
import java.util.Iterator;

import edu.princeton.cs.algs4.Bag;
import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.SequentialSearchST;
import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;

public class Contactos {
	private BusquedaSimilares listaContactos=new BusquedaSimilares();
	private ArrayList<contacto> Lcontactos=new ArrayList();
	
	public class contacto {
		private String llave;
		private String valor;
		public contacto(String key,String val) {
			this.llave=key;
			valor=val;
		}
		public String Llave() {return llave;}
		public String Valor() {return valor;}
		@Override
		public String toString() {
			String[] auxValor=valor.split(",");
			String salida="Contacto: "+llave+"\n";
			
			for(int i=0;i<auxValor.length;i++) {
				salida+="Telefono "+(i+1)+": "+auxValor[i]+"\n";
			}
			return salida;
		}
	}
	
	public Contactos(String ruta) {
		In Arc = new In(ruta); //Archivo
		String[] lineas;
		
		lineas = Arc.readAllLines(); //Leerlo todo, cada posicion es una linea
		Arc.close(); 
		
		String[] auxContactos;
		
		for(int i=0;i<lineas.length;i++) {
			auxContactos=lineas[i].split(",");
			listaContactos.add(auxContactos[0]);
			Lcontactos.add(new contacto(auxContactos[0],auxContactos[1]+","+auxContactos[2]));
		}
	}
	public String obtenerContacto(String contacto) {
			for(contacto j: Lcontactos) {
				if(j.llave.compareTo(contacto)==0) {
					return j.toString();
				}
			}
			return null;
	}
	public Bag<String> getContactosFragmentos(String termino){
		return listaContactos.get(termino);
	}
	public static void main(String[] args) {
		try {
			//Al iniciarse la aplicación carga la lista de un archivo separado por comas que contiene los nombres y los teléfonos de contactos (pueden ser datos ficticios).
			Contactos contactos=new Contactos(".\\BDContactos.txt");
			//String fragmento;
			int NroContactoElegido;
			int des=0,k=0; 
			//Luego entra al ciclo de búsqueda donde:
			do {
				//Se pregunta el fragmento de búsqueda
				StdOut.println("Ingrese el fragmento de busqueda");
				String fragmento=StdIn.readString();
				int j=0;
				Bag<String> similares=contactos.getContactosFragmentos(fragmento);//Retornan los nombres similares
				if(similares.isEmpty()==false) {
					for(String i:similares ) {
						StdOut.println(++j+". "+i);
					}
					//El usuario selecciona un nombre y se presentan los datos correspondientes
					StdOut.println("Ingrese el numero de contacto que desea buscar");
					NroContactoElegido=StdIn.readInt();
					if(NroContactoElegido<=j && NroContactoElegido>0) {
						j=0;
						for(String i:similares) {
							if(NroContactoElegido==++j) {
								StdOut.println(contactos.obtenerContacto(i));
							}
						}
					}
					else StdOut.println("No ingreso un contacto");
				}
				else StdOut.println("Ningun contacto encontrado");
				
				
				StdOut.println("Desea Continuar: 1->SI");
				
				des=StdIn.readInt();
			}while(des==1);
			StdOut.println("Fin del Programa");
			
			
		}
		catch(Exception e) {
			StdOut.println(e.getMessage());
		}
		
	}
}
