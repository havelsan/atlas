//$6B286AA4
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
    public partial class SurgeryProcedureServiceController : Controller
    {
        public class GetSurgeryProceduresByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SurgeryProcedure.GetSurgeryProceduresByEpisode_Class> GetSurgeryProceduresByEpisode(GetSurgeryProceduresByEpisode_Input input)
        {
            var ret = SurgeryProcedure.GetSurgeryProceduresByEpisode(input.EPISODE);
            return ret;
        }

        public class GetSurgeryProceduresBySubEpisode_Input
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
        public BindingList<SurgeryProcedure.GetSurgeryProceduresBySubEpisode_Class> GetSurgeryProceduresBySubEpisode(GetSurgeryProceduresBySubEpisode_Input input)
        {
            var ret = SurgeryProcedure.GetSurgeryProceduresBySubEpisode(input.SUBEPISODE, input.EPISODE);
            return ret;
        }

        public class OLAP_GetCancelledSurgeryProcedure_Input
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
        public BindingList<SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure_Class> OLAP_GetCancelledSurgeryProcedure(OLAP_GetCancelledSurgeryProcedure_Input input)
        {
            var ret = SurgeryProcedure.OLAP_GetCancelledSurgeryProcedure(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetSurgeryProcedures_Input
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
        public BindingList<SurgeryProcedure.OLAP_GetSurgeryProcedures_Class> OLAP_GetSurgeryProcedures(OLAP_GetSurgeryProcedures_Input input)
        {
            var ret = SurgeryProcedure.OLAP_GetSurgeryProcedures(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetSurgeryCountByPatient_Input
        {
            public string SURGERYPROID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SurgeryProcedure.OLAP_GetSurgeryCountByPatient_Class> OLAP_GetSurgeryCountByPatient(OLAP_GetSurgeryCountByPatient_Input input)
        {
            var ret = SurgeryProcedure.OLAP_GetSurgeryCountByPatient(input.SURGERYPROID);
            return ret;
        }

        public class OLAP_GetSurgeryCountBySUTCode_Input
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
        public BindingList<SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode_Class> OLAP_GetSurgeryCountBySUTCode(OLAP_GetSurgeryCountBySUTCode_Input input)
        {
            var ret = SurgeryProcedure.OLAP_GetSurgeryCountBySUTCode(input.ENDDATE, input.STARTDATE);
            return ret;
        }

        public class OLAP_Ameliyat_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SurgeryProcedure.OLAP_Ameliyat_Class> OLAP_Ameliyat(OLAP_Ameliyat_Input input)
        {
            var ret = SurgeryProcedure.OLAP_Ameliyat(input.DATE);
            return ret;
        }

        public class GetSurgeryPersonnelBySurgery_Input
        {
            public string SURGERY
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SurgeryProcedure.GetSurgeryPersonnelBySurgery_Class> GetSurgeryPersonnelBySurgery(GetSurgeryPersonnelBySurgery_Input input)
        {
            var ret = SurgeryProcedure.GetSurgeryPersonnelBySurgery(input.SURGERY);
            return ret;
        }
    }
}