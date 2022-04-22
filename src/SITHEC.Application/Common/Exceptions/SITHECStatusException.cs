using System;
using System.Net;

namespace SITHEC.Application.Common.Exceptions
{
    public class SITHECStatusException : Exception
    {
        public SITHECStatusException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
