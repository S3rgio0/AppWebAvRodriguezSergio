using System;
using System.Data;
using DAL.PoliMusicV3;
using EntityLayer.PoliMusicV3;
using EntityLayer.PoliMusicV3.Util;

namespace BLL.PoliMusicV3
{
    public class User
    {
        private readonly DAL.PoliMusicV3.User dataAccess;

        public User(string connectionString)
        {
            dataAccess = new DAL.PoliMusicV3.User(connectionString);
        }

        public bool Save(EntityLayer.PoliMusicV3.User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            EntityLayer.PoliMusicV3.User storedUser = CopyUser(user);
            storedUser.Password = Hash.GeneratePasswordHash(user.Password ?? String.Empty);
            return dataAccess.Save(storedUser);
        }

        public DataTable Read() { return dataAccess.Read(); }

        public bool Update(EntityLayer.PoliMusicV3.User user)
        {
            if (user == null) throw new ArgumentNullException("user");
            return dataAccess.Update(CopyUser(user));
        }

        public bool Delete(int id) { return dataAccess.Delete(id); }

        public EntityLayer.PoliMusicV3.User AuthenticateUser(string userName, string password)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrEmpty(password)) return null;
            return dataAccess.AuthenticateUser(userName.Trim(), Hash.GeneratePasswordHash(password));
        }

        public bool CheckExistUser(string userName) { return dataAccess.CheckExistUser(userName); }
        public bool CheckExistEmail(string email) { return dataAccess.CheckExistEmail(email); }

        public string ValidationsDuplicated(string userName, string email)
        {
            string errors = String.Empty;
            if (!String.IsNullOrWhiteSpace(userName) && CheckExistUser(userName.Trim()))
                errors += "El nombre de usuario ya existe.";
            if (!String.IsNullOrWhiteSpace(email) && CheckExistEmail(email.Trim()))
            {
                if (errors.Length > 0) errors += " ";
                errors += "El correo electrónico ya está registrado.";
            }
            return errors;
        }

        private static EntityLayer.PoliMusicV3.User CopyUser(EntityLayer.PoliMusicV3.User user)
        {
            return new EntityLayer.PoliMusicV3.User(user.ID, user.UserName, user.Password, user.Email,
                user.Birthday, user.UserType, user.Photo);
        }
    }
}
