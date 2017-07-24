using System;
using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Persistence;
using Vouzamo.Common.Models.Errors;
using Vouzamo.Common.Models.Types;

namespace Vouzamo.Manager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class ResourceApiController<T, TKey> : Controller where T : class, IIdentifiable<TKey> where TKey : IComparable<TKey>
    {
        protected abstract IUnitOfWork UnitOfWork { get; }

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = int.MaxValue)
        {
            var resources = UnitOfWork.Repository<T, TKey>().Page(page, pageSize);

            return new OkObjectResult(resources);
        }

        [HttpGet("{id}")]
        public IActionResult Get(TKey id)
        {
            var resource = UnitOfWork.Repository<T, TKey>().Get(id);

            return new OkObjectResult(resource);
        }

        [HttpPost]
        public IActionResult Post([FromBody] T resource)
        {
            Validate(resource);

            UnitOfWork.Repository<T, TKey>().Add(resource);
            UnitOfWork.Complete();

            return new CreatedAtRouteResult(new { action = "Get", id = resource.Id }, resource);
        }

        [HttpPut("{id}")]
        public IActionResult Put(TKey id, [FromBody] T resource)
        {
            Validate(resource);

            if (!id.Equals(resource.Id))
            {
                throw new ArgumentException("id mismatch");
            }

            UnitOfWork.Repository<T, TKey>().Update(resource);
            UnitOfWork.Complete();

            return new OkObjectResult(resource);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TKey id)
        {
            var resource = UnitOfWork.Repository<T, TKey>().Get(id);

            UnitOfWork.Repository<T, TKey>().Remove(resource);
            UnitOfWork.Complete();

            return new NoContentResult();
        }

        #region NonActions
        public virtual void Validate(T resource)
        {
            // generic validation
            if(resource == null)
            {
                throw new ErrorException(ErrorType.General, "Erm... What do you expect me to do with that?");
            }
        }
        #endregion
    }
}