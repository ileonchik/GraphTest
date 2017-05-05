using System;
using System.Linq;
using System.ServiceModel;
using Test.Common.Enities;
using Test.Database;


namespace Test.ServiceWcf
{
    [ServiceBehavior(Namespace = "http://test.com/LoaderService")]
    public class LoaderService : ILoaderService
    {
        public void SaveNode(string id, string label)
        {
            using (var ctx = new TestDbContext("TestDBCompact"))
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
            using (var ctx = new TestDbContext("TestDBCompact"))
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
                using (var ctx = new TestDbContext("TestDBCompact"))
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
