using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class RepoItem : Item, IHasParent<Guid>, IHasChildren<Guid>, IHasOwnership<Guid>
    {
        [RequiredGuid]
        public Guid ParentId { get; set; }

        public RepoItem() : base()
        {
            Type = ItemType.Repo;
        }

        public bool IsValidChild<T>(T child) where T : IHasParent<Guid>
        {
            return (ItemType.Repo | ItemType.RootFolder).HasFlag(child.Type);
        }

        public bool IsValidOwned<T>(T owned) where T : IHasOwner<Guid>
        {
            return (ItemType.RootFolder | ItemType.Folder | ItemType.Contract | ItemType.Component).HasFlag(owned.Type);
        }
    }
}
