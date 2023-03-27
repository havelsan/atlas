//$92D3A65F
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
    public DrugReturnActionCompletedFormViewModel DrugReturnActionCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return DrugReturnActionCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public DrugReturnActionCompletedFormViewModel DrugReturnActionCompletedFormLoad(FormLoadInput input)
    {
        return DrugReturnActionCompletedFormLoadInternal(input);
    }

    private DrugReturnActionCompletedFormViewModel DrugReturnActionCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("ff97db11-bf91-416b-b6dc-525d6c78f530");
        var objectDefID = Guid.Parse("e8038335-a8b1-4149-bfac-7c12007eca1a");
        var viewModel = new DrugReturnActionCompletedFormViewModel();
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
                PreScript_DrugReturnActionCompletedForm(viewModel, viewModel._DrugReturnAction, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel DrugReturnActionCompletedForm(DrugReturnActionCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("ff97db11-bf91-416b-b6dc-525d6c78f530");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Episodes);
            objectContext.AddToRawObjectList(viewModel.Patients);
            objectContext.AddToRawObjectList(viewModel.PharmacyStoreDefinitions);
            objectContext.AddToRawObjectList(viewModel.DrugOrderTransactions);
            objectContext.AddToRawObjectList(viewModel.DrugOrders);
            objectContext.AddToRawObjectList(viewModel.Materials);
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
            PostScript_DrugReturnActionCompletedForm(viewModel, drugReturnAction, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(drugReturnAction);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(drugReturnAction);
            AfterContextSaveScript_DrugReturnActionCompletedForm(viewModel, drugReturnAction, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_DrugReturnActionCompletedForm(DrugReturnActionCompletedFormViewModel viewModel, DrugReturnAction drugReturnAction, TTObjectContext objectContext);
    partial void PostScript_DrugReturnActionCompletedForm(DrugReturnActionCompletedFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_DrugReturnActionCompletedForm(DrugReturnActionCompletedFormViewModel viewModel, DrugReturnAction drugReturnAction, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(DrugReturnActionCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DrugReturnActionDetailsGridList = viewModel._DrugReturnAction.DrugReturnActionDetails.OfType<DrugReturnActionDetail>().ToArray();
        viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        viewModel.PharmacyStoreDefinitions = objectContext.LocalQuery<Store>().ToArray();
        viewModel.DrugOrderTransactions = objectContext.LocalQuery<DrugOrderTransaction>().ToArray();
        viewModel.DrugOrders = objectContext.LocalQuery<DrugOrder>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PharmacyStoreList", viewModel.PharmacyStoreDefinitions);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DrugList", viewModel.Materials);
    }
}
}


namespace Core.Models
{
    public partial class DrugReturnActionCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.DrugReturnAction _DrugReturnAction { get; set; }
        public TTObjectClasses.DrugReturnActionDetail[] DrugReturnActionDetailsGridList { get; set; }
        public TTObjectClasses.Episode[] Episodes { get; set; }
        public TTObjectClasses.Patient[] Patients { get; set; }
        public TTObjectClasses.Store[] PharmacyStoreDefinitions { get; set; }
        public TTObjectClasses.DrugOrderTransaction[] DrugOrderTransactions { get; set; }
        public TTObjectClasses.DrugOrder[] DrugOrders { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
    }
}
