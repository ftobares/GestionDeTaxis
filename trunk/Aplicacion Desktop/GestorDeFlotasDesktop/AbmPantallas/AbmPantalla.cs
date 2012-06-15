using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmPantallas
{
    public partial class AbmPantalla : Form
    {
        private string camposSelect = "pantallaID, descripcion";
        private string whereObligatorio = "1=1";
        private string consultaOrderBy = "pantallaID";
        private string nombreTabla = "Femig.Pantalla";
        private string filtro1Value = "pantallaID";
        private string filtro2Value = "descripcion";

        private string filtro1Text = "Pantalla ID:";
        private string filtro2Text = "Descripción:";

        private static AbmPantalla unicaInst = null;
        public static AbmPantalla Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmPantalla();
            }
            return unicaInst;
        }

        private AbmPantalla()
        {
            InitializeComponent();
        }

        private void AbmPantalla_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgPantallas.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            txtPantallaID.Text = "";
            txtDescripcion.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtPantallaID.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtPantallaID.Text + "%'";
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtDescripcion.Text + "%'";
            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgPantallas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtPantallaID.Text))
                leyendaFiltros += filtro1Text + " " + txtPantallaID.Text;
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtDescripcion.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            inicializarFormulario();
            cargarQuery();
        }

        private void dgPantallas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmPantallas.editPantalla frmEditarPantalla = GestorDeFlotasDesktop.AbmPantallas.editPantalla.Instance();
                frmEditarPantalla.modoAbm = "Editar";
                frmEditarPantalla.pantallaID = dgPantallas.SelectedRows[0].Cells["pantallaID"].Value.ToString();
                frmEditarPantalla.tituloPantalla = "Editar Pantalla: " + dgPantallas.SelectedRows[0].Cells["pantallaID"].Value.ToString();
                if (frmEditarPantalla.ShowDialog() == DialogResult.OK)
                    cargarQuery();
                frmEditarPantalla.Close();
            }
        }
    }
}
