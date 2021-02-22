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
    public partial class Nueva_Compra : Form
    {
        private static List<Ropa> Lista_Ropa = new List<Ropa>();
        private static List<Tenis> Lista_Tenis = new List<Tenis>();
        private static List<Suministro> Lista_Suministros = new List<Suministro>();
        private static List<Cliente> Lista_Clientes = new List<Cliente>();
        private DataTable tabla = new DataTable();
        public static string[] datosCompra = new string[3];
        public static string[] identificacion_nombre = new string[2];
        public static Compra nCompra;
        public Nueva_Compra()
        {
            InitializeComponent();
            Lista_Ropa.Clear();
            Lista_Suministros.Clear();
            Lista_Tenis.Clear();
            tabla.Clear();
            T_PCompra.DataSource = tabla;
            tabla.Columns.Add("");
            tabla.Columns.Add("Codigo Interno");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Precio Unitario");
            tabla.Columns.Add("Precio Producto");
            SubirRopa();
            SubirSuministro();
            SubirTenis();
            T_PCompra.DataSource = tabla;
            nCompra = new Compra(Inicio.vendedor);
            SubirClientes();
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
                    CB_SProducto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
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
                    CB_SProducto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
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
                    CB_SProducto.Items.Add(i.Codigo_Producto1 + "|    " + i.Descripcion1);
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
        public void SubirClientes()
        {
            try
            {
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Cliente.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    if (linea.Length > 1)
                    {
                        Destinosplit = linea.Split(',');

                        Cliente C1 = new Cliente(Destinosplit[0], Convert.ToInt64(Destinosplit[1]), Convert.ToInt64(Destinosplit[2]), Destinosplit[3], Convert.ToDateTime(Destinosplit[4]));
                        Lista_Clientes.Add(C1);

                    }
                    linea = archivo.ReadLine();
                }
                archivo.Close();
                //añadir vendedores al combo box
                

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
                    if (CB_SProducto.SelectedItem.Equals("") == false)
                    {
                        string[] Codigo = Convert.ToString(CB_SProducto.SelectedItem).Split('|');
                        foreach (Tenis i in Lista_Tenis)
                        {
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                if(i.Cantidad_Disponible1>= Convert.ToInt32(TB_Cantidad.Text))
                                {
                                    DataRow fila = tabla.NewRow();
                                    fila[0] = i.Codigo_Producto1;
                                    fila[1] = i.Descripcion1;
                                    fila[2] = Convert.ToInt32(TB_Cantidad.Text);
                                    fila[3] = "$ " + i.Precio_Producto1;
                                    fila[4] = "$ " + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text));
                                    tabla.Rows.Add(fila);
                                    TB_Subtotal.Text = Convert.ToString(Convert.ToDouble(TB_Subtotal.Text) + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text)));
                                    nCompra.Agregar_Tenis(i);
                                }
                                else MessageBox.Show("No hay Suficiente Inventario, por favor recargue.");
                                correcto = true;


                            }
                        }
                        foreach (Ropa i in Lista_Ropa)
                        {
                            //MessageBox.Show(i.Precio_Producto1 + "      " + Codigo[0]);
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                if (i.Cantidad_Disponible1 >= Convert.ToInt32(TB_Cantidad.Text))
                                {
                                    DataRow fila = tabla.NewRow();
                                    fila[0] = i.Codigo_Producto1;
                                    fila[1] = i.Descripcion1;
                                    fila[2] = Convert.ToInt32(TB_Cantidad.Text);
                                    fila[3] = "$ " + i.Precio_Producto1;
                                    fila[4] = "$ " + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text));
                                    tabla.Rows.Add(fila);
                                    TB_Subtotal.Text = Convert.ToString(Convert.ToDouble(TB_Subtotal.Text) + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text)));
                                    nCompra.Agregar_Ropa(i);
                                }

                                else MessageBox.Show("No hay Suficiente Inventario, por favor recargue.");
                                correcto = true;
                            }
                        }
                        foreach (Suministro i in Lista_Suministros)
                        {
                            if (i.Codigo_Producto1.Equals(Codigo[0]) == true)
                            {
                                if (i.Cantidad_Disponible1 >= Convert.ToInt32(TB_Cantidad.Text))
                                {
                                    DataRow fila = tabla.NewRow();
                                    fila[0] = i.Codigo_Producto1;
                                    fila[1] = i.Descripcion1;
                                    fila[2] = Convert.ToInt32(TB_Cantidad.Text);
                                    fila[3] = "$ " + i.Precio_Producto1;
                                    fila[4] = "$ " + (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text));
                                    tabla.Rows.Add(fila);
                                    TB_Subtotal.Text = Convert.ToString(Convert.ToDouble(TB_Subtotal.Text)+ (i.Precio_Producto1 * Convert.ToInt32(TB_Cantidad.Text)));
                                    nCompra.Agregar_Suministros(i);
                                }
                                else MessageBox.Show("No hay Suficiente Inventario, por favor recargue.");
                                correcto = true;
                            }
                        }
                    }
                    if (correcto == true)
                    {
                        TB_Cantidad.Text = "";
                        foreach (Ropa i in Lista_Ropa) CB_SProducto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
                        foreach (Tenis i in Lista_Tenis) CB_SProducto.Items.Add(i.Codigo_Producto1 + "|      " + i.Descripcion1);
                        foreach (Suministro i in Lista_Suministros) CB_SProducto.Items.Add(i.Codigo_Producto1 + "|    " + i.Descripcion1);
                        TB_IVA.Text = Convert.ToString((Convert.ToDouble(TB_Subtotal.Text) *19)/100);
                        TB_Total.Text = Convert.ToString(Convert.ToDouble(TB_IVA.Text) + Convert.ToDouble(TB_Subtotal.Text));
                    }
                    if (correcto == false)
                    {
                        MessageBox.Show("Por favor selecione un producto, o Ingrese un codigo valido");
                    }
                    //se suben los cambios ala tabla
                    T_PCompra.DataSource = tabla;
                   
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

        private void B_Comprar_Click(object sender, EventArgs e)
        {
            datosCompra[0] = TB_Subtotal.Text;
            datosCompra[1] = TB_IVA.Text;
            datosCompra[2] = TB_Total.Text;
            
            if (TB_Identificacion.Text.Equals("") == false && TB_Nombre.Text.Equals("") == false)
            {
                foreach (Cliente i in Lista_Clientes)
                {
                    //MessageBox.Show("Identificacion obtenida: " + TB_Identificacion.Text + "Identificacion lista: " + i.Identificacion1);
                    if (Convert.ToString(i.Identificacion1).Equals(TB_Identificacion.Text))
                    {
                        //MessageBox.Show("3");
                        Hide();
                        Facturar fa = new Facturar(tabla, nCompra, i);
                        fa.ShowDialog();
                        Show();
                    }
                }
                /*Hide();
                Facturar fa = new Facturar(tabla, nCompra,identificacion_nombre);
                fa.ShowDialog();
                Show();*/
            }
            else MessageBox.Show("No se puede registar una compra sin el nombre e identificacion del usuario");
        }
    }
}
