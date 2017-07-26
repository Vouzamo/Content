using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class FolderItem : Item, IHasOwner<Guid>, IHasChildren<Guid>, IHasParent<Guid>
    {
        public ItemType AllowedItemTypes => (ItemType.Folder | ItemType.Contract | ItemType.Component);

        [RequiredGuid]
        public Guid OwnerId { get; set; }

        [RequiredGuid]
        public Guid ParentId { get; set; }

        public FolderItem() : base()
        {
            Type = ItemType.Folder;
        }
    }
}
