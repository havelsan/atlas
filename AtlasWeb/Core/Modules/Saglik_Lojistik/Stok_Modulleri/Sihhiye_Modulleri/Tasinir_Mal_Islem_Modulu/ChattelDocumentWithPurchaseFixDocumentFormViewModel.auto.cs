//$1A607FA5
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class ChattelDocumentWithPurchaseServiceController : Controller
    {
        [HttpGet]
        public ChattelDocumentWithPurchaseFixDocumentFormViewModel ChattelDocumentWithPurchaseFixDocumentForm(Guid? id)
        {
            var formDefID = Guid.Parse("c4e5be97-0080-4fcf-b194-dce8d6533430");
            var objectDefID = Guid.Parse("3799bd27-4d89-4cd5-83e3-7aea9801138e");
            var viewModel = new ChattelDocumentWithPurchaseFixDocumentFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentWithPurchase = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentWithPurchase;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentWithPurchase);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentWithPurchase);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PreScript_ChattelDocumentWithPurchaseFixDocumentForm(viewModel, viewModel._ChattelDocumentWithPurchase, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChattelDocumentWithPurchaseFixDocumentForm(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ChattelDocumentWithPurchaseFixDocumentFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ChattelDocumentWithPurchaseFixDocumentFormInternal(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("c4e5be97-0080-4fcf-b194-dce8d6533430");
            objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.Stores);
            objectContext.AddToRawObjectList(viewModel.Suppliers);
            objectContext.AddToRawObjectList(viewModel.Materials);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
            objectContext.AddToRawObjectList(viewModel.DemandDetails);
            objectContext.AddToRawObjectList(viewModel.Demands);
            objectContext.AddToRawObjectList(viewModel.ResSections);
            objectContext.AddToRawObjectList(viewModel.ResUsers);
            objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithPurchaseGridList);
            objectContext.AddToRawObjectList(viewModel.DemandAmountsGridGridList);
            objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
            objectContext.AddToRawObjectList(viewModel._ChattelDocumentWithPurchase);
            objectContext.AddToRawObjectList(viewModel.PTSStockActionDetails);
            objectContext.ProcessRawObjects();

            var chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)objectContext.GetLoadedObject(viewModel._ChattelDocumentWithPurchase.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentWithPurchase, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);

            if (viewModel.PTSStockActionDetails != null)
            {
                foreach (var item in viewModel.PTSStockActionDetails)
                {
                    var ptsStockActionDetailsImported = (PTSStockActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)ptsStockActionDetailsImported).IsDeleted)
                        continue;
                    ptsStockActionDetailsImported.StockAction = chattelDocumentWithPurchase;
                    foreach (StockActionDetail detail in ptsStockActionDetailsImported.StockActionDetails)
                    {
                        ChattelDocumentDetailWithPurchase det = (ChattelDocumentDetailWithPurchase)detail;
                        det.DiscountAmount = ptsStockActionDetailsImported.DiscountAmount / detail.Amount.Value;
                        det.DiscountRate = ptsStockActionDetailsImported.DiscountRate;
                        det.LotNo = ptsStockActionDetailsImported.LotNo;
                        det.NotDiscountedUnitPrice = ptsStockActionDetailsImported.NotDiscountedUnitPrice / detail.Amount.Value;
                        det.TotalDiscountAmount = ptsStockActionDetailsImported.TotalDiscountAmount / detail.Amount.Value;
                        det.TotalPriceNotDiscount = ptsStockActionDetailsImported.TotalPriceNotDiscount;
                        det.UnitPrice = ptsStockActionDetailsImported.UnitPrice;
                        //det.UnitPriceWithInVat = ptsStockActionDetailsImported.UnitPriceWithInVat;
                        //det.UnitPriceWithOutVat = ptsStockActionDetailsImported.UnitPriceWithOutVat;
                        det.VatRate = ptsStockActionDetailsImported.VatRate;
                    }
                }
            }
            else
            {
                if (viewModel.ChattelDocumentDetailsWithPurchaseGridList != null)
                {
                    foreach (var item in viewModel.ChattelDocumentDetailsWithPurchaseGridList)
                    {
                        var chattelDocumentDetailsWithPurchaseImported = (ChattelDocumentDetailWithPurchase)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)chattelDocumentDetailsWithPurchaseImported).IsDeleted)
                            continue;
                        chattelDocumentDetailsWithPurchaseImported.StockAction = chattelDocumentWithPurchase;
                    }
                }
            }

            if (viewModel.DemandAmountsGridGridList != null)
            {
                foreach (var item in viewModel.DemandAmountsGridGridList)
                {
                    var chattelDocumentDistributionsImported = (ChattelDocumentDistribution)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)chattelDocumentDistributionsImported).IsDeleted)
                        continue;
                    chattelDocumentDistributionsImported.ChattelDocumentWithPurchase = chattelDocumentWithPurchase;
                }
            }

            if (viewModel.StockActionSignDetailsGridList != null)
            {
                foreach (var item in viewModel.StockActionSignDetailsGridList)
                {
                    var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                        continue;
                    stockActionSignDetailsImported.StockAction = chattelDocumentWithPurchase;
                }
            }
            var transDef = chattelDocumentWithPurchase.TransDef;
            PostScript_ChattelDocumentWithPurchaseFixDocumentForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentWithPurchase);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentWithPurchase);
            AfterContextSaveScript_ChattelDocumentWithPurchaseFixDocumentForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ChattelDocumentWithPurchaseFixDocumentForm(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTObjectContext objectContext);
        partial void PostScript_ChattelDocumentWithPurchaseFixDocumentForm(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseFixDocumentForm(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ChattelDocumentWithPurchaseFixDocumentFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ChattelDocumentDetailsWithPurchaseGridList = viewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.OfType<ChattelDocumentDetailWithPurchase>().ToArray();
            viewModel.DemandAmountsGridGridList = viewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions.OfType<ChattelDocumentDistribution>().ToArray();
            viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentWithPurchase.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            viewModel.DemandDetails = objectContext.LocalQuery<DemandDetail>().ToArray();
            viewModel.Demands = objectContext.LocalQuery<Demand>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.PTSStockActionDetails = viewModel._ChattelDocumentWithPurchase.PTSStockActionDetails.OfType<PTSStockActionDetail>().ToArray();
            if (viewModel.PTSStockActionDetails.Length > 0)
            {
                List<PTSMaterial> ptsList = new List<PTSMaterial>();
                int id = 1;
                foreach (PTSStockActionDetail ptsDetail in viewModel.PTSStockActionDetails)
                {
                    PTSMaterial ptsMaterial = new PTSMaterial();
                    ptsMaterial.amount = (double)ptsDetail.Amount;
                    ptsMaterial.barcode = ptsDetail.Material.Barcode;
                    ptsMaterial.DiscountAmount = ptsDetail.DiscountAmount;
                    ptsMaterial.DiscountRate = ptsDetail.DiscountRate;
                    ptsMaterial.DistributionTypeName = ptsDetail.Material.StockCard.DistributionType.DistributionType;
                    ptsMaterial.expirationDate = ptsDetail.ExpirationDate.Value;
                    ptsMaterial.ID = id;
                    id = id + 1;
                    ptsMaterial.lotNO = ptsDetail.LotNo;
                    ptsMaterial.material = ptsDetail.Material;
                    ptsMaterial.materialName = ptsDetail.Material.Name;
                    ptsMaterial.materialObjectID = ptsDetail.Material.ObjectID;
                    ptsMaterial.NatoStockNo = ptsDetail.Material.StockCard.NATOStockNO;
                    ptsMaterial.ProductionDate = ptsDetail.ProductionDate;
                    ptsMaterial.RetrievalYear = ptsDetail.RetrievalYear;
                    ptsMaterial.UnitPriceWithInVat = ((ChattelDocumentDetailWithPurchase)ptsDetail.StockActionDetails.Select(string.Empty)[0]).UnitPriceWithInVat;
                    ptsMaterial.UnitPriceWithOutVat = ((ChattelDocumentDetailWithPurchase)ptsDetail.StockActionDetails.Select(string.Empty)[0]).UnitPriceWithOutVat;
                    ptsMaterial.VatRate = ptsDetail.VatRate;
                    ptsMaterial.price = (double)ptsDetail.UnitPrice * ptsDetail.Amount;
                    ptsMaterial.UnitPrice = ptsDetail.UnitPrice;
                    ptsMaterial.PTSStockActionDetail = ptsDetail;
                    ptsMaterial.serialNOList = new List<PTSMaterialSerialNumber>();
                    foreach (StockActionDetail detail in ptsDetail.StockActionDetails)
                    {
                        PTSMaterialSerialNumber serialNumber = new PTSMaterialSerialNumber();
                        serialNumber.amount = (double)detail.Amount;
                        serialNumber.serialNo = detail.SerialNo;
                        ptsMaterial.serialNOList.Add(serialNumber);
                    }
                    ptsList.Add(ptsMaterial);
                }
                viewModel.PTSMaterials = ptsList.ToArray();
            }
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class ChattelDocumentWithPurchaseFixDocumentFormViewModel
    {
        public TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase { get; set; }
        public TTObjectClasses.ChattelDocumentDetailWithPurchase[] ChattelDocumentDetailsWithPurchaseGridList { get; set; }
        public TTObjectClasses.ChattelDocumentDistribution[] DemandAmountsGridGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Supplier[] Suppliers { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.DemandDetail[] DemandDetails { get; set; }
        public TTObjectClasses.Demand[] Demands { get; set; }
        public TTObjectClasses.ResSection[] ResSections { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.PTSStockActionDetail[] PTSStockActionDetails { get; set; }
        public PTSMaterial[] PTSMaterials { get; set; }
    }
}
