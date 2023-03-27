//$775CEDB8
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.PTSPackageReceiverServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class PTSPackageReceiverServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public PTSPackageReceiverServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class receiveFileStreamInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public receiveFileParametersType receiveFilePT
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public Byte[] receiveFileStream(receiveFileStreamInput input)
        {
            var result = PTSPackageReceiverServis.WebMethods.receiveFileStream(input.siteID, input.receiveFilePT);
            return result;
        }
    }
}