public interface IMatriz {
	public int getFilas(); //Obtener el numero total de filas
	public int getColumnas(); //Obtener el numero total de columnas
	public double[][] getMatriz(); //Obtener la matriz
	public IMatriz sumar(IMatriz b) throws Exception;
	public IMatriz multiplicar(IMatriz b) throws Exception;
	/*
	 * Retorna una IMatriz que es el resultado de la operacion (suma o multiplicacion) de las dos matrices
	 * Recibe una matriz, que es el segundo operando, la matriz que llama el metodo es el primer operando
	 */
	public IMatriz multiplicar(double r) throws Exception; //Recibe el numero a multiplicar la matriz y retorna el resultado
	public double[] eliminacionGauss(double[] b) throws Exception;
	/* Retorna el vector solucion tamaño N del sistema de ecuacion (matriz NxN)
	 * Recibe un vector de tamaño N que son los terminos independientes del sistema de ecuaciones
	 */
	//NINGUN METODO MODIDFICA LA MATRIZ QUE LO INVOCA
}
