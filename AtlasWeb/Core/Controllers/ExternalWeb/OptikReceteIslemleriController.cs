//$CCAB65F0
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.OptikReceteIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class OptikReceteIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public OptikReceteIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ereceteListeSorguInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public ereceteListeSorguIstekDVO ereceteListeSorguIstek
            {
                get;
                set;
            }
        }

        public ereceteListeSorguCevapDVO ereceteListeSorgu(ereceteListeSorguInput input)
        {
            var result = OptikReceteIslemleri.WebMethods.ereceteListeSorgu(input.siteID, input.userName, input.password, input.ereceteListeSorguIstek);
            return result;
        }

        public class ereceteSilInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public ereceteSilDVO ereceteSil
            {
                get;
                set;
            }
        }

        public sonucDVO ereceteSil(ereceteSilInput input)
        {
            var result = OptikReceteIslemleri.WebMethods.ereceteSil(input.siteID, input.userName, input.password, input.ereceteSil);
            return result;
        }

        public class ereceteKaydetInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public receteTesisDVO receteTesis
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public sonucDVO ereceteKaydet(ereceteKaydetInput input)
        {
            var result = OptikReceteIslemleri.WebMethods.ereceteKaydet(input.siteID, input.userName, input.password, input.receteTesis);
            return result;
        }
    }
}