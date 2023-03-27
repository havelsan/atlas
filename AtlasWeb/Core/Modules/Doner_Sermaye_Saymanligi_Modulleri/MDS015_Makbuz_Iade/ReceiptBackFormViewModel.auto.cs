//$BEB7C85F
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
    public partial class ReceiptBackServiceController : Controller
{
    [HttpGet]
    public ReceiptBackFormViewModel ReceiptBackForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return ReceiptBackFormLoadInternal(input);
    }

    [HttpPost]
    public ReceiptBackFormViewModel ReceiptBackFormLoad(FormLoadInput input)
    {
        return ReceiptBackFormLoadInternal(input);
    }

    private ReceiptBackFormViewModel ReceiptBackFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("fc345e2b-890b-49b5-9b52-e05c84b1b937");
        var objectDefID = Guid.Parse("2332794c-f5e7-4828-91f2-068d327b9b45");
        var viewModel = new ReceiptBackFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ReceiptBack = objectContext.GetObject(id.Value, objectDefID) as ReceiptBack;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReceiptBack, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReceiptBack, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ReceiptBack);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ReceiptBack);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ReceiptBackForm(viewModel, viewModel._ReceiptBack, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._ReceiptBack = new ReceiptBack(objectContext);
                var entryStateID = Guid.Parse("1c3e4ccf-3546-407e-8b1e-a910eeba8188");
                viewModel._ReceiptBack.CurrentStateDefID = entryStateID;
                viewModel.GRIDReceiptBackDetailsGridList = new TTObjectClasses.ReceiptBackDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ReceiptBack, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReceiptBack, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ReceiptBack);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ReceiptBack);
                PreScript_ReceiptBackForm(viewModel, viewModel._ReceiptBack, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel ReceiptBackForm(ReceiptBackFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("fc345e2b-890b-49b5-9b52-e05c84b1b937");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.ReceiptBackDocuments);
            objectContext.AddToRawObjectList(viewModel.CashierLogs);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Receipts);
            objectContext.AddToRawObjectList(viewModel.GRIDReceiptBackDetailsGridList);
            var entryStateID = Guid.Parse("1c3e4ccf-3546-407e-8b1e-a910eeba8188");
            objectContext.AddToRawObjectList(viewModel._ReceiptBack, entryStateID);
            objectContext.ProcessRawObjects(false);
            var receiptBack = (ReceiptBack)objectContext.GetLoadedObject(viewModel._ReceiptBack.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(receiptBack, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ReceiptBack, formDefID);
            if (viewModel.GRIDReceiptBackDetailsGridList != null)
            {
                foreach (var item in viewModel.GRIDReceiptBackDetailsGridList)
                {
                    var receiptBackDetailsImported = (ReceiptBackDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)receiptBackDetailsImported).IsDeleted)
                        continue;
                    receiptBackDetailsImported.ReceiptBack = receiptBack;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(receiptBack);
            PostScript_ReceiptBackForm(viewModel, receiptBack, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(receiptBack);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(receiptBack);
            AfterContextSaveScript_ReceiptBackForm(viewModel, receiptBack, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_ReceiptBackForm(ReceiptBackFormViewModel viewModel, ReceiptBack receiptBack, TTObjectContext objectContext);
    partial void PostScript_ReceiptBackForm(ReceiptBackFormViewModel viewModel, ReceiptBack receiptBack, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_ReceiptBackForm(ReceiptBackFormViewModel viewModel, ReceiptBack receiptBack, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(ReceiptBackFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.GRIDReceiptBackDetailsGridList = viewModel._ReceiptBack.ReceiptBackDetails.OfType<ReceiptBackDetail>().ToArray();
        viewModel.ReceiptBackDocuments = objectContext.LocalQuery<ReceiptBackDocument>().ToArray();
        viewModel.CashierLogs = objectContext.LocalQuery<CashierLog>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Receipts = objectContext.LocalQuery<Receipt>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ReceiptListDefinition", viewModel.Receipts);
    }
}
}


namespace Core.Models
{
    public partial class ReceiptBackFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ReceiptBack _ReceiptBack { get; set; }
        public TTObjectClasses.ReceiptBackDetail[] GRIDReceiptBackDetailsGridList { get; set; }
        public TTObjectClasses.ReceiptBackDocument[] ReceiptBackDocuments { get; set; }
        public TTObjectClasses.CashierLog[] CashierLogs { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Receipt[] Receipts { get; set; }
    }
}
