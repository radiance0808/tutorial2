using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    class UniversityXML
    {
        [JsonPropertyName("university")]
        public University University { get; set; }
    }
}