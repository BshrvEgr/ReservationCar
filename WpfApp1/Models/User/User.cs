using System;

namespace WpfApp1.Models.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public int Age { get { return Convert.ToInt32(DateTime.Now - UserPassport.DateBirthday); } }
        public Passport UserPassport { get; set; }
    }
}
