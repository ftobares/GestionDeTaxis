using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AsignacionChofer_AutoTurno
{
     public partial class addChofer_AutoTurno : Form
    {
        public long asignacionID { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addChofer_AutoTurno unicaInst = null;
        public static addChofer_AutoTurno Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addChofer_AutoTurno();
            }
            return unicaInst;
        }

        private addChofer_AutoTurno()
        {
            InitializeComponent();
        }

        private void addEditChofer_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
        }

        private void inicializarFormulario()
        {

            lblTitulo.Text = tituloPantalla;
            this.Text = tituloPantalla;

            if (modoAbm == "Editar")
            {
                getDatosRegistro(asignacionID);
            }
        }

        private void getDatosRegistro(long dniChofer)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select fecha, dniChofer, turnoID, patente from femig.ChoferAutoTurno where asignacionID = " + asignacionID);
            dtpNacimiento.Text = dtValores.Rows[0]["fecha"].ToString();
            textChofer.Text = dtValores.Rows[0]["dniChofer"].ToString();
            txtTurno.Text = dtValores.Rows[0]["turnoID"].ToString();
            txtAuto.Text = dtValores.Rows[0]["patente"].ToString();
        }

        private bool validaCamposRequeridos()
        {

            if (dtpNacimiento.Text == string.Empty || txtAuto.Text == string.Empty || textChofer.Text == string.Empty || txtTurno.Text == string.Empty)
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


                    frmErrores.ShowDialog();
                    frmErrores.Dispose();

                    return;
                }

                string retCatchError = string.Empty;

                SqlParameter pId_Asign = new SqlParameter("@pId_Asign", SqlDbType.Int);
                pId_Asign.Value = this.asignacionID;

                SqlParameter pNombre = new SqlParameter("@pFecha", SqlDbType.DateTime);
                pNombre.Value = dtpNacimiento.Text;
                SqlParameter pApellido = new SqlParameter("@pDniChofer", SqlDbType.Int);
                pApellido.Value = textChofer.Text;
                SqlParameter pDireccion = new SqlParameter("@pTurnoID", SqlDbType.Int);
                pDireccion.Value = txtTurno.Text;
                SqlParameter pTurno = new SqlParameter("@pPatente", SqlDbType.VarChar, 10);
                pTurno.Value = txtAuto.Text;
                /*SqlParameter pAnulado = new SqlParameter("@pAnulado", SqlDbType.Bit);
                pAnulado.Value = 0;*/
                SqlParameter pRetCatchError = new SqlParameter("@retCatchError", SqlDbType.VarChar, 1000);
                pRetCatchError.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pNombre, pApellido, pDireccion, pTurno, pRetCatchError };

                if (modoAbm == "Nuevo")
                {
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.crearChoferAutoTurno", parametros))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("Fue dato de alta exitosamente.", "Alta exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(pRetCatchError.Value.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    SqlParameter[] parametros2 = { pId_Asign, pNombre, pApellido, pTurno, pDireccion, pRetCatchError };
                    if (GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.editarChoferAutoTurno", parametros2))
                    {
                        if (string.IsNullOrEmpty(pRetCatchError.Value.ToString()))
                        {
                            MessageBox.Show("Fue dado de alta exitosamente.", "Edición exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //if (modoAbm == "Nuevo")
            //{
                txtAuto.Text = "";
                textChofer.Text = "";
                txtTurno.Text = "";
            //}
        }

        private void txtDniChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSeleccionarAuto_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.Buscador.Buscador frmBuscadorReloj = new GestorDeFlotasDesktop.Buscador.Buscador("patente");

            frmBuscadorReloj.campoRetorno = "patente";
            frmBuscadorReloj.Filtro1Text = "Marca:";
            frmBuscadorReloj.Filtro1Value = "marca";
            frmBuscadorReloj.Filtro2Text = "Modelo:";
            frmBuscadorReloj.Filtro2Value = "modelo";
            frmBuscadorReloj.nombreTabla = "femig.autos";
            frmBuscadorReloj.camposSelect = "patente, marca, modelo";
            frmBuscadorReloj.orderBy = "marca, modelo, patente";
            frmBuscadorReloj.whereObligatorio = "isnull(anulado,'0')='0'";

            if (frmBuscadorReloj.ShowDialog() == DialogResult.OK)
                txtAuto.Text = frmBuscadorReloj.valorRetorno;

            frmBuscadorReloj.Dispose();
        }

        private void btnSeleccionarChofer_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.Buscador.Buscador frmBuscadorReloj = new GestorDeFlotasDesktop.Buscador.Buscador("dniChofer");

            frmBuscadorReloj.campoRetorno = "dniChofer";
            frmBuscadorReloj.Filtro1Text = "Nombre:";
            frmBuscadorReloj.Filtro1Value = "nombre";
            frmBuscadorReloj.Filtro2Text = "Apellido:";
            frmBuscadorReloj.Filtro2Value = "apellido";
            frmBuscadorReloj.nombreTabla = "femig.choferes";
            frmBuscadorReloj.camposSelect = "dniChofer, nombre, apellido";
            frmBuscadorReloj.orderBy = "nombre, apellido, dniChofer";
            frmBuscadorReloj.whereObligatorio = "isnull(anulado,'0')='0'";

            if (frmBuscadorReloj.ShowDialog() == DialogResult.OK)
                textChofer.Text = frmBuscadorReloj.valorRetorno;

            frmBuscadorReloj.Dispose();
        }

        private void btnSeleccionarTurno_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.Buscador.Buscador frmBuscadorReloj = new GestorDeFlotasDesktop.Buscador.Buscador("turnoID");

            frmBuscadorReloj.campoRetorno = "turnoID";
            frmBuscadorReloj.Filtro1Text = "Hora Inicio:";
            frmBuscadorReloj.Filtro1Value = "horaInicio";
            //frmBuscadorReloj.Filtro2Text = "Hora Fin:";
            //frmBuscadorReloj.Filtro2Value = "horaFin";
            frmBuscadorReloj.nombreTabla = "femig.turnos";
            frmBuscadorReloj.camposSelect = "turnoID, horaInicio, horaFin";
            frmBuscadorReloj.orderBy = "horaInicio, turnoID";
            frmBuscadorReloj.whereObligatorio = "isnull(anulado,'0')='0'";

            if (frmBuscadorReloj.ShowDialog() == DialogResult.OK)
                txtTurno.Text = frmBuscadorReloj.valorRetorno;

            frmBuscadorReloj.Dispose();
        }

    }
}
