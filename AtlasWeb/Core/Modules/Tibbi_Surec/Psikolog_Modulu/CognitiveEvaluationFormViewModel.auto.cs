//$4CE0C42D
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
    public partial class CognitiveEvaluationServiceController : Controller
{
    [HttpGet]
    public CognitiveEvaluationFormViewModel CognitiveEvaluationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return CognitiveEvaluationFormLoadInternal(input);
    }

    [HttpPost]
    public CognitiveEvaluationFormViewModel CognitiveEvaluationFormLoad(FormLoadInput input)
    {
        return CognitiveEvaluationFormLoadInternal(input);
    }

    private CognitiveEvaluationFormViewModel CognitiveEvaluationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("96d21eff-b727-45d4-a0e3-fd0bc00dedb1");
        var objectDefID = Guid.Parse("655732ac-5572-4f6a-9016-86fd419e0d7c");
        var viewModel = new CognitiveEvaluationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CognitiveEvaluation = objectContext.GetObject(id.Value, objectDefID) as CognitiveEvaluation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CognitiveEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CognitiveEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._CognitiveEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._CognitiveEvaluation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_CognitiveEvaluationForm(viewModel, viewModel._CognitiveEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._CognitiveEvaluation = new CognitiveEvaluation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._CognitiveEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CognitiveEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._CognitiveEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._CognitiveEvaluation);
                PreScript_CognitiveEvaluationForm(viewModel, viewModel._CognitiveEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("96d21eff-b727-45d4-a0e3-fd0bc00dedb1");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel._CognitiveEvaluation);
            objectContext.ProcessRawObjects();
            var cognitiveEvaluation = (CognitiveEvaluation)objectContext.GetLoadedObject(viewModel._CognitiveEvaluation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(cognitiveEvaluation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._CognitiveEvaluation, formDefID);
            var transDef = cognitiveEvaluation.TransDef;
            PostScript_CognitiveEvaluationForm(viewModel, cognitiveEvaluation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(cognitiveEvaluation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(cognitiveEvaluation);
            AfterContextSaveScript_CognitiveEvaluationForm(viewModel, cognitiveEvaluation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel, CognitiveEvaluation cognitiveEvaluation, TTObjectContext objectContext);
    partial void PostScript_CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel, CognitiveEvaluation cognitiveEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_CognitiveEvaluationForm(CognitiveEvaluationFormViewModel viewModel, CognitiveEvaluation cognitiveEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(CognitiveEvaluationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
    }
}
}


namespace Core.Models
{
    public partial class CognitiveEvaluationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.CognitiveEvaluation _CognitiveEvaluation { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers { get; set; }
        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus { get; set; }
    }
}
