using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("units_measure")]
    public class UnitMeasure
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public UnitMeasure()
        {
        }

        public UnitMeasure(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
