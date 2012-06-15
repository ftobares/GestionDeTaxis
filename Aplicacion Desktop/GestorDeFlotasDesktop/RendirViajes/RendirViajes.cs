using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.RendirViajes
{
    public partial class RendirViajes : Form
    {
        public string codRendicion { get; set; }
        public string tituloPantalla { get; set; }
        private static RendirViajes unicaInst = null;
        public static RendirViajes Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new RendirViajes();
            }
            return unicaInst;
        }

        private RendirViajes()
        {
            InitializeComponent();
        }

        private void RendirViajes_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
            //cargarQuery();
        }

        private string construirQuery()
        {
            string strQuery = "select " + "*" + " from " + "femig.Rendiciones" + " where 1=1";
                strQuery += " AND codRendicion = " + codRendicion + " order by " + "importeTotal";
            
            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgRendicion.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }

        private void inicializarFormulario()
        {
            txtChofer.Text = "";
            txtChofer.Text = "";
            txtTurno.Text = "";
            txtImporte.Text = "";
            txtImporte.Visible = false;

        }

        private bool validaCamposRequeridos()
        {

            if ( txtChofer.Text.Trim() == string.Empty || txtTurno.Text.Trim() == string.Empty || txtImporte.Text.Trim() == string.Empty || dtpFecha.Text.Trim() == string.Empty )
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

                    if (string.IsNullOrEmpty(txtChofer.Text))
                        frmErrores.agregarError("Debe ingresar el DNI del Chofer.");
                    if (string.IsNullOrEmpty(txtTurno.Text))
                        frmErrores.agregarError("Debe ingresar el Id del Turno.");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha del Viaje.");
                    
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pFecha = new SqlParameter("@pFecha", SqlDbType.DateTime);
                pFecha.Value = dtpFecha.Text;
                SqlParameter pChofer = new SqlParameter("@pDniChofer", SqlDbType.BigInt);
                pChofer.Value = txtChofer.Text;
                SqlParameter pTurno = new SqlParameter("@pTurnoID", SqlDbType.VarChar,20); //TODO: revisar el tipo
                pTurno.Value = txtTurno.Text;

                SqlParameter pImporteTotal = new SqlParameter("@pImporteTotal", SqlDbType.Float);
                pImporteTotal.Direction = ParameterDirection.Output;
                SqlParameter pCodRendicion = new SqlParameter("@pCodRendicion", SqlDbType.Float);
                pCodRendicion.Direction = ParameterDirection.Output;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pFecha, pChofer, pTurno, pImporteTotal, pCodRendicion, pRetCatchError };

                //if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearRendicion", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            txtImporte.Text = pImporteTotal.Value.ToString();
                            txtImporte.Visible = true;
                            codRendicion = pCodRendicion.Value.ToString();
                            MessageBox.Show("Se dio de Alta La Rendicion correctamente", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            dgRendicion.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgRendicion.Visible = false;
                        }

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

            txtChofer.Text = "";
            txtTurno.Text = "";
            txtImporte.Text = "";
        }

    }
}
