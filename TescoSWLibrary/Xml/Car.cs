using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TescoSWLibrary.Xml.Models;

namespace TescoSWLibrary.Xml
{
    public class Car
    {
        public static void XmlSerialise(CarRootModel CarList, string Path)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(CarRootModel));
            using TextWriter Writer = new StreamWriter(Path);
            Serializer.Serialize(Writer, CarList);
        }
        public static CarRootModel XmlDeserialise(string Path)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(CarRootModel));
            CarRootModel NewCarList;
            using (TextReader writer = new StreamReader(Path))
            {
                NewCarList = (CarRootModel)Serializer.Deserialize(writer);
            }
            return NewCarList;
        }
    }
}
