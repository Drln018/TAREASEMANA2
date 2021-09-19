
package Modelo;

import com.sun.jdi.connect.spi.Connection;
import java.sql.DriverManager;
import java.sql.*;
import java.util.logging.Level;
import java.util.logging.Logger;
/**
 *
 * @author Darlin
 */
public class ClsConexion {
    private static final String JDBC_URL="jdbc:mysql://localhost:3306/dbcomisiones?zeroDateTimeBehavior=convertToNull&useSSL=false&useTimezone=true&serverTimezone=true&serverTimezone=UTC";
    private static final String JDBC_USER="root";
    private static final String JDBC_PWD="2001";
    
     //CREAR METODO CONEXION
    public static java.sql.Connection getConnection() throws SQLException{
        return DriverManager.getConnection(JDBC_URL,JDBC_USER,JDBC_PWD);
    }

     //METODO CERAR CONEXION
     //cerrar conexion de tipo resultset
    public static void close(ResultSet rs){
        try {
            rs.close();
        } catch (SQLException ex) {
           ex.printStackTrace(System.out);
        }
    }


     public static void close(PreparedStatement stmt){
        try {
            stmt.close();
        } catch (SQLException ex) {
             ex.printStackTrace(System.out);
        }
    }
        public static void close(java.sql.Connection cn){
        try {
            cn.close();
        } catch (SQLException ex) {
            ex.printStackTrace(System.out);
        }
    }

}
