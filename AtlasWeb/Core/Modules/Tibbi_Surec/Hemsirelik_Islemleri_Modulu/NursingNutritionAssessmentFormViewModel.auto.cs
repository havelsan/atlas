//$255C8F69
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
    public partial class NursingNutritionAssessmentServiceController : Controller
{
    [HttpGet]
    public NursingNutritionAssessmentFormViewModel NursingNutritionAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingNutritionAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public NursingNutritionAssessmentFormViewModel NursingNutritionAssessmentFormLoad(FormLoadInput input)
    {
        return NursingNutritionAssessmentFormLoadInternal(input);
    }

    private NursingNutritionAssessmentFormViewModel NursingNutritionAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fb0838c3-2d88-496b-bb3f-425f760f0a12");
        var objectDefID = Guid.Parse("abab50f4-1bce-42d3-b22e-30c13def7844");
        var viewModel = new NursingNutritionAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingNutritionAssessment = objectContext.GetObject(id.Value, objectDefID) as NursingNutritionAssessment;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingNutritionAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingNutritionAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingNutritionAssessment);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingNutritionAssessmentForm(viewModel, viewModel._NursingNutritionAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingNutritionAssessment = new NursingNutritionAssessment(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingNutritionAssessment.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingNutritionAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingNutritionAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingNutritionAssessment);
                PreScript_NursingNutritionAssessmentForm(viewModel, viewModel._NursingNutritionAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingNutritionAssessmentForm(NursingNutritionAssessmentFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fb0838c3-2d88-496b-bb3f-425f760f0a12");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.NursingDietDefinitions);
            objectContext.AddToRawObjectList(viewModel.ToothDefinitions);
            objectContext.AddToRawObjectList(viewModel.UrgeDefinitions);
            objectContext.AddToRawObjectList(viewModel.SwallowDefinitions);
            objectContext.AddToRawObjectList(viewModel.PanoramaDefinitions);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingNutritionAssessment, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingNutritionAssessment = (NursingNutritionAssessment)objectContext.GetLoadedObject(viewModel._NursingNutritionAssessment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingNutritionAssessment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionAssessment, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingNutritionAssessment);
            PostScript_NursingNutritionAssessmentForm(viewModel, nursingNutritionAssessment, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingNutritionAssessment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingNutritionAssessment);
            AfterContextSaveScript_NursingNutritionAssessmentForm(viewModel, nursingNutritionAssessment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingNutritionAssessmentForm(NursingNutritionAssessmentFormViewModel viewModel, NursingNutritionAssessment nursingNutritionAssessment, TTObjectContext objectContext);
    partial void PostScript_NursingNutritionAssessmentForm(NursingNutritionAssessmentFormViewModel viewModel, NursingNutritionAssessment nursingNutritionAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingNutritionAssessmentForm(NursingNutritionAssessmentFormViewModel viewModel, NursingNutritionAssessment nursingNutritionAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingNutritionAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.NursingDietDefinitions = objectContext.LocalQuery<NursingDietDefinition>().ToArray();
        viewModel.ToothDefinitions = objectContext.LocalQuery<ToothDefinition>().ToArray();
        viewModel.UrgeDefinitions = objectContext.LocalQuery<UrgeDefinition>().ToArray();
        viewModel.SwallowDefinitions = objectContext.LocalQuery<SwallowDefinition>().ToArray();
        viewModel.PanoramaDefinitions = objectContext.LocalQuery<PanoramaDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "NursingDietListDefinition", viewModel.NursingDietDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ToothListDefinition", viewModel.ToothDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UrgeListDefinition", viewModel.UrgeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SwallowListDefinition", viewModel.SwallowDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PanoramaListDefinition", viewModel.PanoramaDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingNutritionAssessmentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingNutritionAssessment _NursingNutritionAssessment { get; set; }
        public TTObjectClasses.NursingDietDefinition[] NursingDietDefinitions { get; set; }
        public TTObjectClasses.ToothDefinition[] ToothDefinitions { get; set; }
        public TTObjectClasses.UrgeDefinition[] UrgeDefinitions { get; set; }
        public TTObjectClasses.SwallowDefinition[] SwallowDefinitions { get; set; }
        public TTObjectClasses.PanoramaDefinition[] PanoramaDefinitions { get; set; }
    }
}
