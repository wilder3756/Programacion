using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Sala
    {
        private char[,] General;
        private char[,] VIP;
        private short Nro_Sala;
        private static short Nro = 0;

        public Sala(short NumeroFilasGeneral, short NumeroColumnasGeneral, short NumeroFilasVIP, short NumeroColumnasVIP)
        {
            if (NumeroColumnasGeneral > 0 && NumeroColumnasVIP > 0 && NumeroFilasGeneral > 0 && NumeroFilasVIP > 0)
            {
                General = new char[NumeroFilasGeneral, NumeroColumnasGeneral];
                VIP = new char[NumeroFilasVIP, NumeroColumnasVIP];

                Nro++;
                Nro_Sala = Nro;
            }
            else throw new Exception("No puede crear salas con 0 o menos Filas y/o Columnas");
            for (int i = 0; i < NumeroFilasGeneral; i++)
            {
                for (int j = 0; j < NumeroColumnasVIP; j++)
                {
                    General[i, j] = 'O';
                }
            }
            for (int i = 0; i < NumeroFilasVIP; i++)
            {
                for (int j = 0; j < NumeroColumnasVIP; j++)
                {
                    VIP[i, j] = 'O';
                }
            }

        }


        public char[,] General1 { get => General; }
        public char[,] VIP1 { get => VIP; }
        public short Nro_Sala1 { get => Nro_Sala; }


        public string ImprimirEstado()
        {
            string retorno = "EL estado de la sala Es (X=reservado y O=Disponible) : \n\n                   General \n     ";
            for(int i=0; i < General.GetLength(1); i++) { retorno += i + "|"; }
            retorno += "\n \n";
            for (int i = 0; i < General.GetLength(0); i++)
            {
                retorno += i + "    ";
                for (int j = 0; j < General.GetLength(1); j++)
                {
                    retorno += General[i, j] + "|";
                }
                retorno += "\n";
            }

            retorno += "\n                  VIP \n     ";
            for (int i = 0; i < VIP.GetLength(1); i++) { retorno += i + "|"; }
            retorno += "\n \n";
            for (int i = 0; i < VIP.GetLength(0); i++)
            {
                retorno += i + "    ";
                for (int j = 0; j < VIP.GetLength(1); j++)
                {
                    retorno += VIP[i, j] + "|";
                }
                retorno += "\n";
            }
            return retorno;
        }
        public bool Asignar_Puesto(short Fila, short Columna,string tipoBoleta)
        {
            if (tipoBoleta.Equals("GENERAL") == true)
            {
                for (int i = 0; i < General.GetLength(0); i++)
                {
                    for (int j = 0; j < General.GetLength(1); j++)
                    {
                        if ((Fila < General.GetLength(0) && Columna < General.GetLength(1)) && General[Fila, Columna].Equals('O') == true)
                        {
                            General[Fila, Columna] = 'X';
                            return true;
                        }
                    }

                }
            }
            if (tipoBoleta.Equals("VIP") == true)
            {
                for (int i = 0; i < VIP.GetLength(0); i++)
                {
                    for (int j = 0; j < VIP.GetLength(1); j++)
                    {
                        if ((Fila < VIP.GetLength(0) && Columna < VIP.GetLength(1)) && VIP[Fila, Columna].Equals('O') == true)
                        {
                            VIP[Fila, Columna] = 'X';
                            return true;
                        }
                    }
                }
            }
            
            

            return false;
        }
    }
}
