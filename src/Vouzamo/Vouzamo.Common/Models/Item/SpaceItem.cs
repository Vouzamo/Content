using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;

namespace Vouzamo.Common.Models.Item
{
    public class SpaceItem : Item, IHasChildren<Guid>
    {
        public SpaceItem() : base()
        {
            Type = ItemType.Space;
        }

        public bool IsValidChild<T>(T child) where T : IHasParent<Guid>
        {
            return (ItemType.Repo).HasFlag(child.Type);
        }
    }
}
