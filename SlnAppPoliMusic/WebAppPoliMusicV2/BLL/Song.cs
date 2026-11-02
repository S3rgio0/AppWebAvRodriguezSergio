namespace WebAppPoliMusicV2.BLL
{
    using System;
    using System.Data;
    using WebAppPoliMusicV2.DAL;

    public class Song
    {
        /// <summary>
        /// Obtiene la lista de todas las canciones.
        /// </summary>
        /// <returns>DataTable con todas las canciones disponibles.</returns>
        public static DataTable GetSongs()
        {
            DataTable songs = WebAppPoliMusicV2.DAL.Song.GetAllSongs();
            return songs;
        }
    }
}
