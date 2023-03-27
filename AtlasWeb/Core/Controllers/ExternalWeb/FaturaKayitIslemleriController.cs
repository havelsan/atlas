//$F7D1C5A7
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.FaturaKayitIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class FaturaKayitIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public FaturaKayitIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class faturaIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public faturaIptalGirisDVO faturaIptalGiris
            {
                get;
                set;
            }
        }

        public faturaIptalCevapDVO faturaIptalSync(faturaIptalSyncInput input)
        {
            var result = FaturaKayitIslemleri.WebMethods.faturaIptalSync(input.siteID, input.faturaIptalGiris);
            return result;
        }

        public class faturaKayitASyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IWebMethodCallback callerObject
            {
                get;
                set;
            }

            public faturaGirisDVO faturaGiris
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage faturaKayitASync(faturaKayitASyncInput input)
        {
            var result = FaturaKayitIslemleri.WebMethods.faturaKayitASync(input.siteID, input.callerObject, input.faturaGiris);
            return result;
        }

        public class faturaKayitSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public faturaGirisDVO faturaGiris
            {
                get;
                set;
            }
        }

        public faturaCevapDVO faturaKayitSync(faturaKayitSyncInput input)
        {
            var result = FaturaKayitIslemleri.WebMethods.faturaKayitSync(input.siteID, input.faturaGiris);
            return result;
        }

        public class faturaOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public faturaOkuGirisDVO faturaOkuGiris
            {
                get;
                set;
            }
        }

        public faturaOkuCevapDVO faturaOkuSync(faturaOkuSyncInput input)
        {
            var result = FaturaKayitIslemleri.WebMethods.faturaOkuSync(input.siteID, input.faturaOkuGiris);
            return result;
        }

        public class faturaTutarOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public faturaGirisDVO faturaOkuGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public faturaCevapDVO faturaTutarOkuSync(faturaTutarOkuSyncInput input)
        {
            var result = FaturaKayitIslemleri.WebMethods.faturaTutarOkuSync(input.siteID, input.faturaOkuGiris);
            return result;
        }
    }
}