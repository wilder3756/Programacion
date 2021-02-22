import java.util.Iterator;

import edu.princeton.cs.algs4.Bag;

public interface IBusquedaSimilares {
	public Bag<String> get(String termino);		
	public void add(String termino);	
	public void add(String[] terminos);		
	public Iterator<String> similares(String termino);

}
