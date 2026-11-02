namespace WebAppPoliMusicV2.DAL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class Song
    {
        /// <summary>
        /// Obtiene todas las canciones de la base de datos.
        /// </summary>
        /// <returns>DataTable con todas las canciones (ID_SONG, TITLE, FILE_PATH, etc.).</returns>
        public static DataTable GetAllSongs()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter adapter = null;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                connection = new SqlConnection(connectionString);

                string query = "SELECT * FROM TBL_SONG";
                command = new SqlCommand(query, connection);
                adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error en la base de datos al obtener canciones: " + sqlEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                throw new Exception("Error en operacion de conexion: " + invOpEx.Message);
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }

                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }

            return dataTable;
        }
    }
}
