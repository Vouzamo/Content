using System;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Persistence
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        protected DbContext DbContext { get; }

        public EntityFrameworkUnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IRepository<T, TId> Repository<T, TId>() where T : class, IIdentifiable<TId> where TId : IComparable<TId>
        {
            return new EntityFrameworkRepository<T, TId>(DbContext.Set<T>());
        }

        public int Complete()
        {
            return DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
