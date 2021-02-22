namespace Almacen_Deportivo
{
    partial class Revisar_Inventario
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
            this.T_Inventario = new System.Windows.Forms.DataGridView();
            this.B_Regresar = new System.Windows.Forms.Button();
            this.L_Titulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.T_Inventario)).BeginInit();
            this.SuspendLayout();
            // 
            // T_Inventario
            // 
            this.T_Inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.T_Inventario.Location = new System.Drawing.Point(29, 70);
            this.T_Inventario.Margin = new System.Windows.Forms.Padding(4);
            this.T_Inventario.Name = "T_Inventario";
            this.T_Inventario.Size = new System.Drawing.Size(1008, 420);
            this.T_Inventario.TabIndex = 0;
            // 
            // B_Regresar
            // 
            this.B_Regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Regresar.Location = new System.Drawing.Point(924, 498);
            this.B_Regresar.Margin = new System.Windows.Forms.Padding(4);
            this.B_Regresar.Name = "B_Regresar";
            this.B_Regresar.Size = new System.Drawing.Size(127, 41);
            this.B_Regresar.TabIndex = 2;
            this.B_Regresar.Text = "Regresar";
            this.B_Regresar.UseVisualStyleBackColor = true;
            this.B_Regresar.Click += new System.EventHandler(this.B_Regresar_Click);
            // 
            // L_Titulo
            // 
            this.L_Titulo.AutoSize = true;
            this.L_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Titulo.Location = new System.Drawing.Point(467, 9);
            this.L_Titulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Titulo.Name = "L_Titulo";
            this.L_Titulo.Size = new System.Drawing.Size(167, 39);
            this.L_Titulo.TabIndex = 4;
            this.L_Titulo.Text = "Inventario";
            // 
            // Revisar_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.ControlBox = false;
            this.Controls.Add(this.L_Titulo);
            this.Controls.Add(this.B_Regresar);
            this.Controls.Add(this.T_Inventario);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Revisar_Inventario";
            this.Text = "Revisar_Inventaio";
            ((System.ComponentModel.ISupportInitialize)(this.T_Inventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView T_Inventario;
        private System.Windows.Forms.Button B_Regresar;
        private System.Windows.Forms.Label L_Titulo;
    }
}