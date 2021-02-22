using Parcial2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Se crea la Matriz con los Usuarios //las idenficaciones son cortas para que sea nemotecnico
                string[,] Usuarios = new string[7, 5] { { "Juan Hernandez", "1234", "12/02/1945", "31293478", "Juan@gmail.com" },
                                                        { "Jorge Lopez", "1235", "12/02/1971", "31293478", "Juan@gmail.com" },
                                                        { "Maria Gallego", "1236", "12/02/1980", "31293478", "Juan@gmail.com" },
                                                        { "Patricia Hecheverri", "1237", "12/02/2005", "31293478", "Juan@gmail.com" },
                                                        { "Andres Hernandez", "1238", "12/02/2000", "31293478", "Juan@gmail.com" },
                                                        { "Maria Serna", "1239", "12/02/2000", "31293478", "Juan@gmail.com" },
                                                        { "Pedro Rendon", "1230", "12/02/2000", "31293478", "Juan@gmail.com" }}; 


                //01.Crear por lo menos 3 planes turisticos
                DateTime FechaSalida = new DateTime(2019, 12, 23);
                DateTime Fecharegreso = new DateTime(2019, 12, 29);
                PlanTuristico Cali = new PlanTuristico("Cali", FechaSalida, Fecharegreso,1200000);
                Fecharegreso = new DateTime(2019, 12, 2);
                FechaSalida = new DateTime(2019, 11, 24);
                PlanTuristico Cartagena = new PlanTuristico("Cartagena", FechaSalida, Fecharegreso,1000000);
                Fecharegreso = new DateTime(2019, 12, 1);
                FechaSalida = new DateTime(2019, 11, 28);
                PlanTuristico VillaVicencio = new PlanTuristico("Villavicencio", FechaSalida,Fecharegreso,1100000);

                // 02.Inicializar el avion para todos los planes con las sillas O
                //Esto ya se hace en el constructor

                // 03.Juan Realiza una Reserva de 4 cupos para un plan, juan nacio en 1945
                    Console.WriteLine("********************************************Punto 3 Del Funcionamiento********************************************");
                    Console.WriteLine(Cali.RealizarReserva(1234, Usuarios, 4));
                    Console.ReadKey(); 
                    Console.WriteLine("\n \n");
                /////////Realizar Pruebas Segundo Punto
                    Console.WriteLine("********************************************Comienzan Pruebas Punto 2 Del Parcial********************************************");

                    Console.WriteLine("********************************************Prueba Acceder al Precio de los planes********************************************");
                    Console.WriteLine("\n El Valor Del plan a Cali es: " + Cali.ValorPlan1+ "\n El Valor Del plan a Cartagena es: " + Cartagena.ValorPlan1+ "\n El Valor Del plan VillaVicencio es: " + VillaVicencio.ValorPlan1);
                    Console.ReadKey();
                    Console.WriteLine("\n \n");

                Console.WriteLine("********************************************Prueba Metodo Consultar Monto a Pagar********************************************");
                    Console.WriteLine("El Monto a Pagar del Usuario Con identificacion 1234 es: "+ Cali.ConsultarMontoPagar(1234, Usuarios));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                
                    Console.WriteLine("********************************************Prueba Metodo Pagar Reserva********************************************");
                    Console.WriteLine( Cali.PagarReserva(1234, Usuarios));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");

                    Console.WriteLine("********************************************Prueba Metodo Nuevo Estado Del Avion********************************************");
                    Console.WriteLine(Cali.ConsultarAvion());
                    Console.ReadKey();
                    Console.WriteLine("\n \n");

                    Console.WriteLine("********************************************Terminan Pruebas Punto 2 del Parcial******************************************** \n \n");
                    Console.WriteLine("********************************************Continuan Pruebas Punto 1 del parcial******************************************** \n");

                // 04.Jorge Realiza Una reserva de 2 cupos,para el mismo plan de juan.Jorge Nacio en 1971
                Console.WriteLine("********************************************Punto 4 Del Funcionamiento********************************************");
                    Console.WriteLine(Cali.RealizarReserva(1235, Usuarios, 2));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 05.Maria, Nacio en 1980 y Realiza una reserva para 6 cupos en otro plan, pero el sistema le arroja error
                    Console.WriteLine("********************************************Punto 5 Del Funcionamiento********************************************");
                    Console.WriteLine(Cartagena.RealizarReserva(1236, Usuarios, 6));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 06.Maria vuelve a realizar una reserva en el mismo plan, pero esta vez para 5 cupos
                    Console.WriteLine("********************************************Punto 6 Del Funcionamiento********************************************");
                    Console.WriteLine(Cartagena.RealizarReserva(1236, Usuarios, 5));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 07.Patricia,Nacio en 2005 y hace una reserva para un plan distinto al de Juan y Maria,el sistema debe devolver error por la fecha de nacimiento
                    Console.WriteLine("********************************************Punto 7 Del Funcionamiento********************************************");
                    Console.WriteLine( VillaVicencio.RealizarReserva(1237, Usuarios, 1));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 08.Un agente Imprime el estado del avion de los tres planes
                    Console.WriteLine("********************************************Punto 8 Del Funcionamiento********************************************");
                    Console.WriteLine("El estado del Avion es: " + Cali.ConsultarAvion() + "\n");
                    Console.WriteLine("El estado del Avion es:\n" + Cartagena.ConsultarAvion() + "\n");
                    Console.WriteLine("El estado del Avion es:\n" + VillaVicencio.ConsultarAvion() + "\n");
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 09.Elimina la Reserva hecha en el punto 3
                    Console.WriteLine("********************************************Punto 9 Del Funcionamiento********************************************");
					Console.Write("La cancelacion de la reserva del usuario 1234 " + Cali.CancelarReserva(1234, Usuarios));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 10.Se vuelve a imprimir el Avion para ver como quedo la liberacion anterior
                    Console.WriteLine("********************************************Punto 10 Del Funcionamiento********************************************");
                    Console.WriteLine("El estado del Avion es:\n" + Cali.ConsultarAvion());
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 11.Andres,hace una reserva de 4 cupos en el plan de Juan, y debe quedar el las posiciones delanteras del avion
                    Console.WriteLine("********************************************Punto 11 Del Funcionamiento********************************************");
                    Console.WriteLine(" \n" + Cali.RealizarReserva(1238, Usuarios, 4));
                    Console.ReadKey();
                    Console.WriteLine("\n \n");
                // 12.Se imprime el estado del avion del plan de jorge y andres
                    Console.WriteLine("********************************************Punto 12 Del Funcionamiento********************************************");
                    Console.WriteLine("El estado del Avion es:\n" + Cali.ConsultarAvion() + "\n");
                    Console.ReadKey();
                    Console.WriteLine("\n \n");

                Console.ReadKey();

            }

            catch (Exception Error)
            {
                Console.WriteLine("Ocurrio un error: " + Error.Message	);
                Console.ReadKey();

            }
			finally
			{

			}

        }
        
    }
    

}
