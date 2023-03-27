//$541EFFFF
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
    public partial class AdvanceServiceController : Controller
{
    [HttpGet]
    public AdvanceFormViewModel AdvanceForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AdvanceFormLoadInternal(input);
    }

    [HttpPost]
    public AdvanceFormViewModel AdvanceFormLoad(FormLoadInput input)
    {
        return AdvanceFormLoadInternal(input);
    }

    private AdvanceFormViewModel AdvanceFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("a1bf7eec-cf29-4926-8d16-0d9d05bdf199");
        var objectDefID = Guid.Parse("f9fa6079-f22a-4a28-9c36-3910f00c197d");
        var viewModel = new AdvanceFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Advance = objectContext.GetObject(id.Value, objectDefID) as Advance;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Advance, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Advance, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Advance);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Advance);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AdvanceForm(viewModel, viewModel._Advance, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Advance = new Advance(objectContext);
                var entryStateID = Guid.Parse("fc1fd323-d6e8-4493-b473-0a5c64611aa4");
                viewModel._Advance.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Advance, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Advance, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Advance);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Advance);
                PreScript_AdvanceForm(viewModel, viewModel._Advance, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AdvanceForm(AdvanceFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("a1bf7eec-cf29-4926-8d16-0d9d05bdf199");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.AdvanceDocuments);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.CashierLogs);
            var entryStateID = Guid.Parse("fc1fd323-d6e8-4493-b473-0a5c64611aa4");
            objectContext.AddToRawObjectList(viewModel._Advance, entryStateID);
            objectContext.ProcessRawObjects(false);
            var advance = (Advance)objectContext.GetLoadedObject(viewModel._Advance.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(advance, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Advance, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(advance);
            PostScript_AdvanceForm(viewModel, advance, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(advance);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(advance);
            AfterContextSaveScript_AdvanceForm(viewModel, advance, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_AdvanceForm(AdvanceFormViewModel viewModel, Advance advance, TTObjectContext objectContext);
    partial void PostScript_AdvanceForm(AdvanceFormViewModel viewModel, Advance advance, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AdvanceForm(AdvanceFormViewModel viewModel, Advance advance, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AdvanceFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AdvanceDocuments = objectContext.LocalQuery<AdvanceDocument>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.CashierLogs = objectContext.LocalQuery<CashierLog>().ToArray();
    }
}
}


namespace Core.Models
{
    public partial class AdvanceFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Advance _Advance { get; set; }
        public TTObjectClasses.AdvanceDocument[] AdvanceDocuments { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.CashierLog[] CashierLogs { get; set; }
    }
}
