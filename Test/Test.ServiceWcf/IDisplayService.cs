using System.ServiceModel;
using Test.ServiceWcf.Entities;

namespace Test.ServiceWcf
{
    [ServiceContract(Namespace = "http://test.com/DisplayService")]
    public interface IDisplayService
    {
        [OperationContract]
        Graph GetGraph();
    }
}
