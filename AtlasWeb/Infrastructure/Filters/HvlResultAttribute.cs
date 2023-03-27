using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Infrastructure.Helpers;
using TTUtils;
using System.Reflection;
using System.Linq;

namespace Infrastructure.Filters
{
    public class HvlResultAttribute : ActionFilterAttribute, IActionFilter
    {

        public HvlResultAttribute()
        {
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            object returnValue = null;
            Type hvlResultType = typeof (AtlasResult<>);
            var controllerActionDescriptor = (ControllerActionDescriptor)actionExecutedContext.ActionDescriptor;
            Type returnType = controllerActionDescriptor.MethodInfo.ReturnType;

            var returnTypeIsVoid = returnType.Equals(typeof (void));
            if (returnTypeIsVoid == true)
            {
                returnValue = Activator.CreateInstance(hvlResultType.MakeGenericType(typeof (object)));
            }
            else
            {
                if (returnType.IsGenericType && returnType.BaseType != null && returnType.BaseType.Equals(typeof (Task)))
                {
                    returnType = returnType.GenericTypeArguments[0];
                }

                Type[] typeArgs = {returnType};
                returnValue = Activator.CreateInstance(hvlResultType.MakeGenericType(typeArgs));
            }

            int accessCount = TTUtils.AtlasDbAccessTracerFactory.Instance?.GetAccessCount() ?? 0;
            returnValue.GetType().GetProperty("DbAccessCount").SetValue(returnValue, accessCount);

            try
            {
                var metricsService = actionExecutedContext.HttpContext.RequestServices.GetService(typeof(IMetricsService)) as IMetricsService;
                metricsService.SendToPrometheus();
            }
            catch
            {

            }

            if (actionExecutedContext.Exception != null)
            {
                returnValue.GetType().GetProperty("IsSuccess").SetValue(returnValue, false);
                string message = actionExecutedContext.Exception.Message;
                returnValue.GetType().GetProperty("Message").SetValue(returnValue, message);
                actionExecutedContext.ExceptionHandled = true;
                var logger = actionExecutedContext.HttpContext.RequestServices.GetService(typeof(ILogger<HvlResultAttribute>)) as ILogger<HvlResultAttribute>;
                logger.LogError(actionExecutedContext.Exception.ToString());
            }
            else
            {
                returnValue.GetType().GetProperty("IsSuccess").SetValue(returnValue, true);
                if (returnTypeIsVoid == false)
                {
                    var voidObjectResult = actionExecutedContext.Result as ObjectResult;
                    if (voidObjectResult != null)
                    {
                        voidObjectResult.StatusCode = (int)HttpStatusCode.OK;
                        returnValue.GetType().GetProperty("Result").SetValue(returnValue, voidObjectResult.Value);
                    }
                }

                var currentResponse = actionExecutedContext.HttpContext.Response;
                IEnumerable<string> headerValues = currentResponse.Headers[CustomHeaderNames.InfoMessageHeader];
                if (headerValues != null)
                {
                    StringBuilder messageContent = new StringBuilder();
                    foreach (var headerItem in headerValues)
                    {
                        var messageBuffer = Convert.FromBase64String(headerItem);
                        var messageText = Encoding.UTF8.GetString(messageBuffer);
                        messageContent.AppendLine(messageText);
                    }

                    var infoMessage = messageContent.ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(infoMessage))
                    {
                        returnValue.GetType().GetProperty("InfoMessage").SetValue(returnValue, infoMessage);
                    }
                }
            }

            var objectResult = new ObjectResult(returnValue);
            objectResult.StatusCode = (int)HttpStatusCode.OK;
            actionExecutedContext.Result = objectResult;
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}