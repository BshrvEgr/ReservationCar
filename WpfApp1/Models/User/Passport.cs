using System;

namespace WpfApp1.Models.User
{
    public class Passport
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public DateTime DateBirthday { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
    }
}
