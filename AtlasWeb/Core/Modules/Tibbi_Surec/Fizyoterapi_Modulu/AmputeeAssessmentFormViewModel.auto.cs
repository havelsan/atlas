//$F4041360
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
    public partial class AmputeeAssessmentFormServiceController : Controller
{
    [HttpGet]
    public AmputeeAssessmentFormViewModel AmputeeAssessmentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AmputeeAssessmentFormLoadInternal(input);
    }

    [HttpPost]
    public AmputeeAssessmentFormViewModel AmputeeAssessmentFormLoad(FormLoadInput input)
    {
        return AmputeeAssessmentFormLoadInternal(input);
    }

    private AmputeeAssessmentFormViewModel AmputeeAssessmentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ad6ecfd1-169f-4457-9126-11accc59c95e");
        var objectDefID = Guid.Parse("9760f13b-79a8-4b61-b71b-20bcda642812");
        var viewModel = new AmputeeAssessmentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AmputeeAssessmentForm = objectContext.GetObject(id.Value, objectDefID) as AmputeeAssessmentForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AmputeeAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AmputeeAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AmputeeAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AmputeeAssessmentForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AmputeeAssessmentForm(viewModel, viewModel._AmputeeAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AmputeeAssessmentForm = new AmputeeAssessmentForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AmputeeAssessmentForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AmputeeAssessmentForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AmputeeAssessmentForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AmputeeAssessmentForm);
                PreScript_AmputeeAssessmentForm(viewModel, viewModel._AmputeeAssessmentForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AmputeeAssessmentForm(AmputeeAssessmentFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AmputeeAssessmentFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AmputeeAssessmentFormInternal(AmputeeAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ad6ecfd1-169f-4457-9126-11accc59c95e");
        objectContext.AddToRawObjectList(viewModel._AmputeeAssessmentForm);
        objectContext.ProcessRawObjects();
        var amputeeAssessmentForm = (AmputeeAssessmentForm)objectContext.GetLoadedObject(viewModel._AmputeeAssessmentForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(amputeeAssessmentForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AmputeeAssessmentForm, formDefID);
        var transDef = amputeeAssessmentForm.TransDef;
        PostScript_AmputeeAssessmentForm(viewModel, amputeeAssessmentForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(amputeeAssessmentForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(amputeeAssessmentForm);
        AfterContextSaveScript_AmputeeAssessmentForm(viewModel, amputeeAssessmentForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AmputeeAssessmentForm(AmputeeAssessmentFormViewModel viewModel, AmputeeAssessmentForm amputeeAssessmentForm, TTObjectContext objectContext);
    partial void PostScript_AmputeeAssessmentForm(AmputeeAssessmentFormViewModel viewModel, AmputeeAssessmentForm amputeeAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AmputeeAssessmentForm(AmputeeAssessmentFormViewModel viewModel, AmputeeAssessmentForm amputeeAssessmentForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AmputeeAssessmentFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AmputeeAssessmentFormViewModel 
    {
        public TTObjectClasses.AmputeeAssessmentForm _AmputeeAssessmentForm { get; set; }
    }
}
