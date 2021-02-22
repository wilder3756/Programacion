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
    public partial class Crear_Nuevo_Cliente : Form
    {
        private static List<Cliente> Lista_Clientes=new List<Cliente>();
        public Crear_Nuevo_Cliente()
        {
            InitializeComponent();
            Lista_Clientes.Clear();
            SubirClientes();
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
                        
                        Cliente C1 = new Cliente(Destinosplit[0],Convert.ToInt64(Destinosplit[1]), Convert.ToInt64(Destinosplit[2]), Destinosplit[3],Convert.ToDateTime(Destinosplit[4]));
                        Lista_Clientes.Add(C1);

                    }
                    linea = archivo.ReadLine();
                }
                archivo.Close();
                //añadir vendedores al combo box
                CB_SeleccionarNombre.Items.Clear();
                foreach (Cliente i in Lista_Clientes)
                {
                    CB_SeleccionarNombre.Items.Add(i.Nombre1);
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

        private void B_Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificacion de los campos , como validos
                if (TB_Nombre.Text.Equals("") == true || TB_Correo.Text.Equals("") == true
                || Convert.ToInt64(TB_Identificacion.Text) < 10000 || Convert.ToInt64(TB_Identificacion.Text) > 10000000000
                || Convert.ToInt64(TB_Identificacion.Text) < 10000 || DTP_FNacimiento.Value.Date>DateTime.Now.AddYears(-18))
                    MessageBox.Show("Debe llenar los campos identificacion,nombre,etc. con datos validos(el cliente a de ser mayor de edad). \nPor Favor verifiquelo");

                else
                {
                    Cliente C2 = new Cliente(TB_Nombre.Text, Convert.ToInt64(TB_Identificacion.Text), Convert.ToInt64(TB_Telefono.Text),TB_Correo.Text, Convert.ToDateTime(DTP_FNacimiento.Value.Date));
                    Lista_Clientes.Add(C2);
                    StreamWriter text = new StreamWriter("Cliente.txt", true);
                    text.WriteLine("\n" + TB_Nombre.Text + "," + TB_Identificacion.Text + "," + TB_Telefono.Text + "," + TB_Correo.Text + ","+ Convert.ToDateTime(DTP_FNacimiento.Value.Date));
                    text.Close();
                    TB_Nombre.Text = "";
                    TB_Identificacion.Text = "";
                    TB_Telefono.Text = "";
                    TB_Correo.Text = "";
                    MessageBox.Show("Se ha añadido al cliente exitosamente");
                }

            }
            catch (FormatException e2)
            {
                MessageBox.Show("Error en el formato de los datos, por favor revise que en los campos se halla ingresado \n" +
                    "los datos en el formato correspondiente(Identificacion es un numerico  de mas de 5 cifras)");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
        }

        private void B_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CB_SeleccionarNombre.SelectedItem.Equals("") == true) MessageBox.Show("Por favor seleciones un Cliente antes de eliminarlo");
                //Eliminacion si se ha selecionado un elemento del CB_SUsuario
                else
                {
                    Cliente cliente = new Cliente("dfg", 22334456, 1111111, "",DateTime.Now.AddYears(-20));
                    //Se hallan el vendedror a eliminar
                    foreach (Cliente i in Lista_Clientes)
                    {
                        if (i.Nombre1.Equals(CB_SeleccionarNombre.SelectedItem.ToString()) == true)
                        {
                            cliente = i;
                        }
                    }
                    //Eliminacion de Usuario y limpian TB
                    Lista_Clientes.Remove(cliente);
                    TB_TelefonoEliminar.Text = "";
                    TB_IdentificacionEiminar.Text = "";
                    TB_CorreoEliminar.Text = "";
                    //Actualiza CB_SUsuario
                    foreach (Cliente i in Lista_Clientes)
                    {
                        CB_SeleccionarNombre.Items.Add(i.Nombre1);
                    }
                    //Actualiza Archivo Usuarios
                    StreamWriter text = new StreamWriter("Cliente.txt");
                    foreach (Cliente i in Lista_Clientes)
                    {
                        text.WriteLine(i.Nombre1 + "," + i.Identificacion1 + "," + i.Telefono1+ "," + i.Correo1+","+i.Fecha_Nacimiento1);

                    }
                    text.Close();
                    MessageBox.Show("La eliminacion ha sido un exito");
                    foreach (Cliente i in Lista_Clientes)
                    {
                        CB_SeleccionarNombre.Items.Add(i.Nombre1);
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error general en: " + e1.Message);
            }
        }

        private void CB_SeleccionarNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Cliente i in Lista_Clientes)
            {
                if (i.Nombre1.Equals(CB_SeleccionarNombre.SelectedItem) == true)
                {
                    TB_IdentificacionEiminar.Text = Convert.ToString(i.Identificacion1);
                    TB_TelefonoEliminar.Text = Convert.ToString(i.Telefono1);
                    TB_CorreoEliminar.Text = i.Correo1;
                }
            }
        }
    }
}
