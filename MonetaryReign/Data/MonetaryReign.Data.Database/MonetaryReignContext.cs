using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using MonetaryReign.Model.Entities;

namespace MonetaryReign.Data.Database
{
    public class MonetaryReignContext : DbContext
    {
        public MonetaryReignContext() : base("MonetaryReign")
        {

        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
