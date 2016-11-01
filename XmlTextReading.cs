using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication
{
    public class XmlTextReading
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
                        if (reader.Name.ToLower() == "park")
                        {
                            Park p = new Park();
                            if (reader.HasAttributes)
                                p.ID = int.Parse(reader.GetAttribute("id"));
                            while (reader.Read())
                            {
                                if(reader.NodeType == XmlNodeType.EndElement && reader.Name.ToLower() == "park")
                                    break;
                                switch (reader.Name.ToLower())
                                {                                   
                                    case "name":
                                        if (reader.NodeType != XmlNodeType.EndElement)
                                        {
                                            reader.Read();
                                            p.Name = reader.Value;
                                        }
                                        break;
                                    case "tree":
                                        int id = -1, age = -1;
                                        string type = null;
                                        if (reader.HasAttributes)
                                            id = int.Parse(reader.GetAttribute("id"));
                                        while (reader.Read())
                                        {
                                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name.ToLower() == "tree")
                                            {
                                                if (id != -1 && age != -1 && type != "")
                                                    p.TreeList.Add(new Tree(id, age, type));

                                                break;
                                            }
                                            switch (reader.Name.ToLower())
                                            {
                                                case "age":
                                                    if (reader.NodeType != XmlNodeType.EndElement)
                                                    {
                                                        int result = 0;
                                                        while (result == 0)
                                                        {
                                                            reader.Read();
                                                            if (int.TryParse(reader.Value, out result))
                                                                age = result;
                                                        }
                                                    }
                                                    break;
                                                case "type":
                                                    if (reader.NodeType != XmlNodeType.EndElement)
                                                    {
                                                        reader.Read();
                                                        type = reader.Value;
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                }                                
                            }
                            Management.Instance.ParkList.Add(p);
                        }
                        break;
                    default: break;
                }
            }
        }
    }
}
