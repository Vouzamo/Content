using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common;
using Vouzamo.Common.Services;
using Vouzamo.Common.Types;
using Vouzamo.Common.UnitOfWork;
using Vouzamo.Manager.Api.Helpers;

namespace Vouzamo.Manager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/types")]
    public class TypesController : Controller
    {
        private readonly IManagerUnitOfWork ManagerUnitOfWork;
        private readonly IManagerService ManagerService;

        public TypesController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService)
        {
            ManagerUnitOfWork = managerUnitOfWork;
            ManagerService = managerService;
        }

        [HttpGet("field")]
        public IActionResult GetFieldTypes()
        {
            var fieldTypes = EnumHelper.ToDictionary<FieldType>();

            return new OkObjectResult(fieldTypes);
        }

        [HttpGet("item")]
        public IActionResult GetItemTypes()
        {
            var itemTypes = EnumHelper.ToDictionary<ItemType>();

            return new OkObjectResult(itemTypes);
        }
    }
}