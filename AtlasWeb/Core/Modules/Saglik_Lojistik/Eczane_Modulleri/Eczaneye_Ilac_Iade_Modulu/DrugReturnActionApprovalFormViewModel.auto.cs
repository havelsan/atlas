//$C2B6323E
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
    public partial class DrugReturnActionServiceController : Controller
{
    [HttpGet]
    public DrugReturnActionApprovalFormViewModel DrugReturnActionApprovalForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DrugReturnActionApprovalFormLoadInternal(input);
    }

    [HttpPost]
    public DrugReturnActionApprovalFormViewModel DrugReturnActionApprovalFormLoad(FormLoadInput input)
    {
        return DrugReturnActionApprovalFormLoadInternal(input);
    }

    private DrugReturnActionApprovalFormViewModel DrugReturnActionApprovalFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("1d99ab6d-bb65-4e01-8b07-3873b08a0ec0");
        var objectDefID = Guid.Parse("e8038335-a8b1-4149-bfac-7c12007eca1a");
        var viewModel = new DrugReturnActionApprovalFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._DrugReturnAction = objectContext.GetObject(id.Value, objectDefID) as DrugReturnAction;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._DrugReturnAction, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugReturnAction, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._DrugReturnAction);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._DrugReturnAction);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_DrugReturnActionApprovalForm(viewModel, viewModel._DrugReturnAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("1d99ab6d-bb65-4e01-8b07-3873b08a0ec0");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.DrugOrderTransactions);
            objectContext.AddToRawObjectList(viewModel.DrugOrders);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.PharmacyStoreDefinitions);
            objectContext.AddToRawObjectList(viewModel.DrugReturnActionDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._DrugReturnAction);
            objectContext.ProcessRawObjects();
            var drugReturnAction = (DrugReturnAction)objectContext.GetLoadedObject(viewModel._DrugReturnAction.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(drugReturnAction, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._DrugReturnAction, formDefID);
            if (viewModel.DrugReturnActionDetailsGridList != null)
            {
                foreach (var item in viewModel.DrugReturnActionDetailsGridList)
                {
                    var drugReturnActionDetailsImported = (DrugReturnActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)drugReturnActionDetailsImported).IsDeleted)
                        continue;
                    drugReturnActionDetailsImported.DrugReturnAction = drugReturnAction;
                }
            }

            var transDef = drugReturnAction.TransDef;
            PostScript_DrugReturnActionApprovalForm(viewModel, drugReturnAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugReturnAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugReturnAction);
            AfterContextSaveScript_DrugReturnActionApprovalForm(viewModel, drugReturnAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel, DrugReturnAction drugReturnAction, TTObjectContext objectContext);
    partial void PostScript_DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DrugReturnActionApprovalForm(DrugReturnActionApprovalFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DrugReturnActionApprovalFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DrugReturnActionDetailsGridList = viewModel._DrugReturnAction.DrugReturnActionDetails.OfType<DrugReturnActionDetail>().ToArray();
        viewModel.DrugOrderTransactions = objectContext.LocalQuery<DrugOrderTransaction>().ToArray();
        viewModel.DrugOrders = objectContext.LocalQuery<DrugOrder>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.PharmacyStoreDefinitions = objectContext.LocalQuery<Store>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PharmacyStoreList", viewModel.PharmacyStoreDefinitions);
    }
}
}


namespace Core.Models
{
    public partial class DrugReturnActionApprovalFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DrugReturnAction _DrugReturnAction { get; set; }
        public TTObjectClasses.DrugReturnActionDetail[] DrugReturnActionDetailsGridList { get; set; }
        public TTObjectClasses.DrugOrderTransaction[] DrugOrderTransactions { get; set; }
        public TTObjectClasses.DrugOrder[] DrugOrders { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Store[] PharmacyStoreDefinitions { get; set; }
    }
}
