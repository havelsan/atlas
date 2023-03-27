//$99EA4153
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.KPSYbKisiSorgulaYbKimlikNoServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class KPSYbKisiSorgulaYbKimlikNoServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public KPSYbKisiSorgulaYbKimlikNoServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ListeleCokluSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public YbKisiSorgulaYbKimlikNoSorguKriteri kriter
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public YbKimlikNoIleYbKisiBilgisiSonucu ListeleCokluSync(ListeleCokluSyncInput input)
        {
            var result = KPSYbKisiSorgulaYbKimlikNoServis.WebMethods.ListeleCokluSync(input.siteID, input.kriter);
            return result;
        }
    }
}