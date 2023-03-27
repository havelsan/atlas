//$0FFE46D4
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
    public partial class PhysicianApplicationServiceController : Controller
{
    [HttpGet]
    public AnamnesisFormViewModel AnamnesisForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AnamnesisFormLoadInternal(input);
    }

    [HttpPost]
    public AnamnesisFormViewModel AnamnesisFormLoad(FormLoadInput input)
    {
        return AnamnesisFormLoadInternal(input);
    }

    private AnamnesisFormViewModel AnamnesisFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("d0cd937f-d7ce-40c7-8ada-54edda7629e5");
        var objectDefID = Guid.Parse("878282b8-079b-48a1-a130-fbc5a2e69bc7");
        var viewModel = new AnamnesisFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysicianApplication = objectContext.GetObject(id.Value, objectDefID) as PhysicianApplication;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysicianApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysicianApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PhysicianApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PhysicianApplication);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AnamnesisForm(viewModel, viewModel._PhysicianApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PhysicianApplication = new PhysicianApplication(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PhysicianApplication, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysicianApplication, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PhysicianApplication);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PhysicianApplication);
                PreScript_AnamnesisForm(viewModel, viewModel._PhysicianApplication, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AnamnesisForm(AnamnesisFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("d0cd937f-d7ce-40c7-8ada-54edda7629e5");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._PhysicianApplication);
            objectContext.ProcessRawObjects();
            var physicianApplication = (PhysicianApplication)objectContext.GetLoadedObject(viewModel._PhysicianApplication.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(physicianApplication, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PhysicianApplication, formDefID);
            var transDef = physicianApplication.TransDef;
            PostScript_AnamnesisForm(viewModel, physicianApplication, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(physicianApplication);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(physicianApplication);
            AfterContextSaveScript_AnamnesisForm(viewModel, physicianApplication, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AnamnesisForm(AnamnesisFormViewModel viewModel, PhysicianApplication physicianApplication, TTObjectContext objectContext);
    partial void PostScript_AnamnesisForm(AnamnesisFormViewModel viewModel, PhysicianApplication physicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AnamnesisForm(AnamnesisFormViewModel viewModel, PhysicianApplication physicianApplication, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AnamnesisFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AnamnesisFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PhysicianApplication _PhysicianApplication { get; set; }
    }
}
