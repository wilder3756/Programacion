namespace Almacen_Deportivo
{
    partial class PagarCuota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Usuario = new System.Windows.Forms.ComboBox();
            this.LB_Credito = new System.Windows.Forms.Label();
            this.CB_Credito = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_NroCuota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_FPago = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.TB_CRestantes = new System.Windows.Forms.TextBox();
            this.B_Regresar = new System.Windows.Forms.Button();
            this.B_Pagar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // CB_Usuario
            // 
            this.CB_Usuario.FormattingEnabled = true;
            this.CB_Usuario.Location = new System.Drawing.Point(167, 45);
            this.CB_Usuario.Name = "CB_Usuario";
            this.CB_Usuario.Size = new System.Drawing.Size(121, 24);
            this.CB_Usuario.TabIndex = 1;
            this.CB_Usuario.Text = "Seleccionar ";
            this.CB_Usuario.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // LB_Credito
            // 
            this.LB_Credito.AutoSize = true;
            this.LB_Credito.Location = new System.Drawing.Point(397, 51);
            this.LB_Credito.Name = "LB_Credito";
            this.LB_Credito.Size = new System.Drawing.Size(53, 17);
            this.LB_Credito.TabIndex = 2;
            this.LB_Credito.Text = "Credito";
            // 
            // CB_Credito
            // 
            this.CB_Credito.FormattingEnabled = true;
            this.CB_Credito.Location = new System.Drawing.Point(474, 45);
            this.CB_Credito.Name = "CB_Credito";
            this.CB_Credito.Size = new System.Drawing.Size(121, 24);
            this.CB_Credito.TabIndex = 3;
            this.CB_Credito.Text = "Seleccionar ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TB_CRestantes);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TB_FPago);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TB_NroCuota);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(63, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 254);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Informacion de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nro Cuota";
            // 
            // TB_NroCuota
            // 
            this.TB_NroCuota.Location = new System.Drawing.Point(155, 87);
            this.TB_NroCuota.Name = "TB_NroCuota";
            this.TB_NroCuota.Size = new System.Drawing.Size(100, 22);
            this.TB_NroCuota.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Fecha de Pago";
            // 
            // TB_FPago
            // 
            this.TB_FPago.Location = new System.Drawing.Point(478, 87);
            this.TB_FPago.Name = "TB_FPago";
            this.TB_FPago.Size = new System.Drawing.Size(100, 22);
            this.TB_FPago.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor a Pagar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cuotas Restantes";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(155, 170);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 7;
            // 
            // TB_CRestantes
            // 
            this.TB_CRestantes.Location = new System.Drawing.Point(478, 170);
            this.TB_CRestantes.Name = "TB_CRestantes";
            this.TB_CRestantes.Size = new System.Drawing.Size(100, 22);
            this.TB_CRestantes.TabIndex = 8;
            // 
            // B_Regresar
            // 
            this.B_Regresar.Location = new System.Drawing.Point(696, 12);
            this.B_Regresar.Name = "B_Regresar";
            this.B_Regresar.Size = new System.Drawing.Size(75, 23);
            this.B_Regresar.TabIndex = 5;
            this.B_Regresar.Text = "Regresar";
            this.B_Regresar.UseVisualStyleBackColor = true;
            this.B_Regresar.Click += new System.EventHandler(this.B_Regresar_Click);
            // 
            // B_Pagar
            // 
            this.B_Pagar.Location = new System.Drawing.Point(674, 384);
            this.B_Pagar.Name = "B_Pagar";
            this.B_Pagar.Size = new System.Drawing.Size(97, 34);
            this.B_Pagar.TabIndex = 6;
            this.B_Pagar.Text = "Pagar";
            this.B_Pagar.UseVisualStyleBackColor = true;
            // 
            // PagarCuota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.B_Pagar);
            this.Controls.Add(this.B_Regresar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CB_Credito);
            this.Controls.Add(this.LB_Credito);
            this.Controls.Add(this.CB_Usuario);
            this.Controls.Add(this.label1);
            this.Name = "PagarCuota";
            this.Text = "Xtream-Limit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Usuario;
        private System.Windows.Forms.Label LB_Credito;
        private System.Windows.Forms.ComboBox CB_Credito;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TB_CRestantes;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_FPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_NroCuota;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_Regresar;
        private System.Windows.Forms.Button B_Pagar;
    }
}