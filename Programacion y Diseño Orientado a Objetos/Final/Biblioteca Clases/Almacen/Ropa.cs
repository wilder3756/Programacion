using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Ropa:Mercancia
    {
        private string Talla;
        private string Color;

        public Ropa(string talla, string color, string codigo_Provedor, string codigo_Producto, string descripcion, int cantidad_Disponible, double precio_Provedor, double precio_Producto, string marca, string categoria_Deporte, string material) : base(codigo_Provedor, codigo_Producto, descripcion, cantidad_Disponible, precio_Provedor, precio_Producto, marca, categoria_Deporte, material)
        {
            Talla = talla ?? throw new ArgumentNullException(nameof(talla));
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string Talla1 { get => Talla; set => Talla = value; }
        public string Color1 { get => Color; set => Color = value; }
    }
}
