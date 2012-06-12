using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            //inicializarFormulario();
        }

        /*private void inicializarFormulario()
        {
            mtxtPatente.Text = "";
            cargarMarcas();
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            txtReloj.Text = "";
            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(patenteAuto);
                mtxtPatente.ReadOnly = true;
            }
        }

        private void getDatosRegistro(string patente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select patente, marca, modelo, licencia, rodado, nroSerieReloj from femig.autos where patente = '" + patente + "'");
            mtxtPatente.Text = dtValores.Rows[0]["patente"].ToString();
            cmbMarca.Text = dtValores.Rows[0]["marca"].ToString();
            txtModelo.Text = dtValores.Rows[0]["modelo"].ToString();
            txtLicencia.Text = dtValores.Rows[0]["licencia"].ToString();
            txtReloj.Text = dtValores.Rows[0]["nroSerieReloj"].ToString();
            txtLicencia.Text = dtValores.Rows[0]["licencia"].ToString();
            txtRodado.Text = dtValores.Rows[0]["rodado"].ToString();
        }

        private void cargarMarcas()
        {
            string strQuery = "Select marca from FEMIG.marcas_autos order by marca";
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
                    GestorDeFlotasDesktop.ListaErrores.ListaErrores frmErrores = new GestorDeFlotasDesktop.ListaErrores.ListaErrores();

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar crear el nuevo Auto.");

                    if (string.IsNullOrEmpty(mtxtPatente.Text) | !mtxtPatente.MaskFull)
                        frmErrores.agregarError("Debe completar la patente de 6 caracteres/dígitos.");
                    if (string.IsNullOrEmpty(cmbMarca.Text))
                        frmErrores.agregarError("Debe seleccionar la marca del auto.");
                    if (string.IsNullOrEmpty(txtModelo.Text))
                        frmErrores.agregarError("Debe especificar el modelo del auto.");
                    if (string.IsNullOrEmpty(txtLicencia.Text))
                        frmErrores.agregarError("Debe ingresar la Licencia del auto.");
                    if (string.IsNullOrEmpty(txtRodado.Text))
                        frmErrores.agregarError("Debe especificar el rodado del auto.");
                    if (string.IsNullOrEmpty(txtReloj.Text))
                        frmErrores.agregarError("Debe especificar el reloj asociado al auto.");

                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pPatente = new SqlParameter("@pPatente", SqlDbType.VarChar, 10);
                pPatente.Value = mtxtPatente.Text;
                SqlParameter pMarca = new SqlParameter("@pMarca", SqlDbType.VarChar, 255);
                pMarca.Value = cmbMarca.Text;
                SqlParameter pModelo = new SqlParameter("@pModelo", SqlDbType.VarChar, 255);
                pModelo.Value = txtModelo.Text;
                SqlParameter pLicencia = new SqlParameter("@pLicencia", SqlDbType.VarChar, 26);
                pLicencia.Value = txtLicencia.Text;
                SqlParameter pRodado = new SqlParameter("@pRodado", SqlDbType.VarChar, 10);
                pRodado.Value = txtRodado.Text;
                SqlParameter pNroSerieReloj = new SqlParameter("@pNroSerieReloj", SqlDbType.Int);
                pNroSerieReloj.Value = txtReloj.Text;
                SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                pAnulado.Value = 0;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pPatente, pMarca, pModelo, pLicencia, pRodado, pNroSerieReloj, pAnulado, pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearAuto", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El auto con patente: " + mtxtPatente.Text + " fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarAuto", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("El auto con patente: " + mtxtPatente.Text + " fue editado exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSeleccionarReloj_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.Buscador.Buscador frmBuscadorReloj = new GestorDeFlotasDesktop.Buscador.Buscador();

            frmBuscadorReloj.campoRetorno = "nroSerieReloj";
            frmBuscadorReloj.Filtro1Text = "Marca:";
            frmBuscadorReloj.Filtro1Value = "marca";
            frmBuscadorReloj.Filtro2Text = "Modelo:";
            frmBuscadorReloj.Filtro2Value = "modelo";
            frmBuscadorReloj.nombreTabla = "femig.relojes";
            frmBuscadorReloj.camposSelect = "nroSerieReloj, marca, modelo, fechaVersion";
            frmBuscadorReloj.orderBy = "marca, modelo, nroSerieReloj";
            frmBuscadorReloj.whereObligatorio = "isnull(anulado,'0')='0'";

            if (frmBuscadorReloj.ShowDialog() == DialogResult.OK)
                txtReloj.Text = frmBuscadorReloj.valorRetorno;

            frmBuscadorReloj.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (modoAbm=="Nuevo")
                mtxtPatente.Text = "";
            
            cmbMarca.Text = "";
            txtModelo.Text = "";
            txtLicencia.Text = "";
            txtRodado.Text = "";
            txtReloj.Text = "";
        }
    */
    }
}
