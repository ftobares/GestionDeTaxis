using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.ListaErrores
{
    public partial class ListaErrores : Form
    {
        public ListaErrores()
        {
            InitializeComponent();
        }

        public void agregarError(string errorDesc)
        {
            this.listErrores.Items.Add("* " + errorDesc);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void setTitulo(string strTitulo)
        {
            lblDescripcion.Text = strTitulo;
        }
    }
}
