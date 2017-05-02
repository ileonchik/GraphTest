using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Test.Common.Enities;

namespace Test.XmlReader
{
    public class NodesReader
    {
        public Graph Read(string[] fileNames)
        {
            var nodes = new List<Node>();
            foreach (var fileName in fileNames)
            {
                nodes.AddRange(Read(fileName));
            }
            return Read(nodes);
        }

        public List<Node> Read(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            var nodes = new List<Node>();
            XmlNodeList xmlNodes = doc.DocumentElement.SelectNodes("/node");

            foreach (XmlNode xmlNode in xmlNodes)
            {
                var adjacentIds = new List<string>();
                foreach (var adjacent in xmlNode["adjacentNodes"].ChildNodes)
                {
                    adjacentIds.Add(((XmlNode)adjacent).InnerText);
                }

                var node = new Node()
                {
                    UniqueId = xmlNode["id"].InnerText,
                    Label = xmlNode["label"].InnerText,
                    AdjacenciesUniqueIds = adjacentIds

                };
                nodes.Add(node);
            }
            return nodes;
        }
        private Graph Read(List<Node> nodes )
        {
            Graph graph = new Graph();

            foreach (var node in nodes)
            {

                foreach (var adjacency in node.AdjacenciesUniqueIds)
                {
                    if (!graph.Adjacencies.
                        Any(a => ((a.Key == node.UniqueId && a.Value == adjacency)
                                  || (a.Value == node.UniqueId && a.Key == adjacency))))
                    {
                        graph.Adjacencies.Add(new KeyValuePair<string, string>(node.UniqueId, adjacency));
                    }
                }


                if (!graph.NodesList.ContainsKey(node.UniqueId))
                {
                    graph.NodesList.Add(node.UniqueId, node);
                }
            }
            return graph;
        }
    }
}
