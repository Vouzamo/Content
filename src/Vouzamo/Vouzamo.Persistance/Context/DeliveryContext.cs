using Microsoft.EntityFrameworkCore;

namespace Vouzamo.Persistence.Context
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {

        }
    }
}
