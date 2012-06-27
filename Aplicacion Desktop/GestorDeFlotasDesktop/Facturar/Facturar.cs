using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.Facturar
{
    public partial class Facturar : Form
    {
        public string codFactura { get; set; }
        public string tituloPantalla { get; set; }
        private static Facturar unicaInst = null;
        public static Facturar Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new Facturar();
            }
            return unicaInst;
        }

        private Facturar()
        {
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
            //cargarQuery();
        }

        private string construirQuery()
        {
            string strQuery = "select " + "*" + " from " + "femig.viajes" + " where 1=1";
            strQuery += " AND codFactura = " + codFactura; //+" order by " + "importeTotal";
            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgFacturas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }

        private void inicializarFormulario()
        {
            txtCliente.Text = "";
            txtImporte.Text = "";
            txtImporte.Visible = false;
        }

        private bool validaCamposRequeridos()
        {

            if (txtCliente.Text.Trim() == string.Empty || txtCliente.Text == "0" || dtpFecha.Text.Trim() == string.Empty || dtpFechaFin.Text.Trim() == string.Empty)
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

                    if (string.IsNullOrEmpty(txtCliente.Text))
                        frmErrores.agregarError("Debe ingresar el DNI del Cliente.");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha Inicial de Facturacion.");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha Final de Facturacion.");
                    
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pFecha = new SqlParameter("@pFechaInicio", SqlDbType.DateTime);
                pFecha.Value = dtpFecha.Text;
                SqlParameter pFechaFin = new SqlParameter("@pFechaFin", SqlDbType.DateTime);
                pFechaFin.Value = dtpFechaFin.Text;
                SqlParameter pCliente = new SqlParameter("@pDniCliente", SqlDbType.BigInt);
                pCliente.Value = txtCliente.Text;

                SqlParameter pImporteTotal = new SqlParameter("@pImporteTotal", SqlDbType.Float);
                pImporteTotal.Direction = ParameterDirection.Output;
                SqlParameter pCodFactura = new SqlParameter("@pCodFactura", SqlDbType.BigInt);
                pCodFactura.Direction = ParameterDirection.Output;
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pFecha, pFechaFin, pCliente, pImporteTotal, pCodFactura, pRetCatchError };

                //if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearFacturacion", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            txtImporte.Text = pImporteTotal.Value.ToString();
                            txtImporte.Visible = true;
                            codFactura = pCodFactura.Value.ToString();
                            MessageBox.Show("Se dio de Alta la Facturacion correctamente", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.codFactura= pCodFactura.Value.ToString();
                            cargarQuery();
                            dgFacturas.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            dgFacturas.Visible = false;
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
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //if (modoAbm=="Nuevo")
                //mtxtPatente.Text = "";

            txtCliente.Text = "";
            txtImporte.Text = "";
        }

    }
}
