namespace GestorDeFlotasDesktop.UsuariosRoles
{
    partial class UsuariosRoles
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
            this.btnTodoNada = new System.Windows.Forms.Button();
            this.dgPantallas = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPantallas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTodoNada
            // 
            this.btnTodoNada.Location = new System.Drawing.Point(12, 41);
            this.btnTodoNada.Name = "btnTodoNada";
            this.btnTodoNada.Size = new System.Drawing.Size(297, 25);
            this.btnTodoNada.TabIndex = 28;
            this.btnTodoNada.Text = "Seleccionar Todos/Ninguno";
            this.btnTodoNada.UseVisualStyleBackColor = true;
            this.btnTodoNada.Click += new System.EventHandler(this.btnTodoNada_Click);
            // 
            // dgPantallas
            // 
            this.dgPantallas.AllowUserToAddRows = false;
            this.dgPantallas.AllowUserToDeleteRows = false;
            this.dgPantallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPantallas.Location = new System.Drawing.Point(12, 72);
            this.dgPantallas.Name = "dgPantallas";
            this.dgPantallas.Size = new System.Drawing.Size(297, 266);
            this.dgPantallas.TabIndex = 26;
            this.dgPantallas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRoles_CellContentClick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(22, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(273, 26);
            this.lblTitulo.TabIndex = 25;
            this.lblTitulo.Text = "Asignación Usuarios Roles";
            // 
            // btnVolver
            // 
            this.btnVolver.Image = global::GestorDeFlotasDesktop.Properties.Resources.arrow_undo;
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(12, 344);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(69, 23);
            this.btnVolver.TabIndex = 27;
            this.btnVolver.Text = "Volver";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // UsuariosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 374);
            this.Controls.Add(this.btnTodoNada);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgPantallas);
            this.Controls.Add(this.lblTitulo);
            this.Name = "UsuariosRoles";
            this.Text = "UsuariosRoles";
            this.Load += new System.EventHandler(this.UsuariosRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPantallas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTodoNada;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgPantallas;
        private System.Windows.Forms.Label lblTitulo;
    }
}