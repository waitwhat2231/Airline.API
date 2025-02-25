using Airline.Application.User.Commands.Login;
using Airline.Application.User.Commands.Register;
using Airline.Application.User.Commands.Register.AirlineManager;
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
        public async Task<ActionResult>RegisterUser([FromBody] RegisterUserCommand command)
        {
            var res = await mediator.Send(command);
            if (res.Any())
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpPost]
        [Route("register/managerregister")]
        [Authorize(Roles ="Administrator")]
        public async Task<ActionResult> RegisterAirlineManager([FromBody] RegisterAirlineManagerCommand request)
        {
            var Id = await mediator.Send(request);
            return Ok(Id);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginUserCommand request)
        {
            var result = await mediator.Send(request);
            if (result == null)
            {
                return NotFound("User not found");
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("refreshToken")]
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
