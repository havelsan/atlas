//$1E058FB3
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
    public partial class InPatientPhysicianProgressesServiceController : Controller
    {
        public class GetInpatienPhProgressesBySubEpisode_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }

            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode_Class> GetInpatienPhProgressesBySubEpisode(GetInpatienPhProgressesBySubEpisode_Input input)
        {
            var ret = InPatientPhysicianProgresses.GetInpatienPhProgressesBySubEpisode(input.SUBEPISODE, input.EPISODE);
            return ret;
        }

        public class GetInpatienPhProgressesByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode_Class> GetInpatienPhProgressesByEpisode(GetInpatienPhProgressesByEpisode_Input input)
        {
            var ret = InPatientPhysicianProgresses.GetInpatienPhProgressesByEpisode(input.EPISODE);
            return ret;
        }
    }
}