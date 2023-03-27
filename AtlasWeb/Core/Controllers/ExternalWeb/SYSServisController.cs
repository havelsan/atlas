//$7A2579C6
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.SYSServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class SYSServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public SYSServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class SYSSendMessageSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string input
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public string SYSSendMessageSync(SYSSendMessageSyncInput input)
        {
            var result = SYSServis.WebMethods.SYSSendMessageSync(input.siteID, input.input);
            return result;
        }
    }
}