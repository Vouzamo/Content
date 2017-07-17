using Vouzamo.Common.Persistence;
using Vouzamo.Common.Repository;

namespace Vouzamo.Common.UnitOfWork
{
    public interface IDeliveryUnitOfWork : IUnitOfWork
    {
        IExampleRepository ExampleRepository { get; }
    }
}
