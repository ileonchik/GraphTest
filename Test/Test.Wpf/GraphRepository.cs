using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Test.Common.Enities;
using Test.Common.Interfaces;
using Test.XmlReader;

namespace Test.Wpf
{
    internal class GraphRepository:IRepository<Graph>
    {
        public Graph Get()
        {
            Graph result;
            List<KeyValuePair<string,string>> adjacencies= new List<KeyValuePair<string, string>>();
            List<Node> nodes;
            /*   using (var ctx = new TestDbContext())
               {
                   result = new Graph(ctx.Adjacencies.ToList(),ctx.Nodes.ToList());
               }
            return result;*/
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(path, "*.xml");
            NodesReader nodeasReader = new NodesReader();
            return  nodeasReader.Read(files);

        
            
        }
    }
}
