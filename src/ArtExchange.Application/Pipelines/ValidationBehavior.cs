using FluentValidation;
using MediatR;

namespace ArtExchange.Application.Pipelines
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x=>x!=null);
                
            if (errors.Any())
            {
                throw new ValidationException("Server validation error", errors);
            }
            return await next();

            //https://code-maze.com/cqrs-mediatr-fluentvalidation/
        }

        
    }
    
}
