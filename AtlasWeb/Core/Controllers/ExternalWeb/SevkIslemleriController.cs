//$55BF986C
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.SevkIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class SevkIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public SevkIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class mutatDisiAracRaporKaydetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public mutatDisiRaporDVO mutatDisiRaporDVO
            {
                get;
                set;
            }
        }

        public mutatDisiRaporCevapDVO mutatDisiAracRaporKaydetSync(mutatDisiAracRaporKaydetSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(input.siteID, input.mutatDisiRaporDVO);
            return result;
        }

        public class mutatDisiAracRaporSilSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO
            {
                get;
                set;
            }
        }

        public mutatDisiIptalCevapDVO mutatDisiAracRaporSilSync(mutatDisiAracRaporSilSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(input.siteID, input.mutatDisiRaporIptalDVO);
            return result;
        }

        public class sevkBildirimIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkBildirimIptalDVO sevkBildirimIptalDVO
            {
                get;
                set;
            }
        }

        public sevkIptalCevapDVO sevkBildirimIptalSync(sevkBildirimIptalSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.sevkBildirimIptalSync(input.siteID, input.sevkBildirimIptalDVO);
            return result;
        }

        public class sevkBildirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkBildirimDVO sevkBildirimDVO
            {
                get;
                set;
            }
        }

        public sevkCevapDVO sevkBildirSync(sevkBildirSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.sevkBildirSync(input.siteID, input.sevkBildirimDVO);
            return result;
        }

        public class sevkKayitIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkKayitIptalDVO sevkKayitIptalDVO
            {
                get;
                set;
            }
        }

        public sevkIptalCevapDVO sevkKayitIptalSync(sevkKayitIptalSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.sevkKayitIptalSync(input.siteID, input.sevkKayitIptalDVO);
            return result;
        }

        public class sevkKayitSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkKayitDVO sevkKayitDVO
            {
                get;
                set;
            }
        }

        public sevkCevapDVO sevkKayitSync(sevkKayitSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.sevkKayitSync(input.siteID, input.sevkKayitDVO);
            return result;
        }

        public class sevkListeleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkListeDVO sevkListeDVO
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public sevkListeCevapDVO sevkListeleSync(sevkListeleSyncInput input)
        {
            var result = SevkIslemleri.WebMethods.sevkListeleSync(input.siteID, input.sevkListeDVO);
            return result;
        }
    }
}