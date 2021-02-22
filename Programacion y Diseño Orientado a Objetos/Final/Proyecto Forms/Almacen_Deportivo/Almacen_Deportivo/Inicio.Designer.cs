namespace Almacen_Deportivo
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.TB_Usuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_Ingresar = new System.Windows.Forms.Button();
            this.LB_Usuario = new System.Windows.Forms.Label();
            this.LB_Contraseña = new System.Windows.Forms.Label();
            this.LB_Titulo = new System.Windows.Forms.Label();
            this.B_Salir = new System.Windows.Forms.Button();
            this.TB_Contraseña = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_Usuario
            // 
            this.TB_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Usuario.Location = new System.Drawing.Point(498, 204);
            this.TB_Usuario.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Usuario.Multiline = true;
            this.TB_Usuario.Name = "TB_Usuario";
            this.TB_Usuario.Size = new System.Drawing.Size(296, 45);
            this.TB_Usuario.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 390);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // B_Ingresar
            // 
            this.B_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Ingresar.Location = new System.Drawing.Point(743, 406);
            this.B_Ingresar.Margin = new System.Windows.Forms.Padding(4);
            this.B_Ingresar.Name = "B_Ingresar";
            this.B_Ingresar.Size = new System.Drawing.Size(136, 42);
            this.B_Ingresar.TabIndex = 3;
            this.B_Ingresar.Text = "Ingresar";
            this.B_Ingresar.UseVisualStyleBackColor = true;
            this.B_Ingresar.Click += new System.EventHandler(this.B_Ingresar_Click);
            // 
            // LB_Usuario
            // 
            this.LB_Usuario.AutoSize = true;
            this.LB_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Usuario.Location = new System.Drawing.Point(489, 171);
            this.LB_Usuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Usuario.Name = "LB_Usuario";
            this.LB_Usuario.Size = new System.Drawing.Size(96, 29);
            this.LB_Usuario.TabIndex = 4;
            this.LB_Usuario.Text = "Usuario";
            // 
            // LB_Contraseña
            // 
            this.LB_Contraseña.AutoSize = true;
            this.LB_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Contraseña.Location = new System.Drawing.Point(493, 281);
            this.LB_Contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Contraseña.Name = "LB_Contraseña";
            this.LB_Contraseña.Size = new System.Drawing.Size(136, 29);
            this.LB_Contraseña.TabIndex = 5;
            this.LB_Contraseña.Text = "Contraseña";
            // 
            // LB_Titulo
            // 
            this.LB_Titulo.AutoSize = true;
            this.LB_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Titulo.Location = new System.Drawing.Point(170, 9);
            this.LB_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Titulo.Name = "LB_Titulo";
            this.LB_Titulo.Size = new System.Drawing.Size(506, 39);
            this.LB_Titulo.TabIndex = 6;
            this.LB_Titulo.Text = "Almacen Deportivo Xtream-Limit";
            // 
            // B_Salir
            // 
            this.B_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Salir.Location = new System.Drawing.Point(798, 28);
            this.B_Salir.Margin = new System.Windows.Forms.Padding(4);
            this.B_Salir.Name = "B_Salir";
            this.B_Salir.Size = new System.Drawing.Size(81, 39);
            this.B_Salir.TabIndex = 7;
            this.B_Salir.Text = "Salir";
            this.B_Salir.UseVisualStyleBackColor = true;
            this.B_Salir.Click += new System.EventHandler(this.B_Salir_Click);
            // 
            // TB_Contraseña
            // 
            this.TB_Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Contraseña.Location = new System.Drawing.Point(498, 314);
            this.TB_Contraseña.Margin = new System.Windows.Forms.Padding(4);
            this.TB_Contraseña.Multiline = true;
            this.TB_Contraseña.Name = "TB_Contraseña";
            this.TB_Contraseña.PasswordChar = '*';
            this.TB_Contraseña.Size = new System.Drawing.Size(296, 44);
            this.TB_Contraseña.TabIndex = 1;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 484);
            this.ControlBox = false;
            this.Controls.Add(this.B_Salir);
            this.Controls.Add(this.LB_Titulo);
            this.Controls.Add(this.LB_Contraseña);
            this.Controls.Add(this.LB_Usuario);
            this.Controls.Add(this.B_Ingresar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TB_Contraseña);
            this.Controls.Add(this.TB_Usuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inicio";
            this.Text = "Xtream-Limit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Usuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_Ingresar;
        private System.Windows.Forms.Label LB_Usuario;
        private System.Windows.Forms.Label LB_Contraseña;
        private System.Windows.Forms.Label LB_Titulo;
        private System.Windows.Forms.Button B_Salir;
        private System.Windows.Forms.TextBox TB_Contraseña;
    }
}

