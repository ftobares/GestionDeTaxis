namespace GestorDeFlotasDesktop.AbmReloj
{
    partial class AbmReloj
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
            unicaInst = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.txtNroSerieReloj = new System.Windows.Forms.TextBox();
            this.lblNroSerieReloj = new System.Windows.Forms.Label();
            this.dgRelojes = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNuevoReloj = new System.Windows.Forms.Button();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRelojes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(170, 22);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(71, 13);
            this.lblFechaDesde.TabIndex = 32;
            this.lblFechaDesde.Text = "Fecha Desde";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(285, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(139, 26);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "ABM Relojes";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(197, 47);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 27;
            this.lblModelo.Text = "Modelo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(245, 44);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.lblFechaDesde);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnFiltrar);
            this.groupBox2.Controls.Add(this.lblModelo);
            this.groupBox2.Controls.Add(this.txtModelo);
            this.groupBox2.Controls.Add(this.txtMarca);
            this.groupBox2.Controls.Add(this.lblMarca);
            this.groupBox2.Controls.Add(this.lblFechaHasta);
            this.groupBox2.Controls.Add(this.txtNroSerieReloj);
            this.groupBox2.Controls.Add(this.lblNroSerieReloj);
            this.groupBox2.Location = new System.Drawing.Point(7, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 73);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Búsqueda";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(59, 44);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 23;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(9, 47);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 22;
            this.lblMarca.Text = "Marca";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(365, 22);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(68, 13);
            this.lblFechaHasta.TabIndex = 17;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // txtNroSerieReloj
            // 
            this.txtNroSerieReloj.Location = new System.Drawing.Point(59, 19);
            this.txtNroSerieReloj.Name = "txtNroSerieReloj";
            this.txtNroSerieReloj.Size = new System.Drawing.Size(100, 20);
            this.txtNroSerieReloj.TabIndex = 15;
            // 
            // lblNroSerieReloj
            // 
            this.lblNroSerieReloj.AutoSize = true;
            this.lblNroSerieReloj.Location = new System.Drawing.Point(9, 19);
            this.lblNroSerieReloj.Name = "lblNroSerieReloj";
            this.lblNroSerieReloj.Size = new System.Drawing.Size(31, 13);
            this.lblNroSerieReloj.TabIndex = 13;
            this.lblNroSerieReloj.Text = "Reloj";
            // 
            // dgRelojes
            // 
            this.dgRelojes.AllowUserToAddRows = false;
            this.dgRelojes.AllowUserToDeleteRows = false;
            this.dgRelojes.AllowUserToResizeRows = false;
            this.dgRelojes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRelojes.Location = new System.Drawing.Point(7, 149);
            this.dgRelojes.MultiSelect = false;
            this.dgRelojes.Name = "dgRelojes";
            this.dgRelojes.ReadOnly = true;
            this.dgRelojes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRelojes.Size = new System.Drawing.Size(687, 255);
            this.dgRelojes.TabIndex = 16;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(4, 418);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro.TabIndex = 19;
            this.lblFiltro.Text = "label5";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(589, 44);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltrar.Location = new System.Drawing.Point(508, 44);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 29;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            // 
            // btnNuevoReloj
            // 
            this.btnNuevoReloj.Image = global::GestorDeFlotasDesktop.Properties.Resources.add;
            this.btnNuevoReloj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoReloj.Location = new System.Drawing.Point(14, 41);
            this.btnNuevoReloj.Name = "btnNuevoReloj";
            this.btnNuevoReloj.Size = new System.Drawing.Size(93, 23);
            this.btnNuevoReloj.TabIndex = 17;
            this.btnNuevoReloj.Text = "Nuevo Reloj";
            this.btnNuevoReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoReloj.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(245, 19);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 33;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(439, 19);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 34;
            // 
            // AbmReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 439);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgRelojes);
            this.Controls.Add(this.btnNuevoReloj);
            this.Controls.Add(this.lblFiltro);
            this.Name = "AbmReloj";
            this.Text = "ABM Relojes";
            this.Load += new System.EventHandler(this.AbmReloj_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRelojes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.TextBox txtNroSerieReloj;
        private System.Windows.Forms.Label lblNroSerieReloj;
        private System.Windows.Forms.DataGridView dgRelojes;
        private System.Windows.Forms.Button btnNuevoReloj;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
    }
}