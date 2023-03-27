using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Core.Security;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class MkysIntegrationController : Controller
    {
        public class EndOfYearItem
        {
            public Store store { get; set; }
            public string year { get; set; }
            public string MKYSUserName { get; set; }
            public string MKYSUserPassword { get; set; }
        }

        public class OutputMyStock
        {
            public string stockcardObj { get; set; }
            public string tasinirKod { get; set; }
            public string malzemeAdi { get; set; }
            public string mevcut { get; set; }
            public string depoObjID { get; set; }

            public Currency calcInheld { get; set; }
            public Currency calcTotalIn { get; set; }
            public Currency calcTotalInPrice { get; set; }
            public Currency calcTotalOut { get; set; }
            public Currency calcTotalOutPrice { get; set; }
        }


        public class QueryInputDVO
        {
            public Guid accountingTermObjID
            {
                get;
                set;
            }

            public bool isWithOutCancelled
            {
                get;
                set;
            }
            public string StoreID { get; set; }
        }

        public class QueryMkysDVO
        {
            public List<DocumentRecordLogGridItem> mkysObject
            {
                get;
                set;
            }

            public string MKYSUserName
            {
                get;
                set;
            }
            public string MKYSUserPassword
            {
                get;
                set;
            }
        }

        public class QueryMkysCompareItem
        {
            public string stockActionID
            {
                get;
                set;
            }
        }

        public class QueryMkysActionAllCompare
        {
            public DateTime startDate
            {
                get;
                set;
            }

            public DateTime endDate
            {
                get;
                set;
            }

            public string stockActionID
            {
                get;
                set;
            }
            public string MKYSUserName
            {
                get;
                set;
            }
            public string MKYSUserPassword
            {
                get;
                set;
            }
        }



        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MkysIntegrationViewModel GetRoleControlMkys()
        {
            MkysIntegrationViewModel model = new MkysIntegrationViewModel();
            if (TTUser.CurrentUser.HasRole(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Gonderilemeyen_Islemler) != true)
            {
                model.hasRoleSendToMkys = false;
            }
            else
            {
                model.hasRoleSendToMkys = true;
            }
            if (TTUser.CurrentUser.HasRole(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Karsilastirma) != true)
            {
                model.hasRoleCompareToMkys = false;
            }
            else
            {
                model.hasRoleCompareToMkys = true;
            }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Kurumlardan_Gelen_Belgeler) != true)
            {
                model.hasRoleMkysDocumentsFromInstitutions = false;
            }
            else
            {
                model.hasRoleMkysDocumentsFromInstitutions = true;
            }

            if (TTUser.CurrentUser.HasRole(TTRoleNames.Yilsonu_Devir_Islemi_Kayit) != true ||
                TTUser.CurrentUser.HasRole(TTRoleNames.Yilsonu_Devir_Islemi_Onay) != true ||
                 TTUser.CurrentUser.HasRole(TTRoleNames.Yilsonu_Devir_Islemi_Tamam) != true)
            {
                model.hasRoleMkysEndOfYearCensus = false;
            }
            else
            {
                model.hasRoleMkysEndOfYearCensus = true;
            }

            return model;
        }


        public class GetActiveAccountingTerm_Input
        {
            public Guid storeObjectId { get; set; }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi)]
        public MkysIntegrationViewModel GetActiveAccountingTerm(GetActiveAccountingTerm_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MkysIntegrationViewModel model = new MkysIntegrationViewModel();
                ActiveAccountingTerm activeAccountingTerm = new ActiveAccountingTerm();
                Store store = (Store)objectContext.GetObject(input.storeObjectId, typeof(Store));
                if (store is MainStoreDefinition)
                {
                    MainStoreDefinition mainStoreDefinition = (MainStoreDefinition)store;
                    var activeTerm = objectContext.QueryObjects("ACCOUNTINGTERM", "STATUS = '1' AND ACCOUNTANCY = '" + mainStoreDefinition.Accountancy.ObjectID.ToString() + "'");
                    if (activeTerm.Count > 0)
                    {
                        activeAccountingTerm.AccountingTerm = ((AccountingTerm)activeTerm[0]).ObjectID;
                        activeAccountingTerm.Desciption = ((AccountingTerm)activeTerm[0]).Description;
                    }
                    model.ActiveAccountingTerm = activeAccountingTerm;
                }
                return model;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Gonderilemeyen_Islemler)]
        public MkysIntegrationViewModel GetDocumentRecordLog(QueryInputDVO inputdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MkysIntegrationViewModel model = new MkysIntegrationViewModel();
                List<DocumentRecordLogGridItem> documentRecordLogList = new List<DocumentRecordLogGridItem>();
                if (inputdvo.isWithOutCancelled)
                {
                    documentRecordLogList =
                         DocumentRecordLog.GetDocumentRecordLogToMkysIntegrationComp(inputdvo.accountingTermObjID, new Guid(inputdvo.StoreID)).Select(docRecord => new DocumentRecordLogGridItem()
                         {
                             ObjectID = docRecord.ObjectID.Value,
                             Subject = docRecord.Subject,
                             DocumentRecordLogNumber = (long)docRecord.DocumentRecordLogNumber,
                             DocumentDateTime = (DateTime)docRecord.DocumentDateTime,
                             DocumentTransactionType = (TTObjectClasses.DocumentTransactionTypeEnum)docRecord.DocumentTransactionType,
                             ReceiptNumber = docRecord.ReceiptNumber,
                             StockAction = docRecord.StockAction,
                             StockActionID = docRecord.StockActionID.ToString(),
                             MKYSControlType = docRecord.MKYSStatus.Value,
                             BudgetTypeName = (MKYS_EButceTurEnum)docRecord.BudgeType,
                         }).ToList();
                }
                else
                {
                    documentRecordLogList = DocumentRecordLog.GetDocumentRecordLogToMkysIntegration(inputdvo.accountingTermObjID, new Guid(inputdvo.StoreID)).Select(docRecord => new DocumentRecordLogGridItem()
                    {
                        ObjectID = docRecord.ObjectID.Value,
                        Subject = docRecord.Subject,
                        DocumentRecordLogNumber = (long)docRecord.DocumentRecordLogNumber,
                        DocumentDateTime = (DateTime)docRecord.DocumentDateTime,
                        DocumentTransactionType = (TTObjectClasses.DocumentTransactionTypeEnum)docRecord.DocumentTransactionType,
                        ReceiptNumber = docRecord.ReceiptNumber,
                        StockAction = docRecord.StockAction,
                        StockActionID = docRecord.StockActionID.ToString(),
                        MKYSControlType = docRecord.MKYSStatus.Value,
                        BudgetTypeName = (MKYS_EButceTurEnum)docRecord.BudgeType,
                    }).ToList();
                }
                model.DocumentRecordLogGridListItem = documentRecordLogList;
                return model;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Gonderilemeyen_Islemler)]
        public MkysIntegrationViewModel SentToMkysForUnCompleted(QueryMkysDVO mkysdvo)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MkysIntegrationViewModel model = new MkysIntegrationViewModel();
                List<DocumentRecordLogGridItem> documentRecordLogList = new List<DocumentRecordLogGridItem>();
                foreach (DocumentRecordLogGridItem logItem in mkysdvo.mkysObject)
                {
                    var stockActionList = objectContext.QueryObjects("STOCKACTION", "OBJECTID = '" + logItem.StockAction + "'");
                    StockAction stockAction = (StockAction)stockActionList[0];
                    if (stockAction.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        if (logItem.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                        {
                            logItem.MKYSResultMsg = stockAction.SendMKYSForInputDocument(mkysdvo.MKYSUserPassword);
                        }
                        else
                        {
                            logItem.MKYSResultMsg = stockAction.SendMKYSForOutputDocument(mkysdvo.MKYSUserPassword);
                        }
                    }

                    if (logItem.MKYSResultMsg.Contains("Ayniyat Numarası ile MKYS'ye Bildirim Başarılı Kaydedilmiştir.") == true)
                    {
                        if(stockAction.DocumentRecordLogs.FirstOrDefault(x => x.ObjectID == logItem.ObjectID).ReceiptNumber != null)
                        {
                            logItem.ReceiptNumber = (int)stockAction.DocumentRecordLogs.FirstOrDefault(x => x.ObjectID == logItem.ObjectID).ReceiptNumber;
                        }
                    }
                    documentRecordLogList.Add(logItem);
                }

                model.DocumentRecordLogGridListItem = documentRecordLogList;
                return model;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi)]
        public MkysIntegrationViewModel CompateToMkys(QueryMkysCompareItem stockActionID)
        {
            return null;
        }

        private CompareTaskItem CompareMethod<T>(StockActionMkysCompareItem compareItem, string Subj, T MkysValue, T MyValue)
        {
            CompareTaskItem compareTaskItem = new CompareTaskItem();
            compareTaskItem.Subject = Subj.ToString();
            compareTaskItem.MkysValue = MkysValue.ToString();
            if (MyValue != null)
                compareTaskItem.MyValue = MyValue.ToString();
            else
                compareTaskItem.MyValue = "";
            if (EqualityComparer<T>.Default.Equals(MkysValue, MyValue))
            {
                compareTaskItem.Result = true;
                //compareItem.colorEnum = MkysCompareResultColorEnum.green;
            }
            else
            {
                compareTaskItem.Result = false;
                compareItem.colorEnum = MkysCompareResultColorEnum.red;
                compareItem.IsFaild = true;
            }

            return compareTaskItem;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Karsilastirma)]
        public MkysIntegrationViewModel CompareAllActionToMkys(QueryMkysActionAllCompare item)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MkysIntegrationViewModel model = new MkysIntegrationViewModel();
                List<StockActionMkysCompareItem> StockActionMkysCompareItems = new List<StockActionMkysCompareItem>();
                IBindingList stockActionList;
                if (String.IsNullOrEmpty(item.stockActionID))
                {
                    stockActionList = objectContext.QueryObjects("STOCKACTION", "TRANSACTIONDATE BETWEEN " + Globals.CreateNQLToDateParameter(item.startDate) + " AND " + Globals.CreateNQLToDateParameter(item.endDate) + " AND CURRENTSTATE IS SUCCESSFUL");
                }
                else
                {
                    stockActionList = objectContext.QueryObjects("STOCKACTION", "STOCKACTIONID = '" + item.stockActionID + "'");
                }

                if (stockActionList.Count > 0)
                {
                    foreach (StockAction stockaction in stockActionList)
                    {
                        if (stockaction.DocumentRecordLogs.Select(string.Empty).Count > 0)
                        {
                            foreach (DocumentRecordLog log in stockaction.DocumentRecordLogs.Select(string.Empty))
                            {
                                if (log.MKYSStatus == MKYSControlEnum.CompletedSent && log.ReceiptNumber != null)
                                {
                                    StockActionMkysCompareItem stockActionMkysCompareItem = new StockActionMkysCompareItem();
                                    stockActionMkysCompareItem.colorEnum = MkysCompareResultColorEnum.blue;
                                    stockActionMkysCompareItem.IsFaild = false;
                                    stockActionMkysCompareItem.StockActionID = stockaction.StockActionID.ToString();
                                    stockActionMkysCompareItem.StockActionName = stockaction.ObjectDef.DisplayText;
                                    stockActionMkysCompareItem.StockActionTransactionDate = (DateTime)stockaction.TransactionDate;
                                    List<StockActionDetailView> stockActionDetailViews = new List<StockActionDetailView>();
                                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                                    {
                                        if (stockaction.MKYS_GonderimTarihi != null)
                                        {
                                            List<MkysServis.girisMakbuzDetayItem> girisMakbuzDetayItems = MkysServis.WebMethods.makbuzDetayGetDataSync(Sites.SiteLocalHost, item.MKYSUserName, item.MKYSUserPassword, (int)log.ReceiptNumber, ((DateTime)stockaction.MKYS_GonderimTarihi).Year, (MkysServis.EButceTurID)(int)log.BudgeType.Value).ToList();
                                            if (girisMakbuzDetayItems.Count > 0)
                                            {
                                                foreach (MkysServis.girisMakbuzDetayItem girisItem in girisMakbuzDetayItems)
                                                {
                                                    foreach (StockActionDetail detailIn in stockaction.StockActionDetails)
                                                    {
                                                        foreach (var trans in detailIn.StockTransactions.Select(" INOUT = 1 "))
                                                        {
                                                            if (girisItem.stokHareketID == trans.MKYS_StokHareketID)
                                                            {
                                                                StockActionDetailView stockActionDetailIn = new StockActionDetailView();
                                                                stockActionDetailIn.AyniyatMakbuzID = (int)log.ReceiptNumber;
                                                                stockActionDetailIn.StokHareketID = (int)girisItem.stokHareketID;
                                                                stockActionDetailIn.Material = detailIn.Material.Name;
                                                                stockActionDetailIn.MalzemeKayitID = (int)girisItem.malzemeKayitID;
                                                                List<CompareTaskItem> compareTaskItems = new List<CompareTaskItem>();
                                                                if (stockaction is ReturningDocument)
                                                                {
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M26082", "İndirim Oranı"), girisItem.indirimOrani, 0));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, "KDV Oranı", girisItem.kdvOrani, 0));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19030", "Miktar"), girisItem.miktar, (decimal)((StockActionDetailOut)detailIn).Amount));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19908", "Ölçü Birimi"), girisItem.olcuBirimID.Trim(), ((StockActionDetailOut)detailIn).Material.StockCard.DistributionType.QRef.Trim()));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27165", "Ürün Barkodu"), girisItem.urunBarkodu, ((StockActionDetailOut)detailIn).Material.Barcode));
                                                                }
                                                                else if (stockaction is IExtendExpirationDate)
                                                                {
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M22057", "Son Kullanma Tarihi"), girisItem.sonKullanmaTarihi, ((ExtendExpirationDateDetail)detailIn).NewDateForExpiration));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19030", "Miktar"), girisItem.miktar, (decimal)((StockActionDetailOut)detailIn).Amount));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19908", "Ölçü Birimi"), girisItem.olcuBirimID.Trim(), ((StockActionDetailOut)detailIn).Material.StockCard.DistributionType.QRef.Trim()));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27165", "Ürün Barkodu"), girisItem.urunBarkodu, ((StockActionDetailOut)detailIn).Material.Barcode));
                                                                }
                                                                else if (stockaction is IMainStoreStockTransfer)
                                                                {
                                                                    //compareTaskItems.Add(CompareMethod("Son Kullanma Tarihi", girisItem.sonKullanmaTarihi, ((StockActionDetailOut)detailIn).NewDateForExpiration));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19030", "Miktar"), girisItem.miktar, (decimal)((StockActionDetailOut)detailIn).Amount));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19908", "Ölçü Birimi"), girisItem.olcuBirimID.Trim(), ((StockActionDetailOut)detailIn).Material.StockCard.DistributionType.QRef.Trim()));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27165", "Ürün Barkodu"), girisItem.urunBarkodu, ((StockActionDetailOut)detailIn).Material.Barcode));
                                                                }
                                                                else
                                                                {
                                                                    if (((StockActionDetailIn)detailIn).DiscountRate != null)
                                                                        compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M26082", "İndirim Oranı"), girisItem.indirimOrani, (decimal)((StockActionDetailIn)detailIn).DiscountRate));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, "KDV Oranı", girisItem.kdvOrani, (decimal)((StockActionDetailIn)detailIn).VatRate));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M22057", "Son Kullanma Tarihi"), girisItem.sonKullanmaTarihi, ((StockActionDetailIn)detailIn).ExpirationDate));
                                                                }

                                                                if (!(stockaction is IExtendExpirationDate) && !(stockaction is ReturningDocument) && !(stockaction is IMainStoreStockTransfer))
                                                                {
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19030", "Miktar"), girisItem.miktar, (decimal)((StockActionDetailIn)detailIn).Amount));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19908", "Ölçü Birimi"), girisItem.olcuBirimID.Trim(), ((StockActionDetailIn)detailIn).Material.StockCard.DistributionType.QRef.Trim()));
                                                                    compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27165", "Ürün Barkodu"), girisItem.urunBarkodu, ((StockActionDetailIn)detailIn).Material.Barcode));
                                                                }

                                                                stockActionDetailIn.CompareTaskItems = compareTaskItems;
                                                                stockActionDetailViews.Add(stockActionDetailIn);
                                                            }
                                                        }
                                                    }
                                                }

                                                stockActionMkysCompareItem.StockActionDetailViews = stockActionDetailViews;
                                            }
                                        }
                                    }

                                    if (log.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
                                    {
                                        List<MkysServis.cikisFisDetayItem> cikisFisDetayItems = MkysServis.WebMethods.cikisFisDetayGetDataSync(Sites.SiteLocalHost, item.MKYSUserName, item.MKYSUserPassword, (int)log.ReceiptNumber).ToList();
                                        if (cikisFisDetayItems.Count > 0)
                                        {
                                            foreach (MkysServis.cikisFisDetayItem cikisItem in cikisFisDetayItems)
                                            {
                                                foreach (StockActionDetail detailOut in stockaction.StockActionDetails)
                                                {
                                                    foreach (var trans in detailOut.StockTransactions.Select(" INOUT = 2"))
                                                    {
                                                        if (cikisItem.cikisStokHareketID == trans.MKYS_StokHareketID)
                                                        {
                                                            StockActionDetailView stockActionDetailOut = new StockActionDetailView();
                                                            stockActionDetailOut.AyniyatMakbuzID = (int)log.ReceiptNumber;
                                                            stockActionDetailOut.StokHareketID = (int)cikisItem.cikisStokHareketID;
                                                            stockActionDetailOut.Material = detailOut.Material.Name;
                                                            stockActionDetailOut.MalzemeKayitID = (int)cikisItem.malzemeKayitID;
                                                            List<CompareTaskItem> compareTaskItems = new List<CompareTaskItem>();
                                                            compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27165", "Ürün Barkodu"), cikisItem.barkod, ((StockActionDetailOut)detailOut).Material.Barcode));
                                                            compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19030", "Miktar"), cikisItem.miktar, trans.Amount));
                                                            compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M19908", "Ölçü Birimi"), cikisItem.olcuBirimID.Trim(), ((StockActionDetailOut)detailOut).Material.StockCard.DistributionType.QRef.Trim()));
                                                            compareTaskItems.Add(CompareMethod(stockActionMkysCompareItem, TTUtils.CultureService.GetText("M27188", "verigili Birim Fiyatı"), cikisItem.vergiliBirimFiyat, ((StockActionDetailOut)detailOut).UnitPrice));
                                                            stockActionDetailOut.CompareTaskItems = compareTaskItems;
                                                            stockActionDetailViews.Add(stockActionDetailOut);
                                                        }
                                                    }
                                                }
                                            }

                                            stockActionMkysCompareItem.StockActionDetailViews = stockActionDetailViews;
                                        }
                                    }

                                    StockActionMkysCompareItems.Add(stockActionMkysCompareItem);
                                }
                            }
                        }
                    }
                }

                model.StockActionMkysCompareItems = StockActionMkysCompareItems;
                return model;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Kurumlardan_Gelen_Belgeler)]
        public MkysIntegrationViewModel GetMkysTifByParamater(QueryMkysActionAllCompare input)
        {
            TTObjectContext context = new TTObjectContext(true);
            MkysIntegrationViewModel model = new MkysIntegrationViewModel();
            List<ReceivedDataFromMkys> dataSourceForMyView = new List<ReceivedDataFromMkys>();
            MkysServis.kurumlardanGelenDevirKriter kriter = new MkysServis.kurumlardanGelenDevirKriter();
            kriter.ambarlarArasiDeviriDeGetir = false;
            kriter.ilkTarih = input.startDate;
            kriter.sonTarih = input.endDate;

            List<TTObjectClasses.MkysServis.kurumlardanGelenDevirItem> items = MkysServis.WebMethods.kurumlardanGelenDevirlerGetDataSync(Sites.SiteLocalHost, input.MKYSUserName, input.MKYSUserPassword, kriter).ToList();
            if (items != null && items.Count > 0)
            {
                foreach (TTObjectClasses.MkysServis.kurumlardanGelenDevirItem inItem in items)
                {
                    if (inItem.turu == "C©" || inItem.turu == "CH" || inItem.turu == "CR" || inItem.turu == "CG" || inItem.turu == "C*" || inItem.turu == "C3" || inItem.turu == "C(") //mkyskod where kodadı = 'TASINIR_HAREKET_TURU';
                    {
                        bool addItemToMyList = true;
                        IBindingList existingChattelDocList = context.QueryObjects("CHATTELDOCUMENTINPUTWITHACCOUNTANCY", "ACTIONRECORDNO = '" + inItem.islemKayitNo.ToString() + "'");
                        if (existingChattelDocList.Count == 0)
                        {
                            addItemToMyList = true;
                        }
                        else
                        {
                            foreach (ChattelDocumentInputWithAccountancy cht in existingChattelDocList)
                            {
                                if (cht.CurrentStateDefID != ChattelDocumentInputWithAccountancy.States.Cancelled)
                                {
                                    addItemToMyList = false;
                                    break;
                                }
                            }
                        }

                        IBindingList mainStore = context.QueryObjects("MAINSTOREDEFINITION", "UNITRECORDNO = '" + inItem.gonderenBirimID + "'");
                        if (mainStore.Count > 0)
                        {
                            IBindingList existingChattelDocOutList = context.QueryObjects("CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", "STORE = '" + ((Store)mainStore[0]).ObjectID.ToString() + "'");
                            if (existingChattelDocOutList.Count == 0)
                            {
                                addItemToMyList = true;
                            }
                            else
                            {
                                addItemToMyList = false;
                            }
                        }

                        //if (inItem.devirGerceklestiMi != 1)
                        //{
                        if (addItemToMyList)
                        {
                            ReceivedDataFromMkys newReceivedData = new ReceivedDataFromMkys();
                            newReceivedData.kurumlardanGelenDevirItem = inItem;
                            newReceivedData.turu = inItem.turu;
                            newReceivedData.cikisBelgeNo = inItem.cikisBelgeNo;
                            newReceivedData.cikisBelgeTarihi = inItem.cikisBelgeTarihi;
                            newReceivedData.gonderenBirimAdi = inItem.gonderenBirimAdi;
                            newReceivedData.gonderenButceTuruAdi = inItem.gonderenButceTuruAdi;
                            newReceivedData.gonderenDepoAdi = inItem.gonderenDepoAdi;
                            newReceivedData.hareketTuru = inItem.hareketTuru;
                            newReceivedData.gonderenBirimID = inItem.gonderenBirimID;
                            newReceivedData.birimDepoID = inItem.birimDepoID;
                            newReceivedData.islemKayitNo = inItem.islemKayitNo;
                            newReceivedData.devirGerceklestiMi = inItem.devirGerceklestiMi;

                            List<TTObjectClasses.MkysServis.devirFisiItem> devirFisiItems = MkysServis.WebMethods.devirFisiGetSync(Sites.SiteLocalHost, input.MKYSUserName, input.MKYSUserPassword, (int)inItem.islemKayitNo).ToList();
                            newReceivedData.details = devirFisiItems;
                            dataSourceForMyView.Add(newReceivedData);
                        }
                        //}
                    }
                }
            }
            model.receivedDataSource = dataSourceForMyView;

            return model;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.MKYS_Entegrasyon_Yonetimi_Karsilastirma, TTRoleNames.Tasinir_Mal_Islemi_Giris_Kayit)]
        public string CreateChattelDocumentInputWithAccForSelecetedItem(InputFor_ChattelDocumentCreate input)
        {
            string ErrorMessage = string.Empty;
            string stockActionIds = string.Empty;

            try
            {
                TTObjectContext context = new TTObjectContext(false);
                foreach (ReceivedDataFromMkys item in input.SelectedReceivedDataItems)
                {
                    ChattelDocumentInputWithAccountancy chatDocument = new ChattelDocumentInputWithAccountancy(context);
                    chatDocument.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
                    IBindingList accountancyList = context.QueryObjects("ACCOUNTANCY", "ACCOUNTANCYCODE = '" + item.gonderenBirimID.ToString() + "'");
                    if (accountancyList.Count > 0)
                    {
                        chatDocument.Accountancy = (Accountancy)accountancyList[0];
                    }
                    else
                    {
                        Accountancy newAccountancy = new Accountancy(context);
                        newAccountancy.AccountancyCode = item.gonderenBirimID.ToString();
                        newAccountancy.AccountancyNO = item.gonderenBirimID.ToString();
                        newAccountancy.Address = "";
                        newAccountancy.Name = item.gonderenBirimAdi.ToUpper();
                        newAccountancy.QREF = item.gonderenBirimAdi.ToUpper().Substring(0, 5);
                        chatDocument.Accountancy = newAccountancy;
                        //ErrorMessage += " Geldiği yer için " + item.gonderenBirimID + " isimli birim kaydı sistemde bulunamamıştır.";
                    }

                    if (input.Store == null)
                    {
                        ErrorMessage += " Giriş Yapılacak Depo Seçilmemiştir. ";
                    }

                    if (!(input.Store is MainStoreDefinition))
                    {
                        ErrorMessage += " Giriş Yapılacak Depo Ana Depo Olmalıdır. ";
                    }

                    chatDocument.Store = input.Store;
                    chatDocument.IsEntryOldMaterial = true;
                    switch (item.turu)
                    {
                        case "CH":
                            chatDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.stokFazlasiDevir;
                            chatDocument.inputWithAccountancyType = TasinirMalGirisTurEnum.stokFazlasiDevir;
                            chatDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
                            break;
                        case "CR":
                            chatDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.bagliSaglikTsisisndenDevir;
                            chatDocument.inputWithAccountancyType = TasinirMalGirisTurEnum.bagliSaglikTesisindenDevir;
                            chatDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
                            break;
                        case "CG":
                            chatDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.ihtiyacFazlasiDevir;
                            chatDocument.inputWithAccountancyType = TasinirMalGirisTurEnum.ihtiyacFazlasiDevir;
                            chatDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
                            break;
                        case "C*":
                            chatDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.tedarikPaylasimDevirGiris;
                            chatDocument.inputWithAccountancyType = TasinirMalGirisTurEnum.tedarikPaylasimDevirGiris;
                            chatDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
                            break;
                        case "C©":
                            chatDocument.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.devirCovid19DevirAlinan;
                            chatDocument.inputWithAccountancyType = TasinirMalGirisTurEnum.devirCovid19DevirAlinan;
                            chatDocument.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
                            break;
                    }
                    chatDocument.Description = Common.RecTime().ToLongDateString() + " MKYS Kurumlardan Gelen Belgeler  İle Otomatik Oluşturulan Belge.";
                    chatDocument.Waybill = item.cikisBelgeNo.ToString();
                    chatDocument.WaybillDate = item.cikisBelgeTarihi;
                    chatDocument.ActionRecordNo = item.islemKayitNo;
                    if (item.gonderenButceTuruAdi.Contains("DÖNER") == true)
                    {
                        BudgetTypeDefinition budgetType = (BudgetTypeDefinition)context.GetObject(new Guid("3511171d-06ae-4434-ad44-3579ee616ecb"), TTObjectDefManager.Instance.ObjectDefs[typeof(BudgetTypeDefinition).Name], false);
                        chatDocument.BudgetTypeDefinition = budgetType;
                    }
                    else if (item.gonderenButceTuruAdi.Contains("GENEL") == true)
                    {
                        BudgetTypeDefinition budgetType = (BudgetTypeDefinition)context.GetObject(new Guid("57c410cc-afea-487a-8327-76e91a696a02"), TTObjectDefManager.Instance.ObjectDefs[typeof(BudgetTypeDefinition).Name], false);
                        chatDocument.BudgetTypeDefinition = budgetType;
                    }

                    else if (item.gonderenButceTuruAdi.Contains("SGK") == true)
                    {
                        BudgetTypeDefinition budgetType = (BudgetTypeDefinition)context.GetObject(new Guid("d899928c-9441-4959-86ea-d3696fc5c318"), TTObjectDefManager.Instance.ObjectDefs[typeof(BudgetTypeDefinition).Name], false);
                        chatDocument.BudgetTypeDefinition = budgetType;
                    }
                    else if (item.gonderenButceTuruAdi.Contains("ÖZEL") == true)
                    {
                        BudgetTypeDefinition budgetType = (BudgetTypeDefinition)context.GetObject(new Guid("e98339a1-2422-481d-8283-2bd92190b91a"), TTObjectDefManager.Instance.ObjectDefs[typeof(BudgetTypeDefinition).Name], false);
                        chatDocument.BudgetTypeDefinition = budgetType;
                    }
                    else if (item.gonderenButceTuruAdi.Contains("YURTDIŞI") == true)
                    {
                        BudgetTypeDefinition budgetType = (BudgetTypeDefinition)context.GetObject(new Guid("f23e83e7-e638-4519-a543-a6520758b100"), TTObjectDefManager.Instance.ObjectDefs[typeof(BudgetTypeDefinition).Name], false);
                        chatDocument.BudgetTypeDefinition = budgetType;
                    }
                    else
                    {
                        ErrorMessage += " Bütçe türü için " + item.gonderenButceTuruAdi + " isimli bütçe türü sistemde bulunamamıştır.";
                    }
                    chatDocument.MKYS_TeslimEden = item.gonderenBirimAdi;

                    foreach (MkysServis.devirFisiItem detItem in item.details)
                    {
                        ChattelDocumentInputDetailWithAccountancy chatDetIn = new ChattelDocumentInputDetailWithAccountancy(context);
                        chatDetIn.StockAction = chatDocument;
                        chatDetIn.MKYS_CikisStokHareketID = detItem.cikisStokHareketID;//taşınır girişi yaratırken kurumdan gelen çıkış numarsı için yaratıldı.

                        IBindingList mat = null;

                        if (!String.IsNullOrEmpty(detItem.urunBarkodu))
                        {
                            mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + detItem.urunBarkodu + "' AND MKYSMALZEMEKODU ='" + detItem.malzemeKayitID + "'"); //ISACTIVE ÖZELLİĞİ VERİ BOZUK OLDUGUNDAN KOYULDU KALDIRILACAK.
                            if (mat.Count == 0)
                            {
                                mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + detItem.urunBarkodu + "'");
                            }
                        }
                        else
                            mat = context.QueryObjects("MATERIAL", "ISACTIVE = 1 AND  MKYSMALZEMEKODU ='" + detItem.malzemeKayitID + "'");
                        if (mat.Count == 1)
                        {
                            Material material = (Material)mat[0];
                            if (material is DrugDefinition)
                            {
                                chatDocument.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.ilac;
                            }
                            else if (material is ConsumableMaterialDefinition)
                            {
                                chatDocument.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.tibbiSarf;
                            }
                            else if (material is FixedAssetDefinition)
                            {
                                chatDocument.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.tibbiCihaz;
                            }
                            else
                            {
                                chatDocument.MKYS_EMalzemeGrup = MKYS_EMalzemeGrupEnum.diger;
                            }

                            if (chatDocument.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac || chatDocument.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                            {
                                chatDetIn.Material = material;
                                chatDetIn.SentAmount = detItem.miktar;
                                chatDetIn.Amount = detItem.miktar;
                                chatDetIn.NotDiscountedUnitPrice = detItem.vergiliBirimFiyat;
                                chatDetIn.DiscountRate = 0;
                                chatDetIn.ConflictSubject = "0";
                                chatDetIn.ProductionDate = detItem.uretimTarihi;
                                chatDetIn.ExpirationDate = detItem.sonKullanmaTarihi;
                                chatDetIn.RetrievalYear = detItem.edinmeYili;
                                chatDetIn.StockLevelType = StockLevelType.NewStockLevel;
                                chatDetIn.CalculatePrices();
                            }
                            else
                            {
                                ErrorMessage += chatDocument.MKYS_EMalzemeGrup.ToString() + " türündeki malzemenin sisteme giriş izni yoktur.";
                            }
                        }
                        else
                        {
                            ErrorMessage += detItem.malzemeKayitID + " kayıt idli " + detItem.malzemeAdi + " isimli malzeme sistemde bulunamamıştır.";
                        }
                    }
                    stockActionIds += " - " + chatDocument.StockActionID.ToString();
                }
                if (string.IsNullOrEmpty(ErrorMessage))
                {
                    ErrorMessage = " İşlemler başarılı şekilde tamamlandı." + stockActionIds + TTUtils.CultureService.GetText("M25040", ".İşlem numaralı listeden kontrol ediniz.");
                    context.Save();
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26244", "İşlemler başarılı şekilde tamamlandı. İş listesini kontrol ediniz."));
                }
                else
                    throw new TTException(ErrorMessage);
            }
            catch (Exception exp)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(exp.ToString());
            }
            return ErrorMessage;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yilsonu_Devir_Islemi_Kayit, TTRoleNames.Yilsonu_Devir_Islemi_Onay, TTRoleNames.Yilsonu_Devir_Islemi_Tamam)]
        public List<MkysServis.yonetimHesabiCetveliItem> GetMkysEndOfYear(EndOfYearItem item)
        {
            int butceYili = Int32.Parse(item.year);
            var store = item.store as MainStoreDefinition;

            if (!store.StoreRecordNo.HasValue)
            {
                var message = string.Format("Depo kayıt numarası belirtilmemiş. {0}", store.Name);
                throw new TTException(store.Name + " " + message);
            }

            /*MkysServis.yilSonuDevriItem yilSonuDevriItem = new MkysServis.yilSonuDevriItem();
            yilSonuDevriItem.birimDepoID = (int)store.StoreRecordNo;
            yilSonuDevriItem.butceYili = butceYili;
            MkysServis.yilSonuDevriSonucItem[] sonucItems = MkysServis.WebMethods.yilSonuDevirDetayBilgileriSync(Sites.SiteLocalHost, yilSonuDevriItem);
            */

            MkysServis.yonetimHesabiKriter yon = new MkysServis.yonetimHesabiKriter();
            yon.depoKayitNo = (int)store.StoreRecordNo;
            yon.butceYili = butceYili;
            yon.tasinirKodu = "150-03-01-8699525750495";
            yon.butceTuru = "B";
            MkysServis.yonetimHesabiCetveliItem[] sonucItems1 = MkysServis.WebMethods.yonetimHesabiCetveliGetDataSync(Sites.SiteLocalHost, item.MKYSUserName, item.MKYSUserPassword, yon);
            return sonucItems1.ToList();

        }


        public class GetYilSonuDevir_Output
        {
            public int malzemeKayitID
            {
                get;
                set;
            }

            public string malzemeAdi
            {
                get;
                set;
            }

            public string malzemeKodu
            {
                get;
                set;
            }
            public decimal toplamGiren
            {
                get;
                set;
            }
            public decimal toplamGirenTutar
            {
                get;
                set;
            }
            public decimal toplamCikan
            {
                get;
                set;
            }
            public decimal toplamCikanTutar
            {
                get;
                set;
            }
            public decimal miktar
            {
                get;
                set;
            }

            public decimal atlasMiktar
            {
                get;
                set;
            }

            public string hata
            {
                get;
                set;
            }

            public List<MkysServis.stokHareketYilSonuItem> stokHaraketYilSonuItems
            {
                get;
                set;
            }
            public string MKYSUserName
            {
                get;
                set;
            }
            public string MKYSUserPassword
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yilsonu_Devir_Islemi_Kayit, TTRoleNames.Yilsonu_Devir_Islemi_Onay, TTRoleNames.Yilsonu_Devir_Islemi_Tamam)]
        public List<GetYilSonuDevir_Output> GetYilSonuDevir(EndOfYearItem item)
        {
            int butceYili = Int32.Parse(item.year);
            var store = item.store as MainStoreDefinition;
            if (store == null)
            {
                throw new TTException("İşlem Yaptığınız Depo Ana Depo Değildir!!!");

            }

            if (!store.StoreRecordNo.HasValue)
            {
                var message = string.Format("Depo kayıt numarası belirtilmemiş. {0}", store.Name);
                throw new TTException(store.Name + " " + message);
            }

            TTObjectContext readOnyContext = new TTObjectContext(true);
            Store stx = (Store)readOnyContext.GetObject(store.ObjectID, typeof(Store));
            AccountingTerm termcont = ((MainStoreDefinition)stx).Accountancy.AccountingTerms.Where(t => t.Status == AccountingTermStatusEnum.HalfOpen).FirstOrDefault();
            if (termcont == null)
            {
                throw new TTException(store.Name + " deposu için yarı açık dönem bulunamamıştır.");
            }

            MkysServis.yilSonuKriter kr = new MkysServis.yilSonuKriter();
            kr.butceYili = butceYili;
            //kr.butceTuru = "B";
            kr.tasinirKodu = "%";
            kr.depoKayitNo = (int)store.StoreRecordNo;
            MkysServis.stokHareketYilSonuItem[] sonucItemsB = MkysServis.WebMethods.stokDurumGetDataSync(Sites.SiteLocalHost, kr);

            //MkysServis.yilSonuKriter kr2 = new MkysServis.yilSonuKriter();
            //kr2.butceYili = butceYili;
            ////kr2.butceTuru = "D";
            //kr2.tasinirKodu = "%";
            //kr2.depoKayitNo = (int)store.StoreRecordNo;
            //MkysServis.stokHareketYilSonuItem[] sonucItemsD = MkysServis.WebMethods.stokDurumGetDataSync(Sites.SiteLocalHost, kr2);

            //MkysServis.yilSonuKriter kr3 = new MkysServis.yilSonuKriter();
            //kr2.butceYili = butceYili;
            ////kr2.butceTuru = "S";
            //kr2.tasinirKodu = "%";
            //kr2.depoKayitNo = (int)store.StoreRecordNo;
            //MkysServis.stokHareketYilSonuItem[] sonucItemsS = MkysServis.WebMethods.stokDurumGetDataSync(Sites.SiteLocalHost, kr3);


            Dictionary<int, List<MkysServis.stokHareketYilSonuItem>> censusDic = new Dictionary<int, List<MkysServis.stokHareketYilSonuItem>>();

            foreach (MkysServis.stokHareketYilSonuItem bItem in sonucItemsB)
            {
                if (censusDic.ContainsKey((int)bItem.malzemeKayitID))
                {
                    censusDic[(int)bItem.malzemeKayitID].Add(bItem);
                }
                else
                {
                    List<MkysServis.stokHareketYilSonuItem> bList = new List<MkysServis.stokHareketYilSonuItem>();
                    bList.Add(bItem);
                    censusDic.Add((int)bItem.malzemeKayitID, bList);
                }
            }

            //foreach (MkysServis.stokHareketYilSonuItem dItem in sonucItemsD)
            //{
            //    if (censusDic.ContainsKey((int)dItem.malzemeKayitID))
            //    {
            //        censusDic[(int)dItem.malzemeKayitID].Add(dItem);
            //    }
            //    else
            //    {
            //        List<MkysServis.stokHareketYilSonuItem> dList = new List<MkysServis.stokHareketYilSonuItem>();
            //        dList.Add(dItem);
            //        censusDic.Add((int)dItem.malzemeKayitID, dList);
            //    }
            //}

            //foreach (MkysServis.stokHareketYilSonuItem sItem in sonucItemsS)
            //{
            //    if (censusDic.ContainsKey((int)sItem.malzemeKayitID))
            //    {
            //        censusDic[(int)sItem.malzemeKayitID].Add(sItem);
            //    }
            //    else
            //    {
            //        List<MkysServis.stokHareketYilSonuItem> bList = new List<MkysServis.stokHareketYilSonuItem>();
            //        bList.Add(sItem);
            //        censusDic.Add((int)sItem.malzemeKayitID, bList);
            //    }
            //}

            List<GetYilSonuDevir_Output> censusList = new List<GetYilSonuDevir_Output>();

            foreach (KeyValuePair<int, List<MkysServis.stokHareketYilSonuItem>> dicItem in censusDic)
            {
                GetYilSonuDevir_Output output = new GetYilSonuDevir_Output();
                output.malzemeKayitID = (int)dicItem.Value[0].malzemeKayitID;
                output.malzemeAdi = dicItem.Value[0].malzemeAdi;
                output.malzemeKodu = dicItem.Value[0].malzemeKodu;
                output.atlasMiktar = 0;
                output.stokHaraketYilSonuItems = new List<MkysServis.stokHareketYilSonuItem>();
                foreach (MkysServis.stokHareketYilSonuItem d in dicItem.Value)
                {
                    output.miktar += (decimal)d.depodakiMiktar;
                    output.stokHaraketYilSonuItems.Add(d);
                }

                TTObjectContext context = new TTObjectContext(false);
                IBindingList materials = context.QueryObjects("MATERIAL", "MKYSMALZEMEKODU =" + output.malzemeKayitID.ToString());
                if (materials.Count != 0)
                {
                    foreach (Material material in materials)
                    {
                        Stock censusStock = material.Stocks.Select("STORE=" + TTConnectionManager.ConnectionManager.GuidToString(store.ObjectID)).FirstOrDefault();
                        if (censusStock != null)
                        {
                            Store s = (Store)context.GetObject(store.ObjectID, typeof(Store));
                            AccountingTerm term = ((MainStoreDefinition)s).Accountancy.AccountingTerms.Where(t => t.Status == AccountingTermStatusEnum.HalfOpen).FirstOrDefault();
                            IList stockTransactions = StockTransaction.GetStockTransactionsByAccountingTermOrderInOut(context, term.ObjectID, censusStock.ObjectID);
                            Stock stockcen = new Stock(context, store, material);
                            AccountingTerm previousTerm = term.PrevTerm;
                            if (previousTerm != null)
                            {
                                IBindingList prevCensusDetail = StockCensusDetail.GetCensusDetail(context, previousTerm.ObjectID, censusStock.ObjectID);
                                if (prevCensusDetail.Count > 0)
                                {
                                    stockcen.Inheld = ((StockCensusDetail)prevCensusDetail[0]).Inheld;
                                    stockcen.Consigned = ((StockCensusDetail)prevCensusDetail[0]).Consigned;
                                    stockcen.TotalIn = ((StockCensusDetail)prevCensusDetail[0]).TotalIn;
                                    stockcen.TotalInPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalInPrice;
                                    stockcen.TotalOut = ((StockCensusDetail)prevCensusDetail[0]).TotalOut;
                                    stockcen.TotalOutPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalOutPrice;
                                    foreach (StockCensusLevel cLevel in ((StockCensusDetail)prevCensusDetail[0]).StockCensusLevels)
                                    {
                                        StockLevel level = new StockLevel(context);
                                        level.Amount = cLevel.Amount;
                                        level.StockLevelType = cLevel.StockLevelType;
                                        level.Stock = stockcen;
                                    }
                                }
                            }

                            string errmsg = string.Empty;
                            foreach (StockTransaction stockTransaction in stockTransactions)
                            {
                                try
                                {
                                    stockcen.StockFieldsUpdate(stockTransaction, false, true);
                                }
                                catch (Exception ex)
                                {
                                    //err = true;
                                    errmsg = errmsg + stockcen.Material.StockCard.NATOStockNO + " " + stockcen.Material.Name + " " + ex.ToString() + "\r\n";
                                }
                            }
                            output.atlasMiktar += (decimal)stockcen.Inheld;
                        }
                    }
                }
                if (output.atlasMiktar != output.miktar)
                    output.hata = "Hatalı Mevcut";
                else
                    output.hata = "OK";

                censusList.Add(output);
            }
            return censusList;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yilsonu_Devir_Islemi_Kayit, TTRoleNames.Yilsonu_Devir_Islemi_Onay, TTRoleNames.Yilsonu_Devir_Islemi_Tamam)]
        public List<OutputMyStock> GetStockCard(EndOfYearItem item)
        {
            int butceYili = Int32.Parse(item.year);
            var store = item.store as MainStoreDefinition;

            if (!store.StoreRecordNo.HasValue)
            {
                var message = string.Format("Depo kayıt numarası belirtilmemiş. {0}", store.Name);
                throw new TTException(store.Name + " " + message);
            }
            List<OutputMyStock> returnList = new List<OutputMyStock>();
            TTObjectContext context = new TTObjectContext(false);

            BindingList<Stock.GetStockForStore_Class> stockList = Stock.GetStockForStore(store.ObjectID.ToString());
            foreach (Stock.GetStockForStore_Class stock in stockList)
            {
                OutputMyStock outputMyStock = new OutputMyStock();
                outputMyStock.malzemeAdi = stock.Stockcardname;
                outputMyStock.tasinirKod = stock.Stockcardnsn;
                outputMyStock.mevcut = stock.Toplammiktar.ToString();
                outputMyStock.stockcardObj = stock.Stockcardobjectid.ToString();
                outputMyStock.depoObjID = item.store.ObjectID.ToString();
                outputMyStock.calcInheld = 0;
                outputMyStock.calcTotalIn = 0;
                outputMyStock.calcTotalInPrice = 0;
                outputMyStock.calcTotalOut = 0;
                outputMyStock.calcTotalOutPrice = 0;
                returnList.Add(outputMyStock);
            }

            return returnList;
        }


        public class StockCensusForAtlas_Input
        {
            public List<GetYilSonuDevir_Output> stokHaraketYilSonuItems;
            public Store store;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Yilsonu_Devir_Islemi_Kayit, TTRoleNames.Yilsonu_Devir_Islemi_Onay, TTRoleNames.Yilsonu_Devir_Islemi_Tamam)]
        public string StockCensusForAtlasClick(StockCensusForAtlas_Input item)
        {
            string returnMessage = string.Empty;
            string errmsg = string.Empty;
            TTObjectContext context = new TTObjectContext(false);
            Store store = (Store)context.GetObject(item.store.ObjectID, typeof(Store));
            AccountingTerm term = ((MainStoreDefinition)store).Accountancy.AccountingTerms.Where(t => t.Status == AccountingTermStatusEnum.HalfOpen).FirstOrDefault();
            StockCensus stockCensus = new StockCensus(context);

            stockCensus.AccountingTerm = term;
            stockCensus.Store = (MainStoreDefinition)store;
            foreach (Stock s in store.Stocks.Select(string.Empty))
            {
                IList stockTransactions = StockTransaction.GetStockTransactionsByAccountingTermOrderInOut(context, term.ObjectID, s.ObjectID);
                TTObjectContext dumyContext = new TTObjectContext(false);
                Stock stockcen = new Stock(dumyContext, store, s.Material);

                AccountingTerm previousTerm = term.PrevTerm;
                if (previousTerm != null)
                {
                    IBindingList prevCensusDetail = StockCensusDetail.GetCensusDetail(dumyContext, previousTerm.ObjectID, s.ObjectID);
                    if (prevCensusDetail.Count > 0)
                    {
                        stockcen.Inheld = ((StockCensusDetail)prevCensusDetail[0]).Inheld;
                        stockcen.Consigned = ((StockCensusDetail)prevCensusDetail[0]).Consigned;
                        stockcen.TotalIn = ((StockCensusDetail)prevCensusDetail[0]).TotalIn;
                        stockcen.TotalInPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalInPrice;
                        stockcen.TotalOut = ((StockCensusDetail)prevCensusDetail[0]).TotalOut;
                        stockcen.TotalOutPrice = ((StockCensusDetail)prevCensusDetail[0]).TotalOutPrice;
                        foreach (StockCensusLevel cLevel in ((StockCensusDetail)prevCensusDetail[0]).StockCensusLevels)
                        {
                            StockLevel level = new StockLevel(dumyContext);
                            level.Amount = cLevel.Amount;
                            level.StockLevelType = cLevel.StockLevelType;
                            level.Stock = stockcen;
                        }
                    }
                }

                foreach (StockTransaction stockTransaction in stockTransactions)
                {
                    try
                    {
                        stockcen.StockFieldsUpdate(stockTransaction, false, true);
                    }
                    catch (Exception ex)
                    {
                        errmsg = errmsg + stockcen.Material.StockCard.NATOStockNO + " " + stockcen.Material.Name + " " + ex.ToString() + "\r\n";
                    }
                }
                StockCensusDetail stockCensusDetail = new StockCensusDetail(context);
                stockCensusDetail.StockCensus = stockCensus;
                stockCensusDetail.Stock = s;
                stockCensusDetail.StockCard = s.Material.StockCard;
                stockCensusDetail.TotalIn = stockcen.TotalIn;
                stockCensusDetail.Consigned = stockcen.Consigned;
                stockCensusDetail.CardOrderNo = 0;
                stockCensusDetail.TotalIn = stockcen.TotalIn;
                stockCensusDetail.TotalOut = stockcen.TotalOut;
                stockCensusDetail.TotalInPrice = stockcen.TotalInPrice;
                stockCensusDetail.TotalOutPrice = stockcen.TotalOutPrice;
                stockCensusDetail.Inheld = stockcen.Inheld;
                stockCensusDetail.TotalInHeld = stockcen.Inheld + stockcen.Consigned;
                stockCensusDetail.YearCensus = 0;
                stockCensusDetail.Used = 0;
                stockCensusDetail.AccountingTerm = term;
                foreach (StockLevel levels in stockcen.StockLevels)
                {
                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.New)
                    {
                        StockCensusLevel censusLevel = null;
                        censusLevel = new StockCensusLevel(context);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.NewStockLevel;
                        censusLevel.StockCensusDetail = stockCensusDetail;
                    }
                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Used)
                    {
                        StockCensusLevel censusLevel = null;
                        censusLevel = new StockCensusLevel(context);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.UsedStockLevel;
                        censusLevel.StockCensusDetail = stockCensusDetail;
                        stockCensusDetail.Used = levels.Amount;
                    }
                    if (levels.StockLevelType.StockLevelTypeStatus == StockLevelTypeEnum.Hek)
                    {
                        StockCensusLevel censusLevel = null;
                        censusLevel = new StockCensusLevel(context);
                        censusLevel.Amount = levels.Amount;
                        censusLevel.StockLevelType = StockLevelType.HekStockLevel;
                        censusLevel.StockCensusDetail = stockCensusDetail;
                    }
                }
                dumyContext.Dispose();
            }

            foreach (GetYilSonuDevir_Output devitItem in item.stokHaraketYilSonuItems)
            {
                string currentState = StockTransaction.States.Completed.ToString();
                foreach (MkysServis.stokHareketYilSonuItem devirItemDetail in devitItem.stokHaraketYilSonuItems)
                {
                    IBindingList stocktransactionList = context.QueryObjects("STOCKTRANSACTION", " INOUT ='1' AND MKYS_STOKHAREKETID='" + devirItemDetail.girisStokHareketID.ToString() + "' AND CURRENTSTATEDEFID ='" + currentState + "'");
                    foreach (StockTransaction st in stocktransactionList)
                    {
                        if (st.Stock.Store == store)
                        {
                            MkysCensusSyncData mkysCensusSyncData = new MkysCensusSyncData(context);
                            mkysCensusSyncData.StockCensus = stockCensus;
                            mkysCensusSyncData.StockTransactionGuid = st.ObjectID;
                            mkysCensusSyncData.StockGuid = st.Stock.ObjectID;
                            mkysCensusSyncData.EskiBirimFiyat = st.UnitPrice;
                            mkysCensusSyncData.YeniBirimFiyat = devirItemDetail.vergiliBirimFiyat;
                            mkysCensusSyncData.EskiStokHareketId = st.MKYS_StokHareketID;
                            mkysCensusSyncData.YeniStokHareketId = devirItemDetail.stokHareketID;
                        }
                    }
                }
            }

            try
            {
                stockCensus.CurrentStateDefID = StockCensus.States.New;
                context.Update();
                stockCensus.CurrentStateDefID = StockCensus.States.Approval;
                context.Update();
                stockCensus.CurrentStateDefID = StockCensus.States.Completed;
                context.Save();
                returnMessage = TTUtils.CultureService.GetText("M26173", "İşlem Başarılı Bir Şekilde Tamamlanmıştır.");
                return returnMessage;
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message;
                throw new TTException(TTUtils.CultureService.GetText("M25900", "Hatalı işlem") + returnMessage);
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}