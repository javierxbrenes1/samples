using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace Programing_in_Csharp
{
    public class Inputclass
    {
       
        //if i pass some invalid json this funcion will throw an ArgumentException
        public void DeserializeAnObjectWithJavascriptSerializer()
        {
            string json = "{\"name\":\"javier brenes\"}";

            var serializer = new JavaScriptSerializer();
            var result = serializer.Deserialize<Dictionary<string, object>>(json);

            Console.WriteLine(result["name"]);
        }


        public void ValidateAnXMlUsingXSD()
        {
            string xsdPath = @"E:\Examen de certificacion C#\file.xsd";
            string xmlPath = @"E:\Examen de certificacion C#\file.xml";

            XmlReader reader = XmlReader.Create(xmlPath);
            XmlDocument document = new XmlDocument();
            document.Schemas.Add("", xsdPath);
            document.Load(reader);
            //define the event
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEvent);

            document.Validate(eventHandler);

            
        }

        static void ValidationEvent(Object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning: {0}", e.Message);
                    break;
                default:
                    break;
            }
        }

    }
}
