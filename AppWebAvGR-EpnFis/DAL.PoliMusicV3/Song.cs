using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.PoliMusicV3
{
    public class Song
    {
        private readonly string connectionString;

        public Song(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("La cadena de conexión es obligatoria.", "connectionString");
            this.connectionString = connectionString;
        }

        public DataTable Read()
        {
            const string sql = "SELECT ID_SONG, TITLE, FILE_PATH, PLAY_COUNT FROM TBL_SONG";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                DataTable table = new DataTable("TBL_SONG");
                adapter.Fill(table);
                return table;
            }
        }
    }
}
