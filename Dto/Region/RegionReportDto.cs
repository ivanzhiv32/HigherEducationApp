using HigherEducationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherEducationApp.Dto.Region
{
    public class RegionReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int CountAllStudents { get; set; }
        public int CountFullTimeStudents { get; set; }
        public int CountFreeFormStudents { get; set; }
        public RegionReport RegionReport { get; set; }
        public List<Models.Institution> Institutions { get; set; }
        public List<Models.InstitutionReport> InstitutionReports { get; set; } 
        public List<Models.DistributionBranches> DistributionBranches { get; set; }
        public RegionInfoDto RegionInfo{ get; set; }
    }
}
