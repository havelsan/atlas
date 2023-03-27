//$FC4EB3E1
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
    public partial class TreatmentDischargeServiceController : Controller
    {
        public class TreatmentDischargeReport_Input
        {
            public string TREATMENTDISCHARGE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<TreatmentDischarge.TreatmentDischargeReport_Class> TreatmentDischargeReport(TreatmentDischargeReport_Input input)
        {
            var ret = TreatmentDischarge.TreatmentDischargeReport(input.TREATMENTDISCHARGE);
            return ret;
        }

        public class OLAP_GetTreatmentDischarge_Input
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
        public BindingList<TreatmentDischarge.OLAP_GetTreatmentDischarge_Class> OLAP_GetTreatmentDischarge(OLAP_GetTreatmentDischarge_Input input)
        {
            var ret = TreatmentDischarge.OLAP_GetTreatmentDischarge(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetTreatmentDischargeByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<TreatmentDischarge> GetTreatmentDischargeByEpisode(GetTreatmentDischargeByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = TreatmentDischarge.GetTreatmentDischargeByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<TreatmentDischarge.OLAP_Sevk_Class> OLAP_Sevk()
        {
            var ret = TreatmentDischarge.OLAP_Sevk();
            return ret;
        }

        public class GetTreatmentDischargeBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<TreatmentDischarge> GetTreatmentDischargeBySubEpisode(GetTreatmentDischargeBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = TreatmentDischarge.GetTreatmentDischargeBySubEpisode(objectContext, input.SUBEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPreDischargedInfoByProcedureDoctor_Input
        {
            public Guid PROCEDUREDOCTOR
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor_Class> GetPreDischargedInfoByProcedureDoctor(GetPreDischargedInfoByProcedureDoctor_Input input)
        {
            var ret = TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor(input.PROCEDUREDOCTOR);
            return ret;
        }

        public class GetPreDischargedInfoByClinic_Input
        {
            public Guid CLINIC
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<TreatmentDischarge.GetPreDischargedInfoByClinic_Class> GetPreDischargedInfoByClinic(GetPreDischargedInfoByClinic_Input input)
        {
            var ret = TreatmentDischarge.GetPreDischargedInfoByClinic(input.CLINIC);
            return ret;
        }
    }
}