using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace XML_LINQ {
    internal class XMLWriterLINQ {
        public static void Write(List<Park> parkList, string destFile) {
            /*
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(new FileStream(destFile, FileMode.OpenOrCreate), settings)) {
                writer.WriteStartElement("RootNode");
                Management.Instance.ParkList.ForEach(p => {
                    writer.WriteStartElement("park");
                    if (p.ID != -1) {
                        writer.WriteAttributeString("id", p.ID.ToString());
                    }
                    writer.WriteElementString("name", p.Name);
                    p.TreeList.ForEach(t => {
                        writer.WriteStartElement("tree");
                        if (t.ID != -1) {
                            writer.WriteAttributeString("id", t.ID.ToString());
                        }
                        writer.WriteElementString("age", t.AgeInYears.ToString());
                        writer.WriteElementString("type", t.Type);
                        writer.WriteEndElement();
                    });
                    writer.WriteEndElement();
                });
                writer.WriteFullEndElement();
            }
            */
            XDocument xdoc = new XDocument(
                new XElement("RootNode",
                    new XElement("park", 
                        new XAttribute("id", 1), 
                    new XElement("name", "Linkin Park"),
                        new XElement("tree", 
                            new XAttribute("id", 1),
                                new XElement("age", 96),
                                new XElement("type", "beech")
                            )
                        )
                    )
                );
            
            xdoc.Save(destFile);
        }
    }
}