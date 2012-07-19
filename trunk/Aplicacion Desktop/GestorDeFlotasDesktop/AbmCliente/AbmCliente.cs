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
                return true;
            else
                return true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            mostrarClientes();
        }

        private void AbmCliente_Load(object sender, EventArgs e)
        {
            try
            {
                string sQuery = cargarQuery();
                DataSet dsResultados = new DataSet();
                dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                dataGridView1.RowHeadersVisible = true;
                colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count;
                colMofificar.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDeFlotasDesktop.AbmCliente.AltaModifCli altaModifCliente = GestorDeFlotasDesktop.AbmCliente.AltaModifCli.Instance();
                altaModifCliente.modoAbm = "Nuevo";
                altaModifCliente.ShowDialog();
                string sQuery = cargarQuery();
                DataSet dsResultados = new DataSet();
                dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                dataGridView1.RowHeadersVisible = true;
                colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count;
                colMofificar.Visible = true;
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

        private string cargarQuery()
        {
            //TODO: modificar este query dependiendo la cunsulta.
            string sQuery = "SELECT * FROM FEMIG.Clientes where 1 = 1 ";
            if (txtNombre.Text != string.Empty)
            {
                sQuery += "AND nombre like '" + txtNombre.Text + "%'";
                //if (txtApellido.Text != string.Empty || txtDNI.Text != string.Empty)
                   // sQuery += " AND ";
            }
            if (txtApellido.Text != string.Empty)
            {
                sQuery += "AND apellido like '" + txtApellido.Text + "%'";
                //if (txtDNI.Text != string.Empty)
                    //sQuery += " AND ";
            }
            if (txtDNI.Text != string.Empty)
                sQuery += "AND dniCliente = " + txtDNI.Text;
            //sQuery += " AND anulado = 0";
            return sQuery;
        }

        private void mostrarClientes()
        {
            try
            {
                if (!controlarCamposCompletos())
                {
                    MessageBox.Show("Debe completar al menos un campo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string sQuery = cargarQuery();
                DataSet dsResultados = new DataSet();
                dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                dataGridView1.RowHeadersVisible = true;
                colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count;
                colMofificar.Visible = true;
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
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0) //Assuming the button column as second column, if not can change the index
            {
                GestorDeFlotasDesktop.AbmCliente.AltaModifCli altaModifCliente = GestorDeFlotasDesktop.AbmCliente.AltaModifCli.Instance();
                altaModifCliente.modoAbm = "Editar";
                altaModifCliente.dniCliente = dataGridView1.Rows[e.RowIndex].Cells["dniCliente"].Value.ToString();
                
                altaModifCliente.ShowDialog();
                string sQuery = cargarQuery();
                DataSet dsResultados = new DataSet();
                dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                dataGridView1.RowHeadersVisible = true;
                colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count;
                colMofificar.Visible = true;
            }
            string sCheck = dataGridView1.Rows[e.RowIndex].Cells["anulado"].Value.ToString();
            if (e.ColumnIndex == dataGridView1.ColumnCount - 1 && sCheck == "False")
            {
                if (MessageBox.Show("¿Esta seguro que deséa eliminar este Cliente?", "Confirmación de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {    
                    string sCheckAnuklado = "1";

                    string sQuery = "UPDATE FEMIG.Clientes SET anulado ='" + sCheckAnuklado + "' WHERE dniCliente = " + dataGridView1.Rows[e.RowIndex].Cells["dniCliente"].Value.ToString();
                    DataTable dtResult = new DataTable();
                    dtResult = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(sQuery);
                    if (dtResult != null)
                        MessageBox.Show("Se Elimino al cliente correctamente.", "Datos Insertados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    sQuery = cargarQuery();
                    DataSet dsResultados = new DataSet();
                    dsResultados = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery_DS(sQuery);
                    dataGridView1.DataSource = dsResultados.Tables["Tabla"];
                    dataGridView1.RowHeadersVisible = true;
                    colMofificar.DisplayIndex = dsResultados.Tables["Tabla"].Columns.Count;
                    colMofificar.Visible = true;
                }

            }
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
