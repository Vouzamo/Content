using System;
using System.Collections.Generic;
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

        public Stack<IItem> OwnerHierarchy(IItem subject)
        {
            var repository = ManagerUnitOfWork.Repository<Item, Guid>();

            if(subject is IHasOwner<Guid>)
            {
                var owned = subject as IHasOwner<Guid>;

                subject = repository.Get(owned.OwnerId);

                return ParentHierarchy(subject);
            }

            return new Stack<IItem>();
        }

        public Stack<IItem> ParentHierarchy(IItem subject)
        {
            var repository = ManagerUnitOfWork.Repository<Item, Guid>();
            var hierarchy = new Stack<IItem>();

            hierarchy.Push(subject);

            while(subject is IHasParent<Guid>)
            {
                var child = subject as IHasParent<Guid>;

                subject = repository.Get(child.ParentId);

                hierarchy.Push(subject);
            }

            return hierarchy;
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

                    if (!parent.AllowedItemTypes.HasFlag(child.Type))
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

                    if(!owner.AllowedOwnerItemTypes.HasFlag(owned.Type))
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
