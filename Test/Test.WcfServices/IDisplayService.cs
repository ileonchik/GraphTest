using System.ServiceModel;
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
