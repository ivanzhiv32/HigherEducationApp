using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models.Users
{
    public enum TypeRepresentative
    {

    }
    public class RepresentativeInstitution : User
    {
        [ForeignKey("id_user")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("id_representative")]
        public int TypeRepresentative { get; set; }
        [ForeignKey("id_institution")]
        public Institution Institution { get; set; }

        public RepresentativeInstitution() { }

        public RepresentativeInstitution(int id, string name, string surName, string patronymic, string login, string password, string salt, string email) :
            base(id, name, surName, patronymic, login, password, salt, email)
        {
        }
    }
}
