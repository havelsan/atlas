//$BBF32961
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
    public partial class NursingAppliProgressServiceController : Controller
{
    [HttpGet]
    public NursingAppliProgressFormViewModel NursingAppliProgressForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingAppliProgressFormLoadInternal(input);
    }

    [HttpPost]
    public NursingAppliProgressFormViewModel NursingAppliProgressFormLoad(FormLoadInput input)
    {
        return NursingAppliProgressFormLoadInternal(input);
    }

    private NursingAppliProgressFormViewModel NursingAppliProgressFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("585d05f0-2320-42f5-b115-5269be2d15ec");
        var objectDefID = Guid.Parse("00ecb26b-771a-4d7f-b594-c5f4904169e6");
        var viewModel = new NursingAppliProgressFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingAppliProgress = objectContext.GetObject(id.Value, objectDefID) as NursingAppliProgress;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingAppliProgress, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingAppliProgress, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingAppliProgress);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingAppliProgress);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingAppliProgressForm(viewModel, viewModel._NursingAppliProgress, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingAppliProgress = new NursingAppliProgress(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingAppliProgress.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingAppliProgress, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingAppliProgress, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingAppliProgress);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingAppliProgress);
                PreScript_NursingAppliProgressForm(viewModel, viewModel._NursingAppliProgress, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingAppliProgressForm(NursingAppliProgressFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("585d05f0-2320-42f5-b115-5269be2d15ec");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingAppliProgress, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingAppliProgress = (NursingAppliProgress)objectContext.GetLoadedObject(viewModel._NursingAppliProgress.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingAppliProgress, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingAppliProgress, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingAppliProgress);
            PostScript_NursingAppliProgressForm(viewModel, nursingAppliProgress, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingAppliProgress);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingAppliProgress);
            AfterContextSaveScript_NursingAppliProgressForm(viewModel, nursingAppliProgress, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingAppliProgressForm(NursingAppliProgressFormViewModel viewModel, NursingAppliProgress nursingAppliProgress, TTObjectContext objectContext);
    partial void PostScript_NursingAppliProgressForm(NursingAppliProgressFormViewModel viewModel, NursingAppliProgress nursingAppliProgress, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingAppliProgressForm(NursingAppliProgressFormViewModel viewModel, NursingAppliProgress nursingAppliProgress, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingAppliProgressFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingAppliProgressFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingAppliProgress _NursingAppliProgress { get; set; }
    }
}
