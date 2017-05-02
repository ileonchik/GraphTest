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
    }
}
