using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2.Clases
{
    class PlanTuristico
    {
        private string Ciudad;
        private DateTime FechaSalida;
        private DateTime FechaRegreso;
        private static short NMaxReserva=5;
        private long[,] Avion;
        private static int CapacidadAvion = 30;
        private double ValorPlan; // Nuevo dato valor plan
        private long[,] ReservasPagadas;


        public double ValorPlan1 { get => ValorPlan;} //Permitir Lectura del precio desdde el Principal

        public PlanTuristico()
        {
            Ciudad = "";
            ValorPlan = 0;
            FechaRegreso = new DateTime(0, 0, 0);
            FechaSalida = new DateTime(0, 0, 0);
            Avion = new long[10, 3];
            ReservasPagadas= new long[10, 3];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Avion[i, j]=0;
                    ReservasPagadas[i, j] = 0;
                }

            }


        }
        public PlanTuristico(string Ciudad, DateTime Fechasalida, DateTime FechaRegreso, double ValorPlan)
        {
            if (FechaRegreso < Fechasalida || Ciudad.Equals("") || ValorPlan<0)
            {
                throw new Exception("La fecha de regreso no puedo ser menor o igual a la fecha de salida o la Ciudad no puede ser nula o El valor del plan no debe ser menor o igual");
            }
            else
            {
                this.Ciudad = Ciudad;
                Avion = new long[10, 3];
                ReservasPagadas = new long[10, 3];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Avion[i, j] = 0;
                        ReservasPagadas[i, j] = 0;
                    }

                }
                this.ValorPlan = ValorPlan;
                this.FechaRegreso = FechaRegreso;
                this.FechaSalida = Fechasalida;
            }
                
            
        }

        public double ConsultarMontoPagar(long Identificacion,string[,] usuarios)
        {
            double Total = 0;
            for (int i = 0; i < usuarios.GetLongLength(0); i++)
            {
                //El usuario existe ne la base de datos
                if (Convert.ToInt64(usuarios[i, 1]) == Identificacion)
                {
                    for (int j = 0; j < Avion.GetLongLength(0); j++)
                    {
                        for (int k = 0; k < Avion.GetLongLength(1); k++)
                        {
                            if (Avion[j, k] == Identificacion)
                            {
                                Total += ValorPlan;
                            }
                        }

                    }

                }
            }

            return Total;
        }
        
        public string PagarReserva(long Identificacion, string[,] usuarios)
        {
            string retorno = "";
            for (int i = 0; i < usuarios.GetLongLength(0); i++)
            {
                //El usuario existe en la base de datos
                if (Convert.ToInt64(usuarios[i, 1]) == Identificacion)
                {
                    for (int j = 0; j < Avion.GetLongLength(0); j++)
                    {
                        for (int k = 0; k < Avion.GetLongLength(1); k++)
                        {
                            if (Avion[j, k] == Identificacion)
                            {
                                ReservasPagadas[j,k]=Identificacion;
                                retorno = "La reserva del Usuario " + usuarios[i, 0] + " Con identificacion " + usuarios[i, 1] + " Ha sido Exitosa";
                            }
                        }

                    }
                    if (retorno.Equals("") == true) retorno = "El Usuario No tiene Reservas en Este Plan Turistico";
                }
            }
            if (retorno.Equals("") == true) retorno = "El Usuario No existe en la Base de Datos";
            return retorno;
        }
        public string RealizarReserva(long Identificacion, string[,] usuarios, short CantidadReserva)
            {
                string retorno = "";
            
                //Console.WriteLine("If");
                for (int i = 0; i < usuarios.GetLongLength(0); i++)
                {
                    //El usuario existe ne la base de datos
                    if (Convert.ToInt64(usuarios[i, 1]) == Identificacion)
                    {
                        DateTime FechaMax = new DateTime();
                        DateTime MayorEdad = new DateTime(2001,01,01);
                        FechaMax = Convert.ToDateTime(usuarios[i, 2]);
                   
                    //Asegurar que las Reservas solo se dan a Mayores de edad
                    if (DateTime.Compare(FechaMax,MayorEdad)<0)
                        {
                            //Conseguir las sillas desesadas
                            if (CantidadReserva <= NMaxReserva)
                            {
                                if ((CantidadReserva <= CapacidadAvion))
                                {
                                    CapacidadAvion = CapacidadAvion - CantidadReserva;
                                
                                    
                                        retorno += "El usuario " + usuarios[i, 0] + " Con nuemero de identificacion " + usuarios[i, 1] + " ha reservado: \n";
                                            //reservar sillas en el avion
                                            for (int j = 0; j < Avion.GetLongLength(0); j++)
                                            {
                                                for (int k = 0; k < Avion.GetLongLength(1); k++)
                                                {
                                                       //Asegurarse que los asientos esten libre y falten sillas por reservar
                                                    if (Avion[j, k] == 0 && CantidadReserva!=0)
                                                    {
                                                        Avion[j, k] = Identificacion;
                                                        retorno += "Reservada la silla: " + (j + 1) + Convert.ToChar(67 - k) + "\n";
                                                        CantidadReserva --;
                                                    }
                                                }

                                            }
                                        
                                
                                }
                                else
                                {
                                    return "No hay Sillas disponibles para generar la reserva";

                                }
                            }
                            else return "El usuario " + usuarios[i,0] + " Con nuemero de identificacion " + usuarios[i, 1] + ", No Puede Reservar mas de " + NMaxReserva + " Sillas";
                    }
                        else retorno="No se puede Reservar siendo menor de Edad";

                    }
                    else if ((i + 1) == usuarios.GetLongLength(0) && retorno.Equals("")) return"Usuario no Registrado";
                }
            

            //else return "No es posible Reservas mas de " + NMaxReserva+ " Sillas";
             return retorno;
            }
        
        public string CancelarReserva(long Identificacion,string[,] usuarios)
        {
            string retorno="";
            //Recorrer 
            for (int i = 0; i < usuarios.GetLongLength(1); i++)
            {
                //El usuario existe en la base de datos
                if (Convert.ToInt64(usuarios[i, 1]) == Identificacion)
                {
                    //Recorrer el avion para Cancelar las sillas asociadas a la reserva del Usuario
                    for (int j = 0; j < Avion.GetLongLength(0); j++)
                    {
                        for (int k = 0; k < Avion.GetLongLength(1); k++)
                        {
                            if (Avion[j, k] == Identificacion)
                            {
                                Avion[j, k] = 0;
                                ReservasPagadas[j, k] = 0;
                                retorno = " ha sido Exitosa";
                            }
                        }

                    }
					
				}
				
                else if ((i+1)== usuarios.GetLongLength(1) && retorno.Equals(""))
                {
                    return"No ha sido posible por: Usuario no Registrado, o dicho Usuario no Posee Reservas";
                    
                }
            }
            return retorno;
        }

        public  string ConsultarAvion()
        {
            string estado = "***Las reservas para el Avion con destino a  "+ this.Ciudad+" *** \n    |C|B|A|";
            for (int i = 0; i < 10; i++)
            {
                if (i <= 8) estado += "\n " + "0" + (i + 1) + " |";
                else estado += "\n " + (i + 1) + " |";
                for (int j = 0; j < 3; j++)
                {
                    //Mostrar las sillas libres
                    if (this.Avion[i, j] == 0) estado += "O" + "|";
                    //Mostrar las sillas ocupadas
                    else if (Avion[i, j] != 0)
                    {
                        if (ReservasPagadas[i, j] != 0) estado += "P" + "|";
                        else estado += "X" + "|";
                    }
                }

            }

            return estado;
        }
    }
}
    

