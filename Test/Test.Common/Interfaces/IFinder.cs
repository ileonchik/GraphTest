using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Interfaces
{
    public interface IFinder
    {
        List<string> Find(string start, string stop);
    }
}
