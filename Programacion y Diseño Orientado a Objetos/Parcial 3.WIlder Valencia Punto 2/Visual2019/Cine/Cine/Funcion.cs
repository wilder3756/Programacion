using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Funcion
    {
        private long Identificacion;
        private static long Ide;
        private Pelicula pelicula;
        private Sala sala;
        private int Duracion;
        private DateTime Hora_Inicio;

        public Funcion(Pelicula pelicula, Sala sala, DateTime hora_Inicio)
        {
            Ide++;
            Identificacion = Ide;
            this.pelicula = pelicula ?? throw new ArgumentNullException(nameof(pelicula));
            this.sala = sala ?? throw new ArgumentNullException(nameof(sala));
            if (hora_Inicio > DateTime.Now) Hora_Inicio = hora_Inicio;
            else throw new Exception("Una funcion no puede tener una fecha de inicio menor a la actual");
            Duracion = 45 + Pelicula.Duracion1;
        }
        public Funcion() { }

        public long Identificacion1 { get => Identificacion; }
        public Pelicula Pelicula { get => pelicula; }
        public Sala Sala { get => sala; }
        public int Duracion1 { get => Duracion; }
        public DateTime Hora_Inicio1 { get => Hora_Inicio; }


    }
}

