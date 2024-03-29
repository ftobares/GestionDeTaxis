﻿using System.Windows.Forms;
namespace GestorDeFlotasDesktop.AbmAuto
{
    partial class AbmAuto
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgAutos = new System.Windows.Forms.DataGridView();
            this.btnNuevoAuto = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReloj = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.chkDeshabilitado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgAutos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblTitulo.Location = new System.Drawing.Point(287, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(122, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "ABM Autos";
            // 
            // dgAutos
            // 
            this.dgAutos.AllowUserToAddRows = false;
            this.dgAutos.AllowUserToDeleteRows = false;
            this.dgAutos.AllowUserToResizeRows = false;
            this.dgAutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAutos.Location = new System.Drawing.Point(5, 149);
            this.dgAutos.MultiSelect = false;
            this.dgAutos.Name = "dgAutos";
            this.dgAutos.ReadOnly = true;
            this.dgAutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAutos.Size = new System.Drawing.Size(687, 255);
            this.dgAutos.TabIndex = 1;
            this.dgAutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAutos_CellContentClick);
            // 
            // btnNuevoAuto
            // 
            this.btnNuevoAuto.Image = global::GestorDeFlotasDesktop.Properties.Resources.add;
            this.btnNuevoAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoAuto.Location = new System.Drawing.Point(12, 41);
            this.btnNuevoAuto.Name = "btnNuevoAuto";
            this.btnNuevoAuto.Size = new System.Drawing.Size(93, 23);
            this.btnNuevoAuto.TabIndex = 2;
            this.btnNuevoAuto.Text = "Nuevo Auto";
            this.btnNuevoAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoAuto.UseVisualStyleBackColor = true;
            this.btnNuevoAuto.Click += new System.EventHandler(this.btnNuevoAuto_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeshabilitado);
            this.groupBox2.Controls.Add(this.txtLicencia);
            this.groupBox2.Controls.Add(this.lblLicencia);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Controls.Add(this.btnFiltrar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtModelo);
            this.groupBox2.Controls.Add(this.txtMarca);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtReloj);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPatente);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(5, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 73);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros de Búsqueda";
            // 
            // txtLicencia
            // 
            this.txtLicencia.Location = new System.Drawing.Point(389, 19);
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(100, 20);
            this.txtLicencia.TabIndex = 33;
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Location = new System.Drawing.Point(336, 22);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(47, 13);
            this.lblLicencia.TabIndex = 32;
            this.lblLicencia.Text = "Licencia";
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
            this.btnLimpiar.Click += new System.EventHandler(this.txtLimpiar_Click);
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
            this.btnFiltrar.Click += new System.EventHandler(this.txtFiltrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Modelo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(218, 46);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 25;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(218, 19);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Marca";
            // 
            // txtReloj
            // 
            this.txtReloj.Location = new System.Drawing.Point(59, 46);
            this.txtReloj.Name = "txtReloj";
            this.txtReloj.Size = new System.Drawing.Size(100, 20);
            this.txtReloj.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Reloj";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(59, 19);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(100, 20);
            this.txtPatente.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Patente";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(2, 418);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(35, 13);
            this.lblFiltro.TabIndex = 14;
            this.lblFiltro.Text = "label5";
            // 
            // chkDeshabilitado
            // 
            this.chkDeshabilitado.AutoSize = true;
            this.chkDeshabilitado.Location = new System.Drawing.Point(339, 48);
            this.chkDeshabilitado.Name = "chkDeshabilitado";
            this.chkDeshabilitado.Size = new System.Drawing.Size(90, 17);
            this.chkDeshabilitado.TabIndex = 35;
            this.chkDeshabilitado.Text = "Deshabilitado";
            this.chkDeshabilitado.UseVisualStyleBackColor = true;
            // 
            // AbmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 440);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnNuevoAuto);
            this.Controls.Add(this.dgAutos);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Autos";
            this.Load += new System.EventHandler(this.AbmAuto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAutos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private DataGridView dgAutos;
        private Button btnNuevoAuto;
        private GroupBox groupBox2;
        private Button btnLimpiar;
        private Button btnFiltrar;
        private Label label4;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private Label label3;
        private TextBox txtReloj;
        private Label label2;
        private TextBox txtPatente;
        private Label label1;
        private TextBox txtLicencia;
        private Label lblLicencia;
        private Label lblFiltro;
        private CheckBox chkDeshabilitado;
    }
}