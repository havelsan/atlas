//$EECB5390
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
    public class ITSReceiptNotificationController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSReceiptNotificationController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class sendReceiptNotificationSyncInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public ItsPlainRequest ReceiptRequest
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public ItsResponse sendReceiptNotificationSync(sendReceiptNotificationSyncInput input)
        //{
        //    var result = ITSReceiptNotification.WebMethods.sendReceiptNotificationSync(input.siteID, input.ReceiptRequest);
        //    return result;
        //}
    }
}