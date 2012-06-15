using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.RolPantallas
{
    public partial class AsigRolPantallas : Form
    {
        public string rolID { get; set; }

        public AsigRolPantallas()
        {
            InitializeComponent();
        }

        private void AsigRolPantallas_Load(object sender, EventArgs e)
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
            SqlParameter pRolID = new SqlParameter("@pRolID", SqlDbType.VarChar,20);
            pRolID.Value = rolID;

            GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.getPantallasDeRol", pRolID,dtResultado);

            dgPantallas.DataSource = dtResultado;

            dgPantallas.Columns["chk"].Visible = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgPantallas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                cambiarSeleccionRolPantalla(dgPantallas.Rows[e.RowIndex].Cells["pantallaID"].Value.ToString());
            }
        }

        private void cambiarSeleccionRolPantalla(string pantallaID)
        {
            SqlParameter pRolID = new SqlParameter("@pRolID", SqlDbType.VarChar, 20);
            pRolID.Value = rolID;
            SqlParameter pPantallaID = new SqlParameter("@pPantallaID", SqlDbType.VarChar, 255);
            pPantallaID.Value = pantallaID;

            SqlParameter[] parametros = { pRolID, pPantallaID };

            GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.AsignarDesasignarRolPantalla", parametros);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i=0; i < dgPantallas.Rows.Count; i++)
            {
                if (dgPantallas.Rows[i].Cells[0].Value.ToString()=="True")
                {
                    quitarSelecciones();
                    return;
                }

            }

            seleccionarTodo();

        }

        private void seleccionarTodo()
        {
            for (int i=0; i < dgPantallas.Rows.Count; i++)
            {
                dgPantallas.Rows[i].Cells[0].Value = true;
                cambiarSeleccionRolPantalla(dgPantallas.Rows[i].Cells["pantallaID"].Value.ToString());
            }
        }

        private void quitarSelecciones()
        {
            for (int i = 0; i < dgPantallas.Rows.Count; i++)
            {
                dgPantallas.Rows[i].Cells[0].Value = false;
                cambiarSeleccionRolPantalla(dgPantallas.Rows[i].Cells["pantallaID"].Value.ToString());
            }
        }
    }
}
