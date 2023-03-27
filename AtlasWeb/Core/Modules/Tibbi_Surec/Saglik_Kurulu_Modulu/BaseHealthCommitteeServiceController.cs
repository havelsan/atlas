//$7E9A378C
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
    public partial class BaseHealthCommitteeServiceController : Controller
    {
        public class AddRequesterHospitalsUnitsForBaseHealthCommittee_Input
        {
            public TTObjectClasses.BaseHealthCommittee baseHealthCommittee
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public void AddRequesterHospitalsUnitsForBaseHealthCommittee(AddRequesterHospitalsUnitsForBaseHealthCommittee_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.baseHealthCommittee != null)
                    input.baseHealthCommittee = (TTObjectClasses.BaseHealthCommittee)objectContext.AddObject(input.baseHealthCommittee);
                BaseHealthCommittee.AddRequesterHospitalsUnitsForBaseHealthCommittee(input.baseHealthCommittee);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
    }
}