using HigherEducationApp.Data;
using HigherEducationApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherEducationApp.Services
{
    class InstitutionReportService
    {
        public InstitutionReport GetInstitutionReport(int id, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var x = educationSystemContext.TypeIndicators
                    .Include(c => c.Indicators)
                    .Where(c => c.Number == "1.1");
                var c = educationSystemContext.InstitutionReports
                    .Include(c => c.Year.InstitutionReports)
                    .Include(c => c.Institution.Region)
                    .Where(c => c.Institution.Id == id);
                
                InstitutionReport institutionReport = c.FirstOrDefault(c => c.Year.Year == year);

                return institutionReport;
            }
        }
    }
}
