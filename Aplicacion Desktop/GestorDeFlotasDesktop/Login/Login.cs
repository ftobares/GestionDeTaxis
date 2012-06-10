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
            logearUsuario();
        }

        private bool controlarCamposCompletos()
        {
            if (this.txtUsuario.Text != string.Empty && this.txtPassword.Text != string.Empty)
                return true;
            else
                return false;
        }


        private void Login_Load(object sender, EventArgs e)
        {
            this.lblEstado.Visible = false;
            this.txtUsuario.Focus();

            //Esto es temporal, me harto poner el usuario y clave
            this.txtUsuario.Text = "Admin";
            this.txtPassword.Text = "w23e";
        }

        private void logearUsuario()
        {
            try
            {
                if (!controlarCamposCompletos())
                {
                    MessageBox.Show("Debe completar los campos Usuario y Password.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.Cursor = Cursors.AppStarting;
                lblEstado.Text = "Verificando Credenciales...";
                lblEstado.Visible = true;

                if (verificarCredenciales())
                {
                    UsuarioLogeado.usuarioID = this.txtUsuario.Text;

                    GestorDeFlotasDesktop.Principal.GestorFlotas gestor = new GestorDeFlotasDesktop.Principal.GestorFlotas();
                    gestor.Show();

                    this.Hide();
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

        private bool verificarCredenciales()
        {
            try
            {
                string retCatchError = string.Empty;
                string passEncript = GestorDeFlotasDesktop.BD.GD1C2012.encriptarStr(this.txtPassword.Text);

                SqlParameter pUsuario = new SqlParameter("@pUsuario", SqlDbType.VarChar, 20);
                pUsuario.Value = txtUsuario.Text;
                SqlParameter pClave = new SqlParameter("@pClave", SqlDbType.VarChar, 100);
                pClave.Value = passEncript;
                SqlParameter pResultado = new SqlParameter("@pResultado", SqlDbType.Bit);
                pResultado.Direction = ParameterDirection.Output;

                SqlParameter[] parametros = { pUsuario, pClave, pResultado };

                GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.verificarCredencialesLogueo", parametros,retCatchError);

                return (bool)pResultado.Value;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                logearUsuario();
            }
        }
    }
}
