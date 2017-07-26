using System;
using Vouzamo.Common.Models;

namespace Vouzamo.Common.Persistence
{
    public interface IIdentifiable<TId> where TId : IComparable<TId>
    {
        TId Id { get; }
    }

    public interface IHasParent<TId> : IItem
    {
        TId ParentId { get; }
    }

    public interface IHasChildren<TId>
    {
        bool IsValidChild<T>(T child) where T : IHasParent<TId>;
    }

    public interface IHasOwner<TId> : IItem
    {
        TId OwnerId { get; }
    }

    public interface IHasOwnership<TId>
    {
        bool IsValidOwned<T>(T owned) where T : IHasOwner<TId>;
    }
}
