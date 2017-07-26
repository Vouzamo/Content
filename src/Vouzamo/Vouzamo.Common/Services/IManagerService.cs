using Vouzamo.Common.Models;

namespace Vouzamo.Common.Services
{
    public interface IManagerService
    {
        void Validate<T>(T item) where T : IItem;
    }
}
