using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Cliente : Persona
    {
        private long Nro_Tarjeta;
        private long Saldo_Tarjeta;
        private static long Nro = 85623;

        public Cliente( long saldo_Tarjeta, string nombre, long identificacion, long telefono, string correo) 
            : base(nombre, identificacion, telefono, correo)
        {
            Nro++;
            Nro_Tarjeta = Nro;
            if (saldo_Tarjeta >= 0) Saldo_Tarjeta = saldo_Tarjeta;
            else throw new Exception("El saldo de la targeta No puede ser Negativo");
        }

        public Cliente( string nombre, long identificacion, long telefono, string correo) : base(nombre, identificacion, telefono, correo)
        {
            Nro++;
            Nro_Tarjeta = Nro;
            Saldo_Tarjeta = 0;
        }


        public long Nro_Tarjeta1 { get => Nro_Tarjeta; }
        public long Saldo_Tarjeta1 { get => Saldo_Tarjeta; }

        public bool Recargar_Tarjeta(long Cantidad_Recarga)
        {
            if (Cantidad_Recarga >= 20000 && Cantidad_Recarga <= 100000)
            {
                Saldo_Tarjeta += Cantidad_Recarga;
                return true;
            }
            return false;
        }
        public string Consultar_Saldo()
        {
            return "EL saldo Actual del Cliente " + Nombre + " Con Identificacion " +
                "" + Identificacion + " es: \n   Numero Tarjeta: " + Nro_Tarjeta + "\n" +
                "   Saldo: " + Saldo_Tarjeta;
        }

        public void Pagar_Boleta(long precio)
        {
            Saldo_Tarjeta -= precio;
        }
    }
}

