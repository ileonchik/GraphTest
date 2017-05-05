using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Test.Database;
using Test.ServiceWcf.Entities;
using Graph = Test.ServiceWcf.Entities.Graph;

namespace Test.ServiceWcf
{
    [ServiceBehavior(Namespace = "http://test.com/DisplayService")]
    public class DisplayService : IDisplayService
    {
        public Graph GetGraph()
        {
            try
            {
  var result = new Graph();
            using (var ctx = new TestDbContext("TestDBCompact"))
            {
                var nodes = ctx.Nodes.ToList();
                    var wcfAdjacencies = new List<WcfAdjacency>();
                foreach (var adj in ctx.Adjacencies.ToList())
                {
                    wcfAdjacencies.Add(new WcfAdjacency(adj,nodes));
                }
                result.Adjacencies = wcfAdjacencies;
                result.Nodes = nodes;
            }
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
