using AngleSharp.Html.Dom;
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
    class Region
    {
        [JsonProperty("id_region")]
        public int Id { get; set; }

        [JsonProperty("name_region")]
        public string Name { get; set; }

        [JsonProperty("countAllStudents_region")]
        public int CountAllStudents { get; set; }

        [JsonProperty("countFullTimeStudents_region")]
        public int CountFullTimeStudents { get; set; }

        [JsonProperty("countFreeFormStudents_region")]
        public int CountFreeFormStudents { get; set; }
        [JsonIgnore]
        public int Year { get; set; }

        [JsonProperty("institutions_region")]
        public List<Institution> institutions { get; set; }

        public Region(int id, int year)
        {
            Id = id;
            Year = year;
        }
    }
}
