using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.RegistrarViaje
{
    public partial class RegistrarViajes : Form
    {
        public string patenteAuto { get; set; }
        public string tituloPantalla { get; set; }
        private static RegistrarViajes unicaInst = null;
        public static RegistrarViajes Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new RegistrarViajes();
            }
            return unicaInst;
        }

        private RegistrarViajes()
        {
            InitializeComponent();
        }

        private void RegistrarViajes_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {
            cmbViaje.Text = "";
            cargarViaje();
            txtChofer.Text = "";
            txtCliente.Text = "";
            txtCliente.Hide();
            label6.Hide();
            txtFichas.Text = "";
            txtTurno.Text = "";

            /*if (modoAbm == "Editar")
            {

                getDatosRegistro(patenteAuto);
                mtxtPatente.ReadOnly = true;
            }*/
        }


        private void cargarViaje()
        {
            
        }

        private bool validaCamposRequeridos()
        {

            if (cmbViaje.Text.ToString() == string.Empty || txtChofer.Text.Trim() == string.Empty || txtFichas.Text.Trim() == string.Empty || txtTurno.Text.Trim() == string.Empty || dtpFecha.Text.Trim() == string.Empty || dtHora.Text.Trim() == string.Empty)
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

                    frmErrores.setTitulo("Ocurrieron algunos errores al intentar dar de alta el Viaje");

                    if (string.IsNullOrEmpty(cmbViaje.Text))
                        frmErrores.agregarError("Debe seleccionar el Tipo de Viaje");
                    if (string.IsNullOrEmpty(txtChofer.Text))
                        frmErrores.agregarError("Debe ingresar el DNI del Chofer.");
                    if (string.IsNullOrEmpty(txtTurno.Text))
                        frmErrores.agregarError("Debe ingresar el Id del Turno.");
                    if (string.IsNullOrEmpty(txtFichas.Text))
                        frmErrores.agregarError("Debe ingresar la Cantidad de Fichas");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha del Viaje.");
                    if (string.IsNullOrEmpty(dtHora.Text))
                        frmErrores.agregarError("Debe especificar la Hora del Viaje.");
                    if(cmbViaje.Text=="registrado")
                        if (string.IsNullOrEmpty(txtCliente.Text))
                            frmErrores.agregarError("Debe especificar el DNI del Cliente.");
                    
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pTipo = new SqlParameter("@pTipoViaje", SqlDbType.VarChar, 10);
                pTipo.Value = cmbViaje.Text;
                SqlParameter pChofer = new SqlParameter("@pDniChofer", SqlDbType.BigInt);
                pChofer.Value = txtChofer.Text;
                SqlParameter pTurno = new SqlParameter("@pTurnoID", SqlDbType.BigInt);
                pTurno.Value = txtTurno.Text;
                SqlParameter pCantFichas = new SqlParameter("@pCantFichas", SqlDbType.BigInt);
                pCantFichas.Value = txtFichas.Text;
                SqlParameter pFchHora = new SqlParameter("@pFecha", SqlDbType.DateTime);
                pFchHora.Value = dtpFecha.Text + " " + dtHora.Value.ToString("HH:mm");
                SqlParameter pCliente = new SqlParameter("@pDniCliente", SqlDbType.BigInt);
                pCliente.Value = txtCliente.Text;
                if (txtCliente.Text == "")    
                    pCliente.Value = 0;
                
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = {pTipo, pChofer, pTurno, pCantFichas, pFchHora, pCliente, pRetCatchError };

                //if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearViaje", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("Se dio de Alta al Viaje correctamente","OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            cmbViaje.Text = "";
                            txtChofer.Text = "";
                            txtCliente.Text = "";
                            txtFichas.Text = "";
                            txtTurno.Text = "";
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
               /* else
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
                }*/

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
            //if (modoAbm=="Nuevo")
                //mtxtPatente.Text = "";
            
            cmbViaje.Text = "";
            txtChofer.Text = "";
            txtCliente.Text = "";
            txtFichas.Text = "";
            txtTurno.Text = "";
        }

        private void cmbViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbViaje.Text == "calle")
            {
                label6.Hide();
                txtCliente.Hide();
            }
            else
            {
                label6.Show();
                txtCliente.Show();
            }
        }
    }
}
