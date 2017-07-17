using System;
using System.Collections.Generic;
using Vouzamo.Common;
using Vouzamo.Common.Models;
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

        public IItem CreateItem(ItemType type, string name)
        {
            Item item = null;

            switch(type)
            {
                case ItemType.Component:
                    item = new ComponentItem(name);
                    break;
                case ItemType.Contract:
                    item = new ContractItem(name);
                    break;
            }

            if(item != null)
            {
                ManagerUnitOfWork.Repository<Item, Guid>().Add(item);
                ManagerUnitOfWork.Complete();
            }

            return item;
        }

        public IItem RenameItem(Guid id, string name)
        {
            var item = ManagerUnitOfWork.Repository<Item, Guid>().Get(id);

            item.Name = name;

            ManagerUnitOfWork.Complete();

            return item;
        }

        public T GetItem<T>(Guid id) where T : class, IItem
        {
            var item = ManagerUnitOfWork.Repository<T, Guid>().Get(id);

            if(item == null)
            {
                throw new KeyNotFoundException($"Could not find item of type {typeof(T).Name} with id {id}");
            }

            return item;
        }
    }
}
