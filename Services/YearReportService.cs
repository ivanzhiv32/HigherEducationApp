using HigherEducationApp.Data;
using HigherEducationApp.Dto;
using HigherEducationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HigherEducationApp.Services
{
    /// <summary>
    /// Служба по работе с годовыми отчетами
    /// </summary>
    public class YearReportService
    { 
        /// <summary>
        /// Возвращает отчет за год
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public YearReportDto GetYearReport(int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                YearReport? yearReport = educationSystemContext.YearReports.FirstOrDefault(c => c.Year == year);

                YearReportDto? yearReportDto = new YearReportDto()
                {
                    Id = yearReport.Id,
                    Year = yearReport.Year,
                    CountAllStudents = yearReport.CountAllStudents,
                    CountFullTimeStudents = yearReport.CountFullTimeStudents,
                    CountFreeFormStudents = yearReport.CountFreeFormStudents,
                };
                return yearReportDto;
            }
        }
    }
}
