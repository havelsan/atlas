//$779A45B8
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class PregnancyResultServiceController : Controller
    {
        public class GetPregnancyResultByPregnancy_Input
        {
            public Guid PREGNANCY
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PregnancyResult.GetPregnancyResultByPregnancy_Class> GetPregnancyResultByPregnancy(GetPregnancyResultByPregnancy_Input input)
        {
            var ret = PregnancyResult.GetPregnancyResultByPregnancy(input.PREGNANCY);
            return ret;
        }
    }
}