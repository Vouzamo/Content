using Microsoft.EntityFrameworkCore;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Types;

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
                .HasValue<SpaceItem>(ItemType.Space)
                .HasValue<RepoItem>(ItemType.Repo)
                .HasValue<RootFolderItem>(ItemType.RootFolder)
                .HasValue<FolderItem>(ItemType.Folder)
                .HasValue<ContractItem>(ItemType.Contract)
                .HasValue<ComponentItem>(ItemType.Component);

            modelBuilder.Entity<SpaceItem>().HasBaseType<Item>();
            modelBuilder.Entity<RepoItem>().HasBaseType<Item>();
            modelBuilder.Entity<RootFolderItem>().HasBaseType<Item>();
            modelBuilder.Entity<FolderItem>().HasBaseType<Item>();
            modelBuilder.Entity<ContractItem>().HasBaseType<Item>();
            modelBuilder.Entity<ComponentItem>().HasBaseType<Item>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
