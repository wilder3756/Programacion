using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Compra
    {
        private List<Ropa> Lista_Ropa;
        private List<Tenis> Lista_Tenis;
        private List<Suministro> Lista_Suministros;
        private Vendedor vendedor;
        
        public Compra( Vendedor vendedor)
        {
            this.vendedor = vendedor;
            Lista_Ropa = new List<Ropa>();
            Lista_Suministros = new List<Suministro>();
            Lista_Tenis = new List<Tenis>();
        }
        public List<Ropa> Lista_Ropa1 { get => Lista_Ropa;  }
        public List<Suministro> Lista_Suministros1 { get => Lista_Suministros;  }
        public Vendedor Vendedor { get => vendedor; }
        internal List<Tenis> Lista_Tenis1 { get => Lista_Tenis; }

        public void Agregar_Ropa(Ropa ropa)
        {
            Lista_Ropa.Add(ropa);
        }
        public void Agregar_Suministros(Suministro suministro)
        {
            Lista_Suministros.Add(suministro);
        }
        public void Agregar_Tenis(Tenis tenis)
        {
            Lista_Tenis.Add(tenis);
        }
    }
}
