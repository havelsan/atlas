//$5CB44512
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.OrtodontiIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class OrtodontiIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public OrtodontiIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ortodontiFormuIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ortodontiFormuIptalGirisDVO ortodontiFormuIptalGiris
            {
                get;
                set;
            }
        }

        public ortodontiFormuIptalCevapDVO ortodontiFormuIptalSync(ortodontiFormuIptalSyncInput input)
        {
            var result = OrtodontiIslemleri.WebMethods.ortodontiFormuIptalSync(input.siteID, input.ortodontiFormuIptalGiris);
            return result;
        }

        public class ortodontiFormuKaydetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ortodontiFormuKaydetGirisDVO ortodontiFormuKaydetGiris
            {
                get;
                set;
            }
        }

        public ortodontiFormuKaydetCevapDVO ortodontiFormuKaydetSync(ortodontiFormuKaydetSyncInput input)
        {
            var result = OrtodontiIslemleri.WebMethods.ortodontiFormuKaydetSync(input.siteID, input.ortodontiFormuKaydetGiris);
            return result;
        }

        public class ortodontiFormuOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ortodontiFormuOkuGirisDVO ortodontiFormuOkuGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public ortodontiFormuOkuCevapDVO ortodontiFormuOkuSync(ortodontiFormuOkuSyncInput input)
        {
            var result = OrtodontiIslemleri.WebMethods.ortodontiFormuOkuSync(input.siteID, input.ortodontiFormuOkuGiris);
            return result;
        }
    }
}