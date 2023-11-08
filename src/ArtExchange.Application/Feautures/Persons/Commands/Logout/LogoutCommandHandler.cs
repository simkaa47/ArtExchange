using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtExchange.Application.Feautures.Persons.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutCommandHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null)
            {
                throw new Exception("Internal server error");
            }
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("jwt");
            return Task.CompletedTask;
        }
    }
}
