//$19FF7E7B
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
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ChattelDocumentWithPurchaseServiceController : Controller
    {
        [HttpGet]
        public ChattelDocumentWithPurchaseNewFormViewModel ChattelDocumentWithPurchaseNewForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ChattelDocumentWithPurchaseNewFormLoadInternal(input);
        }

        [HttpPost]
        public ChattelDocumentWithPurchaseNewFormViewModel ChattelDocumentWithPurchaseNewFormLoad(FormLoadInput input)
        {
            return ChattelDocumentWithPurchaseNewFormLoadInternal(input);
        }

        private ChattelDocumentWithPurchaseNewFormViewModel ChattelDocumentWithPurchaseNewFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("785431bb-d582-4129-8385-cc5ec764a9b9");
            var objectDefID = Guid.Parse("3799bd27-4d89-4cd5-83e3-7aea9801138e");
            var viewModel = new ChattelDocumentWithPurchaseNewFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
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
                    PreScript_ChattelDocumentWithPurchaseNewForm(viewModel, viewModel._ChattelDocumentWithPurchase, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentWithPurchase = new ChattelDocumentWithPurchase(objectContext);
                    var entryStateID = Guid.Parse("53e407a6-c41b-41c5-ab73-21fe0850802e");
                    viewModel._ChattelDocumentWithPurchase.CurrentStateDefID = entryStateID;
                    viewModel.OrderedSuppliersGridGridList = new TTObjectClasses.TmpOrderedSupplier[] { };
                    viewModel.OrderedDetailsGridList = new TTObjectClasses.TmpOrderedDetail[] { };
                    viewModel.ChattelDocumentDetailsWithPurchaseGridList = new TTObjectClasses.ChattelDocumentDetailWithPurchase[] { };
                    viewModel.PTSStockActionDetails = new TTObjectClasses.PTSStockActionDetail[] { };
                    viewModel.DemandAmountsGridGridList = new TTObjectClasses.ChattelDocumentDistribution[] { };
                    viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChattelDocumentWithPurchase);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChattelDocumentWithPurchase);
                    PreScript_ChattelDocumentWithPurchaseNewForm(viewModel, viewModel._ChattelDocumentWithPurchase, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("785431bb-d582-4129-8385-cc5ec764a9b9");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.PurchaseOrders);
                objectContext.AddToRawObjectList(viewModel.Suppliers);
                objectContext.AddToRawObjectList(viewModel.PurchaseOrderDetails);
                objectContext.AddToRawObjectList(viewModel.PurchaseItemDefs);
                objectContext.AddToRawObjectList(viewModel.PurchaseProjectDetails);
                objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
                objectContext.AddToRawObjectList(viewModel.DemandDetails);
                objectContext.AddToRawObjectList(viewModel.Demands);
                objectContext.AddToRawObjectList(viewModel.ResSections);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.OrderedSuppliersGridGridList);
                objectContext.AddToRawObjectList(viewModel.OrderedDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithPurchaseGridList);
                objectContext.AddToRawObjectList(viewModel.DemandAmountsGridGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.PTSStockActionDetails);
                var entryStateID = Guid.Parse("53e407a6-c41b-41c5-ab73-21fe0850802e");
                objectContext.AddToRawObjectList(viewModel._ChattelDocumentWithPurchase, entryStateID);
                objectContext.ProcessRawObjects(false);
                var chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)objectContext.GetLoadedObject(viewModel._ChattelDocumentWithPurchase.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentWithPurchase, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);


                /* BindingList<ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class> checkOfDocuments =
                 ChattelDocumentWithPurchase.ControlOfDublicatePurschase(chattelDocumentWithPurchase.Supplier.ObjectID.ToString(), chattelDocumentWithPurchase.Waybill.ToString(), chattelDocumentWithPurchase.Store.ObjectID.ToString());
                 foreach (ChattelDocumentWithPurchase.ControlOfDublicatePurschase_Class item in checkOfDocuments)
                 {
                     StockAction stockaction = objectContext.GetObject<StockAction>(item.ObjectID.Value);
                     AccountingTerm termOfOldPurhace = ((MainStoreDefinition)stockaction.Store).Accountancy.GetOpenAccountingTerm();
                     AccountingTerm termActive = ((MainStoreDefinition)chattelDocumentWithPurchase.Store).Accountancy.GetOpenAccountingTerm();
                     if (termOfOldPurhace == termActive)
                     {
                         throw new Exception("Aynı Fatura Numarası Daha Önce Girilmiştir. İşlem Numarası : " + item.StockActionID);
                     }
                 }*/
                AccountingTerm termActive = ((MainStoreDefinition)chattelDocumentWithPurchase.Store).Accountancy.GetOpenAccountingTerm();
                string filterSql = " SUPPLIER ='" + chattelDocumentWithPurchase.Supplier.ObjectID.ToString() + "' AND WAYBILL ='"
                    + chattelDocumentWithPurchase.Waybill.ToString() + "' AND  STORE = '" + chattelDocumentWithPurchase.Store.ObjectID.ToString() + "' AND CURRENTSTATE NOT IN(STATES.CANCELLED,STATES.NEW)" +
                    " AND ACCOUNTINGTERM = '" + termActive.ObjectID + "'";

                BindingList<ChattelDocumentWithPurchase> checkOfDocuments = objectContext.QueryObjects<ChattelDocumentWithPurchase>(filterSql);
                if (checkOfDocuments.Count > 0)
                {
                    throw new Exception("Aynı Fatura Numarası Daha Önce Girilmiştir.");
                }

               

                if (viewModel.OrderedSuppliersGridGridList != null)
                {
                    foreach (var item in viewModel.OrderedSuppliersGridGridList)
                    {
                        var tmpOrderedSuppliersImported = (TmpOrderedSupplier)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)tmpOrderedSuppliersImported).IsDeleted)
                            continue;
                        tmpOrderedSuppliersImported.ChattelDocumentWithPurchase = chattelDocumentWithPurchase;
                    }
                }

                if (viewModel.OrderedDetailsGridList != null)
                {
                    foreach (var item in viewModel.OrderedDetailsGridList)
                    {
                        var tmpOrderedDetailsImported = (TmpOrderedDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)tmpOrderedDetailsImported).IsDeleted)
                            continue;
                        tmpOrderedDetailsImported.ChattelDocumentWithPurchase = chattelDocumentWithPurchase;
                    }
                }

                if (viewModel.PTSStockActionDetails != null)
                {
                    foreach (var item in viewModel.PTSStockActionDetails)
                    {
                        var ptsStockActionDetailsImported = (PTSStockActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)ptsStockActionDetailsImported).IsDeleted)
                            continue;
                        ptsStockActionDetailsImported.StockAction = chattelDocumentWithPurchase;
                        List<PTSMaterial> findList = viewModel.PTSMaterials.Where(x => x.materialObjectID == ptsStockActionDetailsImported.Material.ObjectID && x.lotNO == ptsStockActionDetailsImported.LotNo
                        && x.expirationDate == ptsStockActionDetailsImported.ExpirationDate).ToList();
                        foreach (PTSMaterial ptsSeriNo in findList)
                        {
                            foreach (PTSMaterialSerialNumber seriNo in ptsSeriNo.serialNOList)
                            {
                                ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase = new ChattelDocumentDetailWithPurchase(objectContext);
                                chattelDocumentDetailWithPurchase.Material = ptsStockActionDetailsImported.Material;
                                chattelDocumentDetailWithPurchase.Amount = seriNo.amount;
                                chattelDocumentDetailWithPurchase.DiscountAmount = ptsStockActionDetailsImported.DiscountAmount / seriNo.amount;
                                chattelDocumentDetailWithPurchase.DiscountRate = ptsStockActionDetailsImported.DiscountRate;
                                chattelDocumentDetailWithPurchase.ExpirationDate = ptsStockActionDetailsImported.ExpirationDate;
                                chattelDocumentDetailWithPurchase.LotNo = ptsStockActionDetailsImported.LotNo;
                                chattelDocumentDetailWithPurchase.NotDiscountedUnitPrice = ptsStockActionDetailsImported.NotDiscountedUnitPrice / seriNo.amount;
                                chattelDocumentDetailWithPurchase.Price = Convert.ToDouble(ptsSeriNo.price) / seriNo.amount;
                                chattelDocumentDetailWithPurchase.ProductionDate = ptsStockActionDetailsImported.ProductionDate;
                                chattelDocumentDetailWithPurchase.PTSStockActionDetail = ptsStockActionDetailsImported;
                                chattelDocumentDetailWithPurchase.RetrievalYear = ptsStockActionDetailsImported.RetrievalYear;
                                chattelDocumentDetailWithPurchase.SerialNo = seriNo.serialNo;
                                chattelDocumentDetailWithPurchase.Status = StockActionDetailStatusEnum.New;
                                chattelDocumentDetailWithPurchase.StockAction = chattelDocumentWithPurchase;
                                chattelDocumentDetailWithPurchase.StockLevelType = StockLevelType.NewStockLevel;
                                chattelDocumentDetailWithPurchase.TotalDiscountAmount = ptsStockActionDetailsImported.TotalDiscountAmount / seriNo.amount;
                                chattelDocumentDetailWithPurchase.TotalPriceNotDiscount = ptsStockActionDetailsImported.TotalPriceNotDiscount;
                                chattelDocumentDetailWithPurchase.UnitPrice = ptsStockActionDetailsImported.UnitPrice;
                                chattelDocumentDetailWithPurchase.UnitPriceWithInVat = ptsSeriNo.UnitPriceWithInVat;
                                chattelDocumentDetailWithPurchase.UnitPriceWithOutVat = ptsSeriNo.UnitPriceWithOutVat;
                                chattelDocumentDetailWithPurchase.VatRate = ptsStockActionDetailsImported.VatRate;
                                chattelDocumentDetailWithPurchase.VoucherDetailRecordNo = ptsStockActionDetailsImported.VoucherDetailRecordNo;
                            }
                        }
                    }
                }

                if (viewModel.ChattelDocumentDetailsWithPurchaseGridList != null)
                {
                    foreach (var item in viewModel.ChattelDocumentDetailsWithPurchaseGridList)
                    {
                        var chattelDocumentDetailsWithPurchaseImported = (ChattelDocumentDetailWithPurchase)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)chattelDocumentDetailsWithPurchaseImported).IsDeleted)
                            continue;
                        chattelDocumentDetailsWithPurchaseImported.StockAction = chattelDocumentWithPurchase;

                        if (chattelDocumentWithPurchase.PTSStockActionDetails.Count > 0)
                        {
                            PTSStockActionDetail findPTS = chattelDocumentWithPurchase.PTSStockActionDetails.Where(x => x.Material == chattelDocumentDetailsWithPurchaseImported.Material && x.LotNo == chattelDocumentDetailsWithPurchaseImported.LotNo
                            && x.ExpirationDate == chattelDocumentDetailsWithPurchaseImported.ExpirationDate).FirstOrDefault();
                            chattelDocumentDetailsWithPurchaseImported.PTSStockActionDetail = findPTS;
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

                if (viewModel._ChattelDocumentWithPurchase.PTSNumber != null)
                    chattelDocumentWithPurchase.PTSNumber = viewModel._ChattelDocumentWithPurchase.PTSNumber;

                if (viewModel._ChattelDocumentWithPurchase.IsPTSAction != null)
                    chattelDocumentWithPurchase.IsPTSAction = viewModel._ChattelDocumentWithPurchase.IsPTSAction;

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(chattelDocumentWithPurchase);
                PostScript_ChattelDocumentWithPurchaseNewForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentWithPurchase);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentWithPurchase);
                AfterContextSaveScript_ChattelDocumentWithPurchaseNewForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTObjectContext objectContext);
        partial void PostScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ChattelDocumentWithPurchaseNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.OrderedSuppliersGridGridList = viewModel._ChattelDocumentWithPurchase.TmpOrderedSuppliers.OfType<TmpOrderedSupplier>().ToArray();
            viewModel.OrderedDetailsGridList = viewModel._ChattelDocumentWithPurchase.TmpOrderedDetails.OfType<TmpOrderedDetail>().ToArray();
            viewModel.ChattelDocumentDetailsWithPurchaseGridList = viewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.OfType<ChattelDocumentDetailWithPurchase>().ToArray();
            viewModel.DemandAmountsGridGridList = viewModel._ChattelDocumentWithPurchase.ChattelDocumentDistributions.OfType<ChattelDocumentDistribution>().ToArray();
            viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentWithPurchase.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.PurchaseOrders = objectContext.LocalQuery<PurchaseOrder>().ToArray();
            viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
            viewModel.PurchaseOrderDetails = objectContext.LocalQuery<PurchaseOrderDetail>().ToArray();
            viewModel.PurchaseItemDefs = objectContext.LocalQuery<PurchaseItemDef>().ToArray();
            viewModel.PurchaseProjectDetails = objectContext.LocalQuery<PurchaseProjectDetail>().ToArray();
            viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            viewModel.DemandDetails = objectContext.LocalQuery<DemandDetail>().ToArray();
            viewModel.Demands = objectContext.LocalQuery<Demand>().ToArray();
            viewModel.ResSections = objectContext.LocalQuery<ResSection>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.PTSStockActionDetails = objectContext.LocalQuery<PTSStockActionDetail>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "PurchaseItemList", viewModel.PurchaseItemDefs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ResourceListDefinition", viewModel.ResSections);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class ChattelDocumentWithPurchaseNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase { get; set; }
        public TTObjectClasses.TmpOrderedSupplier[] OrderedSuppliersGridGridList { get; set; }
        public TTObjectClasses.TmpOrderedDetail[] OrderedDetailsGridList { get; set; }
        public TTObjectClasses.ChattelDocumentDetailWithPurchase[] ChattelDocumentDetailsWithPurchaseGridList { get; set; }
        public TTObjectClasses.ChattelDocumentDistribution[] DemandAmountsGridGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.PurchaseOrder[] PurchaseOrders { get; set; }
        public TTObjectClasses.Supplier[] Suppliers { get; set; }
        public TTObjectClasses.PurchaseOrderDetail[] PurchaseOrderDetails { get; set; }
        public TTObjectClasses.PurchaseItemDef[] PurchaseItemDefs { get; set; }
        public TTObjectClasses.PurchaseProjectDetail[] PurchaseProjectDetails { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
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
