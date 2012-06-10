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
        public AltaModifCli()
        {
            InitializeComponent();
        }
        private bool controlarCamposCompletos()
        {
            if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.txtDNI.Text == string.Empty
                    || this.txtTel.Text == string.Empty || this.txtCalle.Text == string.Empty || this.txtNumCalle.Text == string.Empty
                        || this.txtLocalidad.Text == string.Empty || this.txtFchNac.Text == string.Empty)
                return true;
            else
                return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.te
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
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
                this.txtNumCalle.Focus();
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
                this.txtCP.Focus();
            }
        }

        private void txtCP_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.button3.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar1.Visible = false;
            this.txtFchNac.Text = this.monthCalendar1.SelectionEnd.ToShortDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtNombre.Text = ""; this.txtApellido.Text = "" ; this.txtDNI.Text = "";
                this.txtTel.Text = ""; this.txtCalle.Text = ""; this.txtNumCalle.Text = "";
                    this.txtPiso.Text = ""; this.txtDpto.Text = ""; this.txtLocalidad.Text = "";
                        this.txtCP.Text = ""; this.txtFchNac.Text = ""; this.txtMail.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (controlarCamposCompletos())
                {
                    MessageBox.Show("Debe completar todos los campos obligatorios.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //TODO: modificar este query dependiendo la cunsulta.
                string sCheckAnuklado = "0";
                if (checkBox1.Checked)
                    sCheckAnuklado = "1";

                string sQuery = "INSERT INTO FEMIG.Cliente VALUES (" + this.txtDNI.Text + ",'" + this.txtNombre.Text
                    + "','" + this.txtApellido.Text + "'," + this.txtTel.Text + ",'LOC{" + this.txtLocalidad.Text + "} CP{" + this.txtCP.Text + "} " + this.txtCalle.Text + " "
                        + this.txtNumCalle.Text + " PISO{" + this.txtPiso.Text + "} DPTO{" + this.txtDpto.Text + "}',";
                if (this.txtMail.Text==string.Empty)
                    sQuery += "NULL";
                else
                    sQuery += "'" + this.txtMail.Text + "'";
                sQuery += ",'" + this.txtFchNac.Text + "','" + sCheckAnuklado + "')";
                DataTable dtResult = new DataTable();
                dtResult = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(sQuery);
                if(dtResult!= null)
                    MessageBox.Show("Se dio de Alta al cliente correctamente.", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
