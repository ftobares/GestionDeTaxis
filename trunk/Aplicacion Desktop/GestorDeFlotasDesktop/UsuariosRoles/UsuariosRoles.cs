using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.UsuariosRoles
{
    public partial class UsuariosRoles : Form
    {
        public string usuarioID { get; set; }

        public UsuariosRoles()
        {
            InitializeComponent();
        }

        private void UsuariosRoles_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chkSeleccionar = new DataGridViewCheckBoxColumn();
            chkSeleccionar.Name = "chkSeleccionar";
            chkSeleccionar.HeaderText = "Selección";
            chkSeleccionar.DataPropertyName = "chk";
            chkSeleccionar.DisplayIndex = 0;
            dgPantallas.Columns.Add(chkSeleccionar);
            chkSeleccionar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            cargarQuery();


        }

        private void cargarQuery()
        {
            DataTable dtResultado = new DataTable();
            SqlParameter pUsuarioID = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
            pUsuarioID.Value = usuarioID;

            GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.getRolesDeUsuario", pUsuarioID, dtResultado);

            dgPantallas.DataSource = dtResultado;

            //dgPantallas.Columns["chk"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                cambiarSeleccionRolPantalla(dgPantallas.Rows[e.RowIndex].Cells["rolID"].Value.ToString());
            }
        }

        private void cambiarSeleccionRolPantalla(string rolID)
        {
            SqlParameter pUsuarioID = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
            pUsuarioID.Value = usuarioID;
            SqlParameter pRolID = new SqlParameter("@pRolID", SqlDbType.VarChar, 255);
            pRolID.Value = rolID;

            SqlParameter[] parametros = { pUsuarioID, pRolID };

            GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.AsignarDesasignarRolUsuario", parametros);

        }

        private void btnTodoNada_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgPantallas.Rows.Count; i++)
            {
                if (dgPantallas.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    quitarSelecciones();
                    return;
                }

            }

            seleccionarTodo();

        }

        private void seleccionarTodo()
        {
            for (int i = 0; i < dgPantallas.Rows.Count; i++)
            {
                dgPantallas.Rows[i].Cells[0].Value = true;
                cambiarSeleccionRolPantalla(dgPantallas.Rows[i].Cells["rolID"].Value.ToString());
            }
        }

        private void quitarSelecciones()
        {
            for (int i = 0; i < dgPantallas.Rows.Count; i++)
            {
                dgPantallas.Rows[i].Cells[0].Value = false;
                cambiarSeleccionRolPantalla(dgPantallas.Rows[i].Cells["rolID"].Value.ToString());
            }
        }
    }
}

