using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Common.Enities;

namespace Test.Database
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base()
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TestDbContext>());
        }

        public DbSet<DbNode> Nodes { get; set; }
        public DbSet<DbAdjacency> Adjacencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbAdjacency>().ToTable("Adjacencies");
            modelBuilder.Entity<DbNode>().ToTable("Nodes");
            modelBuilder.Entity<DbAdjacency>()
                .HasRequired<DbNode>(a => a.Start).WithMany().HasForeignKey(a => a.StartId).WillCascadeOnDelete(false);
            modelBuilder.Entity<DbAdjacency>()
                .HasRequired<DbNode>(a => a.Stop).WithMany().HasForeignKey(a => a.StopId).WillCascadeOnDelete(false);

        }
    }
}
