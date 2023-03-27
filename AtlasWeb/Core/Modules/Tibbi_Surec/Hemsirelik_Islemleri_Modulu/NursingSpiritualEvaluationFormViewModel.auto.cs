//$1D5BDF1C
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
    public partial class NursingSpiritualEvaluationServiceController : Controller
{
    [HttpGet]
    public NursingSpiritualEvaluationFormViewModel NursingSpiritualEvaluationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingSpiritualEvaluationFormLoadInternal(input);
    }

    [HttpPost]
    public NursingSpiritualEvaluationFormViewModel NursingSpiritualEvaluationFormLoad(FormLoadInput input)
    {
        return NursingSpiritualEvaluationFormLoadInternal(input);
    }

    private NursingSpiritualEvaluationFormViewModel NursingSpiritualEvaluationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("f718ffa4-5736-42be-bc8b-c10e95ff9c8b");
        var objectDefID = Guid.Parse("432f054a-99b2-417a-a2f3-39fc455593dc");
        var viewModel = new NursingSpiritualEvaluationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingSpiritualEvaluation = objectContext.GetObject(id.Value, objectDefID) as NursingSpiritualEvaluation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingSpiritualEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingSpiritualEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingSpiritualEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingSpiritualEvaluation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingSpiritualEvaluationForm(viewModel, viewModel._NursingSpiritualEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingSpiritualEvaluation = new NursingSpiritualEvaluation(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingSpiritualEvaluation.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingSpiritualEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingSpiritualEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingSpiritualEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingSpiritualEvaluation);
                PreScript_NursingSpiritualEvaluationForm(viewModel, viewModel._NursingSpiritualEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingSpiritualEvaluationForm(NursingSpiritualEvaluationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("f718ffa4-5736-42be-bc8b-c10e95ff9c8b");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingSpiritualEvaluation, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingSpiritualEvaluation = (NursingSpiritualEvaluation)objectContext.GetLoadedObject(viewModel._NursingSpiritualEvaluation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingSpiritualEvaluation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingSpiritualEvaluation, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingSpiritualEvaluation);
            PostScript_NursingSpiritualEvaluationForm(viewModel, nursingSpiritualEvaluation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingSpiritualEvaluation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingSpiritualEvaluation);
            AfterContextSaveScript_NursingSpiritualEvaluationForm(viewModel, nursingSpiritualEvaluation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingSpiritualEvaluationForm(NursingSpiritualEvaluationFormViewModel viewModel, NursingSpiritualEvaluation nursingSpiritualEvaluation, TTObjectContext objectContext);
    partial void PostScript_NursingSpiritualEvaluationForm(NursingSpiritualEvaluationFormViewModel viewModel, NursingSpiritualEvaluation nursingSpiritualEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingSpiritualEvaluationForm(NursingSpiritualEvaluationFormViewModel viewModel, NursingSpiritualEvaluation nursingSpiritualEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingSpiritualEvaluationFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingSpiritualEvaluationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingSpiritualEvaluation _NursingSpiritualEvaluation { get; set; }
    }
}
