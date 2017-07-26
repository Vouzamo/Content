using Microsoft.AspNetCore.Mvc;
using System;
using Vouzamo.Common.Models;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Api.Controllers
{
    public abstract class ManagerBaseController<T> : ResourceApiController<T, Guid> where T : class, IItem
    {
        protected readonly IManagerUnitOfWork ManagerUnitOfWork;
        protected readonly IManagerService ManagerService;

        protected override IUnitOfWork UnitOfWork => ManagerUnitOfWork;

        protected ManagerBaseController(IManagerUnitOfWork managerUnitOfWork, IManagerService managerService) : base()
        {
            ManagerUnitOfWork = managerUnitOfWork;
            ManagerService = managerService;
        }

        #region NonActions
        public override void BeforeWrite(T resource)
        {
            base.BeforeWrite(resource);

            ManagerService.Validate(resource);
        }
        #endregion
    }
}