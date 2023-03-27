//$A48BCAEC
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
    public partial class BaseNursingDataEntryServiceController : Controller
{
    [HttpGet]
    public BaseNursingDataEntryFormViewModel BaseNursingDataEntryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BaseNursingDataEntryFormLoadInternal(input);
    }

    [HttpPost]
    public BaseNursingDataEntryFormViewModel BaseNursingDataEntryFormLoad(FormLoadInput input)
    {
        return BaseNursingDataEntryFormLoadInternal(input);
    }

    private BaseNursingDataEntryFormViewModel BaseNursingDataEntryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("6ea60d49-4fdb-4758-92c8-dc0b97f1e36f");
        var objectDefID = Guid.Parse("e35e296e-6b27-4c5c-b27c-45decf5d3561");
        var viewModel = new BaseNursingDataEntryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingDataEntry = objectContext.GetObject(id.Value, objectDefID) as BaseNursingDataEntry;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingDataEntry, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDataEntry, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BaseNursingDataEntry);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BaseNursingDataEntry);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BaseNursingDataEntryForm(viewModel, viewModel._BaseNursingDataEntry, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BaseNursingDataEntry = new BaseNursingDataEntry(objectContext);
                var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
                viewModel._BaseNursingDataEntry.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BaseNursingDataEntry, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDataEntry, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BaseNursingDataEntry);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BaseNursingDataEntry);
                PreScript_BaseNursingDataEntryForm(viewModel, viewModel._BaseNursingDataEntry, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BaseNursingDataEntryForm(BaseNursingDataEntryFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("6ea60d49-4fdb-4758-92c8-dc0b97f1e36f");
        using (var objectContext = new TTObjectContext(false))
        {
            var entryStateID = Guid.Parse("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9");
            objectContext.AddToRawObjectList(viewModel._BaseNursingDataEntry, entryStateID);
            objectContext.ProcessRawObjects(false);
            var baseNursingDataEntry = (BaseNursingDataEntry)objectContext.GetLoadedObject(viewModel._BaseNursingDataEntry.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(baseNursingDataEntry, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BaseNursingDataEntry, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(baseNursingDataEntry);
            PostScript_BaseNursingDataEntryForm(viewModel, baseNursingDataEntry, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(baseNursingDataEntry);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(baseNursingDataEntry);
            AfterContextSaveScript_BaseNursingDataEntryForm(viewModel, baseNursingDataEntry, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BaseNursingDataEntryForm(BaseNursingDataEntryFormViewModel viewModel, BaseNursingDataEntry baseNursingDataEntry, TTObjectContext objectContext);
    partial void PostScript_BaseNursingDataEntryForm(BaseNursingDataEntryFormViewModel viewModel, BaseNursingDataEntry baseNursingDataEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BaseNursingDataEntryForm(BaseNursingDataEntryFormViewModel viewModel, BaseNursingDataEntry baseNursingDataEntry, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BaseNursingDataEntryFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class BaseNursingDataEntryFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BaseNursingDataEntry _BaseNursingDataEntry { get; set; }
    }
}
