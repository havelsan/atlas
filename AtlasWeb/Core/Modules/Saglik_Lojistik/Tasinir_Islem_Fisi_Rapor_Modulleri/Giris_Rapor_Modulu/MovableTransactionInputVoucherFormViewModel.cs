using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using System.ComponentModel;
using TTObjectClasses;
using Infrastructure.Filters;
using Core.Security;
using TTInstanceManagement;
using Core.Controllers.Logistic;
using TTDataDictionary;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class MovableTransactionInputVoucherServiceController : Controller
    {


        public List<MaterialDetailsResultModel> GetMaterialDetailsOnStockTransaction(MaterialDetailsInputModel input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<MaterialDetailsResultModel> resultList = new List<MaterialDetailsResultModel>();
                List<StockTransaction> detailList = objectContext.QueryObjects<StockTransaction>("StockActionDetail = '" + input.StockActionDetailObjectID + "'").ToList();
                foreach (StockTransaction transaction in detailList)
                {
                    foreach (StockTransactionDetail transactionDetail in transaction.StockTransactionDetails)
                    {
                        MaterialDetailsResultModel model = new MaterialDetailsResultModel();
                        model.MKYS_StokHareketID = transaction.MKYS_StokHareketID.ToString();
                        model.OutDate = transactionDetail.LastUpdate;
                        //model.OutLocation = transaction.;
                        model.Amount = (double)(transactionDetail.Amount);
                        model.UnitPrice = (double)(transaction.UnitPrice);
                        model.TotalPrice = (double)(model.Amount * transaction.UnitPrice);
                        model.StockActionDetailObjectID = input.StockActionDetailObjectID;
                        model.StockActionObjectID = input.StockActionObjectID;
                        model.MaterialObjectID = input.MaterialObjectID;

                        resultList.Add(model);
                    }
                }

                return resultList;
            }
        }

        public List<VoucherDetailsResultModel> GetVoucherDetailsOnMaterial(VoucherDetailsInputModel input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<VoucherDetailsResultModel> resultList = new List<VoucherDetailsResultModel>();
                StockAction action = objectContext.GetObject<StockAction>(input.StockActionObjectID);
                List<StockActionDetailIn> detailList = action.StockActionInDetails.ToList<StockActionDetailIn>();
                foreach (StockActionDetailIn actiondetail in detailList)
                {
                    VoucherDetailsResultModel model = new VoucherDetailsResultModel();
                    model.MaterialName = actiondetail.Material.Name_Shadow;
                    model.MaterialObjectID = actiondetail.Material.ObjectID;
                    model.StockActionObjectID = action.ObjectID;
                    model.StockActionDetailObjectID = actiondetail.ObjectID;
                    model.TransactionCode = actiondetail.Material.NATOStockNO;
                    model.Barcode = actiondetail.Material.Barcode;
                    model.Amount = actiondetail.Amount.ToString();
                    model.StoreStock = actiondetail.StoreStock.ToString();
                    model.ExpirationDate = actiondetail.ExpirationDate;

                    resultList.Add(model);
                }

                return resultList;
            }
        }
        public bool canMaterialImport(StockAction action, List<Material> selectedMaterialList)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                bool control = false;
                IBindingList stockActionMaterialList = objectContext.QueryObjects("StockActionDetail", "stockaction ='" + action.ObjectID + "'");

                foreach (StockActionDetailIn stockActionItem in stockActionMaterialList)
                {
                    foreach (Material selectedItem in selectedMaterialList)
                    {
                        if (selectedItem.ObjectID.Equals(stockActionItem.Material.ObjectID))
                        {
                            control = true;
                            break;
                        }
                    }
                }

                return control;
            }
        }



        public List<MovableTransactionInputVoucherResultModel> GetMovableTransactionInputVouchers(MovableTransactionInputVoucherFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<MovableTransactionInputVoucherResultModel> stockactionlist = new List<MovableTransactionInputVoucherResultModel>();

                string filiterExpresion = viewModel.GetFilterExpression();
                List<StockAction> lookupList = new List<StockAction>();
                if (string.IsNullOrEmpty(viewModel.DocumentRecordLogID) == false)
                {
                    IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER ='" + viewModel.DocumentRecordLogID + "'");
                    foreach (DocumentRecordLog d in documentRecordLogs)
                    {
                        lookupList.Add(d.StockAction);
                    }
                }
                else if (string.IsNullOrEmpty(viewModel.MKYSStockTransactionID) == false)
                {
                    lookupList = StockAction.GetMovTransInputVoucStockTransID(objectContext, viewModel.MKYSStockTransactionID, viewModel.StoreID, viewModel.EndDate, viewModel.StartDate, filiterExpresion).ToList();
                }
                else
                {
                    lookupList = StockAction.GetMovableTransactionInputVouchers(objectContext, viewModel.EndDate, viewModel.StartDate, viewModel.StoreID, filiterExpresion).ToList();
                }

                foreach (StockAction action in lookupList)
                {
                    if (action is StockAction)
                    {
                        if (canMaterialImport(action, viewModel.SelectedFilterMaterials) || viewModel.SelectedFilterMaterials.Count == 0)
                        {
                            BaseChattelDocument Chattel = (BaseChattelDocument)objectContext.GetObject<BaseChattelDocument>(action.ObjectID);

                            MovableTransactionInputVoucherResultModel resultModel = new MovableTransactionInputVoucherResultModel();
                            resultModel.StockActionObjectID = action.ObjectID;
                            resultModel.StockActionID = (int)action.StockActionID.Value;

                            if (Chattel is ChattelDocumentWithPurchase)
                            {
                                LoadResultModelFromChattelWithPurchase(Chattel, resultModel);
                                if (viewModel.SupplierObjectID != null)
                                {
                                    if (((ChattelDocumentWithPurchase)Chattel).Supplier != null && ((ChattelDocumentWithPurchase)Chattel).Supplier.ObjectID == viewModel.SupplierObjectID)
                                    {
                                        stockactionlist.Add(resultModel);
                                    }
                                }
                                else
                                {
                                    stockactionlist.Add(resultModel);
                                }
                            }
                            else if (Chattel is ChattelDocumentInputWithAccountancy)
                            {
                                LoadResultModelFromChattleDocumentInputWithAccountancy(Chattel, resultModel);
                                if (viewModel.AccountancyObjectID != null)
                                {
                                    if (((ChattelDocumentInputWithAccountancy)Chattel).Accountancy != null && ((ChattelDocumentInputWithAccountancy)Chattel).Accountancy.ObjectID == viewModel.AccountancyObjectID)
                                    {
                                        stockactionlist.Add(resultModel);
                                    }
                                }
                                else
                                {
                                    stockactionlist.Add(resultModel);
                                }
                            }
                        }
                    }
                }
                return stockactionlist;
            }
        }

        private static void LoadResultModelFromChattelWithPurchase(BaseChattelDocument Chattel, MovableTransactionInputVoucherResultModel resultModel)
        {
            resultModel.ExamintaionNo = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportNo;

            if (((ChattelDocumentWithPurchase)Chattel).Waybill != null)
                resultModel.VounherNo = ((ChattelDocumentWithPurchase)Chattel).Waybill;

            if (((ChattelDocumentWithPurchase)Chattel).BudgetTypeDefinition != null)
                resultModel.BudgetType = ((ChattelDocumentWithPurchase)Chattel).BudgetTypeDefinition.Name;

            if (((ChattelDocumentWithPurchase)Chattel).Supplier != null)
                resultModel.CompanyName = ((ChattelDocumentWithPurchase)Chattel).Supplier.Name;

            if (((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate != null)
                resultModel.ExaminationDate = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate.Value;

            if (((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal != null)
                resultModel.VoucherAmount = ((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal.Value;
            else
                resultModel.VoucherAmount = CalculatePrice(Chattel);

            if (((ChattelDocumentWithPurchase)Chattel).TransactionDate != null)
                resultModel.VoucherDate = ((ChattelDocumentWithPurchase)Chattel).TransactionDate.Value;

            if (((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi != null)
                resultModel.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_EAlimYontemiEnum", (int)((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi.Value);
            resultModel.TIFNo = Chattel.DocumentRecordLogNumbers;

        }

        private static void LoadResultModelFromChattleDocumentInputWithAccountancy(BaseChattelDocument Chattel, MovableTransactionInputVoucherResultModel resultModel)
        {
            if (((ChattelDocumentInputWithAccountancy)Chattel).Waybill != null)
                resultModel.VounherNo = ((ChattelDocumentInputWithAccountancy)Chattel).Waybill;

            if (((ChattelDocumentInputWithAccountancy)Chattel).BudgetTypeDefinition != null)
                resultModel.BudgetType = ((ChattelDocumentInputWithAccountancy)Chattel).BudgetTypeDefinition.Name;

            if (((ChattelDocumentInputWithAccountancy)Chattel).Accountancy != null)
                resultModel.CompanyName = ((ChattelDocumentInputWithAccountancy)Chattel).Accountancy.Name;

            if (((ChattelDocumentInputWithAccountancy)Chattel).TransactionDate != null)
                resultModel.VoucherDate = ((ChattelDocumentInputWithAccountancy)Chattel).TransactionDate.Value;

            if (((ChattelDocumentInputWithAccountancy)Chattel).MKYS_ETedarikTuru != null)
                resultModel.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_ETedarikTurEnum", (int)((ChattelDocumentInputWithAccountancy)Chattel).MKYS_ETedarikTuru.Value);
            resultModel.VoucherAmount = CalculatePrice(Chattel);
            resultModel.TIFNo = Chattel.DocumentRecordLogNumbers;

        }

        public static Currency CalculatePrice(BaseChattelDocument Chattel)
        {
            Currency totalPrice = 0;
            foreach (StockActionDetail detail in Chattel.StockActionDetails)
            {
                totalPrice += detail.Amount.Value * (Currency)((StockActionDetailIn)detail).UnitPrice;
            }
            return totalPrice;
        }

        /*    private static void LoadMaterialResultModelFromChattelWithPurchase(BaseChattelDocument Chattel, MaterialModelForDetailedSearch resultModel)
            {
                resultModel.ExamintaionNo = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportNo;

                if (((ChattelDocumentWithPurchase)Chattel).BudgetTypeDefinition != null)
                    resultModel.BudgetType = ((ChattelDocumentWithPurchase)Chattel).BudgetTypeDefinition.Name;

                if (((ChattelDocumentWithPurchase)Chattel).Supplier != null)
                    resultModel.CompanyName = ((ChattelDocumentWithPurchase)Chattel).Supplier.Name;

                if (((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate != null)
                    resultModel.ExaminationDate = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate.Value;

                if (((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal != null)
                    resultModel.VoucherAmount = ((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal.Value;

                if (((ChattelDocumentWithPurchase)Chattel).TransactionDate != null)
                    resultModel.VoucherDate = ((ChattelDocumentWithPurchase)Chattel).TransactionDate.Value;

                if (((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi != null)
                    resultModel.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_EAlimYontemiEnum", (int)((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi.Value);
            }*/
        public List<MaterialModelForDetailedSearch> GetInputMaterialsForDetailedSearch(MovableTransactionInputVoucherFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<MaterialModelForDetailedSearch> resultlist = new List<MaterialModelForDetailedSearch>();
                List<InventoryInfoModel> list = new List<InventoryInfoModel>();

                string filiterExpresion = "";//viewModel.GetFilterExpression();
                string materialFiliter = "";
                string documentrecordfilter = "";

                if (string.IsNullOrEmpty(viewModel.DocumentRecordLogID) == false)
                {
                    IBindingList documentRecordLogs = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER ='" + viewModel.DocumentRecordLogID + "'");
                    if(documentRecordLogs.Count> 0)
                    {

                        documentrecordfilter =" AND this.StockActionDetail.StockAction.StockActionID IN (";
                        foreach (DocumentRecordLog d in documentRecordLogs)
                        {
                            documentrecordfilter += (int)d.StockAction.StockActionID.Value +",";
                        }
                        string filterSub = documentrecordfilter.Substring(0, documentrecordfilter.Length - 1);
                        filiterExpresion += filterSub + ")";
                    }
                    

                }
                if (viewModel.BudgetTypeDefinitionObjectID != null)
                {
                    filiterExpresion += " AND BudgetTypeDefinition = '" + viewModel.BudgetTypeDefinitionObjectID + "'";
                }
                if (viewModel.StockActionID != null)
                {
                    filiterExpresion += " AND this.StockActionDetail.StockAction.StockActionID = " + viewModel.StockActionID;
                }

                if (viewModel.MKYSStockTransactionID != null)
                {
                    filiterExpresion += " AND this.StockActionDetail.MKYS_StokHareketID = '" + viewModel.MKYSStockTransactionID + "'";

                }

                if (viewModel.VademecumList.Count != 0)
                {
                    string vadecumFilter = " this.Stocks.Store = '" + viewModel.StoreID + "'" + " AND (";
                    foreach (int item in viewModel.VademecumList)
                    {
                        vadecumFilter += "this.DrugSpecifications.DrugSpecification = '" + item + "'" + " OR ";
                    }
                    vadecumFilter = vadecumFilter.Remove(vadecumFilter.LastIndexOf(" OR ")) + ")";
                    BindingList<DrugDefinition.GetDrugDefinitionForReport_Class> query = new BindingList<DrugDefinition.GetDrugDefinitionForReport_Class>();
                    query = DrugDefinition.GetDrugDefinitionForReport(vadecumFilter);

                    if (query.Count != 0)
                    {
                        materialFiliter += " AND (this.StockActionDetail.Material.OBJECTID = ";
                        // filiterExpresion += " AND (this.StockActionDetail.Material.OBJECTID = ";
                        foreach (DrugDefinition.GetDrugDefinitionForReport_Class material in query)
                        {
                            materialFiliter += "'" + material.Materialobjeid + "'" + " OR this.StockActionDetail.Material.OBJECTID = ";
                            // filiterExpresion += "'" + material.Materialobjeid + "'" + " OR this.StockActionDetail.Material.OBJECTID = ";
                        }
                        // filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR this.StockActionDetail.Material.OBJECTID = ")) + ")";
                        materialFiliter = materialFiliter.Remove(materialFiliter.LastIndexOf(" OR this.StockActionDetail.Material.OBJECTID = ")) + ")";
                    }
                    filiterExpresion += materialFiliter;
                }

                if (viewModel.SelectedFilterMaterials.Count != 0)
                {
                    if (viewModel.VademecumList.Count != 0)
                    {
                        materialFiliter = materialFiliter.Remove(materialFiliter.LastIndexOf(")"));
                        foreach (Material selectedItem in viewModel.SelectedFilterMaterials)
                        {
                            materialFiliter += " OR this.StockActionDetail.Material.OBJECTID = '" + selectedItem.ObjectID + "' ";
                        }
                        materialFiliter = materialFiliter + ")";
                        filiterExpresion += materialFiliter;
                    }
                    else
                    {
                        filiterExpresion += " AND (this.StockActionDetail.Material.OBJECTID = ";
                        foreach (Material selectedItem in viewModel.SelectedFilterMaterials)
                        {
                            filiterExpresion += "'" + selectedItem.ObjectID + "'" + " OR this.StockActionDetail.Material.OBJECTID = ";
                        }
                        filiterExpresion = filiterExpresion.Remove(filiterExpresion.LastIndexOf(" OR this.StockActionDetail.Material.OBJECTID = ")) + ")";
                    }
                }

                BindingList<StockTransaction> queryList = new BindingList<StockTransaction>();
                queryList = StockTransaction.GetInputMaterials(objectContext, viewModel.StartDate, viewModel.EndDate, viewModel.StoreID, filiterExpresion);

                foreach (StockTransaction transaction in queryList)
                {
                    BindingList<StockTransaction> QueryForOutput = new BindingList<StockTransaction>();
                    MaterialModelForDetailedSearch model = new MaterialModelForDetailedSearch();
                    List<InventoryInfoModel> inventorylist = new List<InventoryInfoModel>();
                    model.OutAmount = 0;
                    if (transaction.StockActionDetail.Material != null)
                    {
                        model.MaterialObjectID = transaction.StockActionDetail.Material.ObjectID;
                        QueryForOutput = StockTransaction.GetOutputMaterials(objectContext, viewModel.StartDate, viewModel.EndDate, viewModel.StoreID, model.MaterialObjectID, filiterExpresion);
                        foreach (StockTransaction output in QueryForOutput)
                        {
                            model.OutAmount += (int)output.Amount;
                        }
                        model.MaterialName = transaction.StockActionDetail.Material.Name;
                        model.Barcode = transaction.StockActionDetail.Material.Barcode;
                        model.InAmount = (int)transaction.Amount;
                        model.StockTransactionID = transaction.ObjectID;
                        model.StockActionObjectID = transaction.StockActionDetail.StockAction.ObjectID;
                        model.StockActionID = (int)transaction.StockActionDetail.StockAction.StockActionID.Value;
                        model.NatoStockNO = transaction.Stock.Material.StockCard.NATOStockNO;

                        model.RestAmount = transaction.RestAmount.Value;

                        BindingList<TTObjectClasses.DocumentRecordLog.GetTifNumber_Class> documentRecord = DocumentRecordLog.GetTifNumber(model.StockActionObjectID);
                        foreach (TTObjectClasses.DocumentRecordLog.GetTifNumber_Class x in documentRecord)
                        {
                            model.DocumentRecordLogID = x.DocumentRecordLogNumber;
                        }
                        string filiter = "";
                        filiter += " AND this.Stocks.Material.OBJECTID = '" + model.MaterialObjectID + "'";

                        BindingList<Material.GetHospitalInventory_Class> inventoryList = new BindingList<Material.GetHospitalInventory_Class>();
                        //BindingList<Material.GetRestAmounInStock_Class> stockAmountList = new BindingList<Material.GetRestAmounInStock_Class>();
                        inventoryList = Material.GetHospitalInventory(objectContext, viewModel.StoreID, filiter);
                        //stockAmountList = Material.GetRestAmounInStock(objectContext, viewModel.StoreID, filiter);
                        model.inventory = 0;
                        /*foreach (Material.GetRestAmounInStock_Class stock in stockAmountList)
                        {
                            model.RestAmount += (int)stock.Inheld;

                        }*/
                        foreach (Material.GetHospitalInventory_Class inventory in inventoryList)
                        {
                            model.inventory += inventory.Inheld;

                        }
                        if (transaction.StockActionDetail is StockActionDetailIn)
                        {
                            model.VatRate = ((StockActionDetailIn)transaction.StockActionDetail).VatRate.Value;
                        }

                        if (transaction.StockActionDetail is ChattelDocumentDetailWithPurchase)
                        {
                            model.UnitPriceWithinVat = ((ChattelDocumentDetailWithPurchase)transaction.StockActionDetail).UnitPriceWithInVat.Value;
                            model.UnitPriceWithoutVat = ((ChattelDocumentDetailWithPurchase)transaction.StockActionDetail).UnitPriceWithOutVat.Value;
                        }


                        StockAction Chattel = (StockAction)objectContext.GetObject<StockAction>(model.StockActionObjectID);

                        if (Chattel.MKYS_EAlimYontemi != null)
                            model.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_EAlimYontemiEnum", (int)(Chattel).MKYS_EAlimYontemi.Value);

                        if (Chattel.AccountancyName != null)
                            model.CompanyName = Chattel.AccountancyName;

                        if (Chattel is ChattelDocumentWithPurchase)
                        {
                            model.BidDate = ((ChattelDocumentWithPurchase)Chattel).AuctionDate;
                            model.BidNumber = ((ChattelDocumentWithPurchase)Chattel).RegistrationAuctionNo;
                        }


                        bool existReturnListCheck = true;
                        if (transaction.StockActionDetail.StockAction.IsPTSAction != null && transaction.StockActionDetail.StockAction.IsPTSAction == true)
                        {
                            if (resultlist.Where(x => x.StockActionObjectID == transaction.StockActionDetail.StockAction.ObjectID && x.MaterialObjectID == transaction.StockActionDetail.Material.ObjectID).Any())
                            {
                                resultlist.Where(x => x.StockActionObjectID == transaction.StockActionDetail.StockAction.ObjectID && x.MaterialObjectID == transaction.StockActionDetail.Material.ObjectID).FirstOrDefault().InAmount += model.InAmount;
                                resultlist.Where(x => x.StockActionObjectID == transaction.StockActionDetail.StockAction.ObjectID && x.MaterialObjectID == transaction.StockActionDetail.Material.ObjectID).FirstOrDefault().OutAmount += model.OutAmount;
                                resultlist.Where(x => x.StockActionObjectID == transaction.StockActionDetail.StockAction.ObjectID && x.MaterialObjectID == transaction.StockActionDetail.Material.ObjectID).FirstOrDefault().RestAmount += model.RestAmount;
                                existReturnListCheck = false;
                            }

                            if (viewModel.SupplierObjectID != null && Chattel is ChattelDocumentWithPurchase && existReturnListCheck)
                            {
                                if (((ChattelDocumentWithPurchase)Chattel).Supplier.ObjectID == viewModel.SupplierObjectID)
                                {
                                    resultlist.Add(model);
                                }
                            }

                            if (viewModel.AccountancyObjectID != null && Chattel is ChattelDocumentInputWithAccountancy && existReturnListCheck)
                            {
                                if (((ChattelDocumentInputWithAccountancy)Chattel).Accountancy.ObjectID == viewModel.AccountancyObjectID)
                                {
                                    resultlist.Add(model);
                                }
                            }

                            if (viewModel.AccountancyObjectID == null && viewModel.SupplierObjectID == null && existReturnListCheck)
                            {
                                resultlist.Add(model);
                            }
                        }
                        else
                        {
                            if (viewModel.SupplierObjectID != null && Chattel is ChattelDocumentWithPurchase)
                            {
                                if (((ChattelDocumentWithPurchase)Chattel).Supplier.ObjectID == viewModel.SupplierObjectID)
                                {
                                    resultlist.Add(model);
                                }
                            }

                            if (viewModel.AccountancyObjectID != null && Chattel is ChattelDocumentInputWithAccountancy)
                            {
                                if (((ChattelDocumentInputWithAccountancy)Chattel).Accountancy.ObjectID == viewModel.AccountancyObjectID)
                                {
                                    resultlist.Add(model);
                                }
                            }

                            if (viewModel.AccountancyObjectID == null && viewModel.SupplierObjectID == null)
                            {
                                resultlist.Add(model);
                            }
                        }
                    }
                }
                return resultlist;
            }

        }

        public List<MovableTransactionInputVoucherResultModel> GetInVouchersForDetailedSearch(ModelForInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<MovableTransactionInputVoucherResultModel> resultList = new List<MovableTransactionInputVoucherResultModel>();
                BindingList<StockTransaction> inStockTransaction = StockTransaction.GetInVouchers(objectContext, input.MaterialStockTransactionID);

                foreach (StockTransaction transaction in inStockTransaction)
                {
                    MovableTransactionInputVoucherResultModel model = new MovableTransactionInputVoucherResultModel();
                    StockAction inVoucher = transaction.StockActionDetail.StockAction;
                    Guid ActionObjectID = inVoucher.ObjectID;
                    int StockActionID = (int)inVoucher.StockActionID.Value;
                    BaseChattelDocument Chattel = (BaseChattelDocument)objectContext.GetObject<BaseChattelDocument>(ActionObjectID);

                    model.VoucherDate = inVoucher.TransactionDate;
                    if (inVoucher.BudgetTypeDefinition != null)
                        model.BudgetType = inVoucher.BudgetTypeDefinition.Name;
                    model.VoucherAmount = (int)inVoucher.TotalPrice;
                    model.StockActionObjectID = inVoucher.ObjectID;
                    model.StockActionID = (int)inVoucher.StockActionID.Value;
                    if (Chattel is ChattelDocumentWithPurchase)
                    {
                        model.ExamintaionNo = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportNo;
                        if (((ChattelDocumentWithPurchase)Chattel).Supplier != null)
                            model.CompanyName = ((ChattelDocumentWithPurchase)Chattel).Supplier.Name;
                        if (((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal != null)
                            model.VoucherAmount = ((ChattelDocumentWithPurchase)Chattel).XXXXXXSaleTotal.Value;
                        if (((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi != null)
                            model.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_EAlimYontemiEnum", (int)((ChattelDocumentWithPurchase)Chattel).MKYS_EAlimYontemi.Value);
                        if (((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate != null)
                            model.ExaminationDate = ((ChattelDocumentWithPurchase)Chattel).ExaminationReportDate.Value;
                    }
                    else if (Chattel is ChattelDocumentInputWithAccountancy)
                    {
                        if (((ChattelDocumentInputWithAccountancy)Chattel).Accountancy != null)
                            model.CompanyName = ((ChattelDocumentInputWithAccountancy)Chattel).Accountancy.Name;
                        if (((ChattelDocumentInputWithAccountancy)Chattel).MKYS_ETedarikTuru != null)
                            model.TakeinType = Common.GetDisplayTextOfEnumValue("MKYS_ETedarikTurEnum", (int)((ChattelDocumentInputWithAccountancy)Chattel).MKYS_ETedarikTuru.Value);
                    }

                    resultList.Add(model);
                }


                return resultList;
            }
        }

        public List<OutTransactionDetailModel> GetOutTransactionForInMaterials(ModelForInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<OutTransactionDetailModel> resultList = new List<OutTransactionDetailModel>();
                BindingList<StockTransactionDetail> inStockTransaction = StockTransactionDetail.GetInTransactionVoucherForInMaterials(objectContext, input.MaterialStockTransactionID);
                foreach (StockTransactionDetail transaction in inStockTransaction)
                {
                    OutTransactionDetailModel model = new OutTransactionDetailModel();
                    StockTransaction outTransaction = transaction.OutStockTransaction;
                    if (outTransaction.CurrentStateDef.DisplayText.Equals("Tamamlandı"))
                    {
                        if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID != null)
                        {
                            if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("a06d6465-0fe8-4fb1-a0df-a62373fef8de"))
                            {
                                BindingList<DistributionDocument.GetDestinationStore_Class> destStore = DistributionDocument.GetDestinationStore(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (DistributionDocument.GetDestinationStore_Class d in destStore)
                                {
                                    model.OutPlace = d.Name;
                                }
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("7982a4b9-5630-4e52-990e-2d46491c0baf"))
                            {
                                model.OutPlace = "Atık Depo";
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("98befb68-75cc-4d99-b76b-55ed1721e254"))
                            {
                                BindingList<KSchedule.GetOutPlace_Class> forOut = KSchedule.GetOutPlace(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (KSchedule.GetOutPlace_Class k in forOut)
                                {
                                    model.OutPlace = k.Name + k.Surname;
                                }
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("a7a40ea6-57ac-4181-a185-99f9f81e630f"))
                            {
                                BindingList<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class> forOut = ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class c in forOut)
                                {
                                    model.OutPlace = c.Name;
                                }
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("2e411643-ae98-4235-bb26-517909d043a6"))
                            {
                                BindingList<MainStoreStockTransfer.GetDestStoreForTransfer_Class> destStore = MainStoreStockTransfer.GetDestStoreForTransfer(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (MainStoreStockTransfer.GetDestStoreForTransfer_Class store in destStore)
                                {
                                    model.OutPlace = store.Destinationstore;
                                }
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("ca3f49f3-f0ed-449c-a31a-32534effc1d0"))
                            {
                                BindingList<ReturningDocument.GetDestStoreFromReturningDocument_Class> destStore = ReturningDocument.GetDestStoreFromReturningDocument(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (ReturningDocument.GetDestStoreFromReturningDocument_Class store in destStore)
                                {
                                    model.OutPlace = store.Destinationstore;
                                }
                            }
                            else if (outTransaction.StockActionDetail.StockAction.ObjectDef.ID.ToString().Equals("22f58018 - d72e - 46aa - 8372 - 2fa49e2b8127"))
                            {
                                BindingList<PresDistributionDocument.GetDestStoreFromPresDistDocument_Class> destStore = PresDistributionDocument.GetDestStoreFromPresDistDocument(outTransaction.StockActionDetail.StockAction.ObjectID);
                                foreach (PresDistributionDocument.GetDestStoreFromPresDistDocument_Class store in destStore)
                                {
                                    model.OutPlace = store.Destinationstore;
                                }
                            }
                            else
                            {
                                model.OutPlace = "-";
                            }
                        }
                        model.OutDate = outTransaction.TransactionDate;
                        model.Amount = (double)outTransaction.Amount;
                        model.UnitPrice = (double)outTransaction.UnitPrice;
                        model.UnitPrice = System.Math.Round(model.UnitPrice, 2);
                        model.TotalPrice = model.Amount * model.UnitPrice;
                        model.TotalPrice = System.Math.Round(model.TotalPrice, 2);
                        model.StockHareketID = outTransaction.MKYS_StokHareketID.ToString();
                        if (outTransaction != null)
                            model.OutTransactionID = outTransaction.ObjectID;

                        resultList.Add(model);

                    }

                }

                return resultList;
            }


        }
        public List<MovableTransactionInputVoucherResultModel> GetOutVouchersForDetailedSearch(ModelForInfoInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<MovableTransactionInputVoucherResultModel> resultList = new List<MovableTransactionInputVoucherResultModel>();
                BindingList<StockTransaction> outTransactions = StockTransaction.GetInVouchers(objectContext, input.MaterialStockTransactionID);

                foreach (StockTransaction transaction in outTransactions)
                {
                    MovableTransactionInputVoucherResultModel model = new MovableTransactionInputVoucherResultModel();
                    StockAction outVoucher = transaction.StockActionDetail.StockAction;
                    if (outVoucher.TransactionDate != null)
                        model.VoucherDate = outVoucher.TransactionDate;
                    if (outVoucher.TotalPrice != null)
                        model.VoucherAmount = (int)outVoucher.TotalPrice;
                    if (outVoucher.ObjectID != null)
                        model.StockActionObjectID = outVoucher.ObjectID;
                    if (outVoucher.StockActionID != null)
                        model.StockActionID = (int)outVoucher.StockActionID.Value;

                    resultList.Add(model);
                }
                return resultList;
            }
        }
        public List<InventoryInfoModel> GetHospitalInventory(InventoryInput input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string filiter = "";
                filiter += " AND this.Stocks.Material.OBJECTID = '" + input.MaterialObjectID + "'";

                BindingList<Material.GetHospitalInventory_Class> inventoryList = new BindingList<Material.GetHospitalInventory_Class>();
                inventoryList = Material.GetHospitalInventory(objectContext, input.viewModel.StoreID, filiter);
                List<InventoryInfoModel> list = new List<InventoryInfoModel>();

                foreach (Material.GetHospitalInventory_Class inventory in inventoryList)
                {

                    InventoryInfoModel inventoryModel = new InventoryInfoModel();
                    inventoryModel.Inventory = inventory.Inheld;
                    inventoryModel.StoreName = inventory.Name;
                    list.Add(inventoryModel);
                }
                return list;
            }
        }
    }


}



namespace Core.Models
{
    public class MovableTransactionInputVoucherFormViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MKYSStockTransactionID { get; set; }
        public Guid StoreID { get; set; }
        public string StateType { get; set; }
        public int? StockActionID { get; set; }
        public Guid? SupplierObjectID { get; set; }
        public Guid? BudgetTypeDefinitionObjectID { get; set; }
        public Guid? AccountancyObjectID { get; set; }
        public string DocumentRecordLogID { get; set; }
        public List<ObjectItem> SelectedWorkListItems = new List<ObjectItem>();
        public List<Material> SelectedFilterMaterials { get; set; }
        public string MovableBarcodeNumber { get; set; }
        public string MovableCode { get; set; }
        public bool showZeroValues { get; set; }
        public List<int> VademecumList { get; set; }


        public string GetFilterExpression()
        {
            string filiterExpresion = " AND CURRENTSTATE IS SUCCESSFUL AND OBJECTDEFID IN ('3799bd27-4d89-4cd5-83e3-7aea9801138e','1c5c4fc6-72e8-4c58-8d6a-21e17d1eacf3')";

            if (String.IsNullOrEmpty(StateType) == false)
            {
                filiterExpresion += " AND CURRENTSTATE IS " + StateType;
            }

            if (StockActionID != null)
            {
                filiterExpresion += " AND StockActionID = " + StockActionID + "";
            }

            if (BudgetTypeDefinitionObjectID != null)
            {
                filiterExpresion += " AND BudgetTypeDefinition = '" + BudgetTypeDefinitionObjectID + "'";
            }

            if (SelectedWorkListItems != null && SelectedWorkListItems.Count > 0)
            {
                filiterExpresion = filiterExpresion + " AND OBJECTDEFID IN (";
                foreach (ObjectItem wli in SelectedWorkListItems)
                {
                    filiterExpresion = filiterExpresion + "'" + wli.ObjectDefId + "',";
                }

                filiterExpresion = filiterExpresion.Remove(filiterExpresion.Length - 1);
                filiterExpresion = filiterExpresion + ")";
            }

            return filiterExpresion;
        }
    }
    public class ObjectItem
    {
        public string ObjectDefName { get; set; }
        public string ObjectDefId { get; set; }
    }

    public class MovableTransactionInputVoucherResultModel
    {
        public DateTime? VoucherDate { get; set; }
        public string TakeinType { get; set; }
        public string BudgetType { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public string ExamintaionNo { get; set; }
        public Currency? VoucherAmount { get; set; }
        public int StockActionID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public string TIFNo { get; set; }
        public string VounherNo { get; set; }



    }
    public class VoucherDetailsResultModel
    {
        public DateTime? ExpirationDate { get; set; }
        public string TransactionCode { get; set; }
        public string Barcode { get; set; }
        public string Amount { get; set; }
        public string StoreStock { get; set; }
        public string MaterialName { get; set; }
        public Guid MaterialObjectID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public Guid StockActionDetailObjectID { get; set; }

    }
    public class VoucherDetailsInputModel
    {
        public Guid StockActionObjectID { get; set; }
    }


    public class MaterialDetailsResultModel
    {
        public DateTime? OutDate { get; set; }
        public string OutLocation { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string MKYS_StokHareketID { get; set; }
        public Guid MaterialObjectID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public Guid StockActionDetailObjectID { get; set; }

    }
    public class MaterialDetailsInputModel
    {
        public Guid StockActionObjectID { get; set; }
        public Guid StockActionDetailObjectID { get; set; }
        public Guid MaterialObjectID { get; set; }
    }

    public class MaterialModelForDetailedSearch
    {
        public string NatoStockNO { get; set; } //tasinir kod
        public string Barcode { get; set; }
        public string MaterialName { get; set; }
        public int InAmount { get; set; } //giris miktari
        public int OutAmount { get; set; } //cikis miktari
        public double RestAmount { get; set; } // kalan miktar
        public Guid StockTransactionID { get; set; }
        public Guid StockActionObjectID { get; set; }
        public int StockActionID { get; set; }
        public List<StockAction> VoucherList { get; set; }
        public Guid MaterialObjectID { get; set; }
        public List<InventoryInfoModel> HospitalInventory { get; set; }
        public int? inventory { get; set; }
        public long? DocumentRecordLogID { get; set; }
        public DateTime? BidDate { get; set; }
        public string BidNumber { get; set; }

        public string CompanyName { get; set; }
        public string TakeinType { get; set; }

        public long VatRate { get; set; }
        public double UnitPriceWithinVat { get; set; }
        public double UnitPriceWithoutVat { get; set; }




    }

    public class ModelForInfoInput
    {
        public Guid MaterialStockTransactionID { get; set; }
    }

    public class OutTransactionDetailModel
    {
        public string StockHareketID { get; set; }
        public string OutPlace { get; set; }
        public DateTime? OutDate { get; set; }
        public double Amount { get; set; } //kac adet cikildigi bilgisini tutar.
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public Guid OutTransactionID { get; set; }


    }
    public class ModelForOutInfo
    {
        public StockTransaction OutTransaction { get; set; }
    }
    public class InventoryInfoModel
    {
        public int? Inventory { get; set; }
        public String StoreName { get; set; }
    }
    public class InventoryInput
    {
        public Guid MaterialObjectID { get; set; }
        public MovableTransactionInputVoucherFormViewModel viewModel { get; set; }
    }

}
