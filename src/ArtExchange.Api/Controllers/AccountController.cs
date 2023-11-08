using ArtExchange.Application.Feautures.Persons.Commands.Login;
using ArtExchange.Application.Feautures.Persons.Commands.Logout;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtExchange.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginCommand loginCommand)
        {
            await _mediator.Send(loginCommand);            
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await _mediator.Send(new LogoutCommand());
            return Ok();
        }


    }
}
