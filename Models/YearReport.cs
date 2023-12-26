using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParsingOfEducationalinstitutions
{
    class YearReport
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("countAllStudents_year")]
        public int CountAllStudents { get; set; }

        [JsonProperty("countFullTimeStudents_year")]
        public int CountFullTimeStudents { get; set; }

        [JsonProperty("countFreeFormStudents_year")]
        public int CountFreeFormStudents { get; set; }

        [JsonProperty("regions_year")]
        public List<Region> Regions { get; set; }

        public YearReport(int year)
        {
            if (year > 2022 || year < 2015) throw new Exception("Веб-ресурс не содержит данные за выбранную дату");
            Year = year;
        }
    }
}
