using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.Buscador
{
    public partial class Buscador : Form
    {
        public string strQueryPrincipal { get; set; }
        public string strQueryCombo { get; set; }
        public string strQuerySeleccionar { get; set; }
        public string Filtro1Value { get; set; }
        public string Filtro1Text { get; set; }
        public string Filtro2Value { get; set; }
        public string Filtro2Text { get; set; }

        public Buscador()
        {
            InitializeComponent();
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strQueryCombo))
            {
                lblFiltroCmb.Visible = false;
                cmbFiltro.Visible = false;
                
            }

            if (string.IsNullOrEmpty(strQuerySeleccionar))
            {
                lblFiltro3.Visible = false;
                txtFiltro3.Visible = false;
                btnSeleccionar.Visible = false;

            }

            if (string.IsNullOrEmpty(Filtro1Text) | string.IsNullOrEmpty(Filtro1Value))
            {
                lblFiltro1.Visible = false;
                txtFiltro1.Visible = false;
            }

            if (string.IsNullOrEmpty(Filtro2Text) | string.IsNullOrEmpty(Filtro2Value))
            {
                lblFiltro2.Visible = false;
                txtFiltro2.Visible = false;
            }

            lblFiltro.Visible = false;
            cargarQueryPrincipal();

        }

        private void cargarQueryPrincipal()
        {
            dgResultados.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQueryPrincipal);
        }
    }
}
