using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestorDeFlotasDesktop.BD
{
    public static class GD1C2012
    {
        private static string getConnectionString()
        {
            string connectionString = "";
            GestorDeFlotasDesktop.BD.parametros config = new GestorDeFlotasDesktop.BD.parametros();
            string dataSource = config.dataSource;
            string database = config.dataBase;
            string pSInfo = config.persistSecurityInfo;
            string user = config.userID;
            string pass = config.pass;
            connectionString = "Data Source=" + dataSource + ";Initial Catalog=" + database + ";Persist Security Info=" + pSInfo + ";User ID=" + user + ";Password=" + pass;
            return connectionString;
        }

        public static DataTable executeSqlQuery(string strQuery)
        {
            try
            {
                using (SqlConnection connBD = new SqlConnection())
                {
                    connBD.ConnectionString = getConnectionString();
                    connBD.Open();

                    DataTable dtResultados = new DataTable();

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(strQuery, connBD);
                    myReader = myCommand.ExecuteReader();

                    dtResultados.Load(myReader);

                    return dtResultados;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static DataSet executeSqlQuery_DS(string strQuery)
        {
            try
            {
                using (SqlConnection connBD = new SqlConnection())
                {
                    connBD.ConnectionString = getConnectionString();
                    connBD.Open();

                    DataTable dtResultados = new DataTable();

                    //SqlDataReader myReader = null;
                    SqlDataAdapter da = new SqlDataAdapter(strQuery, connBD);
                    DataSet ds;ds = new DataSet();
                    da.Fill(ds, "Tabla");
                    //dtResultados.Load(myReader);

                    return ds;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static string encriptarStr(string valor)
        {
            try
            {
                System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
                byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(valor);
                byte[] cryString = sha256.ComputeHash(sha256Bytes);
                string sha256Str = string.Empty;
                for (int i = 0; i < cryString.Length; i++)
                {
                    sha256Str += cryString[i].ToString("X").PadLeft(2,'0');
                }
                return sha256Str;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return string.Empty;
            }
        }

        public static DataTable ejecutarSP(string spName, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection connBD = new SqlConnection())
                {
                    connBD.ConnectionString = getConnectionString();
                    connBD.Open();

                    DataTable dtResultado = new DataTable();
                    SqlCommand cmd = new SqlCommand(spName, connBD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parametros);
                    
                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                    myAdapter.Fill(dtResultado);

                    return dtResultado;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public static DataTable ejecutarSP(string spName, SqlParameter parametro)
        {
            try
            {
                using (SqlConnection connBD = new SqlConnection())
                {
                    connBD.ConnectionString = getConnectionString();
                    connBD.Open();

                    DataTable dtResultado = new DataTable();
                    SqlCommand cmd = new SqlCommand(spName, connBD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(parametro);

                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                    myAdapter.Fill(dtResultado);

                    return dtResultado;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
