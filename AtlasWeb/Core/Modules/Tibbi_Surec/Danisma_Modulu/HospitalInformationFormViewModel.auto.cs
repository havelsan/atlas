//$25F497AD
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
    public partial class HospitalInformationServiceController : Controller
{
    [HttpGet]
    public HospitalInformationFormViewModel HospitalInformationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return HospitalInformationFormLoadInternal(input);
    }

    [HttpPost]
    public HospitalInformationFormViewModel HospitalInformationFormLoad(FormLoadInput input)
    {
        return HospitalInformationFormLoadInternal(input);
    }

    private HospitalInformationFormViewModel HospitalInformationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("98c20fcb-0536-4f33-a747-8d7b4bf0cf56");
        var objectDefID = Guid.Parse("8e5c155a-ecbf-49e3-afc2-1e04be8dde39");
        var viewModel = new HospitalInformationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HospitalInformation = objectContext.GetObject(id.Value, objectDefID) as HospitalInformation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HospitalInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HospitalInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._HospitalInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._HospitalInformation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_HospitalInformationForm(viewModel, viewModel._HospitalInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._HospitalInformation = new HospitalInformation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._HospitalInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HospitalInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._HospitalInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._HospitalInformation);
                PreScript_HospitalInformationForm(viewModel, viewModel._HospitalInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel HospitalInformationForm(HospitalInformationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("98c20fcb-0536-4f33-a747-8d7b4bf0cf56");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PatientVisitors);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel._HospitalInformation);
            objectContext.ProcessRawObjects();
            var hospitalInformation = (HospitalInformation)objectContext.GetLoadedObject(viewModel._HospitalInformation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(hospitalInformation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._HospitalInformation, formDefID);
            var transDef = hospitalInformation.TransDef;
            PostScript_HospitalInformationForm(viewModel, hospitalInformation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(hospitalInformation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(hospitalInformation);
            AfterContextSaveScript_HospitalInformationForm(viewModel, hospitalInformation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_HospitalInformationForm(HospitalInformationFormViewModel viewModel, HospitalInformation hospitalInformation, TTObjectContext objectContext);
    partial void PostScript_HospitalInformationForm(HospitalInformationFormViewModel viewModel, HospitalInformation hospitalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_HospitalInformationForm(HospitalInformationFormViewModel viewModel, HospitalInformation hospitalInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(HospitalInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PatientVisitors = objectContext.LocalQuery<PatientVisitor>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class HospitalInformationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.HospitalInformation _HospitalInformation { get; set; }
        public TTObjectClasses.PatientVisitor[] PatientVisitors { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
    }
}
