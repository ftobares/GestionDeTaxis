using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmRol
{
    public partial class AbmRol : Form
    {
        private string camposSelect = "rolID, descripcion, case when anulado=1 then 'SI' else 'NO' end as Anulado";
        private string whereObligatorio = "1=1";
        private string consultaOrderBy = "rolID";
        private string DescripcionTabla = "Femig.Rol";
        private string filtro1Value = "rolID";
        private string filtro2Value = "Descripcion";
        private string filtro3Value = "anulado";

        private string filtro1Text = "Usuario ID:";
        private string filtro2Text = "Descripción:";
        private string filtro3Text = "Anulado:";

        private static AbmRol unicaInst = null;
        public static AbmRol Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmRol();
            }
            return unicaInst;
        }

        private AbmRol()
        {
            InitializeComponent();
        }

        private void AbmRol_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgRoles.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgRoles.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            txtRolID.Text = "";
            txtDescripcion.Text = "";
            chkDeshabilitado.Checked = false;
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + DescripcionTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtRolID.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtRolID.Text + "%'";
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtDescripcion.Text + "%'";

            if (chkDeshabilitado.Checked)
                strQuery += " and anulado='1'";
            else
                strQuery += " and anulado='0'";

            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgRoles.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtRolID.Text))
                leyendaFiltros += filtro1Text + " " + txtRolID.Text;
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtDescripcion.Text;

            if (chkDeshabilitado.Checked)
                leyendaFiltros += ", " + filtro3Text + " SI";

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmRol.addEditRol frmAbmRol = GestorDeFlotasDesktop.AbmRol.addEditRol.Instance();
            frmAbmRol.modoAbm = "Nuevo";
            frmAbmRol.tituloPantalla = "Agregar Nuevo Rol";
            if (frmAbmRol.ShowDialog() == DialogResult.OK)
                cargarQuery();
            frmAbmRol.Close();
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

        private void dgRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmRol.addEditRol frmEditarRol = GestorDeFlotasDesktop.AbmRol.addEditRol.Instance();
                frmEditarRol.modoAbm = "Editar";
                frmEditarRol.rolID = dgRoles.SelectedRows[0].Cells["rolID"].Value.ToString();
                frmEditarRol.tituloPantalla = "Editar Rol ID: " + dgRoles.SelectedRows[0].Cells["rolID"].Value.ToString();
                if (frmEditarRol.ShowDialog() == DialogResult.OK)
                    cargarQuery();
                frmEditarRol.Close();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa deshabilitar el Rol?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter prolID = new SqlParameter("@prolID", SqlDbType.VarChar, 20);
                    prolID.Value = dgRoles.SelectedRows[0].Cells["rolID"].Value.ToString();
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarRol", prolID);
                    cargarQuery();
                }

            }



        }
    }
}

