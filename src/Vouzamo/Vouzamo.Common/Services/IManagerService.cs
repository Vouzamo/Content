using System.Collections.Generic;
using Vouzamo.Common.Models;

namespace Vouzamo.Common.Services
{
    public interface IManagerService
    {
        Stack<IItem> OwnerHierarchy(IItem subject);
        Stack<IItem> ParentHierarchy(IItem subject);

        void Validate<T>(T item) where T : IItem;
    }
}
