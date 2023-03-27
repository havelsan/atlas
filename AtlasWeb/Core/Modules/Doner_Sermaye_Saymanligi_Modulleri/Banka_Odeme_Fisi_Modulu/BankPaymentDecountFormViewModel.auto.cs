//$0A6A1098
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
    public partial class BankPaymentDecountServiceController : Controller
{
    [HttpGet]
    public BankPaymentDecountFormViewModel BankPaymentDecountForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BankPaymentDecountFormLoadInternal(input);
    }

    [HttpPost]
    public BankPaymentDecountFormViewModel BankPaymentDecountFormLoad(FormLoadInput input)
    {
        return BankPaymentDecountFormLoadInternal(input);
    }

    private BankPaymentDecountFormViewModel BankPaymentDecountFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("5be842af-d7f2-4a64-ae6e-4270a7468def");
        var objectDefID = Guid.Parse("dadd2ddc-cc6d-4471-bd13-f4bb4ce2ce00");
        var viewModel = new BankPaymentDecountFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BankPaymentDecount = objectContext.GetObject(id.Value, objectDefID) as BankPaymentDecount;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BankPaymentDecount, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BankPaymentDecount, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BankPaymentDecount);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BankPaymentDecount);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BankPaymentDecountForm(viewModel, viewModel._BankPaymentDecount, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BankPaymentDecount = new BankPaymentDecount(objectContext);
                var entryStateID = Guid.Parse("c15d8145-94dc-498e-9401-9030fcd41a20");
                viewModel._BankPaymentDecount.CurrentStateDefID = entryStateID;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BankPaymentDecount, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BankPaymentDecount, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BankPaymentDecount);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BankPaymentDecount);
                PreScript_BankPaymentDecountForm(viewModel, viewModel._BankPaymentDecount, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BankPaymentDecountForm(BankPaymentDecountFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("5be842af-d7f2-4a64-ae6e-4270a7468def");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BankPaymentDecountDocuments);
            objectContext.AddToRawObjectList(viewModel.BankDecounts);
            objectContext.AddToRawObjectList(viewModel.BankAccountDefinitions);
            objectContext.AddToRawObjectList(viewModel.CashOfficeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            var entryStateID = Guid.Parse("c15d8145-94dc-498e-9401-9030fcd41a20");
            objectContext.AddToRawObjectList(viewModel._BankPaymentDecount, entryStateID);
            objectContext.ProcessRawObjects(false);
            var bankPaymentDecount = (BankPaymentDecount)objectContext.GetLoadedObject(viewModel._BankPaymentDecount.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bankPaymentDecount, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BankPaymentDecount, formDefID);
            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(bankPaymentDecount);
            PostScript_BankPaymentDecountForm(viewModel, bankPaymentDecount, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bankPaymentDecount);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bankPaymentDecount);
            AfterContextSaveScript_BankPaymentDecountForm(viewModel, bankPaymentDecount, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BankPaymentDecountForm(BankPaymentDecountFormViewModel viewModel, BankPaymentDecount bankPaymentDecount, TTObjectContext objectContext);
    partial void PostScript_BankPaymentDecountForm(BankPaymentDecountFormViewModel viewModel, BankPaymentDecount bankPaymentDecount, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BankPaymentDecountForm(BankPaymentDecountFormViewModel viewModel, BankPaymentDecount bankPaymentDecount, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BankPaymentDecountFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.BankPaymentDecountDocuments = objectContext.LocalQuery<BankPaymentDecountDocument>().ToArray();
        viewModel.BankDecounts = objectContext.LocalQuery<BankDecount>().ToArray();
        viewModel.BankAccountDefinitions = objectContext.LocalQuery<BankAccountDefinition>().ToArray();
        viewModel.CashOfficeDefinitions = objectContext.LocalQuery<CashOfficeDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BankAccountListDefinition", viewModel.BankAccountDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class BankPaymentDecountFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BankPaymentDecount _BankPaymentDecount { get; set; }
        public TTObjectClasses.BankPaymentDecountDocument[] BankPaymentDecountDocuments { get; set; }
        public TTObjectClasses.BankDecount[] BankDecounts { get; set; }
        public TTObjectClasses.BankAccountDefinition[] BankAccountDefinitions { get; set; }
        public TTObjectClasses.CashOfficeDefinition[] CashOfficeDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
