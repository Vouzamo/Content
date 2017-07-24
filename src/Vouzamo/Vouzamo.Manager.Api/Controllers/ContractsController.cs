using System;
using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    
    public class ContractsController : ResourceApiController<ContractItem, Guid>
    {
        private readonly IManagerUnitOfWork ManagerUnitOfWork;

        protected override IUnitOfWork UnitOfWork => ManagerUnitOfWork;

        public ContractsController(IManagerUnitOfWork managerUnitOfWork)
        {
            ManagerUnitOfWork = managerUnitOfWork;
        }
    }
}