//$99073253
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
    public partial class SubStoreStockTransferServiceController : Controller
{
    [HttpGet]
    public SubStoreStockTransferComplatedFormViewModel SubStoreStockTransferComplatedForm(Guid? id)
    {
        var input = new FormLoadInput();
        input.Id = id;
        return SubStoreStockTransferComplatedFormLoadInternal(input);
    }

    [HttpPost]
    public SubStoreStockTransferComplatedFormViewModel SubStoreStockTransferComplatedFormLoad(FormLoadInput input)
    {
        return SubStoreStockTransferComplatedFormLoadInternal(input);
    }

    private SubStoreStockTransferComplatedFormViewModel SubStoreStockTransferComplatedFormLoadInternal(FormLoadInput input)
    {
        Guid? id = input.Id;
        var formDefID = Guid.Parse("713e4e6c-7a1e-4e8f-aaff-7d7a78c00567");
        var objectDefID = Guid.Parse("4bcc82dc-5d81-463f-82cd-f7c327ca01ea");
        var viewModel = new SubStoreStockTransferComplatedFormViewModel();
        viewModel.ActiveIDsModel = input.Model;
        if (id.HasValue && id.Value != Guid.Empty)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._SubStoreStockTransfer = objectContext.GetObject(id.Value, objectDefID) as SubStoreStockTransfer;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._SubStoreStockTransfer, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubStoreStockTransfer, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._SubStoreStockTransfer);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._SubStoreStockTransfer);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_SubStoreStockTransferComplatedForm(viewModel, viewModel._SubStoreStockTransfer, objectContext);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        return viewModel;
    }

    [HttpPost]
    public BaseViewModel SubStoreStockTransferComplatedForm(SubStoreStockTransferComplatedFormViewModel viewModel)
    {
        var retViewModel = new BaseViewModel();
        var formDefID = Guid.Parse("713e4e6c-7a1e-4e8f-aaff-7d7a78c00567");
        using (var objectContext = new TTObjectContext(false))
        {
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel.SubStoreStockTransferMaterialsGridList);
            objectContext.AddToRawObjectList(viewModel._SubStoreStockTransfer);
            objectContext.ProcessRawObjects();
            var subStoreStockTransfer = (SubStoreStockTransfer)objectContext.GetLoadedObject(viewModel._SubStoreStockTransfer.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(subStoreStockTransfer, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._SubStoreStockTransfer, formDefID);
            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = subStoreStockTransfer;
                }
            }

            if (viewModel.SubStoreStockTransferMaterialsGridList != null)
            {
                foreach (var item in viewModel.SubStoreStockTransferMaterialsGridList)
                {
                    var subStoreStockTransferMaterialsImported = (SubStoreStockTransferMat)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)subStoreStockTransferMaterialsImported).IsDeleted)
                        continue;
                    subStoreStockTransferMaterialsImported.StockAction = subStoreStockTransfer;
                }
            }

            var transDef = subStoreStockTransfer.TransDef;
            PostScript_SubStoreStockTransferComplatedForm(viewModel, subStoreStockTransfer, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(subStoreStockTransfer);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(subStoreStockTransfer);
            AfterContextSaveScript_SubStoreStockTransferComplatedForm(viewModel, subStoreStockTransfer, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
        }

        return retViewModel;
    }

    partial void PreScript_SubStoreStockTransferComplatedForm(SubStoreStockTransferComplatedFormViewModel viewModel, SubStoreStockTransfer subStoreStockTransfer, TTObjectContext objectContext);
    partial void PostScript_SubStoreStockTransferComplatedForm(SubStoreStockTransferComplatedFormViewModel viewModel, SubStoreStockTransfer subStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    partial void AfterContextSaveScript_SubStoreStockTransferComplatedForm(SubStoreStockTransferComplatedFormViewModel viewModel, SubStoreStockTransfer subStoreStockTransfer, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
    void ContextToViewModel(SubStoreStockTransferComplatedFormViewModel viewModel, TTObjectContext objectContext)
    {
        viewModel.StockActionSignDetailsGridList = viewModel._SubStoreStockTransfer.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
        viewModel.SubStoreStockTransferMaterialsGridList = viewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials.OfType<SubStoreStockTransferMat>().ToArray();
        viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
        viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
        viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
        viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
        viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SubStoreList", viewModel.Stores);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
        ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
    }
}
}


namespace Core.Models
{
    public partial class SubStoreStockTransferComplatedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.SubStoreStockTransfer _SubStoreStockTransfer { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.SubStoreStockTransferMat[] SubStoreStockTransferMaterialsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
    }
}
