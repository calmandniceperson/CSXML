using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_LINQ {
    class Park {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Tree> TreeList { get; private set; }

        public Park() {
            TreeList = new List<Tree>();
        }

        override public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("=== Park ===\n")
                .Append($"Name: {Name}\n");
            foreach (var t in TreeList) {
                sb.Append(t.ToString());
            }
            return sb.ToString();
        }
    }
}
