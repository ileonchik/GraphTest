using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;
using Test.Common.Interfaces;

namespace Test.PathFinder
{
    public abstract class BaseFinder:IFinder
    {
        public Graph Graph { get; private set; }

        protected BaseFinder(Graph graph)
        {
            Graph = graph;
        }

        public List<string> Find(string start, string stop)
        {
            var nodesDictionary = new Dictionary<int, Node>();
            var labelsDictionary = new Dictionary<string, int>();
            int index = 0;
            foreach (var node in Graph.NodesList.Values)
            {
                nodesDictionary.Add(index, node);
                labelsDictionary.Add(node.UniqueId, index);
                index++;
            }
            int[,] adjanciesMatrix = new int[index, index];
            foreach (var adj in Graph.Adjacencies)
            {
                adjanciesMatrix[labelsDictionary[adj.Key], labelsDictionary[adj.Value]] = 1;
                adjanciesMatrix[labelsDictionary[adj.Value], labelsDictionary[adj.Key]] = 1;
            }
            var result = Find(adjanciesMatrix, labelsDictionary[start], labelsDictionary[stop], index);

            return result.Select(node => nodesDictionary[node].UniqueId).ToList();
        }

        protected abstract List<int>  Find(int[,] adjaciesMatrix, int start, int stop, int size);
    }
}
