using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("name_indicators")]
    public class TypeIndicator
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("number")]
        public double Number { get; set; }
        [ForeignKey("id_unit_measure")]
        public UnitMeasure UnitMeasure { get; set; }

        //public virtual List<Indicator> Indicators { get; set; }

        public TypeIndicator(int id, string name, double number, UnitMeasure unitMeasure)
        {
            Id = id;
            Name = name;
            Number = number;
            UnitMeasure = unitMeasure;
        }
    }
}
