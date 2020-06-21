using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    public class Studies
    {
        [XmlElement("course", typeof(string))]
        [JsonPropertyName("course")]
        public string Course { get; set; }
        [XmlElement("studiesMode", typeof(string))]
        [JsonPropertyName("studiesMode")]
        public string StudiesMode { get; set; }

        public Studies(string course, string studiesMode)
        {
            Course = course;
            StudiesMode = studiesMode;
        }

       
    }
}