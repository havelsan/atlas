//$DE34AE43
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
    public partial class InfertilityPatientInformationServiceController : Controller
{
    [HttpGet]
    public InfertilityPatientInformationFormViewModel InfertilityPatientInformationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return InfertilityPatientInformationFormLoadInternal(input);
    }

    [HttpPost]
    public InfertilityPatientInformationFormViewModel InfertilityPatientInformationFormLoad(FormLoadInput input)
    {
        return InfertilityPatientInformationFormLoadInternal(input);
    }

    private InfertilityPatientInformationFormViewModel InfertilityPatientInformationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9502c4e5-eb0b-4ce6-9f3c-80415e647c7e");
        var objectDefID = Guid.Parse("7587a9c4-c66b-4fcc-8f1e-a97a22406188");
        var viewModel = new InfertilityPatientInformationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InfertilityPatientInformation = objectContext.GetObject(id.Value, objectDefID) as InfertilityPatientInformation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfertilityPatientInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfertilityPatientInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._InfertilityPatientInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._InfertilityPatientInformation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_InfertilityPatientInformationForm(viewModel, viewModel._InfertilityPatientInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._InfertilityPatientInformation = new InfertilityPatientInformation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._InfertilityPatientInformation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfertilityPatientInformation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._InfertilityPatientInformation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._InfertilityPatientInformation);
                PreScript_InfertilityPatientInformationForm(viewModel, viewModel._InfertilityPatientInformation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel InfertilityPatientInformationForm(InfertilityPatientInformationFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return InfertilityPatientInformationFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel InfertilityPatientInformationFormInternal(InfertilityPatientInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9502c4e5-eb0b-4ce6-9f3c-80415e647c7e");
        objectContext.AddToRawObjectList(viewModel._InfertilityPatientInformation);
        objectContext.ProcessRawObjects();
        var infertilityPatientInformation = (InfertilityPatientInformation)objectContext.GetLoadedObject(viewModel._InfertilityPatientInformation.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(infertilityPatientInformation, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._InfertilityPatientInformation, formDefID);
        var transDef = infertilityPatientInformation.TransDef;
        PostScript_InfertilityPatientInformationForm(viewModel, infertilityPatientInformation, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(infertilityPatientInformation);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(infertilityPatientInformation);
        AfterContextSaveScript_InfertilityPatientInformationForm(viewModel, infertilityPatientInformation, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_InfertilityPatientInformationForm(InfertilityPatientInformationFormViewModel viewModel, InfertilityPatientInformation infertilityPatientInformation, TTObjectContext objectContext);
    partial void PostScript_InfertilityPatientInformationForm(InfertilityPatientInformationFormViewModel viewModel, InfertilityPatientInformation infertilityPatientInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_InfertilityPatientInformationForm(InfertilityPatientInformationFormViewModel viewModel, InfertilityPatientInformation infertilityPatientInformation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(InfertilityPatientInformationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class InfertilityPatientInformationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.InfertilityPatientInformation _InfertilityPatientInformation { get; set; }
    }
}
