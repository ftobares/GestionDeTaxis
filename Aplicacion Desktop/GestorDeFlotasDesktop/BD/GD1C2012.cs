using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.BD
{
    static class GD1C2012
    {
        static private SqlConnection connBD = new SqlConnection();

        public static bool conectar()
        {
            try
            {
                string dataSource = "EASTBLUE\\SQLSERVER2005";
                string database = "GD1C2012";
                SqlConnection connBD = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=gd;Password=gd2012");
                connBD.Open();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static void desconectar()
        {
            try
            {
                connBD.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
