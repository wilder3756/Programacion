public class Taller2 {
	public static void main(String[] args) {
		try {
			Matriz a = new Matriz(3,3), b = Matriz.generarMatrizIdentidad(3),
				c = new Matriz( new double[][] {{2,-1,1},{3,1,-2},{-1,2,5}});
			//Suma
			assert(b.sumar(a).equals(b));
			assert(!b.sumar(b).equals(b));
			//Suma y multiplicar por un  escalar
			assert((b.sumar(b)).equals(b.multiplicar(2)));
			//Multiplicacion por matriz
			assert((Matriz.generarMatrizAleatoria(3,5).multiplicar(new Matriz(5,3)).equals(a)));
			assert(b.multiplicar(b).equals(b));
			//Eliminacion
			assert(equalsVectores(new double[] {2.0,1.0,-1.0},(c.eliminacionGauss(new double[] { 2, 9, -5}))));
			assert(!equalsVectores(new double[] {0.0,0.0,0.0},(b.eliminacionGauss(new double[] { 1, 1, 1}))));
			assert(equalsVectores(new double[] {1.0,1.0,1.0},(b.eliminacionGauss(new double[] { 1, 1, 1}))));
			
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	static boolean equalsVectores(double[] a, double[] b) {
		if(a.length != b.length) return false;
		for(int i = 0; i < a.length; i++)
			if(a[i] != b[i]) return false;
		return true;
	}
}
