namespace WebAppPoliMusicV2.DAL
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using Entities;

    public class User
    {
        /// <summary>
        /// Valida el login verificando usuario y contraseña hasheada en la base de datos.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="passwordHash">Contraseña hasheada (SHA1).</param>
        /// <returns>Objeto Entities.User si las credenciales son válidas, null en caso contrario.</returns>
        public static Entities.User ValidateLogin(string username, string passwordHash)
        {
            Entities.User user = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT * FROM TBL_USER WHERE USERNAME = @Username AND PASSWORD = @Password";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", passwordHash);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new Entities.User();
                    user.ID_USER = Convert.ToInt32(reader["ID_USER"]);
                    user.USERNAME = reader["USERNAME"].ToString();
                    user.PASSWORD = reader["PASSWORD"].ToString();
                    user.EMAIL = reader["EMAIL"].ToString();
                    user.BIRTHDAY = Convert.ToDateTime(reader["BIRTHDAY"]);
                    user.USER_PHOTO = reader["USER_PHOTO"].ToString();
                    user.USER_TYPE = reader["USER_TYPE"].ToString();
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error en la base de datos durante la validacion de login: " + sqlEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                throw new Exception("Error en operacion de conexion: " + invOpEx.Message);
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader.Dispose();
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

            return user;
        }
    }
}
