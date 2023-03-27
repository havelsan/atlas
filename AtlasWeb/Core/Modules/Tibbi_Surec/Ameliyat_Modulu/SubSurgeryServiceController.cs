//$3B63DFD0
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
    public partial class SubSurgeryServiceController : Controller
    {
        public class SubSurgeryReportNQL_Input
        {
            public string SUBSURGERY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubSurgery.SubSurgeryReportNQL_Class> SubSurgeryReportNQL(SubSurgeryReportNQL_Input input)
        {
            var ret = SubSurgery.SubSurgeryReportNQL(input.SUBSURGERY);
            return ret;
        }

        public class SubSurgeryReportBySurgeryNQL_Input
        {
            public string SURGERY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubSurgery.SubSurgeryReportBySurgeryNQL_Class> SubSurgeryReportBySurgeryNQL(SubSurgeryReportBySurgeryNQL_Input input)
        {
            var ret = SubSurgery.SubSurgeryReportBySurgeryNQL(input.SURGERY);
            return ret;
        }

        public class GetByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SubSurgery> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubSurgery.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}