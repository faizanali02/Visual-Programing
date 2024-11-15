using System;
using System.Xml;

class Program
{
    static void Main()
    {
        // Create the XML file
        CreateXmlFile();

        // Read and display the XML file
        ReadAndDisplayXmlFile();
    }

    static void CreateXmlFile()
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t"
        };

        using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("GPS_Log");

            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", "1/26/2017 5:08:59 PM");
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");
            writer.WriteStartElement("SatteliteInfo");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoSatt", "7");
            writer.WriteEndElement(); // End SatteliteInfo
            writer.WriteEndElement(); // End Position

            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement(); // End Image

            writer.WriteEndElement(); // End GPS_Log
            writer.WriteEndDocument();
        }

        Console.WriteLine("XML file created successfully.");
    }

    static void ReadAndDisplayXmlFile()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("GPS.xml");

        Console.WriteLine(doc.OuterXml);
    }
}
