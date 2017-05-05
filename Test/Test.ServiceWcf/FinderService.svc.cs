using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Test.Common.Enities;
using Test.Common.Interfaces;
using Test.Database;
using Test.PathFinder;
using Graph = Test.ServiceWcf.Entities.Graph;


namespace Test.ServiceWcf
{
    [ServiceBehavior(Namespace = "http://test.com/FinderService")]
    public class FinderService : IFinderService
    {
        public List<string> FindPath(string start, string stop)
        {;
            IFinder finder;
            using (var ctx = new TestDbContext("TestDBCompact"))
            {
                var nodes = ctx.Nodes.ToList();
                var adjacencies = ctx.Adjacencies.ToList();
                finder = FinderFactory.GetFinder(FinderType.Dijkstra, new Common.Enities.Graph(adjacencies,nodes));
            }
            return finder.Find(start, stop);
        }
    }
}
