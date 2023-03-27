//$E942F735
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class AdvanceBackServiceController : Controller
    {
        public class GetByEpisode_Input
        {
            public string PARAMEPISODE
            {
                get;
                set;
            }

            public string PARAMSTATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<AdvanceBack> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AdvanceBack.GetByEpisode(objectContext, input.PARAMEPISODE, input.PARAMSTATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}