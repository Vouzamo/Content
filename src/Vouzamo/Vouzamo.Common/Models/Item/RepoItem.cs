using Vouzamo.Common.Types;
using Vouzamo.Common.Persistence;
using System;
using Vouzamo.Common.Attributes;

namespace Vouzamo.Common.Models.Item
{
    public class RepoItem : Item, IHasParent<Guid?>, IHasChildren
    {
        public ItemType AllowedItemTypes => (ItemType.Folder);

        public RepoItem() : base()
        {
            Type = ItemType.Repo;
        }
    }
}
