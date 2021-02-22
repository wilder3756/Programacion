import edu.princeton.cs.algs4.Bag;
import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.StdIn;
import edu.princeton.cs.algs4.StdOut;

public class Contacto {
	private BusquedaSimilares contactosBS=new BusquedaSimilares();
	private String[][] Lcontactos;
	
	
	
	public Contacto(String ruta) {
		In archivo = new In(ruta); 
		String[] filas;
		
		filas = archivo.readAllLines(); 
		archivo.close(); 
		
		String[] contac;
		Lcontactos=new String[filas.length][2];
		
		for(int i=0;i<filas.length;i++) {
			
			contac=filas[i].split(",");
			contactosBS.add(contac[0]);
			Lcontactos[i][0]=contac[0];
			Lcontactos[i][1]=contac[1];
		}
		
	}
	public String toStringContacto(String contacto) {
			for(int i=0;i<Lcontactos.length;i++) {
				if(Lcontactos[i][0].toLowerCase().compareTo(contacto)==0) {
					return "Contacto: "+Lcontactos[i][0]+"		Numero: "+Lcontactos[i][1];
				}
			}
			return null;
	}
	public Bag<String> getContactosFragmentos(String termino){
		return contactosBS.get(termino);
	}
	public static void main(String[] args) {
		try {
			
			Contacto contactos=new Contacto(".\\contactos.txt");
			int nrocontacto;
			int terminar=0; 
			
			do {
				StdOut.println("Ingrese el patron de busqueda");
				String patron=StdIn.readString();
				int j=0;
				Bag<String> similares=contactos.getContactosFragmentos(patron);
				
				if(similares.isEmpty()==false) {
					for(String i:similares ) {
						StdOut.println(++j+". "+i);
					}
					StdOut.println("Ingrese el numero de contacto que desea buscar");
					nrocontacto=StdIn.readInt();
					
					if(nrocontacto<=j && nrocontacto>0) {
						j=0;
						for(String i:similares) {
							if(nrocontacto==++j) {
								StdOut.println(contactos.toStringContacto(i));
							}
						}
					}
					else StdOut.println("Debio ingresar un contacto valido, Reintente la Busqueda");
				}
				else StdOut.println("No se encontraron contactos que coincidan con el patron");
				
				
				StdOut.println("Desea Continuar: 0->SI");
				
				terminar=StdIn.readInt();
			}while(terminar==0);
			StdOut.println("Fin de la Prueba");
			
			
		}
		catch(Exception e) {
			StdOut.println(e.getMessage());
		}
		
	}
}
