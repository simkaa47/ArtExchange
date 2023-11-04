using ArtExchange.Application.Feautures.Persons.Commands.Login;
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
            var token = await _mediator.Send(loginCommand);
            this.HttpContext.Response.Cookies.Append("jwt", token);
            return Ok();
        }
    }
}
