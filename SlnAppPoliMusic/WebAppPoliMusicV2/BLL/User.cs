namespace WebAppPoliMusicV2.BLL
{
    using System;
    using Entities;
    using WebAppPoliMusicV2.DAL;
    using WebAppPoliMusicV2.Util;

    public class User
    {
        /// <summary>
        /// Realiza el login validando username y contraseña en texto plano.
        /// Encripta la contraseña con SHA1 y valida contra la base de datos.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="rawPassword">Contraseña en texto plano (sin encriptar).</param>
        /// <returns>Objeto Entities.User si las credenciales son válidas, null en caso contrario.</returns>
        public static Entities.User Login(string username, string rawPassword)
        {
            // Validar que los parámetros no sean nulos o vacíos
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            if (string.IsNullOrEmpty(rawPassword))
            {
                return null;
            }

            // Encriptar la contraseña con SHA1
            string encryptedPassword = WebAppPoliMusicV2.Util.Hash.ComputeSHA1(rawPassword);

            // Validar contra la base de datos
            Entities.User user = WebAppPoliMusicV2.DAL.User.ValidateLogin(username, encryptedPassword);

            return user;
        }
    }
}
