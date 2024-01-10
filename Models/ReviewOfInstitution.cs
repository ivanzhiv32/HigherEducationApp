using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("review_of_institutions")]
    public class ReviewOfInstitution
    {
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("id_institution")]
        public Institution Institution { get; set; }
        //[ForeignKey("id_institution")]
        //public int InstitutionId { get; set; }
        [Column("id_tonality")]
        public int Tonality { get; set; }
        [Column("review")]
        public string Text { get; set; }
        [Column("author_status")]
        public string AuthorStatus { get; set; }
        public ReviewOfInstitution(Institution institution, int tonality, string text, string authorStatus)
        {
            Institution = institution;
            Tonality = tonality;
            Text = text;
            AuthorStatus = authorStatus;
        }

        public ReviewOfInstitution()
        {
        }

        public ReviewOfInstitution(int id, Institution institution, int tonality, string text, string authorStatus)
        {
            Id = id;
            Institution = institution;
            Tonality = tonality;
            Text = text;
            AuthorStatus = authorStatus;
        }

        //public ReviewOfInstitution(int institutionId, int tonality, string text, string authorStatus)
        //{
        //    InstitutionId = institutionId;
        //    Tonality = tonality;
        //    Text = text;
        //    AuthorStatus = authorStatus;
        //}
    }
}
