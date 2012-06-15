using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmPantallas
{
    public partial class editPantalla : Form
    {
        public string pantallaID { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static editPantalla unicaInst = null;
        public static editPantalla Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new editPantalla();
            }
            return unicaInst;
        }

        private editPantalla()
        {
            InitializeComponent();
        }

        private void editPantalla_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            txtPantallaID.Text = "";
            txtDescripcion.Text = "";
            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(pantallaID);
                txtPantallaID.ReadOnly = true;
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select pantallaID, descripcion from femig.Pantalla where pantallaID = '" + pantallaID + "'");
            txtPantallaID.Text = dtValores.Rows[0]["pantallaID"].ToString();  
            txtDescripcion.Text = dtValores.Rows[0]["descripcion"].ToString();
        }

        private bool validaCamposRequeridos()
        {

            if (txtPantallaID.Text.Trim() == string.Empty | txtDescripcion.Text.Trim() == string.Empty)
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
                    GestorDeFlotasDesktop.ListaErrores.ListaErrores frmErrores = new GestorDeFlotasDesktop.ListaErrores.ListaErrores();

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar editar la pantalla.");

                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                        frmErrores.agregarError("Debe especificar una descripción para la pantalla.");

                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pPantallaID = new SqlParameter("@pPantallaID", SqlDbType.VarChar, 255);
                pPantallaID.Value = txtPantallaID.Text;
                SqlParameter pDescripcion = new SqlParameter("@pDescripcion", SqlDbType.VarChar, 255);
                pDescripcion.Value = txtDescripcion.Text;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pPantallaID, pDescripcion,pRetCatchError};


                if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarPantalla", parametros))
                {
                    if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                    {
                        MessageBox.Show("La Pantalla: " + txtPantallaID.Text + " fue editada exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (modoAbm == "Nuevo")
                txtPantallaID.Text = "";

            txtDescripcion.Text = "";
        }
    }
}
