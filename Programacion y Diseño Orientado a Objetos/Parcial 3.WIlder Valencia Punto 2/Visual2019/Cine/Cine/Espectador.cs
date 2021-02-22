using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Espectador : Persona
    {
        public Espectador(string nombre, long identificacion, long telefono, string correo) : base(nombre, identificacion, telefono, correo)
        {
        }
    }
}
