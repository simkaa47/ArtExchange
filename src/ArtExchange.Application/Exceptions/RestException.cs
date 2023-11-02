using System.Net;

namespace ArtExchange.Application.Exceptions
{
    public class RestException:ApplicationException
    {
        public RestException(string message, HttpStatusCode code)
            :base(message)
        {
            Code = code;            
        }

        public HttpStatusCode Code { get; }
        
    }
}
