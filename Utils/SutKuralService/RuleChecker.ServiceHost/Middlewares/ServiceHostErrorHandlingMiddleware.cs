using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RuleChecker.Interface;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RuleChecker.ServiceHost.Middlewares
{
    public class ServiceHostErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ServiceHostErrorHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.Error(exception, "An Error ocurred with method {0}", context.Request.Method);
            var code = HttpStatusCode.InternalServerError;
            var errorInfo = new { error = exception.Message, detailedError = exception.ToString() };
            var result = JsonConvert.SerializeObject(errorInfo);
            context.Response.ContentType = RuleCheckerConstants.ContentTypeApplicationJson;
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
