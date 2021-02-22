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
    public partial class Inicio : Form
    {
        public List<Vendedor> lista_vendedores=new List<Vendedor>();
        public static Vendedor vendedor;
        public Inicio()
        {

            InitializeComponent();
            SubirClientes();
            

        }
        public void SubirClientes()
        {
            try
            {
                //Se suben los vendedores a una lista de vendedores
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Usuarios.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    Destinosplit = linea.Split(',');
                    Vendedor v1 = new Vendedor(Destinosplit[0], Destinosplit[1], Destinosplit[2], Convert.ToInt64(Destinosplit[3]));
                    lista_vendedores.Add(v1);
                    vendedor = v1; //Almacena el vendedor logueado que sera utilizado en el futuro.
                    linea = archivo.ReadLine();
                    
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
        private void B_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                bool f = false;
                //Conprobacion contra lista de vendedores para  logueo
                foreach (Vendedor i in lista_vendedores)
                {
                    if (i.Usuario.Equals(TB_Usuario.Text) == true && i.Clave.Equals(TB_Contraseña.Text) == true)
                    {
                        //logueo
                        MessageBox.Show("Logueo Exitoso");
                        vendedor = i;
                        f = true;
                        TB_Usuario.Text = "";
                        TB_Contraseña.Text = "";
                        Hide();
                        Menu_Principal FP = new Menu_Principal();
                        FP.ShowDialog();
                        Show();
                    }
                }
                //logueo negativo
                if (f == false)
                {
                    TB_Usuario.Text = "";
                    TB_Contraseña.Text = "";
                    MessageBox.Show("Logueo Incorrecto, Por Favor Reintentelo");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
            
        }
    }
}
