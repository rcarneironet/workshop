using Contoso.Store.Application.Handlers.CustomerHandler;
using Contoso.Store.Domain.Contexts.Commands.Customer;
using Contoso.Store.Shared.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Store.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerHandler _handler;
        public CustomerController(CustomerHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("criar")]
        [ProducesResponseType(typeof(string), 200)] //OK
        [ProducesResponseType(400)] //bad request
        [ProducesResponseType(500)] //server error
        public ICommandResult Post([FromBody] CreateCustomerCommand command)
        {
            return _handler.Handle(command);
        }
    }
}