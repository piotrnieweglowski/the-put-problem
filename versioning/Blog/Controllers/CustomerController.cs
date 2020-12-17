using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly IEnumerable<Customer> _customers = new List<Customer>()
        {
            new Customer { Id = 1, Version = 1, Name = "John", City = "Cracow", IsPremiumMember = false }
        };

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_customers.FirstOrDefault(x => x.Id == id));
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            var toUpdate = _customers.First(x => x.Id == customer.Id);
            if (toUpdate.Version != customer.Version) 
            {
                return BadRequest(
                    "The data you're trying to update has been changed. " +
                    "Please reload data and try once again.");
            }
            toUpdate.Name = customer.Name;
            toUpdate.City = customer.City;
            toUpdate.IsPremiumMember = customer.IsPremiumMember;
            toUpdate.Version++;
            return NoContent();
        }
    }
}
