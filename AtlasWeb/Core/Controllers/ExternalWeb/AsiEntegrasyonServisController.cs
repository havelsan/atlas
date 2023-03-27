//$1FAB4B8C
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.AsiEntegrasyonServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class AsiEntegrasyonServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public AsiEntegrasyonServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class AsiKullanilabilirlikSorgusuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public AsiKullanilabilirlikSorgusuGirdi asiKullanilabilirlikSorgusuGirdi
            {
                get;
                set;
            }
        }

        public AsiKullanilabilirlikSorgusuCikti AsiKullanilabilirlikSorgusuSync(AsiKullanilabilirlikSorgusuSyncInput input)
        {
            var result = AsiEntegrasyonServis.WebMethods.AsiKullanilabilirlikSorgusuSync(input.siteID, input.asiKullanilabilirlikSorgusuGirdi);
            return result;
        }

        public class AsiUygulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public AsiUygulamaParametre istek
            {
                get;
                set;
            }
        }

        public AsiUygulamaCikti AsiUygulamaSync(AsiUygulamaSyncInput input)
        {
            var result = AsiEntegrasyonServis.WebMethods.AsiUygulamaSync(input.siteID, input.istek);
            return result;
        }

        public class UygulamaSorgusuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string SorguNo
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public UygulamaSorgusuCikti UygulamaSorgusuSync(UygulamaSorgusuSyncInput input)
        {
            var result = AsiEntegrasyonServis.WebMethods.UygulamaSorgusuSync(input.siteID, input.SorguNo);
            return result;
        }
    }
}