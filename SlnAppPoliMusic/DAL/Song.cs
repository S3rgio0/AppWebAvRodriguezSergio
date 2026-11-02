namespace DAL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class Song
    {
        private string connectionString;

        public Song()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BDD_PoliMusic"].ConnectionString;
        }

        /// <summary>
        /// Obtiene el listado completo de canciones de TBL_SONG.
        /// </summary>
        /// <returns>DataTable con las columnas id, song_name, file_path, reproductions.</returns>
        public DataTable GetSongs()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;

            try
            {
                connection = new SqlConnection(connectionString);
                string query = "SELECT id, song_name, file_path, reproductions FROM TBL_SONG";
                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener la lista de canciones: " + ex.Message);
            }
            finally
            {
                if (adapter != null)
                {
                    adapter.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return dataTable;
        }
    }
}
