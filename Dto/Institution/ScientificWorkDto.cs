using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherEducationApp.Dto.Institution
{
    public class ScientificWorkDto
    {
        public double NumberOfCitationsPublications { get; set; } //2.3
        public double CountPublications { get; set; } //2.6
        public double ScopeOfScientificResearch { get; set; } //2.7
        public int CountScientificJournalsPublished { get; set; } //2.15
        public double CountGrantsReceived { get; set; } //2.16
    }
}
