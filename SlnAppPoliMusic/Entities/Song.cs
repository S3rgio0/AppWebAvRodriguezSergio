namespace Entities
{
    public class Song
    {
        private int id_song;
        private string title;
        private string file_path;

        public int ID_SONG
        {
            get { return id_song; }
            set { id_song = value; }
        }

        public string TITLE
        {
            get { return title; }
            set { title = value; }
        }

        public string FILE_PATH
        {
            get { return file_path; }
            set { file_path = value; }
        }
    }
}
