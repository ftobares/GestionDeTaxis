using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmReloj
{
    public partial class AbmReloj : Form
    {
        private string camposSelect = "nroSerieReloj, marca, modelo, fechaVersion";
        private string whereObligatorio = "isnull(anulado,'0')='0'";
        private string consultaOrderBy = "nroSerieReloj";
        private string nombreTabla = "Femig.Relojes";
        private string filtro1Value = "nroSerieReloj";
        private string filtro2Value = "marca";
        private string filtro3Value = "modelo";
        private string filtro4Value = "fechaVersion";
        private string filtro1Text = "Reloj:";
        private string filtro2Text = "Marca:";
        private string filtro3Text = "Modelo:";
        private string filtro4Text = "Fecha Versión:";
        private static AbmReloj unicaInst = null;
        public static AbmReloj Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmReloj();
            }
            return unicaInst;
        }

        private AbmReloj()
        {
            InitializeComponent();
        }

        private void AbmReloj_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgRelojes.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgRelojes.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            txtNroSerieReloj.Text = "";
            txtModelo.Text = "";
            txtMarca.Text = "";
            dtpDesde.Value = DateTime.Today.AddYears(-10);
            dtpHasta.Value = DateTime.Today;
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtNroSerieReloj.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtNroSerieReloj.Text + "%'";
            if (!string.IsNullOrEmpty(txtMarca.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtMarca.Text + "%'";
            if (!string.IsNullOrEmpty(txtModelo.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtModelo.Text + "%'";

            strQuery += " and fechaVersion between '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "' and '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "'";

            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgRelojes.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtNroSerieReloj.Text))
                leyendaFiltros += filtro1Text + " " + txtNroSerieReloj.Text;
            if (!string.IsNullOrEmpty(txtMarca.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtMarca.Text;
            if (!string.IsNullOrEmpty(txtModelo.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtModelo.Text;

            leyendaFiltros += ", Fecha Versión Desde: " + dtpDesde.Value.Date.ToShortDateString();
            leyendaFiltros += ", Fecha Versión Hasta: " + dtpHasta.Value.Date.ToShortDateString();

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoReloj_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmReloj.addEditReloj frmAbmReloj = GestorDeFlotasDesktop.AbmReloj.addEditReloj.Instance();
            frmAbmReloj.modoAbm = "Nuevo";
            frmAbmReloj.tituloPantalla = "Agregar Nuevo Reloj";
            if (frmAbmReloj.ShowDialog() == DialogResult.OK)
                cargarQuery();
            frmAbmReloj.Close();
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

        private void dgRelojes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmReloj.addEditReloj frmEditarAuto = GestorDeFlotasDesktop.AbmReloj.addEditReloj.Instance();
                frmEditarAuto.modoAbm = "Editar";
                frmEditarAuto.nroSerieReloj = dgRelojes.SelectedRows[0].Cells["nroSerieReloj"].Value.ToString();
                frmEditarAuto.tituloPantalla = "Editar Reloj, Serie: " + dgRelojes.SelectedRows[0].Cells["nroSerieReloj"].Value.ToString();
                if (frmEditarAuto.ShowDialog() == DialogResult.OK)
                    cargarQuery();
                frmEditarAuto.Close();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa eliminar este Reloj?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter pNroSerieReloj = new SqlParameter("@pNroSerieReloj", SqlDbType.VarChar, 10);
                    pNroSerieReloj.Value = dgRelojes.SelectedRows[0].Cells["pNroSerieReloj"].Value.ToString();
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarReloj", pNroSerieReloj);
                    cargarQuery();
                }

            }



        }
    }
}
