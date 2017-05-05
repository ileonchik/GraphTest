using System;
using System.Collections.Generic;
using System.Linq;
using Test.Common.Enities;
using Test.Common.Interfaces;

namespace Test.Wpf
{
    internal class GraphRepository:IRepository<Graph>
    {
        public Graph Get()
        {
           
            List<Node> nodes;
            try
            {
  var service = new ServiceReference.DisplayServiceClient();
           var wcfGraph =  service.GetGraph();
                var adjacencies = new List<KeyValuePair<string,string>>();
                foreach (var adj in wcfGraph.Adjacencies)
                {
                    adjacencies.Add(new KeyValuePair<string, string>(adj.Start, adj.Stop));
                }
 Graph result= new Graph(adjacencies,wcfGraph.Nodes.ToList());
            return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
