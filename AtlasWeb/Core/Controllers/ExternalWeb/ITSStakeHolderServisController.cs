//$422C2A47
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class ITSStakeHolderServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSStakeHolderServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class CallStakeholderInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public ITSStakeHolderServis.stakeholderRequest stakeholderRq
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public ITSStakeHolderServis.stakeholderResponse CallStakeholder(CallStakeholderInput input)
        //{
        //    var result = ITSStakeHolderServis.WebMethods.CallStakeholder(input.siteID, input.stakeholderRq);
        //    return result;
        //}
    }
}