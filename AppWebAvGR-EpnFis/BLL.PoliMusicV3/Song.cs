using System.Data;
using DAL.PoliMusicV3;

namespace BLL.PoliMusicV3
{
    public class Song
    {
        private readonly DAL.PoliMusicV3.Song dataAccess;

        public Song(string connectionString)
        {
            dataAccess = new DAL.PoliMusicV3.Song(connectionString);
        }

        public DataTable Read() { return dataAccess.Read(); }
    }
}
