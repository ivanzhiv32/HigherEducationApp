using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherEducationApp.Dto.Institution
{
    public class InfrastructureDto
    {
        public double AreaOfEducationalAndLaboratory { get; set; } //5.1
        public double CountComputers { get; set; } //5.6
        public double CountPrintedEducationalPublications { get; set; } //5.8
        public double PercentStudentsWithoutHostel { get; set; } //44 (отрицительный фактор)
    }
}
