
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Stok Hareketleri için kullanılan temel sınıftır. Ortak stok hareketi bilgilerini tutar.
    /// </summary>
    public partial class StockTransaction : TTObject
    {
        public partial class GetSpendByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMonthlyConsumptionReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class ConsumableStockCardQuery_Class : TTReportNqlObject
        {
        }

        public partial class StockTransactionReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialConsumptionAmount_Class : TTReportNqlObject
        {
        }

        public partial class ConsumableMaterialForStoreQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockCardForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetChequeDocumentForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledStockTransactions_Old_Class : TTReportNqlObject
        {
        }

        public partial class GetMainFieldsForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetReturningDocumentForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetConsumptionDocumentForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetDistributionDocumentForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetOtherDocumentsForStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class FIFOOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class GetSpendAmountForMaterialRequestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialIDQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetStockTransactions_Class : TTReportNqlObject
        {
        }

        public partial class GetTransactionsForCardPresentationReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetTransactionRestAmountRQ_Class : TTReportNqlObject
        {
        }

        public partial class LIFOOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class RestFIFOStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class RestLIFOStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledStockTransactions_Class : TTReportNqlObject
        {
        }

        public partial class ExpirationDateApproachingQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetMaterialExpirationScheduleReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetStockTransactionsWithCollectedTRXRQ_Class : TTReportNqlObject
        {
        }

        public partial class LIFOLotOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class LIFOExpirationOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class UnitePriceOfZero_Class : TTReportNqlObject
        {
        }

        public partial class GetE1ReportQuery2_Class : TTReportNqlObject
        {
        }

        public partial class LOTOutableStockTransactions_Class : TTReportNqlObject
        {
        }

        public partial class LOTOutableStockTransactionsWithZeroPrice_Class : TTReportNqlObject
        {
        }

        public partial class MaterialLotDetailRQ_Class : TTReportNqlObject
        {
        }

        public partial class FIFOLotOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class GetDocumentSavingRegisterIncompletedReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetE1ReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetTotalConsumptionAmountForAllStore_Class : TTReportNqlObject
        {
        }

        public partial class FIFOExpirationOutableStockTransactionsRQ_Class : TTReportNqlObject
        {
        }

        public partial class GetTransactionsForCensus_InventoryAccountReport_Class : TTReportNqlObject
        {
        }

        public partial class LOTOutableStockTransactionsWithPrice_Class : TTReportNqlObject
        {
        }

        public partial class GetMinTransactionDate_Class : TTReportNqlObject
        {
        }

        public partial class GetTotalConsumptionAmountByTransactionDate_Class : TTReportNqlObject
        {
        }

        public partial class VEM_STOK_HAREKET_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Kullanılan miktarı döndürür. Sadece Hareket tipi "in"  olanlar için  çalışmalıdır.
        /// </summary>
        public double? RestAmount
        {
            get
            {
                try
                {
                    #region RestAmount_GetScript                    
                    double retValue = 0;
                    if (InOut == TransactionTypeEnum.In)
                    {
                        IList trxList = GetTransactionRestAmountRQ(ObjectID);
                        if (trxList.Count > 0)
                        {
                            GetTransactionRestAmountRQ_Class restAmountClass = (GetTransactionRestAmountRQ_Class)trxList[0];
                            retValue = Convert.ToDouble(restAmountClass.Restamount);
                        }
                    }
                    return retValue;
                    #endregion RestAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "RestAmount") + " : " + ex.Message, ex);
                }
            }
        }

        //public List<getOutPutsDVO> getOutputs(StockTransaction stockTransaction)
        //{
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        List<getOutPutsDVO> output = new List<getOutPutsDVO>();

        //        // string destinationpoint = "";
        //        if (stockTransaction.StockActionDetail.StockAction is DistributionDocument) //Dağıtım mı?
        //        {
        //            StockTransaction theInput = objectContext.GetObject<StockTransaction>(new Guid(stockTransaction.StockActionDetail.StockAction.ObjectID.ToString()));
        //            //StockTransaction theInput = stockTransaction.StockActionDetail.StockAction.MKYS_ETedarikTuru;
        //            List<StockTransaction> detailList = objectContext.QueryObjects<StockTransaction>("StockActionDetail = '" + stockTransaction.StockActionDetail.ObjectID + "'").ToList();

        //            StockActionDetail theDistributionDetail = objectContext.GetObject<StockActionDetail>(new Guid(theInput.ToString()));
        //            StockAction theDistribution = objectContext.GetObject<StockAction>(new Guid(theDistributionDetail.ToString()));

        //            if (theInput.StockActionDetail.StockAction is DistributionDocument)
        //            {

        //                getOutputs(theInput);

        //            }
        //            List<StockActionDetailOut> theOutputs = theDistribution.StockActionOutDetails.ToList<StockActionDetailOut>();
        //            else
        //            {
        //                // stockrtransactiondetail'in girişi vererek çıkışını getir.
        //                //stockActionID vererek çıkışları getir

        //                foreach (var item in detailList)
        //                {
        //                    output.Add(item);
        //                }

        //            }


        //            // destinationpoint = ((DistributionDocument)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;

        //        }

        //    return output;
        //}
        //}







        /// <summary>
        /// Tutarı
        /// </summary>
        public BigCurrency? Price
        {
            get
            {
                try
                {
                    #region Price_GetScript                    
                    BigCurrency retValue = 0;

                    if (Amount.HasValue && Amount.Value > 0 && UnitPrice.HasValue && UnitPrice.Value > 0)
                        retValue = (BigCurrency)Amount.Value * UnitPrice.Value;

                    return retValue;
                    #endregion Price_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "Price") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "STOCKACTIONDETAIL":
                    {
                        StockActionDetail value = (StockActionDetail)newValue;
                        #region STOCKACTIONDETAIL_SetParentScript
                        if (value != null)
                            value.ResetPrice();
                        #endregion STOCKACTIONDETAIL_SetParentScript
                    }
                    break;

            }
        }

        protected override void PostInsert()
        {
            #region PostInsert






            base.PostInsert();
            //            IList stockLotDetails = null;
            //            if (this.Stock.Material.StockCard.StockMethod == StockMethodEnum.LotUsed)
            //            {
            //                stockLotDetails = this.ObjectContext.QueryObjects("STOCKLOTDETAIL", "STOCK =" + ConnectionManager.GuidToString(this.Stock.ObjectID) + " AND LOTNO ='" + this.LotNo + "' AND STOCKLEVELTYPE =" + ConnectionManager.GuidToString(this.StockLevelType.ObjectID)); 
            //                switch (StockTransactionDefinition.TransactionType)
            //                {
            //                    case(TransactionTypeEnum.In):
            //                        DoStockLotDetailInOperation(stockLotDetails, this);
            //                        break;
            //                    case(TransactionTypeEnum.Out):
            //                        DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        break;
            //                    case(TransactionTypeEnum.Transfer):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                    case(TransactionTypeEnum.Consumption):
            //                        break;
            //                    case(TransactionTypeEnum.Production):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                    case(TransactionTypeEnum.ChangeStockLevel):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                }
            //            }
            //            else if(this.Stock.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
            //            {
            //                stockLotDetails = this.ObjectContext.QueryObjects("STOCKLOTDETAIL", "STOCK =" + ConnectionManager.GuidToString(this.Stock.ObjectID) + " AND EXPIRATIONDATE ='" + this.ExpirationDate + "' AND STOCKLEVELTYPE =" + ConnectionManager.GuidToString(this.StockLevelType.ObjectID));
            //                switch (StockTransactionDefinition.TransactionType)
            //                {
            //                    case (TransactionTypeEnum.In):
            //                        DoStockLotDetailInOperation(stockLotDetails, this);
            //                        break;
            //                    case (TransactionTypeEnum.Out):
            //                        DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        break;
            //                    case (TransactionTypeEnum.Transfer):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                    case (TransactionTypeEnum.Consumption):
            //                        break;
            //                    case (TransactionTypeEnum.Production):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                    case (TransactionTypeEnum.ChangeStockLevel):
            //                        if (this.InOut == TransactionTypeEnum.In)
            //                        {
            //                            DoStockLotDetailInOperation(stockLotDetails, this);
            //                        }
            //                        else if (this.InOut == TransactionTypeEnum.Out)
            //                        {
            //                            DoStockLotDetailOutOperation(stockLotDetails, this);
            //                        }
            //                        break;
            //                }
            //            }


            #endregion PostInsert
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled




            string errorMessage = string.Empty;
            if (StockCollectedTrxs.Select(string.Empty).Count > 0)
            {
                foreach (StockCollectedTrx stockCollectedTrx in StockCollectedTrxs)
                    errorMessage += StockActionDetail.Material.Name + " isimli malzeme, Tüketim Üretim Elde Edilenler belgesine çıktığı için önce o belgenin iptal edilmesi gerekmektedir.\r\nTüketim Üretim Elde Edilenler Belgesi İşlem Nu.:" + stockCollectedTrx.StockActionDetail.StockAction.StockActionID;
            }

            StockTransactionDetails.Select(string.Empty);
            if (StockTransactionDetails.Count > 0)
            {
                string messageHeader = TTUtils.CultureService.GetText("M26353", "Kullanılmış stok hareket(ler)i iptal edilemez.\r\n\r\n");
                foreach (StockTransactionDetail stockTransactionDetail in StockTransactionDetails)
                {
                    if (stockTransactionDetail.OutStockTransaction.CurrentStateDefID.Equals(StockTransaction.States.Completed))
                    {
                        errorMessage += messageHeader + "İşlem Nu.: " + stockTransactionDetail.OutStockTransaction.StockActionDetail.StockAction.StockActionID;
                        messageHeader = "\r\n";
                    }
                }
            }
            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new Exception(errorMessage);



            #endregion PreTransition_Completed2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            Stock.StockFieldsUpdate(this, true);
            // TODO Post_Scriptte  Methodumuzu çağırıyoruz. (State Geçişinde)
            this.MakeReceivingAndUsingCancelation();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled



            throw new Exception(SystemMessage.GetMessage(727));


            #endregion UndoTransition_Completed2Cancelled
        }

        #region Methods
        protected override void OnConstruct()
        {
            if (((ITTObject)this).IsNew == true)
            {
                CurrentStateDefID = StockTransaction.States.Completed;
            }
        }

        public StockTransaction GetFirstInTransaction()
        {
            StockTransaction firstTrx = null;
            foreach (StockTransactionDetail trxDetail in OutStockTransactionDetails)
            {
                if (trxDetail.InStockTransaction.StockActionDetail.StockTransactions.Select("INOUT =2").Count > 0)
                {
                    foreach (StockTransaction trx in trxDetail.InStockTransaction.StockActionDetail.StockTransactions.Select("INOUT =2"))
                        firstTrx = trx.GetFirstInTransaction();
                }
                else if (trxDetail.InStockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 1").Count == 1)
                    firstTrx = trxDetail.InStockTransaction;
                else if (trxDetail.InStockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 1").Count > 1)
                    firstTrx = trxDetail.InStockTransaction;
            }

            return firstTrx;
        }

        public InFirstStockTransactionInvoceDetailDVO GetInFirstStockTransactionInvoceDetailDVO()
        {
            InFirstStockTransactionInvoceDetailDVO dvo = new InFirstStockTransactionInvoceDetailDVO();
            StockTransaction firstInTransaction = GetFirstInTransaction();
            if (firstInTransaction != null)
            {
                dvo.GirisIslemTipi = firstInTransaction.StockActionDetail.StockAction.ObjectDef.DisplayText;
                dvo.IslemTarihi = firstInTransaction.TransactionDate;
                dvo.SatinAlisMiktari = firstInTransaction.Amount;
                dvo.KDVliFiyat = firstInTransaction.UnitPrice;
                dvo.KDV = firstInTransaction.VatRate;

                if (firstInTransaction.UnitPrice.HasValue && firstInTransaction.VatRate.HasValue)
                    dvo.KDVsizFiyat = firstInTransaction.UnitPrice.Value / ((decimal)firstInTransaction.VatRate.Value + 100) * 100;

                if (firstInTransaction.StockActionDetail.Patient != null)
                    dvo.HastayaOzel = true;
                else
                    dvo.HastayaOzel = false;

                if (firstInTransaction.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                {
                    IChattelDocumentWithPurchase purchase = (IChattelDocumentWithPurchase)firstInTransaction.StockActionDetail.StockAction;
                    dvo.IhaleTarihi = purchase.GetAuctionDate();
                    dvo.KararTarihi = purchase.GetConclusionDateTime();
                    dvo.IhaleNo = purchase.GetRegistrationAuctionNo();
                    dvo.AlimYontemi = firstInTransaction.StockActionDetail.StockAction.MKYS_EAlimYontemi;
                    dvo.Firma = purchase.GetSupplier().GetName();
                    dvo.DayanakBelgeTarihi = purchase.GetWaybillDate();
                    dvo.DayanakBelgeNo = purchase.GetWaybill();
                }

                if (firstInTransaction.StockActionDetail.StockAction is IChattelDocumentInputWithAccountancy)
                {
                    IChattelDocumentInputWithAccountancy input = (IChattelDocumentInputWithAccountancy)firstInTransaction.StockActionDetail.StockAction;
                    dvo.DayanakBelgeTarihi = input.GetWaybillDate();
                    dvo.DayanakBelgeNo = input.GetWaybill();
                    dvo.Firma = input.GetAccountancy().GetName();
                }
            }

            return dvo;
        }

        public static List<StockTransaction.getOutPutsDVO> GetFirstOutTransaction(List<StockTransaction.getOutPutsDVO> EmptyList, StockTransaction stockTransaction)
        {
            StockTransaction.getOutPutsDVO lastOut = null;
            if (stockTransaction.StockTransactionDetails.Count > 0)
            {
                foreach (StockTransactionDetail outTrx in stockTransaction.StockTransactionDetails.Select(string.Empty))
                {
                    foreach (StockTransaction outInTrx in outTrx.OutStockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 1"))
                    {
                        if (outInTrx.StockTransactionDetails.Count > 0)
                        {
                            lastOut = new StockTransaction.getOutPutsDVO();
                            lastOut.stockTransaction = outInTrx;
                            lastOut.stockActionDetail = outInTrx.StockActionDetail;
                            EmptyList.Add(lastOut);
                            GetFirstOutTransaction(EmptyList, outInTrx);
                        }
                    }
                    foreach (StockTransaction outInTrx in outTrx.OutStockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 2"))
                    {
                        lastOut = new StockTransaction.getOutPutsDVO();
                        lastOut.stockTransaction = outInTrx;
                        lastOut.stockActionDetail = outInTrx.StockActionDetail;
                        EmptyList.Add(lastOut);
                        GetFirstOutTransaction(EmptyList, outInTrx);
                    }
                }


                if (stockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 2").Count > 0)
                {
                    foreach (StockTransactionDetail trxDetail in stockTransaction.StockTransactionDetails)
                    {
                        lastOut = new StockTransaction.getOutPutsDVO();
                        lastOut.stockTransaction = trxDetail.OutStockTransaction;
                        lastOut.stockActionDetail = trxDetail.OutStockTransaction.StockActionDetail;
                        EmptyList.Add(lastOut);
                        GetFirstOutTransaction(EmptyList, trxDetail.OutStockTransaction);
                    }
                }
            }
            return EmptyList;
        }

        public string GetSupplierNumber()
        {
            string vendorNumber = null;
            StockTransaction firstTrx = GetFirstInTransaction();
            if (firstTrx.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                vendorNumber = ((IChattelDocumentWithPurchase)firstTrx.StockActionDetail.StockAction).GetSupplier().GetSupplierNumber();
            else if (firstTrx.StockActionDetail is IChattelDocumentInputDetailWithAccountancy)
            {
                vendorNumber = ((IChattelDocumentInputDetailWithAccountancy)firstTrx.StockActionDetail).GetSupplier().SupplierNumber;
            }


            return vendorNumber;
        }

        public DateTime? GetPurchaseDate()
        {
            DateTime? purchaseDate = null;
            StockTransaction firstTrx = GetFirstInTransaction();
            if (firstTrx.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                purchaseDate = ((IChattelDocumentWithPurchase)firstTrx.StockActionDetail.StockAction).GetBaseDateTime();
            else
            {
                if (firstTrx.StockActionDetail.InvoiceDetails.Count > 0)
                    purchaseDate = firstTrx.StockActionDetail.InvoiceDetails[0].InvoiceDate;
                else if (Stock.Material.PurchaseDate != null)
                    purchaseDate = Stock.Material.PurchaseDate;
            }

            if (purchaseDate == null)
            {
                if (firstTrx.StockActionDetail.StockAction.TransactionDate != null)
                    purchaseDate = firstTrx.StockActionDetail.StockAction.TransactionDate;
                else
                    purchaseDate = firstTrx.StockActionDetail.StockAction.ActionDate;
            }

            return purchaseDate;
        }

        public DateTime? GetAuctionDate()
        {
            DateTime? auctionDate = null;
            StockTransaction firstTrx = GetFirstInTransaction();

            if (firstTrx.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                auctionDate = ((IChattelDocumentWithPurchase)firstTrx.StockActionDetail.StockAction).GetAuctionDate();
            else if (firstTrx.StockActionDetail.InvoiceDetails.Count > 0)
                auctionDate = firstTrx.StockActionDetail.InvoiceDetails[0].AuctionDate;

            if (!auctionDate.HasValue)
                auctionDate = Stock.Material.AuctionDate;

            return auctionDate;
        }

        public string GetRegistrationAuctionNo()
        {
            string registrationAuctionNo = string.Empty;
            StockTransaction firstTrx = GetFirstInTransaction();

            if (firstTrx.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                registrationAuctionNo = ((IChattelDocumentWithPurchase)firstTrx.StockActionDetail.StockAction).GetRegistrationAuctionNo();
            else if (firstTrx.StockActionDetail.InvoiceDetails.Count > 0)
                registrationAuctionNo = firstTrx.StockActionDetail.InvoiceDetails[0].RegistrationAuctionNo;

            if (string.IsNullOrEmpty(registrationAuctionNo))
                registrationAuctionNo = Stock.Material.RegistrationAuctionNo;

            return registrationAuctionNo;
        }

        public void DoStockLotDetailInOperation(IList stockLotDetails, StockTransaction stockTransaction)
        {
            if (stockLotDetails.Count == 1)
            {
                StockLotDetail stockLotDetail = (StockLotDetail)stockLotDetails[0];
                stockLotDetail.RestAmount = stockLotDetail.RestAmount + stockTransaction.Amount;
            }
            else if (stockLotDetails.Count == 0)
            {
                StockLotDetail stockLotDetail = new StockLotDetail(stockTransaction.ObjectContext);
                stockLotDetail.Stock = stockTransaction.Stock;
                stockLotDetail.LotNo = stockTransaction.LotNo;
                stockLotDetail.ExpirationDate = stockTransaction.ExpirationDate;
                stockLotDetail.StockLevelType = stockTransaction.StockLevelType;
            }
            else
            {
                throw new TTException("Herhangibir mevcut bulunamamıştır.");
            }

        }

        public void DoStockLotDetailOutOperation(IList stockLotDetails, StockTransaction stockTransaction)
        {
            if (stockLotDetails.Count == 1)
            {
                StockLotDetail stockLotDetail = (StockLotDetail)stockLotDetails[0];
                if (stockLotDetail.RestAmount - stockTransaction.Amount == 0)
                {
                    ((ITTObject)stockLotDetail).Delete();
                }
                else if (stockLotDetail.RestAmount - stockTransaction.Amount > 0)
                {
                    stockLotDetail.RestAmount = stockLotDetail.RestAmount - stockTransaction.Amount;
                }
            }
            else
            {
                throw new TTException("Herhangibir mevcut bulunamamıştır.");
            }
        }

        #endregion Methods

        public class getOutPutsDVO
        {
            public StockActionDetail stockActionDetail { get; set; }
            public StockTransaction stockTransaction { get; set; }
        }

        public class InFirstStockTransactionInvoceDetailDVO
        {
            public DateTime? IslemTarihi { get; set; }
            public DateTime? IhaleTarihi { get; set; }
            public DateTime? KararTarihi { get; set; }
            public DateTime? DayanakBelgeTarihi { get; set; }
            public MKYS_EAlimYontemiEnum? AlimYontemi { get; set; }
            public bool HastayaOzel { get; set; }
            public string Firma { get; set; }
            public string IhaleNo { get; set; }
            public string DayanakBelgeNo { get; set; }
            public Currency? SatinAlisMiktari { get; set; }
            public BigCurrency? KDVliFiyat { get; set; }
            public BigCurrency? KDVsizFiyat { get; set; }
            public long? KDV { get; set; }
            public string GirisIslemTipi { get; set; }
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockTransaction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockTransaction.States.Completed && toState == StockTransaction.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockTransaction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockTransaction.States.Completed && toState == StockTransaction.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(StockTransaction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == StockTransaction.States.Completed && toState == StockTransaction.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }


        string sonuc = "";
        bool basarili = true;
        public string MakeReceivingAndUsingCancelation()
        {
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

            foreach (UTSNotificationDetail utsNotDet in this.UTSNotificationDetails.Where(x => x.CurrentStateDefID == UTSNotificationDetail.States.Successful))
            {
                UTSServis.KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek = new UTSServis.KullanimIptalBildirimiIstek();
                kullanimIptalBildirimiIstek.BID = utsNotDet.NotificationID;

                try
                {
                    UTSServis.BildirimCevap KullanımIptalcevap = UTSServis.WebMethods.KullanimIptalBildirimiSync(new Guid(siteID), kullanimIptalBildirimiIstek);
                    sonuc = KullanımIptalcevap.MSJ[0].MET;
                }
                catch (Exception e)
                {
                    sonuc = e.ToString();
                    basarili = false;
                }
                if (basarili)
                {
                    using (TTObjectContext context = new TTObjectContext(false))
                    {
                        foreach (UTSNotificationDetail utsDet in this.UTSNotificationDetails.Select(string.Empty))
                        {
                            utsDet.CurrentStateDefID = UTSNotificationDetail.States.Cancelled;
                        }
                    }
                }
            }
            return sonuc;
        }
    }
}