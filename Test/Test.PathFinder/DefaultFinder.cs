using System;
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
           throw new NotImplementedException();
        }
    }
}
