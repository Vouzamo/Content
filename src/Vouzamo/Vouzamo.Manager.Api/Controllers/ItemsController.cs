using System;
using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    public class ItemsController : ResourceApiController<Item, Guid>
    {
        private readonly IManagerUnitOfWork ManagerUnitOfWork;

        protected override IUnitOfWork UnitOfWork => ManagerUnitOfWork;

        public ItemsController(IManagerUnitOfWork managerUnitOfWork)
        {
            ManagerUnitOfWork = managerUnitOfWork;
        }
    }
}