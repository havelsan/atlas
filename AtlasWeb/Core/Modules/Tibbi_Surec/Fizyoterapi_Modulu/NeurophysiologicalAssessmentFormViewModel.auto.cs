//$9047BFCC
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
    public partial class NeurophysiologicalAssessmentFormServiceController : Controller
{
    [HttpGet]
    public NeurophysiologicalAssessmentFormViewModel NeurophysiologicalAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return NeurophysiologicalAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public NeurophysiologicalAssessmentFormViewModel NeurophysiologicalAssessmentFormLoad(FormLoadInput input)
    {
        return NeurophysiologicalAssessmentFormLoadInternal(input);
    }

    private NeurophysiologicalAssessmentFormViewModel NeurophysiologicalAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("290c4752-ad56-4022-afce-88c8566872e8");
        var objectDefID = Guid.Parse("f156992f-ba89-41df-ab33-0c2bc707ced6");
        var viewModel = new NeurophysiologicalAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NeurophysiologicalAssessmentForm = objectContext.GetObject(id.Value, objectDefID) as NeurophysiologicalAssessmentForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NeurophysiologicalAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NeurophysiologicalAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._NeurophysiologicalAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._NeurophysiologicalAssessmentForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_NeurophysiologicalAssessmentForm(viewModel, viewModel._NeurophysiologicalAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NeurophysiologicalAssessmentForm = new NeurophysiologicalAssessmentForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._NeurophysiologicalAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NeurophysiologicalAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._NeurophysiologicalAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._NeurophysiologicalAssessmentForm);
                PreScript_NeurophysiologicalAssessmentForm(viewModel, viewModel._NeurophysiologicalAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel NeurophysiologicalAssessmentForm(NeurophysiologicalAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return NeurophysiologicalAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel NeurophysiologicalAssessmentFormInternal(NeurophysiologicalAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("290c4752-ad56-4022-afce-88c8566872e8");
        objectContext.AddToRawObjectList(viewModel._NeurophysiologicalAssessmentForm);
        objectContext.ProcessRawObjects();
        var neurophysiologicalAssessmentForm = (NeurophysiologicalAssessmentForm)objectContext.GetLoadedObject(viewModel._NeurophysiologicalAssessmentForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(neurophysiologicalAssessmentForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._NeurophysiologicalAssessmentForm, formDefID);
        var transDef = neurophysiologicalAssessmentForm.TransDef;
        PostScript_NeurophysiologicalAssessmentForm(viewModel, neurophysiologicalAssessmentForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(neurophysiologicalAssessmentForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(neurophysiologicalAssessmentForm);
        AfterContextSaveScript_NeurophysiologicalAssessmentForm(viewModel, neurophysiologicalAssessmentForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_NeurophysiologicalAssessmentForm(NeurophysiologicalAssessmentFormViewModel viewModel, NeurophysiologicalAssessmentForm neurophysiologicalAssessmentForm, TTObjectContext objectContext);
    partial void PostScript_NeurophysiologicalAssessmentForm(NeurophysiologicalAssessmentFormViewModel viewModel, NeurophysiologicalAssessmentForm neurophysiologicalAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_NeurophysiologicalAssessmentForm(NeurophysiologicalAssessmentFormViewModel viewModel, NeurophysiologicalAssessmentForm neurophysiologicalAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(NeurophysiologicalAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class NeurophysiologicalAssessmentFormViewModel 
    {
        public TTObjectClasses.NeurophysiologicalAssessmentForm _NeurophysiologicalAssessmentForm { get; set; }
    }
}
