using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TescoSWLibrary.Xml.Models
{
    public class CarModel
    {
        [XmlElement]
        public string Series { get; set; }
        public DateTime Sale { get; set; }
        public double Price { get; set; }
        public double DPH { get; set; }
    }
}
