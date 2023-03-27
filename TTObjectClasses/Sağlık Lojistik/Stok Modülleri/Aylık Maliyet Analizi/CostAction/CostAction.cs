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
    public partial class CostAction : StockAction
    {
        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni)]
        public static CostAction CostActionDateCreatTS(CostAction costAction)
        {
            DateTime date = Common.RecTime();
            DateTime dateStart = Common.RecTime();
            DateTime dateEnd = Common.RecTime();
            BindingList<CostAction.GetCostActionByEndDate_Class> endDates = CostAction.GetCostActionByEndDate(costAction.Store.ObjectID);
            if (endDates.Count > 0)
            {
                if (endDates[0].CurrentStateDefID != CostAction.States.Completed)
                {
                    throw new Exception(endDates[0].StockActionID + " işlemi tamamlayın!");
                }
                else
                {
                    date = (DateTime)endDates[0].EndDate;
                    dateStart = new DateTime(date.Year, date.Month, date.Day).AddDays(+1);
                    dateEnd = new DateTime(dateStart.Year, dateStart.Month, 1).AddMonths(+1).AddDays(-1);
                    if (endDates[0].EndDate != dateEnd)
                        return CostAction.CostActionCreateTS(costAction, dateStart, dateEnd);
                    else
                        throw new Exception(endDates[0].StockActionID + TTUtils.CultureService.GetText("M26580", "Nolu Maliyet Analizi Yapılmıştır!"));
                }
            }
            else //hiç yoksa
            {
                AccountingTerm openAccountingTerm = ((MainStoreDefinition)costAction.Store).Accountancy.GetOpenAccountingTerm();
                date = (DateTime)openAccountingTerm.StartDate;
                dateStart = date;
                dateEnd = new DateTime(date.Year, date.Month, 1).AddMonths(+1).AddDays(-1);
                return CostAction.CostActionCreateTS(costAction, dateStart, dateEnd);
            }
        }


    

 

        public static CostAction CostActionCreateTS(CostAction costAction, DateTime dateStart, DateTime dateEnd)
        {
            return costAction.CostActionCreate(costAction, dateStart, dateEnd);
        }

        public CostAction CostActionCreate(CostAction costAction, DateTime dateStart, DateTime dateEnd)
        {
            costAction.StartDate = dateStart;
            costAction.EndDate = dateEnd.AddHours(23).AddMinutes(59).AddSeconds(59);

            if (costAction.EndDate > Common.RecTime())
                throw new TTException(TTUtils.CultureService.GetText("M26395", "Maliyet Analizi Yapmaya Çalıştığınız Dönem Sonu Gelmemiştir. Tarih :")+ ((DateTime)Common.RecTime()).ToShortDateString() + " Dönem Bitiş Tarihi :" + ((DateTime)costAction.EndDate).ToShortDateString());

            string ayIsmi = AyIsmi(((DateTime)(costAction.StartDate)).Month);
            costAction.CostActionDesciption = ((DateTime)(costAction.StartDate)).Year + " - " + ayIsmi;
            foreach (Stock stock in costAction.Store.Stocks.Select(string.Empty))
            {
                CostActionMaterial costActionMaterial = new CostActionMaterial(costAction.ObjectContext);
                costActionMaterial.Material = stock.Material;
                costActionMaterial.AvarageUnitePrice = 0;
                costActionMaterial.DifAvarageUnitePrice = 0;
                costActionMaterial.MaterialPrice = 0;
                costActionMaterial.PreviousMonthPrice = 0;
                costActionMaterial.PreviousMothInheld = 0;
                costActionMaterial.ProfitAndLoss = 0;
                costActionMaterial.TotalAmount = 0;
                costActionMaterial.TotalOutAmunt = 0;
                costActionMaterial.TotalPrice = 0;
                costActionMaterial.TransferredAmount = 0;
                TTObjectContext stockcenObjectContex = new TTObjectContext(false);
                TTObjectContext objectContex = new TTObjectContext(false);
                Stock stockDevir = new Stock(stockcenObjectContex, stock.Store, stock.Material);

                BindingList<CostActionMaterial.GetPreviousCostAction_Class> allCostActionMaterials = CostActionMaterial.GetPreviousCostAction(stock.Material.ObjectID, ((DateTime)costAction.StartDate).AddDays(-1), stock.Store.ObjectID);
                if (allCostActionMaterials.Count > 0)
                {
                    costActionMaterial.PreviousMothInheld = allCostActionMaterials[0].TransferredAmount;
                    costActionMaterial.PreviousMonthPrice = allCostActionMaterials[0].DifAvarageUnitePrice;
                    stockDevir.Inheld = allCostActionMaterials[0].TransferredAmount;
                    stockDevir.TotalInPrice = allCostActionMaterials[0].DifAvarageUnitePrice;
                    stockDevir.TotalIn = allCostActionMaterials[0].TransferredAmount;
                    StockLevel stockLevel = new StockLevel(stockcenObjectContex);
                    stockLevel.Stock = stockDevir;
                    stockLevel.StockLevelType = StockLevelType.NewStockLevel;
                    stockLevel.Amount = allCostActionMaterials[0].TransferredAmount;
                }


                IList<StockTransaction> stockTransactionSelectMoths = StockTransaction.GetCompletedStockTransactions(objectContex, stock.ObjectID, " AND  TRANSACTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter((DateTime)costAction.StartDate) + " AND " + Globals.CreateNQLToDateParameter((DateTime)costAction.EndDate));
                foreach (StockTransaction stockTrans in stockTransactionSelectMoths)
                {
                    stockDevir.StockFieldsUpdateForCostAction(stockTrans);
                }

                costActionMaterial.TotalAmount = stockDevir.TotalIn - costActionMaterial.PreviousMothInheld;
                costActionMaterial.TotalOutAmunt = stockDevir.TotalOut;
                costActionMaterial.TotalPrice = stockDevir.TotalInPrice - costActionMaterial.PreviousMonthPrice;
                if (stockDevir.TotalIn != 0)
                    costActionMaterial.AvarageUnitePrice = stockDevir.TotalInPrice / (BigCurrency)stockDevir.TotalIn;
                else if (costActionMaterial.TotalAmount != 0)
                    costActionMaterial.AvarageUnitePrice = costActionMaterial.TotalPrice / (BigCurrency)costActionMaterial.TotalAmount;
                costActionMaterial.TransferredAmount = stockDevir.Inheld;
                if (stockDevir.Inheld != 0 && costActionMaterial.AvarageUnitePrice != 0)
                    costActionMaterial.DifAvarageUnitePrice = (BigCurrency)stockDevir.Inheld * costActionMaterial.AvarageUnitePrice;
                else
                    costActionMaterial.DifAvarageUnitePrice = costActionMaterial.PreviousMonthPrice;
                if (costActionMaterial.Material.AllowToGivePatient.HasValue && costActionMaterial.Material.AllowToGivePatient == true)
                {
                    BindingList<TTObjectClasses.MaterialPrice.MaterialPriceForCostBenefit_Class> prices = TTObjectClasses.MaterialPrice.MaterialPriceForCostBenefit(costActionMaterial.Material.ObjectID.ToString(), (DateTime)costAction.StartDate, (DateTime)costAction.EndDate);
                    if (prices.Count > 0)
                    {
                        costActionMaterial.MaterialPrice = prices[0].Price;
                        costActionMaterial.ProfitAndLoss = (Currency)prices[0].Price - costActionMaterial.AvarageUnitePrice;
                    }
                }

                foreach (StockLevel levels in stockDevir.StockLevels)
                {
                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.New)
                    {
                        CostActionLevel censusLevel = null;
                        censusLevel = new CostActionLevel(costAction.ObjectContext);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.NewStockLevel;
                        censusLevel.CostActionMaterial = costActionMaterial;
                    }

                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Used)
                    {
                        CostActionLevel censusLevel = null;
                        censusLevel = new CostActionLevel(costAction.ObjectContext);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.UsedStockLevel;
                        censusLevel.CostActionMaterial = costActionMaterial;
                        costActionMaterial.Used = levels.Amount;
                    }

                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Hek)
                    {
                        CostActionLevel censusLevel = null;
                        censusLevel = new CostActionLevel(costAction.ObjectContext);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.HekStockLevel;
                        censusLevel.CostActionMaterial = costActionMaterial;
                    }

                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Redundant)
                    {
                        CostActionLevel censusLevel = null;
                        censusLevel = new CostActionLevel(costAction.ObjectContext);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.RedundantLevel;
                        censusLevel.CostActionMaterial = costActionMaterial;
                    }
                }

                costAction.CostActionMaterials.Add(costActionMaterial);
            }

            return costAction;
        }

        public static string AyIsmi(int ay)
        {
            string sonuc = TTUtils.CultureService.GetText("M26621", "Ocak");
            switch (ay)
            {
                case 1:
                    sonuc = TTUtils.CultureService.GetText("M26621", "Ocak");
                    break;
                case 2:
                    sonuc = TTUtils.CultureService.GetText("M26965", "Şubat");
                    break;
                case 3:
                    sonuc = TTUtils.CultureService.GetText("M26418", "Mart");
                    break;
                case 4:
                    sonuc = TTUtils.CultureService.GetText("M26570", "Nisan");
                    break;
                case 5:
                    sonuc = TTUtils.CultureService.GetText("M26422", "Mayıs");
                    break;
                case 6:
                    sonuc = TTUtils.CultureService.GetText("M25910", "Haziran");
                    break;
                case 7:
                    sonuc = TTUtils.CultureService.GetText("M27091", "Temmuz");
                    break;
                case 8:
                    sonuc = TTUtils.CultureService.GetText("M25141", "Ağustos");
                    break;
                case 9:
                    sonuc = TTUtils.CultureService.GetText("M25625", "Eylül");
                    break;
                case 10:
                    sonuc = TTUtils.CultureService.GetText("M25576", "Ekim");
                    break;
                case 11:
                    sonuc = TTUtils.CultureService.GetText("M26274", "Kasım");
                    break;
                case 12:
                    sonuc = TTUtils.CultureService.GetText("M25191", "Aralık");
                    break;
            }

            return sonuc;
        }


        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval
            string message = string.Empty;

            BindingList<DocumentRecordLog.GetDocumentRecordLogsByDate_Class> documentrecordlogs = DocumentRecordLog.GetDocumentRecordLogsByDate((DateTime)EndDate, (DateTime)StartDate,Store.ObjectID.ToString());
            foreach (DocumentRecordLog.GetDocumentRecordLogsByDate_Class log in documentrecordlogs)
            {
                if (log.ReceiptNumber == null)
                    message += log.StockActionID.ToString() + " Nolu işlem için " + log.DocumentRecordLogNumber.ToString() + " TİF MKYS sistemine bildirilmemiştir.";
            }
            if (String.IsNullOrEmpty(message) == false)
            {
                throw new TTException("Ay içerisnde MKYS ye gönderilmemiş işlemler mevcuttur. MKYS Eşleştirmesi sekmesinden görüntüleyebilirsiniz.");
            }

            string ayIsmi = AyIsmi(((DateTime)(StartDate)).Month);
            CostActionDesciption = ((DateTime)(StartDate)).Year + " - " + ayIsmi;

            #endregion PreTransition_New2Approval
        }
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Approval
            #region PreTransition_New2Approval
            string message = string.Empty;

            BindingList<DocumentRecordLog.GetDocumentRecordLogsByDate_Class> documentrecordlogs = DocumentRecordLog.GetDocumentRecordLogsByDate((DateTime)EndDate, (DateTime)StartDate, Store.ObjectID.ToString());
            foreach (DocumentRecordLog.GetDocumentRecordLogsByDate_Class log in documentrecordlogs)
            {
                if (log.ReceiptNumber == null)
                    message += log.StockActionID.ToString() + " Nolu işlem için " + log.DocumentRecordLogNumber.ToString() + " TİF MKYS sistemine bildirilmemiştir.";
            }
            if (String.IsNullOrEmpty(message) == false)
            {
                throw new TTException("Ay içerisnde MKYS ye gönderilmemiş işlemler mevcuttur. MKYS Eşleştirmesi sekmesinden görüntüleyebilirsiniz.");
            }

            string ayIsmi = AyIsmi(((DateTime)(StartDate)).Month);
            CostActionDesciption = ((DateTime)(StartDate)).Year + " - " + ayIsmi;

            #endregion PreTransition_New2Approval
        }
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CostAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CostAction.States.Completed && toState == CostAction.States.Cancelled)
                PreTransition_Completed2Cancelled();
            if (fromState == CostAction.States.New && toState == CostAction.States.Approval)
                PreTransition_New2Approval();
            if (fromState == CostAction.States.New && toState == CostAction.States.Completed)
                PreTransition_New2Completed();
        }
    }
}