using System;
using System.Configuration;
using System.Web.Security;
using EntityLayer.PoliMusicV3;

namespace WebAppPoliMusicV3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
#if DEBUG
            if (!IsPostBack)
            {
                txtLogin.Text = "sergio.rodriguez";
                txtPassword.Text = "12345678";
            }
#endif
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDD_PoliMusicConnectionString"].ConnectionString;
            EntityLayer.PoliMusicV3.User user = new BLL.PoliMusicV3.User(connectionString).AuthenticateUser(txtLogin.Text, txtPassword.Text);
            if (user == null)
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
                return;
            }

            FormsAuthentication.SetAuthCookie(user.UserName, false);
            Session["CurrentUser"] = user;
            Response.Redirect(ResolveUrl("~/"), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
