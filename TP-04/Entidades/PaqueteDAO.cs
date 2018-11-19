using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    ///     Clase estática que se encargará de guardar los datos de un paquete 
    ///     en la base de datos.
    /// </summary>
    public static class PaqueteDAO
    {
        #region "Campos"
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region "Constructor"

        /// <summary>
        ///     Constructor por defecto, inicializa conexión a SQL Server.
        ///     Instancia un nuevo comando asociado a la conexión en la cual se 
        ///     ejecutarán sus acciones. De surgir cualquier error, se lanza una excepción.
        /// </summary>
        static PaqueteDAO()
        {
            try
            {
                String connectionString = 
                    "Server=DESKTOP-587OIBF;Database=correo-sp-2017;Trusted_Connection=True;";

                PaqueteDAO.conexion = new SqlConnection(connectionString);
                PaqueteDAO.comando = new SqlCommand();
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Métodos"

        /// <summary>
        ///     Ejecuta un comando para guardar los datos de un paquete 
        ///     en la base de datos de SQL Server.
        /// </summary>
        /// <param name="p">
        ///     Paquete a ser guardado.
        /// </param>
        /// <returns>
        ///     (true) Si se inserto el paquete en la base de datos con éxito.
        ///     (Exception) En caso de producirse un error.
        /// </returns>
        public static bool Insertar(Paquete p)
        {
            bool returnAux = false;
            try
            {
                PaqueteDAO.comando.CommandText = 
                    "INSERT INTO dbo.Paquetes(direccionEntrega, trackingID, alumno)" +
                    "VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "','"+"Gastón Pesoa"+"')";

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
                returnAux = true;
            }
            return returnAux;
        }
        #endregion
    }
}
