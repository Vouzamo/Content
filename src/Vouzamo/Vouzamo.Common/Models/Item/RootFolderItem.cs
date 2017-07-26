using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class RootFolderItem : Item, IHasOwner<Guid>, IHasChildren<Guid>
    {
        [RequiredGuid]
        public Guid OwnerId { get; set; }

        public RootFolderItem() : base()
        {
            Type = ItemType.RootFolder;
        }

        public bool IsValidChild<T>(T child) where T : IHasParent<Guid>
        {
            return (ItemType.Folder | ItemType.Contract | ItemType.Component).HasFlag(child.Type);
        }
    }
}
