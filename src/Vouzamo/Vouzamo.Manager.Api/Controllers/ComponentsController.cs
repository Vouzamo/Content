using System;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    
    public class ComponentsController : ResourceApiController<ComponentItem, Guid>
    {
        private readonly IManagerUnitOfWork ManagerUnitOfWork;

        protected override IUnitOfWork UnitOfWork => ManagerUnitOfWork;

        public ComponentsController(IManagerUnitOfWork managerUnitOfWork)
        {
            ManagerUnitOfWork = managerUnitOfWork;
        }
    }
}