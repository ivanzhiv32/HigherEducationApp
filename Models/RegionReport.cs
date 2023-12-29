using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("region_report_year")]
    public class RegionReport
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id_region")]
        public Region Region { get; set; }

        [ForeignKey("id_year")]
        public YearReport YearReport { get; set; }

        [Column("count_all_students")]
        public int CountAllStudents { get; set; }

        [Column("count_fulltime_students")]
        public int CountFullTimeStudents { get; set; }

        [Column("count_freeform_students")]
        public int CountFreeFormStudents { get; set; }

        public RegionReport() { }

        public RegionReport(int id, Region region, YearReport year)
        {
            Id = id;
            Region = region;
            YearReport = year;
        }

        public RegionReport(int id, Region region, YearReport yearReport, int countAllStudents, int countFullTimeStudents, int countFreeFormStudents)
        {
            Id = id;
            Region = region;
            YearReport = yearReport;
            CountAllStudents = countAllStudents;
            CountFullTimeStudents = countFullTimeStudents;
            CountFreeFormStudents = countFreeFormStudents;
        }
    }
}
