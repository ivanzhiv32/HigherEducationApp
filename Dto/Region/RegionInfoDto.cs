using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HigherEducationApp.Models;

namespace HigherEducationApp.Dto.Region
{
    public class RegionInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountInstitutions { get; set; }
        public HigherEducationApp.Models.Region Region { get; set; }
    }
}
