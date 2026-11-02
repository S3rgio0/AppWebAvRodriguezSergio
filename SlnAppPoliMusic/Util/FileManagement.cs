namespace Util
{
    using System;
    using System.IO;

    public static class FileManagement
    {
        /// <summary>
        /// Valida que la extensión del archivo sea permitida.
        /// </summary>
        /// <param name="fileName">Nombre del archivo con extensión.</param>
        /// <param name="allowedExtensions">Array de extensiones permitidas (ej: ".mp3", ".jpg").</param>
        /// <returns>true si la extensión es válida, false en caso contrario.</returns>
        public static bool IsValidExtension(string fileName, string[] allowedExtensions)
        {
            if (fileName == null || fileName.Length == 0)
            {
                return false;
            }

            string fileExtension = Path.GetExtension(fileName).ToLower();
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i].ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Obtiene el nombre seguro del archivo usando Path.GetFileName.
        /// </summary>
        /// <param name="filePath">Ruta del archivo (puede contener rutas relativas o absolutas).</param>
        /// <returns>Nombre del archivo sin ruta.</returns>
        public static string GetSafeFileName(string filePath)
        {
            if (filePath == null || filePath.Length == 0)
            {
                return string.Empty;
            }

            return Path.GetFileName(filePath);
        }

        /// <summary>
        /// Verifica si un archivo existe en la ruta física especificada.
        /// </summary>
        /// <param name="physicalPath">Ruta física completa del archivo.</param>
        /// <returns>true si el archivo existe, false en caso contrario.</returns>
        public static bool FileExists(string physicalPath)
        {
            if (physicalPath == null || physicalPath.Length == 0)
            {
                return false;
            }

            return File.Exists(physicalPath);
        }

        /// <summary>
        /// Guarda un array de bytes en la ruta física especificada.
        /// </summary>
        /// <param name="physicalPath">Ruta física completa donde guardar el archivo.</param>
        /// <param name="fileBytes">Array de bytes del archivo.</param>
        /// <returns>true si se guardó exitosamente, false en caso contrario.</returns>
        public static bool SaveFile(string physicalPath, byte[] fileBytes)
        {
            if (physicalPath == null || physicalPath.Length == 0 || fileBytes == null)
            {
                return false;
            }

            try
            {
                FileStream fileStream = new FileStream(physicalPath, FileMode.Create, FileAccess.Write);
                try
                {
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }
                finally
                {
                    fileStream.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
