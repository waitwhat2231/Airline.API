using Airline.Application.User.Commands;
using Airline.Application.User.Commands.Login;
using Airline.Application.User.Commands.Token;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers
{
    [ApiController]
    [Route("/api")]
    public class AccountController(IMediator mediator):ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult>RegisterUser(RegisterUserCommand command)
        {
            var res = await mediator.Send(command);
            if (res.Any())
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserCommand request)
        {
            var result = await mediator.Send(request);
            if (result == null)
            {
                return NotFound("User not found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("RefreshToken")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequestCommand request)
        {
            var response = await mediator.Send(request);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
