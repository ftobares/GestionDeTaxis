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
    public partial class addEditChofer : Form
    {
        public long dniChofer { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditChofer unicaInst = null;
        public static addEditChofer Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditChofer();
            }
            return unicaInst;
        }

        private addEditChofer()
        {
            InitializeComponent();
        }

        private void addEditChofer_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            txtDniChofer.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            dtpNacimiento.Value = DateTime.Today;

            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {
                getDatosRegistro(dniChofer);
                txtDniChofer.ReadOnly = true;
            }
        }

        private void getDatosRegistro(long dniChofer)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select dniChofer, nombre, apellido, direccion, telefono, email, fechaNacimiento, anulado from femig.choferes where dniChofer = " + dniChofer);
            txtDniChofer.Text = dtValores.Rows[0]["dniChofer"].ToString();
            txtNombre.Text = dtValores.Rows[0]["nombre"].ToString();
            txtApellido.Text = dtValores.Rows[0]["apellido"].ToString();
            txtDireccion.Text = dtValores.Rows[0]["direccion"].ToString();
            txtTelefono.Text = dtValores.Rows[0]["telefono"].ToString();
            txtEmail.Text = dtValores.Rows[0]["email"].ToString();
            dtpNacimiento.Value =  (DateTime)dtValores.Rows[0]["fechaNacimiento"];
            if (dtValores.Rows[0]["anulado"].ToString() == "True")
                chkDeshabilitado.Checked = true;
            else
                chkDeshabilitado.Checked = false;
        }

        private bool validaCamposRequeridos()
        {

            if (txtDniChofer.Text.Trim() == string.Empty | txtNombre.Text.Trim() == string.Empty | txtApellido.Text.Trim() == string.Empty | txtDireccion.Text.Trim() == string.Empty | txtTelefono.Text.Trim() == string.Empty | txtEmail.Text.Trim() == string.Empty | dtpNacimiento.Value>=DateTime.Today)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Chofer.");

                    if (string.IsNullOrEmpty(txtDniChofer.Text))
                        frmErrores.agregarError("Debe completar el DNI del chofer.");
                    if (string.IsNullOrEmpty(txtNombre.Text))
                        frmErrores.agregarError("Debe completar el Nombre.");
                    if (string.IsNullOrEmpty(txtApellido.Text))
                        frmErrores.agregarError("Debe completar el apellido.");
                    if (string.IsNullOrEmpty(txtDireccion.Text))
                        frmErrores.agregarError("Debe completar la dirección.");
                    if (string.IsNullOrEmpty(txtTelefono.Text))
                        frmErrores.agregarError("Debe completar el teléfono.");
                    if (string.IsNullOrEmpty(txtEmail.Text))
                        frmErrores.agregarError("Debe completar el Email.");
                    if (dtpNacimiento.Value>=DateTime.Today)
                        frmErrores.agregarError("La fecha de nacimiento debe ser menor a hoy.");
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pDniChofer = new SqlParameter("@pDniChofer", SqlDbType.BigInt);
                pDniChofer.Value = txtDniChofer.Text;
                SqlParameter pNombre = new SqlParameter("@pNombre", SqlDbType.VarChar, 255);
                pNombre.Value = txtNombre.Text;
                SqlParameter pApellido = new SqlParameter("@pApellido", SqlDbType.VarChar, 255);
                pApellido.Value = txtApellido.Text;
                SqlParameter pDireccion = new SqlParameter("@pDireccion", SqlDbType.VarChar, 255);
                pDireccion.Value = txtDireccion.Text;
                SqlParameter pTelefono = new SqlParameter("@pTelefono", SqlDbType.BigInt);
                pTelefono.Value = txtTelefono.Text;
                SqlParameter pEmail = new SqlParameter("@pEmail", SqlDbType.VarChar,50);
                pEmail.Value = txtEmail.Text;
                SqlParameter pFechaNacimiento = new SqlParameter("@pFechaNacimiento", SqlDbType.DateTime);
                pFechaNacimiento.Value = dtpNacimiento.Value;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                if (chkDeshabilitado.Checked)
                    pAnulado.Value = 1;
                else
                    pAnulado.Value = 0;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pDniChofer,pNombre,pApellido,pDireccion,pTelefono,pEmail,pFechaNacimiento,pAnulado,pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearChofer", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El chofer con dni: " + txtDniChofer.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarChofer", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El chofer con dni: " + txtDniChofer.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtDniChofer.Text = "";

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            chkDeshabilitado.Checked = false;
        }

        private void txtDniChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
