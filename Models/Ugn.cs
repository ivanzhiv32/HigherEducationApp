using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("ugn")]
    public class Ugn
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public Ugn(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Ugn()
        {
        }
    }
}
