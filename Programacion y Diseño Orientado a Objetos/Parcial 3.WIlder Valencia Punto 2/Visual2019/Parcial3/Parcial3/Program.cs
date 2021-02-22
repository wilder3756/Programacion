using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cine;
using System.IO;

namespace Parcial3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion de variables que se utilizaran en todo el main
                List<Cliente> Lista_Clientes = new List<Cliente>();
                List<Espectador> Lista_Espectadores = new List<Espectador>();
                List<Director> Directores = new List<Director>();
                Pelicula pelicula;
                Cliente cliente;
                Espectador espectador;
                Director director;
                Funcion funcion = new Funcion();
                Boleta boleta;
                string linea;
                string[] Destinosplit;
                StreamReader archivo;
                List<Boleta> BoletasCompradas;
                //Creacion de Taquilllas
                Taquilla Taquilla1 = new Taquilla();
                Taquilla Taquilla2 = new Taquilla();
                

            try
            {

                //Creacion de taquilleros y asignacion
                Taquillero taq1 = new Taquillero("Juan", 834564594, 8642756, "Juan@gmail.com");
                Taquillero taq2 = new Taquillero("Felipe", 88457944, 8648956, "Felipe@gmail.com");
                Taquilla1.AsignarTaquillero(taq1);
                Taquilla2.AsignarTaquillero(taq2);


                //Creacion Salas de Cine
                Sala sala1 = new Sala(5, 10, 2, 10);
                Sala sala2 = new Sala(5, 10, 2, 10);
                Sala sala3 = new Sala(13, 10, 5, 10);
                Sala sala4 = new Sala(13, 10, 5, 10);

                //Crecion de objetos pelicula, espectadores y clientes
                    //Se suben los directores
                        archivo=new StreamReader("..\\..\\Archivos\\Directores.txt");
                        linea = archivo.ReadLine();
                        while (linea != null)
                        {
                            Destinosplit = linea.Split(',');
                            
                            director = new Director(Destinosplit[0], Convert.ToDateTime(Destinosplit[1]), Destinosplit[2]);
                            Directores.Add(director);
                            linea = archivo.ReadLine();
                        }
                            

                //Se suben peliculas desde archivo y se adicionan a la taquilla
                       archivo = new StreamReader("..\\..\\Archivos\\Peliculas.txt");
                        linea = archivo.ReadLine();
                        string[] direct;
                        List<Director> direcPelicula = new List<Director>();
                        while (linea != null)
                        {
                            
                            Destinosplit = linea.Split(',');
                            direct = Destinosplit[1].Split('-');
                            foreach(string i in direct)
                            {
                                foreach(Director j in Directores)
                                {
                                    if (j.Nombre1.Equals(i) == true)
                                    {
                                        direcPelicula.Add(j);
                                    }
                                }
                            }
                            
                            pelicula = new Pelicula(Destinosplit[0], direcPelicula, Convert.ToInt32(Destinosplit[2]), Destinosplit[3], Destinosplit[4]);
                            Taquilla.AgregarPelicula(pelicula);
                            linea = archivo.ReadLine();
                        }

                    //Se suben Usuarios
                        archivo = new StreamReader("..\\..\\Archivos\\Cliente.txt");
                        linea = archivo.ReadLine();
                        while (linea != null)
                        {
                            Destinosplit = linea.Split(',');
                            cliente = new Cliente(Convert.ToInt64(Destinosplit[0]), Destinosplit[1], Convert.ToInt64(Destinosplit[2]), Convert.ToInt64(Destinosplit[3]), Destinosplit[4]); ;
                            Lista_Clientes.Add(cliente);
                            linea = archivo.ReadLine();
                        }
                
                    //se suben espectadores
                        archivo = new StreamReader("..\\..\\Archivos\\Espectador.txt");
                        linea = archivo.ReadLine();
                        while (linea != null)
                        {
                            Destinosplit = linea.Split(',');
                            espectador = new Espectador(Destinosplit[0], Convert.ToInt64(Destinosplit[1]), Convert.ToInt64(Destinosplit[2]), Destinosplit[3]); ;
                            Lista_Espectadores.Add(espectador);
                            linea = archivo.ReadLine();
                        }

                    //se crean Funciones
                        archivo = new StreamReader("..\\..\\Archivos\\Funciones.txt");
                        linea = archivo.ReadLine();
                        while (linea != null)
                        {
                            Destinosplit = linea.Split(',');
                            foreach (Pelicula i in Taquilla.Lista_Peliculas1)
                            {
                                if (Destinosplit[0].Equals(i.Titulo1) == true)
                                {
                                    if (sala1.Nro_Sala1 == Convert.ToInt16(Destinosplit[1]))
                                    {
                                        funcion = new Funcion(i, sala1, Convert.ToDateTime(Destinosplit[2]));
                                        Taquilla.AgregarFuncion(funcion);
                                    }
                                    if (sala2.Nro_Sala1 == Convert.ToInt16(Destinosplit[1]))
                                    {
                                        funcion = new Funcion(i, sala1, Convert.ToDateTime(Destinosplit[2]));
                                        Taquilla.AgregarFuncion(funcion);
                                    }
                                    if (sala3.Nro_Sala1 == Convert.ToInt16(Destinosplit[1]))
                                    {
                                        funcion = new Funcion(i, sala1, Convert.ToDateTime(Destinosplit[2]));
                                        Taquilla.AgregarFuncion(funcion);
                                    }
                                    if (sala4.Nro_Sala1 == Convert.ToInt16(Destinosplit[1]))
                                    {
                                        funcion = new Funcion(i, sala1, Convert.ToDateTime(Destinosplit[2]));
                                        Taquilla.AgregarFuncion(funcion);
                                    }
                                }
                            }
                            linea = archivo.ReadLine();
                        }

                goto Principal;
                }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("El Error es: "+ e.Message);
                goto Principal;
            }
        Principal:
            try
            {


                //Menu Principal
                short opcion;
                Console.WriteLine("Ingrese el numero de la Accion que desea realizar: \n" +
                    "   0. Director de una pelicula de una funcion \n" +
                    "   1. Consultar Saldo \n" +
                    "   2. Recargar Tarjeta \n" +
                    "   3. Consultar Clientes \n" +
                    "   4. Colsultar Funciones Disponibles \n" +
                    "   5. Comprar Boleta \n" +
                    "   Ingrese cualquier otro numero para salir");
                opcion = Convert.ToInt16(Console.ReadLine());
                ///////////////revisar cuando no se ingresa ningun dato o no numerico

                //Manejo del menu
                while (opcion >= 0 && opcion < 6)
                {
                    if (opcion == 0)
                    {
                        string fun = "La funciones son:\n";

                        foreach (Funcion i in Taquilla.Lista_Funciones1)
                        {
                            fun += "       Numero Identificacion: " + i.Identificacion1 +
                                "\n       Pelicula de la funcion: " + i.Pelicula.Titulo1 +"\n \n";
                        }

                        Console.WriteLine(fun);

                        Console.WriteLine("Ingrese la identificacion de la funcion que desea conocer el director de la pelicula");
                        long identificacion = Convert.ToInt64(Console.ReadLine());
                        bool f = true;
                        while (f)
                        {
                            foreach(Funcion i in Taquilla.Lista_Funciones1)
                            {
                                if (i.Identificacion1 == identificacion && f)
                                {
                                    Console.WriteLine("La pelicula " + i.Pelicula.Titulo1 + " de la funcion " + i.Identificacion1);
                                    foreach(Director j in i.Pelicula.Director1)
                                    {
                                        Console.WriteLine(j.MostarDirector()+"\n");
                                        break;
                                    }
                                    f = false;
                                }
                                if(i==Taquilla.Lista_Funciones1.Last()&& f) Console.WriteLine("La funcion No existe");
                            }
                        }
                        Console.ReadKey();

                    }
                    if (opcion == 1)
                    {
                        Console.WriteLine("         Clientes");
                        foreach (Cliente i in Lista_Clientes)
                        {
                            Console.WriteLine("Cliente:" + i.Nombre1 + " Identificacion " + i.Identificacion1);
                        }

                        Console.WriteLine("\n\nIngrese su identificacion");
                        long identificacion = Convert.ToInt64(Console.ReadLine());
                        bool y = true;
                        while (y)
                        {
                            foreach (Cliente i in Lista_Clientes)
                            {
                                if (identificacion == i.Identificacion1)
                                {
                                    y = false;
                                    Console.WriteLine(i.Consultar_Saldo());
                                }
                                else if ((Lista_Clientes.Last() == i) && y) Console.WriteLine("La identificacion dada no esta asociada a un cliente");
                            }
                            if (y)
                            {
                                Console.WriteLine("Ingrese su identificacion");
                                identificacion = Convert.ToInt64(Console.ReadLine());
                            }
                        }

                        Console.ReadKey();
                    }
                    if (opcion == 2)
                    {
                        Console.WriteLine("         Clientes");
                        foreach (Cliente i in Lista_Clientes)
                        {
                            Console.WriteLine("Cliente:" + i.Nombre1 + " Identificacion " + i.Identificacion1);
                        }

                        bool y = true;
                        Console.WriteLine("\n\nIngrese su identificacion");
                        long identificacion = Convert.ToInt64(Console.ReadLine());
                        while (y)
                        {
                            foreach (Cliente i in Lista_Clientes)
                            {
                                if (identificacion == i.Identificacion1)
                                {
                                    Console.WriteLine("Ingrese el saldo que desea recargar");
                                    long saldorecarg = Convert.ToInt64(Console.ReadLine());
                                    y = false;
                                    if (i.Recargar_Tarjeta(saldorecarg)) Console.WriteLine("Recarga Exitosa\n"+i.Consultar_Saldo());
                                    else Console.WriteLine("No es posible recargar la cantidad Ingresada, ya que la recarga no esta en el rango permitido(entre $20.000 y $100.000)");
                                }
                                else if ((Lista_Clientes.Last() == i) && y) Console.WriteLine("La identificacion dada no esta asociada a un cliente");
                            }
                            if (y)
                            {
                                Console.WriteLine("Ingrese su identificacion");
                                identificacion = Convert.ToInt64(Console.ReadLine());
                            }
                        }

                        Console.ReadKey();
                    }
                    if (opcion == 3)
                    {
                        string clie = "Los Clientes Activos son:\n";
                        foreach (Cliente i in Lista_Clientes)
                        {
                            clie += "       Nombre: " + i.Nombre1 +
                                "\n       Identificacion: " + i.Identificacion1 +
                                "\n       Telefono: " + i.Telefono1 +
                                "\n       Correo: " + i.Correo1 +
                                "\n       Numero de Tarjeta: " + i.Nro_Tarjeta1 +
                                "\n       Saldo Tarjeta: " + i.Saldo_Tarjeta1 + "\n \n";
                        }
                        Console.WriteLine(clie);
                        Console.ReadKey();
                    }
                    if (opcion == 4)
                    {
                        string fun = "Las funciones disponibles \n";

                        foreach (Funcion i in Taquilla.Lista_Funciones1)
                        {
                            fun += "       Numero Identificacion: " + i.Identificacion1 +
                                "\n       Pelicula de la funcion: " + i.Pelicula.Titulo1 +
                                "\n       Duracion: " + i.Duracion1 +
                                "\n       Hora Funcion: " + i.Hora_Inicio1 +
                                "\n       Sala: " + i.Sala.Nro_Sala1 +
                                "\n       Clasificacion : " + i.Pelicula.Censura1 + "\n \n";
                        }

                        Console.WriteLine(fun);

                        Console.ReadKey();
                    }
                    if (opcion == 5)
                    {
                        string fun = "Las funciones disponibles \n";

                        foreach (Funcion i in Taquilla.Lista_Funciones1)
                        {
                            fun += "       Numero Identificacion: " + i.Identificacion1 +
                                "\n       Pelicula de la funcion: " + i.Pelicula.Titulo1 +
                                "\n       Duracion: " + i.Duracion1 +
                                "\n       Hora Funcion: " + i.Hora_Inicio1 +
                                "\n       Sala: " + i.Sala.Nro_Sala1 +
                                "\n       Clasificacion : " + i.Pelicula.Censura1 + "\n \n";
                        }

                        Console.WriteLine(fun);

                        Console.Write("Ingrese el Numero de la funcion:\n");
                        short nrofuncion = Convert.ToInt16(Console.ReadLine());

                        bool r = false;
                        while (r == false)
                        {
                            if (nrofuncion <= Taquilla.Lista_Funciones1.Count)
                            {
                                foreach (Funcion i in Taquilla.Lista_Funciones1)
                                {
                                    if (nrofuncion == i.Identificacion1)
                                    {
                                        funcion = i;
                                        r = true;
                                    }
                                }
                            }
                            else
                            {
                                Console.Write("La funcion indicada No existe \n Ingrese el Numero de la funcion:\n");
                                nrofuncion = Convert.ToInt16(Console.ReadLine());
                            }
                        }

                        Console.Write("Seleccione la localidad:\n" +
                            "   1. VIP \n" +
                            "   2. General \n");
                        short localidad = Convert.ToInt16(Console.ReadLine());
                        while (localidad < 1 || localidad > 2)
                        {

                            Console.Write("La Localidad ingresada no es valida \nSeleccione la localidad:\n" +
                            "   1. VIP \n" +
                            "   2. General \n");
                            localidad = Convert.ToInt16(Console.ReadLine());
                        }

                        Console.WriteLine("         Clientes");
                        foreach (Cliente i in Lista_Clientes)
                        {
                            Console.WriteLine("Cliente:" + i.Nombre1 + " Identificacion " + i.Identificacion1);
                        }
                        Console.WriteLine("\n         Espectadores");
                        foreach (Espectador i in Lista_Espectadores)
                        {
                            Console.WriteLine("Espectador:" + i.Nombre1 + " Identificacion " + i.Identificacion1);
                        }
                        Console.WriteLine("\n\nPor favor Ingrese su identificacion");
                        long identificacion = Convert.ToInt64(Console.ReadLine());
                        bool usu = false;

                        foreach (Cliente i in Lista_Clientes)
                        {
                            if (identificacion == i.Identificacion1)
                            {
                                Console.WriteLine("Bienvenido Cliente " + i.Nombre1 + ". Por favor ingrese el numero de boletas que desea adquirir");
                                short CantBoletas = Convert.ToInt16(Console.ReadLine());
                                while (CantBoletas < 0 || CantBoletas > 7)
                                {
                                    Console.WriteLine("No es posible comprar menos de 1 boleta ni mas de 7, Por favor ingrese el numero de boletas que desea adquirir");
                                    CantBoletas = Convert.ToInt16(Console.ReadLine());
                                }
                                Console.WriteLine(funcion.Sala.ImprimirEstado());
                                string ubicacion = "";
                                int w = 1;
                                short can = CantBoletas;
                                while (CantBoletas > 0)
                                {
                                    string ubi = "";
                                    Console.WriteLine("Ingrese la ubicacion de la " + w + " boleta de la sigiente manera fila-columna(2-7)");
                                    ubi = Console.ReadLine();
                                    ubicacion += ubi + ",";
                                    w++;
                                    CantBoletas--;
                                }
                                string tipoSilla;
                                if (localidad == 1) tipoSilla = "VIP";
                                else tipoSilla = "GENERAL";
                                BoletasCompradas = Taquilla1.Vender_Boleta(i, funcion, ubicacion, tipoSilla, can);

                                //imprimir boletas
                                string boletas = "Las boletas Compradas son: \n";
                                foreach (Boleta j in BoletasCompradas)
                                {
                                    boletas += "      " + j.Funcion1.Pelicula.Titulo1 +
                                        "\n       Numero de Boleta: " + j.Codigo1 + "\n" +
                                        "       Fecha y Hora: " + j.Fecha_Hora1 +
                                        "\n       Sala:" + j.Funcion1.Sala.Nro_Sala1 +
                                        "\n       Numero de Silla: " + j.Nro_Silla1 + " Localidad: " + j.Localidad1 +
                                        "\n       Valor Boleta: $" + j.Valor_Final1 +
                                        "\n       Vendedor: " + Taquilla1.Taquillero1.Nombre1 + "\n\n";
                                }

                                Console.WriteLine(boletas);

                            }
                        }
                        foreach (Espectador i in Lista_Espectadores)
                        {
                            if (identificacion == i.Identificacion1)
                            {

                                Console.WriteLine("Bienvenido Espectador " + i.Nombre1 + ". Por favor ingrese el numero de boletas que desea adquirir");
                                short CantBoletas = Convert.ToInt16(Console.ReadLine());
                                while (CantBoletas < 0 || CantBoletas > 7)
                                {
                                    Console.WriteLine("No es posible comprar menos de 1 boleta ni mas de 7, Por favor ingrese el numero de boletas que desea adquirir");
                                    CantBoletas = Convert.ToInt16(Console.ReadLine());
                                }
                                Console.WriteLine(funcion.Sala.ImprimirEstado());
                                string ubicacion = "";
                                int w = 1;
                                short can = CantBoletas;
                                while (CantBoletas > 0)
                                {
                                    string ubi = "";
                                    Console.WriteLine("Ingrese la ubicacion de la " + w + " boleta de la sigiente manera fila-columna(2-7)");
                                    ubi = Console.ReadLine();
                                    ubicacion += ubi + ",";
                                    w++;
                                    CantBoletas--;
                                }
                                string tipoSilla;
                                if (localidad == 1) tipoSilla = "VIP";
                                else tipoSilla = "GENERAL";
                                BoletasCompradas = Taquilla1.Vender_Boleta(funcion, ubicacion, tipoSilla, can);

                                //imprimir boletas
                                string boletas = "Las boletas Compradas son: \n";
                                foreach (Boleta j in BoletasCompradas)
                                {
                                    boletas += "      " + j.Funcion1.Pelicula.Titulo1 +
                                        "\n       Numero de Boleta: " + j.Codigo1 + "\n" +
                                        "       Fecha y Hora: " + j.Fecha_Hora1 +
                                        "\n       Sala:" + j.Funcion1.Sala.Nro_Sala1 +
                                        "\n       Numero de Silla: " + j.Nro_Silla1 + " Localidad: " + j.Localidad1 +
                                        "\n       Valor Boleta: $" + j.Valor_Final1 +
                                        "\n       Vendedor: " + Taquilla1.Taquillero1.Nombre1+"\n\n";
                                }

                                Console.WriteLine(boletas);

                            }

                        }
                        
                    }
                    Console.Clear();
                    Console.WriteLine("Ingrese el numero de la Accion que desea realizar: \n" +
                    "   0. Director de una pelical de una funcion \n" +
                    "   1. Consultar Saldo \n" +
                    "   2. Recargar Tarjeta \n" +
                    "   3. Consultar Clientes \n" +
                    "   4. Colsultar Funciones Disponibles \n" +
                    "   5. Comprar Boleta \n" +
                    "   Ingrese cualquier otro numero para salir");
                    opcion = Convert.ToInt16(Console.ReadLine());

                }

                Console.WriteLine("*******************Programa Finalizado*******************");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("El error General es: " + e.Message + "\n");
                goto Principal;

            }
        }
    }
}
