//$3110868C
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
    public partial class EarlyChildGrowthEvaluationServiceController : Controller
    {
        public class EarlyChildGrovthEvaluationFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList_Class> EarlyChildGrovthEvaluationFormList(EarlyChildGrovthEvaluationFormList_Input input)
        {
            var ret = EarlyChildGrowthEvaluation.EarlyChildGrovthEvaluationFormList(input.EPISODE);
            return ret;
        }
    }
}