using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Almacen;
using System.IO;

namespace Almacen_Deportivo
{
    public partial class Facturar : Form
    {
        private DataTable tabla=new DataTable();

        private string[] nombre_identificacion;
        private long NroFactura,NroCredito;
        private List<Factura> ListaFacturas = new List<Factura>();
        private static List<Cliente> Lista_Clientes = new List<Cliente>();
        private static List<Credito> Lista_Creditos = new List<Credito>();
        private Factura fa;
        public Facturar(DataTable tat,Compra compra,Cliente cliente)
        {
            InitializeComponent();
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Precio");
            tabla.Columns.Add("Precio Total");
            Llenartabla(tat);
            TB_Subtotal.Text = Nueva_Compra.datosCompra[0];
            TB_VIVA.Text= Nueva_Compra.datosCompra[1];
            TB_VFinal.Text= Nueva_Compra.datosCompra[2];
            TB_Vendedor.Text = Inicio.vendedor.Nombre1;
            SubirClientes();
            SubirCreditos();
            subirFacturas();
            fa = new Factura(cliente, compra,NroFactura,DateTime.Now);
            ListaFacturas.Add(fa);
            TB_NFactura.Text = Convert.ToString(fa.Nro_Factura1);
            TB_FCompra.Text = Convert.ToString(fa.Fecha_Compra1);
            T_Factura.DataSource = tabla;
        }
        public void Llenartabla(DataTable tat)
        {
            foreach(DataRow i in tat.Rows)
            {
                
                DataRow fila = tabla.NewRow();
                fila[0] = i[1];
                fila[1] = i[2];
                fila[2] = i[3];
                fila[3] = i[4]; 
                tabla.Rows.Add(fila);
            }
        }
        public void subirFacturas()
        {
            try
            {
                Credito cr;
                bool f = false;
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Factura.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    if (linea.Length < 7) NroFactura = Convert.ToInt64(linea);
                    else if (linea.Length > 1)
                    {
                        Destinosplit = linea.Split(',');
                        foreach(Cliente i in Lista_Clientes)
                        {
                            foreach(Credito j in Lista_Creditos)
                            {
                                if (Convert.ToString(j.Nro_Credito1).Equals(Destinosplit[1]))
                                {
                                    cr = j;
                                }
                            }
                            if (i.Identificacion1.Equals(Destinosplit[0]) && f==false)
                            {
                                Factura f1 = new Factura(i, Convert.ToInt64(Destinosplit[2]), Convert.ToDateTime(Destinosplit[3]));
                                ListaFacturas.Add(f1);
                                f = true;
                                NroFactura++;
                            }
                        }
                        if (f == false)
                        {
                            Factura f1 = new Factura( Convert.ToInt64(Destinosplit[2]), Convert.ToDateTime(Destinosplit[3]));
                            ListaFacturas.Add(f1);
                            NroFactura++;
                        }

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
        public void SubirCreditos()
        {
            string linea;
            string[] Destinosplit;
            StreamReader archivo;

            archivo = new StreamReader("Credito.txt");
            linea = archivo.ReadLine();
            while (linea != null)
            {
                if (linea.Length > 1)
                {
                    if (linea.Length < 7) NroCredito = Convert.ToInt64(linea);
                    else
                    {
                        Destinosplit = linea.Split(',');
                        Credito C1 = new Credito(Convert.ToInt64(Destinosplit[0]), Convert.ToInt16(Destinosplit[1]),  Convert.ToDouble(Destinosplit[2]), Convert.ToInt16(Destinosplit[3]) );
                        Lista_Creditos.Add(C1);
                    }
                }
                linea = archivo.ReadLine();
            }
            archivo.Close();
        }

        private void B_Efectivo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La cantidad a pagar es: " + TB_VFinal.Text+" a traves de efectivo");
            AlmacenarFactura();
            this.Close();
        }

        private void B_TDebito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La cantidad a pagar es: " + TB_VFinal.Text+" a traves de la tarjeta de debito");
            AlmacenarFactura();
            this.Close();
        }

        private void B_TCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La cantidad a pagar es: " + TB_VFinal.Text+" a traves de tarjeta de credito");
            AlmacenarFactura();
            this.Close();
        }

        private void B_Regresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AlmacenarFactura()
        {
            try
            {
                StreamWriter arc = new StreamWriter("Factura.txt");
                foreach (Factura i in ListaFacturas)
                {
                    arc.WriteLine("1000");
                    if (i.Credito.Nro_Credito1 < 0) arc.WriteLine(i.Cliente.Identificacion1 + "," + i.Credito.Nro_Credito1 + "," + i.Nro_Factura1 + "," + i.Fecha_Compra1);
                    else arc.WriteLine(i.Cliente.Identificacion1 + "," + i.Nro_Factura1 + "," + i.Fecha_Compra1);
                }
                arc.Close();
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

        private void B_Credito_Click(object sender, EventArgs e)
        {
            Hide();
            Nuevo_Credito nc = new Nuevo_Credito(Convert.ToDouble(TB_VFinal.Text.Trim('$')));
            nc.ShowDialog();
            Show();
            
        }

    }
}
