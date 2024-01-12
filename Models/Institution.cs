using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HigherEducationApp.Models
{
    [Table("institution")]  
    public class Institution
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("adress")]
        public string Adress { get; set; }
        [Column("department")]
        public string Department { get; set; }
        [Column("founder")]
        public string Founder { get; set; }
        [Column("link")]
        public string Site { get; set; }
        [ForeignKey("id_region")]
        public Region Region { get; set; }
        //[Column("year")]
        //public int Year { get; set; } //Под вопросом
        //public double Rating { get; set; } //Из таблицы rating_of_institutions
        
        public virtual List<InstitutionReport> InstitutionReports { get; set; }
        //public List<Indicator> Indicators { get; set; }
        //public List<BranchScience> BranchesScience { get; set; }
        public virtual List<DistributionUgn> Ugns { get; set; }
        public virtual List<VerificationResult> VerificationResults { get; set; }
        public virtual List<ReviewOfInstitution> Reviews { get; set; }
        public virtual List<RatingInstitution> Ratings { get; set; }

        public Institution()
        {
        }

        public Institution(int id, int year)
        {
            Id = id;
        }

        public Institution(int id, string name, string adress, string department, string founder, string site, Region region)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Department = department;
            Founder = founder;
            Site = site;
            Region = region;
        }
    }
}
