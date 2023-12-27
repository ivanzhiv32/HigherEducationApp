using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("tonality_review")]
    public class Tonality
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("tonality")]
        public int Value { get; set; }
    }
}
