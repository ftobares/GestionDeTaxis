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
    public partial class addEditRol : Form
    {
        public string rolID { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditRol unicaInst = null;
        public static addEditRol Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditRol();
            }
            return unicaInst;
        }

        private addEditRol()
        {
            InitializeComponent();
        }

        private void addEditRol_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            txtRolId.Text = "";
            txtDescripcion.Text = "";
            chkDeshabilitado.Checked = false;

            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(rolID);
                txtRolId.ReadOnly = true;
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select rolID, descripcion, anulado from femig.Rol where rolID = '" + rolID + "'");
            txtRolId.Text = dtValores.Rows[0]["rolID"].ToString();
            txtDescripcion.Text = dtValores.Rows[0]["descripcion"].ToString();
            
            if (dtValores.Rows[0]["anulado"].ToString() == "True")
                chkDeshabilitado.Checked = true;
            else
                chkDeshabilitado.Checked = false;
        }

        private bool validaCamposRequeridos()
        {

            if (txtRolId.Text.Trim() == string.Empty | txtDescripcion.Text.Trim() == string.Empty)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Rol.");

                    if (string.IsNullOrEmpty(txtRolId.Text))
                        frmErrores.agregarError("Debe completar el campo Rol ID.");
                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                        frmErrores.agregarError("Debe completar el Descripcion.");

                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pRolID = new SqlParameter("@pRolID", SqlDbType.VarChar, 20);
                pRolID.Value = txtRolId.Text;
                SqlParameter pDescripcion = new SqlParameter("@pDescripcion", SqlDbType.VarChar, 50);
                pDescripcion.Value = txtDescripcion.Text;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                if (chkDeshabilitado.Checked)
                    pAnulado.Value = 1;
                else
                    pAnulado.Value = 0;

                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pRolID, pDescripcion, pAnulado, pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearRol", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El Rol: " + txtRolId.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarRol", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El Rol: " + txtRolId.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
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
                txtRolId.Text = "";

            txtDescripcion.Text = "";
            chkDeshabilitado.Checked = false;
        }

        private void txtMaxIntentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
