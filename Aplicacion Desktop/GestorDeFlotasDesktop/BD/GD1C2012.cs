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
                SqlConnection connBD = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=" + database + ";Persist Security Info=" + pSInfo + ";User ID=" + user + ";Password=" + pass);
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

        public static DataTable obtenerFuncionalidades()
        {
            try
            {
                DataTable dtRoles = new DataTable();

                var querySQL = @"Select P.pantallaID, P.descripcion
                                from Usuario U
                                inner join RolUsuario RU on (U.usuarioID = RU.usuarioID)
                                inner join Rol R on (RU.rolID = R.rolID)
                                inner join RolPantalla RP on (R.rolID = RP.rolID)
                                inner join Pantalla P on (RP.pantallaID = P.pantallaID)
                                where	isnull(U.anulado,'0')='0'
	                                    and isnull(R.anulado,'0')='0'
	                                    and U.usuarioID = 'itata'
	                                    and isnull(RP.acceso,'0')='1'";

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(querySQL, connBD);
                myReader = myCommand.ExecuteReader();

                dtRoles.Load(myReader);

                return dtRoles;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
