using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherEducationApp.Models.Users
{
    public enum TypeRepresentative
    {

    }
    public class RepresentativeInstitution : User
    {
        //public Institution Institution { get; set; }
        public TypeRepresentative TypeRepresentative { get; set; }
        public RepresentativeInstitution(int id, string name, string surName, string patronymic, string login, string password, string salt, string email) :
            base(id, name, surName, patronymic, login, password, salt, email)
        {
        }
    }
}
