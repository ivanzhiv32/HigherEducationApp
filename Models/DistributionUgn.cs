using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("distribution_ugn")]
    public class DistributionUgn
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id_institution")]
        public Institution Institution { get; set; }
        [ForeignKey("id_ugn")]
        public Ugn Ugn { get; set; }
        [Column("count_students")]
        public int CountStudents { get; set; }

        public DistributionUgn()
        {
        }

        public DistributionUgn(int id, Institution institution, Ugn ugn, int countStudents)
        {
            Id = id;
            Institution = institution;
            Ugn = ugn;
            CountStudents = countStudents;
        }
    }
}
