//$052D82DE
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
    public partial class BaseDentalEpisodeActionDiagnosisGridServiceController : Controller
    {
        public class GetByExternalIDNQL_Input
        {
            public string EXTERNALID
            {
                get;
                set;
            }

            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<BaseDentalEpisodeActionDiagnosisGrid> GetByExternalIDNQL(GetByExternalIDNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseDentalEpisodeActionDiagnosisGrid.GetByExternalIDNQL(objectContext, input.EXTERNALID, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}