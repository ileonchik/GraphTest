using System.Collections.Generic;
using Test.Common.Enities;

namespace Test.PathFinder
{
    public class DefaultFinder:BaseFinder
    {
        public DefaultFinder(Graph graph) : base(graph)
        {
        }

        protected  override List<int> Find(int[,] adjaciesMatrix, int start, int stop,int size)
        {
            var result = new List<int>();
            Queue<int> nodesNotVisited = new Queue<int>();
            Queue<int> nodesVisited = new Queue<int>();
            var edges = new int[adjaciesMatrix.Length, adjaciesMatrix.Length];
            nodesNotVisited.Enqueue(start);
            var presvious = new Dictionary<int,int>();
            int index = -1;
            while (nodesNotVisited.Count != 0)
            {
                var prev = index;
                index = nodesNotVisited.Dequeue();
                if (prev >= 0)
                {
                    presvious.Add(index, prev);
                }
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
                
            }
            result.Add(stop);
            var next = presvious[stop];
            while (next!=start)
            {
                result.Add(next);
                next = presvious[next];
            }
            result.Add(start);
            return result;
        }
    }
}
