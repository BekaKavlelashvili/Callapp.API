using Callapp.Application.Commands;
using Callapp.Application.Dtos;
using Callapp.Domain.Aggregates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Callapp.API.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediatR) => _mediator = mediatR;


        [HttpPost("authorization")]
        public async Task<IActionResult> Login([FromBody]LoginUserDto loginUser)
        {
            var userToReturn = await _mediator.Send(new AuthenticateUserCommand(loginUser));
            return Ok(userToReturn);
        }

        [Authorize]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserDto user)
        {
            var userToReturn = await _mediator.Send(new CreateUserCommand(user));

            return Ok(userToReturn);
        }
    }
}
