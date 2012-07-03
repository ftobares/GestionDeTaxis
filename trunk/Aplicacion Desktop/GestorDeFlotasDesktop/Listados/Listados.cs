using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.Listados
{
    public partial class Listados : Form
    {
        public string codListado { get; set; }
        public string tituloPantalla { get; set; }
        private static Listados unicaInst = null;
        public static Listados Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new Listados();
            }
            return unicaInst;
        }

        private Listados()
        {
            InitializeComponent();
            for (int i = 1900; i < 3000; i++)
            {
                dtpAnio.Items.Add(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.MejoresClientes.MejoresClientes mC = GestorDeFlotasDesktop.MejoresClientes.MejoresClientes.Instance();
            mC.iAnio = dtpAnio.Text;
            mC.iTrim = cbTrim.Text;
            mC.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.MejoresChoferes.MejoresChoferes mCh = GestorDeFlotasDesktop.MejoresChoferes.MejoresChoferes.Instance();
            mCh.iAnio = dtpAnio.Text;
            mCh.iTrim = cbTrim.Text;
            mCh.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestorDeFlotasDesktop.MejoresAutos.MejoresAutos mA = GestorDeFlotasDesktop.MejoresAutos.MejoresAutos.Instance();
            mA.iAnio = dtpAnio.Text;
            mA.iTrim = cbTrim.Text;
            mA.ShowDialog();
        }

        private void Listados_Load(object sender, EventArgs e)
        {

        }
    }
}
