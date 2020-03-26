using System;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    [Serializable]
    public class Studies
    {
        [XmlElement("course", typeof(string))]
        public string Course { get; set; }
        [XmlElement("StudiesMode", typeof(string))]
        public string StudiesMode { get; set; }
    }
}