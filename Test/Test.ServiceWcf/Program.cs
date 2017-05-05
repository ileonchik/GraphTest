using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HybridService.Wcf;
using Test.WcfServices;

namespace Test.ServiceWcf
{
    class Program
    {
        static void Main(string[] args)
        {
            new HybridServiceWcf(new Type[] { typeof(DisplayService) ,typeof(LoaderService)}).Run(args);
        }
    }
}
