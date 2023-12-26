using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions.Users
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string surName, string lastName, string login, string password)
        {
            Id = id;
            Name = name;
            SurName = surName;
            LastName = lastName;
            Login = login;
            Password = password;
        }
    }
}
