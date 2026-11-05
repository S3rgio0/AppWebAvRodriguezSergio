using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace WebAppPoliMusicV3
{
    public static class FileManagement
    {
        private const int MaxImageLength = 10 * 1024 * 1024;
        private const string DefaultImageBytes = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+jS2cAAAAASUVORK5CYII=";

        public static string SaveImageOnServer(HttpPostedFile file)
        {
            string directory = ConfigurationManager.AppSettings["userImagesPath"] ?? "~/UserImages";
            return SaveImageOnServer(file, directory);
        }

        public static string SaveImageOnServer(HttpPostedFile file, string virtualDirectory)
        {
            if (file == null || file.ContentLength == 0) throw new ArgumentException("Selecciona una imagen.", "file");
            if (file.ContentLength > MaxImageLength) throw new InvalidOperationException("La imagen no puede superar los 10 MB.");

            string extension = Path.GetExtension(file.FileName);
            if (!String.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) &&
                !String.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("La imagen debe tener extensión .jpg o .png.");

            string safeExtension = extension.ToLowerInvariant();
            string fileName = Guid.NewGuid().ToString("N") + safeExtension;
            string physicalDirectory = HttpContext.Current.Server.MapPath(virtualDirectory);
            Directory.CreateDirectory(physicalDirectory);
            file.SaveAs(Path.Combine(physicalDirectory, fileName));
            return VirtualPathUtility.ToAbsolute(VirtualPathUtility.AppendTrailingSlash(virtualDirectory) + fileName);
        }

        public static string SaveDefaultImageOnServer()
        {
            string virtualPath = ConfigurationManager.AppSettings["defaultUserImagePath"] ?? "~/UserImages/default.png";
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);
            string directory = Path.GetDirectoryName(physicalPath);
            Directory.CreateDirectory(directory);
            if (!File.Exists(physicalPath)) File.WriteAllBytes(physicalPath, Convert.FromBase64String(DefaultImageBytes));
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }

        public static string SaveSongOnServer(HttpPostedFile file)
        {
            if (file == null || file.ContentLength == 0) throw new ArgumentException("Selecciona una canción.", "file");
            int maxSongLength;
            if (!Int32.TryParse(ConfigurationManager.AppSettings["maxSongLength"], out maxSongLength)) maxSongLength = 52428800;
            if (file.ContentLength > maxSongLength) throw new InvalidOperationException("La canción supera el tamaño máximo permitido.");
            if (!String.Equals(Path.GetExtension(file.FileName), ".mp3", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("La canción debe tener extensión .mp3.");

            string virtualDirectory = ConfigurationManager.AppSettings["songFilesPath"] ?? "~/SongFiles";
            string physicalDirectory = HttpContext.Current.Server.MapPath(virtualDirectory);
            Directory.CreateDirectory(physicalDirectory);
            string fileName = Guid.NewGuid().ToString("N") + ".mp3";
            file.SaveAs(Path.Combine(physicalDirectory, fileName));
            return VirtualPathUtility.ToAbsolute(VirtualPathUtility.AppendTrailingSlash(virtualDirectory) + fileName);
        }
    }
}
