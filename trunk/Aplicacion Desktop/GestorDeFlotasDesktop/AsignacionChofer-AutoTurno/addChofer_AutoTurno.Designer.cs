namespace GestorDeFlotasDesktop.AsignacionChofer_AutoTurno
{
    partial class addChofer_AutoTurno
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            unicaInst = null;
        }

        #region Código generado por el Diseñador de Windows Forms

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
            this.lblDniChofer = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.dtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnSeleccionarReloj = new System.Windows.Forms.Button();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textChofer = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLimpiar.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_white;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(159, 250);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 23);
            this.btnLimpiar.TabIndex = 9;
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
            this.btnCancelar.Location = new System.Drawing.Point(156, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 23);
            this.btnCancelar.TabIndex = 8;
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
            this.btnAceptar.Location = new System.Drawing.Point(73, 221);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 7;
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
            this.lblTitulo.Location = new System.Drawing.Point(33, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(254, 26);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Asignacion Chofer - Auto";
            // 
            // lblDniChofer
            // 
            this.lblDniChofer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDniChofer.AutoSize = true;
            this.lblDniChofer.ForeColor = System.Drawing.Color.Red;
            this.lblDniChofer.Location = new System.Drawing.Point(62, 77);
            this.lblDniChofer.Name = "lblDniChofer";
            this.lblDniChofer.Size = new System.Drawing.Size(40, 13);
            this.lblDniChofer.TabIndex = 33;
            this.lblDniChofer.Text = "Fecha:";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.Red;
            this.lblNombre.Location = new System.Drawing.Point(70, 110);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(32, 13);
            this.lblNombre.TabIndex = 34;
            this.lblNombre.Text = "Auto:";
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblApellido.AutoSize = true;
            this.lblApellido.ForeColor = System.Drawing.Color.Red;
            this.lblApellido.Location = new System.Drawing.Point(61, 141);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(41, 13);
            this.lblApellido.TabIndex = 37;
            this.lblApellido.Text = "Chofer:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.ForeColor = System.Drawing.Color.Red;
            this.lblDireccion.Location = new System.Drawing.Point(64, 168);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(38, 13);
            this.lblDireccion.TabIndex = 39;
            this.lblDireccion.Text = "Turno:";
            // 
            // dtpNacimiento
            // 
            this.dtpNacimiento.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.dtpNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNacimiento.Location = new System.Drawing.Point(108, 71);
            this.dtpNacimiento.MinDate = new System.DateTime(2012, 6, 13, 0, 0, 0, 0);
            this.dtpNacimiento.Name = "dtpNacimiento";
            this.dtpNacimiento.ShowUpDown = true;
            this.dtpNacimiento.Size = new System.Drawing.Size(121, 20);
            this.dtpNacimiento.TabIndex = 40;
            // 
            // btnSeleccionarReloj
            // 
            this.btnSeleccionarReloj.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.btnSeleccionarReloj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarReloj.Location = new System.Drawing.Point(214, 105);
            this.btnSeleccionarReloj.Name = "btnSeleccionarReloj";
            this.btnSeleccionarReloj.Size = new System.Drawing.Size(100, 23);
            this.btnSeleccionarReloj.TabIndex = 41;
            this.btnSeleccionarReloj.Text = "Seleccionar...";
            this.btnSeleccionarReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarReloj.UseVisualStyleBackColor = true;
            this.btnSeleccionarReloj.Click += new System.EventHandler(this.btnSeleccionarAuto_Click);
            // 
            // txtAuto
            // 
            this.txtAuto.Location = new System.Drawing.Point(108, 107);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.ReadOnly = true;
            this.txtAuto.Size = new System.Drawing.Size(100, 20);
            this.txtAuto.TabIndex = 42;
            this.txtAuto.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(214, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Seleccionar...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSeleccionarChofer_Click);
            // 
            // textChofer
            // 
            this.textChofer.Location = new System.Drawing.Point(108, 138);
            this.textChofer.Name = "textChofer";
            this.textChofer.ReadOnly = true;
            this.textChofer.Size = new System.Drawing.Size(100, 20);
            this.textChofer.TabIndex = 44;
            this.textChofer.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = global::GestorDeFlotasDesktop.Properties.Resources.page_find;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(214, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "Seleccionar...";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSeleccionarTurno_Click);
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(108, 165);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(100, 20);
            this.txtTurno.TabIndex = 46;
            this.txtTurno.TabStop = false;
            // 
            // addChofer_AutoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 291);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textChofer);
            this.Controls.Add(this.btnSeleccionarReloj);
            this.Controls.Add(this.txtAuto);
            this.Controls.Add(this.dtpNacimiento);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDniChofer);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "addChofer_AutoTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignacion Chofer - Auto";
            this.Load += new System.EventHandler(this.addEditChofer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDniChofer;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.DateTimePicker dtpNacimiento;
        private System.Windows.Forms.Button btnSeleccionarReloj;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textChofer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTurno;
    }
}