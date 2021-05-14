using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INSERCION_MYSQL.clases
{
    public class ClsMySQL
    {
        public static MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "basedatos";
            string usuario = "root";
            string password = "contra";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password;

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                return null;
            }

        }
    }
}