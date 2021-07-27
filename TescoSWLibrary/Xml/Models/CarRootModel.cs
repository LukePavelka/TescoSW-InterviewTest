using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TescoSWLibrary.Xml.Models
{
    public class CarRootModel
    {
        [XmlElement]
        public List<CarModel> Cars { get; set; }
    }
}
