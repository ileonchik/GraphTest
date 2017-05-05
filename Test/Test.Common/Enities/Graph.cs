using System.Collections.Generic;
using System.Linq;

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

        public Graph(List<KeyValuePair<string,string>> adjacencies, List<DbNode> nodes) : this()
        {
            Adjacencies.AddRange(adjacencies);
            foreach (var node in nodes)
            {
                NodesList.Add(node.Label, new Node(node));
            }
        }

        public Graph(List<DbAdjacency> adjacencies,List<DbNode> nodes  ):this()
        {
            foreach (var adj in adjacencies)
            {
                var startNode = nodes.FirstOrDefault(n => n.Id == adj.StartId);
                var stopNode = nodes.FirstOrDefault(n => n.Id == adj.StopId);
                Adjacencies.Add(new KeyValuePair<string, string>(startNode.UniqueId, stopNode.UniqueId));
            }
            foreach (var node in nodes)
            {
                NodesList.Add(node.Label,new Node(node));
            }
        }
    }
}
