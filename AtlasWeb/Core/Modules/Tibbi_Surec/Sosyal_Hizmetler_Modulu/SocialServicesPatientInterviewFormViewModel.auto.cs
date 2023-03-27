//$B9459F7E
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class PatientInterviewFormServiceController : Controller
{
    [HttpGet]
    public SocialServicesPatientInterviewFormViewModel SocialServicesPatientInterviewForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SocialServicesPatientInterviewFormLoadInternal(input);
    }

    [HttpPost]
    public SocialServicesPatientInterviewFormViewModel SocialServicesPatientInterviewFormLoad(FormLoadInput input)
    {
        return SocialServicesPatientInterviewFormLoadInternal(input);
    }

    private SocialServicesPatientInterviewFormViewModel SocialServicesPatientInterviewFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9089c2aa-ad45-4f6a-a869-18d2be85ac49");
        var objectDefID = Guid.Parse("425c44b9-edbb-4a1d-897c-2c93131964c1");
        var viewModel = new SocialServicesPatientInterviewFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientInterviewForm = objectContext.GetObject(id.Value, objectDefID) as PatientInterviewForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientInterviewForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientInterviewForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PatientInterviewForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PatientInterviewForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SocialServicesPatientInterviewForm(viewModel, viewModel._PatientInterviewForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PatientInterviewForm = new PatientInterviewForm(objectContext);
                var entryStateID = Guid.Parse("cf1c45ad-8a29-4137-8f88-35433be4d7eb");
                viewModel._PatientInterviewForm.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PatientInterviewForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientInterviewForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PatientInterviewForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PatientInterviewForm);
                PreScript_SocialServicesPatientInterviewForm(viewModel, viewModel._PatientInterviewForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9089c2aa-ad45-4f6a-a869-18d2be85ac49");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SocServAppliedProceduress);
            objectContext.AddToRawObjectList(viewModel.SocServPatientFamilyInfos);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.ResRooms);
            objectContext.AddToRawObjectList(viewModel.PayerDefinitions);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.PatientIdentityAndAddresss);
            var entryStateID = Guid.Parse("cf1c45ad-8a29-4137-8f88-35433be4d7eb");
            objectContext.AddToRawObjectList(viewModel._PatientInterviewForm, entryStateID);
            objectContext.ProcessRawObjects(false);
            var patientInterviewForm = (PatientInterviewForm)objectContext.GetLoadedObject(viewModel._PatientInterviewForm.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patientInterviewForm, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PatientInterviewForm, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(patientInterviewForm);
            PostScript_SocialServicesPatientInterviewForm(viewModel, patientInterviewForm, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patientInterviewForm);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patientInterviewForm);
            AfterContextSaveScript_SocialServicesPatientInterviewForm(viewModel, patientInterviewForm, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel, PatientInterviewForm patientInterviewForm, TTObjectContext objectContext);
    partial void PostScript_SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel, PatientInterviewForm patientInterviewForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SocialServicesPatientInterviewForm(SocialServicesPatientInterviewFormViewModel viewModel, PatientInterviewForm patientInterviewForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SocialServicesPatientInterviewFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        viewModel.SocServAppliedProceduress = objectContext.LocalQuery<SocServAppliedProcedures>().ToArray();
        viewModel.SocServPatientFamilyInfos = objectContext.LocalQuery<SocServPatientFamilyInfo>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.ResRooms = objectContext.LocalQuery<ResRoom>().ToArray();
        viewModel.PayerDefinitions = objectContext.LocalQuery<PayerDefinition>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.PatientIdentityAndAddresss = objectContext.LocalQuery<PatientIdentityAndAddress>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PoliclinicClinicDepartmentResourceListDefinition", viewModel.ResSections);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SocialServicePersonelList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
    }
}
}


namespace Core.Models
{
    public partial class SocialServicesPatientInterviewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PatientInterviewForm _PatientInterviewForm { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers { get; set; }
        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus { get; set; }
        public TTObjectClasses.SKRSMedeniHali[] SKRSMaritalStatuss { get; set; }        
        public TTObjectClasses.SocServAppliedProcedures[] SocServAppliedProceduress { get; set; }
        public TTObjectClasses.SocServPatientFamilyInfo[] SocServPatientFamilyInfos { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.ResRoom[] ResRooms { get; set; }
        public TTObjectClasses.PayerDefinition[] PayerDefinitions { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.PatientIdentityAndAddress[] PatientIdentityAndAddresss { get; set; }
    }
}
