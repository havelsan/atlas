//$2F014EF0
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
    public class ITSDeaktivasyonServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSDeaktivasyonServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class deaktivasyonBildirInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public ITSDeaktivasyonServis.DeaktivasyonBildirimType deaktivasyonBildirimType
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public ITSDeaktivasyonServis.DeaktivasyonBildirimCevapType deaktivasyonBildir(deaktivasyonBildirInput input)
        //{
        //    var result = ITSDeaktivasyonServis.WebMethods.deaktivasyonBildir(input.siteID, input.deaktivasyonBildirimType);
        //    return result;
        //}
    }
}