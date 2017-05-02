using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Test.Common.Enities;
using Test.Database;
using Test.DataLoader.ServiceReference1;
using Test.XmlReader;

namespace Test.DataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer= String.Empty;
            LoaderServiceClient loaderService = new LoaderServiceClient();
            while (answer!="Y"&& answer != "N"&& answer != "X")
            {
                Console.WriteLine("Do you want to clean db first? Please type Y/N or X for exit");
                answer = Console.ReadLine();
            }
            switch (answer)
            {
                case "Y":
                    loaderService.ClearDatabase();
                    break;
                case "N":
                    break;
                case "X":
                    return;
                default:
                    throw  new ArgumentException();

            }
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = Directory.GetFiles(path, "*.xml");
            NodesReader nodeasReader = new NodesReader();
            var graph = nodeasReader.Read(files);
            
            foreach (var node in graph.NodesList.Values)
            {
                loaderService.SaveNode(node.UniqueId,node.Label);
            }
            foreach (var adjacency in graph.Adjacencies)
            {
                loaderService.SaveAdjacency(adjacency.Key,adjacency.Value);
            }
        }
    }
}
