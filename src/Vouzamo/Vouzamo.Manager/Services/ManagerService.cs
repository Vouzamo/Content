using System;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Errors;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Models.Types;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Manager.Services
{
    public class ManagerService : IManagerService
    {
        protected readonly IManagerUnitOfWork ManagerUnitOfWork;

        public ManagerService(IManagerUnitOfWork managerUnitOfWork)
        {
            ManagerUnitOfWork = managerUnitOfWork;
        }

        public void Validate<T>(T item) where T : IItem
        {
            if (item is IHasParent<Guid>)
            {
                var child = item as IHasParent<Guid>;

                var result = ManagerUnitOfWork.Repository<Item, Guid>().Get(child.ParentId);

                if (result is IHasChildren<Guid>)
                {
                    var parent = result as IHasChildren<Guid>;

                    if (!parent.IsValidChild(child))
                    {
                        throw new ErrorException(ErrorType.General, "Invalid parent type");
                    }
                }
                else
                {
                    throw new ErrorException(ErrorType.General, "Invalid parent type");
                }
            }

            if(item is IHasOwner<Guid>)
            {
                var owned = item as IHasOwner<Guid>;

                var result = ManagerUnitOfWork.Repository<Item, Guid>().Get(owned.OwnerId);

                if(result is IHasOwnership<Guid>)
                {
                    var owner = result as IHasOwnership<Guid>;

                    if(!owner.IsValidOwned(owned))
                    {
                        throw new ErrorException(ErrorType.General, "Invalid owner type");
                    }
                }
                else
                {
                    throw new ErrorException(ErrorType.General, "Invalid owner type");
                }
            }
        }
    }
}
