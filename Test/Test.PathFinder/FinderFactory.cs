using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;
using Test.Common.Interfaces;

namespace Test.PathFinder
{
    public class FinderFactory
    {
        public static IFinder GetFinder(FinderType finderType,Graph graph)
        {
            switch (finderType)
            {
                case FinderType.Default:
                    return new DefaultFinder(graph);
                case FinderType.Dijkstra:
                    return new DijkstraFinder(graph);
                default:
                    throw  new ArgumentException(String.Format("Finder type {0} is not supported",finderType));
            }
        }
    }
}
