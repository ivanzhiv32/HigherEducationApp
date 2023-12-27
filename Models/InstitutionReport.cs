using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("institution_reports")]
    public class InstitutionReport
    {
        [ForeignKey("id_institution")]
        public Institution Institution { get; set; }
        [ForeignKey("id_year")]
        public virtual YearReport Year { get; set; }
        public virtual List<Indicator> Indicators { get; set; }
        public virtual List<DistributionBranches> DistributionBranches { get; set; }

        public InstitutionReport()
        {
        }

        public InstitutionReport(Institution institution, YearReport year, List<Indicator> indicators)
        {
            Institution = institution;
            Year = year;
            Indicators = indicators;
        }

        public InstitutionReport(Institution institution, YearReport year)
        {
            Institution = institution;
            Year = year;
        }
    }
}
