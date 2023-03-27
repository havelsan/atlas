//$AA3C9EBC
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
    public partial class TermOpenCloseActionServiceController : Controller
{
    [HttpGet]
    public TermOpenCloseActionFormViewModel TermOpenCloseActionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return TermOpenCloseActionFormLoadInternal(input);
    }

    [HttpPost]
    public TermOpenCloseActionFormViewModel TermOpenCloseActionFormLoad(FormLoadInput input)
    {
        return TermOpenCloseActionFormLoadInternal(input);
    }

    private TermOpenCloseActionFormViewModel TermOpenCloseActionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("25295371-199d-44e7-8394-7785bff548df");
        var objectDefID = Guid.Parse("ab320543-7e2c-455a-889c-6ad314554df4");
        var viewModel = new TermOpenCloseActionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TermOpenCloseAction = objectContext.GetObject(id.Value, objectDefID) as TermOpenCloseAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TermOpenCloseAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TermOpenCloseAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._TermOpenCloseAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._TermOpenCloseAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_TermOpenCloseActionForm(viewModel, viewModel._TermOpenCloseAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._TermOpenCloseAction = new TermOpenCloseAction(objectContext);
                var entryStateID = Guid.Parse("55b6836d-ed0f-4bfc-9b6f-d94a715c0bb9");
                viewModel._TermOpenCloseAction.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._TermOpenCloseAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TermOpenCloseAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._TermOpenCloseAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._TermOpenCloseAction);
                PreScript_TermOpenCloseActionForm(viewModel, viewModel._TermOpenCloseAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel TermOpenCloseActionForm(TermOpenCloseActionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return TermOpenCloseActionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel TermOpenCloseActionFormInternal(TermOpenCloseActionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("25295371-199d-44e7-8394-7785bff548df");
        objectContext.AddToRawObjectList(viewModel.AccountingTerms);
        objectContext.AddToRawObjectList(viewModel.Accountancys);
        var entryStateID = Guid.Parse("55b6836d-ed0f-4bfc-9b6f-d94a715c0bb9");
        objectContext.AddToRawObjectList(viewModel._TermOpenCloseAction, entryStateID);
        objectContext.ProcessRawObjects(false);
        var termOpenCloseAction = (TermOpenCloseAction)objectContext.GetLoadedObject(viewModel._TermOpenCloseAction.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(termOpenCloseAction, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._TermOpenCloseAction, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(termOpenCloseAction);
        PostScript_TermOpenCloseActionForm(viewModel, termOpenCloseAction, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(termOpenCloseAction);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(termOpenCloseAction);
        AfterContextSaveScript_TermOpenCloseActionForm(viewModel, termOpenCloseAction, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_TermOpenCloseActionForm(TermOpenCloseActionFormViewModel viewModel, TermOpenCloseAction termOpenCloseAction, TTObjectContext objectContext);
    partial void PostScript_TermOpenCloseActionForm(TermOpenCloseActionFormViewModel viewModel, TermOpenCloseAction termOpenCloseAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_TermOpenCloseActionForm(TermOpenCloseActionFormViewModel viewModel, TermOpenCloseAction termOpenCloseAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(TermOpenCloseActionFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AccountingTerms = objectContext.LocalQuery<AccountingTerm>().ToArray();
        viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
    }
}
}


namespace Core.Models
{
    public partial class TermOpenCloseActionFormViewModel
    {
        public TTObjectClasses.TermOpenCloseAction _TermOpenCloseAction
        {
            get;
            set;
        }

        public TTObjectClasses.AccountingTerm[] AccountingTerms
        {
            get;
            set;
        }

        public TTObjectClasses.Accountancy[] Accountancys
        {
            get;
            set;
        }
    }
}
