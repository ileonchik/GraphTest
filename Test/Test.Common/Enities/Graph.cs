using System.Collections.Generic;

namespace Test.Common.Enities
{
    public class Graph
    {
        public List<KeyValuePair<string, string>> Adjacencies { get; private set; }

       public  Dictionary<string, Node> NodesList { get; private set; }

        public Graph()
        {
            NodesList = new Dictionary<string, Node>();
            Adjacencies = new List<KeyValuePair<string, string>>();
        }

        public Graph(List<DbAdjacency> adjacencies,List<DbNode> nodes  ):this()
        {
            foreach (var adj in adjacencies)
            {
                Adjacencies.Add(new KeyValuePair<string, string>(adj.Start.UniqueId, adj.Stop.UniqueId));
            }
            foreach (var node in nodes)
            {
                NodesList.Add(node.Label,new Node(node));
            }
        }
    }
}
