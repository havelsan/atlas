//$7A9B496E
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using Core.Modules.Tibbi_Surec.Tetkik_Istem_Modulu;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class PatientExaminationServiceController : Controller
    {
        //public class Serialize_Input
        //{
        //    public T item { get; set; }
        //}
        //[HttpPost]
        //public string Serialize([ModelBinder(typeof(NebulaModelBinder))]Serialize_Input input)
        //{
        //    var ret = PatientExamination.Serialize(input.item);
        //    return ret;
        //}
        //public class Deserialize_Input
        //{
        //    public string xmlString { get; set; }
        //}
        //[HttpPost]
        //public T Deserialize([ModelBinder(typeof(NebulaModelBinder))]Deserialize_Input input)
        //{
        //    var ret = PatientExamination.Deserialize(input.xmlString);
        //    return ret;
        //}
        [HttpGet]
        public NewTreatmentMaterialInfo GetTreatmentMaterialInfo([FromQuery] Guid materialObjectId)
        {
            //, ResSection MasterResource
            TTObjectContext objContext = new TTObjectContext(true);
            Material material = (Material)objContext.GetObject(materialObjectId, "Material");
            NewTreatmentMaterialInfo treatmentMaterialInfo = new NewTreatmentMaterialInfo();
            treatmentMaterialInfo.Material = material;
            treatmentMaterialInfo.Barcode = material.Barcode;
            treatmentMaterialInfo.ActionDate = Common.RecTime();
            treatmentMaterialInfo.Amount = 1;
            treatmentMaterialInfo.StockCard = material.StockCard;
            treatmentMaterialInfo.DistributionTypeDef = material.StockCard.DistributionType;
            treatmentMaterialInfo.DistributionType = material.StockCard.DistributionType.DistributionType;
            return treatmentMaterialInfo;
        }

        public class OLAP_GetPatientExamination_Input
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
        public BindingList<PatientExamination.OLAP_GetPatientExamination_Class> OLAP_GetPatientExamination(OLAP_GetPatientExamination_Input input)
        {
            var ret = PatientExamination.OLAP_GetPatientExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetPatientExaminationByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> GetPatientExaminationByEpisode(GetPatientExaminationByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetPatientExaminationByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientExaminationNQL_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination.GetPatientExaminationNQL_Class> GetPatientExaminationNQL(GetPatientExaminationNQL_Input input)
        {
            var ret = PatientExamination.GetPatientExaminationNQL(input.OBJECTID);
            return ret;
        }

        public class OLAP_GetCancelledPatientExamination_Input
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
        public BindingList<PatientExamination.OLAP_GetCancelledPatientExamination_Class> OLAP_GetCancelledPatientExamination(OLAP_GetCancelledPatientExamination_Input input)
        {
            var ret = PatientExamination.OLAP_GetCancelledPatientExamination(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        [HttpPost]
        public BindingList<PatientExamination> GetUnCompletedExaminationForClosedEpisode()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetUnCompletedExaminationForClosedEpisode(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientExaminationByResponsibleDoctor_Input
        {
            public string PROCEDUREDOCTOR
            {
                get;
                set;
            }

            public DateTime CURRENTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> GetPatientExaminationByResponsibleDoctor(GetPatientExaminationByResponsibleDoctor_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetPatientExaminationByResponsibleDoctor(objectContext, input.PROCEDUREDOCTOR, input.CURRENTDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientAbsentNQL_Input
        {
            public DateTime TARIH
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
        public BindingList<PatientExamination.GetPatientAbsentNQL_Class> GetPatientAbsentNQL(GetPatientAbsentNQL_Input input)
        {
            var ret = PatientExamination.GetPatientAbsentNQL(input.TARIH, input.MASTERRESOURCE);
            return ret;
        }

        public class GetPatientExaminationByMasterResource_Input
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
        public BindingList<PatientExamination.GetPatientExaminationByMasterResource_Class> GetPatientExaminationByMasterResource(GetPatientExaminationByMasterResource_Input input)
        {
            var ret = PatientExamination.GetPatientExaminationByMasterResource(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        public class InactiveExaminationsNQL_Input
        {
            public DateTime TARIH
            {
                get;
                set;
            }

            public Guid STATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> InactiveExaminationsNQL(InactiveExaminationsNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.InactiveExaminationsNQL(objectContext, input.TARIH, input.STATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientExamiationsForBeatenAndAlcohol_Input
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
        public BindingList<PatientExamination.GetPatientExamiationsForBeatenAndAlcohol_Class> GetPatientExamiationsForBeatenAndAlcohol(GetPatientExamiationsForBeatenAndAlcohol_Input input)
        {
            var ret = PatientExamination.GetPatientExamiationsForBeatenAndAlcohol(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetPEByPatientAndAdmissionResource_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public string ADMISSIONRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> GetPEByPatientAndAdmissionResource(GetPEByPatientAndAdmissionResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetPEByPatientAndAdmissionResource(objectContext, input.PATIENT, input.ADMISSIONRESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientExaminationByObjectIDs_Input
        {
            public Guid OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination.GetPatientExaminationByObjectIDs_Class> GetPatientExaminationByObjectIDs(GetPatientExaminationByObjectIDs_Input input)
        {
            var ret = PatientExamination.GetPatientExaminationByObjectIDs(input.OBJECTIDS);
            return ret;
        }

        public class GetPANoDiagnose_Input
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
        public BindingList<PatientExamination.GetPANoDiagnose_Class> GetPANoDiagnose(GetPANoDiagnose_Input input)
        {
            var ret = PatientExamination.GetPANoDiagnose(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetPEByPatientAndMainSpecialty_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }

            public Guid MAINSPECIALITY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> GetPEByPatientAndMainSpecialty(GetPEByPatientAndMainSpecialty_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetPEByPatientAndMainSpecialty(objectContext, input.PATIENT, input.MAINSPECIALITY);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDailyOpenPatientExaminations_Input
        {
            public DateTime DATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PatientExamination> GetDailyOpenPatientExaminations(GetDailyOpenPatientExaminations_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PatientExamination.GetDailyOpenPatientExaminations(objectContext, input.DATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDoctorsWorkListReportNQL_Input
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
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PatientExamination.GetDoctorsWorkListReportNQL_Class> GetDoctorsWorkListReportNQL(GetDoctorsWorkListReportNQL_Input input)
        {
            var ret = PatientExamination.GetDoctorsWorkListReportNQL(input.STARTDATE, input.ENDDATE, input.MINDATE, input.injectionSQL);
            return ret;
        }
        //[HttpPost]
        //public void CreateActionForMyProcedureRequests([ModelBinder(typeof(NebulaModelBinder))]EpisodeActionRequestedProcedureInfo eaRequestedProcedureInfo)
        //{
        //    var objectContext = new TTObjectContext(false);
        //    var ea = (EpisodeAction)objectContext.AddObject(eaRequestedProcedureInfo.EpisodeAction);
        //    List<ProcedureRequestFormDetailDefinition> requestedProcedures = new List<ProcedureRequestFormDetailDefinition>();
        //    foreach (Guid detailId in eaRequestedProcedureInfo.ProcedureRequestFormDetailDefinitionIDs)
        //    {
        //        ProcedureRequestFormDetailDefinition procReqFormDet = (ProcedureRequestFormDetailDefinition)objectContext.GetObject(detailId, "ProcedureRequestFormDetailDefinition");
        //        requestedProcedures.Add(procReqFormDet);
        //    }
        //    List<ProcedureDefinition> requestedAdditionalApplications = new List<ProcedureDefinition>();
        //    foreach (Guid detailId in eaRequestedProcedureInfo.ProcedureRequestAdditionalApplicationIDs)
        //    {
        //        ProcedureDefinition addAppDef = (ProcedureDefinition)objectContext.GetObject(detailId, "ProcedureDefinition");
        //        requestedAdditionalApplications.Add(addAppDef);
        //    }
        //    //ea.ProcessMyProcedureRequests(requestedProcedures, requestedAdditionalApplications);
        //    objectContext.Save();
        //}


        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool CheckPatientSubEpisodeDiagnosisExistence(SubEpisodeDiagnosisExistence input)
        {
            TTObjectContext context = new TTObjectContext(true);

            SubEpisode subEpisode = (SubEpisode)context.GetObject(input.SubEpisodeID, typeof(SubEpisode));
            return subEpisode.IsDiagnosisExists();
        }

        public class SubEpisodeDiagnosisExistence
        {
            public Guid SubEpisodeID
            {
                get;
                set;
            }

        }


    }
}