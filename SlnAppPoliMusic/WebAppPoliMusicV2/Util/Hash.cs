namespace WebAppPoliMusicV2.Util
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class Hash
    {
        /// <summary>
        /// Encripta un string de texto plano usando SHA1 y retorna el hash en formato hexadecimal.
        /// </summary>
        /// <param name="plainText">Texto plano a encriptar.</param>
        /// <returns>Hash SHA1 en formato hexadecimal (minúsculas).</returns>
        public static string ComputeSHA1(string plainText)
        {
            if (plainText == null)
            {
                plainText = string.Empty;
            }

            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            SHA1CryptoServiceProvider sha1Provider = new SHA1CryptoServiceProvider();
            byte[] hashBytes = sha1Provider.ComputeHash(inputBytes);

            StringBuilder hexString = new StringBuilder();
            int i = 0;
            while (i < hashBytes.Length)
            {
                hexString.Append(hashBytes[i].ToString("x2"));
                i++;
            }

            return hexString.ToString();
        }
    }
}
