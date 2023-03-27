//$567AAC48
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class ITSCheckStatusNotificationController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSCheckStatusNotificationController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class sendCheckStatusNotificationSyncInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public ItsPlainRequest QueryRequest
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public ItsResponse sendCheckStatusNotificationSync(sendCheckStatusNotificationSyncInput input)
        //{
        //    var result = ITSCheckStatusNotification.WebMethods.sendCheckStatusNotificationSync(input.siteID, input.QueryRequest);
        //    return result;
        //}
    }
}