using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.Principal
{
    public partial class GestorFlotas : Form
    {
        public GestorFlotas()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GestorFlotas_Load(object sender, EventArgs e)
        {
            cargarMenuFuncionalidades();
        }

        private void menuClick_Handler(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = sender as ToolStripMenuItem;
            switch (itm.Name)
            {
                case "abmAuto":
                    GestorDeFlotasDesktop.AbmAuto.AbmAuto frmAuto = GestorDeFlotasDesktop.AbmAuto.AbmAuto.Instance();
                    frmAuto.MdiParent = this;
                    frmAuto.Show();
                    break;
                case "abmChofer":
                    GestorDeFlotasDesktop.AbmChofer.AbmChofer frmChofer = GestorDeFlotasDesktop.AbmChofer.AbmChofer.Instance();
                    frmChofer.MdiParent = this;
                    frmChofer.Show();
                    break;
                case "abmReloj":
                    GestorDeFlotasDesktop.AbmReloj.AbmReloj frmReloj = GestorDeFlotasDesktop.AbmReloj.AbmReloj.Instance();
                    frmReloj.MdiParent = this;
                    frmReloj.Show();
                    break;
                case "abmTurno":
                    GestorDeFlotasDesktop.AbmTurno.AbmTurno frmTurno = GestorDeFlotasDesktop.AbmTurno.AbmTurno.Instance();
                    frmTurno.MdiParent = this;
                    frmTurno.Show();
                    break;
                case "abmCliente":
                    GestorDeFlotasDesktop.AbmCliente.AbmCliente frmCliente = GestorDeFlotasDesktop.AbmCliente.AbmCliente.Instance();
                    frmCliente.MdiParent = this;
                    frmCliente.Show();
                    break;
                case "abmChoferAuto":
                    GestorDeFlotasDesktop.AsignacionChofer_AutoTurno.AsignacionChofer_AutoTurno frmCAT = GestorDeFlotasDesktop.AsignacionChofer_AutoTurno.AsignacionChofer_AutoTurno.Instance();
                    frmCAT.MdiParent = this;
                    frmCAT.Show();
                    break;
                case "abmViaje":
                    GestorDeFlotasDesktop.RegistrarViaje.RegistrarViajes frmRegV = GestorDeFlotasDesktop.RegistrarViaje.RegistrarViajes.Instance();
                    frmRegV.MdiParent = this;
                    frmRegV.Show();
                    break;
                case "abmRendicion":
                    GestorDeFlotasDesktop.RendirViajes.RendirViajes frmRendV = GestorDeFlotasDesktop.RendirViajes.RendirViajes.Instance();
                    frmRendV.MdiParent = this;
                    frmRendV.Show();
                    break;
                case "abmFacturacion":
                    GestorDeFlotasDesktop.Facturar.Facturar frmFact = GestorDeFlotasDesktop.Facturar.Facturar.Instance();
                    frmFact.MdiParent = this;
                    frmFact.Show();
                    break;
                case "abmUsuario":
                    GestorDeFlotasDesktop.AbmUsuario.AbmUsuario frmAbmUsuario = GestorDeFlotasDesktop.AbmUsuario.AbmUsuario.Instance();
                    frmAbmUsuario.MdiParent = this;
                    frmAbmUsuario.Show();
                    break;
                case "abmRol":
                    GestorDeFlotasDesktop.AbmRol.AbmRol frmAbmRol = GestorDeFlotasDesktop.AbmRol.AbmRol.Instance();
                    frmAbmRol.MdiParent = this;
                    frmAbmRol.Show();
                    break;
                case "abmPantalla":
                    GestorDeFlotasDesktop.AbmPantallas.AbmPantalla frmAbmPantalla = GestorDeFlotasDesktop.AbmPantallas.AbmPantalla.Instance();
                    frmAbmPantalla.MdiParent = this;
                    frmAbmPantalla.Show();
                    break;
                case "abmListado":
                    GestorDeFlotasDesktop.Listados.Listados frmAbmListados = GestorDeFlotasDesktop.Listados.Listados.Instance();
                    frmAbmListados.MdiParent = this;
                    frmAbmListados.Show();
                    break;
            }     
        }



        public void cargarMenuFuncionalidades()
        {
            try
            {
                string retCatchError = string.Empty;
                DataTable dtRoles = new DataTable();

                SqlParameter pUsuario = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
                pUsuario.Value = UsuarioLogeado.usuarioID;

                if (!GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("FEMIG.ObtenerFuncionalidades",pUsuario, dtRoles))
                    return;

                foreach (DataRow r in dtRoles.Rows)
                {

                    ToolStripMenuItem tsmi = new ToolStripMenuItem(r[1].ToString(), null, new EventHandler(menuClick_Handler), r[0].ToString());
                    this.toolStripMenuItem4.DropDownItems.Add(tsmi);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void GestorFlotas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }
    }
}
