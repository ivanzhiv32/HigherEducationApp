using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("distribution_of_branches")]
    public class DistributionBranches
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id_institution_report_year")]
        public InstitutionReport InstitutionReport { get; set; }
        [ForeignKey("id_branches")]
        public BranchScience BranchScience { get; set; }
        [Column("value")]
        public int Value { get; set; }

        public DistributionBranches(int id, InstitutionReport institutionReport, BranchScience branchScience, int value)
        {
            Id = id;
            InstitutionReport = institutionReport;
            BranchScience = branchScience;
            Value = value;
        }
    }
}
