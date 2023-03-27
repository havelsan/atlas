//$14EAE868
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
    public partial class MainCashOfficeOperationServiceController : Controller
{
    [HttpGet]
    public MainCashOfficeOperationFormViewModel MainCashOfficeOperationForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MainCashOfficeOperationFormLoadInternal(input);
    }

    [HttpPost]
    public MainCashOfficeOperationFormViewModel MainCashOfficeOperationFormLoad(FormLoadInput input)
    {
        return MainCashOfficeOperationFormLoadInternal(input);
    }

    private MainCashOfficeOperationFormViewModel MainCashOfficeOperationFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("c891947e-d7de-44b9-a6a2-90dedbf5982a");
        var objectDefID = Guid.Parse("72f6b8ab-b9d1-41e6-9dd8-53f260aa0b4f");
        var viewModel = new MainCashOfficeOperationFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MainCashOfficeOperation = objectContext.GetObject(id.Value, objectDefID) as MainCashOfficeOperation;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainCashOfficeOperation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainCashOfficeOperation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MainCashOfficeOperation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MainCashOfficeOperation);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MainCashOfficeOperationForm(viewModel, viewModel._MainCashOfficeOperation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MainCashOfficeOperation = new MainCashOfficeOperation(objectContext);
                var entryStateID = Guid.Parse("12a77590-ff12-4b23-9d9b-528a524fa9a1");
                viewModel._MainCashOfficeOperation.CurrentStateDefID = entryStateID;
                viewModel.CashierLogsGridGridList = new TTObjectClasses.SubmittedCashierLog[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainCashOfficeOperation, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainCashOfficeOperation, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._MainCashOfficeOperation);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._MainCashOfficeOperation);
                PreScript_MainCashOfficeOperationForm(viewModel, viewModel._MainCashOfficeOperation, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MainCashOfficeOperationForm(MainCashOfficeOperationFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("c891947e-d7de-44b9-a6a2-90dedbf5982a");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.CashOfficeReceiptDocuments);
            objectContext.AddToRawObjectList(viewModel.CashOfficeDefinitions);
            objectContext.AddToRawObjectList(viewModel.BankDecounts);
            objectContext.AddToRawObjectList(viewModel.BankAccountDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.CashierLogs);
            objectContext.AddToRawObjectList(viewModel.MainCashOfficePaymentTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Suppliers);
            objectContext.AddToRawObjectList(viewModel.CashierLogsGridGridList);
            var entryStateID = Guid.Parse("12a77590-ff12-4b23-9d9b-528a524fa9a1");
            objectContext.AddToRawObjectList(viewModel._MainCashOfficeOperation, entryStateID);
            objectContext.ProcessRawObjects(false);
            var mainCashOfficeOperation = (MainCashOfficeOperation)objectContext.GetLoadedObject(viewModel._MainCashOfficeOperation.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(mainCashOfficeOperation, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainCashOfficeOperation, formDefID);
            if (viewModel.CashierLogsGridGridList != null)
            {
                foreach (var item in viewModel.CashierLogsGridGridList)
                {
                    var submittedCashierLogsImported = (SubmittedCashierLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)submittedCashierLogsImported).IsDeleted)
                        continue;
                    submittedCashierLogsImported.MainCashOfficeOperation = mainCashOfficeOperation;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(mainCashOfficeOperation);
            PostScript_MainCashOfficeOperationForm(viewModel, mainCashOfficeOperation, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(mainCashOfficeOperation);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(mainCashOfficeOperation);
            AfterContextSaveScript_MainCashOfficeOperationForm(viewModel, mainCashOfficeOperation, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MainCashOfficeOperationForm(MainCashOfficeOperationFormViewModel viewModel, MainCashOfficeOperation mainCashOfficeOperation, TTObjectContext objectContext);
    partial void PostScript_MainCashOfficeOperationForm(MainCashOfficeOperationFormViewModel viewModel, MainCashOfficeOperation mainCashOfficeOperation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MainCashOfficeOperationForm(MainCashOfficeOperationFormViewModel viewModel, MainCashOfficeOperation mainCashOfficeOperation, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MainCashOfficeOperationFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.CashierLogsGridGridList = viewModel._MainCashOfficeOperation.SubmittedCashierLogs.OfType<SubmittedCashierLog>().ToArray();
        viewModel.CashOfficeReceiptDocuments = objectContext.LocalQuery<CashOfficeReceiptDocument>().ToArray();
        viewModel.CashOfficeDefinitions = objectContext.LocalQuery<CashOfficeDefinition>().ToArray();
        viewModel.BankDecounts = objectContext.LocalQuery<BankDecount>().ToArray();
        viewModel.BankAccountDefinitions = objectContext.LocalQuery<BankAccountDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.CashierLogs = objectContext.LocalQuery<CashierLog>().ToArray();
        viewModel.MainCashOfficePaymentTypeDefinitions = objectContext.LocalQuery<MainCashOfficePaymentTypeDefinition>().ToArray();
        viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BankAccountListDefinition", viewModel.BankAccountDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainCashOfficePaymentTypeListDefinition", viewModel.MainCashOfficePaymentTypeDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
    }
}
}


namespace Core.Models
{
    public partial class MainCashOfficeOperationFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MainCashOfficeOperation _MainCashOfficeOperation { get; set; }
        public TTObjectClasses.SubmittedCashierLog[] CashierLogsGridGridList { get; set; }
        public TTObjectClasses.CashOfficeReceiptDocument[] CashOfficeReceiptDocuments { get; set; }
        public TTObjectClasses.CashOfficeDefinition[] CashOfficeDefinitions { get; set; }
        public TTObjectClasses.BankDecount[] BankDecounts { get; set; }
        public TTObjectClasses.BankAccountDefinition[] BankAccountDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.CashierLog[] CashierLogs { get; set; }
        public TTObjectClasses.MainCashOfficePaymentTypeDefinition[] MainCashOfficePaymentTypeDefinitions { get; set; }
        public TTObjectClasses.Supplier[] Suppliers { get; set; }
    }
}
