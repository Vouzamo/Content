using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;

namespace Vouzamo.Common.Models.Item
{
    public class SpaceItem : Item, IHasChildren
    {
        public ItemType AllowedItemTypes => (ItemType.Repo);

        public new Guid? ParentId => null;

        public SpaceItem() : base()
        {
            Type = ItemType.Space;
        }
    }
}
