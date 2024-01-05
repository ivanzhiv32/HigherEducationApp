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
                
                IQueryable<InstitutionReport> c = educationSystemContext.InstitutionReports
                    .Include(c => c.Year.InstitutionReports)
                    .Include(c => c.Institution.Region)
                    .Where(c => c.Institution.Id == id);

                InstitutionReport institutionReport = c.FirstOrDefault(c => c.Year.Year == year);

                return institutionReport;
            }
        }
        public List<InstitutionReport> GetInstitutionReports(int id, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {

                IQueryable<InstitutionReport> c = educationSystemContext.InstitutionReports
                    .Include(c => c.Year.InstitutionReports)
                    .Include(c => c.Institution.Region)
                    //.Include(c => c.Indicators).ThenInclude(c => c.TypeIndicator)
                    //.Include(c => c.DistributionBranches).ThenInclude(c => c.BranchScience)
                    //.Include(c => c.Institution.Ugns).ThenInclude(c => c.Ugn)
                    .Where(c => c.Institution.Id == id);

                List<InstitutionReport> institutionReports = c.ToList<InstitutionReport>();

                return institutionReports;
            }
        }

        public List<DistributionBranches> GetBranchesScience(int idInstitutionReport)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.DistributionBranches
                    .Include(c => c.BranchScience)
                    .Where(c => c.InstitutionReport.Id == idInstitutionReport);
                return c.ToList();
            }
        }
        public List<DistributionUgn> GetUgns(int idInstitution)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.DistributionUgns
                    .Include(c => c.Ugn)
                    .Where(c => c.Institution.Id == idInstitution);
                return c.ToList();
            }
        }

        public InstitutionReport GetReportWithIndicators(int idInstitution, int year)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var institutionReport = educationSystemContext.InstitutionReports
                    .Include(c => c.Indicators).ThenInclude(c => c.TypeIndicator.UnitMeasure)
                    .Where(c => c.Institution.Id == idInstitution)
                    .FirstOrDefault(c => c.Year.Year == year);
                //InstitutionReport institutionReport = c.FirstOrDefault(c => c.Year.Year == year);
                return institutionReport;
            }
        }
        public List<Indicator> GetIndicatorsByNumber(int idInstitution, string numberIndicator, int currentYear)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.Indicators
                    .Where(c => c.InstitutionReport.Institution.Id == idInstitution)
                    .Include(c => c.TypeIndicator.UnitMeasure).ToList();
                //List<Indicator> indicator = c.FirstOrDefault(c => c.TypeIndicator.Number == numberIndicator);
                return c;
            }
        }
    }
}
