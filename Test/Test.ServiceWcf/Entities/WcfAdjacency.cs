using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;

namespace Test.ServiceWcf.Entities
{
    public class WcfAdjacency
    {
        [DataMember]
        public string Start { get;  set; }

        [DataMember]
        public string Stop { get;  set; }

        public WcfAdjacency()
        {
        }

        public WcfAdjacency(DbAdjacency dbAdjacency,List<DbNode> nodes )
        {
            var startNode = nodes.FirstOrDefault(n => n.Id == dbAdjacency.StartId);
            var stopNode = nodes.FirstOrDefault(n => n.Id == dbAdjacency.StopId);
            Start = startNode.UniqueId;
            Stop = stopNode.UniqueId;
        }
    }
}
