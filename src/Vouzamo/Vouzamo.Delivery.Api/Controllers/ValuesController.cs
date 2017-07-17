using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vouzamo.Common;
using Vouzamo.Common.Models;
using Vouzamo.Common.Services;
using Vouzamo.Common.UnitOfWork;

namespace Vouzamo.Delivery.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDeliveryUnitOfWork DeliveryUnitOfWork;
        private readonly IManagerUnitOfWork ManagerUnitOfWork;
        private readonly IManagerService ManagerService;

        public ValuesController(IDeliveryUnitOfWork deliveryUnitOfWork, IManagerUnitOfWork managerUnitOfWork, IManagerService managerService)
        {
            DeliveryUnitOfWork = deliveryUnitOfWork;
            ManagerUnitOfWork = managerUnitOfWork;
            ManagerService = managerService;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            var example = new Example
            {
                Id = Guid.NewGuid(),
                IsActive = true
            };

            DeliveryUnitOfWork.Repository<Example, Guid>().Add(example);
            DeliveryUnitOfWork.Complete();

            return new OkObjectResult(example);
        }

        [HttpGet("test2")]
        public IActionResult Test2()
        {
            var examples = DeliveryUnitOfWork.ExampleRepository.GetActiveExamples();

            foreach(var example in examples.Results)
            {
                example.IsActive = false;
            }

            DeliveryUnitOfWork.Complete();

            return new OkObjectResult(examples);
        }

        [HttpGet("test3")]
        public IActionResult Test3()
        {
            var examples = DeliveryUnitOfWork.Repository<Example, Guid>().Find(x => !x.IsActive);

            return new OkObjectResult(examples);
        }

        [HttpGet("test4/{type}/{name}")]
        public IActionResult Test4(ItemType type, string name)
        {
            var item = ManagerService.CreateItem(type, name);

            return new OkObjectResult(item);
        }

        [HttpGet("test5/{id}/{name}")]
        public IActionResult Test5(Guid id, string name)
        {
            var item = ManagerService.RenameItem(id, name);

            return new OkObjectResult(item);
        }

        [HttpGet("test6/{id}")]
        public IActionResult Test6(Guid id)
        {
            try
            {
                var item = ManagerService.GetItem<ContractItem>(id);

                return new OkObjectResult(item);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        [HttpGet("test7/{id}")]
        public IActionResult Test7(Guid id)
        {
            try
            {
                var item = ManagerService.GetItem<ContractItem>(id);

                item.Fields.Add("title", new TextField(false));
                item.Fields.Add("author", new TextField(true));

                ManagerUnitOfWork.Complete();

                return new OkObjectResult(item);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
