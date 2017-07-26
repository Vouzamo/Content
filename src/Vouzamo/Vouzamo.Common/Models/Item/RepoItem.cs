using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class RepoItem : Item, IHasParent<Guid>, IHasChildren<Guid>, IHasOwnership<Guid>
    {
        public ItemType AllowedItemTypes => (ItemType.Repo | ItemType.RootFolder);
        public ItemType AllowedOwnerItemTypes => (ItemType.RootFolder | ItemType.Folder | ItemType.Contract | ItemType.Component);

        [RequiredGuid]
        public Guid ParentId { get; set; }

        public RepoItem() : base()
        {
            Type = ItemType.Repo;
        }
    }
}
