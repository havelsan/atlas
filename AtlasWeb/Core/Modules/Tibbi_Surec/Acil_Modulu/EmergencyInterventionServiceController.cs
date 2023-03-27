//$4983452D
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
    public partial class EmergencyInterventionServiceController : Controller
    {
        public class GetByEpisode_Input
        {
            public string PARAMEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EmergencyIntervention> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EmergencyIntervention.GetByEpisode(objectContext, input.PARAMEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetEmergencyObservation_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EmergencyIntervention.OLAP_GetEmergencyObservation_Class> OLAP_GetEmergencyObservation(OLAP_GetEmergencyObservation_Input input)
        {
            var ret = EmergencyIntervention.OLAP_GetEmergencyObservation(input.EPISODE);
            return ret;
        }

        public class GetByEpisodeInfo_Input
        {
            public string PARAMEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EmergencyIntervention.GetByEpisodeInfo_Class> GetByEpisodeInfo(GetByEpisodeInfo_Input input)
        {
            var ret = EmergencyIntervention.GetByEpisodeInfo(input.PARAMEPISODE);
            return ret;
        }

        public class GetEmergencyInterventionsByDate_Input
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
        public BindingList<EmergencyIntervention> GetEmergencyInterventionsByDate(GetEmergencyInterventionsByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EmergencyIntervention.GetEmergencyInterventionsByDate(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEpisodeAndPatientInfoAccordingToDiagnosis_Input
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

            public IList<string> DIAGNOSIS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis_Class> GetEpisodeAndPatientInfoAccordingToDiagnosis(GetEpisodeAndPatientInfoAccordingToDiagnosis_Input input)
        {
            var ret = EmergencyIntervention.GetEpisodeAndPatientInfoAccordingToDiagnosis(input.STARTDATE, input.ENDDATE, input.DIAGNOSIS);
            return ret;
        }

        public class GetEpisodeAndPatientInfo_Input
        {
            public string PARAMEPISPODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<EmergencyIntervention.GetEpisodeAndPatientInfo_Class> GetEpisodeAndPatientInfo(GetEpisodeAndPatientInfo_Input input)
        {
            var ret = EmergencyIntervention.GetEpisodeAndPatientInfo(input.PARAMEPISPODE);
            return ret;
        }

        public class GetEmergencyInterventionsByDateForReport_Input
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
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<EmergencyIntervention.GetEmergencyInterventionsByDateForReport_Class> GetEmergencyInterventionsByDateForReport(GetEmergencyInterventionsByDateForReport_Input input)
        {
            var ret = EmergencyIntervention.GetEmergencyInterventionsByDateForReport(input.STARTDATE, input.ENDDATE);
            return ret;
        }
    }
}