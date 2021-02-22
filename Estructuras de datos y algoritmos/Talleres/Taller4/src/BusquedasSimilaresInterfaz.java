/*
 * Wilder Valencia Ocampo ID 000375627
 * Luis Esteban Santamaria ID 000255600
 * Emilio Martinez Rivera ID 000291800
 */

import java.util.Iterator;
import edu.princeton.cs.algs4.*;

public interface BusquedasSimilaresInterfaz {
	//Metodos definidos en el punto 2 del taller 4
	public Bag<String> get(String termino);		// Devuelve el conjunto de términos similares al término de búsqueda.
	public void add(String termino);	// Agrega un término al conjunto de terminos conocidos
	public void add(String[] terminos);		//  Agrega una colección de términos a la colección.
	public Iterator<String> similares(String termino);		//Devuelve un iterador sobre el conjunto de términos similares al término de entrada.
}
