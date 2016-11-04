using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XML_LINQ {
    class Program {
        public static string rootAttribute = "ID";
        static void Main(string[] args) {
            Console.Clear();
            // Read Koczwara
            XMLReaderLINQ.Read("baum.xml");
            // Allgemeines Printen des Eingelesenen
            Management.Instance.Print();
            // Write Koczwara
            XMLWriterLINQ.Write(Management.Instance.ParkList, "out.xml");

            Console.ReadLine();
        }

        private static string LINQt(XElement xelement) {
            StringBuilder result = new StringBuilder();
            IEnumerable<XElement> parks = xelement.Elements();
            foreach (var park in parks) {
                result.Append(park.Value);
                if(park.HasAttributes)
                    result.Append(" ID=" + park.Attribute("id").Value);
                result.Append("\n\r");
            }
            return result.ToString();
        }
    }
}
