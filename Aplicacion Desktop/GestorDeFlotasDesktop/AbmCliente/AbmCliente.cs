using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace GestorDeFlotasDesktop.AbmCliente
{
    public partial class AbmCliente : Form
    {
        private static AbmCliente unicaInst = null;
        public static AbmCliente Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmCliente();
            }
            return unicaInst;
        }

        private AbmCliente()
        {
            InitializeComponent();
        }

        private bool controlarCamposCompletos()
        {
            if (this.txtNombre.Text == string.Empty && this.txtApellido.Text == string.Empty && this.txtDNI.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            mostrarClientes();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.AbmCliente.AltaModifCli altaModifCliente = new GestorDeFlotasDesktop.AbmCliente.AltaModifCli();
            altaModifCliente.Show();
        }

        private void mostrarClientes()
        {
            try
            {
                DataSet dsResultados = new DataSet();

                if (!controlarCamposCompletos())
                {
                    MessageBox.Show("Debe completar al menos un campo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //TODO: modificar este query dependiendo la cunsulta.
                string sQuery = "SELECT * FROM FEMIG.Cliente where ";
                if (txtNombre.Text != string.Empty)
                {
                    sQuery += "nombre like '" + txtNombre.Text + "%'";
                    if (txtApellido.Text != string.Empty || txtDNI.Text != string.Empty)
                        sQuery += " AND ";
                }
                if (txtApellido.Text != string.Empty)
                {
                    sQuery += "apellido like '" + txtApellido.Text + "%'";
                    if(txtDNI.Text!=string.Empty)
                        sQuery += " AND ";
                }
                if (txtDNI.Text != string.Empty)
                    sQuery += "dniCliente = " + txtDNI.Text;

                dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                dataGridView1.RowHeadersVisible = true;
                colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count+1;
                colMofificar.Visible = true;
                colEliminar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count+1;
                colEliminar.Visible = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int iIndex = e.RowIndex;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buttonBuscar.Focus();
            }
        }

        private void txtApellido_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buttonBuscar.Focus();
            }
        }

        private void txtDNI_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buttonBuscar.Focus();
            }
        }
    }
}
