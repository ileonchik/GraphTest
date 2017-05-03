using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;
using Test.Common.Interfaces;
using Test.Database;

namespace Test.Wpf
{
    internal class GraphRepository:IRepository<Graph>
    {
        public Graph Get()
        {
            Graph result;
            List<KeyValuePair<string,string>> adjacencies= new List<KeyValuePair<string, string>>();
            List<Node> nodes;
            using (var ctx = new TestDbContext())
            {
                result = new Graph(ctx.Adjacencies.ToList(),ctx.Nodes.ToList());
            }
            return result;
        }
    }
}
