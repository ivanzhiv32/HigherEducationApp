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
                Region? region = educationSystemContext.Regions.FirstOrDefault(c => c.Id == id);

                RegionInfoDto? regionDto = new RegionInfoDto()
                {
                    Id = region.Id,
                    Name = region.Name,
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
        public RegionReportDto GetRegionReport(int id, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.RegionReports
                    .Include(c => c.Region)
                    .Include(k => k.YearReport)
                    .Where(c => c.Region.Id == id);
                RegionReport? regionReport = c.FirstOrDefault(c => c.YearReport.Year == year);
                //RegionReport? regionReport = educationSystemContext.RegionReports
                //    .Include(c => c.Region)
                //    .Include(k => k.YearReport)
                //    .Where(c => c.Region.Id == id)
                //    .FirstOrDefaultAsync(c => c.YearReport.Year == year);
                //RegionReport? regionReport = educationSystemContext.RegionReports.FirstOrDefault(n => n.Region.Id == id & n.YearReport.Year == year);

                RegionReportDto? regionReportDto = new RegionReportDto()
                {
                    Id = regionReport.Id,
                    Name = regionReport.Region.Name,
                    Year = regionReport.YearReport.Year,
                    CountAllStudents = regionReport.CountAllStudents,
                    CountFullTimeStudents = regionReport.CountFullTimeStudents,
                    CountFreeFormStudents = regionReport.CountFreeFormStudents,
                };
                return regionReportDto;
            }
        }
    }
}
