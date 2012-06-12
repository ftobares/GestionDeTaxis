using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmReloj
{
    public partial class addEditReloj : Form
    {
        public string nroSerieReloj { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditReloj unicaInst = null;
        public static addEditReloj Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditReloj();
            }
            return unicaInst;
        }

        private addEditReloj()
        {
            InitializeComponent();
        }

        private void addEditReloj_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            txtNroSerieReloj.Text = "";
            txtModelo.Text = "";
            txtMarca.Text = "";
            dtpVersion.Value = DateTime.Today;
            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {
                getDatosRegistro(nroSerieReloj);
                txtNroSerieReloj.ReadOnly = true;
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select nroSerieReloj, marca, modelo, fechaVersion from femig.relojes where nroSerieReloj = '" + nroSerieReloj + "'");
            txtNroSerieReloj.Text = dtValores.Rows[0]["nroSerieReloj"].ToString();
            txtMarca.Text = dtValores.Rows[0]["marca"].ToString();
            txtModelo.Text = dtValores.Rows[0]["modelo"].ToString();
            dtpVersion.Value = DateTime.Parse(dtValores.Rows[0]["fechaVersion"].ToString());
        }

        private bool validaCamposRequeridos()
        {

            if (txtNroSerieReloj.Text.Trim() == string.Empty | txtMarca.Text.Trim() == string.Empty | txtModelo.Text.Trim() == string.Empty | dtpVersion.Value > DateTime.Today)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Reloj.");

                    if (string.IsNullOrEmpty(txtNroSerieReloj.Text))
                        frmErrores.agregarError("Debe completar el Número de Serie del Reloj.");
                    if (string.IsNullOrEmpty(txtMarca.Text))
                        frmErrores.agregarError("Debe completar la marca del reloj.");
                    if (string.IsNullOrEmpty(txtModelo.Text))
                        frmErrores.agregarError("Debe completar el modelo del reloj.");
                    if (dtpVersion.Value>DateTime.Today)
                        frmErrores.agregarError("Debe ingresar una fecha menor o igual a hoy.");
                  
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pNroSerieReloj = new SqlParameter("@pNroSerieReloj", SqlDbType.BigInt);
                pNroSerieReloj.Value = txtNroSerieReloj.Text;
                SqlParameter pMarca = new SqlParameter("@pMarca", SqlDbType.VarChar, 255);
                pMarca.Value = txtMarca.Text;
                SqlParameter pModelo = new SqlParameter("@pModelo", SqlDbType.VarChar, 255);
                pModelo.Value = txtModelo.Text;
                SqlParameter pFechaVencimiento = new SqlParameter("@pFechaVersion", SqlDbType.DateTime);
                pFechaVencimiento.Value = dtpVersion.Value;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                pAnulado.Value = 0;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pNroSerieReloj, pMarca, pModelo, pFechaVencimiento,pAnulado,pRetCatchError};

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearReloj", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El reloj con la serie: " + txtNroSerieReloj.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarReloj", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El reloj con la serie: " + txtNroSerieReloj.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtNroSerieReloj.Text = "";

            txtMarca.Text = "";
            txtModelo.Text = "";
            dtpVersion.Value = DateTime.Today;
        }

        private void txtNroSerieReloj_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
