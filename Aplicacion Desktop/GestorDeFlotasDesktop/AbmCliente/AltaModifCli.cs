using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.AbmCliente
{
    public partial class AltaModifCli : Form
    {
        public string dniCliente { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static AltaModifCli unicaInst = null;
        public static AltaModifCli Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AltaModifCli();
            }
            return unicaInst;
        }

        private AltaModifCli()
        {
            InitializeComponent();
        }

        private bool controlarCamposCompletos()
        {
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtDNI.Text == string.Empty
                    || this.txtTel.Text == string.Empty || this.txtCalle.Text == string.Empty
                        || this.txtLocalidad.Text == string.Empty || this.txtFchNac.Text == string.Empty)
                return true;
            else
                return false;
        }

        private void inicializarFormulario()
        {
            limpiarCampos();
            this.txtDNI.ReadOnly = false;
            this.label15.Visible = false;

            if (modoAbm == "Editar")
            {

                getDatosRegistro(dniCliente);
                this.txtDNI.ReadOnly = true;
                this.label15.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializarFormulario();
            monthCalendar1.Visible = false;
        }
    
        private void txtNombre_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtApellido.Focus();
            }
        }

        private void txtApellido_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtDNI.Focus();
            }
        }

        private void txtDNI_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtMail.Focus();
            }
        }

        private void txtMail_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtTel.Focus();
            }
        }

        private void txtTel_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtCalle.Focus();
            }
        }

        private void txtCalle_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtCP.Focus();
            }
        }

        private void txttxtNumCalle_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtPiso.Focus();
            }
        }

        private void txtPiso_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtDpto.Focus();
            }
        }

        private void txtDpto_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtLocalidad.Focus();
            }
        }

        private void txtLocalidad_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtNumCalle.Focus();
            }
        }

        private void txtCP_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.button3.Focus();
            }
        }

        private void limpiarCampos()
        {
            if(modoAbm=="Nuevo")
                this.txtDNI.Text = "";
            this.txtNombre.Text = ""; this.txtApellido.Text = "";
            this.txtTel.Text = ""; this.txtCalle.Text = ""; this.txtCP.Text = "";
            this.txtPiso.Text = ""; this.txtDpto.Text = ""; this.txtLocalidad.Text = "";
            this.txtNumCalle.Text = ""; this.txtFchNac.Text = ""; this.txtMail.Text = "";
            this.txtMail.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar1.Visible = false;
            this.txtFchNac.Text = this.monthCalendar1.SelectionEnd.ToString("yyyy/MM/dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
            monthCalendar1.BringToFront();
        }

        private void getDatosRegistro(string dniCliente)
        {
            DataTable dtValores = new DataTable();
            dtValores = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery("Select dniCliente, nombre, apellido, telefono, direccion, email, fechaNacimiento from femig.clientes where dniCliente = '" + dniCliente + "'");
            txtDNI.Text = dtValores.Rows[0]["dniCliente"].ToString();
            txtNombre.Text = dtValores.Rows[0]["nombre"].ToString();
            txtApellido.Text = dtValores.Rows[0]["apellido"].ToString();
            txtTel.Text = dtValores.Rows[0]["telefono"].ToString();
            string sDir = dtValores.Rows[0]["direccion"].ToString() + "|||||";
            string[] strDir = sDir.Split('|');
            txtCalle.Text = "";  txtNumCalle.Text = ""; txtPiso.Text = ""; txtDpto.Text = ""; txtLocalidad.Text = ""; txtCP.Text = "";
            txtCalle.Text = strDir[0];
            if (strDir.Length > 1)
            {
                txtNumCalle.Text = strDir[1];
                txtPiso.Text = strDir[2];
                txtDpto.Text = strDir[3];
                txtLocalidad.Text = strDir[4];
                txtCP.Text = strDir[5];
            }
            txtMail.Text = dtValores.Rows[0]["email"].ToString();
            txtFchNac.Text = dtValores.Rows[0]["fechaNacimiento"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (controlarCamposCompletos())
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //TODO: modificar este query dependiendo la cunsulta.
                /*string sCheckAnuklado = "0";
                if (checkBox1.Checked)
                    sCheckAnuklado = "1";*/
                if (this.modoAbm == "Nuevo")
                {
                    string sCheckAnulado = "0";
                    string sQuery = "SELECT * FROM FEMIG.Clientes where 1 = 1 and telefono = " + this.txtTel.Text+"";
                    DataSet dsResultados = new DataSet();
                    dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                    if (dsResultados.Tables["Tabla"].Rows.Count > 0)
                    {
                        MessageBox.Show("Telefono ya ingresado, no se dará de alta al cliente", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    sQuery = "INSERT INTO FEMIG.Clientes VALUES (" + this.txtDNI.Text + ",'" + this.txtNombre.Text
                        + "','" + this.txtApellido.Text + "'," + this.txtTel.Text + ",'" + this.txtCalle.Text + "|" + this.txtNumCalle.Text + "|"
                            + this.txtPiso.Text + "|" + this.txtDpto.Text + "|" + this.txtLocalidad.Text + "|" + this.txtCP.Text + "',";
                    /*if (this.txtMail.Text == string.Empty)
                        sQuery += "NULL";
                    else*/
                        sQuery += "'" + this.txtMail.Text + "'";
                    sQuery += ",'" + this.txtFchNac.Text.Replace("/","") + "','" + sCheckAnulado + "')";
                    DataTable dtResult = new DataTable();
                    dtResult = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(sQuery);
                    if (dtResult != null)
                    {
                        MessageBox.Show("Se dio de Alta al cliente correctamente.", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                    }
                }
                else
                {
                    string sCheckAnuklado = "0";
                    string sQuery = "UPDATE FEMIG.Clientes SET nombre = '" + txtNombre.Text + "', apellido = '" + this.txtApellido.Text + "', telefono = "
                        + this.txtTel.Text + ", direccion = '" + this.txtCalle.Text + "|" + this.txtNumCalle.Text + "|" + this.txtPiso.Text + "|" + this.txtDpto.Text + "|"
                            + this.txtLocalidad.Text + "|" + this.txtCP.Text + "', email = ";
                    if (this.txtMail.Text == string.Empty)
                        sQuery += "NULL";
                    else
                        sQuery += "'" + this.txtMail.Text + "'";
                    sQuery += ",fechaNacimiento = '" + this.txtFchNac.Text.Substring(0,10) + "', anulado ='" + sCheckAnuklado + "' WHERE dniCliente = " + this.txtDNI.Text;
                    DataTable dtResult = new DataTable();
                    dtResult = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(sQuery);
                    if (dtResult != null)
                    {
                        MessageBox.Show("Se habilito y edito al cliente correctamente.", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
