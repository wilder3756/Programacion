using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public abstract class Persona
    {
        protected string Nombre;
        protected long Identificacion;
        protected long Telefono;
        protected string Correo;

        protected Persona(string nombre, long identificacion, long telefono, string correo)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            if (identificacion > 0) Identificacion = identificacion;
            else throw new Exception("La identificacion no es un negativo o 0");
            if (telefono > 100000 && telefono < 9999999) Telefono = telefono;
            else throw new Exception("Un telefono costa de 7 digitos");
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
        }

        public string Nombre1 { get => Nombre; }
        public long Identificacion1 { get => Identificacion; }
        public long Telefono1 { get => Telefono; }
        public string Correo1 { get => Correo; }




    }
}

