using Vouzamo.Common.UnitOfWork;
using Vouzamo.Persistence.Context;

namespace Vouzamo.Persistence.UnitOfWork
{
    public class DeliveryUnitOfWork : EntityFrameworkUnitOfWork, IDeliveryUnitOfWork
    {
        public DeliveryUnitOfWork(DeliveryContext context) : base(context)
        {
            
        }
    }
}
