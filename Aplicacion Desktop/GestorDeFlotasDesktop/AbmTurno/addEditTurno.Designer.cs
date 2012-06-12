namespace GestorDeFlotasDesktop.AbmTurno
{
    partial class addEditTurno
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
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblValorFicha = new System.Windows.Forms.Label();
            this.lblValorBandera = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.cmbHoraFin = new System.Windows.Forms.ComboBox();
            this.txtValorBandera = new System.Windows.Forms.TextBox();
            this.txtValorFicha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(192, 191);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::GestorDeFlotasDesktop.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(100, 191);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::GestorDeFlotasDesktop.Properties.Resources.disk;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(17, 191);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 33;
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
            this.lblTitulo.Location = new System.Drawing.Point(8, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(58, 26);
            this.lblTitulo.TabIndex = 43;
            this.lblTitulo.Text = "titulo";
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(16, 73);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(61, 13);
            this.lblHoraInicio.TabIndex = 44;
            this.lblHoraInicio.Text = "Hora Inicio:";
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(16, 100);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(50, 13);
            this.lblHoraFin.TabIndex = 45;
            this.lblHoraFin.Text = "Hora Fin:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(16, 47);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 46;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblValorFicha
            // 
            this.lblValorFicha.AutoSize = true;
            this.lblValorFicha.Location = new System.Drawing.Point(16, 153);
            this.lblValorFicha.Name = "lblValorFicha";
            this.lblValorFicha.Size = new System.Drawing.Size(63, 13);
            this.lblValorFicha.TabIndex = 47;
            this.lblValorFicha.Text = "Valor Ficha:";
            // 
            // lblValorBandera
            // 
            this.lblValorBandera.AutoSize = true;
            this.lblValorBandera.Location = new System.Drawing.Point(16, 127);
            this.lblValorBandera.Name = "lblValorBandera";
            this.lblValorBandera.Size = new System.Drawing.Size(77, 13);
            this.lblValorBandera.TabIndex = 48;
            this.lblValorBandera.Text = "Valor Bandera:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(88, 44);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(187, 20);
            this.txtDescripcion.TabIndex = 49;
            // 
            // cmbHoraInicio
            // 
            this.cmbHoraInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraInicio.FormattingEnabled = true;
            this.cmbHoraInicio.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbHoraInicio.Location = new System.Drawing.Point(88, 70);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(64, 21);
            this.cmbHoraInicio.TabIndex = 50;
            // 
            // cmbHoraFin
            // 
            this.cmbHoraFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoraFin.FormattingEnabled = true;
            this.cmbHoraFin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbHoraFin.Location = new System.Drawing.Point(88, 97);
            this.cmbHoraFin.Name = "cmbHoraFin";
            this.cmbHoraFin.Size = new System.Drawing.Size(64, 21);
            this.cmbHoraFin.TabIndex = 51;
            // 
            // txtValorBandera
            // 
            this.txtValorBandera.Location = new System.Drawing.Point(99, 124);
            this.txtValorBandera.Name = "txtValorBandera";
            this.txtValorBandera.Size = new System.Drawing.Size(87, 20);
            this.txtValorBandera.TabIndex = 52;
            this.txtValorBandera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorBandera_KeyPress);
            // 
            // txtValorFicha
            // 
            this.txtValorFicha.Location = new System.Drawing.Point(99, 150);
            this.txtValorFicha.Name = "txtValorFicha";
            this.txtValorFicha.Size = new System.Drawing.Size(87, 20);
            this.txtValorFicha.TabIndex = 53;
            this.txtValorFicha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorFicha_KeyPress);
            // 
            // addEditTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 227);
            this.Controls.Add(this.txtValorFicha);
            this.Controls.Add(this.txtValorBandera);
            this.Controls.Add(this.cmbHoraFin);
            this.Controls.Add(this.cmbHoraInicio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblValorBandera);
            this.Controls.Add(this.lblValorFicha);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblHoraFin);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "addEditTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addEditTurno";
            this.Load += new System.EventHandler(this.addEditTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblValorFicha;
        private System.Windows.Forms.Label lblValorBandera;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbHoraInicio;
        private System.Windows.Forms.ComboBox cmbHoraFin;
        private System.Windows.Forms.TextBox txtValorBandera;
        private System.Windows.Forms.TextBox txtValorFicha;
    }
}