public interface IPacman {
	public int getX();
	public int getY();
	public char getDireccion();
	public boolean Mover(ILaberinto l);
	public boolean CambiarDireccion(char d);
}
