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
        }

        private void inicializarFormulario()
        {
            txtPatente.Text = "";
            txtModelo.Text = "";
            txtMarca.Text = "";
            txtReloj.Text = "";
            cargarGrillaAutos();
        }

        private void cargarGrillaAutos()
        {
            string strQuery = "SELECT [patente],[marca],[modelo],[licencia],[rodado],[nroSerieReloj] FROM [GD1C2012].[FEMIG].[autos] WHERE ISNULL(ANULADO,'0')='0'";
            dgAutos.DataSource=GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }

        private void btnNuevoAuto_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmAuto.addEditAuto frmAbmAuto = GestorDeFlotasDesktop.AbmAuto.addEditAuto.Instance();
            frmAbmAuto.ShowDialog();
        }
    }
}
