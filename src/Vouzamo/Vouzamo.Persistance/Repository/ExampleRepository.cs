using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Common.Models;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Repository;

namespace Vouzamo.Persistence.Repository
{
    public class ExampleRepository : EntityFrameworkRepository<Example, Guid>, IExampleRepository
    {
        public ExampleRepository(DbSet<Example> dbSet) : base(dbSet)
        {

        }

        public IPagedResults<Example> GetActiveExamples(int page, int pageSize)
        {
            DbSet.Where(x => x.IsActive).ToList();

            return Find(x => x.IsActive, page, pageSize);
        }
    }
}
