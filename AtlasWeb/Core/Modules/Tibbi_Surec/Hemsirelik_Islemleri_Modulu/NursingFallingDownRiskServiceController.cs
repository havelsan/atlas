//$D0EDB62C
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
    public partial class NursingFallingDownRiskServiceController : Controller
    {
        public class CalcFallingDownRiskTotalScore_Input
        {
            public TTObjectClasses.NursingFallingDownRisk nursingFallingDownRisk
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public void CalcFallingDownRiskTotalScore(CalcFallingDownRiskTotalScore_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.nursingFallingDownRisk != null)
                    input.nursingFallingDownRisk = (TTObjectClasses.NursingFallingDownRisk)objectContext.AddObject(input.nursingFallingDownRisk);
                NursingFallingDownRisk.CalcFallingDownRiskTotalScore(input.nursingFallingDownRisk);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
    }
}