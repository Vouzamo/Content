using Microsoft.EntityFrameworkCore;
using Vouzamo.Common.Models;

namespace Vouzamo.Persistence.Context
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }

        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {

        }
    }
}
