//$50C883FD
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers
{
    public partial class DispatchExaminationServiceController
    {
        partial void PreScript_DispatchExaminationForm(DispatchExaminationFormViewModel viewModel, DispatchExamination dispatchExamination, TTObjectContext objectContext)
        {
            ResUser resuser = Common.CurrentResource;
            List<Guid> sections = new List<Guid>();
            sections.Add(resuser.ObjectID);
            foreach (ResSection res in resuser.SelectedResources)
            {
                sections.Add(res.ObjectID);
            }
            
            viewModel.ProcedureRequestFormResourceIDs = sections;


            if (dispatchExamination.CurrentStateDefID == null)
                dispatchExamination.CurrentStateDefID = DispatchExamination.States.New;

            ContextToViewModel(viewModel, objectContext);

            viewModel.GridDiagnosisGridList = dispatchExamination.DiagnosisGrid_PreScript();
        }
        partial void PostScript_DispatchExaminationForm(DispatchExaminationFormViewModel viewModel, DispatchExamination dispatchExamination, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {

            if (dispatchExamination.CurrentStateDefID == DispatchExamination.States.New)
                dispatchExamination.CurrentStateDefID = DispatchExamination.States.ProcedureRequested;

            dispatchExamination.DiagnosisGrid_PostScript(viewModel.GridDiagnosisGridList);
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Istem_Ekrani_Gorme, TTRoleNames.Istem_Ekrani_Kaydetme, TTRoleNames.Istem_Ekrani_Silme)]
        public void DeleteDispatchExamiantion(DispatchExamination de)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                de = objectContext.GetObject(de.ObjectID, typeof(DispatchExamination)) as DispatchExamination;
                PatientAdmission.DeletePatientAdmission(de.PatientAdmission);
                objectContext.Save();
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Istem_Ekrani_Gorme, TTRoleNames.Istem_Ekrani_Kaydetme, TTRoleNames.Istem_Ekrani_Silme)]
        public List<Guid> ControlExternalPatient(string EpisodeID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<Guid> returnlist = new List<Guid>();

                //Patient p = objectContext.GetObject(new Guid("260e215b-ff39-470a-b18e-11d70b3ccb34"), typeof(Patient)) as Patient;
                Episode e = objectContext.GetObject(new Guid(EpisodeID), typeof(Episode)) as Episode;
                ExternalProviderServiceRequest externalProvider = new ExternalProviderServiceRequest();

                if (e.Patient.UniqueRefNo != null)
                {
                    List<ExternalProviderServiceRequest> serviceRequestsList = ExternalProviderServiceRequest.GetExtProviderByUniqueRefNo(objectContext, e.Patient.UniqueRefNo.Value).ToList<ExternalProviderServiceRequest>();

                    foreach (ExternalProviderServiceRequest serviceRequest in serviceRequestsList)
                    {
                        List<ProcedureRequestFormDetailDefinition> detailDefinitions = ProcedureRequestFormDetailDefinition.GetProcedureRequestFormDetailBySUTCode(objectContext, serviceRequest.ProcedureCode).ToList<ProcedureRequestFormDetailDefinition>();

                        if (detailDefinitions.Count > 0)
                            returnlist.Add(detailDefinitions[0].ObjectID);
                    }

                }
                return returnlist;
            }
        }
    }
}

namespace Core.Models
{
    public partial class DispatchExaminationFormViewModel : BaseViewModel
    {
        public List<Guid> ProcedureRequestFormResourceIDs { get; set; }
        public List<vmProcedureRequestFormDefinition> UserMostUsedFormDefinitions = new List<vmProcedureRequestFormDefinition>();
    }
    public class vmProcedureRequestFormDefinition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<vmProcedureRequestCategoryDefinition> FormCategories = new List<vmProcedureRequestCategoryDefinition>();
    }

    public class vmProcedureRequestCategoryDefinition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<vmProcedureRequestDetailDefinition> FormDetails = new List<vmProcedureRequestDetailDefinition>();
    }

    public class vmProcedureRequestDetailDefinition
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid ProcedureObjectDefID { get; set; }
        public bool Checked { get; set; }
        public bool IsActive { get; set; }
        public string Color { get; set; }
        public bool RequestedLastXDays { get; set; }
    }
}
