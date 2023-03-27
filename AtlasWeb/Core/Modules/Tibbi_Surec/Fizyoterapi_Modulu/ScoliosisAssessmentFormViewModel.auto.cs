//$52ACD131
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
    public partial class ScoliosisAssessmentFormServiceController : Controller
{
    [HttpGet]
    public ScoliosisAssessmentFormViewModel ScoliosisAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ScoliosisAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public ScoliosisAssessmentFormViewModel ScoliosisAssessmentFormLoad(FormLoadInput input)
    {
        return ScoliosisAssessmentFormLoadInternal(input);
    }

    private ScoliosisAssessmentFormViewModel ScoliosisAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ccc5323f-a63d-4c5d-87b7-7f33bbe49e9e");
        var objectDefID = Guid.Parse("2cb20d09-63fd-41bb-a8cf-9e4dbf287ede");
        var viewModel = new ScoliosisAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ScoliosisAssessmentForm = objectContext.GetObject(id.Value, objectDefID) as ScoliosisAssessmentForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ScoliosisAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ScoliosisAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ScoliosisAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ScoliosisAssessmentForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ScoliosisAssessmentForm(viewModel, viewModel._ScoliosisAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ScoliosisAssessmentForm = new ScoliosisAssessmentForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ScoliosisAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ScoliosisAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ScoliosisAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ScoliosisAssessmentForm);
                PreScript_ScoliosisAssessmentForm(viewModel, viewModel._ScoliosisAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ScoliosisAssessmentForm(ScoliosisAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ScoliosisAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ScoliosisAssessmentFormInternal(ScoliosisAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ccc5323f-a63d-4c5d-87b7-7f33bbe49e9e");
        objectContext.AddToRawObjectList(viewModel._ScoliosisAssessmentForm);
        objectContext.ProcessRawObjects();
        var scoliosisAssessmentForm = (ScoliosisAssessmentForm)objectContext.GetLoadedObject(viewModel._ScoliosisAssessmentForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(scoliosisAssessmentForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ScoliosisAssessmentForm, formDefID);
        var transDef = scoliosisAssessmentForm.TransDef;
        PostScript_ScoliosisAssessmentForm(viewModel, scoliosisAssessmentForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(scoliosisAssessmentForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(scoliosisAssessmentForm);
        AfterContextSaveScript_ScoliosisAssessmentForm(viewModel, scoliosisAssessmentForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ScoliosisAssessmentForm(ScoliosisAssessmentFormViewModel viewModel, ScoliosisAssessmentForm scoliosisAssessmentForm, TTObjectContext objectContext);
    partial void PostScript_ScoliosisAssessmentForm(ScoliosisAssessmentFormViewModel viewModel, ScoliosisAssessmentForm scoliosisAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ScoliosisAssessmentForm(ScoliosisAssessmentFormViewModel viewModel, ScoliosisAssessmentForm scoliosisAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ScoliosisAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ScoliosisAssessmentFormViewModel
    {
        public TTObjectClasses.ScoliosisAssessmentForm _ScoliosisAssessmentForm { get; set; }
    }
}
