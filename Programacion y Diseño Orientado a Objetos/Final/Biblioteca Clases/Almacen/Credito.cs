using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen
{
    public class Credito
    {
        private long Nro_Credito;
        private short Nro_Cuotas;
        private double Valor_cuota;
        private static short Recargo=12;
        private short Numero_Cuotas_Pagadas;

        

        

        public Credito(long nro_Credito, short nro_Cuotas, double valor_cuota,  short numero_Cuotas_Pagadas)
        {
            Nro_Credito = nro_Credito;
            if (Nro_Cuotas == 3 || Nro_Cuotas == 6 || Nro_Cuotas == 12) Nro_Cuotas = nro_Cuotas;
            else throw new Exception("La cuotas solo se pueden diferir a a 3,6,12 meses.");
            if (Valor_cuota > 0) Valor_cuota = valor_cuota;
            else throw new Exception("El precio de la couta ha de ser mayor a 0");
            
            Numero_Cuotas_Pagadas = numero_Cuotas_Pagadas;
        }

        public long Nro_Credito1 { get => Nro_Credito; }
        public short Nro_Cuotas1 { get => Nro_Cuotas; }
        public double Valor_cuota1 { get => Valor_cuota; }
        public short Recargo1 { get => Recargo; }
        public short Numero_Cuotas_Pagadas1 { get => Numero_Cuotas_Pagadas; }
    }
}
