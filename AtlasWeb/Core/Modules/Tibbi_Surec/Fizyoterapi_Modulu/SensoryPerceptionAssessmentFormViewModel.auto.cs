//$A76931C9
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
    public partial class SensoryPerceptionAssessmentFormServiceController : Controller
{
    [HttpGet]
    public SensoryPerceptionAssessmentFormViewModel SensoryPerceptionAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SensoryPerceptionAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public SensoryPerceptionAssessmentFormViewModel SensoryPerceptionAssessmentFormLoad(FormLoadInput input)
    {
        return SensoryPerceptionAssessmentFormLoadInternal(input);
    }

    private SensoryPerceptionAssessmentFormViewModel SensoryPerceptionAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("46e3af62-b66d-46e3-aae8-1e1a5c596cd4");
        var objectDefID = Guid.Parse("d5f6b4e3-9911-47b0-b555-6981bca0a1fc");
        var viewModel = new SensoryPerceptionAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SensoryPerceptionAssessmentForm = objectContext.GetObject(id.Value, objectDefID) as SensoryPerceptionAssessmentForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SensoryPerceptionAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SensoryPerceptionAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SensoryPerceptionAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SensoryPerceptionAssessmentForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SensoryPerceptionAssessmentForm(viewModel, viewModel._SensoryPerceptionAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SensoryPerceptionAssessmentForm = new SensoryPerceptionAssessmentForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SensoryPerceptionAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SensoryPerceptionAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._SensoryPerceptionAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._SensoryPerceptionAssessmentForm);
                PreScript_SensoryPerceptionAssessmentForm(viewModel, viewModel._SensoryPerceptionAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SensoryPerceptionAssessmentForm(SensoryPerceptionAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return SensoryPerceptionAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel SensoryPerceptionAssessmentFormInternal(SensoryPerceptionAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("46e3af62-b66d-46e3-aae8-1e1a5c596cd4");
        objectContext.AddToRawObjectList(viewModel._SensoryPerceptionAssessmentForm);
        objectContext.ProcessRawObjects();
        var sensoryPerceptionAssessmentForm = (SensoryPerceptionAssessmentForm)objectContext.GetLoadedObject(viewModel._SensoryPerceptionAssessmentForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(sensoryPerceptionAssessmentForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SensoryPerceptionAssessmentForm, formDefID);
        var transDef = sensoryPerceptionAssessmentForm.TransDef;
        PostScript_SensoryPerceptionAssessmentForm(viewModel, sensoryPerceptionAssessmentForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(sensoryPerceptionAssessmentForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(sensoryPerceptionAssessmentForm);
        AfterContextSaveScript_SensoryPerceptionAssessmentForm(viewModel, sensoryPerceptionAssessmentForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_SensoryPerceptionAssessmentForm(SensoryPerceptionAssessmentFormViewModel viewModel, SensoryPerceptionAssessmentForm sensoryPerceptionAssessmentForm, TTObjectContext objectContext);
    partial void PostScript_SensoryPerceptionAssessmentForm(SensoryPerceptionAssessmentFormViewModel viewModel, SensoryPerceptionAssessmentForm sensoryPerceptionAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SensoryPerceptionAssessmentForm(SensoryPerceptionAssessmentFormViewModel viewModel, SensoryPerceptionAssessmentForm sensoryPerceptionAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SensoryPerceptionAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class SensoryPerceptionAssessmentFormViewModel 
    {
        public TTObjectClasses.SensoryPerceptionAssessmentForm _SensoryPerceptionAssessmentForm { get; set; }
    }
}
