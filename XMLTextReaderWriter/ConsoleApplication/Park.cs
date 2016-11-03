using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
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
                .Append("Name: "+ this.Name + "\n");
            foreach (var t in TreeList)
            {
                sb.Append(t.ToString());
            }
            return sb.ToString();
        }
    }
}