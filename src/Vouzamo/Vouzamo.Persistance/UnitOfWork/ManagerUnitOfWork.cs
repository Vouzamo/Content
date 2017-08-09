using Vouzamo.Common.UnitOfWork;
using Vouzamo.Persistence.Context;

namespace Vouzamo.Persistence.UnitOfWork
{
    public class ManagerUnitOfWork : EntityFrameworkUnitOfWork, IManagerUnitOfWork
    {
        public ManagerUnitOfWork(ManagerContext context) : base(context)
        {
            
        }
    }
}
