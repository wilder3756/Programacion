import java.util.Iterator;

import edu.princeton.cs.algs4.Bag;
import edu.princeton.cs.algs4.KMP;
import edu.princeton.cs.algs4.StdOut;

public class BusquedaSimilares implements IBusquedaSimilares {
	private Bag<String> terminos;
	
	public BusquedaSimilares() {
		terminos=new Bag<String>();
	}
	@Override
	public Bag<String> get(String termino) {
		Bag<String> similares=new Bag<String>();
        KMP patron = new KMP(termino.toLowerCase());
        for(String N: terminos) {
        	if(patron.search(N)!=N.length()) similares.add(N);
        }
        return similares;
	}

	@Override
	public void add(String termino) {
		
		terminos.add(termino.toLowerCase());
		
		
	}

	@Override
	public void add(String[] terminos) {
		for(int i=0;i<terminos.length;i++) {
			this.terminos.add(terminos[i].toLowerCase());
		}
		
	}

	@Override
	public Iterator<String> similares(String termino) {
		return get(termino).iterator();
	}

}
