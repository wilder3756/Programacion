using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Pelicula
    {
        private string Titulo;
        private List<Director> Director;
        private int Duracion;
        private string Genero;
        private string Censura;

        public Pelicula(string titulo, List<Director> directores, int duracion, string genero, string censura)
        {
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Director = directores;
            if (duracion > 39 && duracion < 301) Duracion = duracion;
            else throw new Exception("La duracion de una pelicula no puede ser Inferior  a 40 minutos ni mayor a 5 horas");
            Genero = genero ?? throw new ArgumentNullException(nameof(genero));
            Censura = censura ?? throw new ArgumentNullException(nameof(censura));
        }

        public string Titulo1 { get => Titulo; }
        public List<Director> Director1 { get => Director; }
        public int Duracion1 { get => Duracion; }
        public string Genero1 { get => Genero; }
        public string Censura1 { get => Censura; }
    }
}

