
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
    /// Stok Hareket Tipi Tanımı
    /// </summary>
    public partial class StockTransactionDefinition : TerminologyManagerDef
    {
        public partial class GetStockTransactionDefinition_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TRANSACTIONTYPE":
                    {
                        TransactionTypeEnum? value = (TransactionTypeEnum?)(int?)newValue;
                        #region TRANSACTIONTYPE_SetScript
                        if (value.HasValue)
                            if (value != TransactionTypeEnum.ChangeStockLevel)
                                ChangedStockLevelType = null;
                        #endregion TRANSACTIONTYPE_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        #region Methods
        private static Dictionary<Guid, StockTransactionDefinition> _allStockTransactionDefinitios;

        public static StockTransactionDefinition GetStockTransactionDefinition(Guid objectID)
        {
            StockTransactionDefinition retValue = null;
            _allStockTransactionDefinitios.TryGetValue(objectID, out retValue);
            return retValue;
        }

        static StockTransactionDefinition()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allStockTransactionDefinitios = new Dictionary<Guid, StockTransactionDefinition>();
            foreach (StockTransactionDefinition stockTransactionDefinition in context.QueryObjects<StockTransactionDefinition>())
                _allStockTransactionDefinitios.Add(stockTransactionDefinition.ObjectID, stockTransactionDefinition);
        }


        private StockTransaction InOperation(Stock stock, StockActionDetail stockActionDetail)
        {

            if (stock.Material.JoinedMaterial != null)
            {
                throw new TTException(stock.Material.Name + " Malzemesine İşlem Yapamazsınız!\r\n Yeni Kullanılacak Malzeme = " + stock.Material.StockCard.NATOStockNO.ToString() + " - " + ((Material)stock.Material.JoinedMaterial).Name);
            }
            else
            {
                double inheld = (double)stock.Inheld;
                double amount = (double)stockActionDetail.Amount;
                double minimumLevel = (double)stock.MinimumLevel;
                double maximumLevel = (double)stock.MaximumLevel;
                double saffetyLevel = (double)stock.SafetyLevel;
                string stockCardName = stockActionDetail.Material.StockCard.Name.ToString();
                double lastInheld = inheld + amount;


                StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                stockTransaction.InOut = TransactionTypeEnum.In;
                stockTransaction.TransactionDate = stockActionDetail.StockAction.TransactionDate;
                stockTransaction.StockTransactionDefinition = this;
                stockTransaction.StockLevelType = stockActionDetail.StockLevelType;
                stockTransaction.StockActionDetail = stockActionDetail;
                stockTransaction.MaintainLevelCode = MaintainLevelCode.Value;
                stockTransaction.UnitPrice = ((StockActionDetailIn)stockActionDetail).UnitPrice;
                stockTransaction.LotNo = ((StockActionDetailIn)stockActionDetail).LotNo;
                stockTransaction.SerialNo = ((StockActionDetailIn)stockActionDetail).SerialNo;
                stockTransaction.IncomingDeliveryNotifID = ((StockActionDetailIn)stockActionDetail).IncomingDeliveryNotifID;

                //TODO UTS için eklendi
                stockTransaction.Patient = ((StockActionDetailIn)stockActionDetail).Patient;

                if (stockActionDetail.StockAction.BudgetTypeDefinition == null)
                    throw new TTException(TTUtils.CultureService.GetText("M26235", "İşlemin bütçe tipi seçilmemiştir."));

                stockTransaction.BudgetTypeDefinition = stockActionDetail.StockAction.BudgetTypeDefinition;

                if (((StockActionDetailIn)stockActionDetail).ExpirationDate != null)
                    stockTransaction.ExpirationDate = Common.GetLastDayOfMounth(((DateTime)((StockActionDetailIn)stockActionDetail).ExpirationDate));

                stockTransaction.Amount = stockActionDetail.Amount;
                stockTransaction.VatRate = ((StockActionDetailIn)stockActionDetail).VatRate;

                stock.StockFieldsUpdate(stockTransaction, false);

                //if (maximumLevel != 0 && maximumLevel != null)
                if (maximumLevel != 0)
                {
                    if (lastInheld > maximumLevel)
                    {
                        UserMessage message = new UserMessage(ObjectContext);
                        message.IsSystemMessage = true;
                        message.MessageDate = TTObjectDefManager.ServerTime;
                        message.Subject = TTUtils.CultureService.GetText("M26421", "Maximum Seviye Bilgilendirmesi");
                        //    message.Status = MessageStatusEnum.Sent;
                        message.ToUser = (ResUser)Common.CurrentUser.UserObject;
                        message.Sender = (ResUser)Common.CurrentUser.UserObject;
                        message.SetRTFBody(stockCardName.ToString() + " isimli stok kartı maximum seviyenin üzerine çıkmıştır.\n Maximum Seviye =" + maximumLevel.ToString() + "\n Mevcut : " + lastInheld.ToString());
                    }
                }
                return stockTransaction;
            }
        }

        private List<StockTransaction> OutOperation(Stock stock, StockActionDetail stockActionDetail)
        {
            Currency inheld = (Currency)stock.Inheld;
            Currency amount = (Currency)stockActionDetail.Amount;
            Currency minimumLevel = (Currency)stock.MinimumLevel;
            Currency maximumLevel = (Currency)stock.MaximumLevel;
            Currency safetyLevel = (Currency)stock.SafetyLevel;
            Currency lastInheld = inheld - amount;
            if (lastInheld >= safetyLevel)
            {
                Currency restAmount = stockActionDetail.Amount.Value;
                Currency totalTrxAmount = 0;
                List<StockTransaction> outTransactions = new List<StockTransaction>();
                if (stockActionDetail.ResetOuttableStockTransaction.HasValue && (bool)stockActionDetail.ResetOuttableStockTransaction)
                    stock._outableStockTransactions = null;

                if (stockActionDetail is StockActionDetailOut)
                {
                    if (((StockActionDetailOut)stockActionDetail).UserSelectedOutableTrx.HasValue && ((StockActionDetailOut)stockActionDetail).UserSelectedOutableTrx.Value)
                    {
                        stock.UserSelectedOutableStockTransactions(stockActionDetail);
                    }
                    else
                    {
                        stock.PrepareOutableStockTransactions(stockActionDetail, true);
                    }
                }
                else
                {
                    stock.PrepareOutableStockTransactions(stockActionDetail, true);
                }

                if (stock.OutableStockTransactions != null)
                {
                    foreach (Stock.OutableStockTransaction outableStockTransaction in stock.OutableStockTransactions)
                    {
                        if (stockActionDetail.Patient != null)
                        {
                            if (outableStockTransaction.StockTransaction.Patient == null)
                                continue;
                            else
                            {
                                if (outableStockTransaction.StockTransaction.Patient.ObjectID != stockActionDetail.Patient.ObjectID)
                                    continue;
                            }
                        }

                        if (outableStockTransaction.RequestAmount <= 0)
                            continue;
                        StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                        stockTransaction.InOut = TransactionTypeEnum.Out;
                        stockTransaction.TransactionDate = stockActionDetail.StockAction.TransactionDate;
                        stockTransaction.StockTransactionDefinition = this;
                        stockTransaction.StockLevelType = stockActionDetail.StockLevelType;
                        stockTransaction.StockActionDetail = stockActionDetail;
                        stockTransaction.MaintainLevelCode = MaintainLevelCode.Value;
                        stockTransaction.ExpirationDate = outableStockTransaction.StockTransaction.ExpirationDate;
                        stockTransaction.LotNo = outableStockTransaction.StockTransaction.LotNo;
                        stockTransaction.SerialNo = outableStockTransaction.StockTransaction.SerialNo;
                        stockTransaction.Amount = outableStockTransaction.RequestAmount > restAmount ? restAmount : outableStockTransaction.RequestAmount.Value;
                        stockTransaction.UnitPrice = outableStockTransaction.StockTransaction.UnitPrice;
                        stockTransaction.VatRate = outableStockTransaction.StockTransaction.VatRate;
                        stockTransaction.BudgetTypeDefinition = outableStockTransaction.StockTransaction.BudgetTypeDefinition;
                        stockTransaction.IncomingDeliveryNotifID = outableStockTransaction.StockTransaction.IncomingDeliveryNotifID;
                        stockTransaction.ReceiveNotificationID = outableStockTransaction.StockTransaction.ReceiveNotificationID;
                        stockTransaction.DeliveryNotifictionID = outableStockTransaction.StockTransaction.DeliveryNotifictionID;

                        if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") == "TRUE")
                        {
                            // UTS Tekil takibi gerektiren malzeme ise kullanım bildirimi yapılır 
                            if (stockActionDetail.SubActionMaterial != null && stockActionDetail.SubActionMaterial.Count > 0)
                            {
                                if (stockActionDetail.Material.IsIndividualTrackingRequired == true)
                                {
                                    try
                                    {
                                        Patient p = stockActionDetail.SubActionMaterial[0].Episode.Patient;
                                        for (int i = 0; i < stockTransaction.Amount; i++)
                                        {

                                            UTSServis.KullanimBildirimiIstek kullanimBildirimiIstek = new UTSServis.KullanimBildirimiIstek()
                                            {

                                                TKN = p.UniqueRefNo,
                                                UNO = stockActionDetail.Material.Barcode,
                                                LNO = stockTransaction.LotNo,
                                                SNO = stockTransaction.SerialNo,
                                                ADT = 1,
                                                HAA = p.Name,
                                                HAS = p.Surname,
                                                YKN = p.ForeignUniqueRefNo,
                                                PAN = p.PassportNo,
                                                GIT = DateTime.Now.ToString("yyyy-MM-dd")
                                            };

                                            if (p.UniqueRefNo != null)
                                                kullanimBildirimiIstek.TUR = UTSServis.KullanimBildirimiTur.TC_KIMLIK_NUMARASI_VAR;
                                            else if (p.ForeignUniqueRefNo != null)
                                                kullanimBildirimiIstek.TUR = UTSServis.KullanimBildirimiTur.YABANCI_KIMLIK_NUMARASI_VAR;

                                            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                                            UTSServis.BildirimCevap utsBildirimCevap = UTSServis.WebMethods.KullanimBildirimiSync(new Guid(siteID), kullanimBildirimiIstek);


                                            // Kullanım bildirimi başarı ile tamamlanırsa NotifID UTSNotifDetail objesinde set edilir ve state başarılı olarak belirlenir. 
                                            // Başarılı tamamlanamazsa state başarısız olarak belirlenir. 
                                            if (utsBildirimCevap != null)
                                            {
                                                if (utsBildirimCevap.SNC == String.Empty || utsBildirimCevap.SNC == null)
                                                {
                                                    TTException e = new TTException(utsBildirimCevap.MSJ[0].MET);
                                                }
                                                else
                                                {
                                                    UTSNotificationDetail utsNotificationDetail = new UTSNotificationDetail(ObjectContext)
                                                    {
                                                        StockTransaction = stockTransaction,
                                                        NotificationDate = DateTime.Now,
                                                        NotificationType = UTSNotificationTypeEnum.UsageNotification
                                                    };
                                                    utsNotificationDetail.NotificationID = utsBildirimCevap.SNC;
                                                    utsNotificationDetail.CurrentStateDefID = UTSNotificationDetail.States.Unsuccessful;
                                                }
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        //   throw new Exception(stockActionDetail.Material.Name + " malzemesi için UTS kullanım bildirimi tamamlanamamıştır!");
                                    }
                                }
                            }


                        }

                        restAmount -= stockTransaction.Amount.Value;
                        //outableStockTransaction.DescreaseRestAmount(stockTransaction.Amount.Value);
                        outableStockTransaction.DescreaseRequestAmount(stockTransaction.Amount.Value);

                        outTransactions.Add(stockTransaction);
                        totalTrxAmount += (Currency)stockTransaction.Amount;

                        if (stock.Material.ObjectID.Equals(outableStockTransaction.StockTransaction.Stock.Material.ObjectID) == false)
                            throw new TTException(TTUtils.CultureService.GetText("M25274", "Bilgi işleme haber veriniz. Düşülen Malzeme =") + stock.Material.Name + TTUtils.CultureService.GetText("M25063", "\r\nGönderilen Malzeme =") + outableStockTransaction.StockTransaction.Stock.Material);

                        StockTransactionDetail stockTransactionDetail = new StockTransactionDetail(ObjectContext);
                        stockTransactionDetail.OutStockTransaction = stockTransaction;
                        stockTransactionDetail.InStockTransaction = outableStockTransaction.StockTransaction;
                        stockTransactionDetail.Amount = stockTransaction.Amount;

                        stock.StockFieldsUpdate(stockTransaction, false);
                        if (restAmount <= 0)
                            break;
                    }
                }

                if (totalTrxAmount != stockActionDetail.Amount.Value)
                    throw new TTException(stockActionDetail.Material.Name + TTUtils.CultureService.GetText("M26114", "isimli malzemede belgeden farklı miktar çıkış yapılmak isteniyor.\r\nBelge Miktarı=") + stockActionDetail.Amount.Value.ToString() + TTUtils.CultureService.GetText("M25060", "\r\nÇıkış Miktarı =") + totalTrxAmount.ToString());

                if (minimumLevel != 0 && minimumLevel != null)
                {
                    if (lastInheld < minimumLevel)
                    {
                        UserMessage message = new UserMessage(ObjectContext);
                        message.IsSystemMessage = true;
                        message.MessageDate = TTObjectDefManager.ServerTime;
                        message.Subject = TTUtils.CultureService.GetText("M26529", "Minimum Seviye Bilgilendirmesi");
                        //   message.Status = MessageStatusEnum.Sent;
                        message.ToUser = (ResUser)Common.CurrentUser.UserObject;
                        message.Sender = (ResUser)Common.CurrentUser.UserObject;
                        message.SetRTFBody(stockActionDetail.Material.StockCard.Name + " isimli stok kartı minimum seviyenin altına inmiştir.\n Minimum Seviye =" + minimumLevel.ToString() + "\n Mevcut : " + lastInheld.ToString());
                    }

                    if (minimumLevel - 1 == lastInheld)
                    {
                        if (stock.Material.SendSMS == true && stock.Store.StoreSMSUsers.Count > 0)
                        {
                            List<ResUser> smsUserList = stock.Store.StoreSMSUsers.Select(x => x.ResUser).Where(x => string.IsNullOrEmpty(x.PhoneNumber) == false).ToList();
                            //foreach (StoreSMSUser smsUser in stock.Store.StoreSMSUsers)
                            //{
                            //if (string.IsNullOrEmpty(smsUser.ResUser.PhoneNumber) == false)
                            //{
                            try
                            {
                                UserMessage smsMessage = new UserMessage();
                                string smsText = stock.Material.Name + " isimli malzeme minimum seviyenin altına inmiştir./n Minimum Seviye =" + minimumLevel.ToString() + "\n Mevcut : " + lastInheld.ToString();
                                smsMessage.SendSMSPerson(smsUserList, smsText, SMSTypeEnum.MaterialMinimumLevelSMS);
                            }
                            catch (Exception)
                            {

                            }
                            //}
                            //}
                        }
                    }
                }

                if (safetyLevel != 0 && safetyLevel != null)
                {
                    if (lastInheld < safetyLevel)
                    {
                        UserMessage message = new UserMessage(ObjectContext);
                        message.IsSystemMessage = true;
                        message.MessageDate = TTObjectDefManager.ServerTime;
                        message.Subject = TTUtils.CultureService.GetText("M26529", "Kritik Seviye Bilgilendirmesi");
                        //   message.Status = MessageStatusEnum.Sent;
                        message.ToUser = (ResUser)Common.CurrentUser.UserObject;
                        message.Sender = (ResUser)Common.CurrentUser.UserObject;
                        message.SetRTFBody(stockActionDetail.Material.StockCard.Name + " isimli stok kartı kritik seviyenin altına inmiştir.\n Kritik Seviye =" + safetyLevel.ToString() + "\n Mevcut : " + lastInheld.ToString());
                    }

                    if (safetyLevel - 1 == lastInheld)
                    {
                        if (stock.Material.SendSMS == true && stock.Store.StoreSMSUsers.Count > 0)
                        {
                            List<ResUser> smsUserList = stock.Store.StoreSMSUsers.Select(x => x.ResUser).Where(x => string.IsNullOrEmpty(x.PhoneNumber) == false).ToList();
                            //foreach (StoreSMSUser smsUser in stock.Store.StoreSMSUsers)
                            //{
                            //if (string.IsNullOrEmpty(smsUser.ResUser.PhoneNumber) == false)
                            //{
                            try
                            {
                                UserMessage smsMessage = new UserMessage();
                                string smsText = stock.Material.Name + " isimli malzeme kritik seviyenin altına inmiştir./n Kritik Seviye =" + safetyLevel.ToString() + "\n Mevcut : " + lastInheld.ToString();
                                smsMessage.SendSMSPerson(smsUserList, smsText, SMSTypeEnum.MaterialSafetyLevelSMS);
                            }
                            catch (Exception)
                            {

                            }
                            //}
                            //}
                        }
                    }
                }
                return outTransactions;
            }
            else
            {
                throw new Exception(SystemMessage.GetMessageV3(534, new string[] { (stockActionDetail.Material.StockCard.Name).ToString() }));
            }
        }

        private List<StockTransaction> TransferOperation(Stock fromStock, Stock toStock, StockActionDetail stockActionDetail)
        {
            List<StockTransaction> outTransactions = OutOperation(fromStock, stockActionDetail);
            List<StockTransaction> inTransactions = new List<StockTransaction>();
            foreach (StockTransaction outStockTransaction in outTransactions)
            {
                StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                stockTransaction.InOut = TransactionTypeEnum.In;
                stockTransaction.TransactionDate = outStockTransaction.StockActionDetail.StockAction.TransactionDate;
                stockTransaction.StockTransactionDefinition = this;
                stockTransaction.StockLevelType = outStockTransaction.StockActionDetail.StockLevelType;
                stockTransaction.StockActionDetail = outStockTransaction.StockActionDetail;
                stockTransaction.MaintainLevelCode = DestinationMaintainLevelCode.Value;
                stockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
                stockTransaction.LotNo = outStockTransaction.LotNo;
                stockTransaction.Amount = outStockTransaction.Amount;
                stockTransaction.UnitPrice = outStockTransaction.UnitPrice;
                stockTransaction.VatRate = outStockTransaction.VatRate;
                stockTransaction.BudgetTypeDefinition = outStockTransaction.BudgetTypeDefinition;
                stockTransaction.IncomingDeliveryNotifID = outStockTransaction.IncomingDeliveryNotifID;
                stockTransaction.ReceiveNotificationID = outStockTransaction.ReceiveNotificationID;
                stockTransaction.SerialNo = outStockTransaction.SerialNo;

                //TODO UTS için eklendi
                stockTransaction.Patient = outStockTransaction.Patient;

                toStock.StockFieldsUpdate(stockTransaction, false);
                inTransactions.Add(stockTransaction);
            }
            return inTransactions;
        }

        private List<StockTransaction> ConsumptionOperation(Stock fromStock, Stock toStock, StockActionDetail stockActionDetail)
        {
            List<StockTransaction> outTransactions = new List<StockTransaction>();
            if (MaintainLevelCode != MaintainLevelCodeEnum.Nothing)
            {
                if (MaintainLevelCode == MaintainLevelCodeEnum.DecreaseInheld)
                    outTransactions = OutOperation(fromStock, stockActionDetail);
            }
            else
            {
                foreach (StockCollectedTrx stockCollectedTrx in stockActionDetail.StockCollectedTrxs.Select(string.Empty))
                    outTransactions.Add(stockCollectedTrx.StockTransaction);
            }

            if (DestinationMaintainLevelCode != MaintainLevelCodeEnum.Nothing)
            {
                if (outTransactions.Count == 0)
                    throw new Exception(SystemMessage.GetMessage(535));
                foreach (StockTransaction outStockTransaction in outTransactions)
                {
                    if (outStockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                    {
                        StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                        stockTransaction.InOut = outStockTransaction.InOut;
                        stockTransaction.TransactionDate = outStockTransaction.TransactionDate;
                        stockTransaction.StockTransactionDefinition = this;
                        stockTransaction.StockLevelType = outStockTransaction.StockLevelType;
                        stockTransaction.StockActionDetail = stockActionDetail;
                        stockTransaction.MaintainLevelCode = DestinationMaintainLevelCode.Value;
                        stockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
                        stockTransaction.LotNo = outStockTransaction.LotNo;
                        stockTransaction.Amount = outStockTransaction.Amount;
                        stockTransaction.UnitPrice = outStockTransaction.UnitPrice;
                        stockTransaction.VatRate = outStockTransaction.VatRate;
                        stockTransaction.BudgetTypeDefinition = outStockTransaction.BudgetTypeDefinition;

                        toStock.StockFieldsUpdate(stockTransaction, false);
                    }
                }
            }
            else
            {
                throw new Exception(SystemMessage.GetMessageV3(536, new string[] { ((MaintainLevelCodeEnum)DestinationMaintainLevelCode.Value).ToString() }));
            }
            return outTransactions;
        }

        private StockTransaction ProductionOperation(Stock fromStock, Stock toStock, StockActionDetail stockActionDetail)
        {
            StockTransaction inTransaction = null;
            if (MaintainLevelCode != MaintainLevelCodeEnum.Nothing)
                inTransaction = InOperation(fromStock, stockActionDetail);
            if (DestinationMaintainLevelCode != MaintainLevelCodeEnum.Nothing)
            {
                if (DestinationMaintainLevelCode == MaintainLevelCodeEnum.IncreaseInheld && MaintainLevelCode == MaintainLevelCodeEnum.Nothing)
                {
                    StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                    stockTransaction.InOut = TransactionTypeEnum.In;
                    stockTransaction.TransactionDate = stockActionDetail.StockAction.TransactionDate;
                    stockTransaction.StockTransactionDefinition = this;
                    stockTransaction.StockLevelType = stockActionDetail.StockLevelType;
                    stockTransaction.StockActionDetail = stockActionDetail;
                    if (((StockActionDetailIn)stockActionDetail).ExpirationDate != null)
                        stockTransaction.ExpirationDate = Common.GetLastDayOfMounth(((DateTime)((StockActionDetailIn)stockActionDetail).ExpirationDate));
                    stockTransaction.LotNo = ((StockActionDetailIn)stockActionDetail).LotNo;
                    stockTransaction.UnitPrice = ((StockActionDetailIn)stockActionDetail).UnitPrice;
                    stockTransaction.MaintainLevelCode = DestinationMaintainLevelCode.Value;
                    stockTransaction.Amount = stockActionDetail.Amount;
                    if (stockActionDetail.StockAction.BudgetTypeDefinition == null)
                        throw new TTException(TTUtils.CultureService.GetText("M26235", "İşlemin bütçe tipi seçilmemiştir."));
                    stockTransaction.BudgetTypeDefinition = stockActionDetail.StockAction.BudgetTypeDefinition;

                    toStock.StockFieldsUpdate(stockTransaction, false);
                    inTransaction = stockTransaction;
                }
            }
            return inTransaction;
        }

        private List<StockTransaction> ChangeStockLevelOperation(Stock fromStock, StockActionDetail stockActionDetail)
        {
            List<StockTransaction> outTransactions = OutOperation(fromStock, stockActionDetail);
            List<StockTransaction> inTransactions = new List<StockTransaction>();
            foreach (StockTransaction outStockTransaction in outTransactions)
            {
                StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                stockTransaction.InOut = TransactionTypeEnum.In;
                stockTransaction.TransactionDate = outStockTransaction.StockActionDetail.StockAction.TransactionDate;
                stockTransaction.StockTransactionDefinition = this;
                stockTransaction.StockLevelType = ChangedStockLevelType;
                stockTransaction.StockActionDetail = outStockTransaction.StockActionDetail;
                stockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.IncreaseInheld;
                stockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
                stockTransaction.LotNo = outStockTransaction.LotNo;
                stockTransaction.Amount = outStockTransaction.Amount;
                stockTransaction.UnitPrice = outStockTransaction.UnitPrice;
                stockTransaction.VatRate = outStockTransaction.VatRate;
                stockTransaction.BudgetTypeDefinition = outStockTransaction.BudgetTypeDefinition;

                fromStock.StockFieldsUpdate(stockTransaction, false);
                inTransactions.Add(stockTransaction);
            }
            return inTransactions;
        }

        private List<StockTransaction> UpdateExpritionDateOperation(Stock fromStock, StockActionDetail stockActionDetail)
        {
            List<StockTransaction> outTransactions = OutOperation(fromStock, stockActionDetail);
            List<StockTransaction> inTransactions = new List<StockTransaction>();
            foreach (StockTransaction outStockTransaction in outTransactions)
            {
                StockTransaction stockTransaction = new StockTransaction(ObjectContext);
                stockTransaction.InOut = TransactionTypeEnum.In;
                stockTransaction.TransactionDate = outStockTransaction.StockActionDetail.StockAction.TransactionDate;
                stockTransaction.StockTransactionDefinition = this;
                stockTransaction.StockLevelType = stockActionDetail.StockLevelType;
                stockTransaction.StockActionDetail = outStockTransaction.StockActionDetail;
                stockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.IncreaseInheld;
                //stockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
                stockTransaction.ExpirationDate = ((IExtendExpirationDateDetail)(stockActionDetail)).GetNewDateForExpiration();

                stockTransaction.LotNo = outStockTransaction.LotNo;
                stockTransaction.Amount = outStockTransaction.Amount;
                stockTransaction.UnitPrice = outStockTransaction.UnitPrice;
                stockTransaction.VatRate = outStockTransaction.VatRate;
                stockTransaction.BudgetTypeDefinition = outStockTransaction.BudgetTypeDefinition;

                IBindingList inTRXs = ObjectContext.LocalQuery("STOCKTRANSACTIONDETAIL", "OUTSTOCKTRANSACTION = " + ConnectionManager.GuidToString(outStockTransaction.ObjectID));
                if (inTRXs.Count > 0)
                {
                    StockTransaction inTRX = ((StockTransactionDetail)inTRXs[0]).InStockTransaction;
                    if (inTRX.MKYS_StokHareketID != null)
                        stockTransaction.MKYS_StokHareketID = inTRX.MKYS_StokHareketID;
                    else
                        throw new TTException(inTRX.Stock.Material.Name + " isimli malzemenin değiştirilmek istenen miadın MKYS'ye bildirimi yapılmamıştır. İşlem No: " + inTRX.StockActionDetail.StockAction.StockActionID.ToString());
                }

                fromStock.StockFieldsUpdate(stockTransaction, false);
                inTransactions.Add(stockTransaction);
            }
            return inTransactions;
        }
        private void CheckStockInheld(Stock stock, StockActionDetail stockActionDetail)
        {
            string errMessage = string.Empty;
            if (stock.Inheld == 0)
                errMessage += TTUtils.CultureService.GetText("M26507", "Mevcut yok!");

            if (stock.Inheld < stockActionDetail.Amount)
                errMessage += TTUtils.CultureService.GetText("M27253", "Yeterli mevcut yok!");

            if ((stock.Inheld - stock.ReservedAmount) < stockActionDetail.Amount)
                errMessage += "Ayırtılmış miktar çıkarıldığında mevcut yeterli değildir!";

            IList stockLevels = stock.StockLevels.Select("STOCKLEVELTYPE = " + ConnectionManager.GuidToString(stockActionDetail.StockLevelType.ObjectID));
            TTDataType stockLevelDataType = TTObjectDefManager.Instance.DataTypes[typeof(StockLevelTypeEnum).Name];
            StockLevel stockLevel = null;
            if (stockLevels.Count == 0)
            {
                errMessage += TTUtils.CultureService.GetText("M26158", "İstenen seviye yok!");
            }
            else
            {
                stockLevel = (StockLevel)stockLevels[0];
                if (stockLevel.Amount == 0)
                    errMessage += TTUtils.CultureService.GetText("M26159", "İstenen seviyede mevcut yok!");

                if (stockLevel.Amount < stockActionDetail.Amount)
                    errMessage += TTUtils.CultureService.GetText("M26160", "İstenen seviyede yeterli mevcut yok!");
            }
            if (string.IsNullOrEmpty(errMessage) == false)
            {
                errMessage += "\r\n\r\nDepo : " + stock.Store.Name + "\r\nMalzeme Adı : " + stock.Material.Name + "\r\nİstenen Miktar : " + stockActionDetail.Amount;
                errMessage += "\r\nMevcut : " + stock.Inheld;
                if (stockLevel != null)
                    errMessage += "\r\n" + stockLevelDataType.EnumValueDefs[(int)stockActionDetail.StockLevelType.StockLevelTypeStatus].DisplayText + " Mevcut : " + stockLevel.Amount;
                if (stock.ReservedAmount.HasValue && stock.ReservedAmount.Value > 0)
                    errMessage += "\r\nAyırtılmış Miktar : " + stock.ReservedAmount;
                throw new Exception(errMessage);
            }
        }

        private void DoFixedAssetOperation(StockTransaction stockTransaction)
        {
            if (IsFixedAsset.HasValue && IsFixedAsset.Value == true)
            {
                if (stockTransaction == null)
                    throw new Exception(SystemMessage.GetMessage(537));
                switch (TransactionType)
                {
                    case TransactionTypeEnum.In:
                        if (stockTransaction.StockActionDetail.Material is FixedAssetDefinition && stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if (((StockActionDetailIn)stockTransaction.StockActionDetail).FixedAssetInDetails.Count == 0)
                                throw new Exception(SystemMessage.GetMessageV3(538, new string[] { (stockTransaction.StockActionDetail.Material.Name).ToString() }));

                            List<FixedAssetMaterialDefinition> famdList = new List<FixedAssetMaterialDefinition>();

                            foreach (FixedAssetInDetail fixedAssetInDetail in ((StockActionDetailIn)stockTransaction.StockActionDetail).FixedAssetInDetails)
                            {
                                if (fixedAssetInDetail.TransferredFromXXXXXXSite == false)
                                {
                                    FixedAssetMaterialDefinition fixedAssetMaterialDefinition = new FixedAssetMaterialDefinition(ObjectContext);
                                    fixedAssetMaterialDefinition.CopyFromFixedAssetInDetail(fixedAssetInDetail);
                                    fixedAssetMaterialDefinition.Stock = stockTransaction.Stock;
                                    fixedAssetMaterialDefinition.Accountancy = ((MainStoreDefinition)stockTransaction.Stock.Store).Accountancy;
                                    fixedAssetMaterialDefinition.LastCalibrationDate = TTObjectDefManager.ServerTime.Date;
                                    fixedAssetMaterialDefinition.LastMaintenanceDate = TTObjectDefManager.ServerTime.Date;
                                    fixedAssetMaterialDefinition.Status = FixedAssetStatusEnum.New;

                                    FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                    fixedAssetTransaction.FixedAsset = fixedAssetMaterialDefinition;
                                    fixedAssetTransaction.StockTransaction = stockTransaction;
                                    fixedAssetTransaction.Resource = fixedAssetInDetail.Resource;
                                    fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                                    famdList.Add(fixedAssetMaterialDefinition);

                                }
                                else if (fixedAssetInDetail.TransferredFromXXXXXXSite == true)
                                {
                                    fixedAssetInDetail.TransferedFixedAssetMaterial.Stock = stockTransaction.Stock;

                                    FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                    fixedAssetTransaction.FixedAsset = fixedAssetInDetail.TransferedFixedAssetMaterial;
                                    fixedAssetTransaction.StockTransaction = stockTransaction;
                                    fixedAssetTransaction.Resource = fixedAssetInDetail.Resource;
                                    fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;
                                }
                            }
                            DoFixedAssetDetailInOperation(famdList, stockTransaction.StockActionDetail.Material.StockCard);
                        }
                        else
                        {
                            if (((StockActionDetailIn)stockTransaction.StockActionDetail).FixedAssetInDetails.Count > 0)
                                throw new Exception(SystemMessage.GetMessageV3(539, new string[] { (stockTransaction.StockActionDetail.Material.Name).ToString() }));
                        }
                        break;
                    case TransactionTypeEnum.Out:
                        if (stockTransaction.StockActionDetail.Material is FixedAssetDefinition && stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count == 0)
                                throw new Exception(SystemMessage.GetMessageV2(538, (stockTransaction.StockActionDetail.Material.Name).ToString()));

                            foreach (FixedAssetOutDetail fixedAssetOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails)
                            {
                                FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                fixedAssetTransaction.FixedAsset = fixedAssetOutDetail.FixedAssetMaterialDefinition;
                                fixedAssetTransaction.StockTransaction = stockTransaction;
                                fixedAssetTransaction.Resource = fixedAssetOutDetail.Resource;
                                fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Stock = null;
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Accountancy = fixedAssetOutDetail.Accountancy;
                            }
                        }
                        else
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count > 0)
                                throw new Exception(SystemMessage.GetMessageV2(539, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                        }
                        break;
                    case TransactionTypeEnum.Transfer:
                        if (stockTransaction.StockActionDetail.Material is FixedAssetDefinition && stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count == 0)
                                throw new Exception(SystemMessage.GetMessageV2(538, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                            foreach (FixedAssetOutDetail fixedAssetOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails)
                            {
                                FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                fixedAssetTransaction.FixedAsset = fixedAssetOutDetail.FixedAssetMaterialDefinition;
                                fixedAssetTransaction.StockTransaction = stockTransaction;
                                fixedAssetTransaction.Resource = fixedAssetOutDetail.Resource;
                                fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Stock = fixedAssetTransaction.StockTransaction.Stock;
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Resource = fixedAssetTransaction.Resource;
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Status = FixedAssetStatusEnum.Used;
                            }
                        }
                        else
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count > 0)
                                throw new Exception(SystemMessage.GetMessageV2(539, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                        }
                        break;
                    case TransactionTypeEnum.ChangeStockLevel:
                        if (stockTransaction.StockActionDetail.Material is FixedAssetDefinition && stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count == 0)
                                throw new Exception(SystemMessage.GetMessageV2(538, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                            foreach (FixedAssetOutDetail fixedAssetOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails)
                            {
                                FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                fixedAssetTransaction.FixedAsset = fixedAssetOutDetail.FixedAssetMaterialDefinition;
                                fixedAssetTransaction.StockTransaction = stockTransaction;
                                fixedAssetTransaction.Resource = fixedAssetOutDetail.Resource;
                                fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Stock = fixedAssetTransaction.StockTransaction.Stock;
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Resource = fixedAssetTransaction.Resource;
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Status = FixedAssetStatusEnum.Dead;
                            }
                        }
                        else
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count > 0)
                                throw new Exception(SystemMessage.GetMessageV2(539, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                        }
                        break;
                    case TransactionTypeEnum.MergeStock:
                        if (stockTransaction.StockActionDetail.Material is FixedAssetDefinition && stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count == 0)
                                throw new Exception(SystemMessage.GetMessageV2(538, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                            foreach (FixedAssetOutDetail fixedAssetOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails)
                            {
                                FixedAssetTransaction fixedAssetTransaction = new FixedAssetTransaction(ObjectContext);
                                fixedAssetTransaction.FixedAsset = fixedAssetOutDetail.FixedAssetMaterialDefinition;
                                fixedAssetTransaction.StockTransaction = stockTransaction;
                                fixedAssetTransaction.Resource = fixedAssetOutDetail.FixedAssetMaterialDefinition.Resource;
                                fixedAssetTransaction.CurrentStateDefID = FixedAssetTransaction.States.Completed;

                                fixedAssetOutDetail.FixedAssetMaterialDefinition.Stock = fixedAssetTransaction.StockTransaction.Stock.Store.GetStock(fixedAssetTransaction.StockTransaction.Stock.Material.JoinedMaterial);
                                fixedAssetOutDetail.FixedAssetMaterialDefinition.FixedAssetDefinition = (FixedAssetDefinition)fixedAssetTransaction.StockTransaction.Stock.Material.JoinedMaterial;
                            }
                        }
                        else
                        {
                            if (((StockActionDetailOut)stockTransaction.StockActionDetail).FixedAssetOutDetails.Count > 0)
                                throw new Exception(SystemMessage.GetMessageV2(539, (stockTransaction.StockActionDetail.Material.Name).ToString()));
                        }
                        break;
                    default:
                        throw new Exception(SystemMessage.GetMessage(540));
                }
            }
            else
            {
                if (stockTransaction.StockActionDetail.FixedAssetDetails.Count > 0)
                    throw new Exception(SystemMessage.GetMessageV3(541, new string[] { (stockTransaction.StockActionDetail.Material.StockCard.NATOStockNO).ToString(), (stockTransaction.StockActionDetail.Material.Name).ToString() }));
            }
        }

        private void DoFixedAssetDetailInOperation(List<FixedAssetMaterialDefinition> famdList, StockCard stockcard)
        {
            if (famdList.Count > 0)
            {
                FixedAssetDetailAction fixedAssetDetailAction = new FixedAssetDetailAction(ObjectContext);
                fixedAssetDetailAction.StockCard = stockcard;
                fixedAssetDetailAction.WorkListDescription = stockcard.NATOStockNO + " - " + stockcard.Name + " Detaylandırılması.(Giriş İşlemi İle Yapılmıştır.)";
                foreach (FixedAssetMaterialDefinition fixedAsset in famdList)
                {
                    FixedAssetDetailActionDet fixedAssetDetailActionDet = new FixedAssetDetailActionDet(ObjectContext);
                    fixedAssetDetailActionDet.FixedAssetMaterialDefinition = fixedAsset;
                    fixedAssetDetailActionDet.FixedAssetDetailAction = fixedAssetDetailAction;
                    fixedAssetDetailActionDet.IsAccountancy = true;
                    fixedAssetDetailActionDet.IsNewFixedAsset = true;
                }
                fixedAssetDetailAction.CurrentStateDefID = FixedAssetDetailAction.States.StageOne;//StageTwo;
            }
        }

        private void DoQRCodeOperation(StockTransaction stockTransaction)
        {
            if (stockTransaction == null)
                throw new Exception(TTUtils.CultureService.GetText("M26271", "Karekod için stok hareketi oluşturulmamıştır."));
            switch (TransactionType)
            {
                case TransactionTypeEnum.In:
                    if (stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                    {
                        // Attribute ile kontrol yapılıyor gerek kalmadı. SS
                        //if (((StockActionDetailIn)stockTransaction.StockActionDetail).QRCodeDetails.Count == 0)
                        //    throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Karekod detayları girilmemiştir.");
                        foreach (QRCodeInDetail qRCodeInDetail in ((StockActionDetailIn)stockTransaction.StockActionDetail).QRCodeInDetails)
                        {
                            QRCodeTransaction qRCodeTransaction = new QRCodeTransaction(ObjectContext);
                            qRCodeTransaction.Barcode = qRCodeInDetail.Barcode;
                            qRCodeTransaction.BoxNo = qRCodeInDetail.BoxNo;
                            qRCodeTransaction.BunchNo = qRCodeInDetail.BunchNo;
                            qRCodeTransaction.ExpireDate = qRCodeInDetail.ExpireDate;
                            qRCodeTransaction.LotNo = qRCodeInDetail.LotNo;
                            qRCodeTransaction.OrderNo = qRCodeInDetail.OrderNo;
                            qRCodeTransaction.PackageNo = qRCodeInDetail.PackageNo;
                            qRCodeTransaction.PalletNo = qRCodeInDetail.PalletNo;
                            qRCodeTransaction.SmallBunchNo = qRCodeInDetail.SmallBunchNo;
                            qRCodeTransaction.StockTransaction = stockTransaction;
                            qRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Usable;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailIn)stockTransaction.StockActionDetail).QRCodeDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Karekod ile takip edilmemesine rağmen Karekod girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.Out:
                    if (stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                    {
                        // Attribute ile kontrol yapılıyor gerek kalmadı. SS
                        //if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count == 0)
                        //    throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Karekod detayları girilmemiştir.");

                        foreach (QRCodeOutDetail qRCodeOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeOutDetails)
                        {
                            qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Used;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Karekod ile takip edilmemesine rağmen Karekod girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.Transfer:
                    if (stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                    {
                        // Attribute ile kontrol yapılıyor gerek kalmadı. SS
                        //if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count == 0)
                        //    throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Karekod detayları girilmemiştir.");
                        foreach (QRCodeOutDetail qRCodeOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeOutDetails)
                        {
                            qRCodeOutDetail.QRCodeTransaction.StockTransaction = stockTransaction;
                            if (qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID == QRCodeTransaction.States.Reserved)
                                qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Usable;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Karekod ile takip edilmemesine rağmen Karekod girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.ChangeStockLevel:
                    if (stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                    {
                        // Attribute ile kontrol yapılıyor gerek kalmadı. SS
                        //if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count == 0)
                        //    throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Karekod detayları girilmemiştir.");
                        foreach (QRCodeOutDetail qRCodeOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeOutDetails)
                        {
                            qRCodeOutDetail.QRCodeTransaction.StockTransaction = stockTransaction;
                            if (qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID == QRCodeTransaction.States.Reserved)
                                qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Usable;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Karekod ile takip edilmemesine rağmen Karekod girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.MergeStock:
                    if (stockTransaction.StockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                    {
                        // Attribute ile kontrol yapılıyor gerek kalmadı. SS
                        //if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count == 0)
                        //    throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Karekod detayları girilmemiştir.");
                        foreach (QRCodeOutDetail qRCodeOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeOutDetails)
                        {
                            qRCodeOutDetail.QRCodeTransaction.StockTransaction = stockTransaction;
                            if (qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID == QRCodeTransaction.States.Reserved)
                                qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Usable;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).QRCodeDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Karekod ile takip edilmemesine rağmen Karekod girilmiştir.");
                    }
                    break;
                default:
                    throw new Exception(TTUtils.CultureService.GetText("M25418", "Desteklenmeyen Karekod hareketi tipi"));

            }
        }

        private void DoPrescriptionPaperOperation(StockTransaction stockTransaction)
        {
            if (stockTransaction == null)
                throw new Exception(TTUtils.CultureService.GetText("M26760", "Reçete Takip için stok hareketi oluşturulmamıştır."));
            switch (TransactionType)
            {
                case TransactionTypeEnum.In:
                    if (stockTransaction.StockActionDetail.StockAction is IBasePrescriptionTransaction)
                    {
                        if (((StockActionDetailIn)stockTransaction.StockActionDetail).PrescriptionPaperInDetails.Count == 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Reçete detayları girilmemiştir.");
                        foreach (PrescriptionPaperInDetail prescriptionPaperInDetail in ((StockActionDetailIn)stockTransaction.StockActionDetail).PrescriptionPaperInDetails)
                        {
                            PrescriptionPaper prescriptionPaper = new PrescriptionPaper(ObjectContext);
                            prescriptionPaper.SerialNo = prescriptionPaperInDetail.SerialNo;
                            prescriptionPaper.VolumeNo = prescriptionPaperInDetail.VolumeNo;
                            prescriptionPaper.Stock = stockTransaction.Stock;
                            prescriptionPaper.CurrentStateDefID = PrescriptionPaper.States.Usable;
                            prescriptionPaperInDetail.CreatedPrescriptionPaper = prescriptionPaper;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailIn)stockTransaction.StockActionDetail).PrescriptionPaperInDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Reçete olmamasına rağmen Reçete detayları girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.Out:
                    if (stockTransaction.StockActionDetail.StockAction is IBasePrescriptionTransaction)
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails.Count == 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Reçete detayları girilmemiştir.");

                        foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails)
                        {
                            prescriptionPaperOutDetail.PrescriptionPaper.CurrentStateDefID = PrescriptionPaper.States.Used;
                        }
                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Reçete olmamasına rağmen Reçete detayları girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.Transfer:
                    if (stockTransaction.StockActionDetail.StockAction is IBasePrescriptionTransaction)
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails.Count == 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzemenin Reçete detayları girilmemiştir.");

                        foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in ((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails)
                            prescriptionPaperOutDetail.PrescriptionPaper.Stock = stockTransaction.Stock;

                    }
                    else
                    {
                        if (((StockActionDetailOut)stockTransaction.StockActionDetail).PrescriptionPaperOutDetails.Count > 0)
                            throw new Exception((stockTransaction.StockActionDetail.Material.Name).ToString() + " isimli malzeme Reçete olmamasına rağmen Reçete detayları girilmiştir.");
                    }
                    break;
                case TransactionTypeEnum.ChangeStockLevel:
                case TransactionTypeEnum.MergeStock:
                    break;
                default:
                    throw new Exception(TTUtils.CultureService.GetText("M25418", "Desteklenmeyen Karekod hareketi tipi"));

            }
        }


        public List<StockTransaction> MergeStockOperation(IStockMergeTransaction Interface, IStockMergeMaterialOut stockMergeMaterialOut)
        {
            Store store = Interface.GetStore();
            Store destinationStore = Interface.GetDestinationStore();

            List<StockTransaction> outTransactions = new List<StockTransaction>();

            StockTransaction outStockTransaction = new StockTransaction(ObjectContext);
            outStockTransaction.InOut = TransactionTypeEnum.Out;
            outStockTransaction.TransactionDate = stockMergeMaterialOut.GetStockAction().TransactionDate;
            outStockTransaction.StockTransactionDefinition = this;
            outStockTransaction.StockLevelType = stockMergeMaterialOut.GetOutableStockTransaction().StockLevelType;
            outStockTransaction.StockActionDetail = (StockActionDetail)stockMergeMaterialOut;
            outStockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.DecreaseInheld;
            outStockTransaction.Amount = stockMergeMaterialOut.GetAmount();
            outStockTransaction.ExpirationDate = stockMergeMaterialOut.GetOutableStockTransaction().ExpirationDate;
            outStockTransaction.LotNo = stockMergeMaterialOut.GetOutableStockTransaction().LotNo;
            outStockTransaction.UnitPrice = stockMergeMaterialOut.GetOutableStockTransaction().UnitPrice;
            outStockTransaction.VatRate = stockMergeMaterialOut.GetOutableStockTransaction().VatRate;

            StockTransactionDetail outStockTransactionDetail = new StockTransactionDetail(ObjectContext);
            outStockTransactionDetail.OutStockTransaction = outStockTransaction;
            outStockTransactionDetail.InStockTransaction = stockMergeMaterialOut.GetOutableStockTransaction();
            outStockTransactionDetail.Amount = outStockTransaction.Amount;

            stockMergeMaterialOut.GetOutableStockTransaction().Stock.StockFieldsUpdate(outStockTransaction, false);
            outTransactions.Add(outStockTransaction);

            StockTransaction inStockTransaction = new StockTransaction(ObjectContext);
            inStockTransaction.InOut = TransactionTypeEnum.In;
            inStockTransaction.TransactionDate = outStockTransaction.TransactionDate;
            inStockTransaction.StockTransactionDefinition = this;
            inStockTransaction.StockLevelType = outStockTransaction.StockLevelType;
            inStockTransaction.StockActionDetail = (StockActionDetail)stockMergeMaterialOut.GetStockMergeMaterialIn();
            inStockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.IncreaseInheld;
            inStockTransaction.Amount = outStockTransaction.Amount;
            inStockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
            inStockTransaction.LotNo = outStockTransaction.LotNo;
            inStockTransaction.UnitPrice = outStockTransaction.UnitPrice;
            inStockTransaction.VatRate = outStockTransaction.VatRate;

            stockMergeMaterialOut.GetStockMergeMaterialIn().SetExpirationDate(outStockTransaction.ExpirationDate);
            stockMergeMaterialOut.GetStockMergeMaterialIn().SetUnitPrice(outStockTransaction.UnitPrice);
            stockMergeMaterialOut.GetStockMergeMaterialIn().SetVatRate(outStockTransaction.VatRate);

            Stock inStock = store.GetStock(stockMergeMaterialOut.GetStockMergeMaterialIn().GetMaterial());
            inStock.StockFieldsUpdate(inStockTransaction, false);

            if (destinationStore != null)
            {
                StockTransaction destOutStockTransaction = new StockTransaction(ObjectContext);
                destOutStockTransaction.InOut = TransactionTypeEnum.Out;
                destOutStockTransaction.TransactionDate = stockMergeMaterialOut.GetStockAction().TransactionDate;
                destOutStockTransaction.StockTransactionDefinition = this;
                destOutStockTransaction.StockLevelType = outStockTransaction.StockLevelType;
                destOutStockTransaction.StockActionDetail = (StockActionDetail)stockMergeMaterialOut;
                destOutStockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.DecreaseConsigned;
                destOutStockTransaction.Amount = outStockTransaction.Amount;
                destOutStockTransaction.ExpirationDate = outStockTransaction.ExpirationDate;
                destOutStockTransaction.LotNo = outStockTransaction.LotNo;
                destOutStockTransaction.UnitPrice = outStockTransaction.UnitPrice;
                destOutStockTransaction.VatRate = outStockTransaction.VatRate;

                // Muvakkatların hangi transactiondan çıktığının önemi yok.
                //StockTransactionDetail destOutStockTransactionDetail = new StockTransactionDetail(ObjectContext);
                //destOutStockTransactionDetail.OutStockTransaction = destOutStockTransaction;
                //destOutStockTransactionDetail.InStockTransaction = stockMergeMaterialOut.OutableStockTransaction;
                //destOutStockTransactionDetail.Amount = destOutStockTransaction.Amount;

                Stock outdestStock = destinationStore.GetStock(stockMergeMaterialOut.GetMaterial());
                outdestStock.StockFieldsUpdate(destOutStockTransaction, false);

                StockTransaction destInStockTransaction = new StockTransaction(ObjectContext);
                destInStockTransaction.InOut = TransactionTypeEnum.In;
                destInStockTransaction.TransactionDate = destOutStockTransaction.TransactionDate;
                destInStockTransaction.StockTransactionDefinition = this;
                destInStockTransaction.StockLevelType = destOutStockTransaction.StockLevelType;
                destInStockTransaction.StockActionDetail = (StockActionDetail)stockMergeMaterialOut.GetStockMergeMaterialIn();
                destInStockTransaction.MaintainLevelCode = MaintainLevelCodeEnum.IncreaseConsigned;
                destInStockTransaction.Amount = destOutStockTransaction.Amount;
                destInStockTransaction.ExpirationDate = destOutStockTransaction.ExpirationDate;
                destInStockTransaction.LotNo = destOutStockTransaction.LotNo;
                destInStockTransaction.UnitPrice = destOutStockTransaction.UnitPrice;
                destInStockTransaction.VatRate = destOutStockTransaction.VatRate;

                Stock indestStock = destinationStore.GetStock(stockMergeMaterialOut.GetStockMergeMaterialIn().GetMaterial());
                indestStock.StockFieldsUpdate(destInStockTransaction, false);
            }
            return outTransactions;
        }


        public bool DoOperation(IStockMergeTransaction Interface, IStockMergeMaterialOut stockMergeMaterialOut)
        {
            switch (TransactionType)
            {
                case TransactionTypeEnum.MergeStock:
                    List<StockTransaction> outTransactions = MergeStockOperation(Interface, stockMergeMaterialOut);
                    if (outTransactions != null && outTransactions.Count > 0)
                    {
                        foreach (StockTransaction outTransaction in outTransactions)
                        {
                            DoFixedAssetOperation(outTransaction);
                            DoQRCodeOperation(outTransaction);
                        }
                        return true;
                    }
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessage(542));
            }
            return false;
        }

        public bool DoOperation(Stock fromStock, Stock toStock, StockActionDetail stockActionDetail)
        {
            switch (TransactionType)
            {
                case TransactionTypeEnum.In:
                    StockTransaction inTransaction = InOperation(fromStock, stockActionDetail);
                    if (inTransaction != null)
                    {
                        DoFixedAssetOperation(inTransaction);
                        DoQRCodeOperation(inTransaction);
                        DoPrescriptionPaperOperation(inTransaction);
                        return true;
                    }
                    break;
                case TransactionTypeEnum.Out:
                    CheckStockInheld(fromStock, stockActionDetail);
                    List<StockTransaction> outTransactions = OutOperation(fromStock, stockActionDetail);
                    if (outTransactions != null && outTransactions.Count > 0)
                    {
                        foreach (StockTransaction outTransaction in outTransactions)
                        {
                            DoFixedAssetOperation(outTransaction);
                            DoQRCodeOperation(outTransaction);
                            DoPrescriptionPaperOperation(outTransaction);
                        }
                        return true;
                    }
                    break;
                case TransactionTypeEnum.Transfer:
                    CheckStockInheld(fromStock, stockActionDetail);
                    List<StockTransaction> intTransactions = TransferOperation(fromStock, toStock, stockActionDetail);
                    if (intTransactions != null && intTransactions.Count > 0)
                    {
                        foreach (StockTransaction intTransaction in intTransactions)
                        {
                            DoFixedAssetOperation(intTransaction);
                            DoQRCodeOperation(intTransaction);
                            DoPrescriptionPaperOperation(intTransaction);
                        }
                        return true;
                    }
                    break;
                case TransactionTypeEnum.Consumption:
                    outTransactions = ConsumptionOperation(fromStock, toStock, stockActionDetail);
                    if (outTransactions != null && outTransactions.Count > 0)
                        return true;
                    break;
                case TransactionTypeEnum.Production:
                    inTransaction = ProductionOperation(fromStock, toStock, stockActionDetail);
                    if (inTransaction != null)
                        return true;
                    break;
                case TransactionTypeEnum.ChangeStockLevel:
                    CheckStockInheld(fromStock, stockActionDetail);
                    intTransactions = ChangeStockLevelOperation(fromStock, stockActionDetail);
                    if (intTransactions != null && intTransactions.Count > 0)
                    {
                        foreach (StockTransaction intTransaction in intTransactions)
                        {
                            DoFixedAssetOperation(intTransaction);
                            DoQRCodeOperation(intTransaction);
                            DoPrescriptionPaperOperation(intTransaction);
                        }
                        return true;
                    }
                    break;
                case TransactionTypeEnum.ChangeExpirationDate:
                    CheckStockInheld(fromStock, stockActionDetail);
                    intTransactions = UpdateExpritionDateOperation(fromStock, stockActionDetail);
                    if (intTransactions != null && intTransactions.Count > 0)
                        return true;
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessage(542));
            }
            return false;
        }


        public List<StockTransaction> CollectStockTransactions(DateTime startDate, DateTime endDate, Store store)
        {
            List<StockTransaction> retvalue = null;
            if (StockTransactionCollectedDefinitions.Count > 0)
            {
                retvalue = new List<StockTransaction>();
                List<Guid> defIDs = new List<Guid>();
                foreach (StockTransactionCollectedDefinition stockTransactionCollectedDefinition in StockTransactionCollectedDefinitions)
                    defIDs.Add(stockTransactionCollectedDefinition.CheckedStockTransactionDef.ObjectID);

                TTObjectContext ctx = new TTObjectContext(true);
                IList stockTransactions = StockTransaction.GetStockTransactionToProductionConsumption(ctx, defIDs, startDate, endDate, store.ObjectID);
                foreach (StockTransaction stockTransaction in stockTransactions)
                {
                    IList stockCollectedTrxs = ctx.QueryObjects(typeof(StockCollectedTrx).Name, "STOCKTRANSACTION = " + ConnectionManager.GuidToString(stockTransaction.ObjectID));
                    bool usedBefore = false;
                    if (stockCollectedTrxs.Count > 0)
                        usedBefore = true;
                    if (usedBefore == false)
                        retvalue.Add(stockTransaction);
                }
            }
            return retvalue;
        }

        public List<StockTransaction> CollectStockTransactionsByRoomStores(DateTime startDate, DateTime endDate, IList stores)
        {
            List<StockTransaction> retvalue = null;
            if (StockTransactionCollectedDefinitions.Count > 0)
            {
                retvalue = new List<StockTransaction>();
                List<Guid> defIDs = new List<Guid>();
                foreach (StockTransactionCollectedDefinition stockTransactionCollectedDefinition in StockTransactionCollectedDefinitions)
                    defIDs.Add(stockTransactionCollectedDefinition.CheckedStockTransactionDef.ObjectID);

                foreach (Store roomStore in stores)
                {
                    TTObjectContext ctx = new TTObjectContext(true);
                    IList stockTransactions = StockTransaction.GetStockTransactionToProductionConsumption(ctx, defIDs, startDate, endDate, roomStore.ObjectID);
                    foreach (StockTransaction stockTransaction in stockTransactions)
                    {
                        IList stockCollectedTrxs = ctx.QueryObjects(typeof(StockCollectedTrx).Name, "STOCKTRANSACTION = " + ConnectionManager.GuidToString(stockTransaction.ObjectID));
                        bool usedBefore = false;
                        if (stockCollectedTrxs.Count == 0)
                            usedBefore = true;
                        if (usedBefore == false)
                            retvalue.Add(stockTransaction);
                    }
                }
            }
            return retvalue;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.StockTransactionDefinitionInfo;
        }

        #endregion Methods

    }
}