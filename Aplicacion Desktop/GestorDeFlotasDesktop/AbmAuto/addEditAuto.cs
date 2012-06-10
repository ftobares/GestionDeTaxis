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

        private bool validaCamposRequeridos()
        {

            if (mtxtPatente.Text.Trim() == string.Empty | !mtxtPatente.MaskFull | cmbMarca.Text.Trim() == string.Empty | txtModelo.Text.Trim() == string.Empty | txtLicencia.Text.Trim() == string.Empty | txtRodado.Text.Trim() == string.Empty | txtReloj.Text.Trim() == string.Empty)
                return false;
            else
                return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaCamposRequeridos())
                {
                    MessageBox.Show("Debe completar los campos marcados en Rojo obligatoriamente.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pPatente = new SqlParameter("@pPatente", SqlDbType.VarChar, 20);
                pPatente.Value = mtxtPatente.Text;
                SqlParameter pMarca = new SqlParameter("@pMarca", SqlDbType.VarChar, 100);
                pMarca.Value = cmbMarca.Text;
                SqlParameter pModelo = new SqlParameter("@pModelo", SqlDbType.VarChar, 20);
                pModelo.Value = txtModelo.Text;
                SqlParameter pLicencia = new SqlParameter("@pLicencia", SqlDbType.VarChar, 100);
                pLicencia.Value = txtLicencia.Text;
                SqlParameter pRodado = new SqlParameter("@pRodado", SqlDbType.VarChar, 20);
                pRodado.Value = txtRodado.Text;
                SqlParameter pNroSerieReloj = new SqlParameter("@pNroSerieReloj", SqlDbType.VarChar, 100);
                pNroSerieReloj.Value = txtReloj.Text;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.VarChar, 20);
                pAnulado.Value = "0";

                SqlParameter[] parametros = { pPatente, pMarca, pModelo, pLicencia, pRodado, pNroSerieReloj, pAnulado };

                if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearAuto", parametros, retCatchError))
                {
                    if (retCatchError == string.Empty)
                    {
                        MessageBox.Show("El auto con patente: " + mtxtPatente.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.inicializarFormulario();
                    }
                    else
                        MessageBox.Show(retCatchError, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
