using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmAuto
{
    public partial class AbmAuto : Form
    {
        private string camposSelect = "patente, marca, modelo, licencia, rodado, nroSerieReloj";
        private string whereObligatorio = "isnull(anulado,'0')='0'";
        private string consultaOrderBy = "patente";
        private string nombreTabla = "Femig.Autos";
        private string filtro1Value = "patente";
        private string filtro2Value = "marca";
        private string filtro3Value = "modelo";
        private string filtro4Value = "nroSerieReloj";
        private string filtro5Value = "licencia";
        private string filtro1Text = "Patente:";
        private string filtro2Text = "Marca:";
        private string filtro3Text = "Modelo:";
        private string filtro4Text = "Reloj:";
        private string filtro5Text = "Licencia:";
        private static AbmAuto unicaInst = null;
        public static AbmAuto Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmAuto();
            }
            return unicaInst;
        }

        private AbmAuto()
        {
            InitializeComponent();
        }

        private void AbmAuto_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgAutos.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgAutos.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            txtPatente.Text = "";
            txtModelo.Text = "";
            txtMarca.Text = "";
            txtReloj.Text = "";
            txtLicencia.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtPatente.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtPatente.Text + "%'";
            if (!string.IsNullOrEmpty(txtMarca.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtMarca.Text + "%'";
            if (!string.IsNullOrEmpty(txtModelo.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtModelo.Text + "%'";
            if (!string.IsNullOrEmpty(txtReloj.Text))
                strQuery += " and cast(" + filtro4Value + " as varchar) like '%" + txtReloj.Text + "%'";
            if (!string.IsNullOrEmpty(txtLicencia.Text))
                strQuery += " and cast(" + filtro5Value + " as varchar) like '%" + txtLicencia.Text + "%'";
            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgAutos.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtPatente.Text))
                leyendaFiltros += filtro1Text + " " + txtPatente.Text;
            if (!string.IsNullOrEmpty(txtMarca.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtMarca.Text;
            if (!string.IsNullOrEmpty(txtModelo.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtModelo.Text;
            if (!string.IsNullOrEmpty(txtReloj.Text))
                leyendaFiltros += ", " + filtro4Text + " " + txtReloj.Text;
            if (!string.IsNullOrEmpty(txtLicencia.Text))
                leyendaFiltros += ", " + filtro5Text + " " + txtLicencia.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoAuto_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmAuto.addEditAuto frmAbmAuto = GestorDeFlotasDesktop.AbmAuto.addEditAuto.Instance();
            frmAbmAuto.modoAbm = "Nuevo";
            frmAbmAuto.tituloPantalla = "Agregar Nuevo Auto";
            frmAbmAuto.ShowDialog();
        }

        private void txtFiltrar_Click(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            inicializarFormulario();
            cargarQuery();
        }

        private void dgAutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmAuto.addEditAuto frmEditarAuto = GestorDeFlotasDesktop.AbmAuto.addEditAuto.Instance();
                frmEditarAuto.modoAbm = "Editar";
                frmEditarAuto.patenteAuto = dgAutos.SelectedRows[0].Cells["patente"].Value.ToString();
                frmEditarAuto.tituloPantalla = "Editar Auto, patente: " + dgAutos.SelectedRows[0].Cells["patente"].Value.ToString();
                if (frmEditarAuto.ShowDialog() == DialogResult.OK)
                    cargarQuery();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa eliminar este Auto?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter pPatente = new SqlParameter("@pPatente", SqlDbType.VarChar, 10);
                    pPatente.Value = dgAutos.SelectedRows[0].Cells["patente"].Value.ToString();
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarAuto", pPatente);
                    cargarQuery();
                }
                
            }

            
            
        }
    }
}
