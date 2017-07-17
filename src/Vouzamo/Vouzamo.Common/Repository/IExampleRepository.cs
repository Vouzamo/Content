using System;
using Vouzamo.Common.Models;
using Vouzamo.Common.Persistence;

namespace Vouzamo.Common.Repository
{
    public interface IExampleRepository : IRepository<Example, Guid>
    {
        IPagedResults<Example> GetActiveExamples(int page = 1, int pageSize = int.MaxValue);
    }
}
