using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Factura
    {
        private Cliente cliente;
        private Compra compra;
        private Credito credito;
        private long Nro_Factura;
        private DateTime Fecha_Compra;
        private double Valor_Compra;
        private double Valor_IVA;
        private double Valor_Descuento;
        private double Valor_Final;

        public Factura(Cliente cliente, Compra compra,long nrofact,DateTime fechaCompra)
        {
            double precio=0, iva=0;
            this.cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            this.compra = compra ?? throw new ArgumentNullException(nameof(compra));

            Nro_Factura = nrofact;

            Fecha_Compra = fechaCompra;
            foreach(Tenis i in compra.Lista_Tenis1)
            {
                //agregar precio
                precio+= i.Precio_Producto1;
                //agregar iva
                iva += i.Precio_Producto1 * (Tenis.IVA1 / 100);
            }
            foreach(Ropa i in Compra.Lista_Ropa1)
            {
                //agregar precio
                precio += i.Precio_Producto1;
                //agregar iva
                iva += i.Precio_Producto1 * (Tenis.IVA1 / 100);
            }
            foreach (Suministro i in Compra.Lista_Suministros1)
            {
                //agregar precio
                precio += i.Precio_Producto1;
                //agregar iva
                iva += i.Precio_Producto1 * (Tenis.IVA1 / 100);
            }
            Valor_Compra = precio;
            Valor_IVA = iva;

            

            Valor_Compra -= Valor_Descuento;
            Valor_Final = Valor_Compra + Valor_IVA;
            
        }
        public Factura(Cliente cliente, long nrofact, DateTime fechaCompra)
        {
            this.cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
            

            Nro_Factura = nrofact;

            Fecha_Compra = fechaCompra;
            

        }
        public Factura( long nrofact, DateTime fechaCompra)
        {
            Nro_Factura = nrofact;

            Fecha_Compra = fechaCompra;
        }

        public Cliente Cliente { get => cliente;  }
        public Compra Compra { get => compra; }
        public long Nro_Factura1 { get => Nro_Factura; }
        public DateTime Fecha_Compra1 { get => Fecha_Compra;  }
        public double Valor_Compra1 { get => Valor_Compra; }
        public double Valor_IVA1 { get => Valor_IVA; }
        public double Valor_Descuento1 { get => Valor_Descuento;  }
        public double Valor_Final1 { get => Valor_Final; }
        public Credito Credito { get => credito; }

        public void AgregarCredito(Credito credito)
        {
            this.credito = credito;
        }
        public void AgregarTipoPago(short pa)
        {
            if (pa == 1) Valor_Descuento = Valor_Compra * (5 / 100);
            if (pa == 1) Valor_Descuento = Valor_Compra * (3 / 100);
            else Valor_Descuento = 0;
        }
        public string Facturar()
        {
            string retorno= "************************************\n" + "\nNumero de factura: "  +Nro_Factura+"\n" +
                "Vendedor: " +compra.Vendedor.Nombre1+"\nFecha Compra: "+Fecha_Compra+"\n"+ 
                "    Producto:                  Precio:\n";
            foreach (Tenis i in compra.Lista_Tenis1)
            {
                retorno += "    " + i.Descripcion1.Substring(0, 12)+"   "+i.Precio_Producto1 + "\n    ";
            }
            foreach (Ropa i in Compra.Lista_Ropa1)
            {
                retorno += "    " + i.Descripcion1.Substring(0, 12) + "   " + i.Precio_Producto1+"\n    ";
            }
            foreach (Suministro i in Compra.Lista_Suministros1)
            {
                retorno += "    " + i.Descripcion1.Substring(0, 12) + "   " + i.Precio_Producto1+"\n    ";
            }
            retorno += "\nValor Productos: $" + Valor_Compra + "\nValor IVA: $" + Valor_IVA + "\n" +
                "Descuentos: $" + Valor_Descuento + "\nValor Final" + Valor_Final + "\n***********************************";

            return retorno;
        }
    }
}
