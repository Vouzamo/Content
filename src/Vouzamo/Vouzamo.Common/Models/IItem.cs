using System;
using System.Collections.Generic;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Types;

namespace Vouzamo.Common.Models
{
    public interface IItem : IIdentifiable<Guid>, IHasDiscriminator<ItemType>
    {
        Guid? ParentId { get; }
        string Name { get; }
    }

    public interface IHasFields
    {
        Dictionary<string, IField> Fields { get; }
    }
}
