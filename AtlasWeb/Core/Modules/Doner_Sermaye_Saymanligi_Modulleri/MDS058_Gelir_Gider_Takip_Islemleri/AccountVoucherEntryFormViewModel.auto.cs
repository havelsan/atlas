//$E33C00A9
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
    public partial class AccountVoucherServiceController : Controller
{
    [HttpGet]
    public AccountVoucherEntryFormViewModel AccountVoucherEntryForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AccountVoucherEntryFormLoadInternal(input);
    }

    [HttpPost]
    public AccountVoucherEntryFormViewModel AccountVoucherEntryFormLoad(FormLoadInput input)
    {
        return AccountVoucherEntryFormLoadInternal(input);
    }

    private AccountVoucherEntryFormViewModel AccountVoucherEntryFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("05628a48-e655-43b4-b2f2-45dbecac94aa");
        var objectDefID = Guid.Parse("23cf3324-cd51-42d0-8396-f5194246876d");
        var viewModel = new AccountVoucherEntryFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountVoucher = objectContext.GetObject(id.Value, objectDefID) as AccountVoucher;
                //viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountVoucher, formDefID);
                //viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucher, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AccountVoucher);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AccountVoucher);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AccountVoucherEntryForm(viewModel, viewModel._AccountVoucher, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountVoucher = new AccountVoucher(objectContext);
                var entryStateID = Guid.Parse("2b4bfe99-f47c-4a10-97ca-2e079c695db3");
                viewModel._AccountVoucher.CurrentStateDefID = entryStateID;
                //viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountVoucher, formDefID);
                // viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucher, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AccountVoucher);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AccountVoucher);
                PreScript_AccountVoucherEntryForm(viewModel, viewModel._AccountVoucher, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AccountVoucherEntryForm(AccountVoucherEntryFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AccountVoucherEntryFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AccountVoucherEntryFormInternal(AccountVoucherEntryFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("05628a48-e655-43b4-b2f2-45dbecac94aa");
        objectContext.AddToRawObjectList(viewModel.AccountVoucherCodeDefinitions);
        objectContext.AddToRawObjectList(viewModel.SupplierDefinitions);
        objectContext.AddToRawObjectList(viewModel.AccountPeriodDefinitions);
        var entryStateID = Guid.Parse("2b4bfe99-f47c-4a10-97ca-2e079c695db3");
        objectContext.AddToRawObjectList(viewModel._AccountVoucher, entryStateID);
        objectContext.ProcessRawObjects(false);
        var accountVoucher = (AccountVoucher)objectContext.GetLoadedObject(viewModel._AccountVoucher.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(accountVoucher, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucher, formDefID);
        var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(accountVoucher);
        PostScript_AccountVoucherEntryForm(viewModel, accountVoucher, transDef, objectContext);
        objectContext.AdvanceStateForNewObjects();
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(accountVoucher);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(accountVoucher);
        AfterContextSaveScript_AccountVoucherEntryForm(viewModel, accountVoucher, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AccountVoucherEntryForm(AccountVoucherEntryFormViewModel viewModel, AccountVoucher accountVoucher, TTObjectContext objectContext);
    partial void PostScript_AccountVoucherEntryForm(AccountVoucherEntryFormViewModel viewModel, AccountVoucher accountVoucher, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AccountVoucherEntryForm(AccountVoucherEntryFormViewModel viewModel, AccountVoucher accountVoucher, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AccountVoucherEntryFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.AccountVoucherCodeDefinitions = objectContext.LocalQuery<AccountVoucherCodeDefinition>().ToArray();
        viewModel.AccountPeriodDefinitions = objectContext.LocalQuery<AccountPeriodDefinition>().ToArray();
        viewModel.SupplierDefinitions = objectContext.LocalQuery<Supplier>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountVoucherCodeList", viewModel.AccountVoucherCodeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierDefFormList", viewModel.SupplierDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountPeriodList", viewModel.AccountPeriodDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class AccountVoucherEntryFormViewModel
    {
        public TTObjectClasses.AccountVoucher _AccountVoucher
        {
            get;
            set;
        }

        public TTObjectClasses.AccountVoucherCodeDefinition[] AccountVoucherCodeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.AccountPeriodDefinition[] AccountPeriodDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.Supplier[] SupplierDefinitions
        {
            get;
            set;
        }
    }
}
