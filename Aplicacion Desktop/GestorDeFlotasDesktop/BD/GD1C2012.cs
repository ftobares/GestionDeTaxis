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

        public static void obtenerFuncionalidades()
        {
            try
            {
                DataSet dsRoles = new DataSet();

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

                /*foreach (var item in queryResult)
                {
                    // add the root item and check if it has any children
                    AddChildMenuItems(menuStrip.Items.Add(item, null,
                                      new EventHandler(MenuItemClicked)));
                }*/

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
