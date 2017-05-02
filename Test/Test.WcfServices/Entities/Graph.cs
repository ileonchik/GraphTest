using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Test.Common.Enities;

namespace Test.WcfServices.Entities
{
    [DataContract]
    public class Graph
    {
        [DataMember]
        public List<DbNode> Nodes { get;set;}

        public List<DbAdjacency> Adjacencies { get; set; }

    }
}