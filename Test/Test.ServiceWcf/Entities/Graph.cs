using System.Collections.Generic;
using System.Runtime.Serialization;
using Test.Common.Enities;

namespace Test.ServiceWcf.Entities
{
    [DataContract]
    public class Graph
    {
        [DataMember]
        public List<DbNode> Nodes { get;set;}
        [DataMember]
        public List<WcfAdjacency> Adjacencies { get; set; }

    }
}