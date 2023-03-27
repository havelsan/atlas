//$8B4F13B8
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
    public partial class SurgeryServiceController : Controller
    {
        public class GetSUTPointByProcedureObjectId_Input
        {
            public System.Guid procedureObjId
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double GetSUTPointByProcedureObjectId(GetSUTPointByProcedureObjectId_Input input)
        {
            var ret = Surgery.GetSUTPointByProcedureObjectId(input.procedureObjId);
            return ret;
        }

        public class OLAP_GetSurgeryByDate_Input
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
        public BindingList<Surgery.OLAP_GetSurgeryByDate_Class> OLAP_GetSurgeryByDate(OLAP_GetSurgeryByDate_Input input)
        {
            var ret = Surgery.OLAP_GetSurgeryByDate(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetSurgery10Day_Input
        {
            public string EID
            {
                get;
                set;
            }

            public DateTime DEATHTIME
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Surgery.OLAP_GetSurgery10Day_Class> OLAP_GetSurgery10Day(OLAP_GetSurgery10Day_Input input)
        {
            var ret = Surgery.OLAP_GetSurgery10Day(input.EID, input.DEATHTIME);
            return ret;
        }

        public class SurgeryReportNQL_Input
        {
            public string SURGERY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Surgery.SurgeryReportNQL_Class> SurgeryReportNQL(SurgeryReportNQL_Input input)
        {
            var ret = Surgery.SurgeryReportNQL(input.SURGERY);
            return ret;
        }

        public class SurgeryPatientByDateNQL_Input
        {
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

            public Guid SURGERYROOM
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Surgery.SurgeryPatientByDateNQL_Class> SurgeryPatientByDateNQL(SurgeryPatientByDateNQL_Input input)
        {
            var ret = Surgery.SurgeryPatientByDateNQL(input.STARTDATE, input.ENDDATE, input.SURGERYROOM);
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
        public BindingList<Surgery> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Surgery.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DirectPurchaseExpenditureInfoNQL_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Surgery.DirectPurchaseExpenditureInfoNQL_Class> DirectPurchaseExpenditureInfoNQL(DirectPurchaseExpenditureInfoNQL_Input input)
        {
            var ret = Surgery.DirectPurchaseExpenditureInfoNQL(input.OBJECTID);
            return ret;
        }

        public class SurgeryCountQuery_Input
        {
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
        public BindingList<Surgery.SurgeryCountQuery_Class> SurgeryCountQuery(SurgeryCountQuery_Input input)
        {
            var ret = Surgery.SurgeryCountQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class InCompleteSurgeryPatientListNQL_Input
        {
            public DateTime ENDDATE
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Surgery.InCompleteSurgeryPatientListNQL_Class> InCompleteSurgeryPatientListNQL(InCompleteSurgeryPatientListNQL_Input input)
        {
            var ret = Surgery.InCompleteSurgeryPatientListNQL(input.ENDDATE, input.STARTDATE);
            return ret;
        }
    }
}