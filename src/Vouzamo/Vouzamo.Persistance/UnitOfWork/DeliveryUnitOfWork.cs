using Microsoft.EntityFrameworkCore;
using Vouzamo.Common.Models;
using Vouzamo.Common.Repository;
using Vouzamo.Common.UnitOfWork;
using Vouzamo.Persistence.Context;
using Vouzamo.Persistence.Repository;

namespace Vouzamo.Persistence.UnitOfWork
{
    public class DeliveryUnitOfWork : EntityFrameworkUnitOfWork, IDeliveryUnitOfWork
    {
        public IExampleRepository ExampleRepository => new ExampleRepository(DbContext.Set<Example>());

        public DeliveryUnitOfWork(DeliveryContext context) : base(context)
        {
            
        }
    }
}
