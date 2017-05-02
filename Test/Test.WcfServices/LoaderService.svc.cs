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

namespace Test.WcfServices
{
    [ServiceBehavior(Namespace = "http://test.com/LoaderService")]
    public class LoaderService : ILoaderService
    {
        public void SaveNode(string id, string label)
        {
            using (var ctx = new TestDbContext())
            {

                try
                {
                    ctx.Nodes.Add(new DbNode() {UniqueId = id, Label = label});

                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }
        }

        public void SaveAdjacency(string startNodeId, string endNodeId)
        {
            using (var ctx = new TestDbContext())
            {
                ctx.Adjacencies.Add(new DbAdjacency()
                {
                    StartId = ctx.Nodes.First(n => n.UniqueId == startNodeId).Id,
                    StopId = ctx.Nodes.First(n => n.UniqueId == endNodeId).Id
                });

                ctx.SaveChanges();
            }
        }

        public void ClearDatabase()
        {
            try
            {
                using (var ctx = new TestDbContext())
                {
                    ctx.Database.ExecuteSqlCommand("delete from Nodes");
                    ctx.Database.ExecuteSqlCommand("delete from Adjacencies");
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
