using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp
{
    [Table("links_ready_data")]
    public class LinkReady
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("link")]
        public string Link { get; set; }
    }
}
