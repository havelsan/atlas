//$E6E8C430
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.KPSKisiSorgulaKimlikNoServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class KPSKisiSorgulaKimlikNoServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public KPSKisiSorgulaKimlikNoServisController(WebMethodCallerService webMethodCallerService)
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

            public KisiSorgulaTCKimlikNoSorguKriteri kriter
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public KisiBilgisiSonucu ListeleCokluSync(ListeleCokluSyncInput input)
        {
            var result = KPSKisiSorgulaKimlikNoServis.WebMethods.ListeleCokluSync(input.siteID, input.kriter);
            return result;
        }
    }
}