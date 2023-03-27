//$8A3E4FCD
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.TaahhutIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class TaahhutIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public TaahhutIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class disTaahhutKayitInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public taahhutKayitDVO taahhutKayit
            {
                get;
                set;
            }
        }

        public taahhutCevapDVO disTaahhutKayit(disTaahhutKayitInput input)
        {
            var result = TaahhutIslemleri.WebMethods.disTaahhutKayit(input.siteID, input.taahhutKayit);
            return result;
        }

        public class okuDisTaahhutInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public taahhutOkuDVO taahhutOku
            {
                get;
                set;
            }
        }

        public taahhutCevapDVO okuDisTaahhut(okuDisTaahhutInput input)
        {
            var result = TaahhutIslemleri.WebMethods.okuDisTaahhut(input.siteID, input.taahhutOku);
            return result;
        }

        public class okuKisiDisTaahhutInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public taahhutKisiOkuDVO taahhutOku
            {
                get;
                set;
            }
        }

        public taahhutKisiCevapDVO okuKisiDisTaahhut(okuKisiDisTaahhutInput input)
        {
            var result = TaahhutIslemleri.WebMethods.okuKisiDisTaahhut(input.siteID, input.taahhutOku);
            return result;
        }

        public class silDisTaahhutInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public taahhutOkuDVO taahhutOku
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public taahhutCevapDVO silDisTaahhut(silDisTaahhutInput input)
        {
            var result = TaahhutIslemleri.WebMethods.silDisTaahhut(input.siteID, input.taahhutOku);
            return result;
        }
    }
}