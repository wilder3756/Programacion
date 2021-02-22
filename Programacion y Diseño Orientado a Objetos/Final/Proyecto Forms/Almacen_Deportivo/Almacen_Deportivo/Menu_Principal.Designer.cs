namespace Almacen_Deportivo
{
    partial class Menu_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Principal));
            this.B_NCompra = new System.Windows.Forms.Button();
            this.B_NCliente = new System.Windows.Forms.Button();
            this.B_RInventario = new System.Windows.Forms.Button();
            this.B_GInventario = new System.Windows.Forms.Button();
            this.B_Regresar = new System.Windows.Forms.Button();
            this.PB_FAlmacen = new System.Windows.Forms.PictureBox();
            this.LB_Titulo = new System.Windows.Forms.Label();
            this.B_RVendedor = new System.Windows.Forms.Button();
            this.B_PagarCC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PB_FAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // B_NCompra
            // 
            this.B_NCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_NCompra.Location = new System.Drawing.Point(593, 131);
            this.B_NCompra.Margin = new System.Windows.Forms.Padding(4);
            this.B_NCompra.Name = "B_NCompra";
            this.B_NCompra.Size = new System.Drawing.Size(400, 45);
            this.B_NCompra.TabIndex = 0;
            this.B_NCompra.Text = "Nueva Compra";
            this.B_NCompra.UseVisualStyleBackColor = true;
            this.B_NCompra.Click += new System.EventHandler(this.B_NCompra_Click);
            // 
            // B_NCliente
            // 
            this.B_NCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_NCliente.Location = new System.Drawing.Point(593, 184);
            this.B_NCliente.Margin = new System.Windows.Forms.Padding(4);
            this.B_NCliente.Name = "B_NCliente";
            this.B_NCliente.Size = new System.Drawing.Size(400, 45);
            this.B_NCliente.TabIndex = 1;
            this.B_NCliente.Text = "Crear Nuevo Cliente";
            this.B_NCliente.UseVisualStyleBackColor = true;
            this.B_NCliente.Click += new System.EventHandler(this.B_NCliente_Click);
            // 
            // B_RInventario
            // 
            this.B_RInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_RInventario.Location = new System.Drawing.Point(593, 237);
            this.B_RInventario.Margin = new System.Windows.Forms.Padding(4);
            this.B_RInventario.Name = "B_RInventario";
            this.B_RInventario.Size = new System.Drawing.Size(400, 45);
            this.B_RInventario.TabIndex = 2;
            this.B_RInventario.Text = "Revisar Inventario";
            this.B_RInventario.UseVisualStyleBackColor = true;
            this.B_RInventario.Click += new System.EventHandler(this.B_RInventario_Click);
            // 
            // B_GInventario
            // 
            this.B_GInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_GInventario.Location = new System.Drawing.Point(593, 290);
            this.B_GInventario.Margin = new System.Windows.Forms.Padding(4);
            this.B_GInventario.Name = "B_GInventario";
            this.B_GInventario.Size = new System.Drawing.Size(400, 45);
            this.B_GInventario.TabIndex = 4;
            this.B_GInventario.Text = "Generar Inventario";
            this.B_GInventario.UseVisualStyleBackColor = true;
            this.B_GInventario.Click += new System.EventHandler(this.B_GInventario_Click);
            // 
            // B_Regresar
            // 
            this.B_Regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Regresar.Location = new System.Drawing.Point(887, 496);
            this.B_Regresar.Margin = new System.Windows.Forms.Padding(4);
            this.B_Regresar.Name = "B_Regresar";
            this.B_Regresar.Size = new System.Drawing.Size(167, 45);
            this.B_Regresar.TabIndex = 7;
            this.B_Regresar.Text = "Regresar";
            this.B_Regresar.UseVisualStyleBackColor = true;
            this.B_Regresar.Click += new System.EventHandler(this.B_Regresar_Click);
            // 
            // PB_FAlmacen
            // 
            this.PB_FAlmacen.Image = ((System.Drawing.Image)(resources.GetObject("PB_FAlmacen.Image")));
            this.PB_FAlmacen.Location = new System.Drawing.Point(40, 95);
            this.PB_FAlmacen.Name = "PB_FAlmacen";
            this.PB_FAlmacen.Size = new System.Drawing.Size(516, 435);
            this.PB_FAlmacen.TabIndex = 6;
            this.PB_FAlmacen.TabStop = false;
            // 
            // LB_Titulo
            // 
            this.LB_Titulo.AutoSize = true;
            this.LB_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Titulo.Location = new System.Drawing.Point(423, 19);
            this.LB_Titulo.Name = "LB_Titulo";
            this.LB_Titulo.Size = new System.Drawing.Size(243, 39);
            this.LB_Titulo.TabIndex = 7;
            this.LB_Titulo.Text = "Menu Principal";
            // 
            // B_RVendedor
            // 
            this.B_RVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_RVendedor.Location = new System.Drawing.Point(593, 396);
            this.B_RVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.B_RVendedor.Name = "B_RVendedor";
            this.B_RVendedor.Size = new System.Drawing.Size(400, 45);
            this.B_RVendedor.TabIndex = 6;
            this.B_RVendedor.Text = "Registrar Vendedor";
            this.B_RVendedor.UseVisualStyleBackColor = true;
            this.B_RVendedor.Click += new System.EventHandler(this.B_RVendedor_Click);
            // 
            // B_PagarCC
            // 
            this.B_PagarCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_PagarCC.Location = new System.Drawing.Point(593, 343);
            this.B_PagarCC.Margin = new System.Windows.Forms.Padding(4);
            this.B_PagarCC.Name = "B_PagarCC";
            this.B_PagarCC.Size = new System.Drawing.Size(400, 45);
            this.B_PagarCC.TabIndex = 5;
            this.B_PagarCC.Text = "Pagar Couta-Credito";
            this.B_PagarCC.UseVisualStyleBackColor = true;
            this.B_PagarCC.Click += new System.EventHandler(this.B_PagarCC_Click);
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.ControlBox = false;
            this.Controls.Add(this.B_PagarCC);
            this.Controls.Add(this.B_RVendedor);
            this.Controls.Add(this.LB_Titulo);
            this.Controls.Add(this.PB_FAlmacen);
            this.Controls.Add(this.B_Regresar);
            this.Controls.Add(this.B_GInventario);
            this.Controls.Add(this.B_RInventario);
            this.Controls.Add(this.B_NCliente);
            this.Controls.Add(this.B_NCompra);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu_Principal";
            this.Text = "Menu_Principal";
            ((System.ComponentModel.ISupportInitialize)(this.PB_FAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_NCompra;
        private System.Windows.Forms.Button B_NCliente;
        private System.Windows.Forms.Button B_RInventario;
        private System.Windows.Forms.Button B_GInventario;
        private System.Windows.Forms.Button B_Regresar;
        private System.Windows.Forms.PictureBox PB_FAlmacen;
        private System.Windows.Forms.Label LB_Titulo;
        private System.Windows.Forms.Button B_RVendedor;
        private System.Windows.Forms.Button B_PagarCC;
    }
}