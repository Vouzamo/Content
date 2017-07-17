using System.Collections.Generic;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Common
{
    public class PagedResults<T> : IPagedResults<T>
    {
        public IEnumerable<T> Results { get; protected set; }
        public int Page { get; protected set; }
        public int PageSize { get; protected set; }
        public int Count { get; protected set; }

        public PagedResults(IEnumerable<T> results, int page, int pageSize, int count)
        {
            Results = results;
            Page = page;
            PageSize = pageSize;
            Count = count;
        }
    }
}
