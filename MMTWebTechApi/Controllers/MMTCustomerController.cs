using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTWebTechApi.Models;
using MMTWebTechApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTWebTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MMTCustomerController : ControllerBase
    {
        private IMMTCustomerService _service;
        public MMTCustomerController(IMMTCustomerService service)
        {
            _service = service;
        }
        // GET api/all customer 
        [HttpGet]
        public ActionResult<IEnumerable<MMTCustomer>> Get()
        {
            var items = _service.GetAllUser();
            return Ok(items);
        }

        
        [HttpPost("{user}/{customerId}")]
        [Route("user")]
        public ActionResult<MMTCustomer> Post([FromForm] string user, [FromForm] string customerId)
        {
            var item = _service.GetUserById(user, customerId);

            if (item == null)
            {
                return Ok(null);//NotFound();
            }

            return Ok(item);
        }

        [HttpGet("{customerId}")]
        [Route("lastorder")]
        public ActionResult<MMTOrder> GetOrder([FromForm] string customerId)
        {
            var item = _service.GetOrderByCustomerId(customerId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet("{orderNumber}")]
        [Route("allitems")]
        public ActionResult<IEnumerable<MMTOrderItem>> GetOrderItem([FromForm] int orderNumber)
        {
            var items = _service.GetAllOrderItemByorderNumber(orderNumber);
            if (items == null)
            {
                return NotFound();
            }
            return Ok(items);
        }

    }
}
