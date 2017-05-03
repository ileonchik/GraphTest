using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;

namespace Test.PathFinder
{
    public class DefaultFinder
    {
        private Graph graph;

        public DefaultFinder(Graph graph)
        {
            this.graph = graph;
        }

        public List<string> Search(string start, string stop)
        {
            var nodesDictionary = new Dictionary<int, Node>();
            var labelsDictionary = new Dictionary<string, int>();
            int index = 0;
            foreach (var node in graph.NodesList.Values)
            {
                nodesDictionary.Add(index, node);
                labelsDictionary.Add(node.UniqueId, index);
                index++;
            }
            int[,] adjanciesMatrix = new int[index, index];
            foreach (var adj  in  graph.Adjacencies)
            {
                adjanciesMatrix[labelsDictionary[adj.Key], labelsDictionary[adj.Value]] = 1;
                adjanciesMatrix[labelsDictionary[adj.Value], labelsDictionary[adj.Key]] = 1;
            }
            var result = Search(adjanciesMatrix, labelsDictionary[start], labelsDictionary[stop],index);

            return  result.Select(node => nodesDictionary[node].UniqueId).ToList();
        }

        private  List<int> Search(int[,] adjaciesMatrix, int start, int stop,int size)
        {
            var result = new List<int>();
            Queue<int> nodesNotVisited = new Queue<int>();
            Queue<int> nodesVisited = new Queue<int>();
            var edges = new int[adjaciesMatrix.Length, adjaciesMatrix.Length];
            nodesNotVisited.Enqueue(start);

            while (nodesNotVisited.Count != 0)
            {
                int index = nodesNotVisited.Dequeue();
                if (index == stop)
                {
                    break;
                }
                for (short j = 0; j < size; j++)
                {
                    if (adjaciesMatrix[index, j] != 0)
                    {
                        if (!nodesVisited.Contains(j) && !nodesNotVisited.Contains(j))
                        {
                            nodesNotVisited.Enqueue(j);
                            edges[index, j] = 1;


                        }
                    }
                    else edges[index, j] = 0;

                }
                result.Add(index);
            }
            return result;
        }
    }
}
