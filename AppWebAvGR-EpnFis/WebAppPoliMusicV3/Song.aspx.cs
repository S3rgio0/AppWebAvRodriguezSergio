using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EntityLayer.PoliMusicV3;

namespace WebAppPoliMusicV3
{
    public partial class Song : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            User currentUser = Session["CurrentUser"] as User;
            string userName = currentUser == null ? Context.User.Identity.Name : currentUser.UserName;
#if DEBUG
            if (String.IsNullOrWhiteSpace(userName)) userName = "sergio.rodriguez";
#endif
            if (String.IsNullOrWhiteSpace(userName)) userName = "invitado";
            litUserName.Text = userName;

            string connectionString = ConfigurationManager.ConnectionStrings["BDD_PoliMusicConnectionString"].ConnectionString;
            DataTable songs;
            try
            {
                songs = new BLL.PoliMusicV3.Song(connectionString).Read();
            }
            catch (SqlException)
            {
#if DEBUG
                songs = CreatePreviewSongs();
                lblDataMode.Text = "Vista previa local: SQL Server no está disponible. Se muestran canciones de demostración.";
                lblDataMode.Visible = true;
#else
                throw;
#endif
            }

            lblSongCount.Text = songs.Rows.Count + (songs.Rows.Count == 1 ? " canción" : " canciones");
            gvSongs.DataSource = songs;
            gvSongs.DataBind();
        }

#if DEBUG
        private DataTable CreatePreviewSongs()
        {
            DataTable songs = new DataTable("TBL_SONG");
            songs.Columns.Add("ID_SONG", typeof(int));
            songs.Columns.Add("TITLE", typeof(string));
            songs.Columns.Add("FILE_PATH", typeof(string));
            songs.Columns.Add("PLAY_COUNT", typeof(int));

            string sampleAudio = ResolveUrl("~/SongFiles/bensound-adventure.mp3");
            string[] titles = { "Adventure", "Dreams", "Energy", "Scifi", "Tomorrow" };
            for (int index = 0; index < titles.Length; index++)
                songs.Rows.Add(index + 1, titles[index], sampleAudio, index);
            return songs;
        }
#endif
    }
}
