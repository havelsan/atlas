//$2E89A751
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using TTDataDictionary;
using TTUtils;

namespace Core.Controllers
{
    public partial class ChattelDocumentOutputWithAccountancyServiceController : Controller
    {
        [HttpGet]
        public ChattelDocumentOutputWithAccountancyNewFormViewModel ChattelDocumentOutputWithAccountancyNewForm(Guid? id)
        {
            var input = new FormLoadInput();
            input.Id = id;
            return ChattelDocumentOutputWithAccountancyNewFormLoadInternal(input);
        }

        [HttpPost]
        public ChattelDocumentOutputWithAccountancyNewFormViewModel ChattelDocumentOutputWithAccountancyNewFormLoad(FormLoadInput input)
        {
            return ChattelDocumentOutputWithAccountancyNewFormLoadInternal(input);
        }

        private ChattelDocumentOutputWithAccountancyNewFormViewModel ChattelDocumentOutputWithAccountancyNewFormLoadInternal(FormLoadInput input)
        {
            Guid? id = input.Id;
            var formDefID = Guid.Parse("7d629af3-853f-4565-b4f5-653dded02f85");
            var objectDefID = Guid.Parse("a7a40ea6-57ac-4181-a185-99f9f81e630f");
            var viewModel = new ChattelDocumentOutputWithAccountancyNewFormViewModel();
            viewModel.ActiveIDsModel = input.Model;
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentOutputWithAccountancy = objectContext.GetObject(id.Value, objectDefID) as ChattelDocumentOutputWithAccountancy;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ChattelDocumentOutputWithAccountancy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ChattelDocumentOutputWithAccountancy);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);
                    PreScript_ChattelDocumentOutputWithAccountancyNewForm(viewModel, viewModel._ChattelDocumentOutputWithAccountancy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy(objectContext);
                    var entryStateID = Guid.Parse("2f482725-2fd1-4bf6-aa3d-ac4556e0da92");
                    viewModel._ChattelDocumentOutputWithAccountancy.CurrentStateDefID = entryStateID;
                    viewModel.ChattelDocumentDetailsWithAccountancyGridList = new TTObjectClasses.ChattelDocumentOutputDetailWithAccountancy[] { };
                    viewModel.StockActionSignDetailsGridList = new TTObjectClasses.StockActionSignDetail[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ChattelDocumentOutputWithAccountancy);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ChattelDocumentOutputWithAccountancy);
                    PreScript_ChattelDocumentOutputWithAccountancyNewForm(viewModel, viewModel._ChattelDocumentOutputWithAccountancy, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }

            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ChattelDocumentOutputWithAccountancyNewForm(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("7d629af3-853f-4565-b4f5-653dded02f85");
            using (var objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.Stores);
                objectContext.AddToRawObjectList(viewModel.Materials);
                objectContext.AddToRawObjectList(viewModel.StockCards);
                objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
                objectContext.AddToRawObjectList(viewModel.StockLevelTypes);
                objectContext.AddToRawObjectList(viewModel.Accountancys);
                objectContext.AddToRawObjectList(viewModel.ResUsers);
                objectContext.AddToRawObjectList(viewModel.ChattelDocumentDetailsWithAccountancyGridList);
                objectContext.AddToRawObjectList(viewModel.StockActionSignDetailsGridList);
                var entryStateID = Guid.Parse("2f482725-2fd1-4bf6-aa3d-ac4556e0da92");
                objectContext.AddToRawObjectList(viewModel._ChattelDocumentOutputWithAccountancy, entryStateID);
                objectContext.ProcessRawObjects(false);
                var chattelDocumentOutputWithAccountancy = (ChattelDocumentOutputWithAccountancy)objectContext.GetLoadedObject(viewModel._ChattelDocumentOutputWithAccountancy.ObjectID);
                TTDefinitionManagement.TTFormDef.CheckFormSecurity(chattelDocumentOutputWithAccountancy, formDefID, true);
                TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ChattelDocumentOutputWithAccountancy, formDefID);

                if (viewModel._ChattelDocumentOutputWithAccountancy.IsPTSAction == true)
                {
                    if (viewModel.QRCodeReadList.Length == 0)
                        throw new TTException(" ITS çıkışı için kare kod okutmanız gerekmektedir.");

                    Currency totalAmountDetail = 0;
                    Currency totalOuttableAmountDetail = 0;
                    foreach (ChattelDocumentOutputDetailWithAccountancy detail in viewModel.ChattelDocumentDetailsWithAccountancyGridList)
                        totalAmountDetail += (Currency)detail.Amount;

                    foreach (QRCodeReadDTO outtableLot in viewModel.QRCodeReadList)
                        totalOuttableAmountDetail += outtableLot.Amount;

                    if (totalAmountDetail > totalOuttableAmountDetail)
                        throw new TTException(" ITS çıkışı için okutulan karekod miktarı uyuşmamaktadır.");
                }



