using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Test.WcfServices.Entities;

namespace Test.WcfServices
{
    [ServiceContract]
    public interface IDisplayService
    {
        [OperationContract]
        Graph GetGraph();
    }
}
