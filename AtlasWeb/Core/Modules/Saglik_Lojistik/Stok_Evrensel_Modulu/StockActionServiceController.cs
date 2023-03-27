//$4F2C3A22
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections;
using TTDataDictionary;
using TTConnectionManager;
using Microsoft.AspNetCore.Mvc;
using static TTObjectClasses.StockAction;
using TTUtils;
using TTDefinitionManagement;


namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class StockActionServiceController : Controller
    {
        public class OutableStockTransaction_Response
        {
            public string LotNo
            {
                get;
                set;
            }

            public DateTime? ExpirationDate
            {
                get;
                set;
            }

            public double Usedamount
            {
                get;
                set;
            }

            public double Restamount
            {
                get;
                set;
            }
        }

        public class OutableStockTransaction_Param
        {
            public string materialObjectID
            {
                get;
                set;
            }

            public string storeObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<OutableStockTransaction_Response> GetOutableStockTransactions(OutableStockTransaction_Param input)
        {
            List<OutableStockTransaction_Response> outableStockTransactionsList = new List<OutableStockTransaction_Response>();
            TTObjectContext ObjectContext = new TTObjectContext(true);
            Stock stock = null;
            IList stocks = null;
            string filterExpression = " STORE = '" + input.storeObjectID + "'" + " AND MATERIAL = '" + input.materialObjectID + "'";
            stocks = ObjectContext.QueryObjects(typeof(Stock).Name, filterExpression);
            if (stocks.Count > 0)
            {
                stock = (Stock)stocks[0];
            }

            BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(stock.ObjectID);
            foreach (StockTransaction.LOTOutableStockTransactions_Class outableStockTransaction in outableStockTransactions)
            {
                OutableStockTransaction_Response outtableLot = new OutableStockTransaction_Response();
                outtableLot.LotNo = outableStockTransaction.LotNo;
                if (outableStockTransaction.ExpirationDate == null)
                    outtableLot.ExpirationDate = DateTime.MinValue;
                else
                    outtableLot.ExpirationDate = outableStockTransaction.ExpirationDate;
                outtableLot.Restamount = Double.Parse(outableStockTransaction.Restamount.ToString());
                outtableLot.Usedamount = Double.Parse(outableStockTransaction.Usedamount.ToString());
                outableStockTransactionsList.Add(outtableLot);
            }

            return outableStockTransactionsList;
        }

        public class AutoSupplyRequestDetailCreate_Input
        {
            public TTObjectClasses.Store store
            {
                get;
                set;
            }

            public TTObjectClasses.SupplyRequestTypeEnum requestTypeEnum
            {
                get;
                set;
            }
        }

        public class AutoSupplyRequestDetailCreate_Output
        {
            public TTObjectClasses.Material material
            {
                get;
                set;
            }

            public int amount
            {
                get;
                set;
            }

            public DistributionTypeDefinition distributionType
            {
                get;
                set;
            }
        }

        [HttpPost]
        public List<AutoSupplyRequestDetailCreate_Output> AutoSupplyRequestDetailCreate(AutoSupplyRequestDetailCreate_Input input)
        {
            Type objectTypeDef = null;
            if (input.requestTypeEnum == SupplyRequestTypeEnum.demirbas)
            {
                objectTypeDef = typeof(FixedAssetDefinition);
            }

            if (input.requestTypeEnum == SupplyRequestTypeEnum.Ilac)
            {
                objectTypeDef = typeof(DrugDefinition);
            }

            if (input.requestTypeEnum == SupplyRequestTypeEnum.sarfMalzeme)
            {
                objectTypeDef = typeof(ConsumableMaterialDefinition);
            }

            using (var objectContext = new TTObjectContext(false))
            {
                if (input.store != null)
                    input.store = (TTObjectClasses.Store)objectContext.AddObject(input.store);
                List<AutoSupplyRequestDetailCreate_Output> autoSupplyRequestDetails = new List<AutoSupplyRequestDetailCreate_Output>();
                BindingList<Stock> stocks = input.store.Stocks.Select(" INHELD <= MINIMUMLEVEL  AND MINIMUMLEVEL <> 0 AND MAXIMUMLEVEL <> 0");
                foreach (Stock stock in stocks)
                {
                    if (objectTypeDef != null && stock.Material.GetType() == objectTypeDef)
                    {
                        AutoSupplyRequestDetailCreate_Output autoSupplyRequestDetail = new AutoSupplyRequestDetailCreate_Output();
                        autoSupplyRequestDetail.material = stock.Material;
                        autoSupplyRequestDetail.amount = (int)(stock.MaximumLevel - stock.Inheld);
                        autoSupplyRequestDetail.distributionType = stock.Material.StockCard.DistributionType;
                        autoSupplyRequestDetails.Add(autoSupplyRequestDetail);
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return autoSupplyRequestDetails;
            }
        }

        public class AutoDistributionCreate_Input
        {
            public TTObjectClasses.Store store
            {
                get;
                set;
            }

            public TTObjectClasses.Store destinationStore
            {
                get;
                set;
            }
        }

        public class AutoDistributionCreate_Output
        {
            public TTObjectClasses.Material material { get; set; }
            public int amount { get; set; }
            public DistributionTypeDefinition distributionType { get; set; }
            public StockCard stockCard { get; set; }
            public StockLevelType stockLevelType { get; set; }
            public int storeInheld { get; set; }
            public int destinationStoreInheld { get; set; }
            public int destinationStoreMaxLevel { get; set; }
        }

        [HttpPost]
        public List<AutoDistributionCreate_Output> AutoDistributionCreate(AutoDistributionCreate_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                Store store = (Store)objectContext.GetObject(input.store.ObjectID, typeof(Store));
                Store destientionStore = (Store)objectContext.GetObject(input.destinationStore.ObjectID, typeof(Store));
                List<AutoDistributionCreate_Output> newAutoDistributionCreate = new List<AutoDistributionCreate_Output>();
                BindingList<Stock> stocks = destientionStore.Stocks.Select(" INHELD <= MINIMUMLEVEL AND MINIMUMLEVEL <> 0 AND MAXIMUMLEVEL <> 0 ");
                List<Guid> resMaterial = new List<Guid>();
                List<Stock> requestMaterials = new List<Stock>();
                foreach (Stock s in stocks)
                {
                    BindingList<Stock> dests = store.Stocks.Select("MATERIAL = '" + s.Material.ObjectID + "'");
                    if (dests.Count > 0)
                    {
                        foreach (Stock d in dests)
                        {
                            if (s.Material == d.Material && d.Inheld > 0)
                            {
                                resMaterial.Add(s.Material.ObjectID);
                                requestMaterials.Add(s);
                            }
                        }
                    }

                    if (resMaterial.Count > 0)
                    {
                        BindingList<DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class> allReadyrequestedList = DistributionDocumentMaterial.GetExistAutoDistributionDoc(input.destinationStore.ObjectID, resMaterial);
                        foreach (DistributionDocumentMaterial.GetExistAutoDistributionDoc_Class differenceMaterial in allReadyrequestedList)
                        {
                            foreach (Stock st in requestMaterials)
                            {
                                if (st.Material.ObjectID == differenceMaterial.Material.Value)
                                {
                                    requestMaterials.Remove(st);
                                    if (requestMaterials.Count == 0)
                                        break;
                                }
                            }
                        }
                    }
                }

                if (requestMaterials.Count > 0)
                {
                    foreach (Stock autoDistribution in requestMaterials)
                    {
                        AutoDistributionCreate_Output mat = new AutoDistributionCreate_Output();
                        mat.material = autoDistribution.Material;
                        mat.amount = (int)(autoDistribution.MaximumLevel - autoDistribution.Inheld);
                        mat.stockCard = autoDistribution.Material.StockCard;
                        mat.distributionType = autoDistribution.Material.StockCard.DistributionType;
                        mat.stockLevelType = StockLevelType.NewStockLevel;
                        mat.destinationStoreInheld = (int)autoDistribution.Inheld;
                        mat.destinationStoreMaxLevel = (int)autoDistribution.MaximumLevel;
                        mat.storeInheld = (int)autoDistribution.Material.StockInheld(store);
                        newAutoDistributionCreate.Add(mat);
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return newAutoDistributionCreate;
            }
        }

        public class GetMKYSStokHareketTurEnumFromTedarik_Input
        {
            public TTObjectClasses.MkysServis.ETedarikTurID tedarikTuru
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.MkysServis.EGirisStokHareketTurID GetMKYSStokHareketTurEnumFromTedarik(GetMKYSStokHareketTurEnumFromTedarik_Input input)
        {
            var ret = StockAction.GetMKYSStokHareketTurEnumFromTedarik(input.tedarikTuru);
            return ret;
        }

        public class SendMKYSForInputDocumentTS_Input
        {
            public TTObjectClasses.StockAction stockAction
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }



        [HttpPost]
        public string SendMKYSForInputDocumentTS(SendMKYSForInputDocumentTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.stockAction != null)
                        if (!(input.stockAction is StockIn))
                            input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                    var ret = input.stockAction.SendMKYSForInputDocument(input.mkysPwd, input.stockAction.MKYS_MuayeneNo, input.stockAction.MKYS_MuayeneTarihi);
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public class SendITSTo_Input
        {
            public TTObjectClasses.StockAction stockAction
            {
                get;
                set;
            }
        }

        public class SendMKYSForOutputDocumentTS_Input
        {
            public TTObjectClasses.StockAction stockAction
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        public class SendUpdateMessageToMKYSTS_Input
        {
            public TTObjectClasses.StockAction stockAction
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        [HttpGet]
        public string GetMkysUserName()
        {
            return Common.CurrentResource.MkysUserName;
        }

        [HttpPost]
        public string SendMKYSForOutputDocumentTS(SendMKYSForOutputDocumentTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.stockAction != null)
                        input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                    var ret = input.stockAction.SendMKYSForOutputDocument(input.mkysPwd);
                    //StockAction.SendMKYSForOutputDocumentTS(input.stockAction,mkysPwd);
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        [HttpPost]
        public string ITSForOutDocumentRequest(SendITSTo_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.stockAction != null)
                        input.stockAction = (StockAction)objectContext.AddObject(input.stockAction);
                    var ret = ((ChattelDocumentOutputWithAccountancy)input.stockAction).ITSForOutDocument();
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        [HttpPost]
        public string ITSSendReceiptNotification(SendITSTo_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.stockAction != null)
                        input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                    var ret = input.stockAction.SendITSReceiptNotification();
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost]
        public string SendUpdateMessageToMKYSTS(SendUpdateMessageToMKYSTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.stockAction != null)
                        input.stockAction = (TTObjectClasses.StockAction)objectContext.AddObject(input.stockAction);
                    var ret = input.stockAction.SendUpdateMessageToMKYS(input.mkysPwd);
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public class SendIhaleTarihiVeNumarasiUpdateTS_Input
        {
            public TTObjectClasses.ChattelDocumentWithPurchase chattelDocumentWithPurchase
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        [HttpPost]
        public string SendIhaleTarihiVeNumarasiUpdateTS(SendIhaleTarihiVeNumarasiUpdateTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (input.chattelDocumentWithPurchase != null)
                        input.chattelDocumentWithPurchase = (TTObjectClasses.ChattelDocumentWithPurchase)objectContext.AddObject(input.chattelDocumentWithPurchase);
                    var ret = input.chattelDocumentWithPurchase.SendIhaleTarihiVeNumarasiUpdateMessageToMKYS(input.mkysPwd);
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Satin_Alma_Yoluyla_Tamam)]
        public List<MkysServis.stokHareketLogItem> GetMkysLogSearch(DocumentRecordLogReceiptNumber_Input input)
        {
            List<MkysServis.stokHareketLogItem> returnList = new List<MkysServis.stokHareketLogItem>();
            returnList = StockAction.MkysLogSearch(input.receiptNumber, input.password);
            return returnList;
        }

        [HttpPost]
        public bool DeleteMkysSelectedRowTS(DocumentRecordLogReceiptNumber_Input input)
        {
            DocumentRecordLog_Input inputSend = new DocumentRecordLog_Input();
            inputSend.password = input.password;
            inputSend.documentRecordLogObjectID = input.documentRecordLogObjectID;
            return StockAction.DeleteMkysSelectedRow(inputSend);
        }

        public class DocumentRecordLogReceiptNumber_Input
        {
            public int receiptNumber { get; set; }
            public DocumentTransactionTypeEnum transactionTypeEnum { get; set; }
            public string password { get; set; }
            public string documentRecordLogObjectID { get; set; }
        }

        public class SendDeleteMessageToMkysTS_Input
        {
            public Guid stockAction { get; set; }
            //public TTObjectClasses.StockAction stockAction
            //{
            //    get;
            //    set;
            //}

            public bool IsOutOperetion
            {
                get;
                set;
            }

            public int AyniyatMakbuzID
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        [HttpPost]
        public string SendDeleteMessageToMkysTS(SendDeleteMessageToMkysTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                StockAction stockAction = null;
                if (input.stockAction != Guid.Empty)
                {
                    stockAction = objectContext.GetObject<StockAction>(input.stockAction);
                    if (stockAction != null)
                    {
                        var ret = stockAction.SendDeleteMessageToMkys(input.IsOutOperetion, input.AyniyatMakbuzID, input.mkysPwd);
                        objectContext.FullPartialllyLoadedObjects();
                        return ret;
                    }
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;

            }
        }

        public class StockActionInspectionDetailTS_Input
        {
            public TTObjectClasses.InspectionUserTypeEnum[] signUserTypes
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.StockActionInspectionDetail> StockActionInspectionDetailTS(StockActionInspectionDetailTS_Input input)
        {
            var ret = StockAction.StockActionInspectionDetailTS(input.signUserTypes);
            return ret;
        }

        [HttpPost]
        public StockActionInspection_Output StockActionInspectionTS(StockActionInspectionDetailTS_Input input)
        {
            StockActionInspection_Output output = new StockActionInspection_Output();
            var ret = StockAction.StockActionInspectionTS(input.signUserTypes);
            output.stockActionInspection = ret;
            if (ret.StockActionInspectionDetails != null)
            {
                List<StockActionInspectionDetail> insDets = new List<StockActionInspectionDetail>();
                foreach (StockActionInspectionDetail det in ret.StockActionInspectionDetails)
                {
                    insDets.Add(det);
                }

                output.stockActionInspectionDets = insDets;
            }

            return output;
        }

        public class StockActionInspection_Output
        {
            public StockActionInspection stockActionInspection
            {
                get;
                set;
            }

            public List<StockActionInspectionDetail> stockActionInspectionDets
            {
                get;
                set;
            }
        }

        public class GetDocumentNumbersForMaterialClassReportQuery_Input
        {
            public Guid STOREID
            {
                get;
                set;
            }

            public Guid ACCOUNTINGTERM
            {
                get;
                set;
            }

            public Guid MAINCLASSID
            {
                get;
                set;
            }

            public string REFERENCELETTER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class> GetDocumentNumbersForMaterialClassReportQuery(GetDocumentNumbersForMaterialClassReportQuery_Input input)
        {
            var ret = StockAction.GetDocumentNumbersForMaterialClassReportQuery(input.STOREID, input.ACCOUNTINGTERM, input.MAINCLASSID, input.REFERENCELETTER);
            return ret;
        }

        public class StockActionWorkListNQL_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid StoreID
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction> StockActionWorkListNQL(StockActionWorkListNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockAction.StockActionWorkListNQL(objectContext, input.STARTDATE, input.ENDDATE, input.StoreID, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class UnitPriceStockActionOutDetailsReportQuery_Input
        {
            public string TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.UnitPriceStockActionOutDetailsReportQuery_Class> UnitPriceStockActionOutDetailsReportQuery(UnitPriceStockActionOutDetailsReportQuery_Input input)
        {
            var ret = StockAction.UnitPriceStockActionOutDetailsReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class StockActionInDetailsReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.StockActionInDetailsReportQuery_Class> StockActionInDetailsReportQuery(StockActionInDetailsReportQuery_Input input)
        {
            var ret = StockAction.StockActionInDetailsReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class GetDocumentSavingRegisterReportQuery_Input
        {
            public Guid ACCOUNTINGTERMID
            {
                get;
                set;
            }

            public long REGISTRATIONNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.GetDocumentSavingRegisterReportQuery_Class> GetDocumentSavingRegisterReportQuery(GetDocumentSavingRegisterReportQuery_Input input)
        {
            var ret = StockAction.GetDocumentSavingRegisterReportQuery(input.ACCOUNTINGTERMID, input.REGISTRATIONNO);
            return ret;
        }

        public class GetStockCardPresentationReportQuery_Input
        {
            public string STOCKCARDID
            {
                get;
                set;
            }

            public string STOREID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.GetStockCardPresentationReportQuery_Class> GetStockCardPresentationReportQuery(GetStockCardPresentationReportQuery_Input input)
        {
            var ret = StockAction.GetStockCardPresentationReportQuery(input.STOCKCARDID, input.STOREID, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class StockActionOutDetailsReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.StockActionOutDetailsReportQuery_Class> StockActionOutDetailsReportQuery(StockActionOutDetailsReportQuery_Input input)
        {
            var ret = StockAction.StockActionOutDetailsReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class CensusReportNQL_AllDocuments_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.CensusReportNQL_AllDocuments_Class> CensusReportNQL_AllDocuments(CensusReportNQL_AllDocuments_Input input)
        {
            var ret = StockAction.CensusReportNQL_AllDocuments(input.TERMID);
            return ret;
        }

        public class GetStockActionByTerm_Input
        {
            public Guid TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction> GetStockActionByTerm(GetStockActionByTerm_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockAction.GetStockActionByTerm(objectContext, input.TERMID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOuttableLots_Input
        {
            public Guid StoreID { get; set; }
            public Guid MaterialID { get; set; }
            public string MaterialName { get; set; }
            public Currency RequestAmount { get; set; }
            public string Barcode { get; set; }
            public string DistributionTypeName { get; set; }
        }

        public class GetOuttableLots_Output
        {
            public string LotNo { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string SerialNo { get; set; }
            public string BudgetTypeName { get; set; }
            public Currency RestAmount { get; set; }
            public Guid TrxObjectID { get; set; }
        }

        [HttpPost]
        public List<GetOuttableLots_Output> GetOuttableLots(GetOuttableLots_Input input)
        {
            List<GetOuttableLots_Output> outputs = new List<GetOuttableLots_Output>();
            BindingList<Stock.GetStockFromStoreAndMaterial_Class> stock = Stock.GetStockFromStoreAndMaterial(input.MaterialID, input.StoreID);
            if (stock.Count > 0)
            {
                BindingList<StockTransaction.UserSelectedOutableTransactionRQ_Class> usableTRXs = StockTransaction.UserSelectedOutableTransactionRQ(stock[0].ObjectID.Value);

                foreach (StockTransaction.UserSelectedOutableTransactionRQ_Class trx in usableTRXs)
                {
                    GetOuttableLots_Output output = new GetOuttableLots_Output();
                    if (trx.ExpirationDate.HasValue)
                        output.ExpirationDate = trx.ExpirationDate.Value;
                    else
                        output.ExpirationDate = DateTime.MinValue;
                    output.LotNo = trx.LotNo;
                    output.RestAmount = CurrencyType.ConvertFrom(trx.Restamount).Value;
                    output.SerialNo = trx.SerialNo;
                    output.BudgetTypeName = trx.Name;
                    output.TrxObjectID = trx.ObjectID.Value;
                    outputs.Add(output);
                }

            }
            return outputs;
        }

        public class CensusReportNQL_StockActionInDetailsReportQuery_Input
        {
            public string TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.CensusReportNQL_StockActionInDetailsReportQuery_Class> CensusReportNQL_StockActionInDetailsReportQuery(CensusReportNQL_StockActionInDetailsReportQuery_Input input)
        {
            var ret = StockAction.CensusReportNQL_StockActionInDetailsReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class SearchDocumentRegistryReportQuery_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.SearchDocumentRegistryReportQuery_Class> SearchDocumentRegistryReportQuery(SearchDocumentRegistryReportQuery_Input input)
        {
            var ret = StockAction.SearchDocumentRegistryReportQuery(input.injectionSQL);
            return ret;
        }

        public class StockActionWorkListNQLNoDate_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction> StockActionWorkListNQLNoDate(StockActionWorkListNQLNoDate_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockAction.StockActionWorkListNQLNoDate(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetStockActionsCount_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.GetStockActionsCount_Class> GetStockActionsCount(GetStockActionsCount_Input input)
        {
            var ret = StockAction.GetStockActionsCount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetTenderUpdateNQL_Input
        {
            public string ACTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction> GetTenderUpdateNQL(GetTenderUpdateNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = StockAction.GetTenderUpdateNQL(objectContext, input.ACTIONID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<StockAction.MKYSControlGetQuery_Class> MKYSControlGetQuery()
        {
            var ret = StockAction.MKYSControlGetQuery();
            return ret;
        }

        public class GetMaxMKYS_MakbuzNo_Input
        {
            public int DEPOKAYITNO
            {
                get;
                set;
            }

            public MKYS_EButceTurEnum BUTCE
            {
                get;
                set;
            }

            public int YIL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<StockAction.GetMaxMKYS_MakbuzNo_Class> GetMaxMKYS_MakbuzNo(GetMaxMKYS_MakbuzNo_Input input)
        {
            var ret = StockAction.GetMaxMKYS_MakbuzNo(input.DEPOKAYITNO, input.BUTCE, input.YIL);
            return ret;
        }

        public class InPatientPhysicianApplication_Input
        {
            public string inPatientPhysicianAppObjID
            {
                get;
                set;
            }
        }

        public class EpisodeID_Input
        {
            public string episodeID
            {
                get;
                set;
            }
        }

        public class InPatientPhysicianApplication_Output
        {
            public string clinicProtocolNo
            {
                get;
                set;
            }

            public string clinicName
            {
                get;
                set;
            }

            public string clinicRoom
            {
                get;
                set;
            }

            public string clinicBed
            {
                get;
                set;
            }

            public DateTime? clinicDischargeDate
            {
                get;
                set;
            }
            public Guid episodeObjectID
            {
                get;
                set;
            }
            public Guid patientObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public InPatientPhysicianApplication_Output GetInPatientPhysicianApplication_Info(InPatientPhysicianApplication_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientPhysicianApplication physicianApp = null;
                IList physicianApps = null;
                //string filterExpression = " OBJECTID = " + ConnectionManager.GuidToString(input.inPatientPhysicianAppObjID) ;
                string filterExpression = " OBJECTID = '" + input.inPatientPhysicianAppObjID + "'";
                physicianApps = objectContext.QueryObjects(typeof(InPatientPhysicianApplication).Name, filterExpression);
                if (physicianApps.Count > 0)
                {
                    physicianApp = (InPatientPhysicianApplication)physicianApps[0];
                }

                InPatientPhysicianApplication_Output output = new InPatientPhysicianApplication_Output();
                output.clinicProtocolNo = physicianApp.InPatientTreatmentClinicApp.ProtocolNo != null ? physicianApp.InPatientTreatmentClinicApp.ProtocolNo.Value.ToString() : "";
                output.clinicName = physicianApp.InPatientTreatmentClinicApp.MasterResource != null ? physicianApp.InPatientTreatmentClinicApp.MasterResource.Name : "";
                output.clinicRoom = physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room != null ? physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room.Name : "";
                output.clinicBed = physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != null ? physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.Name : "";
                if (physicianApp.InPatientTreatmentClinicApp.ClinicDischargeDate.HasValue)
                    output.clinicDischargeDate = (DateTime)physicianApp.InPatientTreatmentClinicApp.ClinicDischargeDate;
                output.episodeObjectID = physicianApp.Episode.ObjectID;
                output.patientObjectID = physicianApp.Episode.Patient.ObjectID;
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        [HttpPost]
        public InPatientPhysicianApplication_Output GetInPatientPhysicianApplication_InfoByEpisode(EpisodeID_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientPhysicianApplication physicianApp = null;
                IList physicianApps = null;
                physicianApps = InPatientPhysicianApplication.GetActiveInpatientPhAppByEpisode(objectContext, new Guid(input.episodeID));
                InPatientPhysicianApplication_Output output = null;
                if (physicianApps.Count == 1)
                {
                    physicianApp = (InPatientPhysicianApplication)physicianApps[0];
                    output = new InPatientPhysicianApplication_Output();
                    output.clinicProtocolNo = physicianApp.InPatientTreatmentClinicApp.ProtocolNo != null ? physicianApp.InPatientTreatmentClinicApp.ProtocolNo.Value.ToString() : "";
                    output.clinicName = physicianApp.InPatientTreatmentClinicApp.MasterResource != null ? physicianApp.InPatientTreatmentClinicApp.MasterResource.Name : "";
                    output.clinicRoom = physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room != null ? physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room.Name : "";
                    output.clinicBed = physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != null ? physicianApp.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.Name : "";
                    if (physicianApp.InPatientTreatmentClinicApp.ClinicDischargeDate.HasValue)
                        output.clinicDischargeDate = (DateTime)physicianApp.InPatientTreatmentClinicApp.ClinicDischargeDate;
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetDocumentRecordLogs_Input
        {
            public string stockActionID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Tasinir_Mal_Hesap_Sorumlusu, TTRoleNames.Klinik_Mal_Sorumlusu, TTRoleNames.Cep_Depo_Kullanicilari)]
        public List<DocumentRecordLog> GetDocumentRecordLogs(GetDocumentRecordLogs_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DocumentRecordLog> output = new List<DocumentRecordLog>();
                StockAction stockAction = (StockAction)objectContext.GetObject(new Guid(input.stockActionID), typeof(StockAction));
                foreach (DocumentRecordLog log in stockAction.DocumentRecordLogs)
                    output.Add(log);
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetEquivalentDrug_Input
        {
            public Guid materialObjectID
            {
                get;
                set;
            }

            public Guid storeObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<EquivalentInfo> GetEquivalentDrug(GetEquivalentDrug_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<EquivalentInfo> equivalentDrugs = new List<EquivalentInfo>();
                Material material = (Material)objectContext.GetObject(input.materialObjectID, typeof(Material));
                if (material is DrugDefinition)
                {
                    DrugDefinition drugDef = (DrugDefinition)material;
                    IList allEquivalentDrugs = drugDef.GetEquivalentDrugs();
                    foreach (DrugDefinition drug in allEquivalentDrugs)
                    {
                        if (drug.Stocks.Select("STORE='" + input.storeObjectID + "' AND INHELD > 0").Count > 0)
                        {

                            EquivalentInfo equivalentInfo = new EquivalentInfo();
                            equivalentInfo.drugObjectId = drug.ObjectID.ToString();
                            equivalentInfo.name = drug.Name;
                            equivalentInfo.barcode = drug.Barcode;
                            equivalentDrugs.Add(equivalentInfo);

                        }
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return equivalentDrugs;
            }
        }

        public class EquivalentInfo
        {
            public string drugObjectId
            {
                get;
                set;
            }

            public string name
            {
                get;
                set;
            }

            public string barcode
            {
                get;
                set;
            }
        }

        public class SendBarkodUpdateTS_Input
        {
            public string newBarcode { get; set; }
            public int MKYS_StokHareketID { get; set; }
            public string mkysPwd { get; set; }
        }


        [HttpPost]
        public string SendBarkodUpdateTS(SendBarkodUpdateTS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var ret = StockActionDetailIn.SendBarkodUpdateMessageToMKYS(input.mkysPwd, input.MKYS_StokHareketID, input.newBarcode);
                    objectContext.FullPartialllyLoadedObjects();
                    return ret;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public class SendUTSUpdateTS_Input
        {
            public string newLot { get; set; }
            public string newUTSAlma { get; set; }
            public string newUTSVerme { get; set; }
            public string StockActionDetailInObjID { get; set; }
        }


        [HttpPost]
        public bool SendUTSUpdateTS(SendUTSUpdateTS_Input input)
        {

            bool returnVal = false;
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    StockActionDetailIn stockActionDetailIn = (StockActionDetailIn)objectContext.GetObject(new Guid(input.StockActionDetailInObjID), typeof(StockActionDetailIn).Name);
                    stockActionDetailIn.LotNo = input.newLot;
                    stockActionDetailIn.ReceiveNotificationID = input.newUTSAlma;
                    stockActionDetailIn.IncomingDeliveryNotifID = input.newUTSVerme;

                    StockTransaction stockTransaction = (StockTransaction)objectContext.GetObject(stockActionDetailIn.StockTransactions.Select(string.Empty).FirstOrDefault().ObjectID, typeof(StockTransaction).Name);
                    stockTransaction.LotNo = input.newLot;
                    stockTransaction.ReceiveNotificationID = input.newUTSAlma;
                    stockTransaction.IncomingDeliveryNotifID = input.newUTSVerme;

                    List<StockTransaction.getOutPutsDVO> EmptyList = new List<StockTransaction.getOutPutsDVO>();
                    List<StockTransaction.getOutPutsDVO> returnOutStockTransactions = StockTransaction.GetFirstOutTransaction(EmptyList, stockTransaction);

                    foreach (StockTransaction.getOutPutsDVO putsDVO in returnOutStockTransactions)
                    {
                        if (putsDVO.stockTransaction.CurrentStateDefID != StockTransaction.States.Cancelled)
                        {
                            putsDVO.stockTransaction.LotNo = input.newLot;
                            putsDVO.stockTransaction.ReceiveNotificationID = input.newUTSAlma;
                            putsDVO.stockTransaction.IncomingDeliveryNotifID = input.newUTSVerme;
                        }
                    }


                    objectContext.Save();
                    objectContext.Dispose();
                    returnVal = true;
                    return returnVal;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public class CancelStockActionDetail_Input
        {
            public Guid stockActionDetailObjectID { get; set; }
        }

        [HttpPost]
        public bool CancelStockActionDetail(CancelStockActionDetail_Input input)
        {
            bool ret = false;
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    StockActionDetail stockActionDetail = (StockActionDetail)objectContext.GetObject(input.stockActionDetailObjectID, typeof(StockActionDetail));
                    stockActionDetail.Status = StockActionDetailStatusEnum.Cancelled;
                    foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select(string.Empty))
                    {
                        if (stockTransaction.CurrentStateDefID.Equals(StockTransaction.States.Cancelled) == false)
                        {
                            stockTransaction.CurrentStateDefID = StockTransaction.States.Cancelled;
                        }
                    }
                    objectContext.Save();
                    ret = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return ret;
        }


        public class GetExtendExpDateIn_Input
        {
            public Guid supllierID
            {
                get;
                set;
            }

            public int outID
            {
                get;
                set;
            }
        }


        [HttpPost]
        public List<ExtendExpDateInDetail> GetExtendExpDateIn(GetExtendExpDateIn_Input input)
        {
            List<ExtendExpDateInDetail> output = new List<ExtendExpDateInDetail>();
            using (var objectContext = new TTObjectContext(false))
            {
                IBindingList outActions = objectContext.QueryObjects("EXTENDEXPDATEOUT", "STOCKACTIONID=" + input.outID.ToString());
                if (outActions.Count > 0)
                {
                    ExtendExpDateOut extendExpDateOut = (ExtendExpDateOut)outActions[0];
                    foreach (ExtendExpDateOutDetail extendExpDateOutDetail in extendExpDateOut.ExtendExpDateOutDetails)
                    {
                        foreach (StockTransaction outTrx in extendExpDateOutDetail.StockTransactions.Select(string.Empty))
                        {
                            ExtendExpDateInDetail extendExpDateInDetail = new ExtendExpDateInDetail(objectContext);
                            extendExpDateInDetail.Material = outTrx.Stock.Material;
                            extendExpDateInDetail.Amount = outTrx.Amount;
                            extendExpDateInDetail.Status = StockActionDetailStatusEnum.New;
                            extendExpDateInDetail.StockLevelType = StockLevelType.NewStockLevel;
                            extendExpDateInDetail.UnitPrice = outTrx.UnitPrice;
                            extendExpDateInDetail.VatRate = outTrx.VatRate;

                            extendExpDateInDetail.DiscountAmount = 0;
                            extendExpDateInDetail.DiscountRate = 0;
                            extendExpDateInDetail.NotDiscountedUnitPrice = outTrx.UnitPrice;
                            extendExpDateInDetail.TotalDiscountAmount = 0;
                            extendExpDateInDetail.TotalPriceNotDiscount = (BigCurrency)outTrx.Amount * outTrx.UnitPrice;
                            output.Add(extendExpDateInDetail);
                        }
                    }

                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetInPatientPhysicianApplications_Input
        {
            public string SearchKey { get; set; }
        }

        public class GetDrugTime_Input
        {
            public string ksObjectID { get; set; }
            public bool isOwnDrug { get; set; }
        }

        public class GetInPatientPhysicianApplications_Output
        {
            public string Key { get; set; }
            public InPatientPhysicianApplication InPatientPhysicianApplication { get; set; }
            public string PatientInfo { get; set; }
            public string Description { get; set; }
            public bool InvoiceControl { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GetInPatientPhysicianApplications_Output> GetInPatientPhysicianApplications(GetInPatientPhysicianApplications_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<GetInPatientPhysicianApplications_Output> output = new List<GetInPatientPhysicianApplications_Output>();
                string PatientID = string.Empty;
                string SubEpisodeID = string.Empty;
                if (input.SearchKey.Length == 11)
                    PatientID = input.SearchKey;
                else
                    SubEpisodeID = input.SearchKey;
                BindingList<SubEpisode> subEpisodes = new BindingList<SubEpisode>();
                SubEpisode subEpisode = null;
                if (String.IsNullOrEmpty(PatientID) == false)
                    subEpisodes = SubEpisode.GetInpatientSubEpisodeByPatient(objectContext, PatientID);

                if (String.IsNullOrEmpty(SubEpisodeID) == false)
                    subEpisodes = SubEpisode.GetByProtocolNoForInpatient(objectContext, SubEpisodeID);

                if (subEpisodes.Count > 0)
                    subEpisode = subEpisodes[0];
                if (subEpisode != null)
                {
                    IBindingList InPatientPhysicianApplications = objectContext.QueryObjects<InPatientPhysicianApplication>("SUBEPISODE = " + ConnectionManager.GuidToString(subEpisode.ObjectID));

                    foreach (InPatientPhysicianApplication inPatientApp in InPatientPhysicianApplications)
                    {
                        GetInPatientPhysicianApplications_Output outputDetail = new GetInPatientPhysicianApplications_Output();
                        outputDetail.InvoiceControl = false;
                        outputDetail.Description = inPatientApp.SubEpisode.ProtocolNo + " Protokol Nolu " + inPatientApp.Episode.Patient.FullName + " isimli hastanın " + inPatientApp.MasterResource.Name + " yatışı için alınmıştır.";
                        string faturaDrumu = "";
                        if (inPatientApp.SubEpisode.IsInvoicedCompletely)
                        {
                            faturaDrumu = "Faturası Kesilmiş - ";
                            outputDetail.InvoiceControl = true;
                            outputDetail.Description = "Seçilen hastanın faturası kesilmiştir. Önce faturanın iptali gerekmektedir";
                        }

                        if (inPatientApp.SubEpisode.CurrentStateDefID == SubEpisode.States.Cancelled)
                        {
                            faturaDrumu = "İptal - ";
                            outputDetail.InvoiceControl = true;
                            outputDetail.Description = "Hastanın kaydı iptal edilmiştir. Lütfen doğru yatışı üzerine giriş yapınız";
                        }
                        outputDetail.Key = faturaDrumu + inPatientApp.Episode.Patient.FullName + " - " + inPatientApp.MasterResource.Name + " - " + inPatientApp.SubEpisodeOpeningDate().ToShortDateString();
                        outputDetail.InPatientPhysicianApplication = inPatientApp;
                        outputDetail.PatientInfo = inPatientApp.Episode.Patient.UniqueRefNo.ToString() + " - " + inPatientApp.Episode.Patient.FullName;

                        output.Add(outputDetail);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DrugOrderDetail> GetDrugTime(GetDrugTime_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugOrderDetail> returnDetail = new List<DrugOrderDetail>();
                if (input.isOwnDrug == false)
                {
                    KScheduleMaterial material = (KScheduleMaterial)objectContext.GetObject(new Guid(input.ksObjectID), typeof(KScheduleMaterial));
                    if (material != null)
                    {
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(material.DrugOrderObjectID.Value, typeof(DrugOrder));
                        if (drugOrder != null)
                        {
                            foreach (DrugOrderDetail item in drugOrder.DrugOrderDetails.Select(string.Empty))
                            {
                                returnDetail.Add(item);
                            }
                        }

                    }
                }
                else
                {
                    KSchedulePatienOwnDrug material = (KSchedulePatienOwnDrug)objectContext.GetObject(new Guid(input.ksObjectID), typeof(KSchedulePatienOwnDrug));
                    if (material != null)
                    {
                        DrugOrder drugOrder = (DrugOrder)objectContext.GetObject(material.DrugOrderObjectID.Value, typeof(DrugOrder));
                        if (drugOrder != null)
                        {
                            foreach (DrugOrderDetail item in drugOrder.DrugOrderDetails.Select(string.Empty))
                            {
                                returnDetail.Add(item);
                            }
                        }

                    }
                }
                return returnDetail;
            }
        }

        public class ParseQRcode_Input
        {
            public string qrCode { get; set; }
        }
        public class ParseQRcode_Output
        {
            public long Barcode { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string GTIN { get; set; }
            public string BatchNo { get; set; }
            public string ExpiryDate { get; set; }
            public string PackageCode { get; set; }
            public string Karekod { get; set; }
        }

        [HttpPost]
        public ParseQRcode_Output ParseQRCode(ParseQRcode_Input input)
        {
            Code2D code2D = new Code2D(input.qrCode);
            ParseQRcode_Output output = new ParseQRcode_Output();
            output.Barcode = code2D.Barcode;
            output.BatchNo = code2D.BatchNo;
            output.ExpirationDate = code2D.ExpirationDate;
            output.ExpiryDate = code2D.ExpiryDate;
            output.GTIN = code2D.GTIN;
            output.Karekod = code2D.Karekod;
            output.PackageCode = code2D.PackageCode;
            return output;
        }

        public class MainStoreDVO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }
        public class BudgetTypeDefDVO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }

        public class StockTransactionDefDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
        }

        public class OutTypeDVO
        {
            public string TypeName { get; set; }
        }

        public class DocumentRecordLogInitDVO
        {
            public List<MainStoreDVO> mainStores { get; set; }
            public List<OutTypeDVO> outTypes { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public long startTIFNo { get; set; }
            public long endTIFNo { get; set; }
        }

        [HttpPost]
        public DocumentRecordLogInitDVO GetDocumentRecordLogInitDVO()
        {
            DocumentRecordLogInitDVO output = new DocumentRecordLogInitDVO();
            output.mainStores = new List<MainStoreDVO>();
            BindingList<MainStoreDefinition.GetMainStoreDefinition_Class> stores = MainStoreDefinition.GetMainStoreDefinition("WHERE ISACTIVE = 1");
            foreach (MainStoreDefinition.GetMainStoreDefinition_Class ms in stores)
            {
                MainStoreDVO mainStore = new MainStoreDVO();
                mainStore.ObjectID = ms.ObjectID.Value;
                mainStore.Name = ms.Name;
                output.mainStores.Add(mainStore);
            }
            output.outTypes = new List<OutTypeDVO>();
            List<string> groupSubjects = new List<string>();
            BindingList<DocumentRecordLog.SearchDocumentRecordLogRQ_Class> subjects = DocumentRecordLog.SearchDocumentRecordLogRQ("WHERE DOCUMENTTRANSACTIONTYPE=1");
            foreach (DocumentRecordLog.SearchDocumentRecordLogRQ_Class s in subjects)
            {
                if (groupSubjects.Contains(s.Subject) == false)
                {
                    OutTypeDVO outType = new OutTypeDVO();
                    outType.TypeName = s.Subject;
                    output.outTypes.Add(outType);
                    groupSubjects.Add(s.Subject);
                }
            }
            var newList = output.outTypes.OrderBy(x => x.TypeName).ToList();
            output.outTypes = newList;
            output.startDate = new DateTime(Common.RecTime().Year, 1, 1);
            output.endDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day);
            output.startTIFNo = 0;
            output.endTIFNo = 9999;
            return output;
        }

        public class GetDocumentRecordLogsSameMKYS_Input
        {
            public Guid mainStoreID { get; set; }
            public string outType { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public long startTIFNo { get; set; }
            public long endTIFNo { get; set; }
        }

        public class GetDocumentRecordLogsSameMKYS_Output
        {
            public string TIFNo { get; set; }
            public DateTime TransactionDate { get; set; }
            public string TakenGivenPlace { get; set; }
            public string Subject { get; set; }
            public MKYSControlEnum MKYSStatus { get; set; }
            public Guid DocumentRecordLogID { get; set; }
            public Guid StockActionID { get; set; }
            public Guid StockActionDefID { get; set; }
            public MKYS_EButceTurEnum BudgetType { get; set; }
        }

        [HttpPost]
        public List<GetDocumentRecordLogsSameMKYS_Output> GetDocumentRecordLogsSameMKYS(GetDocumentRecordLogsSameMKYS_Input input)
        {
            List<GetDocumentRecordLogsSameMKYS_Output> output = new List<GetDocumentRecordLogsSameMKYS_Output>();
            DateTime sDate = new DateTime(input.startDate.Year, input.startDate.Month, input.startDate.Day, 0, 0, 0);
            DateTime eDate = new DateTime(input.endDate.Year, input.endDate.Month, input.endDate.Day, 23, 59, 59);
            BindingList<DocumentRecordLog.GetDocumentRecordLogByTrxType_Class> documents = DocumentRecordLog.GetDocumentRecordLogByTrxType(input.mainStoreID, sDate, eDate, 1, input.startTIFNo, input.endTIFNo);
            foreach (DocumentRecordLog.GetDocumentRecordLogByTrxType_Class doc in documents)
            {
                if (string.IsNullOrEmpty(input.outType))
                {
                    GetDocumentRecordLogsSameMKYS_Output outputItem = new GetDocumentRecordLogsSameMKYS_Output();
                    outputItem.DocumentRecordLogID = doc.ObjectID.Value;
                    outputItem.MKYSStatus = doc.MKYSStatus.Value;
                    outputItem.StockActionDefID = doc.Stockactiondefid.Value;
                    outputItem.StockActionID = doc.Stockactionid.Value;
                    outputItem.Subject = doc.Subject;
                    outputItem.TakenGivenPlace = doc.TakenGivenPlace;
                    outputItem.TIFNo = doc.DocumentRecordLogNumber.Value.ToString();
                    outputItem.TransactionDate = doc.TransactionDate.Value;
                    outputItem.BudgetType = doc.BudgeType.Value;
                    output.Add(outputItem);
                }
                else
                {
                    if (input.outType.Equals(doc.Subject) == true)
                    {
                        GetDocumentRecordLogsSameMKYS_Output outputItem = new GetDocumentRecordLogsSameMKYS_Output();
                        outputItem.DocumentRecordLogID = doc.ObjectID.Value;
                        outputItem.MKYSStatus = doc.MKYSStatus.Value;
                        outputItem.StockActionDefID = doc.Stockactiondefid.Value;
                        outputItem.StockActionID = doc.Stockactionid.Value;
                        outputItem.Subject = doc.Subject;
                        outputItem.TakenGivenPlace = doc.TakenGivenPlace;
                        outputItem.TIFNo = doc.DocumentRecordLogNumber.Value.ToString();
                        outputItem.TransactionDate = doc.TransactionDate.Value;
                        outputItem.BudgetType = doc.BudgeType.Value;
                        output.Add(outputItem);
                    }
                }
            }
            return output;
        }

        public class GetDocumentRecordLogsDetails_Input
        {
            public Guid StockActionID { get; set; }
            public MKYS_EButceTurEnum BudgetType { get; set; }
        }

        public class GetDocumentRecordLogsDetails_Output
        {
            public string NatoStockNo { get; set; }
            public string MaterialName { get; set; }
            public Currency Amount { get; set; }
            public string DistributionType { get; set; }
            public Currency UnitPrice { get; set; }
            public Currency TotalPrice { get; set; }
        }

        [HttpPost]
        public List<GetDocumentRecordLogsDetails_Output> GetDocumentRecordLogsDetails(GetDocumentRecordLogsDetails_Input input)
        {
            List<GetDocumentRecordLogsDetails_Output> output = new List<GetDocumentRecordLogsDetails_Output>();
            BindingList<StockTransaction.StockTransactionOutDetailsReportQuery_Class> details = StockTransaction.StockTransactionOutDetailsReportQuery(input.StockActionID, (int)input.BudgetType);
            foreach (StockTransaction.StockTransactionOutDetailsReportQuery_Class det in details)
            {
                GetDocumentRecordLogsDetails_Output outputItem = new GetDocumentRecordLogsDetails_Output();
                outputItem.Amount = Currency.Parse(det.Amount.ToString());
                outputItem.DistributionType = det.DistributionType;
                outputItem.MaterialName = det.Materialname;
                outputItem.NatoStockNo = det.NATOStockNO;
                outputItem.UnitPrice = Currency.Parse(det.Unitprice.ToString());
                outputItem.TotalPrice = outputItem.Amount * outputItem.UnitPrice;
                output.Add(outputItem);
            }
            return output;
        }

        public class GetPurchaseStockAction_Input
        {
            public string StockActionID { get; set; }
            public Guid StoreID { get; set; }
        }

        public class GetPurchaseStockAction_Output
        {
            public ChattelDocumentWithPurchase PurchaseAction { get; set; }
            public List<ChattelDocumentDetailWithPurchase> PurchaseActionDetails { get; set; }
            public List<Material> Materials { get; set; }
        }

        [HttpPost]
        public GetPurchaseStockAction_Output GetPurchaseStockAction(GetPurchaseStockAction_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GetPurchaseStockAction_Output output = new GetPurchaseStockAction_Output();
                IBindingList purchaseAction = objectContext.QueryObjects("DOCUMENTRECORDLOG", "DOCUMENTRECORDLOGNUMBER=" + input.StockActionID + " AND STOCKACTION.STORE = " + ConnectionManager.GuidToString(input.StoreID) + "AND STOCKACTION.MKYS_ETEDARIKTURU = 51");
                if (purchaseAction.Count > 0)
                {
                    DocumentRecordLog documentRecordLog = (DocumentRecordLog)purchaseAction[0];
                    ChattelDocumentWithPurchase purchase = (ChattelDocumentWithPurchase)documentRecordLog.StockAction;
                    output.PurchaseAction = purchase;
                    output.PurchaseActionDetails = purchase.ChattelDocumentDetailsWithPurchase.ToList();
                    output.Materials = new List<Material>();
                    foreach (ChattelDocumentDetailWithPurchase detail in purchase.ChattelDocumentDetailsWithPurchase)
                    {
                        if (output.Materials.Contains(detail.Material) == false)
                            output.Materials.Add(detail.Material);
                    }
                }
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }


        public class GetInoutRemaining_Input
        {

            public Guid mainStoreID { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public Guid? materialObjectID { get; set; }
            public Guid budgetTypeObjectID { get; set; }
        }

        public class GetInoutRemaining_Output
        {
            public Currency devirTutar { get; set; }
            public Currency devirMiktar { get; set; }
            public Currency girisTutar { get; set; }
            public double girisMiktar { get; set; }
            public Currency cikisTutar { get; set; }
            public double cikisMiktar { get; set; }
            public Currency kalanTutar { get; set; }
            public double kalanMiktar { get; set; }
        }

        public class InOutRemainingDTO
        {
            public List<MainStoreDVO> mainStores { get; set; }
            public List<BudgetTypeDefDVO> budgetTypeDefinitions { get; set; }
            public List<StockTransactionDefDTO> stockTransactionDefList { get; set; }

        }

        [HttpPost]
        public InOutRemainingDTO GetInoutRemainingInitDVO()
        {
            InOutRemainingDTO output = new InOutRemainingDTO();
            output.mainStores = new List<MainStoreDVO>();
            output.budgetTypeDefinitions = new List<BudgetTypeDefDVO>();
            output.stockTransactionDefList = new List<StockTransactionDefDTO>();

            output.mainStores = MainStoreDefinition.GetMainStoreDefinition("WHERE ISACTIVE = 1").Select(ms => new MainStoreDVO()
            {
                ObjectID = ms.ObjectID.Value,
                Name = ms.Name
            }).ToList();


            output.budgetTypeDefinitions = BudgetTypeDefinition.GetBudgetTypeDefinitionList(string.Empty).Select(s => new BudgetTypeDefDVO()
            {
                ObjectID = s.ObjectID.Value,
                Name = s.Name
            }).ToList();

            output.stockTransactionDefList = StockTransactionDefinition.GetStockTransactionDefinition(" WHERE MAINTAINLEVELCODE IN (4,128) AND ISTOTALREPORT IS NOT NULL ").Select(x => new StockTransactionDefDTO()
            {
                Name = x.Description,
                ObjectID = x.ObjectID.Value
            }).ToList();


            return output;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public LoadResult GetMaterialList([FromBody] DataSourceLoadOptions loadOptions, [FromQuery] Guid storeID)
        {
            LoadResult result = null;

            string definitionName = loadOptions.Params.definitionName;
            string searchText = loadOptions.Params.searchText;

            using (var objectContext = new TTObjectContext(true))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].QueryDefs["GetMaterialListQuery"];
                var paramList = new Dictionary<string, object>();
                //paramList.Add("OBJECTDEFID", "65a2337c-bc3c-4c6b-9575-ad47fa7a9a89");
                var injection = "MKYSMALZEMEKODU IS NOT NULL AND STOCKS.INHELD IS NOT NULL AND STOCKS.STORE ='" + storeID.ToString() + "'";
                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, injection);
            }
            return result;
        }

        [HttpPost]
        public GetInoutRemaining_Output GetInoutRemaining(GetInoutRemaining_Input input)
        {
            GetInoutRemaining_Output output = new GetInoutRemaining_Output();
            string injection = string.Empty;
            if (input.materialObjectID != null && input.materialObjectID != Guid.Empty)
            {
                injection = " AND THIS.Stock.Material =" + TTConnectionManager.ConnectionManager.GuidToString((Guid)input.materialObjectID);
            }
            BindingList<StockTransaction.GetInoutRemainingRQ_Class> returnRQ = StockTransaction.GetInoutRemainingRQ(input.mainStoreID, input.startDate, input.endDate, input.budgetTypeObjectID, injection);
            foreach (StockTransaction.GetInoutRemainingRQ_Class item in returnRQ)
            {
                if (item.InOut == TransactionTypeEnum.In)
                {
                    output.girisMiktar = Double.Parse(item.Amount.ToString());
                    output.girisTutar = Double.Parse(item.Total.ToString());
                }
                if (item.InOut == TransactionTypeEnum.Out)
                {
                    output.cikisMiktar = Double.Parse(item.Amount.ToString());
                    output.cikisTutar = Double.Parse(item.Total.ToString());
                }
            }

            if (input.startDate.Month == 1 && input.startDate.Day == 1)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                MainStoreDefinition mainStoreDefinition = objectContext.GetObject<MainStoreDefinition>(input.mainStoreID);
                AccountingTerm accountingTerm = mainStoreDefinition.Accountancy.GetOpenAccountingTerm();
                BindingList<MkysCensusSyncData.GetInStockTransactionID_Class> censusTRXs = MkysCensusSyncData.GetInStockTransactionID(accountingTerm.PrevTerm.ObjectID);
                List<Guid> censusTRXIDs = censusTRXs.Select(x => x.StockTransactionGuid.Value).ToList();
                int listCount = censusTRXIDs.Count();

                BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> censusInTRXs = new BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class>();
                for (int i = 0; i < listCount; i = i + 1000)
                {
                    List<Guid> tempCensusTRXIDs = censusTRXIDs.Skip(i).Take(1000).ToList();
                    BindingList<StockTransaction.GetCensusStockTransactionLikeMKYS_Class> tempCensusInTRXs = StockTransaction.GetCensusStockTransactionLikeMKYS(tempCensusTRXIDs, input.materialObjectID.Value, input.budgetTypeObjectID, accountingTerm.StartDate.Value);
                    foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in tempCensusInTRXs)
                    {
                        censusInTRXs.Add(census);
                    }
                }

                foreach (StockTransaction.GetCensusStockTransactionLikeMKYS_Class census in censusInTRXs)
                {
                    output.devirMiktar += Convert.ToDouble(census.Censusamount);
                    output.devirTutar += Double.Parse(census.UnitPrice.ToString());
                }

                output.kalanMiktar = output.devirMiktar + output.girisMiktar - output.cikisMiktar;
                output.kalanTutar = output.devirTutar + output.girisTutar - output.cikisTutar;
            }
            else
            {
                output.kalanMiktar = output.girisMiktar - output.cikisMiktar;
                output.kalanTutar = output.girisTutar - output.cikisTutar;
            }
            return output;
        }

        public class CheckDocumentRecordLogForDelete_Input
        {
            public Guid DocumentRecordLogID { get; set; }
        }

        public class CheckDocumentRecordLogForDelete_Output
        {
            public Guid DocumentRecordLogID { get; set; }
            public string StockActionID { get; set; }
            public string DocumentRecordLogNo { get; set; }
            public string StockActionName { get; set; }
            public string ReceiptNumber { get; set; }
        }

        [HttpPost]
        public List<CheckDocumentRecordLogForDelete_Output> CheckDocumentRecordLogForDelete(CheckDocumentRecordLogForDelete_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<CheckDocumentRecordLogForDelete_Output> output = new List<CheckDocumentRecordLogForDelete_Output>();
                List<DocumentRecordLog> deleteDocument = new List<DocumentRecordLog>();
                DocumentRecordLog documentRecordLog = (DocumentRecordLog)objectContext.GetObject(input.DocumentRecordLogID, typeof(DocumentRecordLog));
                List<StockTransaction> intrxs = new List<StockTransaction>();
                foreach (StockActionDetail stockActionDetail in documentRecordLog.StockAction.StockActionDetails)
                {
                    foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select(""))
                    {
                        if (stockTransaction.BudgetTypeDefinition.MKYS_Butce == documentRecordLog.BudgeType)
                            intrxs.Add(stockTransaction);
                    }
                }
                foreach (StockTransaction intrx in intrxs)
                {
                    foreach (StockTransactionDetail outTrx in intrx.StockTransactionDetails)
                    {
                        if (outTrx.OutStockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                        {
                            DocumentRecordLog outLog = outTrx.OutStockTransaction.StockActionDetail.StockAction.DocumentRecordLogs.Where(x => x.BudgeType == documentRecordLog.BudgeType && x.MKYSStatus == MKYSControlEnum.CompletedSent).FirstOrDefault();
                            if (outLog != null)
                            {
                                if (deleteDocument.Contains(outLog) == false)
                                {
                                    deleteDocument.Add(outLog);
                                }
                            }
                        }
                    }
                }

                foreach (DocumentRecordLog log in deleteDocument)
                {
                    CheckDocumentRecordLogForDelete_Output item = new CheckDocumentRecordLogForDelete_Output();
                    item.DocumentRecordLogID = log.ObjectID;
                    item.DocumentRecordLogNo = log.DocumentRecordLogNumber.Value.ToString();
                    item.ReceiptNumber = log.ReceiptNumber.ToString();
                    item.StockActionID = log.StockAction.StockActionID.ToString();
                    item.StockActionName = log.StockAction.ObjectDef.DisplayText;
                    output.Add(item);
                }

                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetLogisticPatientDocumentInput_Input
        {
            public Guid InpatientAppID { get; set; }
        }

        public class GetLogisticPatientDocumentInput
        {
            public string episodeActionID { get; set; }
            public string episodeID { get; set; }
            public string patientID { get; set; }
            public Episode episode { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetLogisticPatientDocumentInput GetLogisticPatientDocumentInputDVO(GetLogisticPatientDocumentInput_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GetLogisticPatientDocumentInput output = new GetLogisticPatientDocumentInput();
                InPatientPhysicianApplication inPatientPhysicianApp = (InPatientPhysicianApplication)objectContext.GetObject(input.InpatientAppID, typeof(InPatientPhysicianApplication));
                output.episodeActionID = inPatientPhysicianApp.ObjectID.ToString();
                output.episodeID = inPatientPhysicianApp.Episode.ObjectID.ToString();
                output.patientID = inPatientPhysicianApp.Episode.Patient.ObjectID.ToString();
                output.episode = inPatientPhysicianApp.Episode;
                objectContext.FullPartialllyLoadedObjects();
                return output;
            }
        }

        public class GetEpisodeActionIDForStockOut_Input
        {
            public Guid StockOutID { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public string GetEpisodeActionIDForStockOut(GetEpisodeActionIDForStockOut_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                StockOut stockOut = (StockOut)objectContext.GetObject(input.StockOutID, typeof(StockOut));
                return stockOut.StockActionDetails[0].SubActionMaterial[0].EpisodeAction.ObjectID.ToString();
            }
        }

    }
}