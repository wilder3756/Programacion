using System;
using System.Collections.Generic;
using System.Text;

namespace Cine
{
    public class Taquilla
    {
        private short Nro_Identificacion;
        private static short id = 0;
        private Taquillero Taquillero;
        private List<Boleta> Lista_Boletas;
        private static List<Funcion> Lista_Funciones=new List<Funcion>();
        private static List<Pelicula> Lista_Peliculas=new List<Pelicula>();

        public Taquilla(Taquillero taquillero)
        {
            id++;
            Nro_Identificacion = id;

            Taquillero = taquillero;
            Lista_Boletas = new List<Boleta>();

        }
        public Taquilla()
        {
            id++;
            Nro_Identificacion = id;

            Lista_Boletas = new List<Boleta>();

        }

        public short Nro_Identificacion1 { get => Nro_Identificacion; }
        public Taquillero Taquillero1 { get => Taquillero; }
        public List<Boleta> Lista_Boletas1 { get => Lista_Boletas; }
        public static List<Funcion> Lista_Funciones1 { get => Lista_Funciones; }
        public static List<Pelicula> Lista_Peliculas1 { get => Lista_Peliculas; }

        public List<Boleta> Vender_Boleta(Funcion funcion, string Posiciones, string Tipo_silla, short Nro_Boletas)
        {
            List<Boleta> Boletas = new List<Boleta>();
            string[] posi = Posiciones.Split(',');
            Boleta boleta;

            //if(DateTime.Now< funcion.Hora_Inicio1 +15)
            //verificar la Hora de la funcion 15 min
            if (DateTime.Now <= (funcion.Hora_Inicio1.AddMinutes(15)))
            {
                if ((Nro_Boletas + 1) == posi.Length)
                {
                    for (int i = 0; i < Nro_Boletas; i++)
                    {
                        string[] ubi = posi[i].Split('-');

                        boleta = new Boleta(funcion, Tipo_silla, Convert.ToInt16(ubi[0]), Convert.ToInt16(ubi[1]));
                        Lista_Boletas.Add(boleta);
                        Boletas.Add(boleta);

                    }

                }
                else throw new Exception("No ha ingresado igual nuemro de psosiciones y sillas");
            }
            else throw new Exception("No posible ingresar a una funcion que lleva mas de 15 minutos de haber empezado");
            

            return Boletas;
        }
        public List<Boleta> Vender_Boleta(Cliente cliente, Funcion funcion, string Posiciones, string Tipo_silla, int Nro_Boletas)
        {
            List<Boleta> Boletas = new List<Boleta>();
            string[] posi = Posiciones.Split(',');
            Boleta boleta;
            if (DateTime.Now <= (funcion.Hora_Inicio1.AddMinutes(15)))
            {
                if ((Nro_Boletas + 1) == posi.Length)
                {
                    Console.WriteLine(cliente.Saldo_Tarjeta1);
                    if ((cliente.Saldo_Tarjeta1 > Convert.ToInt64(Nro_Boletas * 18000 * 0.85) && Tipo_silla.ToUpper().Equals("VIP"))
                        || cliente.Saldo_Tarjeta1 > Convert.ToInt64(Nro_Boletas * 11000 * 0.85) && Tipo_silla.ToUpper().Equals("GENERAL"))
                    {
                        for (int i = 0; i < Nro_Boletas; i++)
                        {
                            string[] ubi = posi[i].Split('-');

                            boleta = new Boleta(cliente, funcion, Tipo_silla, Convert.ToInt16(ubi[0]), Convert.ToInt16(ubi[1]));
                            Lista_Boletas.Add(boleta);
                            Boletas.Add(boleta);

                        }
                    }
                    else throw new Exception("No posee Saldo suficiente ó la localidad no es correcta");


                }
                else throw new Exception("No ha ingresado igual nuemro de psosiciones y sillas");
            }
            else throw new Exception("No posible ingresar a una funcion que lleva mas de 15 minutos de haber empezado");
            if ((Nro_Boletas+1) == posi.Length)
            {
                Console.WriteLine(cliente.Saldo_Tarjeta1);
                if ((cliente.Saldo_Tarjeta1 > Convert.ToInt64(Nro_Boletas * 18000 * 0.85) && Tipo_silla.ToUpper().Equals("VIP"))
                    || cliente.Saldo_Tarjeta1 > Convert.ToInt64(Nro_Boletas * 11000 * 0.85) && Tipo_silla.ToUpper().Equals("GENERAL"))
                {
                    for (int i = 0; i < Nro_Boletas; i++)
                    {
                        string[] ubi = posi[i].Split('-');

                        boleta = new Boleta(cliente,funcion, Tipo_silla, Convert.ToInt16(ubi[0]), Convert.ToInt16(ubi[1]));
                        Lista_Boletas.Add(boleta);
                        Boletas.Add(boleta);

                    }
                }
                else throw new Exception("No posee Saldo suficiente ó la localidad no es correcta");


            }
            else throw new Exception("No ha ingresado igual nuemro de psosiciones y sillas");

            return Boletas;
        }

        public static void AgregarFuncion(Funcion funcion)
        {
            Lista_Funciones.Add(funcion);
        }

        public static void AgregarPelicula(Pelicula pelicula)
        {
            Lista_Peliculas.Add(pelicula);
        }

        public void AsignarTaquillero(Taquillero taquillero)
        {
            Taquillero = taquillero;
        }
        public string Consultar_Saldo(Cliente cliente)
        {
            return "EL saldo Actual del Cliente: " + cliente.Nombre1 + " Con Identificacion: " +
                "" + cliente.Identificacion1 + "es: \n     Numero Tarjeta: " + cliente.Nro_Tarjeta1 + "\n" +
                "   Saldo: " + cliente.Saldo_Tarjeta1;
            
        }
        
        public bool Recargar_Saldo(long Cantidad_Recarga, Cliente cliente)
        {
            if (Cantidad_Recarga >= 20000 && Cantidad_Recarga <= 100000)
            {
                cliente.Recargar_Tarjeta(Cantidad_Recarga);
                return true;
            }
            return false;
        }
    }
}

