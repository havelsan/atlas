//$44E16F2E
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.TeletipGuidServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class TeletipGuidServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public TeletipGuidServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class CreateGuidWithTcNoAndAccNoSyncInput
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

            public string requestingUserTcNo
            {
                get;
                set;
            }

            public string patientTcNo
            {
                get;
                set;
            }

            public string AccNo
            {
                get;
                set;
            }

            public string applicationCode
            {
                get;
                set;
            }
        }

        public string CreateGuidWithTcNoAndAccNoSync(CreateGuidWithTcNoAndAccNoSyncInput input)
        {
            var result = TeletipGuidServis.WebMethods.CreateGuidWithTcNoAndAccNoSync(input.siteID, input.userName, input.password, input.requestingUserTcNo, input.patientTcNo, input.AccNo, input.applicationCode);
            return result;
        }

        public class CreateGuidWithTcNoSyncInput
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

            public string requestingUserTcNo
            {
                get;
                set;
            }

            public string patientTcNo
            {
                get;
                set;
            }

            public int numberOfUse
            {
                get;
                set;
            }

            public bool numberOfUseSpecified
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public string CreateGuidWithTcNoSync(CreateGuidWithTcNoSyncInput input)
        {
            var result = TeletipGuidServis.WebMethods.CreateGuidWithTcNoSync(input.siteID, input.userName, input.password, input.requestingUserTcNo, input.patientTcNo, input.numberOfUse, input.numberOfUseSpecified);
            return result;
        }
    }
}