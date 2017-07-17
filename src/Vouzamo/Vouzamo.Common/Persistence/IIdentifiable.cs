using System;

namespace Vouzamo.Common.Persistence
{
    public interface IIdentifiable<TId> where TId : IComparable<TId>
    {
        TId Id { get; }
    }
}
