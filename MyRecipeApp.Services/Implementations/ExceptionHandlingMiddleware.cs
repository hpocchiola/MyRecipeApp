using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MyRecipeApp.DTOs;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyRecipeApp.Services.Implementations
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlingMiddleware> logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)    
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception.Message == "You must either set Authority or IntrospectionEndpoint" ? (int)HttpStatusCode.Unauthorized : (int)HttpStatusCode.InternalServerError;
            logger.LogError($"{exception.Message} - {exception.InnerException?.Message} - {exception.StackTrace}");
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDetails { Errors = { exception.Message, exception.InnerException?.Message + exception.StackTrace } }));
        }
    }
}
