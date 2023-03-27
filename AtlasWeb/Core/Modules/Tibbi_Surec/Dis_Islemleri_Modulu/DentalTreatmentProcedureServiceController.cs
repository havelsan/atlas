//$2B2CEA31
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
    public partial class DentalTreatmentProcedureServiceController : Controller
    {
        public class GetUncompletedProceduresByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DentalTreatmentProcedure> GetUncompletedProceduresByEpisode(GetUncompletedProceduresByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DentalTreatmentProcedure.GetUncompletedProceduresByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}