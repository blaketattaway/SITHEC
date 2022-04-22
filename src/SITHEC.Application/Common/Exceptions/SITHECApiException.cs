using System.Net;

namespace SITHEC.Application.Common.Exceptions
{
    public class SITHECApiException
    {
        public SITHECApiException(HttpStatusCode statusCode, string details = null)
        {
            StatusCode = statusCode;
            Details = details;
        }
        public HttpStatusCode StatusCode { get; set; }
        public string Details { get; set; }
    }
}
