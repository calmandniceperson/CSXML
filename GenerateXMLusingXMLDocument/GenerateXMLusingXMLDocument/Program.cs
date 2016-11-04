using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GenerateXMLusingXMLDocument
{
    public class Management
    {
        private static Management instance;
        private Management()
        {
            this.ParkList = new List<Park>();
        }
        public static Management Instance
        {
            get
            {
                if (instance == null)
                    instance = new Management();
                return instance;
            }
        }
        public List<Park> ParkList
        {
            get; set;
        }
        public void Print()
        {
            ParkList.ForEach(x => { Console.WriteLine(x.ToString()); });
        }
    }
    public class Tree
    {
        public int ID { get; set; }
        public int AgeInYears { get; set; }
        public string Type { get; set; }
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n\tTree")
                .Append("\tID: " + this.ID + "\n")
                .Append("\t\tAge in Years: " + this.AgeInYears + "\n")
                .Append("\t\tType: " + this.Type + "\n");
            return sb.ToString();
        }
    }
    public class Park
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Tree> TreeList { get; private set; }

        public Park()
        {
            TreeList = new List<Tree>();
        }
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("=== Park ===\n")
                .Append("Name: " + this.Name + "\n");
            foreach (var t in TreeList)
            {
                sb.Append(t.ToString());
            }
            return sb.ToString();
        }
    }

    class Program
    {
        //static List<Park> ParkList = new List<Park>();
        static void Main(string[] args)
        {
            Console.WriteLine("Step 1: Read XML using XMLDocument:");
            ReadXML(".\\baum.xml");
            Management.Instance.Print();
            Console.WriteLine("Step 2: Write XML using XMLDocument.");
            WriteXML(".\\baum2.xml");
            start:
            Console.WriteLine("Press ESC key to exit...");
            if (ConsoleKey.Escape != Console.ReadKey().Key)
                goto start;
        }
        public static void ReadXML(string path)
        {
            if (File.Exists(path))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
                XmlNodeList xmlnlist = xml.GetElementsByTagName("park");
                foreach (XmlNode node in xmlnlist)
                {
                    switch (node.NodeType)
                    {
                        case XmlNodeType.Comment: break;
                        case XmlNodeType.Element:
                            if (node.Name.ToLower().Equals("park"))
                            {
                                Park p = new Park();
                                foreach (XmlAttribute a in node.Attributes)
                                {
                                    if (a.Name.ToLower().Equals("id"))
                                        p.ID = Convert.ToInt32(a.Value);
                                }
                                if (node.HasChildNodes)
                                {
                                    foreach (XmlNode tree in node)
                                    {
                                        if (tree.Name.ToLower() == "name")
                                            p.Name = tree.InnerText;
                                        else if (tree.Name.ToLower() == "tree")
                                        {
                                            Tree t = new Tree();
                                            foreach (XmlAttribute a in tree.Attributes)
                                            {
                                                if (a.Name.ToLower().Equals("id"))
                                                    t.ID = Convert.ToInt32(a.Value);
                                            }
                                            foreach (XmlNode treechild in tree)
                                            {
                                                if (treechild.Name.ToLower() == "age")
                                                    t.AgeInYears = Convert.ToInt32(treechild.InnerText);
                                                else if (treechild.Name.ToLower() == "type")
                                                    t.Type = treechild.InnerText;
                                            }
                                            p.TreeList.Add(t);
                                        }
                                    }
                                }
                                Management.Instance.ParkList.Add(p);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
                Console.WriteLine("File {path} not found");
        }
        public static void WriteXML(string path)
        {
            XmlDocument newXMLDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = newXMLDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = newXMLDoc.DocumentElement;
            newXMLDoc.InsertBefore(xmlDeclaration, root);
            XmlElement rootNode = newXMLDoc.CreateElement(string.Empty, "RootNode", string.Empty);
            newXMLDoc.AppendChild(rootNode);
            foreach (Park p in Management.Instance.ParkList)
            {
                XmlElement parkNode = newXMLDoc.CreateElement(string.Empty, "park", string.Empty);
                parkNode.SetAttribute("id", Convert.ToString(p.ID));
                rootNode.AppendChild(parkNode);
                XmlElement parkName = newXMLDoc.CreateElement(string.Empty, "name", string.Empty);
                XmlText parkNameText = newXMLDoc.CreateTextNode(p.Name);
                parkName.AppendChild(parkNameText);
                parkNode.AppendChild(parkName);
                foreach (Tree t in p.TreeList)
                {
                    XmlElement tree = newXMLDoc.CreateElement(string.Empty, "tree", string.Empty);
                    tree.SetAttribute("id", Convert.ToString(t.ID));
                    XmlElement treeAge = newXMLDoc.CreateElement(string.Empty, "age", string.Empty);
                    XmlText textAge = newXMLDoc.CreateTextNode(Convert.ToString(t.AgeInYears));
                    treeAge.AppendChild(textAge);
                    XmlElement treeType = newXMLDoc.CreateElement(string.Empty, "type", string.Empty);
                    XmlText textType = newXMLDoc.CreateTextNode(t.Type);
                    treeType.AppendChild(textType);
                    tree.AppendChild(treeAge);
                    tree.AppendChild(treeType);
                    parkNode.AppendChild(tree);
                }
            }
            try
            {
                newXMLDoc.Save(path);
                Console.WriteLine($"Successfully wrote the new Doc to {path}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: \n" + e.ToString());
            }

        }
    }
}
