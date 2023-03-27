//$1BAF74A0
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
        public ChattelDocumentWithPurchaseCompletedFormViewModel ChattelDocumentWithPurchaseCompletedForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ChattelDocumentWithPurchaseCompletedFormLoadInternal(input);
        }

        [HttpPost]
        public ChattelDocumentWithPurchaseCompletedFormViewModel ChattelDocumentWithPurchaseCompletedFormLoad(FormLoadInput input)
        {
            return ChattelDocumentWithPurchaseCompletedFormLoadInternal(input);
        }

        private ChattelDocumentWithPurchaseCompletedFormViewModel ChattelDocumentWithPurchaseCompletedFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("8eb3a202-e68e-466c-9e6a-3af7dd451692");
            var objectDefID = Guid.Parse("3799bd27-4d89-4cd5-83e3-7aea9801138e");
            var viewModel = new ChattelDocumentWithPurchaseCompletedFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                //using (var objectContext = new TTObjectContext(false))
                //{
                TTObjectContext objectContext = new TTObjectContext(false);
                viewModel._ChattelDocumentWithPurchase = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentWithPurchase;
                viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentWithPurchase);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentWithPurchase);
                objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                ContextToViewModel(viewModel, objectContext);
                PreScript_ChattelDocumentWithPurchaseCompletedForm(viewModel, viewModel._ChattelDocumentWithPurchase, objectContext);
                if (viewModel.PTSMaterials == null)
                {
                    objectContext.FullPartialllyLoadedObjects();
                    objectContext.Dispose();
                }
                //}
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("8eb3a202-e68e-466c-9e6a-3af7dd451692");
            using (var objectContext = new TTObjectContext(false))
            {
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
                objectContext.AddToRawObjectList(viewModel.DocumentRecordLogsGridList);
                objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithPurchaseGridList);
                objectContext.AddToRawObjectList(viewModel.DemandAmountsGridGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                objectContext.AddToRawObjectList(viewModel._ChattelDocumentWithPurchase);
                objectContext.ProcessRawObjects();
                var chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)objectContext.GetLoadedObject(viewModel._ChattelDocumentWithPurchase.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentWithPurchase, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentWithPurchase, formDefID);
                if (viewModel.DocumentRecordLogsGridList != null)
                {
                    foreach (var item in viewModel.DocumentRecordLogsGridList)
                    {
                        var documentRecordLogsImported = (DocumentRecordLog)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)documentRecordLogsImported).IsDeleted)
                            continue;
                        documentRecordLogsImported.StockAction = chattelDocumentWithPurchase;
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
                PostScript_ChattelDocumentWithPurchaseCompletedForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentWithPurchase);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentWithPurchase);
                AfterContextSaveScript_ChattelDocumentWithPurchaseCompletedForm(viewModel, chattelDocumentWithPurchase, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTObjectContext objectContext);
        partial void PostScript_ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseCompletedForm(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ChattelDocumentWithPurchaseCompletedFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.DocumentRecordLogsGridList = viewModel._ChattelDocumentWithPurchase.DocumentRecordLogs.OfType<DocumentRecordLog>().ToArray();
            viewModel.PTSStockActionDetails = viewModel._ChattelDocumentWithPurchase.PTSStockActionDetails.OfType<PTSStockActionDetail>().ToArray();
            if (viewModel.PTSStockActionDetails.Length == 0)
                viewModel.ChattelDocumentDetailsWithPurchaseGridList = viewModel._ChattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase.OfType<ChattelDocumentDetailWithPurchase>().ToArray();
            else
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
                    ptsList.Add(ptsMaterial);
                }
                viewModel.PTSMaterials = ptsList.ToArray();
            }
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
    public partial class ChattelDocumentWithPurchaseCompletedFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentWithPurchase _ChattelDocumentWithPurchase { get; set; }
        public TTObjectClasses.DocumentRecordLog[] DocumentRecordLogsGridList { get; set; }
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
