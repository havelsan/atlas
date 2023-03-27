//$D24F8763
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
    public partial class MainStoreStockTransferServiceController : Controller
{
    [HttpGet]
    public MainStoreStockTransferCompletedFormViewModel MainStoreStockTransferCompletedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return MainStoreStockTransferCompletedFormLoadInternal(input);
    }

    [HttpPost]
    public MainStoreStockTransferCompletedFormViewModel MainStoreStockTransferCompletedFormLoad(FormLoadInput input)
    {
        return MainStoreStockTransferCompletedFormLoadInternal(input);
    }

    private MainStoreStockTransferCompletedFormViewModel MainStoreStockTransferCompletedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("720f96e4-961e-4af2-885a-ba80919823d5");
        var objectDefID = Guid.Parse("2e411643-ae98-4235-bb26-517909d043a6");
        var viewModel = new MainStoreStockTransferCompletedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._MainStoreStockTransfer = objectContext.GetObject(id.Value, objectDefID) as MainStoreStockTransfer;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._MainStoreStockTransfer, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreStockTransfer, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._MainStoreStockTransfer);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._MainStoreStockTransfer);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_MainStoreStockTransferCompletedForm(viewModel, viewModel._MainStoreStockTransfer, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel MainStoreStockTransferCompletedForm(MainStoreStockTransferCompletedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("720f96e4-961e-4af2-885a-ba80919823d5");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.MainStoreStockTransferMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel._MainStoreStockTransfer);
            objectContext.ProcessRawObjects();
            var mainStoreStockTransfer = (MainStoreStockTransfer)objectContext.GetLoadedObject(viewModel._MainStoreStockTransfer.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(mainStoreStockTransfer, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._MainStoreStockTransfer, formDefID);
            if (viewModel.DocumentRecordLogsGridList != null)
            {
                foreach (var item in viewModel.DocumentRecordLogsGridList)
                {
                    var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)documentRecordLogsImported).IsDeleted)
                        continue;
                    documentRecordLogsImported.StockAction = mainStoreStockTransfer;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = mainStoreStockTransfer;
                }
            }

            if (viewModel.MainStoreStockTransferMaterialsGridList != null)
            {
                foreach (var item in viewModel.MainStoreStockTransferMaterialsGridList)
                {
                    var mainStoreStockTransferMatsImported = (MainStoreStockTransferMat)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)mainStoreStockTransferMatsImported).IsDeleted)
                        continue;
                    mainStoreStockTransferMatsImported.StockAction = mainStoreStockTransfer;
                }
            }

            var transDef = mainStoreStockTransfer.TransDef;
            PostScript_MainStoreStockTransferCompletedForm(viewModel, mainStoreStockTransfer, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(mainStoreStockTransfer);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(mainStoreStockTransfer);
            AfterContextSaveScript_MainStoreStockTransferCompletedForm(viewModel, mainStoreStockTransfer, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_MainStoreStockTransferCompletedForm(MainStoreStockTransferCompletedFormViewModel viewModel, MainStoreStockTransfer mainStoreStockTransfer, TTObjectContext objectContext);
    partial void PostScript_MainStoreStockTransferCompletedForm(MainStoreStockTransferCompletedFormViewModel viewModel, MainStoreStockTransfer mainStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_MainStoreStockTransferCompletedForm(MainStoreStockTransferCompletedFormViewModel viewModel, MainStoreStockTransfer mainStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(MainStoreStockTransferCompletedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.DocumentRecordLogsGridList = viewModel._MainStoreStockTransfer.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
        viewModel.StockActionSignDetailsGridList = viewModel._MainStoreStockTransfer.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.MainStoreStockTransferMaterialsGridList = viewModel._MainStoreStockTransfer.MainStoreStockTransferMats.OfType<MainStoreStockTransferMat>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
    }
}
}


namespace Core.Models
{
    public partial class MainStoreStockTransferCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.MainStoreStockTransfer _MainStoreStockTransfer { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.MainStoreStockTransferMat[] MainStoreStockTransferMaterialsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
    }
}
