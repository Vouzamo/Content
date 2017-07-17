using System;

namespace Vouzamo.Common.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T, TId> Repository<T, TId>() where T : class, IIdentifiable<TId> where TId : IComparable<TId>;
        int Complete();
    }
}
