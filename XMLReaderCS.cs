/*
 * Author(s): Michael Koeppl
 */

using System;
using System.IO;
using System.Xml;

namespace ConsoleApplication
{
    public class XMLReaderCS
    {
        public static void Read(string sourceFile) {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"File {sourceFile} not found");
                return;
            }
            XmlReader reader = XmlReader.Create(sourceFile);
            while (reader.Read())
            {
                processElement(reader);
            }
        }
        
        private static void processElement(XmlReader reader)
        {
            int id = -1;
            switch (reader.Name)
            {
                case "park":
                    if (reader.HasAttributes)
                    {
                        id = int.Parse(reader.GetAttribute("id"));
                    }
                    processPark(reader);
                    break;
            }
        }
        
        private static void processTree(Park parentPark, XmlReader reader)
        {
            int ageInYears = -1, id = -1 ;
            string type = string.Empty;
            
            if (reader.HasAttributes)
            {
                id = int.Parse(reader.GetAttribute("id"));
            }
            
            while (reader.Read())
            {
                if (reader.Name == "tree" && reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }
                
                switch (reader.Name)
                {
                    case "age":
                        ageInYears = reader.ReadElementContentAsInt();
                        break;
                    case "type":
                        type = reader.ReadElementContentAsString();
                        break;
                }
                if (ageInYears != -1 && id != -1 && type != string.Empty) {
                    parentPark.TreeList.Add(new Tree(id, ageInYears, type));
                }
            }
        }
        
        private static void processPark(XmlReader reader)
        {
            Park park = new Park();
            if (reader.HasAttributes)
            {
                park.ID = int.Parse(reader.GetAttribute("id"));
            }
            while (reader.Read())
            {
                if (reader.Name == "park" && reader.NodeType == XmlNodeType.EndElement)
                {
                    break;
                }
                switch (reader.Name)
                {
                    case "name":
                        park.Name = reader.ReadElementContentAsString();
                        break;
                    case "tree":
                        processTree(park, reader);
                        break;
                }
            }
            Management.Instance.ParkList.Add(park);
        }
    }
}