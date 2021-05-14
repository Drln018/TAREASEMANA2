using INSERCION_MYSQL.clases;
using MySql.Data.MySqlClient;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows;

namespace INSERCION_MYSQL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ButtonMySQL_Click(object sender, EventArgs e)
        {
            //leemos el archivo con sldocument
            SLDocument sl = new SLDocument(@"C:\Users\13237\OneDrive\Desktop\crudDB.xlsx"); //ubicacion
            SLWorksheetStatistics propiedades = sl.GetWorksheetStatistics(); //traer las propiedades del archivo

            int ultimaFila = propiedades.EndRowIndex; //saber cuantas filas existen, trae la ultima fila
            MySqlConnection conexionBD = ClsMySQL.conexion();
            conexionBD.Open();//se abre la conexion

            for (int x = 2; x <= ultimaFila; x++)//leer todas las filas
            {
                //se trae el codigo y se le coloca un alias 
                string sql = "INSERT INTO tabla_alumnos(Correlativo, Nombre, Parcial1, Parcial2, Parcial3, Parcial4, Seccion) " +
                   "VALUES(@Correlativo, @Nombre, @Parcial1, @Parcial2, @Parcial3, @Parcial4, @Seccion)";

                try
                {
                    //transaccion a mysql
                    //con el objeto se agrega el alias, el valor que se le asigna, la columna 
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    comando.Parameters.AddWithValue("@Correlativo", sl.GetCellValueAsString("A" + x));
                    comando.Parameters.AddWithValue("@Nombre", sl.GetCellValueAsString("B" + x));
                    comando.Parameters.AddWithValue("@Parcial1", sl.GetCellValueAsString("C" + x));
                    comando.Parameters.AddWithValue("@Parcial2", sl.GetCellValueAsString("D" + x));
                    comando.Parameters.AddWithValue("@Parcial3", sl.GetCellValueAsString("E" + x));
                    comando.Parameters.AddWithValue("@Parcial4", sl.GetCellValueAsString("F" + x));
                    comando.Parameters.AddWithValue("@Seccion", sl.GetCellValueAsString("G" + x));
                    comando.ExecuteNonQuery(); //se ejecuta la insercion
                }//si hay un error se utiliza mysqlexception
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//si funciona aparecerá un messagebox
            MessageBox.Show("El archivo se ha cargado");
        }
    }
}