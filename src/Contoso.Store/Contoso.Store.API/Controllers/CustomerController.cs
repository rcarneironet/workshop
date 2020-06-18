using Contoso.Store.Application.Handlers.CustomerHandlers;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Domain.Contexts.Queries.CustomerQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Store.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerCommandHandler _commandHandler;
        private readonly CustomerQueryHandler _queryHandler;
        public CustomerController(
            CustomerCommandHandler commandHandler,
            CustomerQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost(template: "create"),
         ProducesResponseType(type: typeof(string), statusCode: 201),
         ProducesResponseType(statusCode: 400),
         ProducesResponseType(statusCode: 401),
         ProducesResponseType(statusCode: 500)]
        public IActionResult Post([FromBody] CreateCustomerCommand command)
        {
            return StatusCode(statusCode: 201, value: _commandHandler.Handle(command: command));
        }

        [HttpPut("update"), ProducesResponseType(typeof(string), 204),
         ProducesResponseType(400),
         ProducesResponseType(401),
         ProducesResponseType(500)]
        public IActionResult Put([FromBody] ChangeCustomerCommand command)
        {
            return StatusCode(204, _commandHandler.Handle(command));
        }

        [HttpPost("getByDocument"),
         ProducesResponseType(typeof(string), 200),
         ProducesResponseType(400),
         ProducesResponseType(401),
         ProducesResponseType(500)]
        public IActionResult Get(CustomerDocumentQuery query)
        {
            return StatusCode(200, _queryHandler.Handle(query));
        }

        [HttpGet("getAllCustomers"),
         ProducesResponseType(typeof(string), 200),
         ProducesResponseType(400),
         ProducesResponseType(401),
         ProducesResponseType(500)]
        public IActionResult Get()
        {
            return StatusCode(200, _queryHandler.Handle());
        }
    }
}