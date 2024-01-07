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
    class BranchScienceServise
    {
        public InstitutionReport GetReportWithBranchesScience(int idInstitution, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                InstitutionReport institutionReport = educationSystemContext.InstitutionReports
                    .Include(c => c.DistributionBranches).ThenInclude(c => c.BranchScience)
                    .Where(c => c.Institution.Id == idInstitution)
                    .FirstOrDefault(c => c.Year.Year == year);
                return institutionReport;
            }
        }
    }
}
