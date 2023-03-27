using Infrastructure.Services;
using Microsoft.AspNetCore.Http;  
using Serilog;  
using Serilog.Events;  
using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;
using Infrastructure.Helpers;
using Serilog.Context;
using Serilog.Core.Enrichers;
using Infrastructure.Constants;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using System.IO;

namespace Core.Middleware
{
    internal class SerilogMiddleware
    {
        const string MessageTemplate =
            "Warning: HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        private static readonly ILogger Log = Serilog.Log.ForContext<SerilogMiddleware>();
        private readonly RequestDelegate _next;
        private readonly IServiceLogWriterService _serviceLogWriterService;
        private readonly Microsoft.Extensions.Logging.ILogger<SerilogMiddleware> _logger;
        private readonly AtlasSettings _atlasSettings;

        public SerilogMiddleware(RequestDelegate next, IServiceLogWriterService serviceLogWriterService, Microsoft.Extensions.Logging.ILogger<SerilogMiddleware> logger, IOptions<AtlasSettings> atlasSettings)
        {
            _next = next;
            _logger = logger;
            _serviceLogWriterService = serviceLogWriterService;
            _atlasSettings = atlasSettings.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var userIDKey = httpContext.GetUserIDKey();
            var workstationIpAddress = httpContext.Connection.RemoteIpAddress.ToString();

            using (LogContext.Push(new PropertyEnricher(PropertyNames.UserID, userIDKey), new PropertyEnricher(PropertyNames.RemoteIpAddress, workstationIpAddress)))
            {
                DateTime startTime = DateTime.Now;
                var sw = Stopwatch.StartNew();
                try
                {
                  /*  long responseLength = 0;
                    var originalBodyStream = httpContext.Response.Body;
                    using (var responseBody = new MemoryStream())
                    {
                        httpContext.Response.Body = responseBody;*/
                        await _next(httpContext);
                        sw.Stop();
                 /*       responseLength = responseBody.Length;
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBodyStream);
                        httpContext.Response.Body = originalBodyStream;
                    }*/
                    
                    var statusCode = httpContext.Response?.StatusCode;
                    var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                    if (sw.ElapsedMilliseconds > _atlasSettings.ServiceElapsedTime) // || responseLength > 10000 || (httpContext.Request.ContentLength.HasValue && httpContext.Request.ContentLength > 10000))
                    {
                        _serviceLogWriterService.WriteErrorLog(httpContext.Request.Method, httpContext.Request.Path, statusCode.ToString(), startTime, workstationIpAddress, sw.Elapsed.TotalMilliseconds);
                        //Log.Write(LogEventLevel.Warning, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);
                    }
                }
                // Never caught, because `LogException()` returns false.
                catch (Exception ex) when (LogException(httpContext, _serviceLogWriterService, _logger, sw, ex)) { }
            }
        }

        static bool LogException(HttpContext httpContext, IServiceLogWriterService serviceLogWriterService, Microsoft.Extensions.Logging.ILogger logger, Stopwatch sw, Exception ex)
        {
            sw.Stop();

            // var userIDKey = httpContext.GetUserIDKey();
            // var workStationName = httpContext.Connection.RemoteIpAddress.ToString();

            Log.Error(ex.ToString());

            // errorLogWriterService.WriteErrorLog(userIDKey, workStationName, ex.ToString());

            return false;
        }
      
    }
}