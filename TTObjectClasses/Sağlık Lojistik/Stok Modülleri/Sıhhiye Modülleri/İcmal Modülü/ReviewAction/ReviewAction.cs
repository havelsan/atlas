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
    /// İcmal 
    /// </summary>
    public partial class ReviewAction : StockAction, IAutoDocumentRecordLog
    {
        #region Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReviewAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReviewAction.States.Approval && toState == ReviewAction.States.Cancelled)
                PreTransition_Approval2Cancelled();

            if (fromState == ReviewAction.States.Completed && toState == ReviewAction.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReviewAction).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
        }

        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
            #region PreTransition_Approval2Cancelled
            DeleteReviewActionCollettedtrx((DateTime)StartDate, (DateTime)EndDate, this);
            #endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Coompleted   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            string SonucMesaj = "";

            DeleteReviewActionCollettedtrx((DateTime)StartDate, (DateTime)EndDate, this);

            if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
            {
                foreach (DocumentRecordLog log in DocumentRecordLogs)
                {
                    if (log.ReceiptNumber != null)
                    {
                        log.MKYSStatus = MKYSControlEnum.Cancelled;
                        MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.cikisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, (int)log.ReceiptNumber);
                        SonucMesaj = makbuzSilmeSonuc.mesaj;
                        if (makbuzSilmeSonuc.basariDurumu == true)
                        {
                            SonucMesaj += "MKYSden " + log.ReceiptNumber + " nolu Ayniyat Makbuzu Silinmiştir. ";
                            log.MKYSStatus = MKYSControlEnum.CancelledSent;
                        }
                        else
                            throw new TTException("MKYSden " + log.ReceiptNumber + " nolu Ayniyat Makbuzu Silinememiştir!");
                    }
                }
            }
            else
            {
                foreach (DocumentRecordLog log in DocumentRecordLogs)
                {
                    log.MKYSStatus = MKYSControlEnum.Cancelled;
                }
            }
            #endregion PreTransition_Completed2Cancelled
        }

        public void DeleteReviewActionCollettedtrx(DateTime startdate, DateTime enddate, ReviewAction reviweAction)
        {
            BindingList<StockCollectedTrx.GetStocktrxbyStockAction_Class> list = StockCollectedTrx.GetStocktrxbyStockAction(reviweAction.ObjectID);
            if (list.Count > 0)
            {
                foreach (StockCollectedTrx.GetStocktrxbyStockAction_Class colTrx in list)
                {
                    StockCollectedTrx item = (StockCollectedTrx)reviweAction.ObjectContext.GetObject((Guid)colTrx.ObjectID, typeof(StockCollectedTrx).Name);
                    ((ITTObject)item).Delete();
                }
            }
        }
        public class ReviewActionService_Output
        {
            public List<ReviewActionDetail> ReviewActionDetails { get; set; }
            public List<ReviewActionPatientDet> ReviewActionPatientDets { get; set; }
            public List<StockCollectedTrx> StockCollectedTrxs { get; set; }
            public string filterDescription { get; set; }
        }

        public static ReviewAction.ReviewActionService_Output GetDrugOrder(DateTime startdate, DateTime enddate, ReviewAction reviweAction, List<Store> filterStore, List<BudgetTypeDefinition> filterBudgetTypeDefinition)
        {
            ReviewAction.ReviewActionService_Output reviewActionService_Output = new ReviewAction.ReviewActionService_Output();
            List<StockCollectedTrx> collTrxs = new List<StockCollectedTrx>();

            Dictionary<Patient, Dictionary<Material, double>> patientDic = new Dictionary<Patient, Dictionary<Material, double>>();

            if (reviweAction.ReviewActionType == null)
                reviweAction.ReviewActionType = ReviewActionTypeEnum.Kschedule;

            StockTransactionDefinition stockTransactionDefinition = null;
            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.Kschedule)
                stockTransactionDefinition = (StockTransactionDefinition)reviweAction.ObjectContext.GetObject(new Guid("f8155e0a-8527-4886-89b8-3aa7c25bc267"), "STOCKTRANSACTIONDEFINITION");

            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.PatientSpecial)
                stockTransactionDefinition = (StockTransactionDefinition)reviweAction.ObjectContext.GetObject(new Guid("b8690f41-827d-413b-aa46-d971e3d6638e"), "STOCKTRANSACTIONDEFINITION");



            //BindingList<StockTransaction> stockTransactions = StockTransaction.GetStockTransactionFromReviewAction(reviweAction.ObjectContext, enddate, startdate, stockTransactionDefinition.ObjectID);
            BindingList<StockTransaction.GetStockTransactionFromReviewActionRQ_Class> stockTransactions = StockTransaction.GetStockTransactionFromReviewActionRQ(reviweAction.ObjectContext, enddate, startdate, stockTransactionDefinition.ObjectID, reviweAction.Store.ObjectID);


            if (stockTransactions != null)
            {
                foreach (StockTransaction.GetStockTransactionFromReviewActionRQ_Class stockTransactionRQ in stockTransactions)
                {
                    IList stockCollectedTrxs = reviweAction.ObjectContext.QueryObjects(typeof(StockCollectedTrx).Name, "STOCKTRANSACTION = " + ConnectionManager.GuidToString((Guid)stockTransactionRQ.ObjectID));
                    if (stockCollectedTrxs.Count > 0)
                        continue;

                    StockTransaction stockTransaction = (StockTransaction)reviweAction.ObjectContext.GetObject((Guid)stockTransactionRQ.ObjectID, typeof(StockTransaction).Name);
                    Store destinationStore = null;
                    if (reviweAction.ReviewActionType == ReviewActionTypeEnum.Kschedule)
                        destinationStore = stockTransaction.StockActionDetail.StockAction.DestinationStore;
                    if (reviweAction.ReviewActionType == ReviewActionTypeEnum.PatientSpecial)
                        destinationStore = stockTransaction.StockActionDetail.SubActionMaterial[0].EpisodeAction.MasterResource.Store;


                    if (filterStore.Contains(destinationStore) && filterBudgetTypeDefinition.Contains(stockTransaction.BudgetTypeDefinition))
                    {
                        StockTransaction inTrx = null;
                        foreach (StockTransactionDetail trxDetail in stockTransaction.OutStockTransactionDetails)
                        {
                            if (trxDetail.InStockTransaction.CurrentStateDefID == StockTransaction.States.Completed && trxDetail.InStockTransaction.InOut == TransactionTypeEnum.In)
                                inTrx = trxDetail.InStockTransaction;
                        }
                        if (inTrx == null)
                            throw new TTException("Bilgi işleme haber verin");

                        Guid storeID = destinationStore.ObjectID;
                        ReviewActionDetail existDetails = reviweAction.ReviewActionDetails.Where(t => t.Material.ObjectID == stockTransaction.Stock.Material.ObjectID
                                                            && t.StoreObjID == storeID
                                                            && t.MKYS_StokHareketID == inTrx.MKYS_StokHareketID
                                                            && t.BudgetTypeDefinition == stockTransaction.BudgetTypeDefinition).FirstOrDefault();

                        ReviewActionDetail reviewActionDetail = null;
                        if (existDetails != null)
                        {
                            reviewActionDetail = existDetails;
                            reviewActionDetail.Amount += stockTransaction.Amount;
                        }
                        else
                        {
                            reviewActionDetail = reviweAction.ReviewActionDetails.AddNew();
                            reviewActionDetail.Amount = stockTransaction.Amount;
                            reviewActionDetail.Material = stockTransaction.Stock.Material;
                            reviewActionDetail.StockLevelType = stockTransaction.StockLevelType;
                            reviewActionDetail.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;
                            reviewActionDetail.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                            reviewActionDetail.StockTranactionGuid = stockTransaction.ObjectID;
                            reviewActionDetail.StoreObjID = storeID;

                            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.Kschedule)
                                reviewActionDetail.StoreName = stockTransaction.StockActionDetail.StockAction.DestinationStore.Name;
                            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.PatientSpecial)
                                reviewActionDetail.StoreName = stockTransaction.StockActionDetail.SubActionMaterial[0].EpisodeAction.MasterResource.Store.Name;

                            reviewActionDetail.MKYS_StokHareketID = inTrx.MKYS_StokHareketID;
                            reviewActionDetail.BudgetTypeDefinition = stockTransaction.BudgetTypeDefinition;
                            reviewActionDetail.UnitPrice = stockTransaction.UnitPrice;
                        }

                        StockCollectedTrx stockCollectedTrx = reviewActionDetail.StockCollectedTrxs.AddNew();
                        stockCollectedTrx.StockTransaction = stockTransaction;
                        collTrxs.Add(stockCollectedTrx);

                        Patient p = null;
                        if (reviweAction.ReviewActionType == ReviewActionTypeEnum.Kschedule)
                            p = ((KSchedule)stockTransaction.StockActionDetail.StockAction).Episode.Patient;
                        if (reviweAction.ReviewActionType == ReviewActionTypeEnum.PatientSpecial)
                            p = stockTransaction.StockActionDetail.SubActionMaterial[0].Episode.Patient;

                        ReviewActionPatientDet existPatientDetails = reviweAction.ReviewActionPatientDets.Where(t => t.MaterialObjID == stockTransaction.Stock.Material.ObjectID
                                && t.PatientObjID == p.ObjectID).FirstOrDefault();

                        ReviewActionPatientDet reviewActionPatientDet = null;
                        if (existPatientDetails != null)
                        {
                            reviewActionPatientDet = existPatientDetails;
                            reviewActionPatientDet.Amount += stockTransaction.Amount;
                        }
                        else
                        {
                            reviewActionPatientDet = reviweAction.ReviewActionPatientDets.AddNew();
                            reviewActionPatientDet.Amount = stockTransaction.Amount;
                            reviewActionPatientDet.MaterialName = stockTransaction.Stock.Material.Name;
                            reviewActionPatientDet.MaterialObjID = stockTransaction.Stock.Material.ObjectID;
                            reviewActionPatientDet.Patient = p.FullName;

                            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.Kschedule)
                                reviewActionPatientDet.Clinic = ((KSchedule)stockTransaction.StockActionDetail.StockAction).DestinationStore.Name;
                            if (reviweAction.ReviewActionType == ReviewActionTypeEnum.PatientSpecial)
                                reviewActionPatientDet.Clinic = stockTransaction.StockActionDetail.SubActionMaterial[0].EpisodeAction.MasterResource.Name;

                            reviewActionPatientDet.UniqueRefNo = p.UniqueRefNo;
                        }

                    }
                }
            }
            reviewActionService_Output.ReviewActionDetails = reviweAction.ReviewActionDetails.ToList();
            reviewActionService_Output.ReviewActionPatientDets = reviweAction.ReviewActionPatientDets.ToList();
            reviewActionService_Output.StockCollectedTrxs = collTrxs;
            string filterStoreDescription = "Depolar: ";
            foreach (Store store in filterStore)
                filterStoreDescription = filterStoreDescription + store.Name + ",";
            string filterBudgetDescription = "Bütçe Tipi: ";
            foreach (BudgetTypeDefinition budget in filterBudgetTypeDefinition)
                filterBudgetDescription = filterBudgetDescription + budget.Name + ",";
            reviewActionService_Output.filterDescription = filterStoreDescription + "-" + filterBudgetDescription;
            return reviewActionService_Output;
        }




        //[TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Ilac_Icmal_Iptal, TTRoleNames.Ilac_Icmal_Tamam)]
        //public static string SendMkysOutputDocumentForReviewActionTS(ReviewAction reviewAction)
        //{
        //    return reviewAction.SendMkysOutputDocumentForReviewAction();
        //}

        //[TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Ilac_Icmal_Iptal, TTRoleNames.Ilac_Icmal_Tamam)]
        //public static string SendDeleteMkysOutputDocumentForReviewActionTS(ReviewAction reviewAction)
        //{
        //    return reviewAction.SendDeleteMkysOutputDocumentForReviewAction();
        //}

        public string SendDeleteMkysOutputDocumentForReviewAction(string mkysPwd)
        {
            string SonucMesaj = string.Empty;
            foreach (DocumentRecordLog log in DocumentRecordLogs)
            {
                if (log.ReceiptNumber != null)
                {
                    MkysServis.makbuzSilmeSonuc makbuzSilmeSonuc = MkysServis.WebMethods.cikisMakbuzDeleteSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, (int)log.ReceiptNumber);
                    SonucMesaj += makbuzSilmeSonuc.mesaj;
                    if (makbuzSilmeSonuc.basariDurumu == true)
                    {
                        SonucMesaj += " MKYSden " + log.ReceiptNumber.ToString() + " nolu Ayniyat Makbuzu Silinmiştir.";
                    }
                    else
                        throw new Exception("MKYSden " + log.ReceiptNumber.ToString() + " nolu Ayniyat Makbuzu Silinememiştir!");
                }
            }
            return SonucMesaj;
        }

        public string SendMkysOutputDocumentForReviewAction(string mkysPwd)
        {
            string mkysMessage = string.Empty;
            MKYS_GidenVeri = string.Empty;
            MKYS_GelenVeri = string.Empty;
            try
            {
                foreach (DocumentRecordLog log in DocumentRecordLogs)
                {
                    if (log.ReceiptNumber == null)
                    {
                        MkysServis.makbuzInsertCikisItem cikisItem = new MkysServis.makbuzInsertCikisItem();
                        cikisItem.islemTuru = (MkysServis.ECikisIslemTuru)(int)MKYS_CikisIslemTuru.Value;
                        cikisItem.butceTurID = (MkysServis.EButceTurID)(int)log.BudgeType.Value;
                        cikisItem.stokHareketTurID = (MkysServis.ECikisStokHareketTurID)(int)MKYS_CikisStokHareketTuru;
                        cikisItem.makbuzNo = Int32.Parse(log.DocumentRecordLogNumber.Value.ToString());
                        cikisItem.makbuzTarihi = (DateTime)log.DocumentDateTime;
                        cikisItem.muayaneNo = MKYS_MuayeneNo;
                        cikisItem.muayeneTarihi = MKYS_MuayeneTarihi;
                        cikisItem.dayanagiBelgeNo = StockActionID.Value.ToString();
                        cikisItem.dayanagiBelgeTarihi = TransactionDate;
                        cikisItem.depoKayitNo = ((MainStoreDefinition)Store).StoreRecordNo.Value;
                        cikisItem.teslimAlan = MKYS_TeslimAlan;
                        cikisItem.teslimEden = MKYS_TeslimEden;
                        cikisItem.fisAciklama = Description;

                        IBindingList store = ObjectContext.QueryObjects("STORE", " NAME LIKE '" + log.Descriptions + "'");
                        Store destinationStore = null;
                        if (store.Count > 0)
                        {
                            destinationStore = ((Store)store[0]);
                            if (destinationStore is SubStoreDefinition)
                            {
                                cikisItem.cikisYapilanDepoKayitNo = ((SubStoreDefinition)destinationStore).UnitRegistryNo;
                                cikisItem.cikisBirimKayitNo = ((SubStoreDefinition)destinationStore).UnitRegistryNo;
                            }
                            else
                            {
                                cikisItem.cikisYapilanDepoKayitNo = ((MainStoreDefinition)Store).StoreRecordNo;
                                cikisItem.cikisBirimKayitNo = ((MainStoreDefinition)Store).StoreRecordNo;
                            }
                        }
                        else
                        {
                            cikisItem.cikisYapilanDepoKayitNo = ((MainStoreDefinition)Store).StoreRecordNo;
                            cikisItem.cikisBirimKayitNo = ((MainStoreDefinition)Store).StoreRecordNo;
                            destinationStore = Store;
                        }

                        //cikisItem.cikisYapilanKisiTCKimlikNo = log.Descriptions; //hastanın tcsi
                        cikisItem.hbysID = "Atlas";
                        var makbuzDetayCikisListe = new List<MkysServis.stokHareketCikisItem>();
                        List<ReviewActionDetail> reviewActionDetails = ReviewActionDetails.Where(t => t.StoreObjID == destinationStore.ObjectID && t.BudgetTypeDefinition.MKYS_Butce == log.BudgeType).ToList();
                        if (reviewActionDetails.Count > 0)
                        {

                            foreach (ReviewActionDetail detail in reviewActionDetails)
                            {
                                MkysServis.stokHareketCikisItem stokHareketCikisItem = new MkysServis.stokHareketCikisItem();

                                StockTransaction st = ObjectContext.GetObject<StockTransaction>(detail.StockTranactionGuid.Value);
                                StockTransaction inTrx = null;
                                foreach (StockTransactionDetail trxDetail in st.OutStockTransactionDetails)
                                {
                                    if (trxDetail.InStockTransaction.CurrentStateDefID == StockTransaction.States.Completed && trxDetail.InStockTransaction.InOut == TransactionTypeEnum.In)
                                        inTrx = trxDetail.InStockTransaction;
                                }
                                if (inTrx == null)
                                    throw new TTException("Bilgi işleme haber verin");

                                if (inTrx.MKYS_StokHareketID == null)
                                {
                                    mkysMessage += inTrx.StockActionDetail.StockAction.StockActionID + " Nolu İşlem'de bulunan " + inTrx.StockActionDetail.Material.Barcode + " Barkodlu " + inTrx.StockActionDetail.Material.Name + " Malzemenin ";
                                }
                                else
                                {
                                    stokHareketCikisItem.girisStokHareketID = inTrx.MKYS_StokHareketID.Value;
                                    stokHareketCikisItem.cikisMiktar = Convert.ToDecimal(detail.Amount);
                                    stokHareketCikisItem.hbysStokHareketID = detail.ObjectID.ToString();
                                    makbuzDetayCikisListe.Add(stokHareketCikisItem);

                                    if (makbuzDetayCikisListe.Count > 0)
                                        cikisItem.cikisStokHareketList = makbuzDetayCikisListe.ToArray();
                                }
                            }
                        }

                        if (String.IsNullOrEmpty(mkysMessage) == false)
                        {
                            return mkysMessage + " MKYS_StokHareketID değeri mevcut değil.Lütfen işlemleri kontrol edeniz..";
                        }

                        MKYS_GonderimTarihi = Common.RecTime();
                        MKYS_GidenVeri += TTUtils.SerializationHelper.XmlSerializeObject(cikisItem);
                        MkysServis.makbuzInsertCikisSonuc makbuzInsertCikisSonuc = MkysServis.WebMethods.makbuzInsertCikisSync(Sites.SiteLocalHost, Common.CurrentResource.MkysUserName, mkysPwd, cikisItem);
                        MKYS_GelenVeri += TTUtils.SerializationHelper.XmlSerializeObject(makbuzInsertCikisSonuc);
                        if (makbuzInsertCikisSonuc.basariDurumu == true)
                        {
                            log.ReceiptNumber = makbuzInsertCikisSonuc.islemKayitNo;
                            log.MKYSStatus = MKYSControlEnum.CompletedSent;
                            if (makbuzInsertCikisSonuc.sonucStokHareketList != null)
                            {
                                foreach (MkysServis.sonucStokHareketItem sonucStokHareketItem in makbuzInsertCikisSonuc.sonucStokHareketList)
                                {
                                    foreach (var detailIn in StockActionDetails)
                                    {
                                        if (detailIn.ObjectID == new Guid(sonucStokHareketItem.hbysStokHareketID))
                                        {
                                            detailIn.MKYS_StokHareketID = sonucStokHareketItem.stokHareketID;
                                        }
                                    }
                                }
                            }
                            ObjectContext.Save();
                        }
                        else
                            mkysMessage += " HATA : " + makbuzInsertCikisSonuc.mesaj;
                    }
                }
                if (String.IsNullOrEmpty(mkysMessage) == true)
                    mkysMessage = "İşlem Başarılı şekilde MKYS ye Gönderilmiştir.";
                TTUtils.InfoMessageService.Instance.ShowMessage(mkysMessage);
                return mkysMessage;
            }
            catch (Exception exp)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(exp.ToString());
                return mkysMessage;
            }
        }



        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                BindingList<StockCollectedTrx.GetCollectedTrxByStockActionID_Class> collectedTrxs = StockCollectedTrx.GetCollectedTrxByStockActionID(ObjectID);


                Dictionary<Guid, Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>> dicForStore = new Dictionary<Guid, Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>>();
                foreach (ReviewActionDetail detail in ReviewActionDetails)
                {
                    if (dicForStore.ContainsKey((Guid)detail.StoreObjID))
                    {
                        Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> dicForBudgetictionary = dicForStore[(Guid)detail.StoreObjID];
                        MKYS_EButceTurEnum bt = (MKYS_EButceTurEnum)detail.BudgetTypeDefinition.MKYS_Butce;
                        if (dicForBudgetictionary.ContainsKey(bt))
                        {
                            dicForBudgetictionary[bt].Add(detail);
                        }
                        else
                        {
                            List<StockActionDetail> outTrxs = new List<StockActionDetail>();
                            outTrxs.Add(detail);
                            dicForBudgetictionary.Add(bt, outTrxs);
                        }
                        dicForStore[(Guid)detail.StoreObjID] = dicForBudgetictionary;
                    }
                    else
                    {
                        Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> dicForBudget = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                        List<StockActionDetail> outTrxs = new List<StockActionDetail>();
                        outTrxs.Add(detail);
                        dicForBudget.Add((MKYS_EButceTurEnum)detail.BudgetTypeDefinition.MKYS_Butce, outTrxs);
                        dicForStore.Add((Guid)detail.StoreObjID, dicForBudget);
                    }




                    /*  if (dicForStore.ContainsKey((Guid)detail.StoreObjID) == false)
                  {
                      Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> dicForBudgetictionary = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                      MKYS_EButceTurEnum bt = (MKYS_EButceTurEnum)detail.BudgetTypeDefinition.MKYS_Butce;
                      if (dicForStore[detail.StoreObjID.Value].ContainsKey(bt) == false)
                      {
                          List<StockActionDetail> outTrxs = new List<StockActionDetail>();
                          outTrxs.Add(detail);
                          dicForBudgetictionary.Add(bt, outTrxs);
                          dicForStore[detail.StoreObjID.Value] = dicForBudgetictionary;
                      }
                      else
                      {
                          dicForStore[detail.StoreObjID.Value][bt].Add(detail);
                      }
                  }
                  else
                  {
                      MKYS_EButceTurEnum bt = (MKYS_EButceTurEnum)detail.BudgetTypeDefinition.MKYS_Butce;
                      if (dicForStore[detail.StoreObjID.Value].ContainsKey(bt))
                      {
                          dicForStore[detail.StoreObjID.Value][bt].Add(detail);
                      }
                      else
                      {
                          Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> dicForBudget = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                          List<StockActionDetail> outTrxs = new List<StockActionDetail>();
                          outTrxs.Add(detail);
                          dicForBudget.Add((MKYS_EButceTurEnum)detail.BudgetTypeDefinition.MKYS_Butce, outTrxs);
                          dicForStore[detail.StoreObjID.Value] = dicForBudget;
                      }

                  }*/
                }

                if (dicForStore.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<Guid, Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>> outLog in dicForStore)
                    {
                        Store s = (Store)ObjectContext.GetObject(outLog.Key, typeof(Store));
                        foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLog in outLog.Value)
                        {
                            string place = ((MainStoreDefinition)Store).Accountancy.AccountancyNO + " " + ((MainStoreDefinition)Store).Accountancy.Name;
                            AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outRecordLog.Key, s.Name);
                            _documentRecordLogContents.Add(logContent);
                        }
                    }
                }

                return _documentRecordLogContents;
            }
        }

        #region IAutoDocumentRecordLog Member
        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> GetDocumentRecordLogContents()
        {
            return DocumentRecordLogContents;
        }
        #endregion
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #endregion Methods
    }
}