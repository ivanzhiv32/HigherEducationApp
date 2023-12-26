using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions
{
    enum TypeTonality
    {
        Positive,
        Negative,
        Neutral
    }
    class Review
    {
        public int Id { get; set; }
        public string TextReview { get; set; }
        public TypeTonality Tonality { get; set; }
    }
}
