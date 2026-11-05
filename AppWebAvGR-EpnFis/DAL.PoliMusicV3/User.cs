using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using EntityLayer.PoliMusicV3;

namespace DAL.PoliMusicV3
{
    public class User
    {
        private readonly string connectionString;

        public User(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("La cadena de conexión es obligatoria.", "connectionString");
            this.connectionString = connectionString;
        }

        public bool Save(EntityLayer.PoliMusicV3.User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            const string sql = @"INSERT INTO TBL_USER (USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_TYPE, USER_PHOTO)
                                 VALUES (@USERNAME, @PASSWORD, @EMAIL, @BIRTHDAY, @USER_TYPE, @USER_PHOTO)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                AddUserParameters(command, user);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool CheckExistUser(string userName)
        {
            return Exists("SELECT TOP (1) ID_USER FROM TBL_USER WHERE USERNAME = @VALUE", userName);
        }

        public bool CheckExistEmail(string email)
        {
            return Exists("SELECT TOP (1) ID_USER FROM TBL_USER WHERE EMAIL = @VALUE", email);
        }

        public DataTable Read()
        {
            const string sql = "SELECT ID_USER, USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_TYPE, USER_PHOTO FROM TBL_USER";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                DataTable table = new DataTable("TBL_USER");
                adapter.Fill(table);
                return table;
            }
        }

        public bool Update(EntityLayer.PoliMusicV3.User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            const string sql = @"UPDATE TBL_USER SET USERNAME = @USERNAME, PASSWORD = @PASSWORD, EMAIL = @EMAIL,
                                 BIRTHDAY = @BIRTHDAY, USER_TYPE = @USER_TYPE, USER_PHOTO = @USER_PHOTO WHERE ID_USER = @ID_USER";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                AddUserParameters(command, user);
                command.Parameters.Add("@ID_USER", SqlDbType.Int).Value = user.ID;
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DELETE FROM TBL_USER WHERE ID_USER = @ID_USER", connection))
            {
                command.Parameters.Add("@ID_USER", SqlDbType.Int).Value = id;
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public EntityLayer.PoliMusicV3.User AuthenticateUser(string userName, string password)
        {
            const string sql = @"SELECT ID_USER, USERNAME, PASSWORD, EMAIL, BIRTHDAY, USER_TYPE, USER_PHOTO
                                 FROM TBL_USER WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 100).Value = userName ?? String.Empty;
                command.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 256).Value = password ?? String.Empty;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow))
                    return reader.Read() ? MapUser(reader) : null;
            }
        }

        private bool Exists(string sql, string value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@VALUE", SqlDbType.NVarChar, 256).Value = value ?? String.Empty;
                connection.Open();
                return command.ExecuteScalar() != null;
            }
        }

        private static void AddUserParameters(SqlCommand command, EntityLayer.PoliMusicV3.User user)
        {
            DateTime birthday;
            if (!DateTime.TryParseExact(user.Birthday, new[] { "dd/MM/yyyy", "yyyy-MM-dd", "MM/dd/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday))
                throw new ArgumentException("La fecha de nacimiento debe tener un formato válido (dd/MM/yyyy).", "user");

            command.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 100).Value = user.UserName ?? String.Empty;
            command.Parameters.Add("@PASSWORD", SqlDbType.NVarChar, 256).Value = user.Password ?? String.Empty;
            command.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 256).Value = user.Email ?? String.Empty;
            command.Parameters.Add("@BIRTHDAY", SqlDbType.Date).Value = birthday.Date;
            command.Parameters.Add("@USER_TYPE", SqlDbType.Int).Value = user.UserType;
            command.Parameters.Add("@USER_PHOTO", SqlDbType.NVarChar, 500).Value = user.Photo ?? String.Empty;
        }

        private static EntityLayer.PoliMusicV3.User MapUser(SqlDataReader reader)
        {
            return new EntityLayer.PoliMusicV3.User
            {
                ID = Convert.ToInt32(reader["ID_USER"], CultureInfo.InvariantCulture),
                UserName = Convert.ToString(reader["USERNAME"], CultureInfo.InvariantCulture),
                Password = Convert.ToString(reader["PASSWORD"], CultureInfo.InvariantCulture),
                Email = Convert.ToString(reader["EMAIL"], CultureInfo.InvariantCulture),
                Birthday = Convert.ToDateTime(reader["BIRTHDAY"], CultureInfo.InvariantCulture).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                UserType = Convert.ToInt32(reader["USER_TYPE"], CultureInfo.InvariantCulture),
                Photo = reader["USER_PHOTO"] == DBNull.Value ? String.Empty : Convert.ToString(reader["USER_PHOTO"], CultureInfo.InvariantCulture)
            };
        }
    }
}
