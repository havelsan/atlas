//$39ED0568
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
    public partial class AccountPeriodDefinitionServiceController : Controller
{
    [HttpGet]
    public AccountPeriodDefintionFormViewModel AccountPeriodDefintionForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return AccountPeriodDefintionFormLoadInternal(input);
    }

    [HttpPost]
    public AccountPeriodDefintionFormViewModel AccountPeriodDefintionFormLoad(FormLoadInput input)
    {
        return AccountPeriodDefintionFormLoadInternal(input);
    }

    private AccountPeriodDefintionFormViewModel AccountPeriodDefintionFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("23a43aba-b78b-4f7f-9682-3cc58a3b350d");
        var objectDefID = Guid.Parse("6e84ca81-7ad7-4865-98b9-cda19b4b530c");
        var viewModel = new AccountPeriodDefintionFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountPeriodDefinition = objectContext.GetObject(id.Value, objectDefID) as AccountPeriodDefinition;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountPeriodDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountPeriodDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._AccountPeriodDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._AccountPeriodDefinition);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_AccountPeriodDefintionForm(viewModel, viewModel._AccountPeriodDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._AccountPeriodDefinition = new AccountPeriodDefinition(objectContext);
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._AccountPeriodDefinition, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountPeriodDefinition, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._AccountPeriodDefinition);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._AccountPeriodDefinition);
                PreScript_AccountPeriodDefintionForm(viewModel, viewModel._AccountPeriodDefinition, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel AccountPeriodDefintionForm(AccountPeriodDefintionFormViewModel viewModel)
    {
        using (var objectContext = new TTObjectContext(false))
        {
            return AccountPeriodDefintionFormInternal(viewModel, objectContext);
        }
    }

    internal BaseViewModel AccountPeriodDefintionFormInternal(AccountPeriodDefintionFormViewModel viewModel, TTObjectContext objectContext)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("23a43aba-b78b-4f7f-9682-3cc58a3b350d");
        objectContext.AddToRawObjectList(viewModel._AccountPeriodDefinition);
        objectContext.ProcessRawObjects();
        var accountPeriodDefinition = (AccountPeriodDefinition)objectContext.GetLoadedObject(viewModel._AccountPeriodDefinition.ObjectID);
        TTDefinitionManagement.TTFormDef.CheckFormSecurity(accountPeriodDefinition, formDefID, true);
        TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._AccountPeriodDefinition, formDefID);
        var transDef = accountPeriodDefinition.TransDef;
        PostScript_AccountPeriodDefintionForm(viewModel, accountPeriodDefinition, transDef, objectContext);
        retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
        objectContext.Save();
        viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(accountPeriodDefinition);
        viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(accountPeriodDefinition);
        AfterContextSaveScript_AccountPeriodDefintionForm(viewModel, accountPeriodDefinition, transDef, objectContext);
        retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
        retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
        objectContext.FullPartialllyLoadedObjects();
        return retViewModel;
    }

    partial void PreScript_AccountPeriodDefintionForm(AccountPeriodDefintionFormViewModel viewModel, AccountPeriodDefinition accountPeriodDefinition, TTObjectContext objectContext);
    partial void PostScript_AccountPeriodDefintionForm(AccountPeriodDefintionFormViewModel viewModel, AccountPeriodDefinition accountPeriodDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_AccountPeriodDefintionForm(AccountPeriodDefintionFormViewModel viewModel, AccountPeriodDefinition accountPeriodDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(AccountPeriodDefintionFormViewModel viewModel, TTObjectContext objectContext)
    {
    }
}
}


namespace Core.Models
{
    public partial class AccountPeriodDefintionFormViewModel
    {
        public TTObjectClasses.AccountPeriodDefinition _AccountPeriodDefinition
        {
            get;
            set;
        }
    }
}
