using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

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
            DataTable dtFunc = new DataTable();
            dtFunc = GestorDeFlotasDesktop.BD.GD1C2012.obtenerFuncionalidades();

            //TODO: Revisar dtFunc.Rows, cuando me logueo sin ingresar un usuario
            foreach (DataRow r in dtFunc.Rows)
            {

                ToolStripMenuItem tsmi = new ToolStripMenuItem(r[1].ToString(), null, new EventHandler(menuClick_Handler), r[0].ToString());
                this.toolStripMenuItem4.DropDownItems.Add(tsmi);
            }

        }

        private void menuClick_Handler(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = sender as ToolStripMenuItem;

            switch (itm.Name)
            {
                case "abmAuto":
                        MessageBox.Show("Autoooooo");
                        break;
                    default:
                        MessageBox.Show("otra cosa!");
                        break;

            }
            

            /*ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
            
            if (item == null)
                return;

            switch (item)
            {
                case "1":
                    break;
                default:
                    break;
            }*/
        }
    }
}
