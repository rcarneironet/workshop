using Contoso.Store.Application.Handlers.Login;
using Contoso.Store.Domain.Contexts.Queries.Security;
using Microsoft.AspNetCore.Mvc;

namespace Contoso.Store.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginQueryHandler _queryHandler;
        public LoginController(LoginQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpPost("token"), 
         ProducesResponseType(typeof(string), 201), 
         ProducesResponseType(400),
         ProducesResponseType(500)]
        public IActionResult Post([FromBody] LoginQuery query)
        {
            return StatusCode(201, _queryHandler.Handle(query));
        }
    }
}