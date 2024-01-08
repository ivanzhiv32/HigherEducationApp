using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigherEducationApp.Data;
using HigherEducationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HigherEducationApp.Services
{
    class RatingService
    {
        public List<Indicator> SortIndicatorsByName(string nameIndicator)
        {
            using(HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                List<Indicator> indicators = new List<Indicator>();
                if (nameIndicator == "44")
                {
                    indicators = educationSystemContext.Indicators
                    .Include(c => c.InstitutionReport)
                    .Where(c => c.InstitutionReport.Year.Year == 2023)
                    .Where(c => c.TypeIndicator.Number == nameIndicator)
                    .OrderByDescending(c => c.Value).ToList();
                }
                else
                {
                    indicators = educationSystemContext.Indicators
                    .Include(c => c.InstitutionReport)
                    .Where(c => c.InstitutionReport.Year.Year == 2023)
                    .Where(c => c.TypeIndicator.Number == nameIndicator)
                    .OrderBy(c => c.Value).ToList();
                }

            return indicators;
            }
        }
        public List<KeyValuePair<int, double>> SortIndicatorsByGroup(int numGroup)
        {
            Dictionary<int, double> instRepRating = new Dictionary<int, double>();
            List<InstitutionReport> institutionReports;

            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                institutionReports = educationSystemContext.InstitutionReports
                    .Where(c => c.Year.Year==2023).ToList();
            }

            foreach(InstitutionReport institutionReport in institutionReports)
            {
                instRepRating.Add(institutionReport.Id, 0);
            }
            

            string[] numbersIndicators = new string[] { };
            switch (numGroup) {
                case 0: 
                    numbersIndicators = new string[] { "1.1", "1.3", "1.4", "1.5", "1.6", "1.10", "8" };
                    break;
                case 1: 
                    numbersIndicators = new string[] { "2.3", "2.6", "2.7", "2.15", "2.16"};
                    break;
                case 2:
                    numbersIndicators = new string[] { "3.3", "3.12", "35"};
                    break;
                case 3:
                    numbersIndicators = new string[] { "5.1", "5.6", "5.8"};
                    break;
                case 4:
                    numbersIndicators = new string[] { "6.4"};
                    break;
            }

            for (int i = 0; i < numbersIndicators.Length; i++)
            {
                var indicators = SortIndicatorsByName(numbersIndicators[i]);
                foreach(Indicator indicator in indicators)
                {
                    instRepRating[indicator.InstitutionReport.Id] += indicators.IndexOf(indicator) / numbersIndicators.Length;
                }
            }
            var result = instRepRating.ToList();
            result.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            
            return result;
        }

        public List<KeyValuePair<int, double>> GetRatingInstitutions()
        {
            Dictionary<int, double> instRepRating = new Dictionary<int, double>();
            List<InstitutionReport> institutionReports;

            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                institutionReports = educationSystemContext.InstitutionReports
                    .Where(c => c.Year.Year == 2023).ToList();
            }

            foreach (InstitutionReport institutionReport in institutionReports)
            {
                instRepRating.Add(institutionReport.Id, 0);
            }


            for (int i = 0; i < 5; i++)
            {
                var ratingGroup = SortIndicatorsByGroup(i);
                //var x = ratingGroup.ToDictionary<KeyValuePair<int, double>>();
                foreach (var rating in ratingGroup)
                {
                    instRepRating[rating.Key] += ratingGroup.IndexOf(rating) / 5;
                }
            }
            var result = instRepRating.ToList();
            result.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            var y = result.Find(c => c.Key == 8326);
            var t = result.IndexOf(y);
            var x = result.Skip(1196);
            return result;
        }
    }
}
