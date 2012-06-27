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
        public string clave { get; set; }
        public string strQueryCombo { get; set; }
        public string strQuerySeleccionar { get; set; }
        public string Filtro1Value { get; set; }
        public string Filtro1Text { get; set; }
        public string Filtro2Value { get; set; }
        public string Filtro2Text { get; set; }
        public string Filtro3Value { get; set; }
        public string Filtro3Text { get; set; }
        public string Filtro4Value { get; set; }
        public string Filtro4Text { get; set; }
        public string nombreTabla { get; set; }
        public string orderBy { get; set; }
        public string camposSelect { get; set; }
        public string whereObligatorio { get; set; }
        public string campoRetorno { get; set; }
        public string valorRetorno { get; set; }

        public Buscador(string sClave)
        {
            this.clave = sClave;
            InitializeComponent();
        }

        private void Buscador_Load(object sender, EventArgs e)
        {

            lblFiltro1.Text = Filtro1Text;
            lblFiltro2.Text = Filtro2Text;
            lblFiltroCmb.Text = Filtro3Text;
            lblFiltro4.Text = Filtro4Text;

            if (string.IsNullOrEmpty(strQueryCombo))
            {
                lblFiltroCmb.Visible = false;
                cmbFiltro.Visible = false;
            }
            else
                cargarCombo();

            if (string.IsNullOrEmpty(strQuerySeleccionar))
            {
                lblFiltro4.Visible = false;
                txtFiltro4.Visible = false;
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

            inicializarFormulario();
            cargarQuery();
        }

        private void inicializarFormulario()
        {
            txtFiltro1.Text = "";
            txtFiltro2.Text = "";
            cmbFiltro.Text = "";
            txtFiltro4.Text = "";
            lblFiltro.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtFiltro1.Text))
                strQuery += " and cast(" + Filtro1Value + " as varchar) like '%" + txtFiltro1.Text + "%'";
            if (!string.IsNullOrEmpty(txtFiltro2.Text))
                strQuery += " and cast(" + Filtro2Value + " as varchar) like '%" + txtFiltro2.Text + "%'";
            if (!string.IsNullOrEmpty(cmbFiltro.Text))
                strQuery += " and cast(" + Filtro3Value + " as varchar) like '%" + cmbFiltro.Text + "%'";
            if (!string.IsNullOrEmpty(txtFiltro4.Text))
                strQuery += " and cast(" + Filtro4Value + " as varchar) like '%" + txtFiltro4.Text + "%'";
            strQuery += " order by " + orderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgResultados.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros="";
            if (!string.IsNullOrEmpty(txtFiltro1.Text))
                leyendaFiltros += Filtro1Text + " " + txtFiltro1.Text;
            if (!string.IsNullOrEmpty(txtFiltro2.Text))
                leyendaFiltros += ", " + Filtro2Text + " " + txtFiltro2.Text;
            if (!string.IsNullOrEmpty(cmbFiltro.Text))
                leyendaFiltros += ", " + Filtro3Text + " " + cmbFiltro.Text;
            if (!string.IsNullOrEmpty(txtFiltro4.Text))
                leyendaFiltros += ", " + Filtro4Text + " " + txtFiltro4.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private void cargarCombo()
        {}

        private void btnResetFiltros_Click(object sender, EventArgs e)
        {
            inicializarFormulario();
            cargarQuery();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            seleccionarRegistro();
        }

        private void seleccionarRegistro()
        {
            if (dgResultados.SelectedRows.Count == 0)
                MessageBox.Show("Debe seleccionar un registro de la grilla.", "Seleccione un registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (dgResultados.SelectedRows.Count == 1)
            {
                valorRetorno = dgResultados.SelectedRows[0].Cells[this.clave].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgResultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            seleccionarRegistro();
        }
    }
}
