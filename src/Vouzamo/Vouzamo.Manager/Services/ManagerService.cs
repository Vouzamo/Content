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

        public Stack<IItem> ParentHierarchy(IItem subject)
        {
            var repository = ManagerUnitOfWork.Repository<IItem, Guid>();
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

        public IPagedResults<Item> Children(IItem item, int page = 1, int pageSize = int.MaxValue)
        {
            var repository = ManagerUnitOfWork.Repository<Item, Guid>();

            List<IItem> items = new List<IItem>();

            return repository.Find(x => x.ParentId.HasValue && x.ParentId.Value == item.Id, page, pageSize);
        }

        public void Validate<T>(T item) where T : IItem
        {
            var repository = ManagerUnitOfWork.Repository<Item, Guid>();

            // Uniqueness Validation
            var nameClashes = repository.Find(x => x.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase) && x.ParentId.Value == item.ParentId.Value, 1, 1);
            if(nameClashes.Count > 0)
            {
                throw new ErrorException(ErrorType.General, $"{nameof(item.Name)} must be unique within containing item.");
            }

            // Parent Validation
            if (item is IHasParent<Guid?>)
            {
                var child = item as IHasParent<Guid?>;

                if(!child.ParentId.HasValue)
                {
                    throw new ErrorException(ErrorType.General, "Parent is not defined");
                }

                var result = ManagerUnitOfWork.Repository<Item, Guid>().Get(child.ParentId.Value);

                if (result is IHasChildren)
                {
                    var parent = result as IHasChildren;

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

            // Component Validation
            if(item is ComponentItem)
            {
                var componentItem = item as ComponentItem;

                var contractItem = ManagerUnitOfWork.Repository<ContractItem, Guid>().Get(componentItem.ContractId);
            }
        }
    }
}
