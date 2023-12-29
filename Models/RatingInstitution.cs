using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("rating_of_institutions")]
    public class RatingInstitution
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id_institution")]
        public Institution Institution { get; set; }
        [ForeignKey("id_year")]
        public YearReport YearReport { get; set; }
        [Column("rating")]
        public double Rating { get; set; }

        public RatingInstitution(int id, Institution institution, YearReport yearReport, double rating)
        {
            Id = id;
            Institution = institution;
            YearReport = yearReport;
            Rating = rating;
        }

        public RatingInstitution()
        {
        }
    }
}
