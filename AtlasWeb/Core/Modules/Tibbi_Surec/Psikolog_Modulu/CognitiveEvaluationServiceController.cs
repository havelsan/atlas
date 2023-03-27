//$A842FE79
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
    public partial class CognitiveEvaluationServiceController : Controller
    {
        public class CognitiveEvaluationFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<CognitiveEvaluation.CognitiveEvaluationFormList_Class> CognitiveEvaluationFormList(CognitiveEvaluationFormList_Input input)
        {
            var ret = CognitiveEvaluation.CognitiveEvaluationFormList(input.EPISODE);
            return ret;
        }
    }
}