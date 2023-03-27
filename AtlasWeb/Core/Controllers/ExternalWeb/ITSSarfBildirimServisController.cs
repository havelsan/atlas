//$CFE83095
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
    public class ITSSarfBildirimServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSSarfBildirimServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class XXXXXXSarfBildirInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public ITSSarfBildirimServis.XXXXXXSarfType XXXXXXSarfType
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public XXXXXXSarfCevapType XXXXXXSarfBildir(XXXXXXSarfBildirInput input)
        //{
        //    var result = ITSSarfBildirimServis.WebMethods.XXXXXXSarfBildir(input.siteID, input.XXXXXXSarfType);
        //    return result;
        //}
    }
}