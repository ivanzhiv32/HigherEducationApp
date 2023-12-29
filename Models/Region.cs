using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("region")]
    public class Region
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public virtual List<RegionReport> RegionReports { get; set; }
        public virtual List<Institution> Institutions { get; set; }

        public Region() { }
        
        public Region(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
