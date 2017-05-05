using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Test.ServiceWcf
{

    [ServiceContract(Namespace = "http://test.com/FinderService")]

    public interface IFinderService
    {

        [OperationContract]
        List<String> FindPath(string start, string stop);
    }



}
