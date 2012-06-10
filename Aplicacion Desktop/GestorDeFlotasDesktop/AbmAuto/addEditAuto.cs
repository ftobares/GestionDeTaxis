using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.AbmAuto
{
    public partial class addEditAuto : Form
    {

        private static addEditAuto unicaInst = null;
        public static addEditAuto Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditAuto();
            }
            return unicaInst;
        }

        private addEditAuto()
        {
            InitializeComponent();
        }

        private void addEditAuto_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            mtxtPatente.Text = "";
            cargarMarcas();
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            txtReloj.Text = "";
        }

        private void cargarMarcas()
        {
            string strQuery = "Select marca from FEMIG.marcas_autos";
            cmbMarca.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
            cmbMarca.DisplayMember = "marca";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
