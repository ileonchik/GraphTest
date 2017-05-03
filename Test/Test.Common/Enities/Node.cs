using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Enities
{
    public class Node:DbNode
    {
        public Node()
        {
        }

        public Node(DbNode dbNode)
        {
            this.Id = dbNode.Id;
            this.Label = dbNode.Label;
            this.UniqueId = dbNode.UniqueId;
        }

        public List<int> AdjacenciesIds { get; set; }

        public List<string> AdjacenciesUniqueIds { get; set; }
    }
}
