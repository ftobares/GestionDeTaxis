using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.AbmReloj
{
    public partial class addEditReloj : Form
    {
        public string nroSerieReloj { get; set; }
        public string modoAbm { get; set; }
        public string tituloPantalla { get; set; }
        private static addEditReloj unicaInst = null;
        public static addEditReloj Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new addEditReloj();
            }
            return unicaInst;
        }

        private addEditReloj()
        {
            InitializeComponent();
        }

        private void addEditReloj_Load(object sender, EventArgs e)
        {

        }
    }
}
