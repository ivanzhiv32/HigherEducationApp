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
        [ForeignKey("id_tonality")]
        public Tonality Tonality { get; set; }
        [Column("review")]
        public string Text { get; set; }

        public ReviewOfInstitution(int id, Institution institution, Tonality tonality, string text)
        {
            Id = id;
            Institution = institution;
            Tonality = tonality;
            Text = text;
        }
    }
}
