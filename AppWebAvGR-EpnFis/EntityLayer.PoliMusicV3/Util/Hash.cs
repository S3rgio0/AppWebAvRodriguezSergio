using System;
using System.Security.Cryptography;
using System.Text;

namespace EntityLayer.PoliMusicV3.Util
{
    public static class Hash
    {
        public static string GeneratePasswordHash(string password)
        {
            if (password == null) throw new ArgumentNullException("password");

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder result = new StringBuilder(hash.Length * 2);
                foreach (byte value in hash) result.Append(value.ToString("x2"));
                return result.ToString();
            }
        }

        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException("password");

            byte[] salt = new byte[16];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create()) random.GetBytes(salt);

            using (Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt, 100000))
            {
                byte[] derivedKey = deriveBytes.GetBytes(32);
                byte[] saltAndKey = new byte[salt.Length + derivedKey.Length];
                Buffer.BlockCopy(salt, 0, saltAndKey, 0, salt.Length);
                Buffer.BlockCopy(derivedKey, 0, saltAndKey, salt.Length, derivedKey.Length);
                return Convert.ToBase64String(saltAndKey);
            }
        }
    }
}
