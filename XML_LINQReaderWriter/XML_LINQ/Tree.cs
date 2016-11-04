using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_LINQ {
    class Tree {
        public int ID { get; private set; }
        public int AgeInYears;
        public string Type;

        public Tree(int id, int ageInYears, string type) {
            this.ID = id;
            this.AgeInYears = ageInYears;
            this.Type = type;
        }

        override public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n\tTree")
                .Append($"\tID: {ID}\n")
                .Append($"\t\tAge in Years: {AgeInYears}\n")
                .Append($"\t\tType: {Type}\n");
            return sb.ToString();
        }
    }
}
