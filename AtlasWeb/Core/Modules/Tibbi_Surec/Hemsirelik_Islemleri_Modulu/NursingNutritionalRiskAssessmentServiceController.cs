//$BD518D5E
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
    public partial class NursingNutritionalRiskAssessmentServiceController : Controller
    {
        public class CalcNursingWoundAssessmentScaleTotalRisk_Input
        {
            public TTObjectClasses.NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment { get; set; }
            public TTObjectClasses.Patient patient { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public int? CalcNursingWoundAssessmentScaleTotalRisk(CalcNursingWoundAssessmentScaleTotalRisk_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.nursingNutritionalRiskAssessment != null)
                    input.nursingNutritionalRiskAssessment = (TTObjectClasses.NursingNutritionalRiskAssessment)objectContext.AddObject(input.nursingNutritionalRiskAssessment);
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                var ret = NursingNutritionalRiskAssessment.CalcNursingWoundAssessmentScaleTotalRisk(input.nursingNutritionalRiskAssessment, input.patient);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}