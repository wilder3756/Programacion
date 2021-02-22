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
    public partial class Generar_Inventario : Form
    {
        private static List<Ropa> Lista_Ropa = new List<Ropa>();
        private static List<Tenis> Lista_Tenis = new List<Tenis>();
        private static List<Suministro> Lista_Suministros = new List<Suministro>();
        private DataTable tabla = new DataTable();
        public Generar_Inventario()
        {
            InitializeComponent();
            Lista_Ropa.Clear();
            Lista_Suministros.Clear();
            Lista_Tenis.Clear();
            tabla.Clear();
            T_GInventario.DataSource = tabla;
            tabla.Columns.Add("Codigo Interno");
            tabla.Columns.Add("Codigo Provedor");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Marca");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Precio Total");
            SubirRopa();
            SubirSuministro();
            SubirTenis();
            T_GInventario.DataSource = tabla;
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
                archivo.Close();
                foreach (Ropa i in Lista_Ropa)
                {
                    CB_Producto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
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
                archivo.Close();
                foreach (Tenis i in Lista_Tenis)
                {
                    CB_Producto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
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
                    Suministro S1 = new Suministro(Destinosplit[0], Destinosplit[1],
                        Destinosplit[2], Convert.ToInt32(Destinosplit[4]), Convert.ToDouble(Destinosplit[5]),
                        Convert.ToDouble(Destinosplit[6]), Destinosplit[7], Destinosplit[3], Destinosplit[8]);
                    Lista_Suministros.Add(S1);
                    linea = archivo.ReadLine();

                }
                archivo.Close();
                foreach (Suministro i in Lista_Suministros)
                {
                    CB_Producto.Items.Add(i.Codigo_Producto1 + "|    " + i.Descripcion1);
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

        private void B_GPedido_Click(object sender, EventArgs e)
        {
            try
            {
                
                for(int i=0; i < T_GInventario.Rows.Count-1; i++)
                {
                    
                    foreach (Ropa j in Lista_Ropa)
                    {
                        if (j.Codigo_Producto1.Equals(T_GInventario.Rows[i].Cells[0].Value.ToString()) == true)
                        {
                            j.AgregarProducto(Convert.ToInt32(T_GInventario.Rows[i].Cells[4].Value));
                        }
                    }
                    foreach (Tenis j in Lista_Tenis)
                    {
                        if (j.Codigo_Producto1.Equals(T_GInventario.Rows[i].Cells[0].Value.ToString()) == true)
                        {
                            j.AgregarProducto(Convert.ToInt32(T_GInventario.Rows[i].Cells[4].Value));
                        }

                    }
                    foreach (Suministro j in Lista_Suministros)
                    {
                        if (j.Codigo_Producto1.Equals(T_GInventario.Rows[i].Cells[0].Value.ToString()) == true)
                        {
                            j.AgregarProducto(Convert.ToInt32(T_GInventario.Rows[i].Cells[4].Value));
                        }
                    }
                }
                tabla.Clear();
                T_GInventario.DataSource = tabla;

                //Guardar en archivos la ropa,tenis,suministros
                //Suben los articulos de ropa
                StreamWriter text1 = new StreamWriter("Ropa.txt");
                foreach (Ropa i in Lista_Ropa)
                {
                    text1.WriteLine(i.Talla1 + "#" + i.Color1 + "#" + i.Codigo_Provedor1 + "#" + i.Codigo_Producto1 + "#" +
                                   i.Descripcion1 + "#" + i.Categoria_Deporte1 + "#" + i.Cantidad_Disponible1 + "#" + i.Precio_Provedor1 + "#" + i.Precio_Producto1 + "#" +
                                   i.Marca1  + "#" + i.Material1);
                    
                }
                text1.Close();
                //Suben los articulos de tenis
                StreamWriter text2 = new StreamWriter("Tenis.txt");
                foreach (Tenis i in Lista_Tenis)
                {
                    text2.WriteLine(i.Talla1 + "#" + i.Color1 + "#" + i.Codigo_Provedor1 + "#" + i.Codigo_Producto1 + "#" +
                                   i.Descripcion1 + "#" + i.Categoria_Deporte1  + "#" + i.Cantidad_Disponible1 + "#" + i.Precio_Provedor1 + "#" + i.Precio_Producto1 + "#" +
                                   i.Marca1 + "#" + i.Material1);
                }
                text2.Close();
                //suben los suministros
                StreamWriter text3 = new StreamWriter("Suministro.txt");
                foreach (Suministro i in Lista_Suministros)
                {
                    text3.WriteLine(i.Codigo_Provedor1 + "#" + i.Codigo_Producto1 + "#" +
                                   i.Descripcion1 + "#" + i.Categoria_Deporte1 + "#" + i.Cantidad_Disponible1 + "#" + i.Precio_Provedor1 + "#" + i.Precio_Producto1 + "#" +
                                   i.Marca1  + "#" + i.Material1);
                }
                text3.Close();
                MessageBox.Show("Recarga de inventario Exitosa");

            }
            catch (IOException e2)
            {
                MessageBox.Show("Se ha producido error al subir el archivo: "+ e2.Message);
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
        }

        private void B_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                //tabla.Clear();
                bool correcto = false;
                if (Convert.ToInt32(TB_Cantidad.Text) > 0)
                {
                    //a traves de un codigo digitado
                    
                    //Seleciono un elemento por Combo Box
                    if (CB_Producto.SelectedItem.Equals("") == false)
                    {
                        string[] Codigo = Convert.ToString(CB_Producto.SelectedItem).Split('|');
                        foreach (Tenis i in Lista_Tenis)
                        {
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                DataRow fila = tabla.NewRow();
                                fila[0] = i.Codigo_Producto1;
                                fila[1] = i.Codigo_Provedor1;
                                fila[2] = i.Descripcion1;
                                fila[3] = i.Marca1; ;
                                fila[4] = Convert.ToInt32(TB_Cantidad.Text);
                                fila[5] = "$ " + i.Precio_Producto1;
                                fila[6] = "$ " + (i.Precio_Producto1* Convert.ToInt32(TB_Cantidad.Text));
                                tabla.Rows.Add(fila);
                                correcto = true;
                            }
                        }
                        foreach(Ropa i in Lista_Ropa)
                        {
                            //MessageBox.Show(i.Precio_Producto1 + "      " + Codigo[0]);
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                DataRow fila = tabla.NewRow();
                                fila[0] = i.Codigo_Producto1;
                                fila[1] = i.Codigo_Provedor1;
                                fila[2] = i.Descripcion1;
                                fila[3] = i.Marca1; ;
                                fila[4] = Convert.ToInt32(TB_Cantidad.Text);
                                fila[5] = "$ " + i.Precio_Producto1;
                                fila[6] = "$ " + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text));
                                tabla.Rows.Add(fila);
                                correcto = true;
                            }
                        }
                        foreach(Suministro i in Lista_Suministros)
                        {
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                DataRow fila = tabla.NewRow();
                                fila[0] = i.Codigo_Producto1;
                                fila[1] = i.Codigo_Provedor1;
                                fila[2] = i.Descripcion1;
                                fila[3] = i.Marca1; ;
                                fila[4] = Convert.ToInt32(TB_Cantidad.Text);
                                fila[5] = "$ " + i.Precio_Producto1;
                                fila[6] = "$ " + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text));
                                tabla.Rows.Add(fila);
                                correcto = true;
                            }
                        }
                    }
                    if (correcto == true)
                    {
                        TB_Cantidad.Text = "";
                        foreach (Ropa i in Lista_Ropa) CB_Producto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
                        foreach (Tenis i in Lista_Tenis) CB_Producto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
                        foreach (Suministro i in Lista_Suministros) CB_Producto.Items.Add(i.Codigo_Producto1 + "|    " + i.Descripcion1);
                    }
                    if (correcto == false)
                    {
                        MessageBox.Show("Por favor selecione un producto, o Ingrese un codigo valido");
                    }
                    //se suben los cambios ala tabla
                    T_GInventario.DataSource = tabla;
                }
                else MessageBox.Show("Cantidad No valida, Ingrese Una cantidad mayor a 0 y menor a 65000");
            }
            catch (FormatException e2)
            {
                MessageBox.Show("Revise que la cantidad sea un dato numerico y reintentelo");
            }

            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
        }

        private void LB_Titulo_Click(object sender, EventArgs e)
        {

        }

        private void T_GInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TB_Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void LB_Cantidad_Click(object sender, EventArgs e)
        {

        }

        private void CB_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LB_Producto_Click(object sender, EventArgs e)
        {

        }
    }
}
