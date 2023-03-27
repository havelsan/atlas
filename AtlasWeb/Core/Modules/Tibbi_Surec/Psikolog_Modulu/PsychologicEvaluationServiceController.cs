//$49E37C09
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
    public partial class PsychologicEvaluationServiceController : Controller
    {
        public class PsychologicEvaluationFormList_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PsychologicEvaluation.PsychologicEvaluationFormList_Class> PsychologicEvaluationFormList(PsychologicEvaluationFormList_Input input)
        {
            var ret = PsychologicEvaluation.PsychologicEvaluationFormList(input.EPISODE);
            return ret;
        }
    }
}