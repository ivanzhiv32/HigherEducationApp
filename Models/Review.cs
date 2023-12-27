using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherEducationApp.Models
{
    public enum TypeTonality
    {
        Positive,
        Negative,
        Neutral
    }
    public class Review
    {
        public int Id { get; set; }
        public string TextReview { get; set; }
        public TypeTonality Tonality { get; set; }
    }
}
