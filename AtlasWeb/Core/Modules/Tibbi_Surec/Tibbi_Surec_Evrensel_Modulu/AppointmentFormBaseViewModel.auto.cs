//$41307FCE
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
    public partial class BaseActionServiceController : Controller
{
    [HttpGet]
    public AppointmentFormBaseViewModel AppointmentFormBase(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AppointmentFormBaseLoadInternal(input);
    }

    [HttpPost]
    public AppointmentFormBaseViewModel AppointmentFormBaseLoad(FormLoadInput input)
    {
        return AppointmentFormBaseLoadInternal(input);
    }

    private AppointmentFormBaseViewModel AppointmentFormBaseLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("306af301-bba0-442e-b0bf-a0551b0a3dc6");
        var objectDefID = Guid.Parse("19912241-723c-4f0f-adcf-59482f642cf8");
        var viewModel = new AppointmentFormBaseViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseAction = objectContext.GetObject(id.Value, objectDefID) as BaseAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AppointmentFormBase(viewModel, viewModel._BaseAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseAction = new BaseAction(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseAction);
                PreScript_AppointmentFormBase(viewModel, viewModel._BaseAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AppointmentFormBase(AppointmentFormBaseViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("306af301-bba0-442e-b0bf-a0551b0a3dc6");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._BaseAction);
            objectContext.ProcessRawObjects();
            var baseAction = (BaseAction)objectContext.GetLoadedObject(viewModel._BaseAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseAction, formDefID);
            var transDef = baseAction.TransDef;
            PostScript_AppointmentFormBase(viewModel, baseAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseAction);
            AfterContextSaveScript_AppointmentFormBase(viewModel, baseAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AppointmentFormBase(AppointmentFormBaseViewModel viewModel, BaseAction baseAction, TTObjectContext objectContext);
    partial void PostScript_AppointmentFormBase(AppointmentFormBaseViewModel viewModel, BaseAction baseAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AppointmentFormBase(AppointmentFormBaseViewModel viewModel, BaseAction baseAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AppointmentFormBaseViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AppointmentFormBaseViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseAction _BaseAction { get; set; }
    }
}
