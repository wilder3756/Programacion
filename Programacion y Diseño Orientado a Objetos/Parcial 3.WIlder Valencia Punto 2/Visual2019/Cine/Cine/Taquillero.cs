using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Taquillero : Persona
    {
        private long Cod_Usuario;
        static private long Cod_U = 8000;

        public long Cod_Usuario1 { get => Cod_Usuario; }

        public Taquillero(string nombre, long identificacion, long telefono, string correo) : base(nombre, identificacion, telefono, correo)
        {
            Cod_U++;
            Cod_Usuario = Cod_U;

        }

    }
}

