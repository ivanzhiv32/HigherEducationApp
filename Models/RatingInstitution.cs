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
        [Column("rating_education")]
        public int? RatingEducation { get; set; }
        [Column("rating_science")]
        public int? RatingScience { get; set; }
        [Column("rating_finance")]
        public int? RatingFinance { get; set; }

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

        public RatingInstitution(Institution institution, YearReport yearReport, double rating)
        {
            Institution = institution;
            YearReport = yearReport;
            Rating = rating;
        }

        public RatingInstitution(Institution institution, YearReport yearReport, double rating, int ratingEducation, int ratingScience, int ratingFinance) : this(institution, yearReport, rating)
        {
            RatingEducation = ratingEducation;
            RatingScience = ratingScience;
            RatingFinance = ratingFinance;
        }
    }
}
