namespace TrabajoFinal
{
    partial class Principal
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.GB_Manual = new System.Windows.Forms.GroupBox();
            this.LB_RPerdio = new System.Windows.Forms.Label();
            this.LB_RGano = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.B_LimpiarManual = new System.Windows.Forms.Button();
            this.Grafica_Manual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TB_SaldoApostar = new System.Windows.Forms.TextBox();
            this.LB_Resultado = new System.Windows.Forms.Label();
            this.LbSaldoApostar = new System.Windows.Forms.Label();
            this.LbPG = new System.Windows.Forms.Label();
            this.LbCuoApuesta = new System.Windows.Forms.Label();
            this.B_Apostar = new System.Windows.Forms.Button();
            this.TB_CuotaApuesta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_SaldoInicialManual = new System.Windows.Forms.TextBox();
            this.TB_ProbabilidadGanar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_SaldoActual = new System.Windows.Forms.TextBox();
            this.LbSaldoActual = new System.Windows.Forms.Label();
            this.GB_Automatica = new System.Windows.Forms.GroupBox();
            this.TB_Probabilidad = new System.Windows.Forms.TextBox();
            this.TB_ValorApostado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_SaldoFinal = new System.Windows.Forms.TextBox();
            this.CB_EstMedia = new System.Windows.Forms.CheckBox();
            this.Grafica_Automatica = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.LbSaldoInicial = new System.Windows.Forms.Label();
            this.TB_SaldoInicialAutomatico = new System.Windows.Forms.TextBox();
            this.TB_NroApuestas = new System.Windows.Forms.TextBox();
            this.CB_EstConservadora = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.B_Iniciar = new System.Windows.Forms.Button();
            this.LbProGanar = new System.Windows.Forms.Label();
            this.CB_EstDerrochadora = new System.Windows.Forms.CheckBox();
            this.CB_EstArriesgada = new System.Windows.Forms.CheckBox();
            this.CB_EstEconomizadora = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbVA = new System.Windows.Forms.Label();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.B_Manual = new System.Windows.Forms.Button();
            this.B_Automatica = new System.Windows.Forms.Button();
            this.GB_Manual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grafica_Manual)).BeginInit();
            this.GB_Automatica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grafica_Automatica)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_Manual
            // 
            this.GB_Manual.Controls.Add(this.LB_RPerdio);
            this.GB_Manual.Controls.Add(this.LB_RGano);
            this.GB_Manual.Controls.Add(this.label7);
            this.GB_Manual.Controls.Add(this.B_LimpiarManual);
            this.GB_Manual.Controls.Add(this.Grafica_Manual);
            this.GB_Manual.Controls.Add(this.TB_SaldoApostar);
            this.GB_Manual.Controls.Add(this.LB_Resultado);
            this.GB_Manual.Controls.Add(this.LbSaldoApostar);
            this.GB_Manual.Controls.Add(this.LbPG);
            this.GB_Manual.Controls.Add(this.LbCuoApuesta);
            this.GB_Manual.Controls.Add(this.B_Apostar);
            this.GB_Manual.Controls.Add(this.TB_CuotaApuesta);
            this.GB_Manual.Controls.Add(this.label5);
            this.GB_Manual.Controls.Add(this.TB_SaldoInicialManual);
            this.GB_Manual.Controls.Add(this.TB_ProbabilidadGanar);
            this.GB_Manual.Controls.Add(this.label4);
            this.GB_Manual.Controls.Add(this.TB_SaldoActual);
            this.GB_Manual.Controls.Add(this.LbSaldoActual);
            this.GB_Manual.Location = new System.Drawing.Point(27, 82);
            this.GB_Manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GB_Manual.Name = "GB_Manual";
            this.GB_Manual.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GB_Manual.Size = new System.Drawing.Size(659, 663);
            this.GB_Manual.TabIndex = 1;
            this.GB_Manual.TabStop = false;
            this.GB_Manual.Text = "Apuesta Manual";
            // 
            // LB_RPerdio
            // 
            this.LB_RPerdio.AutoSize = true;
            this.LB_RPerdio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_RPerdio.ForeColor = System.Drawing.Color.Red;
            this.LB_RPerdio.Location = new System.Drawing.Point(555, 183);
            this.LB_RPerdio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_RPerdio.Name = "LB_RPerdio";
            this.LB_RPerdio.Size = new System.Drawing.Size(19, 20);
            this.LB_RPerdio.TabIndex = 35;
            this.LB_RPerdio.Text = "0";
            // 
            // LB_RGano
            // 
            this.LB_RGano.AutoSize = true;
            this.LB_RGano.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_RGano.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LB_RGano.Location = new System.Drawing.Point(409, 183);
            this.LB_RGano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_RGano.Name = "LB_RGano";
            this.LB_RGano.Size = new System.Drawing.Size(19, 20);
            this.LB_RGano.TabIndex = 34;
            this.LB_RGano.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(461, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "%";
            // 
            // B_LimpiarManual
            // 
            this.B_LimpiarManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_LimpiarManual.Location = new System.Drawing.Point(559, 9);
            this.B_LimpiarManual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_LimpiarManual.Name = "B_LimpiarManual";
            this.B_LimpiarManual.Size = new System.Drawing.Size(100, 28);
            this.B_LimpiarManual.TabIndex = 32;
            this.B_LimpiarManual.Text = "Limpiar";
            this.B_LimpiarManual.UseVisualStyleBackColor = true;
            this.B_LimpiarManual.Click += new System.EventHandler(this.button1_Click);
            // 
            // Grafica_Manual
            // 
            chartArea1.AxisX.Title = "# Apuesta";
            chartArea1.AxisY.Title = "Saldo";
            chartArea1.Name = "ChartArea1";
            this.Grafica_Manual.ChartAreas.Add(chartArea1);
            this.Grafica_Manual.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.Grafica_Manual.Legends.Add(legend1);
            this.Grafica_Manual.Location = new System.Drawing.Point(3, 251);
            this.Grafica_Manual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grafica_Manual.Name = "Grafica_Manual";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "SaldoVsApuesta";
            this.Grafica_Manual.Series.Add(series1);
            this.Grafica_Manual.Size = new System.Drawing.Size(653, 410);
            this.Grafica_Manual.TabIndex = 31;
            this.Grafica_Manual.Text = "chart1";
            // 
            // TB_SaldoApostar
            // 
            this.TB_SaldoApostar.Location = new System.Drawing.Point(195, 76);
            this.TB_SaldoApostar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SaldoApostar.Name = "TB_SaldoApostar";
            this.TB_SaldoApostar.Size = new System.Drawing.Size(132, 22);
            this.TB_SaldoApostar.TabIndex = 17;
            this.TB_SaldoApostar.Enter += new System.EventHandler(this.TB_SaldoApostar_Enter);
            this.TB_SaldoApostar.Leave += new System.EventHandler(this.TB_SaldoApostar_Leave);
            // 
            // LB_Resultado
            // 
            this.LB_Resultado.AutoSize = true;
            this.LB_Resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Resultado.Location = new System.Drawing.Point(451, 150);
            this.LB_Resultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Resultado.Name = "LB_Resultado";
            this.LB_Resultado.Size = new System.Drawing.Size(93, 20);
            this.LB_Resultado.TabIndex = 25;
            this.LB_Resultado.Text = "Resultado";
            // 
            // LbSaldoApostar
            // 
            this.LbSaldoApostar.AutoSize = true;
            this.LbSaldoApostar.Location = new System.Drawing.Point(191, 52);
            this.LbSaldoApostar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSaldoApostar.Name = "LbSaldoApostar";
            this.LbSaldoApostar.Size = new System.Drawing.Size(97, 17);
            this.LbSaldoApostar.TabIndex = 27;
            this.LbSaldoApostar.Text = "Saldo Apostar";
            // 
            // LbPG
            // 
            this.LbPG.AutoSize = true;
            this.LbPG.Location = new System.Drawing.Point(157, 162);
            this.LbPG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPG.Name = "LbPG";
            this.LbPG.Size = new System.Drawing.Size(0, 17);
            this.LbPG.TabIndex = 27;
            // 
            // LbCuoApuesta
            // 
            this.LbCuoApuesta.AutoSize = true;
            this.LbCuoApuesta.Location = new System.Drawing.Point(37, 133);
            this.LbCuoApuesta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbCuoApuesta.Name = "LbCuoApuesta";
            this.LbCuoApuesta.Size = new System.Drawing.Size(120, 17);
            this.LbCuoApuesta.TabIndex = 29;
            this.LbCuoApuesta.Text = "Cuota de apuesta";
            // 
            // B_Apostar
            // 
            this.B_Apostar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Apostar.Location = new System.Drawing.Point(537, 71);
            this.B_Apostar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Apostar.Name = "B_Apostar";
            this.B_Apostar.Size = new System.Drawing.Size(100, 28);
            this.B_Apostar.TabIndex = 23;
            this.B_Apostar.Text = "Apostar";
            this.B_Apostar.UseVisualStyleBackColor = true;
            this.B_Apostar.Click += new System.EventHandler(this.B_Apostar_Click);
            // 
            // TB_CuotaApuesta
            // 
            this.TB_CuotaApuesta.Location = new System.Drawing.Point(37, 153);
            this.TB_CuotaApuesta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_CuotaApuesta.Name = "TB_CuotaApuesta";
            this.TB_CuotaApuesta.ReadOnly = true;
            this.TB_CuotaApuesta.Size = new System.Drawing.Size(132, 22);
            this.TB_CuotaApuesta.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Saldo Inicial";
            // 
            // TB_SaldoInicialManual
            // 
            this.TB_SaldoInicialManual.Location = new System.Drawing.Point(41, 75);
            this.TB_SaldoInicialManual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SaldoInicialManual.Name = "TB_SaldoInicialManual";
            this.TB_SaldoInicialManual.Size = new System.Drawing.Size(132, 22);
            this.TB_SaldoInicialManual.TabIndex = 16;
            this.TB_SaldoInicialManual.Enter += new System.EventHandler(this.TB_SaldoInicialManual_Enter);
            this.TB_SaldoInicialManual.Leave += new System.EventHandler(this.TB_SaldoInicialManual_Leave);
            // 
            // TB_ProbabilidadGanar
            // 
            this.TB_ProbabilidadGanar.Location = new System.Drawing.Point(349, 76);
            this.TB_ProbabilidadGanar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_ProbabilidadGanar.Name = "TB_ProbabilidadGanar";
            this.TB_ProbabilidadGanar.Size = new System.Drawing.Size(132, 22);
            this.TB_ProbabilidadGanar.TabIndex = 18;
            this.TB_ProbabilidadGanar.Enter += new System.EventHandler(this.TB_ProbabilidadGanar_Enter);
            this.TB_ProbabilidadGanar.Leave += new System.EventHandler(this.TB_ProbabilidadGanar_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Probabilidad de ganar";
            // 
            // TB_SaldoActual
            // 
            this.TB_SaldoActual.Location = new System.Drawing.Point(213, 153);
            this.TB_SaldoActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SaldoActual.Name = "TB_SaldoActual";
            this.TB_SaldoActual.ReadOnly = true;
            this.TB_SaldoActual.Size = new System.Drawing.Size(132, 22);
            this.TB_SaldoActual.TabIndex = 22;
            // 
            // LbSaldoActual
            // 
            this.LbSaldoActual.AutoSize = true;
            this.LbSaldoActual.Location = new System.Drawing.Point(211, 133);
            this.LbSaldoActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSaldoActual.Name = "LbSaldoActual";
            this.LbSaldoActual.Size = new System.Drawing.Size(87, 17);
            this.LbSaldoActual.TabIndex = 30;
            this.LbSaldoActual.Text = "Saldo Actual";
            // 
            // GB_Automatica
            // 
            this.GB_Automatica.Controls.Add(this.TB_Probabilidad);
            this.GB_Automatica.Controls.Add(this.TB_ValorApostado);
            this.GB_Automatica.Controls.Add(this.label8);
            this.GB_Automatica.Controls.Add(this.TB_SaldoFinal);
            this.GB_Automatica.Controls.Add(this.CB_EstMedia);
            this.GB_Automatica.Controls.Add(this.Grafica_Automatica);
            this.GB_Automatica.Controls.Add(this.label2);
            this.GB_Automatica.Controls.Add(this.LbSaldoInicial);
            this.GB_Automatica.Controls.Add(this.TB_SaldoInicialAutomatico);
            this.GB_Automatica.Controls.Add(this.TB_NroApuestas);
            this.GB_Automatica.Controls.Add(this.CB_EstConservadora);
            this.GB_Automatica.Controls.Add(this.label3);
            this.GB_Automatica.Controls.Add(this.B_Iniciar);
            this.GB_Automatica.Controls.Add(this.LbProGanar);
            this.GB_Automatica.Controls.Add(this.CB_EstDerrochadora);
            this.GB_Automatica.Controls.Add(this.CB_EstArriesgada);
            this.GB_Automatica.Controls.Add(this.CB_EstEconomizadora);
            this.GB_Automatica.Location = new System.Drawing.Point(701, 82);
            this.GB_Automatica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GB_Automatica.Name = "GB_Automatica";
            this.GB_Automatica.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GB_Automatica.Size = new System.Drawing.Size(659, 663);
            this.GB_Automatica.TabIndex = 2;
            this.GB_Automatica.TabStop = false;
            this.GB_Automatica.Text = "Apuesta Automatica";
            // 
            // TB_Probabilidad
            // 
            this.TB_Probabilidad.Location = new System.Drawing.Point(213, 97);
            this.TB_Probabilidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Probabilidad.Name = "TB_Probabilidad";
            this.TB_Probabilidad.ReadOnly = true;
            this.TB_Probabilidad.Size = new System.Drawing.Size(41, 22);
            this.TB_Probabilidad.TabIndex = 34;
            // 
            // TB_ValorApostado
            // 
            this.TB_ValorApostado.Location = new System.Drawing.Point(464, 101);
            this.TB_ValorApostado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_ValorApostado.Name = "TB_ValorApostado";
            this.TB_ValorApostado.ReadOnly = true;
            this.TB_ValorApostado.Size = new System.Drawing.Size(132, 22);
            this.TB_ValorApostado.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Saldo Final";
            // 
            // TB_SaldoFinal
            // 
            this.TB_SaldoFinal.Location = new System.Drawing.Point(519, 219);
            this.TB_SaldoFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SaldoFinal.Name = "TB_SaldoFinal";
            this.TB_SaldoFinal.ReadOnly = true;
            this.TB_SaldoFinal.Size = new System.Drawing.Size(132, 22);
            this.TB_SaldoFinal.TabIndex = 31;
            // 
            // CB_EstMedia
            // 
            this.CB_EstMedia.AutoSize = true;
            this.CB_EstMedia.Location = new System.Drawing.Point(67, 156);
            this.CB_EstMedia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_EstMedia.Name = "CB_EstMedia";
            this.CB_EstMedia.Size = new System.Drawing.Size(136, 21);
            this.CB_EstMedia.TabIndex = 30;
            this.CB_EstMedia.Text = "Estrategia Media";
            this.CB_EstMedia.UseVisualStyleBackColor = true;
            this.CB_EstMedia.CheckedChanged += new System.EventHandler(this.CB_EstArriesgada_CheckedChanged);
            // 
            // Grafica_Automatica
            // 
            chartArea2.AxisX.Title = "# Apuesta";
            chartArea2.AxisY.Title = "Saldo";
            chartArea2.Name = "ChartArea1";
            this.Grafica_Automatica.ChartAreas.Add(chartArea2);
            this.Grafica_Automatica.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.Grafica_Automatica.Legends.Add(legend2);
            this.Grafica_Automatica.Location = new System.Drawing.Point(3, 251);
            this.Grafica_Automatica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grafica_Automatica.Name = "Grafica_Automatica";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "SaldoVsApuesta";
            this.Grafica_Automatica.Series.Add(series2);
            this.Grafica_Automatica.Size = new System.Drawing.Size(653, 410);
            this.Grafica_Automatica.TabIndex = 29;
            this.Grafica_Automatica.Text = "Grafica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Saldo Inicial";
            // 
            // LbSaldoInicial
            // 
            this.LbSaldoInicial.AutoSize = true;
            this.LbSaldoInicial.Location = new System.Drawing.Point(213, 36);
            this.LbSaldoInicial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSaldoInicial.Name = "LbSaldoInicial";
            this.LbSaldoInicial.Size = new System.Drawing.Size(140, 17);
            this.LbSaldoInicial.TabIndex = 25;
            this.LbSaldoInicial.Text = "Numero de apuestas";
            // 
            // TB_SaldoInicialAutomatico
            // 
            this.TB_SaldoInicialAutomatico.Location = new System.Drawing.Point(73, 55);
            this.TB_SaldoInicialAutomatico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_SaldoInicialAutomatico.Name = "TB_SaldoInicialAutomatico";
            this.TB_SaldoInicialAutomatico.Size = new System.Drawing.Size(132, 22);
            this.TB_SaldoInicialAutomatico.TabIndex = 15;
            this.TB_SaldoInicialAutomatico.Enter += new System.EventHandler(this.TB_SaldoInicialAutomatico_Enter);
            this.TB_SaldoInicialAutomatico.Leave += new System.EventHandler(this.TB_SaldoInicialAutomatico_Leave);
            // 
            // TB_NroApuestas
            // 
            this.TB_NroApuestas.Location = new System.Drawing.Point(213, 55);
            this.TB_NroApuestas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_NroApuestas.Name = "TB_NroApuestas";
            this.TB_NroApuestas.Size = new System.Drawing.Size(132, 22);
            this.TB_NroApuestas.TabIndex = 16;
            this.TB_NroApuestas.Enter += new System.EventHandler(this.TB_NroApuestas_Enter);
            this.TB_NroApuestas.Leave += new System.EventHandler(this.TB_NroApuestas_Leave);
            // 
            // CB_EstConservadora
            // 
            this.CB_EstConservadora.AutoSize = true;
            this.CB_EstConservadora.Location = new System.Drawing.Point(67, 124);
            this.CB_EstConservadora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_EstConservadora.Name = "CB_EstConservadora";
            this.CB_EstConservadora.Size = new System.Drawing.Size(187, 21);
            this.CB_EstConservadora.TabIndex = 18;
            this.CB_EstConservadora.Text = "Estrategia Conservadora";
            this.CB_EstConservadora.UseVisualStyleBackColor = true;
            this.CB_EstConservadora.CheckedChanged += new System.EventHandler(this.CB_EstConservadora_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Valor apostado";
            // 
            // B_Iniciar
            // 
            this.B_Iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Iniciar.Location = new System.Drawing.Point(419, 50);
            this.B_Iniciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.B_Iniciar.Name = "B_Iniciar";
            this.B_Iniciar.Size = new System.Drawing.Size(100, 28);
            this.B_Iniciar.TabIndex = 23;
            this.B_Iniciar.Text = "Iniciar";
            this.B_Iniciar.UseVisualStyleBackColor = true;
            this.B_Iniciar.Click += new System.EventHandler(this.B_Iniciar_Click);
            // 
            // LbProGanar
            // 
            this.LbProGanar.AutoSize = true;
            this.LbProGanar.Location = new System.Drawing.Point(63, 101);
            this.LbProGanar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbProGanar.Name = "LbProGanar";
            this.LbProGanar.Size = new System.Drawing.Size(148, 17);
            this.LbProGanar.TabIndex = 17;
            this.LbProGanar.Text = "Probabilidad de ganar";
            // 
            // CB_EstDerrochadora
            // 
            this.CB_EstDerrochadora.AutoSize = true;
            this.CB_EstDerrochadora.Location = new System.Drawing.Point(344, 154);
            this.CB_EstDerrochadora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_EstDerrochadora.Name = "CB_EstDerrochadora";
            this.CB_EstDerrochadora.Size = new System.Drawing.Size(186, 21);
            this.CB_EstDerrochadora.TabIndex = 22;
            this.CB_EstDerrochadora.Text = "Estrategia Derrochadora";
            this.CB_EstDerrochadora.UseVisualStyleBackColor = true;
            this.CB_EstDerrochadora.CheckedChanged += new System.EventHandler(this.CB_EstDerrochadora_CheckedChanged);
            // 
            // CB_EstArriesgada
            // 
            this.CB_EstArriesgada.AutoSize = true;
            this.CB_EstArriesgada.Location = new System.Drawing.Point(67, 191);
            this.CB_EstArriesgada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_EstArriesgada.Name = "CB_EstArriesgada";
            this.CB_EstArriesgada.Size = new System.Drawing.Size(167, 21);
            this.CB_EstArriesgada.TabIndex = 19;
            this.CB_EstArriesgada.Text = "Estrategia Arriesgada";
            this.CB_EstArriesgada.UseVisualStyleBackColor = true;
            this.CB_EstArriesgada.CheckedChanged += new System.EventHandler(this.CB_EstMedia_CheckedChanged);
            // 
            // CB_EstEconomizadora
            // 
            this.CB_EstEconomizadora.AutoSize = true;
            this.CB_EstEconomizadora.Location = new System.Drawing.Point(344, 124);
            this.CB_EstEconomizadora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CB_EstEconomizadora.Name = "CB_EstEconomizadora";
            this.CB_EstEconomizadora.Size = new System.Drawing.Size(196, 21);
            this.CB_EstEconomizadora.TabIndex = 21;
            this.CB_EstEconomizadora.Text = "Estrategia Economizadora";
            this.CB_EstEconomizadora.UseVisualStyleBackColor = true;
            this.CB_EstEconomizadora.CheckedChanged += new System.EventHandler(this.CB_EstEconomizadora_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(605, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "APUESTAS.ES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LbVA
            // 
            this.LbVA.AutoSize = true;
            this.LbVA.Location = new System.Drawing.Point(952, 38);
            this.LbVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbVA.Name = "LbVA";
            this.LbVA.Size = new System.Drawing.Size(0, 17);
            this.LbVA.TabIndex = 26;
            // 
            // BtnVolver
            // 
            this.BtnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(1260, 17);
            this.BtnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(100, 28);
            this.BtnVolver.TabIndex = 24;
            this.BtnVolver.Text = "Salir";
            this.BtnVolver.UseVisualStyleBackColor = true;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Por favor Escoja un modo de Apuesta";
            // 
            // B_Manual
            // 
            this.B_Manual.Location = new System.Drawing.Point(52, 33);
            this.B_Manual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Manual.Name = "B_Manual";
            this.B_Manual.Size = new System.Drawing.Size(96, 26);
            this.B_Manual.TabIndex = 30;
            this.B_Manual.Text = "Manual";
            this.B_Manual.UseVisualStyleBackColor = true;
            this.B_Manual.Click += new System.EventHandler(this.B_Manual_Click);
            // 
            // B_Automatica
            // 
            this.B_Automatica.Location = new System.Drawing.Point(171, 33);
            this.B_Automatica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_Automatica.Name = "B_Automatica";
            this.B_Automatica.Size = new System.Drawing.Size(96, 26);
            this.B_Automatica.TabIndex = 31;
            this.B_Automatica.Text = "Automatica";
            this.B_Automatica.UseVisualStyleBackColor = true;
            this.B_Automatica.Click += new System.EventHandler(this.B_Automatica_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 775);
            this.ControlBox = false;
            this.Controls.Add(this.B_Automatica);
            this.Controls.Add(this.B_Manual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GB_Automatica);
            this.Controls.Add(this.GB_Manual);
            this.Controls.Add(this.LbVA);
            this.Controls.Add(this.BtnVolver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apuestas.es";
            this.GB_Manual.ResumeLayout(false);
            this.GB_Manual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grafica_Manual)).EndInit();
            this.GB_Automatica.ResumeLayout(false);
            this.GB_Automatica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grafica_Automatica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Manual;
        private System.Windows.Forms.GroupBox GB_Automatica;
        private System.Windows.Forms.TextBox TB_SaldoApostar;
        private System.Windows.Forms.Label LB_Resultado;
        private System.Windows.Forms.Label LbSaldoApostar;
        private System.Windows.Forms.Label LbPG;
        private System.Windows.Forms.Label LbCuoApuesta;
        private System.Windows.Forms.Button B_Apostar;
        private System.Windows.Forms.TextBox TB_CuotaApuesta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_SaldoInicialManual;
        private System.Windows.Forms.TextBox TB_ProbabilidadGanar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_SaldoActual;
        private System.Windows.Forms.Label LbSaldoActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbSaldoInicial;
        private System.Windows.Forms.TextBox TB_SaldoInicialAutomatico;
        private System.Windows.Forms.TextBox TB_NroApuestas;
        private System.Windows.Forms.CheckBox CB_EstConservadora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_Iniciar;
        private System.Windows.Forms.Label LbProGanar;
        private System.Windows.Forms.CheckBox CB_EstDerrochadora;
        private System.Windows.Forms.CheckBox CB_EstArriesgada;
        private System.Windows.Forms.CheckBox CB_EstEconomizadora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbVA;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart Grafica_Manual;
        private System.Windows.Forms.DataVisualization.Charting.Chart Grafica_Automatica;
        private System.Windows.Forms.CheckBox CB_EstMedia;
        private System.Windows.Forms.Button B_Manual;
        private System.Windows.Forms.Button B_Automatica;
        private System.Windows.Forms.Button B_LimpiarManual;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LB_RPerdio;
        private System.Windows.Forms.Label LB_RGano;
        private System.Windows.Forms.TextBox TB_Probabilidad;
        private System.Windows.Forms.TextBox TB_ValorApostado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_SaldoFinal;
    }
}

