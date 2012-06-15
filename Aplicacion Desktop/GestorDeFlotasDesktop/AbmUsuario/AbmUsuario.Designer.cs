namespace GestorDeFlotasDesktop.AbmUsuario
{
    partial class AbmUsuario
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
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDeshabilitado = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtUsuarioID = new System.Windows.Forms.TextBox();
            this.lblUsuarioId = new System.Windows.Forms.Label();
            this.dgUsuarios = new System.Windows.Forms.DataGridView();
            this.btnNuevoUsuario = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(242, 42);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 33;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(192, 45);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 32;
            this.lblApellido.Text = "Apellido";
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
            this.lblTitulo.Location = new System.Drawing.Point(141, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(393, 26);
            this.lblTitulo.TabIndex = 15;
            this.lblTitulo.Text = "Administración de Usuarios y Permisos";
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
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.lblApellido);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnFiltrar);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.lblNombre);
            this.groupBox2.Controls.Add(this.txtUsuarioID);
            this.groupBox2.Controls.Add(this.lblUsuarioId);
            this.groupBox2.Location = new System.Drawing.Point(7, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 73);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Búsqueda";
            // 
            // chkDeshabilitado
            // 
            this.chkDeshabilitado.AutoSize = true;
            this.chkDeshabilitado.Location = new System.Drawing.Point(195, 18);
            this.chkDeshabilitado.Name = "chkDeshabilitado";
            this.chkDeshabilitado.Size = new System.Drawing.Size(90, 17);
            this.chkDeshabilitado.TabIndex = 34;
            this.chkDeshabilitado.Text = "Deshabilitado";
            this.chkDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(72, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 23;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(9, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 22;
            this.lblNombre.Text = "Nombre";
            // 
            // txtUsuarioID
            // 
            this.txtUsuarioID.Location = new System.Drawing.Point(72, 16);
            this.txtUsuarioID.Name = "txtUsuarioID";
            this.txtUsuarioID.Size = new System.Drawing.Size(100, 20);
            this.txtUsuarioID.TabIndex = 15;
            // 
            // lblUsuarioId
            // 
            this.lblUsuarioId.AutoSize = true;
            this.lblUsuarioId.Location = new System.Drawing.Point(9, 19);
            this.lblUsuarioId.Name = "lblUsuarioId";
            this.lblUsuarioId.Size = new System.Drawing.Size(57, 13);
            this.lblUsuarioId.TabIndex = 13;
            this.lblUsuarioId.Text = "Usuario ID";
            // 
            // dgUsuarios
            // 
            this.dgUsuarios.AllowUserToAddRows = false;
            this.dgUsuarios.AllowUserToDeleteRows = false;
            this.dgUsuarios.AllowUserToResizeRows = false;
            this.dgUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsuarios.Location = new System.Drawing.Point(7, 149);
            this.dgUsuarios.MultiSelect = false;
            this.dgUsuarios.Name = "dgUsuarios";
            this.dgUsuarios.ReadOnly = true;
            this.dgUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsuarios.Size = new System.Drawing.Size(687, 255);
            this.dgUsuarios.TabIndex = 16;
            this.dgUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUsuarios_CellContentClick);
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Image = global::GestorDeFlotasDesktop.Properties.Resources.add;
            this.btnNuevoUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoUsuario.Location = new System.Drawing.Point(14, 41);
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.Size = new System.Drawing.Size(112, 23);
            this.btnNuevoUsuario.TabIndex = 17;
            this.btnNuevoUsuario.Text = "Nuevo Usuario";
            this.btnNuevoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoUsuario.UseVisualStyleBackColor = true;
            this.btnNuevoUsuario.Click += new System.EventHandler(this.btnNuevoUsuario_Click);
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
            // AbmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 443);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgUsuarios);
            this.Controls.Add(this.btnNuevoUsuario);
            this.Controls.Add(this.lblFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración de Usuarios y Permisos";
            this.Load += new System.EventHandler(this.AbmUsuario_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtUsuarioID;
        private System.Windows.Forms.Label lblUsuarioId;
        private System.Windows.Forms.DataGridView dgUsuarios;
        private System.Windows.Forms.Button btnNuevoUsuario;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.CheckBox chkDeshabilitado;
    }
}