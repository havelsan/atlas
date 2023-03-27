//$C9720AA9
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
    public partial class NursingNutritionalRiskAssessmentServiceController : Controller
{
    [HttpGet]
    public NursingNutritionalRiskAssessmentFormViewModel NursingNutritionalRiskAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NursingNutritionalRiskAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public NursingNutritionalRiskAssessmentFormViewModel NursingNutritionalRiskAssessmentFormLoad(FormLoadInput input)
    {
        return NursingNutritionalRiskAssessmentFormLoadInternal(input);
    }

    private NursingNutritionalRiskAssessmentFormViewModel NursingNutritionalRiskAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1ae8e372-5e7c-4293-bd51-e6eb70de46ab");
        var objectDefID = Guid.Parse("15fe6058-247a-41eb-a6fb-2397170be443");
        var viewModel = new NursingNutritionalRiskAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingNutritionalRiskAssessment = objectContext.GetObject(id.Value, objectDefID) as NursingNutritionalRiskAssessment;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingNutritionalRiskAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionalRiskAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NursingNutritionalRiskAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NursingNutritionalRiskAssessment);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NursingNutritionalRiskAssessmentForm(viewModel, viewModel._NursingNutritionalRiskAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NursingNutritionalRiskAssessment = new NursingNutritionalRiskAssessment(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._NursingNutritionalRiskAssessment.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NursingNutritionalRiskAssessment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionalRiskAssessment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NursingNutritionalRiskAssessment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NursingNutritionalRiskAssessment);
                PreScript_NursingNutritionalRiskAssessmentForm(viewModel, viewModel._NursingNutritionalRiskAssessment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NursingNutritionalRiskAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NursingNutritionalRiskAssessmentFormInternal(NursingNutritionalRiskAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1ae8e372-5e7c-4293-bd51-e6eb70de46ab");
        var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
        objectContext.AddToRawObjectList(viewModel._NursingNutritionalRiskAssessment, entryStateID);
        objectContext.ProcessRawObjects(false);
        var nursingNutritionalRiskAssessment = (NursingNutritionalRiskAssessment)objectContext.GetLoadedObject(viewModel._NursingNutritionalRiskAssessment.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(nursingNutritionalRiskAssessment, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NursingNutritionalRiskAssessment, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(nursingNutritionalRiskAssessment);
        PostScript_NursingNutritionalRiskAssessmentForm(viewModel, nursingNutritionalRiskAssessment, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(nursingNutritionalRiskAssessment);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(nursingNutritionalRiskAssessment);
        AfterContextSaveScript_NursingNutritionalRiskAssessmentForm(viewModel, nursingNutritionalRiskAssessment, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel, NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, TTObjectContext objectContext);
    partial void PostScript_NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel, NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NursingNutritionalRiskAssessmentForm(NursingNutritionalRiskAssessmentFormViewModel viewModel, NursingNutritionalRiskAssessment nursingNutritionalRiskAssessment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NursingNutritionalRiskAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NursingNutritionalRiskAssessmentFormViewModel
    {
        public TTObjectClasses.NursingNutritionalRiskAssessment _NursingNutritionalRiskAssessment
        {
            get;
            set;
        }
    }
}
