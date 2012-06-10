﻿using System;
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
            }     
        }



        public void cargarMenuFuncionalidades()
        {
            try
            {
                DataTable dtRoles = new DataTable();

                SqlParameter pUsuario = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
                pUsuario.Value = UsuarioLogeado.usuarioID;

                dtRoles = GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("ObtenerFuncionalidades",pUsuario);

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

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
