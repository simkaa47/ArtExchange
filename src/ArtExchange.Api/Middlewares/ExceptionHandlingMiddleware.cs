using ArtExchange.Application.Exceptions;
using FluentValidation;
using System.Linq;
using System.Text.Json;

namespace ArtExchange.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        public static int GetStatusCode(Exception exception) 
        {
            switch (exception)
            {
                case BadHttpRequestException:return StatusCodes.Status400BadRequest;  
                    case ValidationException:return StatusCodes.Status422UnprocessableEntity;
                case NotFoundException: return StatusCodes.Status404NotFound;
                case RestException: return ((int)((RestException)exception).Code);
                default:return StatusCodes.Status500InternalServerError;                    
            }
        }

        private static string GetTitle(Exception exception)
        {
            switch (exception)
            {
                case ApplicationException applicationException:return applicationException.Message;
                default:return "Server error";
            }
        }

        private static IReadOnlyDictionary<string, string[]> GetErrors(Exception exception)
        {
            IReadOnlyDictionary<string, string[]>? errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors
                    .GroupBy(
                            x => x.PropertyName,
                            x => x.ErrorMessage,
                            (propertyName, errorMessages) => new
                            {
                                Key = propertyName,
                                Values = errorMessages.Distinct().ToArray()
                            })
                    .ToDictionary(x => x.Key, x => x.Values);
            }
            if(errors is null)return new Dictionary<string, string[]>();
            return errors;
        }
    }
}
