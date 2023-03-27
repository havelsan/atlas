//$3BB73C87
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
    public partial class SubactionProcedureFlowableServiceController : Controller
{
    [HttpGet]
    public SubactionProcedureAppointmentFormViewModel SubactionProcedureAppointmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SubactionProcedureAppointmentFormLoadInternal(input);
    }

    [HttpPost]
    public SubactionProcedureAppointmentFormViewModel SubactionProcedureAppointmentFormLoad(FormLoadInput input)
    {
        return SubactionProcedureAppointmentFormLoadInternal(input);
    }

    private SubactionProcedureAppointmentFormViewModel SubactionProcedureAppointmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("bc45464f-cf91-42d4-aae9-1dacb1ae9c6b");
        var objectDefID = Guid.Parse("bb5dc227-e1f5-4354-b31e-cfe1bd176fa0");
        var viewModel = new SubactionProcedureAppointmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SubactionProcedureFlowable = objectContext.GetObject(id.Value, objectDefID) as SubactionProcedureFlowable;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SubactionProcedureFlowable, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubactionProcedureFlowable, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SubactionProcedureFlowable);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SubactionProcedureFlowable);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SubactionProcedureAppointmentForm(viewModel, viewModel._SubactionProcedureFlowable, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SubactionProcedureAppointmentForm(SubactionProcedureAppointmentFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("bc45464f-cf91-42d4-aae9-1dacb1ae9c6b");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel._SubactionProcedureFlowable);
            objectContext.ProcessRawObjects();
            var subactionProcedureFlowable = (SubactionProcedureFlowable)objectContext.GetLoadedObject(viewModel._SubactionProcedureFlowable.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(subactionProcedureFlowable, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubactionProcedureFlowable, formDefID);
            var transDef = subactionProcedureFlowable.TransDef;
            PostScript_SubactionProcedureAppointmentForm(viewModel, subactionProcedureFlowable, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(subactionProcedureFlowable);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(subactionProcedureFlowable);
            AfterContextSaveScript_SubactionProcedureAppointmentForm(viewModel, subactionProcedureFlowable, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SubactionProcedureAppointmentForm(SubactionProcedureAppointmentFormViewModel viewModel, SubactionProcedureFlowable subactionProcedureFlowable, TTObjectContext objectContext);
    partial void PostScript_SubactionProcedureAppointmentForm(SubactionProcedureAppointmentFormViewModel viewModel, SubactionProcedureFlowable subactionProcedureFlowable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SubactionProcedureAppointmentForm(SubactionProcedureAppointmentFormViewModel viewModel, SubactionProcedureFlowable subactionProcedureFlowable, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SubactionProcedureAppointmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class SubactionProcedureAppointmentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SubactionProcedureFlowable _SubactionProcedureFlowable { get; set; }
    }
}
