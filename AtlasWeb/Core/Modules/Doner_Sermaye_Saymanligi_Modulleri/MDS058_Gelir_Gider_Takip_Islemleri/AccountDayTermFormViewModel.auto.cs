//$1E7CF357
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
    public partial class AccountDayTermServiceController : Controller
{
    [HttpGet]
    public AccountDayTermFormViewModel AccountDayTermForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AccountDayTermFormLoadInternal(input);
    }

    [HttpPost]
    public AccountDayTermFormViewModel AccountDayTermFormLoad(FormLoadInput input)
    {
        return AccountDayTermFormLoadInternal(input);
    }

    private AccountDayTermFormViewModel AccountDayTermFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("f83d4bbd-9d2d-4811-9eea-075cb744f04b");
        var objectDefID = Guid.Parse("5487eaf4-289e-4fb1-bc89-7393faddfc56");
        var viewModel = new AccountDayTermFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountDayTerm = objectContext.GetObject(id.Value, objectDefID) as AccountDayTerm;
                //viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountDayTerm, formDefID);
                //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountDayTerm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AccountDayTerm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AccountDayTerm);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AccountDayTermForm(viewModel, viewModel._AccountDayTerm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountDayTerm = new AccountDayTerm(objectContext);
                var entryStateID = Guid.Parse("fcd94059-bd0b-44f8-8135-a7b9a2ef7123");
                viewModel._AccountDayTerm.CurrentStateDefID = entryStateID;
                //viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountDayTerm, formDefID);
                //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountDayTerm, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AccountDayTerm);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AccountDayTerm);
                PreScript_AccountDayTermForm(viewModel, viewModel._AccountDayTerm, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AccountDayTermForm(AccountDayTermFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AccountDayTermFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AccountDayTermFormInternal(AccountDayTermFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("f83d4bbd-9d2d-4811-9eea-075cb744f04b");
        objectContext.AddToRawObjectList(viewModel.AccountPeriodDefinitions);
        var entryStateID = Guid.Parse("fcd94059-bd0b-44f8-8135-a7b9a2ef7123");
        objectContext.AddToRawObjectList(viewModel._AccountDayTerm, entryStateID);
        objectContext.ProcessRawObjects(false);
        var accountDayTerm = (AccountDayTerm)objectContext.GetLoadedObject(viewModel._AccountDayTerm.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(accountDayTerm, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountDayTerm, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(accountDayTerm);
        PostScript_AccountDayTermForm(viewModel, accountDayTerm, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(accountDayTerm);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(accountDayTerm);
        AfterContextSaveScript_AccountDayTermForm(viewModel, accountDayTerm, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AccountDayTermForm(AccountDayTermFormViewModel viewModel, AccountDayTerm accountDayTerm, TTObjectContext objectContext);
    partial void PostScript_AccountDayTermForm(AccountDayTermFormViewModel viewModel, AccountDayTerm accountDayTerm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AccountDayTermForm(AccountDayTermFormViewModel viewModel, AccountDayTerm accountDayTerm, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AccountDayTermFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AccountPeriodDefinitions = objectContext.LocalQuery<AccountPeriodDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountPeriodList", viewModel.AccountPeriodDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class AccountDayTermFormViewModel
    {
        public TTObjectClasses.AccountDayTerm _AccountDayTerm
        {
            get;
            set;
        }

        public TTObjectClasses.AccountPeriodDefinition[] AccountPeriodDefinitions
        {
            get;
            set;
        }
    }
}
