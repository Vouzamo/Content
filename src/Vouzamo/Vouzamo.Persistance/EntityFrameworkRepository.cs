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

        public IPagedResults<T> Page(int page, int pageSize)
        {
            return Find(x => true, page, pageSize);
        }

        public IPagedResults<T> Find(Expression<Func<T, bool>> predicate, int page, int pageSize)
        {
            var take = pageSize;
            var skip = (page - 1) * pageSize;
            
            var allResults = DbSet.OfType<T>().Where(predicate);

            var count = allResults.Count();

            var results = allResults.Skip(skip).Take(take).ToList();

            return new PagedResults<T>(results, page, pageSize, count);
        }

        public T Get(TId id)
        {
            return DbSet.OfType<T>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
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
