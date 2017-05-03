using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;
using Test.Common.Interfaces;

namespace Test.PathFinder
{
    public class DijkstraFinder : BaseFinder
    {
        public DijkstraFinder(Graph graph) : base(graph)
        {
        }

        protected override List<int> Find(int[,] adjaciesMatrix, int start, int stop, int size)
        {
            var way = new int[size];
            for (int i = 0; i < size; i++)
            {
                way[i] = int.MaxValue;
            }

            way[start] = 0;

            var visited = new bool[size];
            var previous = new int?[size];

            while (true)
            {
                var minDistance = int.MaxValue;
                var minNode = 0;
                for (int i = 0; i < size; i++)
                {
                    if (!visited[i] && minDistance > way[i])
                    {
                        minDistance = way[i];
                        minNode = i;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }

                visited[minNode] = true;

                for (int i = 0; i < size; i++)
                {
                    if (adjaciesMatrix[minNode, i] > 0)
                    {
                        var shortestToMinNode = way[minNode];
                        var distanceToNextNode = adjaciesMatrix[minNode, i];

                        var totalDistance = shortestToMinNode + distanceToNextNode;

                        if (totalDistance < way[i])
                        {
                            way[i] = totalDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (way[stop] == int.MaxValue)
            {
                return null;
            }

            var path = new LinkedList<int>();
            int? currentNode = stop;
            while (currentNode != null)
            {
                path.AddFirst(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            return path.ToList();
        }
    }


}


