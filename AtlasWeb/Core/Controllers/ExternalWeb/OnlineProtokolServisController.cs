//$DF713FCE
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.OnlineProtokolServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class OnlineProtokolServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public OnlineProtokolServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class getVersionSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public string getVersionSync(getVersionSyncInput input)
        {
            var result = OnlineProtokolServis.WebMethods.getVersionSync(input.siteID);
            return result;
        }

        public class protokolVerSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kullanici kullaniciBilgisi
            {
                get;
                set;
            }

            public protokol oProtokol
            {
                get;
                set;
            }
        }

        public cevap protokolVerSync(protokolVerSyncInput input)
        {
            var result = OnlineProtokolServis.WebMethods.protokolVerSync(input.siteID, input.kullaniciBilgisi, input.oProtokol);
            return result;
        }

        public class protokolSilSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public int silmeNedeni
            {
                get;
                set;
            }

            public kullanici kullaniciBilgisi
            {
                get;
                set;
            }
        }

        public cevap protokolSilSync(protokolSilSyncInput input)
        {
            var result = OnlineProtokolServis.WebMethods.protokolSilSync(input.siteID, input.protokolNo, input.silmeNedeni, input.kullaniciBilgisi);
            return result;
        }

        public class protokolListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kullanici kullaniciBilgisi
            {
                get;
                set;
            }

            public string kurum
            {
                get;
                set;
            }

            public string tarih
            {
                get;
                set;
            }

            public string otomasyonKayitID
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public protokolListesiCevap protokolListesiSync(protokolListesiSyncInput input)
        {
            var result = OnlineProtokolServis.WebMethods.protokolListesiSync(input.siteID, input.kullaniciBilgisi, input.kurum, input.tarih, input.otomasyonKayitID);
            return result;
        }
    }
}