namespace GestorDeFlotasDesktop.AbmTurno
{
    partial class AbmTurno
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbHoraFin = new System.Windows.Forms.ComboBox();
            this.cmbHoraInicio = new System.Windows.Forms.ComboBox();
            this.lblMaxBandera = new System.Windows.Forms.Label();
            this.txtMaxBandera = new System.Windows.Forms.TextBox();
            this.txtMaxFicha = new System.Windows.Forms.TextBox();
            this.lblMaxFicha = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dgTurnos = new System.Windows.Forms.DataGridView();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.chkDeshabilitado = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).BeginInit();
            this.SuspendLayout();
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
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(290, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(132, 26);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "ABM Turnos";
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
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeshabilitado);
            this.groupBox2.Controls.Add(this.cmbHoraFin);
            this.groupBox2.Controls.Add(this.cmbHoraInicio);
            this.groupBox2.Controls.Add(this.lblMaxBandera);
            this.groupBox2.Controls.Add(this.txtMaxBandera);
            this.groupBox2.Controls.Add(this.txtMaxFicha);
            this.groupBox2.Controls.Add(this.lblMaxFicha);
            this.groupBox2.Controls.Add(this.txtDescripcion);
            this.groupBox2.Controls.Add(this.lblDescripcion);
            this.groupBox2.Controls.Add(this.lblHoraFin);
            this.groupBox2.Controls.Add(this.lblHoraInicio);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnFiltrar);
            this.groupBox2.Location = new System.Drawing.Point(6, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 99);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Búsqueda";
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
            "23",
            "24"});
            this.cmbHoraFin.Location = new System.Drawing.Point(255, 19);
            this.cmbHoraFin.Name = "cmbHoraFin";
            this.cmbHoraFin.Size = new System.Drawing.Size(111, 21);
            this.cmbHoraFin.TabIndex = 42;
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
            "23",
            "24"});
            this.cmbHoraInicio.Location = new System.Drawing.Point(73, 19);
            this.cmbHoraInicio.Name = "cmbHoraInicio";
            this.cmbHoraInicio.Size = new System.Drawing.Size(109, 21);
            this.cmbHoraInicio.TabIndex = 20;
            // 
            // lblMaxBandera
            // 
            this.lblMaxBandera.AutoSize = true;
            this.lblMaxBandera.Location = new System.Drawing.Point(252, 47);
            this.lblMaxBandera.Name = "lblMaxBandera";
            this.lblMaxBandera.Size = new System.Drawing.Size(114, 13);
            this.lblMaxBandera.TabIndex = 41;
            this.lblMaxBandera.Text = "Valor máximo bandera:";
            // 
            // txtMaxBandera
            // 
            this.txtMaxBandera.Location = new System.Drawing.Point(372, 44);
            this.txtMaxBandera.Name = "txtMaxBandera";
            this.txtMaxBandera.Size = new System.Drawing.Size(110, 20);
            this.txtMaxBandera.TabIndex = 40;
            // 
            // txtMaxFicha
            // 
            this.txtMaxFicha.Location = new System.Drawing.Point(128, 44);
            this.txtMaxFicha.Name = "txtMaxFicha";
            this.txtMaxFicha.Size = new System.Drawing.Size(110, 20);
            this.txtMaxFicha.TabIndex = 39;
            // 
            // lblMaxFicha
            // 
            this.lblMaxFicha.AutoSize = true;
            this.lblMaxFicha.Location = new System.Drawing.Point(6, 49);
            this.lblMaxFicha.Name = "lblMaxFicha";
            this.lblMaxFicha.Size = new System.Drawing.Size(116, 13);
            this.lblMaxFicha.TabIndex = 38;
            this.lblMaxFicha.Text = "Valor máximo de Ficha:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(459, 19);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(205, 20);
            this.txtDescripcion.TabIndex = 37;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(387, 22);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 36;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(202, 25);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(50, 13);
            this.lblHoraFin.TabIndex = 35;
            this.lblHoraFin.Text = "Hora Fin:";
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(6, 25);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(61, 13);
            this.lblHoraInicio.TabIndex = 32;
            this.lblHoraInicio.Text = "Hora Inicio:";
            // 
            // dgTurnos
            // 
            this.dgTurnos.AllowUserToAddRows = false;
            this.dgTurnos.AllowUserToDeleteRows = false;
            this.dgTurnos.AllowUserToResizeRows = false;
            this.dgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTurnos.Location = new System.Drawing.Point(6, 175);
            this.dgTurnos.MultiSelect = false;
            this.dgTurnos.Name = "dgTurnos";
            this.dgTurnos.ReadOnly = true;
            this.dgTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTurnos.Size = new System.Drawing.Size(687, 229);
            this.dgTurnos.TabIndex = 16;
            this.dgTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTurnos_CellContentClick);
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.Image = global::GestorDeFlotasDesktop.Properties.Resources.add;
            this.btnNuevoTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoTurno.Location = new System.Drawing.Point(13, 41);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(93, 23);
            this.btnNuevoTurno.TabIndex = 17;
            this.btnNuevoTurno.Text = "Nuevo Turno";
            this.btnNuevoTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoTurno.UseVisualStyleBackColor = true;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(3, 418);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro.TabIndex = 19;
            this.lblFiltro.Text = "label5";
            // 
            // chkDeshabilitado
            // 
            this.chkDeshabilitado.AutoSize = true;
            this.chkDeshabilitado.Location = new System.Drawing.Point(9, 76);
            this.chkDeshabilitado.Name = "chkDeshabilitado";
            this.chkDeshabilitado.Size = new System.Drawing.Size(90, 17);
            this.chkDeshabilitado.TabIndex = 35;
            this.chkDeshabilitado.Text = "Deshabilitado";
            this.chkDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // AbmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 441);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgTurnos);
            this.Controls.Add(this.btnNuevoTurno);
            this.Controls.Add(this.lblFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Turnos";
            this.Load += new System.EventHandler(this.AbmTurno_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DataGridView dgTurnos;
        private System.Windows.Forms.Button btnNuevoTurno;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMaxBandera;
        private System.Windows.Forms.TextBox txtMaxBandera;
        private System.Windows.Forms.TextBox txtMaxFicha;
        private System.Windows.Forms.Label lblMaxFicha;
        private System.Windows.Forms.ComboBox cmbHoraFin;
        private System.Windows.Forms.ComboBox cmbHoraInicio;
        private System.Windows.Forms.CheckBox chkDeshabilitado;
    }
}