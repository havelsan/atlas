//$5D52E235
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
    public partial class PsychologicEvaluationServiceController : Controller
{
    [HttpGet]
    public PsychologicEvaluationFormViewModel PsychologicEvaluationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return PsychologicEvaluationFormLoadInternal(input);
    }

    [HttpPost]
    public PsychologicEvaluationFormViewModel PsychologicEvaluationFormLoad(FormLoadInput input)
    {
        return PsychologicEvaluationFormLoadInternal(input);
    }

    private PsychologicEvaluationFormViewModel PsychologicEvaluationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1fc4204f-2d2d-4625-9ea5-9a9834e550bd");
        var objectDefID = Guid.Parse("36a11fb1-689d-4d12-b4c6-ba744b4f6a5a");
        var viewModel = new PsychologicEvaluationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologicEvaluation = objectContext.GetObject(id.Value, objectDefID) as PsychologicEvaluation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologicEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._PsychologicEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._PsychologicEvaluation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_PsychologicEvaluationForm(viewModel, viewModel._PsychologicEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._PsychologicEvaluation = new PsychologicEvaluation(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._PsychologicEvaluation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicEvaluation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._PsychologicEvaluation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._PsychologicEvaluation);
                PreScript_PsychologicEvaluationForm(viewModel, viewModel._PsychologicEvaluation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1fc4204f-2d2d-4625-9ea5-9a9834e550bd");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.SKRSOgrenimDurumus);
            objectContext.AddToRawObjectList(viewModel.SKRSMesleklers);
            objectContext.AddToRawObjectList(viewModel._PsychologicEvaluation);
            objectContext.ProcessRawObjects();
            var psychologicEvaluation = (PsychologicEvaluation)objectContext.GetLoadedObject(viewModel._PsychologicEvaluation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(psychologicEvaluation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._PsychologicEvaluation, formDefID);
            var transDef = psychologicEvaluation.TransDef;
            PostScript_PsychologicEvaluationForm(viewModel, psychologicEvaluation, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(psychologicEvaluation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(psychologicEvaluation);
            AfterContextSaveScript_PsychologicEvaluationForm(viewModel, psychologicEvaluation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel, PsychologicEvaluation psychologicEvaluation, TTObjectContext objectContext);
    partial void PostScript_PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel, PsychologicEvaluation psychologicEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_PsychologicEvaluationForm(PsychologicEvaluationFormViewModel viewModel, PsychologicEvaluation psychologicEvaluation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(PsychologicEvaluationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.SKRSOgrenimDurumus = objectContext.LocalQuery<SKRSOgrenimDurumu>().ToArray();
        viewModel.SKRSMesleklers = objectContext.LocalQuery<SKRSMeslekler>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PsychologistList", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResUserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSOgrenimDurumuList", viewModel.SKRSOgrenimDurumus);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SKRSMesleklerList", viewModel.SKRSMesleklers);
    }
}
}


namespace Core.Models
{
    public partial class PsychologicEvaluationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.PsychologicEvaluation _PsychologicEvaluation { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.SKRSOgrenimDurumu[] SKRSOgrenimDurumus { get; set; }
        public TTObjectClasses.SKRSMeslekler[] SKRSMesleklers { get; set; }
    }
}
