using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Vendedor:Persona
    {
        private string usuario;
        private string clave;

        public Vendedor(string usuario, string clave,string nombre, long identificacion, long telefono, string correo, DateTime fecha_Nacimiento) : base(nombre, identificacion, telefono, correo, fecha_Nacimiento)
        {
            this.usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            this.clave = clave ?? throw new ArgumentNullException(nameof(clave));
        }
        public Vendedor(string usuario, string clave, string nombre, long identificacion): base(nombre, identificacion)
        {
            this.usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            this.clave = clave ?? throw new ArgumentNullException(nameof(clave));
        }


        public string Usuario { get => usuario; }
        public string Clave { get => clave; }
    }
}
