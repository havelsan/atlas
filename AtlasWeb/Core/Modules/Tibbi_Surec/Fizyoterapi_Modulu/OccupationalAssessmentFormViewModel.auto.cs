//$097EAA09
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
    public partial class OccupationalAssessmentFormServiceController : Controller
{
    [HttpGet]
    public OccupationalAssessmentFormViewModel OccupationalAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return OccupationalAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public OccupationalAssessmentFormViewModel OccupationalAssessmentFormLoad(FormLoadInput input)
    {
        return OccupationalAssessmentFormLoadInternal(input);
    }

    private OccupationalAssessmentFormViewModel OccupationalAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("69815421-4e41-499e-83d0-9d4c9ee8f004");
        var objectDefID = Guid.Parse("0d3863da-9b08-4ae5-9569-fbfa45bca2af");
        var viewModel = new OccupationalAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OccupationalAssessmentForm = objectContext.GetObject(id.Value, objectDefID) as OccupationalAssessmentForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OccupationalAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OccupationalAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._OccupationalAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._OccupationalAssessmentForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_OccupationalAssessmentForm(viewModel, viewModel._OccupationalAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._OccupationalAssessmentForm = new OccupationalAssessmentForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._OccupationalAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OccupationalAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._OccupationalAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._OccupationalAssessmentForm);
                PreScript_OccupationalAssessmentForm(viewModel, viewModel._OccupationalAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel OccupationalAssessmentForm(OccupationalAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return OccupationalAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel OccupationalAssessmentFormInternal(OccupationalAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("69815421-4e41-499e-83d0-9d4c9ee8f004");
        objectContext.AddToRawObjectList(viewModel._OccupationalAssessmentForm);
        objectContext.ProcessRawObjects();
        var occupationalAssessmentForm = (OccupationalAssessmentForm)objectContext.GetLoadedObject(viewModel._OccupationalAssessmentForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(occupationalAssessmentForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._OccupationalAssessmentForm, formDefID);
        var transDef = occupationalAssessmentForm.TransDef;
        PostScript_OccupationalAssessmentForm(viewModel, occupationalAssessmentForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(occupationalAssessmentForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(occupationalAssessmentForm);
        AfterContextSaveScript_OccupationalAssessmentForm(viewModel, occupationalAssessmentForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_OccupationalAssessmentForm(OccupationalAssessmentFormViewModel viewModel, OccupationalAssessmentForm occupationalAssessmentForm, TTObjectContext objectContext);
    partial void PostScript_OccupationalAssessmentForm(OccupationalAssessmentFormViewModel viewModel, OccupationalAssessmentForm occupationalAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_OccupationalAssessmentForm(OccupationalAssessmentFormViewModel viewModel, OccupationalAssessmentForm occupationalAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(OccupationalAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class OccupationalAssessmentFormViewModel 
    {
        public TTObjectClasses.OccupationalAssessmentForm _OccupationalAssessmentForm { get; set; }
    }
}
