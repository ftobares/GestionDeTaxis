using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GestorDeFlotasDesktop.BD
{
    public sealed class GD1C2012
    {
        private static readonly GD1C2012 instance = new GD1C2012();

        private GD1C2012() { }

        public static SqlConnection connBD = new SqlConnection();

        public static GD1C2012 Instance
        {
            get
            {
                return instance;
            }
        }
        
        public static bool conectar()
        {
            GestorDeFlotasDesktop.BD.parametros config = new GestorDeFlotasDesktop.BD.parametros();
            try
            {
                string dataSource = config.dataSource;
                string database = config.dataBase;
                string pSInfo = config.persistSecurityInfo;
                string user = config.userID;
                string pass = config.pass;
                connBD.ConnectionString = "Data Source=" + dataSource + ";Initial Catalog=" + database + ";Persist Security Info=" + pSInfo + ";User ID=" + user + ";Password=" + pass;
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

        public static DataTable executeSqlQuery(string strQuery)
        {
            try
            {
                DataTable dtResultados = new DataTable();

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(strQuery, connBD);
                myReader = myCommand.ExecuteReader();

                dtResultados.Load(myReader);

                return dtResultados;
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
                    sha256Str += cryString[i].ToString("X");
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
                DataTable dtResultado = new DataTable();
                SqlCommand cmd = new SqlCommand(spName, connBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametros);
                SqlDataReader rd = cmd.ExecuteReader();
                dtResultado.Load(rd);
                return dtResultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
