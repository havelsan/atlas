//$A75D8EB3
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.KPSKimlikNoSorgulaAdresServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class KPSKimlikNoSorgulaAdresServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public KPSKimlikNoSorgulaAdresServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class SorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KimlikNoileAdresSorguKriteri kriter
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public KimlikNoileKisiAdresBilgileriSonucu SorgulaSync(SorgulaSyncInput input)
        {
            var result = KPSKimlikNoSorgulaAdresServis.WebMethods.SorgulaSync(input.siteID, input.kriter);
            return result;
        }
    }
}