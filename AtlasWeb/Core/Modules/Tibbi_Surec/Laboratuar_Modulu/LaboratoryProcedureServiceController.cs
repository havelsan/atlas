//$E60E90CE
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
    public partial class LaboratoryProcedureServiceController : Controller
    {
        public class MicrobiologyTestOrder_Input
        {
            public TTObjectClasses.LaboratoryProcedure.MicrobiologyTestOrderInfo testOrderInfo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void MicrobiologyTestOrder(MicrobiologyTestOrder_Input input)
        {
            LaboratoryProcedure.MicrobiologyTestOrder(input.testOrderInfo);
        }

        public class CompleteLaboratoryRequest_Input
        {
            public System.Guid episodeActionID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CompleteLaboratoryRequest(CompleteLaboratoryRequest_Input input)
        {
            LaboratoryProcedure.CompleteLaboratoryRequest(input.episodeActionID);
        }

        public class UpdateEpisodeStateToOpen_Input
        {
            public System.Guid episodeActionID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void UpdateEpisodeStateToOpen(UpdateEpisodeStateToOpen_Input input)
        {
            LaboratoryProcedure.UpdateEpisodeStateToOpen(input.episodeActionID);
        }

        public class UpdateEpisodeToOldState_Input
        {
            public System.Guid episodeActionID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void UpdateEpisodeToOldState(UpdateEpisodeToOldState_Input input)
        {
            LaboratoryProcedure.UpdateEpisodeToOldState(input.episodeActionID);
        }

        public class SaveLabResult_Input
        {
            public TTObjectClasses.LaboratoryProcedure.LabResultInfo labResult
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveLabResult(SaveLabResult_Input input)
        {
            LaboratoryProcedure.SaveLabResult(input.labResult);
        }

        public class SaveLabState_Input
        {
            public TTObjectClasses.LaboratoryProcedure.LabStateInfo labState
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SaveLabState(SaveLabState_Input input)
        {
            LaboratoryProcedure.SaveLabState(input.labState);
        }

        public class GetLabTestsByPatientByDate_Input
        {
            public string PATIENTID
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
        public BindingList<LaboratoryProcedure> GetLabTestsByPatientByDate(GetLabTestsByPatientByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabTestsByPatientByDate(objectContext, input.PATIENTID, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetLabProcedure_Input
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
        public BindingList<LaboratoryProcedure.OLAP_GetLabProcedure_Class> OLAP_GetLabProcedure(OLAP_GetLabProcedure_Input input)
        {
            var ret = LaboratoryProcedure.OLAP_GetLabProcedure(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetLabTestByPatient_Input
        {
            public string PATIENTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure> GetLabTestByPatient(GetLabTestByPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabTestByPatient(objectContext, input.PATIENTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLabTestByPatientByTestByDate_Input
        {
            public string PATIENTID
            {
                get;
                set;
            }

            public string TESTID
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
        public BindingList<LaboratoryProcedure> GetLabTestByPatientByTestByDate(GetLabTestByPatientByTestByDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabTestByPatientByTestByDate(objectContext, input.PATIENTID, input.TESTID, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class LaboratoryProcedureReportNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.LaboratoryProcedureReportNQL_Class> LaboratoryProcedureReportNQL(LaboratoryProcedureReportNQL_Input input)
        {
            var ret = LaboratoryProcedure.LaboratoryProcedureReportNQL(input.PARAMOBJID);
            return ret;
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure> GetLaboratoryProcedureForLaboratoryAccept()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLaboratoryProcedureForLaboratoryAccept(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLabProcedureByBarcodeId_Input
        {
            public long BARCODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class> GetLabProcedureByBarcodeId(GetLabProcedureByBarcodeId_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByBarcodeId(input.BARCODEID);
            return ret;
        }

        public class GetLabResults_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure> GetLabResults(GetLabResults_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabResults(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetCancelledLabProcedure_Input
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
        public BindingList<LaboratoryProcedure.OLAP_GetCancelledLabProcedure_Class> OLAP_GetCancelledLabProcedure(OLAP_GetCancelledLabProcedure_Input input)
        {
            var ret = LaboratoryProcedure.OLAP_GetCancelledLabProcedure(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetLaboratoryResultsBySubepisodeId_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId_Class> GetLaboratoryResultsBySubepisodeId(GetLaboratoryResultsBySubepisodeId_Input input)
        {
            var ret = LaboratoryProcedure.GetLaboratoryResultsBySubepisodeId(input.SUBEPISODE);
            return ret;
        }

        public class GetLaboratoryProcedureByEpisode_Input
        {
            public Guid EPISODE
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
        public BindingList<LaboratoryProcedure.GetLaboratoryProcedureByEpisode_Class> GetLaboratoryProcedureByEpisode(GetLaboratoryProcedureByEpisode_Input input)
        {
            var ret = LaboratoryProcedure.GetLaboratoryProcedureByEpisode(input.EPISODE, input.injectionSQL);
            return ret;
        }

        public class GetLabProcByPatientByTestByDate_Input
        {
            public string PATIENTID
            {
                get;
                set;
            }

            public string TESTID
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

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class> GetLabProcByPatientByTestByDate(GetLabProcByPatientByTestByDate_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcByPatientByTestByDate(input.PATIENTID, input.TESTID, input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }

        public class GetLabProceduresBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }

            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure> GetLabProceduresBySubEpisode(GetLabProceduresBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabProceduresBySubEpisode(objectContext, input.SUBEPISODE, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLaboratoryProcedureBySubEpisode_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode_Class> GetLaboratoryProcedureBySubEpisode(GetLaboratoryProcedureBySubEpisode_Input input)
        {
            var ret = LaboratoryProcedure.GetLaboratoryProcedureBySubEpisode(input.SUBEPISODE);
            return ret;
        }

        public class GetLabProcedureByTestAndRequest_Input
        {
            public Guid PARAMOBJID
            {
                get;
                set;
            }

            public Guid TEST
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> GetLabProcedureByTestAndRequest(GetLabProcedureByTestAndRequest_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByTestAndRequest(input.PARAMOBJID, input.TEST);
            return ret;
        }

        public class GetLabProceduresByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure> GetLabProceduresByEpisode(GetLabProceduresByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabProceduresByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLabProcedureByTabAndRequest_Input
        {
            public Guid PARAMOBJID
            {
                get;
                set;
            }

            public Guid TAB
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class> GetLabProcedureByTabAndRequest(GetLabProcedureByTabAndRequest_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByTabAndRequest(input.PARAMOBJID, input.TAB);
            return ret;
        }

        public class GetRejectedLaboratoryProceduresByDate_Input
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
        public BindingList<LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate_Class> GetRejectedLaboratoryProceduresByDate(GetRejectedLaboratoryProceduresByDate_Input input)
        {
            var ret = LaboratoryProcedure.GetRejectedLaboratoryProceduresByDate(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetLabProcedureByFilter_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcedureByFilter_Class> GetLabProcedureByFilter(GetLabProcedureByFilter_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByFilter(input.injectionSQL);
            return ret;
        }

        public class GetLabTestsByPatientForGraph_Input
        {
            public Guid PATIENT
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
        public BindingList<LaboratoryProcedure> GetLabTestsByPatientForGraph(GetLabTestsByPatientForGraph_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = LaboratoryProcedure.GetLabTestsByPatientForGraph(objectContext, input.PATIENT, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOnlyApprovedProcedures_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetOnlyApprovedProcedures_Class> GetOnlyApprovedProcedures(GetOnlyApprovedProcedures_Input input)
        {
            var ret = LaboratoryProcedure.GetOnlyApprovedProcedures(input.PARAMOBJID);
            return ret;
        }

        public class GetLabProcedureByRequestTab_Input
        {
            public Guid REQUESTTAB
            {
                get;
                set;
            }

            public Guid PATIENT
            {
                get;
                set;
            }

            public DateTime WORKLISTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<LaboratoryProcedure.GetLabProcedureByRequestTab_Class> GetLabProcedureByRequestTab(GetLabProcedureByRequestTab_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByRequestTab(input.REQUESTTAB, input.PATIENT, input.WORKLISTDATE);
            return ret;
        }

        public class GetLabProcedureByWorklistDate_Input
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

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<LaboratoryProcedure.GetLabProcedureByWorklistDate_Class> GetLabProcedureByWorklistDate(GetLabProcedureByWorklistDate_Input input)
        {
            var ret = LaboratoryProcedure.GetLabProcedureByWorklistDate(input.STARTDATE, input.ENDDATE, input.injectionSQL);
            return ret;
        }
    }
}