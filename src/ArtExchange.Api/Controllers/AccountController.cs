using ArtExchange.Application.Feautures.Persons.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtExchange.Api.Controllers
{
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
    }
}
