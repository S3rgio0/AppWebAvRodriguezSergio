namespace WebAppPoliMusicV2
{
    using System;
    using Entities;
    using WebAppPoliMusicV2.BLL;

    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si ya hay sesión, redirigir a Song.aspx
                if (Session["User"] != null)
                {
                    Response.Redirect("Song.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Entities.User user = WebAppPoliMusicV2.BLL.User.Login(username, password);

            if (user != null)
            {
                // Login exitoso - guardar objeto User en Session
                Session["User"] = user;
                Response.Redirect("Song.aspx");
            }
            else
            {
                // Login fallido
                lblError.Text = "Credenciales incorrectas";
            }
        }
    }
}

