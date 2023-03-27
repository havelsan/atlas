//$4B637091
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
    public partial class ReceiptServiceController : Controller
{
    [HttpGet]
    public ReceiptFormViewModel ReceiptForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ReceiptFormLoadInternal(input);
    }

    [HttpPost]
    public ReceiptFormViewModel ReceiptFormLoad(FormLoadInput input)
    {
        return ReceiptFormLoadInternal(input);
    }

    private ReceiptFormViewModel ReceiptFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("18f47a42-e47e-43e7-819f-320cf89b178f");
        var objectDefID = Guid.Parse("83762da5-c38d-43ee-b340-f518b6975b30");
        var viewModel = new ReceiptFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Receipt = objectContext.GetObject(id.Value, objectDefID) as Receipt;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Receipt, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Receipt, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._Receipt);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._Receipt);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ReceiptForm(viewModel, viewModel._Receipt, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._Receipt = new Receipt(objectContext);
                var entryStateID = Guid.Parse("3a9e132b-ceec-4e0a-b7ec-3b4f56deaed9");
                viewModel._Receipt.CurrentStateDefID = entryStateID;
                viewModel.GRIDReceiptProceduresGridList = new TTObjectClasses.ReceiptProcedure[]{};
                viewModel.GRIDReceiptMaterialsGridList = new TTObjectClasses.ReceiptMaterial[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._Receipt, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Receipt, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._Receipt);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._Receipt);
                PreScript_ReceiptForm(viewModel, viewModel._Receipt, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ReceiptForm(ReceiptFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("18f47a42-e47e-43e7-819f-320cf89b178f");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.ReceiptDocuments);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.CashierLogs);
            objectContext.AddToRawObjectList(viewModel.DiscountTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.GRIDReceiptProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.GRIDReceiptMaterialsGridList);
            var entryStateID = Guid.Parse("3a9e132b-ceec-4e0a-b7ec-3b4f56deaed9");
            objectContext.AddToRawObjectList(viewModel._Receipt, entryStateID);
            objectContext.ProcessRawObjects(false);
            var receipt = (Receipt)objectContext.GetLoadedObject(viewModel._Receipt.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(receipt, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._Receipt, formDefID);
            if (viewModel.GRIDReceiptProceduresGridList != null)
            {
                foreach (var item in viewModel.GRIDReceiptProceduresGridList)
                {
                    var receiptProceduresImported = (ReceiptProcedure)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)receiptProceduresImported).IsDeleted)
                        continue;
                    receiptProceduresImported.Receipt = receipt;
                }
            }

            if (viewModel.GRIDReceiptMaterialsGridList != null)
            {
                foreach (var item in viewModel.GRIDReceiptMaterialsGridList)
                {
                    var receiptMaterialsImported = (ReceiptMaterial)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)receiptMaterialsImported).IsDeleted)
                        continue;
                    receiptMaterialsImported.Receipt = receipt;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(receipt);
            PostScript_ReceiptForm(viewModel, receipt, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(receipt);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(receipt);
            AfterContextSaveScript_ReceiptForm(viewModel, receipt, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ReceiptForm(ReceiptFormViewModel viewModel, Receipt receipt, TTObjectContext objectContext);
    partial void PostScript_ReceiptForm(ReceiptFormViewModel viewModel, Receipt receipt, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ReceiptForm(ReceiptFormViewModel viewModel, Receipt receipt, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ReceiptFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GRIDReceiptProceduresGridList = viewModel._Receipt.ReceiptProcedures.OfType<ReceiptProcedure>().ToArray();
        viewModel.GRIDReceiptMaterialsGridList = viewModel._Receipt.ReceiptMaterials.OfType<ReceiptMaterial>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.ReceiptDocuments = objectContext.LocalQuery<ReceiptDocument>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.CashierLogs = objectContext.LocalQuery<CashierLog>().ToArray();
        viewModel.DiscountTypeDefinitions = objectContext.LocalQuery<DiscountTypeDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DiscountTypeListDefinition", viewModel.DiscountTypeDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class ReceiptFormViewModel : BaseViewModel
    {
        public TTObjectClasses.Receipt _Receipt { get; set; }
        public TTObjectClasses.ReceiptProcedure[] GRIDReceiptProceduresGridList { get; set; }
        public TTObjectClasses.ReceiptMaterial[] GRIDReceiptMaterialsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.ReceiptDocument[] ReceiptDocuments { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.CashierLog[] CashierLogs { get; set; }
        public TTObjectClasses.DiscountTypeDefinition[] DiscountTypeDefinitions { get; set; }
    }
}
