using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
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
            new Customer { Id = 1, Name = "John", City = "Cracow", IsPremiumMember = false }
        };

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_customers.FirstOrDefault(x => x.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, JsonPatchDocument<Customer> patchDoc)
        {
            var toUpdate = _customers.First(x => x.Id == id);
            patchDoc.ApplyTo(toUpdate);
            return NoContent();
        }
    }
}
