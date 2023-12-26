using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions.Users
{
    class Applicant : User
    {
        public Applicant(int id, string name, string surName, string lastName, string login, string password) : base(id, name, surName, lastName, login, password)
        {
        }
    }
}
