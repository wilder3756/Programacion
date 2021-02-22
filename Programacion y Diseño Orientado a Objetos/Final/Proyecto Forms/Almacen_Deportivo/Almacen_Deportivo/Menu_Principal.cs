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
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void B_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B_NCompra_Click(object sender, EventArgs e)
        {
            Hide();
            Nueva_Compra NC = new Nueva_Compra();
            NC.ShowDialog();
            Show();
        }

        private void B_NCliente_Click(object sender, EventArgs e)
        {
            Hide();
            Crear_Nuevo_Cliente CNC = new Crear_Nuevo_Cliente();
            CNC.ShowDialog();
            Show();
        }

        private void B_RInventario_Click(object sender, EventArgs e)
        {
            Hide();
            Revisar_Inventario RI = new Revisar_Inventario();
            RI.ShowDialog();
            Show();
        }

        private void B_RCreditos_Click(object sender, EventArgs e)
        {
            Hide();
            Revisar_Creditos RC = new Revisar_Creditos();
            RC.ShowDialog();
            Show();
        }

        private void B_GInventario_Click(object sender, EventArgs e)
        {
            Hide();
            Generar_Inventario GI = new Generar_Inventario();
            GI.ShowDialog();
            Show();
        }

        private void B_PagarCC_Click(object sender, EventArgs e)
        {
            Hide();
            PagarCuota PC = new PagarCuota();
            PC.ShowDialog();
            Show();
        }

        private void B_RVendedor_Click(object sender, EventArgs e)
        {
            Hide();
            Registrar_Vendedor RV = new Registrar_Vendedor();
            RV.ShowDialog();
            Show();
        }

    }
}
