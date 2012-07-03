using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.MejoresChoferes
{
    public partial class MejoresChoferes : Form
    {
        public string iTrim { get; set; }
        public string iAnio { get; set; }
        public string tituloPantalla { get; set; }
        private static MejoresChoferes unicaInst = null;
        public static MejoresChoferes Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new MejoresChoferes();
            }
            return unicaInst;
        }

        private MejoresChoferes()
        {
            InitializeComponent();
        }

        private void MejoresChoferes_Load(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private string construirQuery()
        {
            iAnio = "'2012'";
            string strQuery = "SELECT TOP (5) ch.nombre , SUM(ISNULL(f.importeTotal,0)) AS ImporteTotal FROM GD1C2012.FEMIG.Facturas f INNER JOIN GD1C2012.FEMIG.viajes v on f.codFactura = v.codFactura INNER JOIN GD1C2012.FEMIG.ChoferAutoTurno cat on v.asignacionID = cat.turnoID INNER JOIN GD1C2012.FEMIG.choferes ch on cat.dniChofer = ch.dniChofer WHERE YEAR(f.fechaFin) = " + iAnio + " AND datepart(quarter,f.fechaFin) = " + iTrim + " GROUP BY ch.nombre,f.importeTotal ORDER BY f.importeTotal";
            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgFacturas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }
    }
}
