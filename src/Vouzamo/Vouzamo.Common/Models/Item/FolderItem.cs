using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class FolderItem : Item, IHasOwner<Guid>, IHasChildren<Guid>, IHasParent<Guid>
    {
        [RequiredGuid]
        public Guid OwnerId { get; set; }

        [RequiredGuid]
        public Guid ParentId { get; set; }

        public FolderItem() : base()
        {
            Type = ItemType.Folder;
        }

        public bool IsValidChild<T>(T child) where T : IHasParent<Guid>
        {
            return (ItemType.Folder | ItemType.Contract | ItemType.Component).HasFlag(child.Type);
        }
    }
}
