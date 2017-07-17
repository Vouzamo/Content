using System.Collections.Generic;

namespace Vouzamo.Common.Persistence
{
    public interface IPagedResults<T>
    {
        IEnumerable<T> Results { get; }
        int Page { get; }
        int PageSize { get; }
        int Count { get; }
    }
}
