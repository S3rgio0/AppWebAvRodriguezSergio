using System;
using System.Configuration;
using System.Globalization;
using BLL.PoliMusicV3;
using EntityLayer.PoliMusicV3;
using EntityLayer.PoliMusicV3.Util;

namespace WebAppPoliMusicV3
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            lblMessage.CssClass = "form-message text-danger";
            if (String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) ||
                String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                lblMessage.Text = "Completa todos los campos obligatorios.";
                return;
            }
            if (!String.Equals(txtPassword.Text, txtConfirmPassword.Text, StringComparison.Ordinal))
            {
                lblMessage.Text = "Las contraseñas no coinciden.";
                return;
            }
            DateTime birthday;
            if (!DateTime.TryParseExact(txtBirthday.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out birthday))
            {
                lblMessage.Text = "Ingresa la fecha con el formato dd/MM/yyyy.";
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["BDD_PoliMusicConnectionString"].ConnectionString;
            BLL.PoliMusicV3.User businessUser = new BLL.PoliMusicV3.User(connectionString);
            string duplicateErrors = businessUser.ValidationsDuplicated(txtName.Text.Trim(), txtEmail.Text.Trim());
            if (!String.IsNullOrEmpty(duplicateErrors))
            {
                lblMessage.Text = duplicateErrors;
                return;
            }

            try
            {
                string photoPath = uploadPhoto.HasFile
                    ? FileManagement.SaveImageOnServer(uploadPhoto.PostedFile)
                    : FileManagement.SaveDefaultImageOnServer();
                EntityLayer.PoliMusicV3.User newUser = new EntityLayer.PoliMusicV3.User
                {
                    UserName = txtName.Text.Trim(),
                    Password = txtPassword.Text,
                    Email = txtEmail.Text.Trim(),
                    Birthday = birthday.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    UserType = Constants.ID_USER_NORMAL,
                    Photo = photoPath
                };

                if (!businessUser.Save(newUser))
                {
                    lblMessage.Text = "No se pudo crear la cuenta. Inténtalo de nuevo.";
                    return;
                }

                Response.Redirect(ResolveUrl("~/Login.aspx?registered=1"), false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                lblMessage.Text = Server.HtmlEncode(ex.Message);
            }
        }
    }
}
