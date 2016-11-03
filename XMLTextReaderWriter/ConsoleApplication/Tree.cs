using System.Text;

namespace ConsoleApplication
{
    public class Tree
    {
        public int ID { get; private set; }
        public int AgeInYears;
        public string Type;
        public Tree(int id, int ageInYears, string type)
        {
            this.ID = id;
            this.AgeInYears = ageInYears;
            this.Type = type;
        }
        
        override public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n\tTree")
                .Append("\tID: " + this.ID + "\n")
                .Append("\t\tAge in Years: "+ this.AgeInYears+"\n")
                .Append("\t\tType: " + this.Type + "\n");
            return sb.ToString();
        }
    }
}