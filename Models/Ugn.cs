using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions
{
    class Ugn
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Ugn(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
