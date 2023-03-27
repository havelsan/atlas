using Infrastructure.Filters;
using System;
using System.Collections.Generic;

using System.Linq;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class SystemMessageServiceController : Controller
    {
        public class GetMessageInput
        {
            public int Code
            {
                get;
                set;
            }

            public string DefaultValue
            {
                get;
                set;
            }

            public string[] Parameters
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetMessage(GetMessageInput input)
        {
            if (input.Parameters != null && !string.IsNullOrWhiteSpace(input.DefaultValue))
            {
                return SystemMessage.GetMessageV4(input.Code, input.DefaultValue, input.Parameters);
            }
            else if (input.Parameters != null && string.IsNullOrWhiteSpace(input.DefaultValue))
            {
                return SystemMessage.GetMessageV3(input.Code, input.Parameters);
            }
            else if (input.Parameters == null && !string.IsNullOrWhiteSpace(input.DefaultValue))
            {
                return SystemMessage.GetMessageV2(input.Code, input.DefaultValue);
            }

            return SystemMessage.GetMessage(input.Code);
        }
    }
}