//$893B07BD
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.TakipFormuIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class TakipFormuIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public TakipFormuIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class takipFormuKaydetInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipFormuKaydetGirisDVO takipFormuGiris
            {
                get;
                set;
            }
        }

        public takipFormuKaydetCevapDVO takipFormuKaydet(takipFormuKaydetInput input)
        {
            var result = TakipFormuIslemleri.WebMethods.takipFormuKaydet(input.siteID, input.takipFormuGiris);
            return result;
        }

        public class takipFormuOkuInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipFormuOkuGirisDVO takipFormuOkuGiris
            {
                get;
                set;
            }
        }

        public takipFormuOkuCevapDVO takipFormuOku(takipFormuOkuInput input)
        {
            var result = TakipFormuIslemleri.WebMethods.takipFormuOku(input.siteID, input.takipFormuOkuGiris);
            return result;
        }

        public class takipFormuSilInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipFormuSilGirisDVO takipFormuSilGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public takipFormuSilCevapDVO takipFormuSil(takipFormuSilInput input)
        {
            var result = TakipFormuIslemleri.WebMethods.takipFormuSil(input.siteID, input.takipFormuSilGiris);
            return result;
        }
    }
}