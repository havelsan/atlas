//$1720CCD4
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
    public partial class NursingWoundAssessmentScaleServiceController : Controller
{
    [HttpGet]
    public NursingWoundAssessmentScaleFormViewModel NursingWoundAssessmentScaleForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingWoundAssessmentScaleFormLoadInternal(input);
    }

    [HttpPost]
    public NursingWoundAssessmentScaleFormViewModel NursingWoundAssessmentScaleFormLoad(FormLoadInput input)
    {
        return NursingWoundAssessmentScaleFormLoadInternal(input);
    }

    private NursingWoundAssessmentScaleFormViewModel NursingWoundAssessmentScaleFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("2813724d-e180-4880-b65c-ce911d4bb659");
        var objectDefID = Guid.Parse("3a7ebeab-c1c1-4c3a-8d89-50fcda1730ef");
        var viewModel = new NursingWoundAssessmentScaleFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingWoundAssessmentScale = objectContext.GetObject(id.Value, objectDefID) as NursingWoundAssessmentScale;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingWoundAssessmentScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundAssessmentScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingWoundAssessmentScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingWoundAssessmentScale);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingWoundAssessmentScaleForm(viewModel, viewModel._NursingWoundAssessmentScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingWoundAssessmentScale = new NursingWoundAssessmentScale(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingWoundAssessmentScale.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingWoundAssessmentScale, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundAssessmentScale, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingWoundAssessmentScale);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingWoundAssessmentScale);
                PreScript_NursingWoundAssessmentScaleForm(viewModel, viewModel._NursingWoundAssessmentScale, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingWoundAssessmentScaleFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingWoundAssessmentScaleFormInternal(NursingWoundAssessmentScaleFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("2813724d-e180-4880-b65c-ce911d4bb659");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingWoundAssessmentScale, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingWoundAssessmentScale = (NursingWoundAssessmentScale)objectContext.GetLoadedObject(viewModel._NursingWoundAssessmentScale.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingWoundAssessmentScale, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingWoundAssessmentScale, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingWoundAssessmentScale);
        PostScript_NursingWoundAssessmentScaleForm(viewModel, nursingWoundAssessmentScale, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingWoundAssessmentScale);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingWoundAssessmentScale);
        AfterContextSaveScript_NursingWoundAssessmentScaleForm(viewModel, nursingWoundAssessmentScale, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel, NursingWoundAssessmentScale nursingWoundAssessmentScale, TTObjectContext objectContext);
    partial void PostScript_NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel, NursingWoundAssessmentScale nursingWoundAssessmentScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingWoundAssessmentScaleForm(NursingWoundAssessmentScaleFormViewModel viewModel, NursingWoundAssessmentScale nursingWoundAssessmentScale, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingWoundAssessmentScaleFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingWoundAssessmentScaleFormViewModel : BaseViewModel
    {
        public TTObjectClasses.NursingWoundAssessmentScale _NursingWoundAssessmentScale { get; set; }
    }
}
