using System.Collections.Generic;
using Vouzamo.Common.Models;
using Vouzamo.Common.Models.Item;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Common.Services
{
    public interface IManagerService
    {
        Stack<IItem> ParentHierarchy(IItem subject);
        IPagedResults<Item> Children(IItem item, int page = 1, int pageSize = int.MaxValue);
        void Validate<T>(T item) where T : IItem;
    }
}
