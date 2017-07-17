using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Vouzamo.Common.Persistence
{

    public interface IRepository<T, TId> where T : class, IIdentifiable<TId> where TId : IComparable<TId>
    {
        T Get(TId id);

        IPagedResults<T> Page(int page = 1, int pageSize = int.MaxValue);
        IPagedResults<T> Find(Expression<Func<T, bool>> predicate, int page = 1, int pageSize = int.MaxValue);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
    }
}
