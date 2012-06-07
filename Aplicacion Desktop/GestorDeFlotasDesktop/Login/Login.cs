using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                    return;
                }


                lblEstado.Text = "Verificando Credenciales.";
                //Application.DoEvents()
                if (logearUsuario())
                {
                    Usuario user = new Usuario();
                    user.sUsuarioID = txtUsuario.Text;

                    Hide();

                    GestorDeFlotasDesktop.Principal.GestorFlotas gestor = new GestorDeFlotasDesktop.Principal.GestorFlotas();
                    gestor.Show();
                }
                else
                {
                    lblEstado.Text = "Credenciales Incorrectas.";
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

        private void Login_Load(object sender, EventArgs e)
        {
            this.lblEstado.Visible = false;
            this.txtUsuario.Focus();
        }

        private bool logearUsuario()
        {
            try
            {
                string passEncript = GestorDeFlotasDesktop.BD.GD1C2012.encriptarStr(this.txtPassword.Text);

                SqlParameter pUsuario = new SqlParameter("@pUsuario",SqlDbType.VarChar,20);
                pUsuario.Value=txtUsuario.Text;
                SqlParameter pClave = new SqlParameter("@pClave",SqlDbType.VarChar,100);
                pClave.Value = passEncript;
                SqlParameter pResultado = new SqlParameter("@pResultado",SqlDbType.VarChar,1);
                pResultado.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = {pUsuario,pClave,pResultado};

                GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("verificarCredencialesLogueo", parametros);

                if (pResultado.Value != null && pResultado.Value!=string.Empty && pResultado.Value=="1")
                    return true;
                else return false;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
