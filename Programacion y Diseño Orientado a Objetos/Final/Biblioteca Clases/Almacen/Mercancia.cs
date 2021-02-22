using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public abstract class Mercancia
    {
        protected string Codigo_Provedor;
        protected string Codigo_Producto;
        protected string Descripcion;
        protected int Cantidad_Disponible;
        protected double Precio_Provedor;
        protected double Precio_Producto;
        protected string Marca;
        protected string Categoria_Deporte;
        protected string Material;
        protected static short IVA = 19;

        public Mercancia(string codigo_Provedor, string codigo_Producto, string descripcion, int cantidad_Disponible, double precio_Provedor, double precio_Producto, string marca, string categoria_Deporte, string material)
        {
            Codigo_Provedor = codigo_Provedor ?? throw new ArgumentNullException(nameof(codigo_Provedor));
            Codigo_Producto = codigo_Producto ?? throw new ArgumentNullException(nameof(codigo_Producto));
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            if (cantidad_Disponible > 0) Cantidad_Disponible = cantidad_Disponible;
            else throw new Exception("La cantidad disponible debe ser mayor a cero");
            if(precio_Provedor>0)Precio_Provedor = precio_Provedor;
            else throw new Exception("El precio del provedor ha de ser mayor a 0");
            if(precio_Producto>0) Precio_Producto = precio_Producto;
            else throw new Exception("El precio interno ha de ser mayor a 0");
            Marca = marca ?? throw new ArgumentNullException(nameof(marca));
            Categoria_Deporte = categoria_Deporte ?? throw new ArgumentNullException(nameof(categoria_Deporte));
            Material = material ?? throw new ArgumentNullException(nameof(material));
        }

        public string Codigo_Provedor1 { get => Codigo_Provedor;}
        public string Codigo_Producto1 { get => Codigo_Producto;  }
        public string Descripcion1 { get => Descripcion; }
        public int Cantidad_Disponible1 { get => Cantidad_Disponible;  }
        public double Precio_Provedor1 { get => Precio_Provedor;  }
        public double Precio_Producto1 { get => Precio_Producto; }
        public string Marca1 { get => Marca; set => Marca = value; }
        public string Categoria_Deporte1 { get => Categoria_Deporte; }
        public string Material1 { get => Material;  }
        public static short IVA1 { get => IVA;  }
        

        public void AgregarProducto(int cantidad)
        {
            if (cantidad > 0) Cantidad_Disponible += cantidad;
        }
    }
}
