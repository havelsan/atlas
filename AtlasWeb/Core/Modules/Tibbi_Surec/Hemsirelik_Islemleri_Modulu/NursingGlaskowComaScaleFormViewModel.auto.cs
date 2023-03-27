//$55A7FB89
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
    public partial class NursingGlaskowComaScaleServiceController : Controller
{
    [HttpGet]
    public NursingGlaskowComaScaleFormViewModel NursingGlaskowComaScaleForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingGlaskowComaScaleFormLoadInternal(input);
    }

    [HttpPost]
    public NursingGlaskowComaScaleFormViewModel NursingGlaskowComaScaleFormLoad(FormLoadInput input)
    {
        return NursingGlaskowComaScaleFormLoadInternal(input);
    }

    private NursingGlaskowComaScaleFormViewModel NursingGlaskowComaScaleFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("4c8deecc-3e6f-40aa-95da-23e1a9beb489");
        var objectDefID = Guid.Parse("ec8b4adc-539d-4c79-8dee-e8d8d1b1debe");
        var viewModel = new NursingGlaskowComaScaleFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingGlaskowComaScale = objectContext.GetObject(id.Value, objectDefID) as NursingGlaskowComaScale;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingGlaskowComaScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingGlaskowComaScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingGlaskowComaScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingGlaskowComaScale);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingGlaskowComaScaleForm(viewModel, viewModel._NursingGlaskowComaScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingGlaskowComaScale = new NursingGlaskowComaScale(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingGlaskowComaScale.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingGlaskowComaScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingGlaskowComaScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingGlaskowComaScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingGlaskowComaScale);
                PreScript_NursingGlaskowComaScaleForm(viewModel, viewModel._NursingGlaskowComaScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingGlaskowComaScaleForm(NursingGlaskowComaScaleFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("4c8deecc-3e6f-40aa-95da-23e1a9beb489");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.GlaskowComaScaleDefinitions);
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._NursingGlaskowComaScale, entryStateID);
            objectContext.ProcessRawObjects(false);
            var nursingGlaskowComaScale = (NursingGlaskowComaScale)objectContext.GetLoadedObject(viewModel._NursingGlaskowComaScale.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingGlaskowComaScale, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingGlaskowComaScale, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingGlaskowComaScale);
            PostScript_NursingGlaskowComaScaleForm(viewModel, nursingGlaskowComaScale, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingGlaskowComaScale);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingGlaskowComaScale);
            AfterContextSaveScript_NursingGlaskowComaScaleForm(viewModel, nursingGlaskowComaScale, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_NursingGlaskowComaScaleForm(NursingGlaskowComaScaleFormViewModel viewModel, NursingGlaskowComaScale nursingGlaskowComaScale, TTObjectContext objectContext);
    partial void PostScript_NursingGlaskowComaScaleForm(NursingGlaskowComaScaleFormViewModel viewModel, NursingGlaskowComaScale nursingGlaskowComaScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingGlaskowComaScaleForm(NursingGlaskowComaScaleFormViewModel viewModel, NursingGlaskowComaScale nursingGlaskowComaScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingGlaskowComaScaleFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GlaskowComaScaleDefinitions = objectContext.LocalQuery<GlaskowComaScaleDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSMotorAnswerListDefinition", viewModel.GlaskowComaScaleDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSEyesListDefinition", viewModel.GlaskowComaScaleDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GKSOralAnswerListDefinition", viewModel.GlaskowComaScaleDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class NursingGlaskowComaScaleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingGlaskowComaScale _NursingGlaskowComaScale { get; set; }
        public TTObjectClasses.GlaskowComaScaleDefinition[] GlaskowComaScaleDefinitions { get; set; }
    }
}
