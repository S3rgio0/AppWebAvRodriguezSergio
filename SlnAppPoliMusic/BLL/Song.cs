namespace BLL
{
    using System;
    using System.Data;
    using DAL;

    public class Song
    {
        private DAL.Song dalSong;

        public Song()
        {
            dalSong = new DAL.Song();
        }

        /// <summary>
        /// Obtiene el listado de canciones desde la capa DAL.
        /// </summary>
        /// <returns>DataTable con la información de todas las canciones.</returns>
        public DataTable GetSongs()
        {
            DataTable songList = dalSong.GetSongs();
            return songList;
        }
    }
}
