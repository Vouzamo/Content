using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    
    public class ComponentsController : ManagerBaseController<ComponentItem>
    {
        public ComponentsController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService) : base(managerUnitOfWork, managerService)
        {
            
        }
    }
}