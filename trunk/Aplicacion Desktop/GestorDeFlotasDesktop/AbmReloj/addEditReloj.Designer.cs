namespace GestorDeFlotasDesktop.AbmReloj
{
    partial class addEditReloj
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNroSerieReloj = new System.Windows.Forms.Label();
            this.lblFechaVersion = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtNroSerieReloj = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.dtpVersion = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(198, 176);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::GestorDeFlotasDesktop.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(106, 176);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::GestorDeFlotasDesktop.Properties.Resources.disk;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(23, 176);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(58, 26);
            this.lblTitulo.TabIndex = 43;
            this.lblTitulo.Text = "titulo";
            // 
            // lblNroSerieReloj
            // 
            this.lblNroSerieReloj.AutoSize = true;
            this.lblNroSerieReloj.ForeColor = System.Drawing.Color.Red;
            this.lblNroSerieReloj.Location = new System.Drawing.Point(40, 63);
            this.lblNroSerieReloj.Name = "lblNroSerieReloj";
            this.lblNroSerieReloj.Size = new System.Drawing.Size(34, 13);
            this.lblNroSerieReloj.TabIndex = 42;
            this.lblNroSerieReloj.Text = "Reloj:";
            // 
            // lblFechaVersion
            // 
            this.lblFechaVersion.AutoSize = true;
            this.lblFechaVersion.ForeColor = System.Drawing.Color.Red;
            this.lblFechaVersion.Location = new System.Drawing.Point(40, 142);
            this.lblFechaVersion.Name = "lblFechaVersion";
            this.lblFechaVersion.Size = new System.Drawing.Size(78, 13);
            this.lblFechaVersion.TabIndex = 40;
            this.lblFechaVersion.Text = "Fecha Versión:";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(124, 113);
            this.txtModelo.MaxLength = 255;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 2;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.ForeColor = System.Drawing.Color.Red;
            this.lblModelo.Location = new System.Drawing.Point(40, 116);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(45, 13);
            this.lblModelo.TabIndex = 38;
            this.lblModelo.Text = "Modelo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.ForeColor = System.Drawing.Color.Red;
            this.lblMarca.Location = new System.Drawing.Point(40, 89);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 37;
            this.lblMarca.Text = "Marca:";
            // 
            // txtNroSerieReloj
            // 
            this.txtNroSerieReloj.Location = new System.Drawing.Point(124, 60);
            this.txtNroSerieReloj.MaxLength = 15;
            this.txtNroSerieReloj.Name = "txtNroSerieReloj";
            this.txtNroSerieReloj.Size = new System.Drawing.Size(100, 20);
            this.txtNroSerieReloj.TabIndex = 0;
            this.txtNroSerieReloj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroSerieReloj_KeyPress);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(124, 86);
            this.txtMarca.MaxLength = 255;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 1;
            // 
            // dtpVersion
            // 
            this.dtpVersion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVersion.Location = new System.Drawing.Point(124, 142);
            this.dtpVersion.Name = "dtpVersion";
            this.dtpVersion.Size = new System.Drawing.Size(98, 20);
            this.dtpVersion.TabIndex = 3;
            // 
            // addEditReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 211);
            this.Controls.Add(this.dtpVersion);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtNroSerieReloj);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNroSerieReloj);
            this.Controls.Add(this.lblFechaVersion);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblMarca);
            this.Name = "addEditReloj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addEditReloj";
            this.Load += new System.EventHandler(this.addEditReloj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNroSerieReloj;
        private System.Windows.Forms.Label lblFechaVersion;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtNroSerieReloj;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.DateTimePicker dtpVersion;
    }
}