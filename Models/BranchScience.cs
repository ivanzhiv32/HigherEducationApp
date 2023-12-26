using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParsingOfEducationalinstitutions
{
    class BranchScience
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public BranchScience(int id, int name)
        {
            Id = id;
            Name = name;
        }
    }
}
