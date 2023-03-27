//$25C21461
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.HizmetKayitIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class HizmetKayitIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public HizmetKayitIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class hizmetIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public hizmetIptalGirisDVO hizmetIptalGiris
            {
                get;
                set;
            }
        }

        public hizmetIptalCevapDVO hizmetIptalSync(hizmetIptalSyncInput input)
        {
            var result = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(input.siteID, input.hizmetIptalGiris);
            return result;
        }

        public class hizmetKayitASyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public Guid? procedureObjectID
            {
                get;
                set;
            }

            public IWebMethodCallback callerObject
            {
                get;
                set;
            }

            public hizmetKayitGirisDVO hizmetKayitGiris
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage hizmetKayitASync(hizmetKayitASyncInput input)
        {
            var result = HizmetKayitIslemleri.WebMethods.hizmetKayitASync(input.siteID, input.procedureObjectID, input.callerObject, input.hizmetKayitGiris);
            return result;
        }

        public class hizmetKayitSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public Guid? procedureObjectID
            {
                get;
                set;
            }

            public hizmetKayitGirisDVO hizmetKayitGiris
            {
                get;
                set;
            }
        }

        public hizmetKayitCevapDVO hizmetKayitSync(hizmetKayitSyncInput input)
        {
            var result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(input.siteID, input.procedureObjectID, input.hizmetKayitGiris);
            return result;
        }

        public class hizmetOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public hizmetOkuGirisDVO hizmetOkuGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public hizmetOkuCevapDVO hizmetOkuSync(hizmetOkuSyncInput input)
        {
            var result = HizmetKayitIslemleri.WebMethods.hizmetOkuSync(input.siteID, input.hizmetOkuGiris);
            return result;
        }
    }
}