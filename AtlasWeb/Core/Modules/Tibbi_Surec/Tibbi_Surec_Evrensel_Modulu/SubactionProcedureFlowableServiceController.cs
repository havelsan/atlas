//$E83DCBE7
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
    public partial class SubactionProcedureFlowableServiceController : Controller
    {
        public class SetMandatorySubactionProcedureFlowableProperties_Input
        {
            public TTObjectClasses.EpisodeAction episodeAction
            {
                get;
                set;
            }

            public TTObjectClasses.ResSection masterResource
            {
                get;
                set;
            }

            public TTObjectClasses.ResSection fromResource
            {
                get;
                set;
            }

            public TTObjectClasses.SubactionProcedureFlowable subactionProcedureFlowable
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SetMandatorySubactionProcedureFlowableProperties(SetMandatorySubactionProcedureFlowableProperties_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episodeAction != null)
                    input.episodeAction = (TTObjectClasses.EpisodeAction)objectContext.AddObject(input.episodeAction);
                if (input.masterResource != null)
                    input.masterResource = (TTObjectClasses.ResSection)objectContext.AddObject(input.masterResource);
                if (input.fromResource != null)
                    input.fromResource = (TTObjectClasses.ResSection)objectContext.AddObject(input.fromResource);
                if (input.subactionProcedureFlowable != null)
                    input.subactionProcedureFlowable = (TTObjectClasses.SubactionProcedureFlowable)objectContext.AddObject(input.subactionProcedureFlowable);
                SubactionProcedureFlowable.SetMandatorySubactionProcedureFlowableProperties(input.episodeAction, input.masterResource, input.fromResource, input.subactionProcedureFlowable);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class CheckPaid_Input
        {
            public TTObjectClasses.SubactionProcedureFlowable subactionProcedureFlowable
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CheckPaid(CheckPaid_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subactionProcedureFlowable != null)
                    input.subactionProcedureFlowable = (TTObjectClasses.SubactionProcedureFlowable)objectContext.AddObject(input.subactionProcedureFlowable);
                SubactionProcedureFlowable.CheckPaid(input.subactionProcedureFlowable);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class IsPaid_Input
        {
            public System.Guid subActProcFlowID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsPaid(IsPaid_Input input)
        {
            var ret = SubactionProcedureFlowable.IsPaid(input.subActProcFlowID);
            return ret;
        }

        public class AllowedToCancel_Input
        {
            public System.Guid subActProcFlowID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool AllowedToCancel(AllowedToCancel_Input input)
        {
            var ret = SubactionProcedureFlowable.AllowedToCancel(input.subActProcFlowID);
            return ret;
        }

        public class GetSpecialResourceForStore_Input
        {
            public TTObjectClasses.SubactionProcedureFlowable subactionProcedureFlowable
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Resource GetSpecialResourceForStore(GetSpecialResourceForStore_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.subactionProcedureFlowable != null)
                    input.subactionProcedureFlowable = (TTObjectClasses.SubactionProcedureFlowable)objectContext.AddObject(input.subactionProcedureFlowable);
                var ret = SubactionProcedureFlowable.GetSpecialResourceForStore(input.subactionProcedureFlowable);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProcOfPatient_Input
        {
            public string PATIENTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfPatient(GetAllConsultationProcOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetAllConsultationProcOfPatient(objectContext, input.PATIENTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByWorklistDate_Input
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

            public DateTime MINDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetByWorklistDate(GetByWorklistDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetByWorklistDate(objectContext, input.STARTDATE, input.ENDDATE, input.MINDATE, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllConsultationProcOfSubEpisode_Input
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
        public BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfSubEpisode(GetAllConsultationProcOfSubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetAllConsultationProcOfSubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSubactionProceduresByEpisodeAction_Input
        {
            public string EPISODEACTION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetSubactionProceduresByEpisodeAction(GetSubactionProceduresByEpisodeAction_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetSubactionProceduresByEpisodeAction(objectContext, input.EPISODEACTION);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetUncompletedSPFsByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetUncompletedSPFsByEpisode_Class> GetUncompletedSPFsByEpisode(GetUncompletedSPFsByEpisode_Input input)
        {
            var ret = SubactionProcedureFlowable.GetUncompletedSPFsByEpisode(input.EPISODE);
            return ret;
        }

        public class GetAllConsultationProceduresOfPatient_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetAllConsultationProceduresOfPatient(GetAllConsultationProceduresOfPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetAllConsultationProceduresOfPatient(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByFilterExpression_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetByFilterExpression(GetByFilterExpression_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetByFilterExpression(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBySPFWorklistDateReport_Input
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

            public DateTime MINDATE
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetBySPFWorklistDateReport_Class> GetBySPFWorklistDateReport(GetBySPFWorklistDateReport_Input input)
        {
            var ret = SubactionProcedureFlowable.GetBySPFWorklistDateReport(input.STARTDATE, input.ENDDATE, input.MINDATE, input.injectionSQL);
            return ret;
        }

        public class GetBySPFFilterExpressionReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetBySPFFilterExpressionReport_Class> GetBySPFFilterExpressionReport(GetBySPFFilterExpressionReport_Input input)
        {
            var ret = SubactionProcedureFlowable.GetBySPFFilterExpressionReport(input.injectionSQL);
            return ret;
        }

        public class GetSubactionProceduresByObjectIDs_Input
        {
            public IList<string> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class> GetSubactionProceduresByObjectIDs(GetSubactionProceduresByObjectIDs_Input input)
        {
            var ret = SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs(input.OBJECTIDS);
            return ret;
        }

        public class GetAllConsultationProcOfEpisode_Input
        {
            public string EPISODEOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable> GetAllConsultationProcOfEpisode(GetAllConsultationProcOfEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubactionProcedureFlowable.GetAllConsultationProcOfEpisode(objectContext, input.EPISODEOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientFolderEpisodeSubactions_Input
        {
            public Guid EPISODEID
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions_Class> GetPatientFolderEpisodeSubactions(GetPatientFolderEpisodeSubactions_Input input)
        {
            var ret = SubactionProcedureFlowable.GetPatientFolderEpisodeSubactions(input.EPISODEID, input.injectionSQL);
            return ret;
        }

        public class GetEndOfDayConsultationPoliclinicReport_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport_Class> GetEndOfDayConsultationPoliclinicReport(GetEndOfDayConsultationPoliclinicReport_Input input)
        {
            var ret = SubactionProcedureFlowable.GetEndOfDayConsultationPoliclinicReport(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        [HttpPost]
        public BindingList<SubactionProcedureFlowable.VEM_TETKIK_ORNEK_Class> VEM_TETKIK_ORNEK()
        {
            var ret = SubactionProcedureFlowable.VEM_TETKIK_ORNEK();
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SubactionProcedureFlowable.VEM_TETKIK_SONUC_Class> VEM_TETKIK_SONUC()
        {
            var ret = SubactionProcedureFlowable.VEM_TETKIK_SONUC();
            return ret;
        }
    }
}