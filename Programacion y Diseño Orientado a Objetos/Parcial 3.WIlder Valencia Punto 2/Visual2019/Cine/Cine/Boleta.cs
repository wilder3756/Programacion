using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Boleta
    {
        private string Nro_Silla;
        private double Valor_Descuento;
        private double Valor_Final;
        private Funcion Funcion;
        private DateTime Fecha_Hora;
        private long Codigo;
        private static long Cod = 1200;
        private string Localidad;
        private static int Valor_General = 11000;
        private static int Valor_VIP = 18000;

        public Boleta(Funcion funcion, string tipo_Silla, short Fila, short Columna)
        {

            Funcion = funcion ?? throw new ArgumentNullException(nameof(funcion));
            if (Fila >= 0 && Columna >= 0 && Funcion.Sala.Asignar_Puesto(Fila, Columna,tipo_Silla))
            {
                if (tipo_Silla.ToUpper().Equals("VIP") == true) Localidad = "VIP";
                else if (tipo_Silla.ToUpper().Equals("GENERAL") == true) Localidad = "GENERAL";
                else throw new Exception("Solo son validas las localidades Genral y VIP");
                Cod++;
                Codigo = Cod;
                Nro_Silla = Fila + "-" + Columna;

                Valor_Descuento = 0;
                if (Localidad.Equals("VIP")) Valor_Final = Valor_VIP;
                else Valor_Final = Valor_General;

                Fecha_Hora = funcion.Hora_Inicio1;
                ///comprobaciones en taquilla

            }
            else throw new Exception("La silla no existe o Esta Ocupada");

        }
        public Boleta(Cliente Cliente, Funcion funcion, string tipo_Silla, short Fila, short Columna)
        {

            Funcion = funcion ?? throw new ArgumentNullException(nameof(funcion));
            if (Cliente.Saldo_Tarjeta1 > 15300)
            {
                if (Fila >= 0 && Columna >= 0 && Funcion.Sala.Asignar_Puesto(Fila, Columna,tipo_Silla))
                {
                    //eVALUAR QUE LOCALIDAD LLEGUE COMO SHORT Y NO STRING
                    if (tipo_Silla.ToUpper().Equals("VIP") == true) Localidad = "VIP";
                    else if (tipo_Silla.ToUpper().Equals("GENERAL") == true) Localidad = "GENERAL";
                    else throw new Exception("Solo son validas las localidades Genral y VIP");
                    Cod++;
                    Codigo = Cod;
                    Nro_Silla = Fila + "-" + Columna;

                    Valor_Descuento = 0;
                    if (Localidad.Equals("VIP")) Valor_Final = Valor_VIP * 0.85;
                    else Valor_Final = Valor_General * 0.85;

                    Cliente.Pagar_Boleta(Convert.ToInt64(Valor_Final));
                    Fecha_Hora = funcion.Hora_Inicio1;
                    ///comprobaciones en taquilla

                }
                else throw new Exception("LA silla no existe o Esta Ocupada");
            }
            else throw new Exception("No dispone de Saldo para efectuar la compra");
            //EVALUAr la posibilidad de permitir recaRGAR

        }
        public string Nro_Silla1 { get => Nro_Silla; }
        public double Valor_Descuento1 { get => Valor_Descuento; }
        public double Valor_Final1 { get => Valor_Final; }
        public Funcion Funcion1 { get => Funcion; }
        public DateTime Fecha_Hora1 { get => Fecha_Hora; }
        public long Codigo1 { get => Codigo; }
        public string Localidad1 { get => Localidad; }
    }
}

