using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Director
    {
        private string Nombre;
        private DateTime Año_Nacimiento;
        private string Pais;

        public Director(string nombre, DateTime año_Nacimiento, string pais)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Año_Nacimiento = año_Nacimiento;
            Pais = pais ?? throw new ArgumentNullException(nameof(pais));
        }

        public string Nombre1 { get => Nombre;  }
        public DateTime Año_Nacimiento1 { get => Año_Nacimiento;  }
        public string Pais1 { get => Pais; }

        public string MostarDirector()
        {
            return "    Director: " + Nombre + "\n" + "   Fecha de nacimiento: " + Año_Nacimiento + "\n" + "   Pais de origen " + Pais;
        }
    }
}
