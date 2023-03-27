//$F9807022
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
    public partial class ChattelDocumentInputWithAccountancyServiceController : Controller
    {
        [HttpGet]
        public ChattelDocumentInputWithAccountancyNewFormViewModel ChattelDocumentInputWithAccountancyNewForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ChattelDocumentInputWithAccountancyNewFormLoadInternal(input);
        }

        [HttpPost]
        public ChattelDocumentInputWithAccountancyNewFormViewModel ChattelDocumentInputWithAccountancyNewFormLoad(FormLoadInput input)
        {
            return ChattelDocumentInputWithAccountancyNewFormLoadInternal(input);
        }

        private ChattelDocumentInputWithAccountancyNewFormViewModel ChattelDocumentInputWithAccountancyNewFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("79853c19-45b5-4d7b-862f-3e71a506d7b9");
            var objectDefID = Guid.Parse("1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3");
            var viewModel = new ChattelDocumentInputWithAccountancyNewFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentInputWithAccountancy = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentInputWithAccountancy;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentInputWithAccountancy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentInputWithAccountancy);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_ChattelDocumentInputWithAccountancyNewForm(viewModel, viewModel._ChattelDocumentInputWithAccountancy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentInputWithAccountancy = new ChattelDocumentInputWithAccountancy(objectContext);
                    var entryStateID = Guid.Parse("078e7b15-ebf6-4701-bcc4-13576c15a6df");
                    viewModel._ChattelDocumentInputWithAccountancy.CurrentStateDefID = entryStateID;
                    viewModel.ChattelDocumentDetailsWithAccountancyGridList = new TTObjectClasses.ChattelDocumentInputDetailWithAccountancy[] { };
                    viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[] { };
                    viewModel.PTSStockActionDetails = new TTObjectClasses.PTSStockActionDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChattelDocumentInputWithAccountancy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChattelDocumentInputWithAccountancy);
                    PreScript_ChattelDocumentInputWithAccountancyNewForm(viewModel, viewModel._ChattelDocumentInputWithAccountancy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("79853c19-45b5-4d7b-862f-3e71a506d7b9");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.BudgetTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Accountancys);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.Suppliers);
                objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithAccountancyGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                objectContext.AddToRawObjectList(viewModel.PTSStockActionDetails);
                var entryStateID = Guid.Parse("078e7b15-ebf6-4701-bcc4-13576c15a6df");
                objectContext.AddToRawObjectList(viewModel._ChattelDocumentInputWithAccountancy, entryStateID);
                objectContext.ProcessRawObjects(false);
                var chattelDocumentInputWithAccountancy = (ChattelDocumentInputWithAccountancy)objectContext.GetLoadedObject(viewModel._ChattelDocumentInputWithAccountancy.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentInputWithAccountancy, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentInputWithAccountancy, formDefID);
                if (viewModel.ChattelDocumentDetailsWithAccountancyGridList != null)
                {
                    foreach (var item in viewModel.ChattelDocumentDetailsWithAccountancyGridList)
                    {
                        var chattelDocumentInputDetailsWithAccountancyImported = (ChattelDocumentInputDetailWithAccountancy)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)chattelDocumentInputDetailsWithAccountancyImported).IsDeleted)
                            continue;
                        chattelDocumentInputDetailsWithAccountancyImported.StockAction = chattelDocumentInputWithAccountancy;

                        if (chattelDocumentInputWithAccountancy.PTSStockActionDetails.Count > 0)
                        {
                            PTSStockActionDetail findPTS = chattelDocumentInputWithAccountancy.PTSStockActionDetails.Where(x => x.Material == chattelDocumentInputDetailsWithAccountancyImported.Material && x.LotNo == chattelDocumentInputDetailsWithAccountancyImported.LotNo
                            && x.ExpirationDate == chattelDocumentInputDetailsWithAccountancyImported.ExpirationDate).FirstOrDefault();
                            chattelDocumentInputDetailsWithAccountancyImported.PTSStockActionDetail = findPTS;
                        }
                    }
                }

                if (viewModel.StockActionSignDetailsGridList != null)
                {
                    foreach (var item in viewModel.StockActionSignDetailsGridList)
                    {
                        var stockActionSignDetailsImported = (StockActionSignDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)stockActionSignDetailsImported).IsDeleted)
                            continue;
                        stockActionSignDetailsImported.StockAction = chattelDocumentInputWithAccountancy;
                    }
                }

                if (viewModel.PTSStockActionDetails != null)
                {
                    foreach (var item in viewModel.PTSStockActionDetails)
                    {
                        var ptsStockActionDetailsImported = (PTSStockActionDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)ptsStockActionDetailsImported).IsDeleted)
                            continue;
                        ptsStockActionDetailsImported.StockAction = chattelDocumentInputWithAccountancy;

                        List<PTSMaterial> findList = viewModel.PTSMaterials.Where(x => x.materialObjectID == ptsStockActionDetailsImported.Material.ObjectID && x.lotNO == ptsStockActionDetailsImported.LotNo
                  && x.expirationDate == ptsStockActionDetailsImported.ExpirationDate).ToList();
                        foreach (PTSMaterial ptsSeriNo in findList)
                        {
                            foreach (PTSMaterialSerialNumber seriNo in ptsSeriNo.serialNOList)
                            {
                                ChattelDocumentInputDetailWithAccountancy chattelDocumentInputDetailWithAccountancy = new ChattelDocumentInputDetailWithAccountancy(objectContext);
                                chattelDocumentInputDetailWithAccountancy.Material = ptsStockActionDetailsImported.Material;
                                chattelDocumentInputDetailWithAccountancy.Amount = seriNo.amount;
                                chattelDocumentInputDetailWithAccountancy.DiscountAmount = ptsStockActionDetailsImported.DiscountAmount / seriNo.amount;
                                chattelDocumentInputDetailWithAccountancy.DiscountRate = ptsStockActionDetailsImported.DiscountRate;
                                chattelDocumentInputDetailWithAccountancy.ExpirationDate = ptsStockActionDetailsImported.ExpirationDate;
                                chattelDocumentInputDetailWithAccountancy.LotNo = ptsStockActionDetailsImported.LotNo;
                                chattelDocumentInputDetailWithAccountancy.NotDiscountedUnitPrice = ptsStockActionDetailsImported.NotDiscountedUnitPrice / seriNo.amount;
                                chattelDocumentInputDetailWithAccountancy.Price = Convert.ToDouble(ptsSeriNo.price) / seriNo.amount;
                                chattelDocumentInputDetailWithAccountancy.ProductionDate = ptsStockActionDetailsImported.ProductionDate;
                                chattelDocumentInputDetailWithAccountancy.PTSStockActionDetail = ptsStockActionDetailsImported;
                                chattelDocumentInputDetailWithAccountancy.RetrievalYear = ptsStockActionDetailsImported.RetrievalYear;
                                chattelDocumentInputDetailWithAccountancy.SerialNo = seriNo.serialNo;
                                chattelDocumentInputDetailWithAccountancy.Status = StockActionDetailStatusEnum.New;
                                chattelDocumentInputDetailWithAccountancy.StockAction = chattelDocumentInputWithAccountancy;
                                chattelDocumentInputDetailWithAccountancy.StockLevelType = StockLevelType.NewStockLevel;
                                chattelDocumentInputDetailWithAccountancy.TotalDiscountAmount = ptsStockActionDetailsImported.TotalDiscountAmount / seriNo.amount;
                                chattelDocumentInputDetailWithAccountancy.TotalPriceNotDiscount = ptsStockActionDetailsImported.TotalPriceNotDiscount;
                                chattelDocumentInputDetailWithAccountancy.UnitPrice = ptsStockActionDetailsImported.UnitPrice;
                                chattelDocumentInputDetailWithAccountancy.SentAmount = seriNo.amount;
                                //chattelDocumentInputDetailWithAccountancy.UnitPriceWithInVat = ptsSeriNo.UnitPriceWithInVat;
                                //chattelDocumentInputDetailWithAccountancy.UnitPriceWithOutVat = ptsSeriNo.UnitPriceWithOutVat;
                                chattelDocumentInputDetailWithAccountancy.VatRate = ptsStockActionDetailsImported.VatRate;
                                chattelDocumentInputDetailWithAccountancy.VoucherDetailRecordNo = ptsStockActionDetailsImported.VoucherDetailRecordNo;
                            }
                        }

                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(chattelDocumentInputWithAccountancy);
                PostScript_ChattelDocumentInputWithAccountancyNewForm(viewModel, chattelDocumentInputWithAccountancy, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentInputWithAccountancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentInputWithAccountancy);
                AfterContextSaveScript_ChattelDocumentInputWithAccountancyNewForm(viewModel, chattelDocumentInputWithAccountancy, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTObjectContext objectContext);
        partial void PostScript_ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChattelDocumentInputWithAccountancyNewForm(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ChattelDocumentInputWithAccountancyNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ChattelDocumentDetailsWithAccountancyGridList = viewModel._ChattelDocumentInputWithAccountancy.ChattelDocumentInputDetailsWithAccountancy.OfType<ChattelDocumentInputDetailWithAccountancy>().ToArray();
            viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentInputWithAccountancy.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.BudgetTypeDefinitions = objectContext.LocalQuery<BudgetTypeDefinition>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            viewModel.Suppliers = objectContext.LocalQuery<Supplier>().ToArray();
            viewModel.PTSStockActionDetails = objectContext.LocalQuery<PTSStockActionDetail>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "BugdetTypeList", viewModel.BudgetTypeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreDefinitionList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SupplierListDefinition", viewModel.Suppliers);
        }
    }
}


namespace Core.Models
{
    public partial class ChattelDocumentInputWithAccountancyNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentInputWithAccountancy _ChattelDocumentInputWithAccountancy { get; set; }
        public TTObjectClasses.ChattelDocumentInputDetailWithAccountancy[] ChattelDocumentDetailsWithAccountancyGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.BudgetTypeDefinition[] BudgetTypeDefinitions { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Accountancy[] Accountancys { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
        public TTObjectClasses.Supplier[] Suppliers { get; set; }
        public TTObjectClasses.PTSStockActionDetail[] PTSStockActionDetails { get; set; }
        public PTSMaterial[] PTSMaterials { get; set; }
    }
}
