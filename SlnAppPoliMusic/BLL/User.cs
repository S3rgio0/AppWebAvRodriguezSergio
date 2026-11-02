namespace BLL
{
    using System;
    using DAL;
    using Entities;
    using Util;

    public class User
    {
        private DAL.User dalUser;

        public User()
        {
            dalUser = new DAL.User();
        }

        public Entities.User Login(string username, string plainPassword)
        {
            if (username == null || username.Trim().Length == 0)
            {
                return null;
            }

            if (plainPassword == null || plainPassword.Trim().Length == 0)
            {
                return null;
            }

            string hashedPassword = Hash.ComputeSHA1(plainPassword);

            Entities.User user = dalUser.Login(username, hashedPassword);

            return user;
        }

        public bool Register(string username, string plainPassword, string email, DateTime birthday, string userPhoto, string userType)
        {
            if (username == null || username.Trim().Length == 0)
            {
                return false;
            }

            if (plainPassword == null || plainPassword.Trim().Length == 0)
            {
                return false;
            }

            if (email == null || email.Trim().Length == 0)
            {
                return false;
            }

            if (dalUser.UserExists(username))
            {
                return false;
            }

            string hashedPassword = Hash.ComputeSHA1(plainPassword);

            Entities.User user = new Entities.User();
            user.USERNAME = username;
            user.PASSWORD = hashedPassword;
            user.EMAIL = email;
            user.BIRTHDAY = birthday;
            user.USER_PHOTO = userPhoto;
            user.USER_TYPE = userType;

            bool result = dalUser.Register(user);

            return result;
        }
    }
}
