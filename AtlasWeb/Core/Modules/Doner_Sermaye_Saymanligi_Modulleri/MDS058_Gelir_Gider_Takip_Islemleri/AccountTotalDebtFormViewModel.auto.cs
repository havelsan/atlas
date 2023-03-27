//$9EF7BF9E
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
    public partial class AccountTotalDebtServiceController : Controller
{
    [HttpGet]
    public AccountTotalDebtFormViewModel AccountTotalDebtForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AccountTotalDebtFormLoadInternal(input);
    }

    [HttpPost]
    public AccountTotalDebtFormViewModel AccountTotalDebtFormLoad(FormLoadInput input)
    {
        return AccountTotalDebtFormLoadInternal(input);
    }

    private AccountTotalDebtFormViewModel AccountTotalDebtFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("43542c77-af44-409b-97b8-2877ca6a39b3");
        var objectDefID = Guid.Parse("73b57b16-b879-4b74-b0d5-8998bf21c306");
        var viewModel = new AccountTotalDebtFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountTotalDebt = objectContext.GetObject(id.Value, objectDefID) as AccountTotalDebt;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountTotalDebt, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountTotalDebt, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AccountTotalDebt);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AccountTotalDebt);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AccountTotalDebtForm(viewModel, viewModel._AccountTotalDebt, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountTotalDebt = new AccountTotalDebt(objectContext);
                var entryStateID = Guid.Parse("108ae45e-f3dd-4610-bb3f-917a671f82c2");
                viewModel._AccountTotalDebt.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountTotalDebt, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountTotalDebt, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AccountTotalDebt);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AccountTotalDebt);
                PreScript_AccountTotalDebtForm(viewModel, viewModel._AccountTotalDebt, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AccountTotalDebtForm(AccountTotalDebtFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AccountTotalDebtFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AccountTotalDebtFormInternal(AccountTotalDebtFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("43542c77-af44-409b-97b8-2877ca6a39b3");
        objectContext.AddToRawObjectList(viewModel.AccountPeriodDefinitions);
        var entryStateID = Guid.Parse("108ae45e-f3dd-4610-bb3f-917a671f82c2");
        objectContext.AddToRawObjectList(viewModel._AccountTotalDebt, entryStateID);
        objectContext.ProcessRawObjects(false);
        var accountTotalDebt = (AccountTotalDebt)objectContext.GetLoadedObject(viewModel._AccountTotalDebt.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(accountTotalDebt, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountTotalDebt, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(accountTotalDebt);
        PostScript_AccountTotalDebtForm(viewModel, accountTotalDebt, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(accountTotalDebt);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(accountTotalDebt);
        AfterContextSaveScript_AccountTotalDebtForm(viewModel, accountTotalDebt, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AccountTotalDebtForm(AccountTotalDebtFormViewModel viewModel, AccountTotalDebt accountTotalDebt, TTObjectContext objectContext);
    partial void PostScript_AccountTotalDebtForm(AccountTotalDebtFormViewModel viewModel, AccountTotalDebt accountTotalDebt, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AccountTotalDebtForm(AccountTotalDebtFormViewModel viewModel, AccountTotalDebt accountTotalDebt, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AccountTotalDebtFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AccountPeriodDefinitions = objectContext.LocalQuery<AccountPeriodDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountPeriodList", viewModel.AccountPeriodDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class AccountTotalDebtFormViewModel
    {
        public TTObjectClasses.AccountTotalDebt _AccountTotalDebt
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
