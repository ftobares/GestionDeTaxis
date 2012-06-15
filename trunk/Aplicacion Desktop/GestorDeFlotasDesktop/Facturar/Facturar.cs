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
        public string dniCliente { get; set; }
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
            /*
            string strQuery = "select " + camposSelect + " from " + nombreTabla + " where 1=1";
            if (!string.IsNullOrEmpty(whereObligatorio))
                strQuery += " and " + whereObligatorio;
            if (!string.IsNullOrEmpty(txtPatente.Text))
                strQuery += " and cast(" + filtro1Value + " as varchar) like '%" + txtPatente.Text + "%'";
            if (!string.IsNullOrEmpty(txtMarca.Text))
                strQuery += " and cast(" + filtro2Value + " as varchar) like '%" + txtMarca.Text + "%'";
            if (!string.IsNullOrEmpty(txtModelo.Text))
                strQuery += " and cast(" + filtro3Value + " as varchar) like '%" + txtModelo.Text + "%'";
            if (!string.IsNullOrEmpty(txtReloj.Text))
                strQuery += " and cast(" + filtro4Value + " as varchar) like '%" + txtReloj.Text + "%'";
            if (!string.IsNullOrEmpty(txtLicencia.Text))
                strQuery += " and cast(" + filtro5Value + " as varchar) like '%" + txtLicencia.Text + "%'";
            strQuery += " order by " + consultaOrderBy;
            
            return strQuery;*/
            return "";
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgFacturas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
            /*
            string leyendaFiltrosInicial = "Filtros Aplicados: ";
            string leyendaFiltros = "";
            if (!string.IsNullOrEmpty(txtPatente.Text))
                leyendaFiltros += filtro1Text + " " + txtPatente.Text;
            if (!string.IsNullOrEmpty(txtMarca.Text))
                leyendaFiltros += ", " + filtro2Text + " " + txtMarca.Text;
            if (!string.IsNullOrEmpty(txtModelo.Text))
                leyendaFiltros += ", " + filtro3Text + " " + txtModelo.Text;
            if (!string.IsNullOrEmpty(txtReloj.Text))
                leyendaFiltros += ", " + filtro4Text + " " + txtReloj.Text;
            if (!string.IsNullOrEmpty(txtLicencia.Text))
                leyendaFiltros += ", " + filtro5Text + " " + txtLicencia.Text;

            if (string.IsNullOrEmpty(leyendaFiltros))
                lblFiltro.Text = "No se seleccionó ningún filtro.";
            else
                lblFiltro.Text = leyendaFiltrosInicial + leyendaFiltros;*/
        }

        private void inicializarFormulario()
        {
            txtCliente.Text = "";
            txtImporte.Text = "";

            /*if (modoAbm == "Editar")
            {

                getDatosRegistro(patenteAuto);
                mtxtPatente.ReadOnly = true;
            }*/
        }

        private bool validaCamposRequeridos()
        {

            if (txtCliente.Text.Trim() == string.Empty || txtImporte.Text.Trim() == string.Empty || dtpFecha.Text.Trim() == string.Empty || dtpFechaFin.Text.Trim() == string.Empty)
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
                    if (string.IsNullOrEmpty(txtImporte.Text))
                        frmErrores.agregarError("Debe ingresar el importe");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha Inicial de Facturacion.");
                    if (string.IsNullOrEmpty(dtpFecha.Text))
                        frmErrores.agregarError("Debe especificar la Fecha Final de Facturacion.");
                    
                    frmErrores.ShowDialog();
                    frmErrores.Dispose();
                    
                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pFecha = new SqlParameter("@pFechaInicial", SqlDbType.DateTime);
                pFecha.Value = dtpFecha.Text;
                SqlParameter pFechaFin = new SqlParameter("@pFechaFinal", SqlDbType.DateTime);
                pFechaFin.Value = dtpFecha.Text;
                SqlParameter pCliente = new SqlParameter("@pDniCliente", SqlDbType.BigInt);
                pCliente.Value = txtCliente.Text;
                SqlParameter pImporteTotal = new SqlParameter("@pImporteTotal", SqlDbType.Float);
                pImporteTotal.Value = txtImporte.Text;
                pImporteTotal.Direction = ParameterDirection.Output;
                
                SqlParameter pRetCatchError = new SqlParameter("@pRetCatchError", SqlDbType.VarChar,1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pFecha, pFechaFin, pCliente, pImporteTotal, pRetCatchError };

                //if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearFacturacion", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("Se dio de Alta la Facturacion correctamente", "OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
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
