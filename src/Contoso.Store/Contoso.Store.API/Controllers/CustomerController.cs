using Contoso.Store.Application.Handlers.CustomerHandler;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerHandler _handler;
        public CustomerController(CustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CreateCustomerCommand command)
        {
            return StatusCode(201, _handler.Handle(command));
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(string), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put([FromBody] ChangeCustomerCommand command)
        {
            return StatusCode(204, _handler.Handle(command));
        }

        [HttpGet("getall")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            return StatusCode(200);
        }
    }
}