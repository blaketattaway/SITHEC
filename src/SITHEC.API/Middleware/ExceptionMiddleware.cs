using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SITHEC.Application.Common.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SITHEC.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case SITHECStatusException statusException:
                        statusCode = statusException.StatusCode;
                        result = JsonConvert.SerializeObject(statusException);
                        break;
                    case SITHECValidationException validationException:
                        statusCode = HttpStatusCode.BadRequest;
                        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(new SITHECApiException(statusCode, validationJson));
                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new SITHECApiException(statusCode, ex.StackTrace));

                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(result);

            }

        }
    }
}
