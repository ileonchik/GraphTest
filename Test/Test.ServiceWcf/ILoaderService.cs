using System.ServiceModel;

namespace Test.WcfServices
{

    [ServiceContract(Namespace = "http://test.com/LoaderService")]

    public interface ILoaderService
    {

        [OperationContract]
        void SaveAdjacency(string startNodeId, string endNodeId);

        [OperationContract]
        void SaveNode(string id, string label);

        [OperationContract]
        void ClearDatabase();
    }



}
