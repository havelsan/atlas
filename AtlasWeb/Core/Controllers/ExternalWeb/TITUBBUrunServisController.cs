//$AED1FBDE
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.TITUBBUrunServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class TITUBBUrunServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public TITUBBUrunServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class GetUrunSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public string barkod
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public ProductServiceResult GetUrunSync(GetUrunSyncInput input)
        {
            var result = TITUBBUrunServis.WebMethods.GetUrunSync(input.siteID, input.userName, input.password, input.barkod);
            return result;
        }
    }
}