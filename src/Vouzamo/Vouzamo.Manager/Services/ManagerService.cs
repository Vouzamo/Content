using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Services
{
    public class ManagerService : IManagerService
    {
        protected readonly IManagerUnitOfWork ManagerUnitOfWork;

        public ManagerService(IManagerUnitOfWork managerUnitOfWork)
        {
            ManagerUnitOfWork = managerUnitOfWork;
        }
    }
}
