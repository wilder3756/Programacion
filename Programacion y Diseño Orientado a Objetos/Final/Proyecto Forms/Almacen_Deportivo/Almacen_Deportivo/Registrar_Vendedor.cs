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
    public partial class Registrar_Vendedor : Form
    {
        private static List<Vendedor> Lista_vendedores = new List<Vendedor>();
        public Registrar_Vendedor()
        {
            InitializeComponent();
            Lista_vendedores.Clear();
            SubirClientes();
        }

        public void SubirClientes()
        {
            try
            {
                string linea;
                string[] Destinosplit;
                StreamReader archivo;

                archivo = new StreamReader("Usuarios.txt");
                linea = archivo.ReadLine();
                while (linea != null)
                {
                    if (linea.Length > 1)
                    {
                        Destinosplit = linea.Split(',');
                        Vendedor v1 = new Vendedor(Destinosplit[0], Destinosplit[1], Destinosplit[2], Convert.ToInt64(Destinosplit[3]));
                        Lista_vendedores.Add(v1);
                        
                    }
                    linea = archivo.ReadLine();
                }
                archivo.Close();
                //añadir vendedores al combo box
                CB_SUsuario.Items.Clear();
                foreach (Vendedor i in Lista_vendedores)
                {
                    CB_SUsuario.Items.Add(i.Usuario);
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

        private void B_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificacion de los campos , como validos
                if (TB_Contraseña.Text.Equals("") == true || TB_Usuario.Text.Equals("") == true
                || Convert.ToInt64(TB_Identificacion.Text) < 10000 || TB_Nombre.Text.Equals("") == true) MessageBox.Show("Debe llenar los campos usuario,identificacion,nombre,usuario con datos validos. \nPor Favor verifiquelo");

                else
                {
                    Vendedor V1 = new Vendedor(TB_Usuario.Text, TB_Contraseña.Text, TB_Nombre.Text, Convert.ToInt64(TB_Identificacion.Text));
                    Lista_vendedores.Add(V1);
                    StreamWriter text = new StreamWriter("Usuarios.txt", true);
                    text.WriteLine("\n"+TB_Usuario.Text + "," + TB_Contraseña.Text + "," + TB_Nombre.Text + "," + TB_Identificacion.Text);
                    text.Close();
                    TB_Usuario.Text = "";
                    TB_Contraseña.Text = "";
                    TB_Nombre.Text = "";
                    TB_Identificacion.Text = "";
                    MessageBox.Show("Se ha añadido el vendedor exitosamente");
                }
                
            }
            catch(FormatException e2)
            {
                MessageBox.Show("Error en el formato de los datos, por favor revise que en los campos se halla ingresado \n" +
                    "los datos en el formato correspondiente(Identificacion es un numerico  de mas de 5 cifras)");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
            
        }

        private void CB_SUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Actualiza el CB_SUsuario
            foreach (Vendedor i in Lista_vendedores)
            {
                if (i.Usuario.Equals(CB_SUsuario.SelectedItem) == true)
                {
                    TB_Nombre1.Text = i.Nombre1;
                    TB_Identificaion1.Text = Convert.ToString(i.Identificacion1);
                }
            }
        }

        private void B_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CB_SUsuario.SelectedItem.Equals("") == true) MessageBox.Show("Por favor seleciones un usuario antes de eliminarlo");
                //Eliminacion si se ha selecionado un elemento del CB_SUsuario
                else
                {
                    Vendedor vendedor = new Vendedor("sdfs", "sdfs", "df", 111111);
                    //Se hallan el vendedror a eliminar
                    foreach (Vendedor i in Lista_vendedores)
                    {
                        if (i.Usuario.Equals(CB_SUsuario.SelectedItem.ToString()) == true)
                        {
                            vendedor = i;
                        }
                    }
                    //Eliminacion de Usuario y limpian TB
                    Lista_vendedores.Remove(vendedor);
                    TB_Nombre1.Text = "";
                    TB_Identificaion1.Text = "";
                    CB_SUsuario.Items.Clear();
                    //Actualiza CB_SUsuario
                    foreach (Vendedor i in Lista_vendedores)
                    {
                        CB_SUsuario.Items.Add(i.Usuario);
                    }
                    //Actualiza Archivo Usuarios
                    StreamWriter text = new StreamWriter("Usuarios.txt");
                    foreach (Vendedor i in Lista_vendedores)
                    {
                            text.WriteLine(i.Usuario + "," + i.Clave + "," + i.Nombre1 + "," + i.Identificacion1);
                        
                    }
                    text.Close();
                    MessageBox.Show("La eliminacion ha sido un exitosa");
                    foreach (Vendedor i in Lista_vendedores)
                    {
                        CB_SUsuario.Items.Add(i.Usuario);
                    }
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
            
            
        }
    }
}
