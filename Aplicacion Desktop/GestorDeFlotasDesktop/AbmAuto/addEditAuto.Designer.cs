namespace GestorDeFlotasDesktop.AbmAuto
{
    partial class addEditAuto
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
            this.lblReloj = new System.Windows.Forms.Label();
            this.txtRodado = new System.Windows.Forms.TextBox();
            this.lblRodado = new System.Windows.Forms.Label();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.mtxtPatente = new System.Windows.Forms.MaskedTextBox();
            this.llblPatente = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtReloj = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSeleccionarReloj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReloj
            // 
            this.lblReloj.AutoSize = true;
            this.lblReloj.ForeColor = System.Drawing.Color.Red;
            this.lblReloj.Location = new System.Drawing.Point(51, 194);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(34, 13);
            this.lblReloj.TabIndex = 24;
            this.lblReloj.Text = "Reloj:";
            // 
            // txtRodado
            // 
            this.txtRodado.Location = new System.Drawing.Point(104, 165);
            this.txtRodado.MaxLength = 10;
            this.txtRodado.Name = "txtRodado";
            this.txtRodado.Size = new System.Drawing.Size(100, 20);
            this.txtRodado.TabIndex = 4;
            // 
            // lblRodado
            // 
            this.lblRodado.AutoSize = true;
            this.lblRodado.ForeColor = System.Drawing.Color.Red;
            this.lblRodado.Location = new System.Drawing.Point(51, 168);
            this.lblRodado.Name = "lblRodado";
            this.lblRodado.Size = new System.Drawing.Size(48, 13);
            this.lblRodado.TabIndex = 22;
            this.lblRodado.Text = "Rodado:";
            // 
            // txtLicencia
            // 
            this.txtLicencia.Location = new System.Drawing.Point(104, 139);
            this.txtLicencia.MaxLength = 26;
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(100, 20);
            this.txtLicencia.TabIndex = 3;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.ForeColor = System.Drawing.Color.Red;
            this.lblLicencia.Location = new System.Drawing.Point(51, 142);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(50, 13);
            this.lblLicencia.TabIndex = 20;
            this.lblLicencia.Text = "Licencia:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(104, 113);
            this.txtModelo.MaxLength = 255;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 2;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.ForeColor = System.Drawing.Color.Red;
            this.lblModelo.Location = new System.Drawing.Point(51, 116);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(45, 13);
            this.lblModelo.TabIndex = 18;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.ForeColor = System.Drawing.Color.Red;
            this.lblMarca.Location = new System.Drawing.Point(51, 89);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 17;
            this.lblMarca.Text = "Marca:";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(104, 86);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(121, 21);
            this.cmbMarca.TabIndex = 1;
            // 
            // mtxtPatente
            // 
            this.mtxtPatente.Location = new System.Drawing.Point(104, 60);
            this.mtxtPatente.Mask = "AAAAAA";
            this.mtxtPatente.Name = "mtxtPatente";
            this.mtxtPatente.ResetOnSpace = false;
            this.mtxtPatente.Size = new System.Drawing.Size(66, 20);
            this.mtxtPatente.TabIndex = 0;
            // 
            // llblPatente
            // 
            this.llblPatente.AutoSize = true;
            this.llblPatente.ForeColor = System.Drawing.Color.Red;
            this.llblPatente.Location = new System.Drawing.Point(51, 63);
            this.llblPatente.Name = "llblPatente";
            this.llblPatente.Size = new System.Drawing.Size(47, 13);
            this.llblPatente.TabIndex = 14;
            this.llblPatente.Text = "Patente:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(43, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(58, 26);
            this.lblTitulo.TabIndex = 26;
            this.lblTitulo.Text = "titulo";
            // 
            // txtReloj
            // 
            this.txtReloj.Location = new System.Drawing.Point(104, 191);
            this.txtReloj.Name = "txtReloj";
            this.txtReloj.ReadOnly = true;
            this.txtReloj.Size = new System.Drawing.Size(100, 20);
            this.txtReloj.TabIndex = 20;
            this.txtReloj.TabStop = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(203, 229);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::GestorDeFlotasDesktop.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(111, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::GestorDeFlotasDesktop.Properties.Resources.disk;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(28, 229);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSeleccionarReloj
            // 
            this.btnSeleccionarReloj.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.btnSeleccionarReloj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarReloj.Location = new System.Drawing.Point(210, 189);
            this.btnSeleccionarReloj.Name = "btnSeleccionarReloj";
            this.btnSeleccionarReloj.Size = new System.Drawing.Size(100, 23);
            this.btnSeleccionarReloj.TabIndex = 5;
            this.btnSeleccionarReloj.Text = "Seleccionar...";
            this.btnSeleccionarReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarReloj.UseVisualStyleBackColor = true;
            this.btnSeleccionarReloj.Click += new System.EventHandler(this.btnSeleccionarReloj_Click);
            // 
            // addEditAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 268);
            this.Controls.Add(this.btnSeleccionarReloj);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtReloj);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.txtRodado);
            this.Controls.Add(this.lblRodado);
            this.Controls.Add(this.txtLicencia);
            this.Controls.Add(this.lblLicencia);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.mtxtPatente);
            this.Controls.Add(this.llblPatente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addEditAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addEditAuto";
            this.Load += new System.EventHandler(this.addEditAuto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.TextBox txtRodado;
        private System.Windows.Forms.Label lblRodado;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.MaskedTextBox mtxtPatente;
        private System.Windows.Forms.Label llblPatente;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtReloj;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSeleccionarReloj;
    }
}