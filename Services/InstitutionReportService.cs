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

                //IQueryable<InstitutionReport> c = educationSystemContext.InstitutionReports
                //    .Include(c => c.Year.InstitutionReports)
                //    .Include(c => c.Institution.Region)
                //    .Include(c => c.Indicators).ThenInclude(c => c.TypeIndicator)
                //    .Where(c => c.Institution.Id == id);
                InstitutionReport institutionReport = educationSystemContext.InstitutionReports
                    //.Include(c => c.Year.InstitutionReports)
                    //.Include(c => c.Institution.Region)
                    .Include(c => c.Indicators).ThenInclude(c => c.TypeIndicator)
                    .Where(c => c.Institution.Id == id)
                    .FirstOrDefault(c => c.Year.Year == year);

                //InstitutionReport institutionReport = c.FirstOrDefault(c => c.Year.Year == year);

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
                    .Include(c => c.Year)
                    .Where(c => c.Institution.Id == idInstitution)
                    .FirstOrDefault(c => c.Year.Year == year);
                //InstitutionReport institutionReport = c.FirstOrDefault(c => c.Year.Year == year);
                return institutionReport;
            }
        }
        public Indicator GetIndicatorByNumber(int idInstitution, int year, string numberIndicator)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.Indicators
                    .Include(c => c.TypeIndicator.UnitMeasure)
                    .Where(c => c.InstitutionReport.Year.Year == year);
                Indicator indicator = c.FirstOrDefault(c => c.TypeIndicator.Number == numberIndicator);
                //List<Indicator> indicator = c.FirstOrDefault(c => c.TypeIndicator.Number == numberIndicator);
                return indicator;
            }
        }
        public Institution GetInstitution(int idInstitutionReport)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                var c = educationSystemContext.InstitutionReports
                    .Include(c => c.Institution.Region)
                    .FirstOrDefault(c => c.Institution.Id == idInstitutionReport);
                Institution institution = c.Institution;

                return institution;
            }
        }

        public Dictionary<int, double> GetAverageScore(int idInstitution)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                Dictionary<int, double> averageScore = new Dictionary<int, double>();

                List<InstitutionReport> institutionReports = educationSystemContext.InstitutionReports
                    .Include(c => c.Year)
                    .Where(c => c.Institution.Id == idInstitution).ToList();

                
                foreach(var report in institutionReports)
                {
                    if (report.Year.Year < 2017) continue;
                    Indicator score = educationSystemContext.Indicators
                        .Where(c => c.TypeIndicator.Number == "2")
                        .FirstOrDefault(c => c.InstitutionReport.Id == report.Id);
                    if(score == null)
                    {
                        averageScore.Add(report.Year.Year, 63);
                        continue;
                    }
                    averageScore.Add(report.Year.Year, score.Value);
                }
                return averageScore;
            }
        }
        public Dictionary<int, double> GetMinScore(int idInstitution)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                Dictionary<int, double> minScore = new Dictionary<int, double>();

                List<InstitutionReport> institutionReports = educationSystemContext.InstitutionReports
                    .Include(c => c.Year)
                    .Where(c => c.Institution.Id == idInstitution).ToList();


                foreach (var report in institutionReports)
                {
                    if (report.Year.Year < 2017) continue;
                    if (report.Year.Year == 2021) continue;
                    try
                    {
                        var score = educationSystemContext.Indicators
                            .Where(c => c.TypeIndicator.Id == 5)
                            .FirstOrDefault(c => c.InstitutionReport.Id == report.Id).Value;
                        minScore.Add(report.Year.Year, score);
                    }
                    catch { continue; }
                }
                return minScore;
            }
        }
        public Dictionary<int, double> GetMinScoreRus(int idInstitution)
        {
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                Dictionary<int, double> minScoreRus = new Dictionary<int, double>();

                var indicators = educationSystemContext.Indicators
                    .Include(c => c.TypeIndicator)
                    .Where(c => c.TypeIndicator.Id == 5);

                for (int i = 2017; i < 2024; i++)
                {
                    minScoreRus.Add(i, indicators.Where(c => c.InstitutionReport.Year.Year == i).Sum(c => c.Value) / 
                        indicators.Where(c => c.InstitutionReport.Year.Year == i).Count());
                }
                return minScoreRus;
            }
        }
    }
}
