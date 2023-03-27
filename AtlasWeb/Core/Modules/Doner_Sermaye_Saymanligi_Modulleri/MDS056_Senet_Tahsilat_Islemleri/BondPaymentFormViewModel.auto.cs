//$0709B83F
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
    public partial class BondPaymentServiceController : Controller
{
    [HttpGet]
    public BondPaymentFormViewModel BondPaymentForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return BondPaymentFormLoadInternal(input);
    }

    [HttpPost]
    public BondPaymentFormViewModel BondPaymentFormLoad(FormLoadInput input)
    {
        return BondPaymentFormLoadInternal(input);
    }

    private BondPaymentFormViewModel BondPaymentFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("82db744f-7001-4058-8b3f-0faa39699783");
        var objectDefID = Guid.Parse("f404c7c1-510d-4f12-a9f3-b9b8e3cc2c35");
        var viewModel = new BondPaymentFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BondPayment = objectContext.GetObject(id.Value, objectDefID) as BondPayment;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BondPayment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BondPayment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._BondPayment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._BondPayment);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_BondPaymentForm(viewModel, viewModel._BondPayment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }
        else
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._BondPayment = new BondPayment(objectContext);
                var entryStateID = Guid.Parse("d10e709b-fb87-4e56-b79c-25d6e266df53");
                viewModel._BondPayment.CurrentStateDefID = entryStateID;
                viewModel.ttgrid1GridList = new TTObjectClasses.BondPaymentDetail[]{};
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._BondPayment, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BondPayment, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._BondPayment);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._BondPayment);
                PreScript_BondPaymentForm(viewModel, viewModel._BondPayment, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel BondPaymentForm(BondPaymentFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("82db744f-7001-4058-8b3f-0faa39699783");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.BondPaymentDocuments);
            objectContext.AddToRawObjectList(viewModel.CashOfficeDefinitions);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.BankDecounts);
            objectContext.AddToRawObjectList(viewModel.BankAccountDefinitions);
            objectContext.AddToRawObjectList(viewModel.ttgrid1GridList);
            var entryStateID = Guid.Parse("d10e709b-fb87-4e56-b79c-25d6e266df53");
            objectContext.AddToRawObjectList(viewModel._BondPayment, entryStateID);
            objectContext.ProcessRawObjects(false);
            var bondPayment = (BondPayment)objectContext.GetLoadedObject(viewModel._BondPayment.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(bondPayment, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._BondPayment, formDefID);
            if (viewModel.ttgrid1GridList != null)
            {
                foreach (var item in viewModel.ttgrid1GridList)
                {
                    var bondPaymentDetailsImported = (BondPaymentDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)bondPaymentDetailsImported).IsDeleted)
                        continue;
                    bondPaymentDetailsImported.BondPayment = bondPayment;
                }
            }

            var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(bondPayment);
            PostScript_BondPaymentForm(viewModel, bondPayment, transDef, objectContext);
            objectContext.AdvanceStateForNewObjects();
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(bondPayment);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(bondPayment);
            AfterContextSaveScript_BondPaymentForm(viewModel, bondPayment, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_BondPaymentForm(BondPaymentFormViewModel viewModel, BondPayment bondPayment, TTObjectContext objectContext);
    partial void PostScript_BondPaymentForm(BondPaymentFormViewModel viewModel, BondPayment bondPayment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_BondPaymentForm(BondPaymentFormViewModel viewModel, BondPayment bondPayment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(BondPaymentFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.ttgrid1GridList = viewModel._BondPayment.BondPaymentDetails.OfType<BondPaymentDetail>().ToArray();
        viewModel.BondPaymentDocuments = objectContext.LocalQuery<BondPaymentDocument>().ToArray();
        viewModel.CashOfficeDefinitions = objectContext.LocalQuery<CashOfficeDefinition>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.BankDecounts = objectContext.LocalQuery<BankDecount>().ToArray();
        viewModel.BankAccountDefinitions = objectContext.LocalQuery<BankAccountDefinition>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BankAccountListDefinition", viewModel.BankAccountDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class BondPaymentFormViewModel : BaseViewModel
    {
        public TTObjectClasses.BondPayment _BondPayment { get; set; }
        public TTObjectClasses.BondPaymentDetail[] ttgrid1GridList { get; set; }
        public TTObjectClasses.BondPaymentDocument[] BondPaymentDocuments { get; set; }
        public TTObjectClasses.CashOfficeDefinition[] CashOfficeDefinitions { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.BankDecount[] BankDecounts { get; set; }
        public TTObjectClasses.BankAccountDefinition[] BankAccountDefinitions { get; set; }
    }
}
