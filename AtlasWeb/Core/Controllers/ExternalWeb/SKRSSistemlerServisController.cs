//$63D9D8D9
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.SKRSSistemlerServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class SKRSSistemlerServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public SKRSSistemlerServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class SistemKodlariSayfaGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string sistemKoduInput
            {
                get;
                set;
            }

            public DateTime tarihInput
            {
                get;
                set;
            }

            public bool tarihInputSpecified
            {
                get;
                set;
            }
            public int skrsKod
            {
                get;
                set;
            }

            public bool skrsKodSpecified
            {
                get;
                set;
            }
            public string kurumNo
            {
                get;
                set;
            }
        }

        public kodDegerleriResponse SistemKodlariSayfaGetirSync(SistemKodlariSayfaGetirSyncInput input)
        {
            var result = SKRSSistemlerServis.WebMethods.SistemKodlariSayfaGetirSync(input.siteID, input.sistemKoduInput, input.tarihInput, input.tarihInputSpecified, input.skrsKod, input.skrsKodSpecified, input.kurumNo);
            return result;
        }

        public class SistemKodlariSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string sistemKoduInput
            {
                get;
                set;
            }

            public DateTime tarihInput
            {
                get;
                set;
            }

            public bool tarihInputSpecified
            {
                get;
                set;
            }

            public string kurumNo
            {
                get;
                set;
            }
        }

        public kodDegerleriResponse SistemKodlariSync(SistemKodlariSyncInput input)
        {
            var result = SKRSSistemlerServis.WebMethods.SistemKodlariSync(input.siteID, input.sistemKoduInput, input.tarihInput, input.tarihInputSpecified, input.kurumNo);
            return result;
        }

        public class SistemlerSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public wsskrsSistemlerResponse SistemlerSync(SistemlerSyncInput input)
        {
            var result = SKRSSistemlerServis.WebMethods.SistemlerSync(input.siteID);
            return result;
        }
    }
}