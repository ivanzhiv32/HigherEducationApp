using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models.Users
{
    [Table("admins")]
    public class Admin : User
    {
        [ForeignKey("id_user")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Admin() { }

        public Admin(int id, string name, string surName, string patronymic, string login, string password, string salt, string email):
            base(id, name, surName, patronymic, login, password, salt, email)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
            Login = login;
            Password = password;
            Salt = salt;
            Email = email;
        }
    }
}
