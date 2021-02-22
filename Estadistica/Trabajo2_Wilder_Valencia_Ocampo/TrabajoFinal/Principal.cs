using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinal
{
    public partial class Principal : Form
    {
        private int Nro,NroGanadas=0,NroPerdidas=0;

        public Principal()
        {
            InitializeComponent();
            GB_Automatica.Enabled = false;
            GB_Manual.Enabled = false;
        }
        private void B_Manual_Click(object sender, EventArgs e)
        {
            InicializarAutomatico();
            GB_Automatica.Enabled = false;
            GB_Manual.Enabled = true;
            InicializarManual();
        }

        private void B_Automatica_Click(object sender, EventArgs e)
        {
            GB_Automatica.Enabled = true;
            InicializarManual();
            GB_Manual.Enabled = false;
            InicializarAutomatico();
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        //MANUAL
            private void InicializarManual()
            {
                try
                {
                    //Inicializar los componentes de apuesta manual a sus estados iniciales
                    TB_SaldoActual.Text = string.Format("{0:C}", 0);
                    TB_SaldoApostar.Text = string.Format("{0:C}", 0);
                    TB_SaldoInicialManual.Text = string.Format("{0:C}", 0);
                    TB_CuotaApuesta.Text = 0 + "";
                    TB_ProbabilidadGanar.Text = 0 + "";
                    Nro = 0;
                    NroGanadas = 0;
                    NroPerdidas = 0;
                    LB_Resultado.ForeColor = Color.Black;
                    LB_Resultado.Text = "Resultado";
                    Grafica_Manual.Series[0].Points.Clear();
                    LB_RGano.Text = "0";
                    LB_RPerdio.Text = "0";
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error." + e.Message);
                }
            }
        
            private void TB_ProbabilidadGanar_Leave(object sender, EventArgs e)
            {
                try
                {
                
                    if (TB_ProbabilidadGanar.Text.Equals("")) TB_ProbabilidadGanar.Text = string.Format("{0:C}", 0);
                    else
                    {
                    
                        double PG = Convert.ToDouble(TB_ProbabilidadGanar.Text), CA = 0;
                    
                        if ((int)PG > 0 && (int)PG < 100) CA = 1d / (PG * 0.01);
                        else
                        {
                            TB_ProbabilidadGanar.Focus();
                            MessageBox.Show("La probabilidad de ganar en porcentaje debe ser mayor que 0 y menor que 100.");
                        }
                    
                        TB_ProbabilidadGanar.Text = Convert.ToDouble(TB_ProbabilidadGanar.Text) + "";
                        TB_CuotaApuesta.Text = CA + "";
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message);
                    TB_ProbabilidadGanar.Focus();
                }
            }
            private void TB_SaldoInicialManual_Leave(object sender, EventArgs e)
            {
                try
                {
                    if (TB_SaldoInicialManual.Text.Equals("")) TB_SaldoInicialManual.Text = string.Format("{0:C}", 0);
                    else
                    {
                        double Saldo = Convert.ToDouble(TB_SaldoInicialManual.Text);
                        if (Saldo > 0 && (Saldo % 50) == 0)
                        {
                            TB_SaldoInicialManual.Text = string.Format("{0:C}", Saldo);
                            TB_SaldoActual.Text = string.Format("{0:C}", Saldo);
                            Grafica_Manual.Series[0].Points.AddXY(Nro, Saldo);
                        }
                        else
                        {
                            TB_SaldoInicialManual.Focus();
                            MessageBox.Show("El saldo inicial debe ser mayor de cero y multipo de 50.");
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message);
                    TB_SaldoInicialManual.Focus();
                }
            }
            private void TB_SaldoApostar_Leave(object sender, EventArgs e)
            {
                try
                {
                    if (TB_SaldoApostar.Text.Equals("")) TB_SaldoApostar.Text = string.Format("{0:C}", 0);
                    else
                    {
                        double Apostar = Convert.ToDouble(TB_SaldoApostar.Text), Saldo = Convert.ToDouble(TB_SaldoInicialManual.Text.Replace("$", ""));
                        if (Apostar > 0 && Apostar <= Saldo && (Apostar % 50) == 0) TB_SaldoApostar.Text = string.Format("{0:C}", Apostar);
                        else
                        {
                            TB_SaldoApostar.Focus();
                            MessageBox.Show("El saldo a postar debe ser mayor de cero y menor o igual al saldo actual además debe ser multipo de 50.");
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message);
                    TB_SaldoApostar.Focus();
                }
            }
        
            private void TB_SaldoInicialManual_Enter(object sender, EventArgs e)
            {
                try
                {
                    bool cam = false;
                    if (Convert.ToDouble(TB_SaldoApostar.Text.Replace("$", "")) > 0)
                    {
                        if (MessageBox.Show(null, "Si cambia el saldo inicial se reiniciarán todas las apuestas.", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes) cam = true;
                    }
                    else cam = true;
                    if (cam)
                    {
                        InicializarManual();
                        if (Convert.ToDouble(TB_SaldoInicialManual.Text.Replace("$", "")) > 0) TB_SaldoInicialManual.Text = TB_SaldoInicialManual.Text.Replace("$", "");
                        else TB_SaldoInicialManual.Text = "";
                    }
                    else Grafica_Automatica.Focus();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
            private void TB_SaldoApostar_Enter(object sender, EventArgs e)
            {
                try
                {
                    if (TB_SaldoInicialManual.Text.Replace("$", "").Equals("0")) TB_SaldoInicialManual.Focus();
                    else
                    {
                        if (Convert.ToDouble(TB_SaldoApostar.Text.Replace("$", "")) > 0) TB_SaldoApostar.Text = TB_SaldoApostar.Text.Replace("$", "");
                        else TB_SaldoApostar.Text = "";
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
            private void TB_ProbabilidadGanar_Enter(object sender, EventArgs e)
            {
                try
                {
                    if (TB_ProbabilidadGanar.Text.Equals("0")) TB_ProbabilidadGanar.Text = "";
                    if (TB_ProbabilidadGanar.Text.Equals("")==false)
                    {
                        if (Convert.ToDouble(TB_ProbabilidadGanar.Text) < 0 || Convert.ToDouble(TB_ProbabilidadGanar.Text) > 100)
                        {

                            MessageBox.Show("La probabilidad debe ser mayor de cero y menor a 100");
                        }
                    }
                

                }
                catch (Exception er)
                {
                    MessageBox.Show("ErrorEnter. " + er.Message);
                }
            }
            private void B_Apostar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (Convert.ToSingle(TB_SaldoActual.Text.Replace("$", "")) == 0)
                    {
                        if (MessageBox.Show(null, "Ha perdido Todo, desea Comenzar Con un Nuevo saldo", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            InicializarManual();
                            TB_SaldoInicialManual.Focus();
                            return;
                        }
                    }
                    Random r = new Random();
                
                    double SaldoApostar = Convert.ToDouble(TB_SaldoApostar.Text.Replace("$", "")), CA = Convert.ToDouble(TB_CuotaApuesta.Text),
                        SaldoActual = Convert.ToDouble(TB_SaldoActual.Text.Replace("$", "")), VG = 0, g = r.NextDouble(); 
                    //Validar los campos de textos
                    if (SaldoApostar > 0 && SaldoActual > 0 && CA > 0 && SaldoActual>=SaldoApostar)
                    {
                        if (g <= (Convert.ToDouble(TB_ProbabilidadGanar.Text)/100))//Validar si ganó con el numero aleatorio generado con la probabilidad de ganar //g <= (1d / CA)
                        {
                            LB_Resultado.ForeColor = Color.Green;
                            Text = "¡FELICIDADES!";
                            LB_Resultado.Text = "¡GANÓ!";
                            VG = SaldoApostar * CA;
                            NroGanadas++;
                            LB_RGano.Text = NroGanadas.ToString();
                        }
                        else
                        {
                            LB_Resultado.ForeColor = Color.Red;
                            Text = "¡SUERTE PARA LA PROXIMA!";
                            LB_Resultado.Text = "¡PERDIÓ!";
                            NroPerdidas++;
                            LB_RPerdio.Text = NroPerdidas.ToString();
                        }
                        Nro++; //Aumentar el numero de apuesta
                        SaldoActual = SaldoActual - SaldoApostar + VG; //Calcular el nuevo saldo
                        TB_SaldoActual.Text = string.Format("{0:C}", SaldoActual);
                        Grafica_Manual.Series[0].Points.AddXY(Nro, SaldoActual); //Añadir punto
                    }
                    else {
                    
                        if(SaldoApostar < 0) MessageBox.Show(null, "Revise que el saldo apostar sea mayor que cero.", "No es posible apostar");
                        else if(SaldoActual < 0) MessageBox.Show(null, "Revise que el saldo actual sea mayor que cero.", "No es posible apostar");
                        else if(SaldoActual < SaldoApostar) MessageBox.Show(null, "LA apuesta no puede ser mayor que su saldo Actual.", "No es posible apostar");
                        else MessageBox.Show(null, "Revise que el saldo inicial, el saldo apostar y la probabilidad sea mayor que cero.", "No es posible apostar");
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message);
                }
            }
        
            private void button1_Click(object sender, EventArgs e)
            {
                InicializarManual();
            }


        //AUTOMATICA
            private void InicializarAutomatico()
            {
                TB_NroApuestas.Text = 0 + "";
                TB_SaldoInicialAutomatico.Text = string.Format("{0:C}", 0);
                Grafica_Automatica.Series[0].Points.Clear();
                TB_ValorApostado.Visible = false;
                TB_Probabilidad.Visible = false;
                TB_SaldoFinal.Text = "";
            }


            private void TB_SaldoInicialAutomatico_Enter(object sender, EventArgs e)
            {
                try
                {
                    InicializarAutomatico();
                //MessageBox.Show(TB_SaldoInicialAutomatico.Text.Replace("$", ""));
                    if(TB_SaldoInicialAutomatico.Text.Equals("$ 0,00") == false)
                    {
                        if (Convert.ToInt64(TB_SaldoInicialAutomatico.Text.Replace("$", "")) > 0) TB_SaldoInicialAutomatico.Text = TB_SaldoInicialAutomatico.Text.Replace("$", "");
                        else TB_SaldoInicialAutomatico.Text = "";
                    }
                    else TB_SaldoInicialAutomatico.Text = "";

            }
                catch (Exception er)
                {
                    MessageBox.Show("ErrorEnter. " + er.Message);
                }
            }
        
            private void TB_SaldoInicialAutomatico_Leave(object sender, EventArgs e)
            {
                try
                {
                    if (TB_SaldoInicialAutomatico.Text.Equals("")) TB_SaldoInicialAutomatico.Text = string.Format("{0:C}", 0);
                    else
                    {
                        double Saldo = Convert.ToDouble(TB_SaldoInicialAutomatico.Text);
                        if (Saldo > 0 && (Saldo % 50) == 0)
                        {
                            TB_SaldoInicialAutomatico.Text = string.Format("{0:C}", Saldo);
                            Grafica_Automatica.Series[0].Points.AddXY(0, Saldo);
                        }
                        else
                        {
                            TB_SaldoInicialAutomatico.Focus();
                            MessageBox.Show("El saldo inicial debe ser mayor de cero y multipo de 50.");
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error: " + er.Message);
                    TB_SaldoInicialAutomatico.Focus();
                }
            }

            private void TB_NroApuestas_Enter(object sender, EventArgs e)
            {
                try
                {
                    if (Convert.ToInt64(TB_NroApuestas.Text) == 0) TB_NroApuestas.Text = "";
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
        
            private void TB_NroApuestas_Leave(object sender, EventArgs e)
            {

                try
                {
                    if (TB_NroApuestas.Text.Equals("")) TB_NroApuestas.Text = 0 + "";
                    else
                    {
                        if (Convert.ToInt64(TB_NroApuestas.Text) > 0) TB_NroApuestas.Text = Convert.ToInt64(TB_NroApuestas.Text) + "";
                        else
                        {
                            MessageBox.Show("El numero de apuesta debe ser mayor que 0.");
                            TB_NroApuestas.Focus();
                        }
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }

            private void CB_EstEconomizadora_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    if (CB_EstEconomizadora.Checked) CB_EstDerrochadora.Checked = false;
                    else CB_EstDerrochadora.Checked = true;
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
        
            private void CB_EstDerrochadora_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    if (CB_EstDerrochadora.Checked) CB_EstEconomizadora.Checked = false;
                    else CB_EstEconomizadora.Checked = true;
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }

            private void CB_EstConservadora_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    if (CB_EstConservadora.Checked)
                    {
                        CB_EstMedia.Checked = false;
                        CB_EstArriesgada.Checked = false;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
            private void CB_EstArriesgada_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    if (CB_EstMedia.Checked)
                    {
                        CB_EstConservadora.Checked = false;
                        CB_EstArriesgada.Checked = false;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }

       

        private void CB_EstMedia_CheckedChanged(object sender, EventArgs e)
            {
                try
                {
                    if (CB_EstArriesgada.Checked)
                    {
                        CB_EstConservadora.Checked = false;
                        CB_EstMedia.Checked = false;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }
            private void B_Iniciar_Click(object sender, EventArgs e)
            {
                try
                {
                    Grafica_Automatica.Series[0].Points.Clear();
                    long Inicial = (long)Convert.ToDouble(TB_SaldoInicialAutomatico.Text.Replace("$", "")), n = Convert.ToInt64(TB_NroApuestas.Text), VA, S,nAux=0;
                    Random pg = new Random(), va = new Random(), r = new Random();
                    double CA, PG, R;

                    if (Inicial > 0 && (CB_EstConservadora.Checked || CB_EstMedia.Checked || CB_EstArriesgada.Checked) && (CB_EstEconomizadora.Checked || CB_EstDerrochadora.Checked) && n > 0)
                    {
                        S = Inicial;
                    //Calcular la probabilidad y la cuota de apuesta
                    if (CB_EstConservadora.Checked) PG = pg.Next(80, 100) / 100d;
                    else if (CB_EstArriesgada.Checked) PG = pg.Next(0, 20) / 100d;
                    else PG = pg.Next(40, 60) / 100d;
                    CA = 1d / PG;
                    TB_Probabilidad.Visible = true;
                    TB_Probabilidad.Text = (PG * 100).ToString();
                    //LbPG.Text = PG + "";

                    //Calcular el valor apostar
                    if (CB_EstEconomizadora.Checked) VA = (long)((va.Next(0, 10) / 100d) * Inicial);
                    else VA = (long)((va.Next(20, 30) / 100d) * Inicial);
                    TB_ValorApostado.Visible = true;
                    TB_ValorApostado.Text = VA.ToString();
                    //LbVA.Text = string.Format("{0:C}", VA);

                    //Simular las n apuestas
                    Grafica_Automatica.Series[0].Points.AddXY(0, Inicial);
                        for (int i = 0; i < n && S>=VA; i++)
                        {
                        if (CB_EstConservadora.Checked) PG = pg.Next(80, 100) / 100d;
                        else if (CB_EstArriesgada.Checked) PG = pg.Next(0, 20) / 100d;
                        else PG = pg.Next(40, 60) / 100d;
                        CA = 1d / PG;
                        TB_Probabilidad.Visible = true;
                        TB_Probabilidad.Text = (PG * 100).ToString();
                        //LbPG.Text = PG + "";

                        //Calcular el valor apostar
                        if (CB_EstEconomizadora.Checked) VA = (long)((va.Next(0, 10) / 100d) * Inicial);
                        else VA = (long)((va.Next(20, 30) / 100d) * Inicial);
                        TB_ValorApostado.Visible = true;
                        TB_ValorApostado.Text = VA.ToString();
                        R = r.NextDouble();
                            if (R <= PG) S +=  (long)(VA * CA);
                            S = S - VA;
                            Grafica_Automatica.Series[0].Points.AddXY(i + 1, S);
                            nAux++;
                        }
                        TB_SaldoFinal.Text = string.Format("{0:C}",  S-Inicial+Inicial);
                        if (nAux!=n) MessageBox.Show(null, "No se ha podido apostar mas debido a que no dispuso de saldo suficuente, solo se simularon:  " +  nAux+" apuestas", "¡ATENCION!");
                        if (S > Inicial) MessageBox.Show(null, "Acaba de ganar " + string.Format("{0:C}", S - Inicial), "¡FELICIDADES!");
                        else if (S < Inicial) MessageBox.Show(null, "Acaba de perder " + string.Format("{0:C}", Inicial - S), "¡SUERTE PARA LA PROXIMA!");
                        else MessageBox.Show(null, "No ganó ni perdió nada ", "¡SIGUE INTENTANDO!");
                    }
                    else MessageBox.Show("Seleccione las estrategias y/o el numero de apuestas, y también el saldo inicial.");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error. " + er.Message);
                }
            }





        

    }
}
