using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Common;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Persistence
{
    public class EntityFrameworkRepository<T, TId> : IRepository<T, TId> where T : class, IIdentifiable<TId> where TId : IComparable<TId>
    {
        protected DbSet<T> DbSet { get; set; }

        public EntityFrameworkRepository(DbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public IPagedResults<T> Page(int page, int pageSize)
        {
            return Find(x => true, page, pageSize);
        }

        public IPagedResults<T> Find(Expression<Func<T, bool>> predicate, int page, int pageSize)
        {
            var take = pageSize;
            var skip = (page - 1) * pageSize;
            
            var allResults = DbSet.Where(predicate);

            var count = allResults.Count();

            var results = allResults.Skip(skip).Take(take).ToList();

            return new PagedResults<T>(results, page, pageSize, count);
        }

        public T Get(TId id)
        {
            return DbSet.SingleOrDefault(x => x.Id.Equals(id));
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
