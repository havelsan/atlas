//$5A711BE1
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.DrugServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class DrugServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public DrugServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class GetLastAuditsSyncInput
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

            public string LastRowId
            {
                get;
                set;
            }
        }

        public AuditRow[] GetLastAuditsSync(GetLastAuditsSyncInput input)
        {
            var result = DrugServis.WebMethods.GetLastAuditsSync(input.siteID, input.userName, input.password, input.LastRowId);
            return result;
        }

        public class GetLastAuditsXXXXXXSyncInput
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

            public string LastRowId
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public AuditRow[] GetLastAuditsXXXXXXSync(GetLastAuditsXXXXXXSyncInput input)
        {
            var result = DrugServis.WebMethods.GetLastAuditsXXXXXXSync(input.siteID, input.userName, input.password, input.LastRowId);
            return result;
        }
    }
}