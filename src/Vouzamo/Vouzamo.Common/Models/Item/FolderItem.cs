using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class FolderItem : Item, IHasParent<Guid?>, IHasChildren
    {
        public ItemType AllowedItemTypes => (ItemType.Folder | ItemType.Contract | ItemType.Component);

        public FolderItem() : base()
        {
            Type = ItemType.Folder;
        }
    }
}
