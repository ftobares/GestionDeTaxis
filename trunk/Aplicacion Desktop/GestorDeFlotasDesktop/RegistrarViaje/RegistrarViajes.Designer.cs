namespace GestorDeFlotasDesktop.RegistrarViaje
{
    partial class RegistrarViajes
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
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.lblViaje = new System.Windows.Forms.Label();
            this.cmbViaje = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtHora = new System.Windows.Forms.DateTimePicker();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.txtFichas = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChofer
            // 
            this.txtChofer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtChofer.Location = new System.Drawing.Point(131, 84);
            this.txtChofer.MaxLength = 255;
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(100, 20);
            this.txtChofer.TabIndex = 19;
            // 
            // lblViaje
            // 
            this.lblViaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblViaje.AutoSize = true;
            this.lblViaje.ForeColor = System.Drawing.Color.Red;
            this.lblViaje.Location = new System.Drawing.Point(44, 60);
            this.lblViaje.Name = "lblViaje";
            this.lblViaje.Size = new System.Drawing.Size(72, 13);
            this.lblViaje.TabIndex = 20;
            this.lblViaje.Text = "Tipo de Viaje:";
            // 
            // cmbViaje
            // 
            this.cmbViaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbViaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViaje.FormattingEnabled = true;
            this.cmbViaje.Items.AddRange(new object[] {
            "calle",
            "registrado"});
            this.cmbViaje.Location = new System.Drawing.Point(131, 57);
            this.cmbViaje.Name = "cmbViaje";
            this.cmbViaje.Size = new System.Drawing.Size(121, 21);
            this.cmbViaje.TabIndex = 21;
            this.cmbViaje.SelectedIndexChanged += new System.EventHandler(this.cmbViaje_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(44, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Chofer :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(44, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Turno:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(44, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(44, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cant. de Fichas:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(219, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Hora:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(44, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Cliente:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFecha.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(131, 162);
            this.dtpFecha.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(82, 20);
            this.dtpFecha.TabIndex = 41;
            this.dtpFecha.Value = new System.DateTime(2012, 7, 1, 23, 30, 7, 0);
            // 
            // dtHora
            // 
            this.dtHora.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtHora.CustomFormat = "hh\':\'mm tt";
            this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtHora.Location = new System.Drawing.Point(258, 162);
            this.dtHora.MinDate = new System.DateTime(2012, 6, 13, 0, 0, 0, 0);
            this.dtHora.Name = "dtHora";
            this.dtHora.ShowUpDown = true;
            this.dtHora.Size = new System.Drawing.Size(82, 20);
            this.dtHora.TabIndex = 42;
            this.dtHora.Value = new System.DateTime(2012, 6, 13, 0, 0, 0, 0);
            // 
            // txtTurno
            // 
            this.txtTurno.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTurno.Location = new System.Drawing.Point(131, 110);
            this.txtTurno.MaxLength = 255;
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(100, 20);
            this.txtTurno.TabIndex = 43;
            // 
            // txtFichas
            // 
            this.txtFichas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFichas.Location = new System.Drawing.Point(131, 136);
            this.txtFichas.MaxLength = 255;
            this.txtFichas.Name = "txtFichas";
            this.txtFichas.Size = new System.Drawing.Size(100, 20);
            this.txtFichas.TabIndex = 44;
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCliente.Location = new System.Drawing.Point(131, 188);
            this.txtCliente.MaxLength = 255;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 45;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(126, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(105, 26);
            this.lblTitulo.TabIndex = 49;
            this.lblTitulo.Text = "Alta Viaje";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(222, 229);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Image = global::GestorDeFlotasDesktop.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(130, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAceptar.Image = global::GestorDeFlotasDesktop.Properties.Resources.disk;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(47, 229);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // RegistrarViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 273);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtFichas);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.dtHora);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbViaje);
            this.Controls.Add(this.txtChofer);
            this.Controls.Add(this.lblViaje);
            this.Name = "RegistrarViajes";
            this.Text = "RegistrarViajes";
            this.Load += new System.EventHandler(this.RegistrarViajes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label lblViaje;
        private System.Windows.Forms.ComboBox cmbViaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.TextBox txtFichas;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.DateTimePicker dtHora;


    }
}