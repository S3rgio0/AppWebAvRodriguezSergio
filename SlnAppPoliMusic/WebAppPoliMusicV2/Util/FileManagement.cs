namespace WebAppPoliMusicV2.Util
{
    using System;
    using System.IO;

    public static class FileManagement
    {
        /// <summary>
        /// Obtiene el nombre seguro de un archivo usando Path.GetFileName.
        /// </summary>
        /// <param name="filePath">Ruta completa o relativa del archivo.</param>
        /// <returns>Nombre del archivo sin ruta.</returns>
        public static string GetSafeFileName(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }

            return Path.GetFileName(filePath);
        }

        /// <summary>
        /// Verifica si un archivo existe en la ruta especificada.
        /// </summary>
        /// <param name="physicalPath">Ruta física completa del archivo.</param>
        /// <returns>true si el archivo existe, false en caso contrario.</returns>
        public static bool FileExists(string physicalPath)
        {
            if (string.IsNullOrEmpty(physicalPath))
            {
                return false;
            }

            return File.Exists(physicalPath);
        }
    }
}
