using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Dto
{
    public class YearReportDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int CountAllStudents { get; set; }
        public int CountFullTimeStudents { get; set; }
        public int CountFreeFormStudents { get; set; }
    }
}
