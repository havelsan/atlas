//$B81C36B7
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
    public partial class DailyActivityTestsFormServiceController : Controller
{
    [HttpGet]
    public DailyActivityTestsFormViewModel DailyActivityTestsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DailyActivityTestsFormLoadInternal(input);
    }

    [HttpPost]
    public DailyActivityTestsFormViewModel DailyActivityTestsFormLoad(FormLoadInput input)
    {
        return DailyActivityTestsFormLoadInternal(input);
    }

    private DailyActivityTestsFormViewModel DailyActivityTestsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c49e935c-ca4b-42e0-82f1-1fe5c82a289c");
        var objectDefID = Guid.Parse("eba932f7-f77c-437a-b6ef-bd8cbd82bcee");
        var viewModel = new DailyActivityTestsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DailyActivityTestsForm = objectContext.GetObject(id.Value, objectDefID) as DailyActivityTestsForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DailyActivityTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DailyActivityTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DailyActivityTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DailyActivityTestsForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DailyActivityTestsForm(viewModel, viewModel._DailyActivityTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DailyActivityTestsForm = new DailyActivityTestsForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DailyActivityTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DailyActivityTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._DailyActivityTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._DailyActivityTestsForm);
                PreScript_DailyActivityTestsForm(viewModel, viewModel._DailyActivityTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DailyActivityTestsForm(DailyActivityTestsFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return DailyActivityTestsFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel DailyActivityTestsFormInternal(DailyActivityTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c49e935c-ca4b-42e0-82f1-1fe5c82a289c");
        objectContext.AddToRawObjectList(viewModel._DailyActivityTestsForm);
        objectContext.ProcessRawObjects();
        var dailyActivityTestsForm = (DailyActivityTestsForm)objectContext.GetLoadedObject(viewModel._DailyActivityTestsForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(dailyActivityTestsForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DailyActivityTestsForm, formDefID);
        var transDef = dailyActivityTestsForm.TransDef;
        PostScript_DailyActivityTestsForm(viewModel, dailyActivityTestsForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(dailyActivityTestsForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(dailyActivityTestsForm);
        AfterContextSaveScript_DailyActivityTestsForm(viewModel, dailyActivityTestsForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_DailyActivityTestsForm(DailyActivityTestsFormViewModel viewModel, DailyActivityTestsForm dailyActivityTestsForm, TTObjectContext objectContext);
    partial void PostScript_DailyActivityTestsForm(DailyActivityTestsFormViewModel viewModel, DailyActivityTestsForm dailyActivityTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DailyActivityTestsForm(DailyActivityTestsFormViewModel viewModel, DailyActivityTestsForm dailyActivityTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DailyActivityTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class DailyActivityTestsFormViewModel 
    {
        public TTObjectClasses.DailyActivityTestsForm _DailyActivityTestsForm { get; set; }
    }
}
