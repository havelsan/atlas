//$5EA9D4F8
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
    public partial class NursingGlaskowComaScaleServiceController : Controller
    {
        public class CalcGlaskowComaScaleTotalScore_Input
        {
            public TTObjectClasses.NursingGlaskowComaScale nursingGlaskowComaScale
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GlaskowComaScaleScoreEnum? CalcGlaskowComaScaleTotalScore(CalcGlaskowComaScaleTotalScore_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GlaskowComaScaleScoreEnum? _totalScore = new GlaskowComaScaleScoreEnum();
                if (input.nursingGlaskowComaScale != null)
                    input.nursingGlaskowComaScale = (TTObjectClasses.NursingGlaskowComaScale)objectContext.AddObject(input.nursingGlaskowComaScale);
                _totalScore = NursingGlaskowComaScale.CalcGlaskowComaScaleTotalScore(input.nursingGlaskowComaScale);
                objectContext.FullPartialllyLoadedObjects();
                return _totalScore;
            }
        }
    }
}