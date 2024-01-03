using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherEducationApp.Dto.Institution
{
    public class EducationalWorkDto
    {
        public double AverageExamScore { get; set; } // (1.1+1.3)/2
        public double MinimumExamScore { get; set; } //1.4
        public int CountWinnersRF { get; set; } //1.5
        public int CountWinnersRegion { get; set; } //1.6
        public double WeightStudentsNextEducation { get; set; } //1.10
        public int EnterprisesWithWhichContracts { get; set; } //8
    }
}
