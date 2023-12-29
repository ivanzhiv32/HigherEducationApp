using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models.Users
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("surname")]
        public string SurName { get; set; }
        [Column("patronymic")]
        public string Patronymic { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("salt")]
        public string Salt { get; set; }
        [Column("email")]
        public string Email { get; set; }
        public Admin? Admin { get; set; }
        public Applicant? Applicant { get; set; }
        public RepresentativeInstitution? RepresentativeInstitution { get; set; }
        public User() { }
        public User(int id, string name, string surName, string patronymic, string login, string password, string salt, string email)
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
