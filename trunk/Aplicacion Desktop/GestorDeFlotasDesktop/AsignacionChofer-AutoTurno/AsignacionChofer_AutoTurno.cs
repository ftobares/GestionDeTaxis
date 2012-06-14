using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AsignacionChofer_AutoTurno
{
    public partial class AsignacionChofer_AutoTurno : Form
    {
        private string whereObligatorio = "";
        private string camposSelect = "asignacionID, fecha, dniChofer, patente, turnoID";
        private string consultaOrderBy = "fecha,dniChofer";
        private string nombreTabla = "Femig.ChoferAutoTurno";
        private string filtro1Value = "fecha";
        private string filtro2Value = "dniChofer";
        private string filtro3Value = "patente";
        private string filtro4Value = "turnoID";
        private string filtro1Text = "Fecha:";
        private string filtro2Text = "DNI-Chofer:";
        private string filtro3Text = "Patente:";
        private string filtro4Text = "ID-Turno:";
        private static AsignacionChofer_AutoTurno unicaInst = null;
        public static AsignacionChofer_AutoTurno Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AsignacionChofer_AutoTurno();
            }
            return unicaInst;
        }

        private AsignacionChofer_AutoTurno()
        {
            InitializeComponent();
        }

        private void AbmChofer_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgChoferes.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgChoferes.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            this.txtApellido.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(dtpNacimiento.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + dtpNacimiento.Text + "%'";
            if (!string.IsNullOrEmpty(txtApellido.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtApellido.Text + "%'";
            if (!string.IsNullOrEmpty(txtNombre.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtNombre.Text + "%'";
            if (!string.IsNullOrEmpty(txtDireccion.Text))
                strQuery += " and cast(" + filtro4Value + " as varchar) like '%" + txtDireccion.Text + "%'";
            strQuery += " order by " + consultaOrderBy;

            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgChoferes.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(dtpNacimiento.Text))
                leyendaFiltros += filtro1Text + " " + dtpNacimiento.Text;
            if (!string.IsNullOrEmpty(txtApellido.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtApellido.Text;
            if (!string.IsNullOrEmpty(txtNombre.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtNombre.Text;
            if (!string.IsNullOrEmpty(txtDireccion.Text))
                leyendaFiltros += ", " + filtro4Text + " " + txtDireccion.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoChofer_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AsignacionChofer_AutoTurno.addChofer_AutoTurno frmAbmChofer = GestorDeFlotasDesktop.AsignacionChofer_AutoTurno.addChofer_AutoTurno.Instance();
            frmAbmChofer.modoAbm = "Nuevo";
            frmAbmChofer.tituloPantalla = "Agregar Nuevo Chofer";
            if (frmAbmChofer.ShowDialog() == DialogResult.OK)
                cargarQuery();
            frmAbmChofer.Close();

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

        private void dgChoferes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
                {
                    GestorDeFlotasDesktop.AbmChofer.addEditChofer frmEditarChofer = GestorDeFlotasDesktop.AbmChofer.addEditChofer.Instance();
                    frmEditarChofer.modoAbm = "Editar";
                    if (dgChoferes.SelectedRows[0].Cells["asignacionID"].Value.ToString() != string.Empty)
                        frmEditarChofer.dniChofer = long.Parse(dgChoferes.SelectedRows[0].Cells["asignacionID"].Value.ToString());
                    frmEditarChofer.tituloPantalla = "Editar Relacion ";
                    if (frmEditarChofer.ShowDialog() == DialogResult.OK)
                        cargarQuery();
                    frmEditarChofer.Close();
                }

                if (e.ColumnIndex == 1)
                {
                    if (MessageBox.Show("¿Esta seguro que deséa eliminar esta Relacion?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlParameter pDniChofer = new SqlParameter("@pDniChofer", SqlDbType.Int);
                        pDniChofer.Value = long.Parse(dgChoferes.SelectedRows[0].Cells["asignacionID"].Value.ToString());
                        GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarChoferAutoTurno", pDniChofer);
                        cargarQuery();
                    }

                }
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
