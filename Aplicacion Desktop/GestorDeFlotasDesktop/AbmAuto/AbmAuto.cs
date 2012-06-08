﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.AbmAuto
{
    public partial class AbmAuto : Form
    {

        private static AbmAuto unicaInst = null;
        public static AbmAuto Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new AbmAuto();
            }
            return unicaInst;
        }

        private AbmAuto()
        {
            InitializeComponent();
        }

        private void AbmAuto_Load(object sender, EventArgs e)
        {
            DataTable dtRoles = new DataTable();

            SqlParameter pUsuario = new SqlParameter("@pUsuarioID", SqlDbType.VarChar, 20);
            pUsuario.Value = UsuarioLogeado.usuarioID;

            dtRoles = GestorDeFlotasDesktop.BD.GD1C2012.ejecutarSP("ObtenerFuncionalidades", pUsuario);

            this.cmbTest.DataSource=dtRoles;
            this.cmbTest.DisplayMember = "descripcion";
            this.cmbTest.ValueMember = "pantallaID";
        }
    }
}
