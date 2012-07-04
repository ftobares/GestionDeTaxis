using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmTurno
{
    public partial class addEditTurno : Form
    {
        public string turnoID { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditTurno unicaInst = null;
        public static addEditTurno Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditTurno();
            }
            return unicaInst;
        }

        private addEditTurno()
        {
            InitializeComponent();
        }

        private void addEditTurno_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void txtValorBandera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar))
            {

                TextBox textBox = (TextBox)sender;

                if (textBox.Text.IndexOf('.') > -1 &&
                         textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }

            }
        }

        private void txtValorFicha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar))
            {

                TextBox textBox = (TextBox)sender;

                if (textBox.Text.IndexOf('.') > -1 &&
                         textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 3)
                {
                    e.Handled = true;
                }

            }
        }

        private void inicializarFormulario()
        {
            txtDescripcion.Text = "";
            cmbHoraInicio.Text = "00";
            cmbHoraFin.Text = "00";
            txtValorBandera.Text = "";
            txtValorFicha.Text = "";
            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(turnoID);
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select horaInicio, horaFin, descripcion, valorFicha, valorBandera, anulado from femig.turnos where turnoID = '" + turnoID + "'");
            txtDescripcion.Text = dtValores.Rows[0]["descripcion"].ToString();
            cmbHoraInicio.Text = dtValores.Rows[0]["horaInicio"].ToString();
            cmbHoraFin.Text = dtValores.Rows[0]["horaFin"].ToString();
            txtValorFicha.Text = dtValores.Rows[0]["valorFicha"].ToString();
            txtValorBandera.Text = dtValores.Rows[0]["valorBandera"].ToString();
            if (dtValores.Rows[0]["anulado"].ToString() == "True")
                chkDeshabilitado.Checked = true;
            else
                chkDeshabilitado.Checked = false;
        }

        private bool validaCamposRequeridos()
        {
            if (txtDescripcion.Text.Trim() == string.Empty | cmbHoraInicio.Text.Trim() == string.Empty | cmbHoraFin.Text.Trim() == string.Empty | cmbHoraFin.Text.Trim() == string.Empty | txtValorFicha.Text.Trim() == string.Empty | txtValorBandera.Text.Trim() == string.Empty)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Turno.");

                    if (string.IsNullOrEmpty(txtDescripcion.Text))
                        frmErrores.agregarError("Debe completar la descripción.");
                    if (int.Parse(cmbHoraFin.Text)<=int.Parse(cmbHoraInicio.Text))
                        frmErrores.agregarError("La hora de Fin no puede ser menor a la de Inicio.");
                    if (string.IsNullOrEmpty(txtValorFicha.Text))
                        frmErrores.agregarError("Debe especificar el valor de la ficha.");
                    if (string.IsNullOrEmpty(txtValorBandera.Text))
                        frmErrores.agregarError("Debe esepcificar el valor de bajada de bandera.");

                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pTurnoID = new SqlParameter("@pTurnoID", SqlDbType.Int);
                pTurnoID.Value = string.IsNullOrEmpty(turnoID) ? "0" : turnoID;
                SqlParameter pDescripcion = new SqlParameter("@pDescripcion", SqlDbType.VarChar, 255);
                pDescripcion.Value = txtDescripcion.Text;
                SqlParameter pHoraInicio = new SqlParameter("@pHoraInicio", SqlDbType.Int);
                pHoraInicio.Value = cmbHoraInicio.Text;
                SqlParameter pHoraFin = new SqlParameter("@pHoraFin", SqlDbType.Int);
                pHoraFin.Value = cmbHoraFin.Text;
                SqlParameter pValorFicha = new SqlParameter("@pValorFicha", SqlDbType.Float);
                pValorFicha.Value = txtValorFicha.Text.Replace(".",",");
                SqlParameter pValorBandera = new SqlParameter("@pValorBandera", SqlDbType.Float);
                pValorBandera.Value = txtValorBandera.Text.Replace(".", ",");
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                if (chkDeshabilitado.Checked)
                    pAnulado.Value = 1;
                else
                    pAnulado.Value = 0;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pTurnoID,pDescripcion,pHoraInicio,pHoraFin,pValorFicha,pValorBandera, pAnulado, pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearTurno", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El turno con descripción: " + txtDescripcion.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarTurno", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El turno con descripción: " + txtDescripcion.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtDescripcion.Text = "";
            txtValorFicha.Text = "";
            txtValorBandera.Text = "";
            cmbHoraInicio.Text = "";
            cmbHoraFin.Text = "";
            chkDeshabilitado.Checked = false;
        }
    }
}
