using System.ServiceModel;
using Test.WcfServices.Entities;

namespace Test.WcfServices
{
    [ServiceContract(Namespace = "http://test.com/DisplayService")]
    public interface IDisplayService
    {
        [OperationContract]
        Graph GetGraph();
    }
}
