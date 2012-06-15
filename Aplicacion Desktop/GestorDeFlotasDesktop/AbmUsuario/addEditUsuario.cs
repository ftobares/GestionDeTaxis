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
    public partial class addEditUsuario : Form
    {
        public string usuarioID { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditUsuario unicaInst = null;
        public static addEditUsuario Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditUsuario();
            }
            return unicaInst;
        }

        private addEditUsuario()
        {
            InitializeComponent();
        }

        private void addEditUsuario_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            txtUsuarioID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtMaxIntentos.Text = "0";
            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(usuarioID);
                txtUsuarioID.ReadOnly = true;
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select usuarioID, nombre, apellido, email, cantMaxIntentos, anulado from femig.Usuario where usuarioID = '" + usuarioID + "'");
            txtUsuarioID.Text = dtValores.Rows[0]["usuarioID"].ToString();
            txtNombre.Text = dtValores.Rows[0]["nombre"].ToString();
            txtApellido.Text = dtValores.Rows[0]["apellido"].ToString();
            txtEmail.Text = dtValores.Rows[0]["email"].ToString();
            txtMaxIntentos.Text = dtValores.Rows[0]["cantMaxIntentos"].ToString();
            txtPassword.Text = "*******";
            if (dtValores.Rows[0]["cantMaxIntentos"].ToString() == "1")
                chkDeshabilitado.Checked = true;
            else
                chkDeshabilitado.Checked = false;
        }

        private bool validaCamposRequeridos()
        {

            if (txtUsuarioID.Text.Trim() == string.Empty | txtNombre.Text.Trim() == string.Empty | txtApellido.Text.Trim() == string.Empty | txtPassword.Text.Trim() == string.Empty | txtMaxIntentos.Text.Trim() == string.Empty)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Auto.");

                    if (string.IsNullOrEmpty(txtUsuarioID.Text))
                        frmErrores.agregarError("Debe completar el campo Usuario ID.");
                    if (string.IsNullOrEmpty(txtNombre.Text))
                        frmErrores.agregarError("Debe completar el Nombre.");
                    if (string.IsNullOrEmpty(txtApellido.Text))
                        frmErrores.agregarError("Debe completar el Apellido.");
                    if (string.IsNullOrEmpty(txtPassword.Text))
                        frmErrores.agregarError("Debe ingresar una contraseña.");
                    if (string.IsNullOrEmpty(txtMaxIntentos.Text))
                        frmErrores.agregarError("Debe especificar una cantidad máxima de intentos.");

                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pUsuarioID = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 10);
                pUsuarioID.Value = txtUsuarioID.Text;
                SqlParameter pNombre = new SqlParameter("@pNombre", SqlDbType.VarChar, 255);
                pNombre.Value = txtNombre.Text;
                SqlParameter pApellido = new SqlParameter("@pApellido", SqlDbType.VarChar, 255);
                pApellido.Value = txtApellido.Text;
                SqlParameter pEmail = new SqlParameter("@pEmail", SqlDbType.VarChar, 26);
                pEmail.Value = txtEmail.Text;
                SqlParameter pPassword = new SqlParameter("@pPassword", SqlDbType.VarChar, 10);
                pPassword.Value = GestorDeFlotasDesktop.BD.GD1C2012.encriptarStr(txtPassword.Text);
                SqlParameter pCantMaxIntentos = new SqlParameter("@pCantMaxIntentos", SqlDbType.Int);
                pCantMaxIntentos.Value = txtMaxIntentos.Text;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                if (chkDeshabilitado.Checked)
                    pAnulado.Value = 1;
                else
                    pAnulado.Value = 0;

                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pUsuarioID, pNombre, pApellido, pEmail, pPassword, pCantMaxIntentos, pAnulado, pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearUsuario", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El usuario ID: " + txtUsuarioID.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarUsuario", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El usuario ID: " + txtUsuarioID.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtUsuarioID.Text = "";

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtMaxIntentos.Text = "";
            chkDeshabilitado.Checked = false;
        }

        private void txtMaxIntentos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
