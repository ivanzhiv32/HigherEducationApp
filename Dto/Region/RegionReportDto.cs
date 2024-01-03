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
        public List<InstitutionReport> InstitutionReports { get; set; } 
        public List<DistributionBranches> DistributionBranches { get; set; }
        public RegionInfoDto RegionInfo{ get; set; }
    }
}
