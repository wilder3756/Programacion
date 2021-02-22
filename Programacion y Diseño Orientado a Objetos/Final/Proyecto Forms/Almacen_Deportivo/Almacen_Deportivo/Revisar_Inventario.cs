using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Almacen;

namespace Almacen_Deportivo
{
    public partial class Revisar_Inventario : Form
    {
        private static List<Ropa> Lista_Ropa=new List<Ropa>();
        private static List<Tenis> Lista_Tenis=new List<Tenis>();
        private static List<Suministro> Lista_Suministros=new List<Suministro>();
        private DataTable tabla=new DataTable();
        public Revisar_Inventario()
        {
            InitializeComponent();
            Lista_Ropa.Clear();
            Lista_Suministros.Clear();
            Lista_Tenis.Clear();
            tabla.Clear();
            T_Inventario.DataSource = tabla;
            tabla.Columns.Add("Codigo Provedor");
            tabla.Columns.Add("Codigo Producto");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Cantidad Disponible");
            tabla.Columns.Add("Precio Provedor");
            tabla.Columns.Add("Precio Venta");
            SubirRopa();
            SubirSuministro();
            SubirTenis();
            T_Inventario.DataSource = tabla;
        }

        public void SubirRopa()
        {
            try
            {
                string linea;
                string[] Destinosplit;
                StreamReader archivo;


                archivo = new StreamReader("Ropa.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    Destinosplit = linea.Split('#');
                    Ropa R1 = new Ropa(Destinosplit[0], Destinosplit[1], Destinosplit[2], Destinosplit[3],
                        Destinosplit[4], Convert.ToInt32(Destinosplit[6]), Convert.ToDouble(Destinosplit[7]),
                        Convert.ToDouble(Destinosplit[8]), Destinosplit[9], Destinosplit[5], Destinosplit[10]);

                    Lista_Ropa.Add(R1);
                    linea = archivo.ReadLine();
                }
                foreach (Ropa i in Lista_Ropa)
                {
                    DataRow Fila = tabla.NewRow();
                    Fila[0] = i.Codigo_Provedor1;
                    Fila[1] = i.Codigo_Producto1;
                    Fila[2] = i.Descripcion1;
                    Fila[3] = i.Marca1;
                    Fila[4] = i.Cantidad_Disponible1;
                    Fila[5] = "$ " + i.Precio_Provedor1;
                    Fila[6] = "$ " + i.Precio_Producto1;
                    tabla.Rows.Add(Fila);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(null, e.Message, "Se ha producido error al subir el archivo");
            }
            catch (Exception e2)
            {
                MessageBox.Show(null, e2.Message, "Error General");
            }
            
            
        }
        public void SubirTenis()
        {
            try
            {
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Tenis.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    Destinosplit = linea.Split('#');

                    Tenis T1 = new Tenis(Destinosplit[0], Destinosplit[1], Destinosplit[2], Destinosplit[3],
                        Destinosplit[4], Convert.ToInt32(Destinosplit[6]), Convert.ToDouble(Destinosplit[7]),
                        Convert.ToDouble(Destinosplit[8]), Destinosplit[9], Destinosplit[5], Destinosplit[10]);
                    Lista_Tenis.Add(T1);
                    linea = archivo.ReadLine();

                }
                foreach (Tenis i in Lista_Tenis)
                {
                    DataRow fila = tabla.NewRow();
                    fila["Codigo Provedor"] = i.Codigo_Provedor1;
                    fila["Codigo Producto"] = i.Codigo_Producto1;
                    fila["Descripcion"] = i.Descripcion1;
                    fila["Marca"] = i.Marca1; ;
                    fila["Cantidad Disponible"] = i.Cantidad_Disponible1;
                    fila["Precio Provedor"] = "$ " + i.Precio_Provedor1;
                    fila["Precio Venta"] = "$ " + i.Precio_Producto1;
                    tabla.Rows.Add(fila);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(null, e.Message, "Se ha producido error al subir el archivo");
            }
            catch (Exception e2)
            {
                MessageBox.Show(null, e2.Message, "Error General");
            }
            
        }
        public void SubirSuministro()
        {
            try
            {
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Suministro.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {

                    Destinosplit = linea.Split('#');
                    //MessageBox.Show("El tamaño es: " + Destinosplit.Length);
                    Suministro S1 = new Suministro(Destinosplit[0], Destinosplit[1],
                        Destinosplit[2], Convert.ToInt32(Destinosplit[4]), Convert.ToDouble(Destinosplit[5]),
                        Convert.ToDouble(Destinosplit[6]), Destinosplit[7], Destinosplit[3], Destinosplit[8]);
                    Lista_Suministros.Add(S1);
                    linea = archivo.ReadLine();

                }
                foreach (Suministro i in Lista_Suministros)
                {
                    DataRow fila = tabla.NewRow();
                    fila["Codigo Provedor"] = i.Codigo_Provedor1;
                    fila["Codigo Producto"] = i.Codigo_Producto1;
                    fila["Descripcion"] = i.Descripcion1;
                    fila["Marca"] = i.Marca1; ;
                    fila["Cantidad Disponible"] = i.Cantidad_Disponible1;
                    fila["Precio Provedor"] = "$ " + i.Precio_Provedor1;
                    fila["Precio Venta"] = "$ " + i.Precio_Producto1;
                    tabla.Rows.Add(fila);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(null, e.Message, "Se ha producido error al subir el archivo");
            }
            catch (Exception e2)
            {
                MessageBox.Show(null, e2.Message, "Error General");
            }
            
        }



        private void B_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
