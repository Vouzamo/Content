using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Fields")]
    public class FieldsController : Controller
    {
        private readonly IManagerUnitOfWork ManagerUnitOfWork;
        private readonly IManagerService ManagerService;

        public FieldsController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService)
        {
            ManagerUnitOfWork = managerUnitOfWork;
            ManagerService = managerService;
        }

        
    }
}