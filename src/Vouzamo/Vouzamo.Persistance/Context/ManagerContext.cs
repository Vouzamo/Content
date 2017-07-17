using Microsoft.EntityFrameworkCore;
using Vouzamo.Common;
using Vouzamo.Common.Models;

namespace Vouzamo.Persistence.Context
{
    public class ManagerContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasDiscriminator(x => x.Type)
                .HasValue<ContractItem>(ItemType.Contract)
                .HasValue<ComponentItem>(ItemType.Component);

            modelBuilder.Entity<ContractItem>().HasBaseType<Item>();

            modelBuilder.Entity<ComponentItem>().HasBaseType<Item>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
