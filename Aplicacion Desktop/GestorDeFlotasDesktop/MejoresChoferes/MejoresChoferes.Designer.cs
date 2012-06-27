namespace GestorDeFlotasDesktop.MejoresChoferes
{
    partial class MejoresChoferes
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
            this.dgFacturas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFacturas
            // 
            this.dgFacturas.AllowUserToAddRows = false;
            this.dgFacturas.AllowUserToDeleteRows = false;
            this.dgFacturas.AllowUserToResizeRows = false;
            this.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturas.Location = new System.Drawing.Point(12, 12);
            this.dgFacturas.MultiSelect = false;
            this.dgFacturas.Name = "dgFacturas";
            this.dgFacturas.ReadOnly = true;
            this.dgFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFacturas.Size = new System.Drawing.Size(260, 238);
            this.dgFacturas.TabIndex = 68;
            // 
            // MejoresChoferes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dgFacturas);
            this.Name = "MejoresChoferes";
            this.Text = "TOP Mejores Choferes";
            this.Load += new System.EventHandler(this.MejoresChoferes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFacturas;
    }
}