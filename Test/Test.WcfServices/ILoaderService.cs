using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Test.WcfServices.Entities;

namespace Test.WcfServices
{
   

    [ServiceContract]
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
