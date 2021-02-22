namespace Almacen_Deportivo
{
    partial class Facturar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_NFactura = new System.Windows.Forms.TextBox();
            this.TB_Vendedor = new System.Windows.Forms.TextBox();
            this.TB_FCompra = new System.Windows.Forms.TextBox();
            this.T_Factura = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TB_VFinal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_VIVA = new System.Windows.Forms.TextBox();
            this.TB_Subtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_Credito = new System.Windows.Forms.Button();
            this.B_TCredito = new System.Windows.Forms.Button();
            this.B_TDebito = new System.Windows.Forms.Button();
            this.B_Efectivo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.B_Regresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.T_Factura)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Factura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Compra";
            // 
            // TB_NFactura
            // 
            this.TB_NFactura.Location = new System.Drawing.Point(215, 35);
            this.TB_NFactura.Name = "TB_NFactura";
            this.TB_NFactura.ReadOnly = true;
            this.TB_NFactura.Size = new System.Drawing.Size(100, 22);
            this.TB_NFactura.TabIndex = 3;
            // 
            // TB_Vendedor
            // 
            this.TB_Vendedor.Location = new System.Drawing.Point(215, 66);
            this.TB_Vendedor.Name = "TB_Vendedor";
            this.TB_Vendedor.ReadOnly = true;
            this.TB_Vendedor.Size = new System.Drawing.Size(143, 22);
            this.TB_Vendedor.TabIndex = 4;
            // 
            // TB_FCompra
            // 
            this.TB_FCompra.Location = new System.Drawing.Point(215, 105);
            this.TB_FCompra.Name = "TB_FCompra";
            this.TB_FCompra.ReadOnly = true;
            this.TB_FCompra.Size = new System.Drawing.Size(226, 22);
            this.TB_FCompra.TabIndex = 5;
            // 
            // T_Factura
            // 
            this.T_Factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.T_Factura.Location = new System.Drawing.Point(32, 151);
            this.T_Factura.Name = "T_Factura";
            this.T_Factura.RowTemplate.Height = 24;
            this.T_Factura.Size = new System.Drawing.Size(646, 159);
            this.T_Factura.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TB_VFinal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TB_VIVA);
            this.panel1.Controls.Add(this.TB_Subtotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(32, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 114);
            this.panel1.TabIndex = 9;
            // 
            // TB_VFinal
            // 
            this.TB_VFinal.Location = new System.Drawing.Point(470, 13);
            this.TB_VFinal.Name = "TB_VFinal";
            this.TB_VFinal.ReadOnly = true;
            this.TB_VFinal.Size = new System.Drawing.Size(100, 22);
            this.TB_VFinal.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Valor Final";
            // 
            // TB_VIVA
            // 
            this.TB_VIVA.Location = new System.Drawing.Point(131, 69);
            this.TB_VIVA.Name = "TB_VIVA";
            this.TB_VIVA.ReadOnly = true;
            this.TB_VIVA.Size = new System.Drawing.Size(100, 22);
            this.TB_VIVA.TabIndex = 3;
            // 
            // TB_Subtotal
            // 
            this.TB_Subtotal.Location = new System.Drawing.Point(131, 11);
            this.TB_Subtotal.Name = "TB_Subtotal";
            this.TB_Subtotal.ReadOnly = true;
            this.TB_Subtotal.Size = new System.Drawing.Size(100, 22);
            this.TB_Subtotal.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Valor IVA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Subtotal";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.B_Credito);
            this.panel2.Controls.Add(this.B_TCredito);
            this.panel2.Controls.Add(this.B_TDebito);
            this.panel2.Controls.Add(this.B_Efectivo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(32, 474);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(646, 190);
            this.panel2.TabIndex = 10;
            // 
            // B_Credito
            // 
            this.B_Credito.Location = new System.Drawing.Point(131, 143);
            this.B_Credito.Name = "B_Credito";
            this.B_Credito.Size = new System.Drawing.Size(382, 33);
            this.B_Credito.TabIndex = 4;
            this.B_Credito.Text = "Credito";
            this.B_Credito.UseVisualStyleBackColor = true;
            this.B_Credito.Click += new System.EventHandler(this.B_Credito_Click);
            // 
            // B_TCredito
            // 
            this.B_TCredito.Location = new System.Drawing.Point(483, 43);
            this.B_TCredito.Name = "B_TCredito";
            this.B_TCredito.Size = new System.Drawing.Size(132, 60);
            this.B_TCredito.TabIndex = 3;
            this.B_TCredito.Text = "Tarjeta Credito";
            this.B_TCredito.UseVisualStyleBackColor = true;
            this.B_TCredito.Click += new System.EventHandler(this.B_TCredito_Click);
            // 
            // B_TDebito
            // 
            this.B_TDebito.Location = new System.Drawing.Point(278, 43);
            this.B_TDebito.Name = "B_TDebito";
            this.B_TDebito.Size = new System.Drawing.Size(131, 60);
            this.B_TDebito.TabIndex = 2;
            this.B_TDebito.Text = "Tarjeta Debito";
            this.B_TDebito.UseVisualStyleBackColor = true;
            this.B_TDebito.Click += new System.EventHandler(this.B_TDebito_Click);
            // 
            // B_Efectivo
            // 
            this.B_Efectivo.Location = new System.Drawing.Point(75, 43);
            this.B_Efectivo.Name = "B_Efectivo";
            this.B_Efectivo.Size = new System.Drawing.Size(119, 60);
            this.B_Efectivo.TabIndex = 1;
            this.B_Efectivo.Text = "Efectivo";
            this.B_Efectivo.UseVisualStyleBackColor = true;
            this.B_Efectivo.Click += new System.EventHandler(this.B_Efectivo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Metodo de Pago";
            // 
            // B_Regresar
            // 
            this.B_Regresar.Location = new System.Drawing.Point(606, 12);
            this.B_Regresar.Name = "B_Regresar";
            this.B_Regresar.Size = new System.Drawing.Size(101, 43);
            this.B_Regresar.TabIndex = 11;
            this.B_Regresar.Text = "Regresar";
            this.B_Regresar.UseVisualStyleBackColor = true;
            this.B_Regresar.Click += new System.EventHandler(this.B_Regresar_Click_1);
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 722);
            this.ControlBox = false;
            this.Controls.Add(this.B_Regresar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.T_Factura);
            this.Controls.Add(this.TB_FCompra);
            this.Controls.Add(this.TB_Vendedor);
            this.Controls.Add(this.TB_NFactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Facturar";
            this.Text = "Xtream-Limit";
            ((System.ComponentModel.ISupportInitialize)(this.T_Factura)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_NFactura;
        private System.Windows.Forms.TextBox TB_Vendedor;
        private System.Windows.Forms.TextBox TB_FCompra;
        private System.Windows.Forms.DataGridView T_Factura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TB_VFinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_VIVA;
        private System.Windows.Forms.TextBox TB_Subtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Credito;
        private System.Windows.Forms.Button B_TCredito;
        private System.Windows.Forms.Button B_TDebito;
        private System.Windows.Forms.Button B_Efectivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button B_Regresar;
    }
}