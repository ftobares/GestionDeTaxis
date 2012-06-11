namespace GestorDeFlotasDesktop.Buscador
{
    partial class Buscador
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
            this.lblFiltro1 = new System.Windows.Forms.Label();
            this.lblFiltro2 = new System.Windows.Forms.Label();
            this.lblFiltroCmb = new System.Windows.Forms.Label();
            this.lblFiltro4 = new System.Windows.Forms.Label();
            this.txtFiltro1 = new System.Windows.Forms.TextBox();
            this.txtFiltro2 = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.txtFiltro4 = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.dgResultados = new System.Windows.Forms.DataGridView();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnResetFiltros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltro1
            // 
            this.lblFiltro1.AutoSize = true;
            this.lblFiltro1.Location = new System.Drawing.Point(12, 19);
            this.lblFiltro1.Name = "lblFiltro1";
            this.lblFiltro1.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro1.TabIndex = 0;
            this.lblFiltro1.Text = "label1";
            // 
            // lblFiltro2
            // 
            this.lblFiltro2.AutoSize = true;
            this.lblFiltro2.Location = new System.Drawing.Point(12, 45);
            this.lblFiltro2.Name = "lblFiltro2";
            this.lblFiltro2.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro2.TabIndex = 1;
            this.lblFiltro2.Text = "label2";
            // 
            // lblFiltroCmb
            // 
            this.lblFiltroCmb.AutoSize = true;
            this.lblFiltroCmb.Location = new System.Drawing.Point(276, 19);
            this.lblFiltroCmb.Name = "lblFiltroCmb";
            this.lblFiltroCmb.Size = new System.Drawing.Size(35, 13);
            this.lblFiltroCmb.TabIndex = 2;
            this.lblFiltroCmb.Text = "label3";
            // 
            // lblFiltro4
            // 
            this.lblFiltro4.AutoSize = true;
            this.lblFiltro4.Location = new System.Drawing.Point(276, 45);
            this.lblFiltro4.Name = "lblFiltro4";
            this.lblFiltro4.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro4.TabIndex = 3;
            this.lblFiltro4.Text = "label4";
            // 
            // txtFiltro1
            // 
            this.txtFiltro1.Location = new System.Drawing.Point(84, 16);
            this.txtFiltro1.Name = "txtFiltro1";
            this.txtFiltro1.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro1.TabIndex = 4;
            // 
            // txtFiltro2
            // 
            this.txtFiltro2.Location = new System.Drawing.Point(84, 42);
            this.txtFiltro2.Name = "txtFiltro2";
            this.txtFiltro2.Size = new System.Drawing.Size(100, 20);
            this.txtFiltro2.TabIndex = 5;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(317, 15);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltro.TabIndex = 6;
            // 
            // txtFiltro4
            // 
            this.txtFiltro4.Location = new System.Drawing.Point(317, 42);
            this.txtFiltro4.Name = "txtFiltro4";
            this.txtFiltro4.ReadOnly = true;
            this.txtFiltro4.Size = new System.Drawing.Size(121, 20);
            this.txtFiltro4.TabIndex = 7;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(444, 40);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(100, 23);
            this.btnSeleccionar.TabIndex = 8;
            this.btnSeleccionar.Text = "Seleccionar...";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // dgResultados
            // 
            this.dgResultados.AllowUserToAddRows = false;
            this.dgResultados.AllowUserToDeleteRows = false;
            this.dgResultados.AllowUserToResizeRows = false;
            this.dgResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultados.Location = new System.Drawing.Point(12, 112);
            this.dgResultados.MultiSelect = false;
            this.dgResultados.Name = "dgResultados";
            this.dgResultados.ReadOnly = true;
            this.dgResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultados.Size = new System.Drawing.Size(552, 232);
            this.dgResultados.TabIndex = 9;
            this.dgResultados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgResultados_CellMouseDoubleClick);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(12, 357);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro.TabIndex = 10;
            this.lblFiltro.Text = "label5";
            // 
            // btnResetFiltros
            // 
            this.btnResetFiltros.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnResetFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetFiltros.Location = new System.Drawing.Point(12, 83);
            this.btnResetFiltros.Name = "btnResetFiltros";
            this.btnResetFiltros.Size = new System.Drawing.Size(75, 23);
            this.btnResetFiltros.TabIndex = 11;
            this.btnResetFiltros.Text = "Limpiar";
            this.btnResetFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetFiltros.UseVisualStyleBackColor = true;
            this.btnResetFiltros.Click += new System.EventHandler(this.btnResetFiltros_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::GestorDeFlotasDesktop.Properties.Resources.find;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(93, 83);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::GestorDeFlotasDesktop.Properties.Resources.accept;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(174, 83);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Buscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 382);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnResetFiltros);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.dgResultados);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtFiltro4);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.txtFiltro2);
            this.Controls.Add(this.txtFiltro1);
            this.Controls.Add(this.lblFiltro4);
            this.Controls.Add(this.lblFiltroCmb);
            this.Controls.Add(this.lblFiltro2);
            this.Controls.Add(this.lblFiltro1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Buscador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador";
            this.Load += new System.EventHandler(this.Buscador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltro1;
        private System.Windows.Forms.Label lblFiltro2;
        private System.Windows.Forms.Label lblFiltroCmb;
        private System.Windows.Forms.Label lblFiltro4;
        private System.Windows.Forms.TextBox txtFiltro1;
        private System.Windows.Forms.TextBox txtFiltro2;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.TextBox txtFiltro4;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.DataGridView dgResultados;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnResetFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAceptar;
    }
}