using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication
{
    class XmlTextReading
    {       
        public void Read(String path){
            if (!File.Exists(path))
            {
                Console.WriteLine("File {path} not found");
                return;
            } 
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Comment: break;
                    case XmlNodeType.Element:
                        if (reader.Name == "Park")
                        {
                            Park p;
                            if (reader.HasAttributes.ToString() == "id")
                                p.id = reader.GetAttribute("id");
                            while (reader.Read())
                            {
                                if(reader.NodeType == XmlNodeType.EndElement && reader.Name.ToLower() == "park")
                                    break;
                                switch (reader.Name.ToLower())
                                {
                                    case "name":
                                        p.Name = reader.Value;
                                        break;
                                    case "tree":
                                        int?  id = null, age = null;
                                        string type = null;
                                        if (reader.HasAttributes.ToString().ToLower() == "id")
                                            id = int.Parse(reader.GetAttribute("id"));
                                        while (reader.Read())
                                        {
                                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name.ToLower() == "tree")
                                                break;
                                            switch (reader.Name.ToLower())
                                            {
                                                case "age":
                                                    age = int.Parse(reader.Value);
                                                    break;
                                                case "type":
                                                    type = reader.Value;
                                                    break;
                                            }
                                        }
                                        if (id != null && age != null && type != "")
                                            p.TreeList.Add(new Tree(id, age, type));
                                        break;
                                }                                
                            }
                            Management.Instance.ParkList.Add(p);

                        }
                        break;
                    default: break;
                }
                reader.Close();
            }
        }
        

    }
}
