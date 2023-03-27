//$50212783
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
    public partial class ManualDexterityTestsFormServiceController : Controller
{
    [HttpGet]
    public ManualDexterityTestsFormViewModel ManualDexterityTestsForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ManualDexterityTestsFormLoadInternal(input);
    }

    [HttpPost]
    public ManualDexterityTestsFormViewModel ManualDexterityTestsFormLoad(FormLoadInput input)
    {
        return ManualDexterityTestsFormLoadInternal(input);
    }

    private ManualDexterityTestsFormViewModel ManualDexterityTestsFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("58047074-b984-4a25-b5c7-639907c7c0c1");
        var objectDefID = Guid.Parse("8a4e2ebe-52c1-46cd-805d-067e99f8845c");
        var viewModel = new ManualDexterityTestsFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManualDexterityTestsForm = objectContext.GetObject(id.Value, objectDefID) as ManualDexterityTestsForm;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManualDexterityTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManualDexterityTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ManualDexterityTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ManualDexterityTestsForm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ManualDexterityTestsForm(viewModel, viewModel._ManualDexterityTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ManualDexterityTestsForm = new ManualDexterityTestsForm(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ManualDexterityTestsForm, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManualDexterityTestsForm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ManualDexterityTestsForm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ManualDexterityTestsForm);
                PreScript_ManualDexterityTestsForm(viewModel, viewModel._ManualDexterityTestsForm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ManualDexterityTestsForm(ManualDexterityTestsFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return ManualDexterityTestsFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel ManualDexterityTestsFormInternal(ManualDexterityTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("58047074-b984-4a25-b5c7-639907c7c0c1");
        objectContext.AddToRawObjectList(viewModel._ManualDexterityTestsForm);
        objectContext.ProcessRawObjects();
        var manualDexterityTestsForm = (ManualDexterityTestsForm)objectContext.GetLoadedObject(viewModel._ManualDexterityTestsForm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(manualDexterityTestsForm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ManualDexterityTestsForm, formDefID);
        var transDef = manualDexterityTestsForm.TransDef;
        PostScript_ManualDexterityTestsForm(viewModel, manualDexterityTestsForm, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(manualDexterityTestsForm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(manualDexterityTestsForm);
        AfterContextSaveScript_ManualDexterityTestsForm(viewModel, manualDexterityTestsForm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_ManualDexterityTestsForm(ManualDexterityTestsFormViewModel viewModel, ManualDexterityTestsForm manualDexterityTestsForm, TTObjectContext objectContext);
    partial void PostScript_ManualDexterityTestsForm(ManualDexterityTestsFormViewModel viewModel, ManualDexterityTestsForm manualDexterityTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ManualDexterityTestsForm(ManualDexterityTestsFormViewModel viewModel, ManualDexterityTestsForm manualDexterityTestsForm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ManualDexterityTestsFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class ManualDexterityTestsFormViewModel
    {
        public TTObjectClasses.ManualDexterityTestsForm _ManualDexterityTestsForm { get; set; }
    }
}
