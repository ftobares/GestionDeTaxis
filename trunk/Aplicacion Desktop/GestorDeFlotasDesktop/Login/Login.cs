using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                lblEstado.Text = "Estableciendo conexión...";
                lblEstado.Visible = true;
                Application.DoEvents();

                if (!GestorDeFlotasDesktop.BD.GD1C2012.conectar())
                {
                    //Muestro mensaje
                    lblEstado.Text = "No se puedo conectar con la base de datos.";
                    //Ocurrió un error al intentar conectar con la BD
                    MessageBox.Show("No se pudo conectar con la base de datos, por favor chequee el estado de la misma", "No pudo conectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //Por las dudas hago un Close de la conexion.
                    GestorDeFlotasDesktop.BD.GD1C2012.desconectar();
                }

                lblEstado.Text = "Conexión exitosa, iniciando aplicación.";
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

        private void Login_Load(object sender, EventArgs e)
        {
            this.lblEstado.Visible = false;
        }
    }
}
