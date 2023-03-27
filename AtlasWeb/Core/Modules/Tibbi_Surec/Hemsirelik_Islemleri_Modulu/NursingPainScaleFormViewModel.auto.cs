//$D58B70B2
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
    public partial class NursingPainScaleServiceController : Controller
{
    [HttpGet]
    public NursingPainScaleFormViewModel NursingPainScaleForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingPainScaleFormLoadInternal(input);
    }

    [HttpPost]
    public NursingPainScaleFormViewModel NursingPainScaleFormLoad(FormLoadInput input)
    {
        return NursingPainScaleFormLoadInternal(input);
    }

    private NursingPainScaleFormViewModel NursingPainScaleFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c7f14c45-b5c9-4f5a-9700-a028709eb494");
        var objectDefID = Guid.Parse("408652b6-d14f-4bae-826f-80556c81b080");
        var viewModel = new NursingPainScaleFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPainScale = objectContext.GetObject(id.Value, objectDefID) as NursingPainScale;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPainScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPainScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingPainScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingPainScale);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingPainScaleForm(viewModel, viewModel._NursingPainScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingPainScale = new NursingPainScale(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingPainScale.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingPainScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPainScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingPainScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingPainScale);
                PreScript_NursingPainScaleForm(viewModel, viewModel._NursingPainScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingPainScaleForm(NursingPainScaleFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c7f14c45-b5c9-4f5a-9700-a028709eb494");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.PainQualityDefinitions);
            objectContext.AddToRawObjectList(viewModel.PainFrequencyDefinitons);
            objectContext.AddToRawObjectList(viewModel.PainPlaceDefitions);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingPainScale, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingPainScale = (NursingPainScale)objectContext.GetLoadedObject(viewModel._NursingPainScale.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingPainScale, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingPainScale, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingPainScale);
            PostScript_NursingPainScaleForm(viewModel, nursingPainScale, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingPainScale);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingPainScale);
            AfterContextSaveScript_NursingPainScaleForm(viewModel, nursingPainScale, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingPainScaleForm(NursingPainScaleFormViewModel viewModel, NursingPainScale nursingPainScale, TTObjectContext objectContext);
    partial void PostScript_NursingPainScaleForm(NursingPainScaleFormViewModel viewModel, NursingPainScale nursingPainScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingPainScaleForm(NursingPainScaleFormViewModel viewModel, NursingPainScale nursingPainScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingPainScaleFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.PainQualityDefinitions = objectContext.LocalQuery<PainQualityDefinition>().ToArray();
        viewModel.PainFrequencyDefinitons = objectContext.LocalQuery<PainFrequencyDefiniton>().ToArray();
        viewModel.PainPlaceDefitions = objectContext.LocalQuery<PainPlaceDefition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PainQualityListDefinition", viewModel.PainQualityDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PainFrequencyListDefiniton", viewModel.PainFrequencyDefinitons);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PainPlaceListDefinition", viewModel.PainPlaceDefitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingPainScaleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingPainScale _NursingPainScale { get; set; }
        public TTObjectClasses.PainQualityDefinition[] PainQualityDefinitions { get; set; }
        public TTObjectClasses.PainFrequencyDefiniton[] PainFrequencyDefinitons { get; set; }
        public TTObjectClasses.PainPlaceDefition[] PainPlaceDefitions { get; set; }
    }
}
