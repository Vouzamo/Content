using System;
using Vouzamo.Common.Models;

namespace Vouzamo.Common.Services
{
    public interface IManagerService
    {
        IItem CreateItem(ItemType itemType, string name);
        IItem RenameItem(Guid id, string name);
        T GetItem<T>(Guid id) where T : class, IItem;
    }
}
