using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions.Users
{
    enum TypeRepresentative
    {

    }
    class RepresentativeInstitution : User
    {
        public Institution Institution { get; set; }
        public TypeRepresentative TypeRepresentative { get; set; }
        public RepresentativeInstitution(int id, string name, string surName, string lastName, string login, string password) : base(id, name, surName, lastName, login, password)
        {
        }
    }
}
