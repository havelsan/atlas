//$F7652F93
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class NursingWoundAssessmentScaleServiceController : Controller
    {
        public class CalcNursingWoundAssessmentScaleTotalRisk_Input
        {
            public TTObjectClasses.NursingWoundAssessmentScale nursingWoundAssessmentScale { get; set; }
            public TTObjectClasses.Patient patient { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public int? CalcNursingWoundAssessmentScaleTotalRisk(CalcNursingWoundAssessmentScaleTotalRisk_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.nursingWoundAssessmentScale != null)
                    input.nursingWoundAssessmentScale = (TTObjectClasses.NursingWoundAssessmentScale)objectContext.AddObject(input.nursingWoundAssessmentScale);
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                var ret = NursingWoundAssessmentScale.CalcNursingWoundAssessmentScaleTotalRisk(input.nursingWoundAssessmentScale, input.patient);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}