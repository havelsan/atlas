//$4825C03A
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
    public partial class PregnancyFollowServiceController : Controller
    {
        public class FillPregnancyCalender_Input
        {
            public System.DateTime lastMenstrualPeriod { get; set; }
            public TTObjectClasses.PregnancyTypeEnum pregnancyType { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public System.ComponentModel.BindingList<TTObjectClasses.PregnancyFollow.PregnancyCalender> FillPregnancyCalender(FillPregnancyCalender_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                var ret = PregnancyFollow.FillPregnancyCalender(context, input.lastMenstrualPeriod, input.pregnancyType);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}