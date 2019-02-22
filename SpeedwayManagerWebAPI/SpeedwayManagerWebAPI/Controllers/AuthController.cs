using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpeedwayManagerWebAPI.Application.Exceptions;
using SpeedwayManagerWebAPI.Application.User.Authenticate;
using SpeedwayManagerWebAPI.Application.User.Registration;
using System.Threading.Tasks;

namespace SpeedwayManagerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login([FromBody]AuthenticateRequest request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch(UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("api/auth/register")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}