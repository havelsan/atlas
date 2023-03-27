//$D176F9D4
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
namespace Core.Controllers
{
    public partial class PatientServiceController : Controller
{
    [HttpGet]
    [AtlasRequiredRoles(TTRoleNames.Hasta_Kayit_Gorme, TTRoleNames.Hasta_Kayit_Kaydetme, TTRoleNames.Hasta_Kayit_Silme)]
    public NewPatientFormViewModel NewPatientForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NewPatientFormLoadInternal(input);
    }

    [HttpPost]
    public NewPatientFormViewModel NewPatientFormLoad(FormLoadInput input)
    {
        return NewPatientFormLoadInternal(input);
    }

    private NewPatientFormViewModel NewPatientFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("e6391e17-8388-4d44-ae95-83f0784b682d");
        var objectDefID = Guid.Parse("54d381eb-0ea3-4021-a400-4c1dda89ab37");
        var viewModel = new NewPatientFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Patient = objectContext.GetObject(id.Value, objectDefID) as Patient;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Patient, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Patient, formDefID);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Patient);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Patient);
                PreScript_NewPatientForm(viewModel, viewModel._Patient, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Patient = new Patient(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Patient, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Patient, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Patient);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Patient);
                PreScript_NewPatientForm(viewModel, viewModel._Patient, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    [AtlasRequiredRoles(TTRoleNames.Hasta_Kayit_Kaydetme, TTRoleNames.Hasta_Kayit_Silme)]
    public BaseViewModel NewPatientForm(NewPatientFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("e6391e17-8388-4d44-ae95-83f0784b682d");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PatientIdentityAndAddresss);
            objectContext.AddToRawObjectList(viewModel.SKRSCinsiyets);
            objectContext.AddToRawObjectList(viewModel.SKRSILKodlaris);
            objectContext.AddToRawObjectList(viewModel.SKRSUlkeKodlaris);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSKanGrubus);
            objectContext.AddToRawObjectList(viewModel.SKRSYabanciHastaTurus);
            objectContext.AddToRawObjectList(viewModel.SKRSOzurlulukDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSMaritalStatuss);
            objectContext.AddToRawObjectList(viewModel._Patient);
            objectContext.ProcessRawObjects();
            var patient = (Patient)objectContext.GetLoadedObject(viewModel._Patient.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(patient, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Patient, formDefID);
            var transDef = patient.TransDef;
            PostScript_NewPatientForm(viewModel, patient, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(patient);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(patient);
            AfterContextSaveScript_NewPatientForm(viewModel, patient, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTObjectContext objectContext);
    partial void PostScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NewPatientForm(NewPatientFormViewModel viewModel, Patient patient, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NewPatientFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PatientIdentityAndAddresss = objectContext.LocalQuery<PatientIdentityAndAddress>().ToArray();
        viewModel.SKRSCinsiyets = objectContext.LocalQuery<SKRSCinsiyet>().ToArray();
        viewModel.SKRSILKodlaris = objectContext.LocalQuery<SKRSILKodlari>().ToArray();
        viewModel.SKRSUlkeKodlaris = objectContext.LocalQuery<SKRSUlkeKodlari>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        viewModel.SKRSKanGrubus = objectContext.LocalQuery<SKRSKanGrubu>().ToArray();
        viewModel.SKRSYabanciHastaTurus = objectContext.LocalQuery<SKRSYabanciHastaTuru>().ToArray();
        viewModel.SKRSMaritalStatuss = objectContext.LocalQuery<SKRSMedeniHali>().ToArray();
        viewModel.SKRSOzurlulukDurumus = objectContext.LocalQuery<SKRSOzurlulukDurumu>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSCinsiyetList", viewModel.SKRSCinsiyets);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMedeniHaliList", viewModel.SKRSMaritalStatuss);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSUlkeKodlariList", viewModel.SKRSUlkeKodlaris);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSYabanciHastaTuruList", viewModel.SKRSYabanciHastaTurus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOzurlulukDurumuList", viewModel.SKRSOzurlulukDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSKanGrubuList", viewModel.SKRSKanGrubus);
    }
}
}

namespace Core.Models
{
    public partial class NewPatientFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Patient _Patient
        {
            get;
            set;
        }

        public TTObjectClasses.PatientIdentityAndAddress[] PatientIdentityAndAddresss
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSYabanciHastaTuru[] SKRSYabanciHastaTurus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSOzurlulukDurumu[] SKRSOzurlulukDurumus
        {
            get;
            set;
        }
        
        public TTObjectClasses.SKRSMedeniHali[] SKRSMaritalStatuss { get; set; }
        public TTObjectClasses.SKRSCinsiyet[] SKRSCinsiyets
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSILKodlari[] SKRSILKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSUlkeKodlari[] SKRSUlkeKodlaris
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers
        {
            get;
            set;
        }

        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus
        {
            get;
            set;
        }
        public TTObjectClasses.SKRSKanGrubu[] SKRSKanGrubus
        {
            get;
            set;
        }
    }
}