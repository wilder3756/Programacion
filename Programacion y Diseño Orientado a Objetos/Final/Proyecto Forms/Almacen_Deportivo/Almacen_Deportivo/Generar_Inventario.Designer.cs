namespace Almacen_Deportivo
{
    partial class Generar_Inventario
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
            this.LB_Producto = new System.Windows.Forms.Label();
            this.CB_Producto = new System.Windows.Forms.ComboBox();
            this.LB_Cantidad = new System.Windows.Forms.Label();
            this.TB_Cantidad = new System.Windows.Forms.TextBox();
            this.B_Agregar = new System.Windows.Forms.Button();
            this.T_GInventario = new System.Windows.Forms.DataGridView();
            this.B_Regresar = new System.Windows.Forms.Button();
            this.B_GPedido = new System.Windows.Forms.Button();
            this.LB_Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.T_GInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_Producto
            // 
            this.LB_Producto.AutoSize = true;
            this.LB_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Producto.Location = new System.Drawing.Point(84, 121);
            this.LB_Producto.Name = "LB_Producto";
            this.LB_Producto.Size = new System.Drawing.Size(90, 25);
            this.LB_Producto.TabIndex = 0;
            this.LB_Producto.Text = "Producto";
            this.LB_Producto.Click += new System.EventHandler(this.LB_Producto_Click);
            // 
            // CB_Producto
            // 
            this.CB_Producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Producto.FormattingEnabled = true;
            this.CB_Producto.Location = new System.Drawing.Point(195, 117);
            this.CB_Producto.Name = "CB_Producto";
            this.CB_Producto.Size = new System.Drawing.Size(349, 28);
            this.CB_Producto.TabIndex = 1;
            this.CB_Producto.SelectedIndexChanged += new System.EventHandler(this.CB_Producto_SelectedIndexChanged);
            // 
            // LB_Cantidad
            // 
            this.LB_Cantidad.AutoSize = true;
            this.LB_Cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Cantidad.Location = new System.Drawing.Point(84, 164);
            this.LB_Cantidad.Name = "LB_Cantidad";
            this.LB_Cantidad.Size = new System.Drawing.Size(91, 25);
            this.LB_Cantidad.TabIndex = 3;
            this.LB_Cantidad.Text = "Cantidad";
            this.LB_Cantidad.Click += new System.EventHandler(this.LB_Cantidad_Click);
            // 
            // TB_Cantidad
            // 
            this.TB_Cantidad.Location = new System.Drawing.Point(185, 161);
            this.TB_Cantidad.Multiline = true;
            this.TB_Cantidad.Name = "TB_Cantidad";
            this.TB_Cantidad.Size = new System.Drawing.Size(76, 33);
            this.TB_Cantidad.TabIndex = 4;
            this.TB_Cantidad.TextChanged += new System.EventHandler(this.TB_Cantidad_TextChanged);
            // 
            // B_Agregar
            // 
            this.B_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Agregar.Location = new System.Drawing.Point(317, 161);
            this.B_Agregar.Name = "B_Agregar";
            this.B_Agregar.Size = new System.Drawing.Size(114, 33);
            this.B_Agregar.TabIndex = 5;
            this.B_Agregar.Text = "Agregar";
            this.B_Agregar.UseVisualStyleBackColor = true;
            this.B_Agregar.Click += new System.EventHandler(this.B_Agregar_Click);
            // 
            // T_GInventario
            // 
            this.T_GInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.T_GInventario.Location = new System.Drawing.Point(56, 238);
            this.T_GInventario.Name = "T_GInventario";
            this.T_GInventario.RowHeadersWidth = 51;
            this.T_GInventario.RowTemplate.Height = 24;
            this.T_GInventario.Size = new System.Drawing.Size(1022, 455);
            this.T_GInventario.TabIndex = 6;
            this.T_GInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.T_GInventario_CellContentClick);
            // 
            // B_Regresar
            // 
            this.B_Regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Regresar.Location = new System.Drawing.Point(998, 57);
            this.B_Regresar.Name = "B_Regresar";
            this.B_Regresar.Size = new System.Drawing.Size(140, 46);
            this.B_Regresar.TabIndex = 9;
            this.B_Regresar.Text = "Regresar\r\n";
            this.B_Regresar.UseVisualStyleBackColor = true;
            this.B_Regresar.Click += new System.EventHandler(this.B_Regresar_Click);
            // 
            // B_GPedido
            // 
            this.B_GPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_GPedido.Location = new System.Drawing.Point(1143, 626);
            this.B_GPedido.Name = "B_GPedido";
            this.B_GPedido.Size = new System.Drawing.Size(131, 67);
            this.B_GPedido.TabIndex = 10;
            this.B_GPedido.Text = "Generar \r\nPedido";
            this.B_GPedido.UseVisualStyleBackColor = true;
            this.B_GPedido.Click += new System.EventHandler(this.B_GPedido_Click);
            // 
            // LB_Titulo
            // 
            this.LB_Titulo.AutoSize = true;
            this.LB_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Titulo.Location = new System.Drawing.Point(230, 30);
            this.LB_Titulo.Name = "LB_Titulo";
            this.LB_Titulo.Size = new System.Drawing.Size(408, 39);
            this.LB_Titulo.TabIndex = 11;
            this.LB_Titulo.Text = "Generar Nuevo Inventario";
            this.LB_Titulo.Click += new System.EventHandler(this.LB_Titulo_Click);
            // 
            // Generar_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 712);
            this.ControlBox = false;
            this.Controls.Add(this.LB_Titulo);
            this.Controls.Add(this.B_GPedido);
            this.Controls.Add(this.B_Regresar);
            this.Controls.Add(this.T_GInventario);
            this.Controls.Add(this.B_Agregar);
            this.Controls.Add(this.TB_Cantidad);
            this.Controls.Add(this.LB_Cantidad);
            this.Controls.Add(this.CB_Producto);
            this.Controls.Add(this.LB_Producto);
            this.Name = "Generar_Inventario";
            this.Text = "57";
            ((System.ComponentModel.ISupportInitialize)(this.T_GInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Producto;
        private System.Windows.Forms.ComboBox CB_Producto;
        private System.Windows.Forms.Label LB_Cantidad;
        private System.Windows.Forms.TextBox TB_Cantidad;
        private System.Windows.Forms.Button B_Agregar;
        private System.Windows.Forms.DataGridView T_GInventario;
        private System.Windows.Forms.Button B_Regresar;
        private System.Windows.Forms.Button B_GPedido;
        private System.Windows.Forms.Label LB_Titulo;
    }
}