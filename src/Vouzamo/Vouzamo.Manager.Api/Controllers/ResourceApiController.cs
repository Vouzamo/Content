using System;
using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common.Persistence;

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
            try
            {
                var resources = UnitOfWork.Repository<T, TKey>().Page(page, pageSize);

                return new OkObjectResult(resources);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(TKey id)
        {
            try
            {
                var resource = UnitOfWork.Repository<T, TKey>().Get(id);

                return new OkObjectResult(resource);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] T resource)
        {
            try
            {
                UnitOfWork.Repository<T, TKey>().Add(resource);
                UnitOfWork.Complete();

                return new CreatedAtRouteResult(new { action = "Get", id = resource.Id }, resource);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(TKey id, [FromBody] T resource)
        {
            try
            {
                if(!id.Equals(resource.Id))
                {
                    throw new ArgumentException("id mismatch");
                }

                UnitOfWork.Repository<T, TKey>().Update(resource);
                UnitOfWork.Complete();

                return new OkObjectResult(resource);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TKey id)
        {
            try
            {
                var resource = UnitOfWork.Repository<T, TKey>().Get(id);

                UnitOfWork.Repository<T, TKey>().Remove(resource);
                UnitOfWork.Complete();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }
    }
}