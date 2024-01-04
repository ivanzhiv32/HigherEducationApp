using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HigherEducationApp.Models
{
    [Table("values_indicators")]
    public class Indicator
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("value")]
        public double Value { get; set; }
        [ForeignKey("id_institution_report_year")]
        public InstitutionReport InstitutionReport { get; set; }
        [ForeignKey("id_name_indicator")]
        public TypeIndicator TypeIndicator { get; set; }
        public Indicator() { }

        public Indicator(int id, InstitutionReport institutionReport, TypeIndicator typeIndicator, double value)
        {
            Id = id;
            InstitutionReport = institutionReport;
            TypeIndicator = typeIndicator;
            Value = value;
        }

        public Indicator(int id, InstitutionReport institutionReport, TypeIndicator typeIndicator)
        {
            Id = id;
            InstitutionReport = institutionReport;
            TypeIndicator = typeIndicator;
        }
    }
}