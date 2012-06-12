using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmChofer
{
    public partial class AbmChofer : Form
    {
        private string camposSelect = "dniChofer, nombre, apellido, direccion, telefono, email, fechaNacimiento";
        private string whereObligatorio = "isnull(anulado,'0')='0'";
        private string consultaOrderBy = "nombre,apellido";
        private string nombreTabla = "Femig.Choferes";
        private string filtro1Value = "dniChofer";
        private string filtro2Value = "apellido";
        private string filtro3Value = "nombre";
        private string filtro4Value = "direccion";
        private string filtro1Text = "Dni:";
        private string filtro2Text = "Apellido:";
        private string filtro3Text = "Nombre:";
        private string filtro4Text = "Dirección:";
        private static AbmChofer unicaInst = null;
        public static AbmChofer Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmChofer();
            }
            return unicaInst;
        }

        private AbmChofer()
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
            this.txtDni.Text = "";
            this.txtApellido.Text = "";
            this.txtNombre.Text = "";
            this.txtDireccion.Text = "";
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtDni.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtDni.Text + "%'";
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
            if (!string.IsNullOrEmpty(txtDni.Text))
                leyendaFiltros += filtro1Text + " " + txtDni.Text;
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
            GestorDeFlotasDesktop.AbmChofer.addEditChofer frmAbmChofer = GestorDeFlotasDesktop.AbmChofer.addEditChofer.Instance();
            frmAbmChofer.modoAbm = "Nuevo";
            frmAbmChofer.tituloPantalla = "Agregar Nuevo Chofer";
            frmAbmChofer.ShowDialog();
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
            if (e.ColumnIndex==0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmChofer.addEditChofer frmEditarChofer = GestorDeFlotasDesktop.AbmChofer.addEditChofer.Instance();
                frmEditarChofer.modoAbm = "Editar";
                frmEditarChofer.dniChofer = long.Parse(dgChoferes.SelectedRows[0].Cells["dniChofer"].Value.ToString());
                frmEditarChofer.tituloPantalla = "Editar Chofer, Dni: " + dgChoferes.SelectedRows[0].Cells["dniChofer"].Value.ToString();
                if (frmEditarChofer.ShowDialog() == DialogResult.OK)
                    cargarQuery();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa eliminar este Chofer?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter pDniChofer = new SqlParameter("@pDniChofer", SqlDbType.BigInt);
                    pDniChofer.Value = long.Parse(dgChoferes.SelectedRows[0].Cells["dniChofer"].Value.ToString());
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarChofer", pDniChofer);
                    cargarQuery();
                }
                
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
