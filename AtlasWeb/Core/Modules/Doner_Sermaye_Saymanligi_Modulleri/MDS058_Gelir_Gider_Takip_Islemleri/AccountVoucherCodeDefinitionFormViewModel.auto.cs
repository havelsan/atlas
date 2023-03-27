//$79742EC7
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
    public partial class AccountVoucherCodeDefinitionServiceController : Controller
{
    [HttpGet]
    public AccountVoucherCodeDefinitionFormViewModel AccountVoucherCodeDefinitionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AccountVoucherCodeDefinitionFormLoadInternal(input);
    }

    [HttpPost]
    public AccountVoucherCodeDefinitionFormViewModel AccountVoucherCodeDefinitionFormLoad(FormLoadInput input)
    {
        return AccountVoucherCodeDefinitionFormLoadInternal(input);
    }

    private AccountVoucherCodeDefinitionFormViewModel AccountVoucherCodeDefinitionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("9708c86a-d8fd-45a9-b996-23e64e43e7fd");
        var objectDefID = Guid.Parse("f290a74c-0eab-4b6e-89c7-92feb84c000e");
        var viewModel = new AccountVoucherCodeDefinitionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountVoucherCodeDefinition = objectContext.GetObject(id.Value, objectDefID) as AccountVoucherCodeDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountVoucherCodeDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucherCodeDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AccountVoucherCodeDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AccountVoucherCodeDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AccountVoucherCodeDefinitionForm(viewModel, viewModel._AccountVoucherCodeDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountVoucherCodeDefinition = new AccountVoucherCodeDefinition(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountVoucherCodeDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucherCodeDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AccountVoucherCodeDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AccountVoucherCodeDefinition);
                PreScript_AccountVoucherCodeDefinitionForm(viewModel, viewModel._AccountVoucherCodeDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AccountVoucherCodeDefinitionForm(AccountVoucherCodeDefinitionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AccountVoucherCodeDefinitionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AccountVoucherCodeDefinitionFormInternal(AccountVoucherCodeDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("9708c86a-d8fd-45a9-b996-23e64e43e7fd");
        objectContext.AddToRawObjectList(viewModel._AccountVoucherCodeDefinition);
        objectContext.ProcessRawObjects();
        var accountVoucherCodeDefinition = (AccountVoucherCodeDefinition)objectContext.GetLoadedObject(viewModel._AccountVoucherCodeDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(accountVoucherCodeDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountVoucherCodeDefinition, formDefID);
        var transDef = accountVoucherCodeDefinition.TransDef;
        PostScript_AccountVoucherCodeDefinitionForm(viewModel, accountVoucherCodeDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(accountVoucherCodeDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(accountVoucherCodeDefinition);
        AfterContextSaveScript_AccountVoucherCodeDefinitionForm(viewModel, accountVoucherCodeDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AccountVoucherCodeDefinitionForm(AccountVoucherCodeDefinitionFormViewModel viewModel, AccountVoucherCodeDefinition accountVoucherCodeDefinition, TTObjectContext objectContext);
    partial void PostScript_AccountVoucherCodeDefinitionForm(AccountVoucherCodeDefinitionFormViewModel viewModel, AccountVoucherCodeDefinition accountVoucherCodeDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AccountVoucherCodeDefinitionForm(AccountVoucherCodeDefinitionFormViewModel viewModel, AccountVoucherCodeDefinition accountVoucherCodeDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AccountVoucherCodeDefinitionFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AccountVoucherCodeDefinitionFormViewModel
    {
        public TTObjectClasses.AccountVoucherCodeDefinition _AccountVoucherCodeDefinition
        {
            get;
            set;
        }
    }
}
