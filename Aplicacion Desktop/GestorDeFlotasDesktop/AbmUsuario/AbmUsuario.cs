using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmUsuario
{
    public partial class AbmUsuario : Form
    {
        private string camposSelect = "usuarioID, nombre, apellido, email, cantIntentosFallo, cantMaxIntentos, case when anulado=1 then 'SI' else 'NO' end as Anulado";
        private string whereObligatorio = "1=1";
        private string consultaOrderBy = "usuarioID";
        private string nombreTabla = "Femig.Usuario";
        private string filtro1Value = "usuarioID";
        private string filtro2Value = "nombre";
        private string filtro3Value = "apellido";
        private string filtro4Value = "anulado";
        
        private string filtro1Text = "Usuario ID:";
        private string filtro2Text = "Nombre:";
        private string filtro3Text = "Apellido:";
        private string filtro4Text = "Anulado:";
        
        private static AbmUsuario unicaInst = null;
        public static AbmUsuario Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmUsuario();
            }
            return unicaInst;
        }

        private AbmUsuario()
        {
            InitializeComponent();
        }

        private void AbmUsuario_Load(object sender, EventArgs e)
        {

            inicializarFormulario();
            cargarQuery();

            DataGridViewImageColumn btnEditar = new DataGridViewImageColumn();
            btnEditar.Description = "Editar";
            btnEditar.HeaderText = "Editar";
            btnEditar.Name = "btnEditar";
            btnEditar.Image = global::GestorDeFlotasDesktop.Properties.Resources.application_edit;
            dgUsuarios.Columns.Add(btnEditar);
            btnEditar.DisplayIndex = 0;
            btnEditar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnEliminar = new DataGridViewImageColumn();
            btnEliminar.Description = "Eliminar";
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Image = global::GestorDeFlotasDesktop.Properties.Resources.delete;
            dgUsuarios.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 1;
            btnEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn btnPermisos = new DataGridViewImageColumn();
            btnPermisos.Description = "Permisos";
            btnPermisos.HeaderText = "Permisos";
            btnPermisos.Name = "btnPermisos";
            btnPermisos.Image = global::GestorDeFlotasDesktop.Properties.Resources.shield;
            dgUsuarios.Columns.Add(btnPermisos);
            btnPermisos.DisplayIndex = 2;
            btnPermisos.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
        }

        private void inicializarFormulario()
        {
            txtUsuarioID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            chkDeshabilitado.Checked = false;
        }

        private string construirQuery()
        {

            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtUsuarioID.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtUsuarioID.Text + "%'";
            if (!string.IsNullOrEmpty(txtNombre.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtNombre.Text + "%'";
            if (!string.IsNullOrEmpty(txtApellido.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtApellido.Text + "%'";
            
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
            dgUsuarios.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);

            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtUsuarioID.Text))
                leyendaFiltros += filtro1Text + " " + txtUsuarioID.Text;
            if (!string.IsNullOrEmpty(txtNombre.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtNombre.Text;
            if (!string.IsNullOrEmpty(txtApellido.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtApellido.Text;
            if (chkDeshabilitado.Checked)
                leyendaFiltros += ", " + filtro4Text + " SI";

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmUsuario.addEditUsuario frmAbmUsuario = GestorDeFlotasDesktop.AbmUsuario.addEditUsuario.Instance();
            frmAbmUsuario.modoAbm = "Nuevo";
            frmAbmUsuario.tituloPantalla = "Agregar Nuevo Usuario";
            if (frmAbmUsuario.ShowDialog() == DialogResult.OK)
                cargarQuery();
            frmAbmUsuario.Close();
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

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmUsuario.addEditUsuario frmEditarRol = GestorDeFlotasDesktop.AbmUsuario.addEditUsuario.Instance();
                frmEditarRol.modoAbm = "Editar";
                frmEditarRol.usuarioID = dgUsuarios.SelectedRows[0].Cells["usuarioID"].Value.ToString();
                frmEditarRol.tituloPantalla = "Editar Usuario ID: " + dgUsuarios.SelectedRows[0].Cells["usuarioID"].Value.ToString();
                if (frmEditarRol.ShowDialog() == DialogResult.OK)
                    cargarQuery();
                frmEditarRol.Close();
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("¿Esta seguro que deséa deshabilitar al Usuario?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter pUsuarioID = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
                    pUsuarioID.Value = dgUsuarios.SelectedRows[0].Cells["usuarioID"].Value.ToString();
                    GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("femig.eliminarUsuario", pUsuarioID);
                    cargarQuery();
                }

            }

            if (e.ColumnIndex == 2)
            {
                GestorDeFlotasDesktop.UsuariosRoles.UsuariosRoles frmUsuariosRoles = new GestorDeFlotasDesktop.UsuariosRoles.UsuariosRoles();

                frmUsuariosRoles.usuarioID = dgUsuarios.SelectedRows[0].Cells["usuarioID"].Value.ToString();
                frmUsuariosRoles.ShowDialog();
                frmUsuariosRoles.Dispose();

            }



        }
    }
}
