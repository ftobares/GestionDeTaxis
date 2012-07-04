using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.MejoresClientes
{
    public partial class MejoresClientes : Form
    {
        public string iTrim { get; set; }
        public string iAnio { get; set; }
        public string tituloPantalla { get; set; }
        private static MejoresClientes unicaInst = null;
        public static MejoresClientes Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new MejoresClientes();
            }
            return unicaInst;
        }

        private MejoresClientes()
        {
            InitializeComponent();
        }

        private void MejoresClientes_Load(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private string construirQuery()
        {
            string strQuery = "SELECT TOP (5) cl.nombre , SUM(ISNULL(f.importeTotal,0)) AS ImporteTotal FROM GD1C2012.FEMIG.Facturas f INNER JOIN GD1C2012.FEMIG.clientes cl on f.dniCliente = cl.dniCliente WHERE YEAR(f.fechaFin) = " + iAnio + " AND datepart(quarter,f.fechaFin) = " + iTrim + " GROUP BY cl.nombre,f.importeTotal ORDER BY f.importeTotal";
            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgFacturas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }
    }
}
