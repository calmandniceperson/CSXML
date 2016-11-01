/*
 * Author(s): Michael Koeppl
 */

using System.Text;

namespace ConsoleApplication
{
    public class Tree
    {
        public int ID { get; private set; }
        private int ageInYears;
        private string type;
        public Tree(int id, int ageInYears, string type)
        {
            this.ID = id;
            this.ageInYears = ageInYears;
            this.type = type;
        }
        
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n\tTree")
                .Append($"\tID: {ID}\n")
                .Append($"\t\tAge in Years: {ageInYears}\n")
                .Append($"\t\tType: {type}\n");
            return sb.ToString();
        }
    }
}