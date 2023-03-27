using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text;

namespace Infrastructure.Filters
{
    public class HvlValidateAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            StringBuilder messages = null;
            if (!actionContext.ModelState.IsValid)
            {
                var controllerActionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
                Type returnType = controllerActionDescriptor.MethodInfo.ReturnType;
                Type hvlResultType = typeof (AtlasResult<>);
                Type[] typeArgs = {returnType};
                object returnValue = Activator.CreateInstance(hvlResultType.MakeGenericType(typeArgs));
                messages = new StringBuilder();
                foreach (var error in actionContext.ModelState.Values.SelectMany(t => t.Errors))
                {
                    messages.Append(error.ErrorMessage);
                }

                returnValue.GetType().GetProperty("Message").SetValue(returnValue, messages.ToString());
                //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError);
                //actionContext.Response.Content = new ObjectContent(returnValue.GetType(), returnValue, new JsonMediaTypeFormatter());
                var content = new ObjectResult(returnValue);
                actionContext.Result = content;
            }
            else
                base.OnActionExecuting(actionContext);
        }
    }
}