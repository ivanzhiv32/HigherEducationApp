using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherEducationApp.Dto.Institution
{
    public class InstitutionInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Department { get; set; }
        public string Founder { get; set; }
        public string Site { get; set; }
        public string RegionName { get; set; }
    }
}
