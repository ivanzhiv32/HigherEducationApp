using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("verification_result")]
    public class VerificationResult
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("subject_verification")] 
        public string SubjectVerification { get; set; }
        [Column("violation")] 
        public string Violation { get; set; }
        [Column("id_institution")]
        public Institution Institution { get; set; }

        public VerificationResult(int id, string status, DateTime date, string subjectVerification, string violation)
        {
            Id = id;
            Status = status;
            Date = date;
            SubjectVerification = subjectVerification;
            Violation = violation;
        }

        public VerificationResult()
        {
        }
    }
}
