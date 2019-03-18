using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Exceptions;
using WebAPI.Application.User.Authenticate;
using WebAPI.Application.User.Registration;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/authorize")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]AuthenticateQuery request)
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
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody]RegistrationQuery request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (EmailAddresIsAlreadyUsedException e)
            {
                return BadRequest(e.Message);
            }
            catch (RequestValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch(LoginIsAlreadyUsedException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}