using Microsoft.AspNetCore.Mvc;
using System;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{

    public class ItemsController : ManagerBaseController<Item>
    {
        public ItemsController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService) : base(managerUnitOfWork, managerService)
        {

        }

        [HttpGet("{id}/owner-hierarchy")]
        public IActionResult OwnerHierarchy(Guid id)
        {
            var item = ManagerUnitOfWork.Repository<Item, Guid>().Get(id);

            var hierarchy = ManagerService.OwnerHierarchy(item);

            return new OkObjectResult(hierarchy);
        }

        [HttpGet("{id}/parent-hierarchy")]
        public IActionResult ParentHierarchy(Guid id)
        {
            var item = ManagerUnitOfWork.Repository<Item, Guid>().Get(id);

            var hierarchy = ManagerService.ParentHierarchy(item);

            return new OkObjectResult(hierarchy);
        }
    }
}