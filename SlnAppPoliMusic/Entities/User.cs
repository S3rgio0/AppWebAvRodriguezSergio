namespace Entities
{
    using System;

    public class User
    {
        private int id_user;
        private string username;
        private string password;
        private string email;
        private DateTime birthday;
        private string user_photo;
        private string user_type;

        public int ID_USER
        {
            get { return id_user; }
            set { id_user = value; }
        }

        public string USERNAME
        {
            get { return username; }
            set { username = value; }
        }

        public string PASSWORD
        {
            get { return password; }
            set { password = value; }
        }

        public string EMAIL
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime BIRTHDAY
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string USER_PHOTO
        {
            get { return user_photo; }
            set { user_photo = value; }
        }

        public string USER_TYPE
        {
            get { return user_type; }
            set { user_type = value; }
        }
    }
}