                if (viewModel.ChattelDocumentDetailsWithAccountancyGridList != null)
                {
                    foreach (var item in viewModel.ChattelDocumentDetailsWithAccountancyGridList)
                    {
                        var chattelDocumentOutputDetailsWithAccountancyImported = (ChattelDocumentOutputDetailWithAccountancy)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)chattelDocumentOutputDetailsWithAccountancyImported).IsDeleted)
                            continue;
                        chattelDocumentOutputDetailsWithAccountancyImported.StockAction = chattelDocumentOutputWithAccountancy;
                        if (chattelDocumentOutputDetailsWithAccountancyImported.UserSelectedOutableTrx.HasValue && chattelDocumentOutputDetailsWithAccountancyImported.UserSelectedOutableTrx.Value)
                        {
                            foreach (OuttableLotDTO outtable in viewModel.OuttableLotList.Where(x => x.StockActionDetailOrderNo == chattelDocumentOutputDetailsWithAccountancyImported.ChattelDocDetailOrderNo))
                            {
                                OuttableLot outtableLot = new OuttableLot(objectContext);
                                outtableLot.Amount = outtable.Amount;
                                outtableLot.BudgetTypeName = outtable.BudgetTypeName;
                                outtableLot.ExpirationDate = outtable.ExpirationDate;
                                outtableLot.isUse = true;
                                outtableLot.LotNo = outtable.LotNo;
                                outtableLot.RestAmount = outtable.RestAmount;
                                outtableLot.SerialNo = outtable.SerialNo;
                                outtableLot.StockActionDetailOut = chattelDocumentOutputDetailsWithAccountancyImported;
                                outtableLot.TrxObjectID = outtable.TrxObjectID;
                            }
                        }

                        if (viewModel.QRCodeReadList.Select(x => x.MaterialObjectID == chattelDocumentOutputDetailsWithAccountancyImported.Material.ObjectID).Any())
                        {
                            foreach (QRCodeReadDTO qrcode in viewModel.QRCodeReadList.Where(x => x.MaterialObjectID == chattelDocumentOutputDetailsWithAccountancyImported.Material.ObjectID))
                            {
                                ManuelReadQRCode manuelReadQRCode = new ManuelReadQRCode(objectContext);
                                manuelReadQRCode.Barcode = qrcode.Barcode;
                                manuelReadQRCode.ExpirationDate = qrcode.ExpirationDate;
                                manuelReadQRCode.LotNo = qrcode.LotNo;
                                manuelReadQRCode.SerialNo = qrcode.SerialNo;
                                manuelReadQRCode.ChattelDocumentOutputDetail = chattelDocumentOutputDetailsWithAccountancyImported;
                            }
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
                        stockActionSignDetailsImported.StockAction = chattelDocumentOutputWithAccountancy;
                    }
                }

                var transDef = objectContext.GetTransitionDefFromNeedAdvanceList(chattelDocumentOutputWithAccountancy);
                PostScript_ChattelDocumentOutputWithAccountancyNewForm(viewModel, chattelDocumentOutputWithAccountancy, transDef, objectContext);
                objectContext.AdvanceStateForNewObjects();
                retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
                objectContext.Save();
                viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(chattelDocumentOutputWithAccountancy);
                viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(chattelDocumentOutputWithAccountancy);
                AfterContextSaveScript_ChattelDocumentOutputWithAccountancyNewForm(viewModel, chattelDocumentOutputWithAccountancy, transDef, objectContext);
                retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
                retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
                objectContext.FullPartialllyLoadedObjects();
            }

            return retViewModel;
        }

        partial void PreScript_ChattelDocumentOutputWithAccountancyNewForm(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTObjectContext objectContext);
        partial void PostScript_ChattelDocumentOutputWithAccountancyNewForm(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ChattelDocumentOutputWithAccountancyNewForm(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel, ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        void ContextToViewModel(ChattelDocumentOutputWithAccountancyNewFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.ChattelDocumentDetailsWithAccountancyGridList = viewModel._ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.OfType<ChattelDocumentOutputDetailWithAccountancy>().ToArray();
            viewModel.StockActionSignDetailsGridList = viewModel._ChattelDocumentOutputWithAccountancy.StockActionSignDetails.OfType<StockActionSignDetail>().ToArray();
            viewModel.Stores = objectContext.LocalQuery<Store>().ToArray();
            viewModel.Materials = objectContext.LocalQuery<Material>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.StockLevelTypes = objectContext.LocalQuery<StockLevelType>().ToArray();
            viewModel.Accountancys = objectContext.LocalQuery<Accountancy>().ToArray();
            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MainStoreList", viewModel.Stores);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialListDefinition", viewModel.Materials);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockLevelTypeList", viewModel.StockLevelTypes);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "AccountancyList", viewModel.Accountancys);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "UserListDefinition", viewModel.ResUsers);
        }
    }
}


namespace Core.Models
{
    public partial class ChattelDocumentOutputWithAccountancyNewFormViewModel : BaseViewModel
    {
        public TTObjectClasses.ChattelDocumentOutputWithAccountancy _ChattelDocumentOutputWithAccountancy { get; set; }
        public TTObjectClasses.ChattelDocumentOutputDetailWithAccountancy[] ChattelDocumentDetailsWithAccountancyGridList { get; set; }
        public TTObjectClasses.StockActionSignDetail[] StockActionSignDetailsGridList { get; set; }
        public TTObjectClasses.Store[] Stores { get; set; }
        public TTObjectClasses.Material[] Materials { get; set; }
        public TTObjectClasses.StockCard[] StockCards { get; set; }
        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions { get; set; }
        public TTObjectClasses.StockLevelType[] StockLevelTypes { get; set; }
        public TTObjectClasses.Accountancy[] Accountancys { get; set; }
        public TTObjectClasses.ResUser[] ResUsers { get; set; }
    }
}
