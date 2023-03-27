//$BC43538A
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
    public partial class NursingNutritionAssessmentServiceController : Controller
    {
        public class CalcNursingWoundAssessmentScaleTotalRisk_Input
        {
            public TTObjectClasses.NursingWoundAssessmentScale nursingWoundAssessmentScale
            {
                get;
                set;
            }
            public Patient Patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public int? CalcNursingWoundAssessmentScaleTotalRisk(CalcNursingWoundAssessmentScaleTotalRisk_Input input)
        {
            
            using (var objectContext = new TTObjectContext(false))
            {
                int? totalRisk = 0;
                if (input.Patient != null)
                    input.Patient = objectContext.GetObject<Patient>(input.Patient.ObjectID);

                if (input.nursingWoundAssessmentScale != null)
                    input.nursingWoundAssessmentScale = (TTObjectClasses.NursingWoundAssessmentScale)objectContext.AddObject(input.nursingWoundAssessmentScale);
                input.nursingWoundAssessmentScale.TotalRisk = NursingWoundAssessmentScale.CalcNursingWoundAssessmentScaleTotalRisk(input.nursingWoundAssessmentScale, input.Patient);
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                return totalRisk;
            }
        }
    }
}