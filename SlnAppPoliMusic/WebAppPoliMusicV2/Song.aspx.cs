namespace WebAppPoliMusicV2
{
    using System;
    using System.Data;
    using WebAppPoliMusicV2.BLL;

    public partial class Song : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar sesión de usuario
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadSongs();
            }
        }

        private void LoadSongs()
        {
            DataTable songList = WebAppPoliMusicV2.BLL.Song.GetSongs();

            gvSongs.DataSource = songList;
            gvSongs.DataBind();
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}

