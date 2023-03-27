//$C01EE3E8
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
    public partial class BaseMultipleDataEntryServiceController : Controller
{
    [HttpGet]
    public BaseMultipleDataEntryFormViewModel BaseMultipleDataEntryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseMultipleDataEntryFormLoadInternal(input);
    }

    [HttpPost]
    public BaseMultipleDataEntryFormViewModel BaseMultipleDataEntryFormLoad(FormLoadInput input)
    {
        return BaseMultipleDataEntryFormLoadInternal(input);
    }

    private BaseMultipleDataEntryFormViewModel BaseMultipleDataEntryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a1424d83-ae0a-4237-abc3-91356c85f0ef");
        var objectDefID = Guid.Parse("672fe125-3eda-4aa7-baac-670f2261d1cb");
        var viewModel = new BaseMultipleDataEntryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseMultipleDataEntry = objectContext.GetObject(id.Value, objectDefID) as BaseMultipleDataEntry;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseMultipleDataEntry, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseMultipleDataEntry, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseMultipleDataEntry);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseMultipleDataEntry);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseMultipleDataEntryForm(viewModel, viewModel._BaseMultipleDataEntry, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseMultipleDataEntry = new BaseMultipleDataEntry(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseMultipleDataEntry, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseMultipleDataEntry, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseMultipleDataEntry);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseMultipleDataEntry);
                PreScript_BaseMultipleDataEntryForm(viewModel, viewModel._BaseMultipleDataEntry, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseMultipleDataEntryForm(BaseMultipleDataEntryFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return BaseMultipleDataEntryFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel BaseMultipleDataEntryFormInternal(BaseMultipleDataEntryFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a1424d83-ae0a-4237-abc3-91356c85f0ef");
        objectContext.AddToRawObjectList(viewModel._BaseMultipleDataEntry);
        objectContext.ProcessRawObjects();
        var baseMultipleDataEntry = (BaseMultipleDataEntry)objectContext.GetLoadedObject(viewModel._BaseMultipleDataEntry.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseMultipleDataEntry, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseMultipleDataEntry, formDefID);
        var transDef = baseMultipleDataEntry.TransDef;
        PostScript_BaseMultipleDataEntryForm(viewModel, baseMultipleDataEntry, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseMultipleDataEntry);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseMultipleDataEntry);
        AfterContextSaveScript_BaseMultipleDataEntryForm(viewModel, baseMultipleDataEntry, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_BaseMultipleDataEntryForm(BaseMultipleDataEntryFormViewModel viewModel, BaseMultipleDataEntry baseMultipleDataEntry, TTObjectContext objectContext);
    partial void PostScript_BaseMultipleDataEntryForm(BaseMultipleDataEntryFormViewModel viewModel, BaseMultipleDataEntry baseMultipleDataEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseMultipleDataEntryForm(BaseMultipleDataEntryFormViewModel viewModel, BaseMultipleDataEntry baseMultipleDataEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseMultipleDataEntryFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseMultipleDataEntryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseMultipleDataEntry _BaseMultipleDataEntry { get; set; }
    }
}
