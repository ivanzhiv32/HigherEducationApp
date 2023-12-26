using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions
{
    class VerificationResult
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string SubjectVerification { get; set; }
        public string Violation { get; set; }

        public VerificationResult(int id, string status, DateTime date, string subjectVerification, string violation)
        {
            Id = id;
            Status = status;
            Date = date;
            SubjectVerification = subjectVerification;
            Violation = violation;
        }
    }
}
