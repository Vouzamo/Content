using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{

    public class ContractsController : ManagerBaseController<ContractItem>
    {
        public ContractsController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService) : base(managerUnitOfWork, managerService)
        {

        }
    }
}