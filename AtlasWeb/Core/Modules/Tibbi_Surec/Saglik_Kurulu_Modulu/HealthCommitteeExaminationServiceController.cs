//$3B79AD51
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
    public partial class HealthCommitteeExaminationServiceController : Controller
    {
        public class GetCurrentHCExamination_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.GetCurrentHCExamination_Class> GetCurrentHCExamination(GetCurrentHCExamination_Input input)
        {
            var ret = HealthCommitteeExamination.GetCurrentHCExamination(input.OBJECTID);
            return ret;
        }

        public class GetHCExamsByMResource_Input
        {
            public IList<string> MRESOURCE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.GetHCExamsByMResource_Class> GetHCExamsByMResource(GetHCExamsByMResource_Input input)
        {
            var ret = HealthCommitteeExamination.GetHCExamsByMResource(input.MRESOURCE, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetHCExaminationByMasterAction_Input
        {
            public string MASTERACTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.GetHCExaminationByMasterAction_Class> GetHCExaminationByMasterAction(GetHCExaminationByMasterAction_Input input)
        {
            var ret = HealthCommitteeExamination.GetHCExaminationByMasterAction(input.MASTERACTIONID);
            return ret;
        }

        public class OLAP_GetHealthCommitteeDetails_Input
        {
            public string EID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails_Class> OLAP_GetHealthCommitteeDetails(OLAP_GetHealthCommitteeDetails_Input input)
        {
            var ret = HealthCommitteeExamination.OLAP_GetHealthCommitteeDetails(input.EID);
            return ret;
        }

        public class OLAP_GetHealthCommitteeExamination_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination_Class> OLAP_GetHealthCommitteeExamination(OLAP_GetHealthCommitteeExamination_Input input)
        {
            var ret = HealthCommitteeExamination.OLAP_GetHealthCommitteeExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetCancelledHealthCommitteeExamination_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination_Class> OLAP_GetCancelledHealthCommitteeExamination(OLAP_GetCancelledHealthCommitteeExamination_Input input)
        {
            var ret = HealthCommitteeExamination.OLAP_GetCancelledHealthCommitteeExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        [HttpPost]
        public BindingList<HealthCommitteeExamination.GetBackHCExaminationByDate_Class> GetBackHCExaminationByDate()
        {
            var ret = HealthCommitteeExamination.GetBackHCExaminationByDate();
            return ret;
        }

        public class GetHCEByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<HealthCommitteeExamination> GetHCEByEpisode(GetHCEByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = HealthCommitteeExamination.GetHCEByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}