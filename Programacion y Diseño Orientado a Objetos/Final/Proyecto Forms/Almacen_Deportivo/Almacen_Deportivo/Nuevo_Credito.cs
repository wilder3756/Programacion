using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen_Deportivo
{
    public partial class Nuevo_Credito : Form
    {
        private double precio;
        public Nuevo_Credito(double PrecioPagar)
        {
            InitializeComponent();
            CB_NCuotas.Items.Add("3");
            CB_NCuotas.Items.Add("6");
            CB_NCuotas.Items.Add("12");
            TB_FPago.Text = Convert.ToString(DateTime.Now);
            precio = PrecioPagar;
        }

        private void B_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Pagar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Elementos Faltantes: \n 1.guardar credito a la factura correspondiente");
        }
    }
}
