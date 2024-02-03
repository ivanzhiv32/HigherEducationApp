using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigherEducationApp.Data;
using HigherEducationApp.Dto.Region;
using HigherEducationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HigherEducationApp.Services
{
    /// <summary>
    /// Служба по работе с региональными отчетами
    /// </summary>
    class RegionService
    {
        /// <summary>
        /// Возвращает общую информацию о регионе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RegionInfoDto GetRegionInfo(int id)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.Regions
                    .Include(m => m.Institutions);

                Region? region = c.FirstOrDefault(k => k.Id == id);

                RegionInfoDto? regionDto = new RegionInfoDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    CountInstitutions = region.Institutions.Count,
                    Region = region
                };
                
                return regionDto;
            }
        }
        /// <summary>
        /// Возвращает годовой отчет региона
        /// </summary>
        /// <param name="id"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public RegionReport GetRegionReport(int id, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.RegionReports
                    .Include(c => c.Region.Institutions)
                    .Include(k => k.YearReport.InstitutionReports)
                    .Where(c => c.Region.Id == id);
                RegionReport? regionReport = c.FirstOrDefault(c => c.YearReport.Year == year);


                //RegionReportDto? regionReportDto = new RegionReportDto()
                //{
                //    Id = regionReport.Id,
                //    Name = regionReport.Region.Name,
                //    Year = regionReport.YearReport.Year,
                //    CountAllStudents = regionReport.CountAllStudents,
                //    CountFullTimeStudents = regionReport.CountFullTimeStudents,
                //    CountFreeFormStudents = regionReport.CountFreeFormStudents,
                //    RegionReport = regionReport,
                //    InstitutionReports = regionReport.YearReport.InstitutionReports,
                //    RegionInfo = GetRegionInfo(id)
                //};
                return regionReport;
            }
        }

        public RegionBranchScienseDto GetBranchesOfScince(int id, int year)
        {
            RegionBranchScienseDto dto = new RegionBranchScienseDto();
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                List<InstitutionReport> institutionReports = educationSystemContext.InstitutionReports
                    .Include(c => c.DistributionBranches).ThenInclude(c => c.BranchScience)
                    .Where(c => c.Institution.Region.Id == id)
                    .Where(c => c.Year.Year == year).ToList();
                List<DistributionBranches> branches = new List<DistributionBranches>();
                foreach (var institution in institutionReports)
                {
                    foreach (var branch in institution.DistributionBranches)
                    {
                        branches.Add(branch);
                    }
                }

                dto = new RegionBranchScienseDto()
                {
                    Social = branches.Where(c => c.BranchScience.Id == 5).Sum(c => c.Value),
                    Education = branches.Where(c => c.BranchScience.Id == 6).Sum(c => c.Value),
                    Humanitarian = branches.Where(c => c.BranchScience.Id == 7).Sum(c => c.Value),
                    Culture = branches.Where(c => c.BranchScience.Id == 8).Sum(c => c.Value),
                    Math = branches.Where(c => c.BranchScience.Id == 10).Sum(c => c.Value),
                    Engineer = branches.Where(c => c.BranchScience.Id == 2).Sum(c => c.Value),
                    Medicine = branches.Where(c => c.BranchScience.Id == 3).Sum(c => c.Value),
                    Village = branches.Where(c => c.BranchScience.Id == 4).Sum(c => c.Value),

                };
            }
            
            return dto;
        }
    }
}
