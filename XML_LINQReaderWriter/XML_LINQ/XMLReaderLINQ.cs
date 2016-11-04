using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace XML_LINQ {
    internal class XMLReaderLINQ {

        internal static void Read(string sourceFile) {
            if (!File.Exists(sourceFile)) {
                Console.WriteLine($"File {sourceFile} not found");
                return;
            }
            XElement xd = XElement.Load(sourceFile);
            IEnumerable<XElement> parks = xd.Elements();
            foreach (XElement park in parks) {
                processElement(park);
            }
        }

        private static void processElement(XElement xpark) {
            if (xpark.Name == "park") {
                processPark(xpark);
            }
        }

        private static void processPark(XElement xpark) {
            Park park = new Park();
            if (xpark.HasAttributes) {
                park.ID = Convert.ToInt32(xpark.Attribute("id").Value);
                park.Name = xpark.Element("name").Value;
            }
            IEnumerable<XElement> trees = xpark.Elements("tree");
            foreach (XElement tree in trees) {
                processTree(tree, park);
            }
            Management.Instance.ParkList.Add(park);
        }

        private static void processTree(XElement tree, Park park) {
            int id = 0, age = 0;
            string type = null;

            id = Convert.ToInt32(tree.Attribute("id").Value);
            age = Convert.ToInt32(tree.Element("age").Value);
            type = tree.Element("type").Value;

            park.TreeList.Add(new Tree(id, age, type));
        }
    }
}