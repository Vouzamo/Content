using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{

    public class ItemsController : ItemsApiController<Item>
    {
        public ItemsController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService) : base(managerUnitOfWork, managerService)
        {

        }
    }
}