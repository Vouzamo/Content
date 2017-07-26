using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;

namespace Vouzamo.Common.Models.Item
{
    public class SpaceItem : Item, IHasChildren<Guid>
    {
        public ItemType AllowedItemTypes => (ItemType.Repo);

        public SpaceItem() : base()
        {
            Type = ItemType.Space;
        }
    }
}
