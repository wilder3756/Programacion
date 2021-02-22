using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Cliente:Persona
    {
        public Cliente(string nombre, long identificacion, long telefono, string correo, DateTime fecha_Nacimiento) : base( nombre, identificacion, telefono, correo, fecha_Nacimiento)
        {

        }
    }
}
