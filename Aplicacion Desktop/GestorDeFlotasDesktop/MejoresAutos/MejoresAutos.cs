using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.MejoresAutos
{
    public partial class MejoresAutos : Form
    {
        public string iTrim { get; set; }
        public string iAnio { get; set; }
        public string tituloPantalla { get; set; }
        private static MejoresAutos unicaInst = null;
        public static MejoresAutos Instance()
        {
            if (unicaInst == null)
            {
                unicaInst = new MejoresAutos();
            }
            return unicaInst;
        }

        private MejoresAutos()
        {
            InitializeComponent();
        }

        private void MejoresAutos_Load(object sender, EventArgs e)
        {
            cargarQuery();
        }

        private string construirQuery()
        {
            string strQuery = "SELECT TOP (5) ta.patente , SUM(ISNULL(f.importeTotal,0)) AS ImporteTotal FROM GD1C2012.FEMIG.Facturas f INNER JOIN GD1C2012.FEMIG.viajes v on f.codFactura = v.codFactura INNER JOIN GD1C2012.FEMIG.ChoferAutoTurno cat on v.asignacionID = cat.asignacionID INNER JOIN GD1C2012.FEMIG.autos ta on cat.patente = ta.patente WHERE YEAR(f.fechaFin) = " + iAnio + " AND datepart(quarter,f.fechaFin) = " + iTrim + " GROUP BY ta.patente,f.importeTotal ORDER BY f.importeTotal";
            return strQuery;
        }

        private void cargarQuery()
        {
            string strQuery = construirQuery();
            dgFacturas.DataSource = GestorDeFlotasDesktop.BD.GD1C2012.executeSqlQuery(strQuery);
        }
    }
}
