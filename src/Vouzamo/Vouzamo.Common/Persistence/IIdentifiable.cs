using System;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Persistence
{
    public interface IIdentifiable<TId> where TId : IComparable<TId>
    {
        TId Id { get; }
    }

    public interface IHasDiscriminator<T>
    {
        T Type { get; }
    }

    public interface IHasParent<TId> : IHasDiscriminator<ItemType>
    {
        TId ParentId { get; }
    }

    public interface IHasChildren
    {
        ItemType AllowedItemTypes { get; }
    }
}
