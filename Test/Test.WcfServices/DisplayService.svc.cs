using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Test.Common.Enities;
using Test.Database;
using Test.WcfServices.Entities;
using Graph = Test.WcfServices.Entities.Graph;

namespace Test.WcfServices
{
    [ServiceBehavior(Namespace = "http://test.com/DisplayService")]
    public class DisplayService : IDisplayService
    {
        public Graph GetGraph()
        {
            throw new NotImplementedException();
        }
    }
}
