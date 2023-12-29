using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("years_reports")]
    public class YearReport
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("year")]
        public int Year { get; set; }

        [Column("count_all_students")]
        public int CountAllStudents { get; set; }

        [Column("count_fulltime_students")]
        public int CountFullTimeStudents { get; set; }

        [Column("count_freeform_students")]
        public int CountFreeFormStudents { get; set; }

        public virtual List<InstitutionReport> InstitutionReports { get; set; }
        public List<RegionReport> RegionReports { get; set; }

        public YearReport(int year)
        {
            if (year > 2022 || year < 2015) throw new Exception("Веб-ресурс не содержит данные за выбранную дату");
            Year = year;
        }

        public YearReport(int id, int year, int countAllStudents, int countFullTimeStudents, int countFreeFormStudents)
        {
            Id = id;
            Year = year;
            CountAllStudents = countAllStudents;
            CountFullTimeStudents = countFullTimeStudents;
            CountFreeFormStudents = countFreeFormStudents;
        }

        public YearReport(int id, int year) : this(id)
        {
            Year = year;
        }

        public YearReport()
        {
        }
    }
}
