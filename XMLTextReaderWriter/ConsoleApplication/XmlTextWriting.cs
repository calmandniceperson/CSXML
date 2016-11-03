using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication
{
    class XmlTextWriting
    {
        public void Write(List<Park> parks, string dest)
        {
            XmlTextWriter writer = new XmlTextWriter(dest,null);
            writer.WriteStartElement("RootNode");
            foreach (Park p in parks)
            {
                writer.WriteStartElement("park");
                if (p.ID != -1)
                    writer.WriteAttributeString("id", p.ID.ToString());
                foreach (Tree t in p.TreeList)
                {
                    writer.WriteStartElement("tree");
                    if (t.ID != -1)
                        writer.WriteAttributeString("id", t.ID.ToString());
                    writer.WriteElementString("age", t.AgeInYears.ToString());
                    writer.WriteElementString("type", t.Type);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
