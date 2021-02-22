using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public abstract class Persona
    {
        protected string Nombre;
        protected long Identificacion;
        protected long Telefono;
        protected string Correo;
        protected DateTime Fecha_Nacimiento;

        public Persona(string nombre, long identificacion, long telefono, string correo, DateTime fecha_Nacimiento)
        {
            
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            if (identificacion > 10000) Identificacion = identificacion;
            else throw new Exception("Una identificacion Tiene Minimo 5 Digitos");
            if (telefono >999999 && telefono<10000000) Telefono = telefono;
            else if(telefono > 999999999 && telefono < 10000000000) Telefono = telefono;
            else throw new Exception("Un telefono tiene 7 Digitos y un numero celular 10 Digitos");
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            if(fecha_Nacimiento<DateTime.Now.AddYears(-18))Fecha_Nacimiento = fecha_Nacimiento;
            else throw new Exception("Un cliente no Puede ser Menor de Edad");
        }
        public Persona(string nombre, long identificacion)
        {

            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            if (identificacion > 10000) Identificacion = identificacion;
            else throw new Exception("Una identificacion Tiene Minimo 5 Digitos");
        
        }

        public string Nombre1 { get => Nombre; }
        public long Identificacion1 { get => Identificacion;  }
        public long Telefono1 { get => Telefono;  }
        public string Correo1 { get => Correo;  }
        public DateTime Fecha_Nacimiento1 { get => Fecha_Nacimiento; }
    }
}
