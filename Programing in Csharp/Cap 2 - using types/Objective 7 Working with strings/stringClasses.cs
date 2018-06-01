using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Programing_in_Csharp
{
    public class stringClasses
    {
        public string usingStringWriterAndXmlWriter()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }

            return stringWriter.ToString();
        }


        public void usingStringReaderandXMLReader()
        {
            var stringReader = new StringReader(usingStringWriterAndXmlWriter());
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("en-US"));
                Console.WriteLine(price);
            }
        }


        public void useIndexOfandLastIndexOf()
        {
            string value = "My sample value";
            int indexOfp = value.IndexOf('p');
            int lastIndexOfm = value.LastIndexOf('m');
        }

        public void useStartsWithAndEndsWith() {
            string value = "<mycustominput>";
            if (value.StartsWith("<")) { }
            if (value.EndsWith(">")) { }
        }

        public void usesubstring()
        {
            string value = "my sample value";
            string substring = value.Substring(3, 6);
        }

        public void useRegExs() {
            string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.?)";

            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };
            foreach (string name in names)
                Console.WriteLine(Regex.Replace(name, pattern, string.Empty));
            

        }

        public void enumeratingStrings()
        {
            string value = "my custom value";

            foreach (char c in value)
            {
                Console.WriteLine(c);
            }

        }

        public void splitText() {
            foreach (string word in "my sentence separated by spaces".Split(' '))
            {
                Console.WriteLine(word);
            }
        }

        public void StringFormatting()
        {
            double cost = 1234.56;
            Console.WriteLine(cost.ToString());
            Console.WriteLine(cost.ToString("C"));
            Console.WriteLine(cost.ToString("C", new CultureInfo("en-US")));
        }


        public void DateTimeFormatting() {
            DateTime d = new DateTime(2018, 5, 22);
            CultureInfo provider = new CultureInfo("en-US");


            Console.WriteLine(d.ToString("d", provider));
            Console.WriteLine(d.ToString("D", provider));
            Console.WriteLine(d.ToString("M", provider));

        }

    }

    //overriding ToString()
    class PersonS {

        public PersonS(string first, string second)
        {
            this.Name = first;
            this.LastName = second;
        }

        public string Name { get; set; }
        public string LastName { get; set; }

        //custom formatting
        public string ToString(string format)
        {

            if (string.IsNullOrEmpty(format) || format == "G") format = "FL";

            format = format.Trim().ToUpperInvariant();

            switch (format) {

                case "FL":
                    return Name + " " + LastName;
                case "LF":
                    return LastName + " " + Name;
                case "FSL":
                    return Name + ", " + LastName;
                case "LSF":
                    return LastName + ", " + Name;
                default:
                    throw new FormatException($"the {format} format string is not supported");
            }
            
        }

    }


}
