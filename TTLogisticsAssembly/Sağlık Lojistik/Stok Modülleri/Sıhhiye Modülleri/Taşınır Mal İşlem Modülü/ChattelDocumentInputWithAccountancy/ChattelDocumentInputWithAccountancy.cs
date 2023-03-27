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
using TTObjectClasses.DTOs;

namespace TTObjectClasses
{
    public partial class ChattelDocumentInputWithAccountancy : BaseChattelDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IStockInTransaction, IChattelDocumentInputWithAccountancy, ICheckStockActionInDetail
    {
        public partial class InputDetailsWithAccountancyRQ_Class : TTReportNqlObject
        {
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            MKYSControl = false;
            #endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
            ChangeAccountancyType();
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed         
            #region PreTransition_Approved2Completed
            ChangeAccountancyType();
            if (InPatientPhysicianApplication != null)
            {
                foreach (ChattelDocumentInputDetailWithAccountancy detail in ChattelDocumentInputDetailsWithAccountancy)
                    detail.Patient = InPatientPhysicianApplication.Episode.Patient;
            }
            #endregion PreTransition_Approved2Completed

        }
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed         
            #region PreTransition_New2Completed
            ChangeAccountancyType();
            if (InPatientPhysicianApplication != null)
            {
                foreach (ChattelDocumentInputDetailWithAccountancy detail in ChattelDocumentInputDetailsWithAccountancy)
                    detail.Patient = InPatientPhysicianApplication.Episode.Patient;
            }
            #endregion PreTransition_New2Completed

        }

        protected void PreTransition_Completed2FixDocument()
        {
            #region PreTransition_Completed2FixDocument
            string errorMsg = string.Empty;
            foreach (ChattelDocumentInputDetailWithAccountancy purchaseDetail in this.ChattelDocumentInputDetailsWithAccountancy)
            {
                foreach (StockTransaction trx in purchaseDetail.StockTransactions.Select(string.Empty))
                {
                    foreach (StockTransactionDetail trxDetail in trx.StockTransactionDetails)
                    {
                        if (trxDetail.OutStockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                        {
                            if (string.IsNullOrEmpty(errorMsg))
                                errorMsg = trxDetail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.ToString();
                            else
                                errorMsg = errorMsg + ", " + trxDetail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.ToString();
                        }

                    }

                }
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
                throw new TTException(errorMsg + " numaralı işlem(ler) ile çıkış olduğu için işlemi düzeltme adımına alamazsınız.");

            #endregion PreTransition_Completed2FixDocument
        }

        protected void PostTransition_Completed2FixDocument()
        {
            #region PostTransition_Completed2FixDocument
            foreach (ChattelDocumentInputDetailWithAccountancy inputDetail in this.ChattelDocumentInputDetailsWithAccountancy)
            {
                foreach (StockTransaction trx in inputDetail.StockTransactions.Select(string.Empty))
                    trx.CurrentStateDefID = StockTransaction.States.Cancelled;
            }
            #endregion PostTransition_Completed2FixDocument
        }

        #region Methods
        #region IChattelDocumentInputWithAccountancy Member
        public DateTime? GetWaybillDate()
        {
            return WaybillDate;
        }

        public string GetWaybill()
        {
            return Waybill;
        }
        #endregion
        #region IChattelDocumentWithAccountancy Members
        IAccountancy IChattelDocumentWithAccountancy.GetAccountancy()
        {
            return (IAccountancy)Accountancy;
        }

        #endregion
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
        #region ICheckStockActionInDetail Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }
        #endregion 
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        private void ChangeAccountancyType()
        {
            if (inputWithAccountancyType != null)
            {
                MKYS_ETedarikTuru = (MKYS_ETedarikTurEnum)Enum.Parse(typeof(MKYS_ETedarikTurEnum), ((int)inputWithAccountancyType.Value).ToString());
                MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M25723", "Giriş türü seçilmeden işleme devam edilemez!"));
            }
        }

        public bool IsConflictExist
        {
            get
            {
                bool isConflictExist = false;
                foreach (ChattelDocumentInputDetailWithAccountancy chattelDocumentInputDetailWithAccountancy in ChattelDocumentInputDetailsWithAccountancy)
                {
                    if (chattelDocumentInputDetailWithAccountancy.ConflictAmount.HasValue && chattelDocumentInputDetailWithAccountancy.ConflictAmount.Value != 0)
                    {
                        isConflictExist = true;
                        break;
                    }
                }

                return isConflictExist;
            }
        }

        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ChattelDocumentInputDetailWithAccountancy detail in ChattelDocumentInputDetailsWithAccountancy)
                {
                    foreach (StockTransaction inTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (inTrx.InOut == TransactionTypeEnum.In)
                        {
                            if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(inTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (inRecordLogs.ContainsKey(butce))
                            {
                                if (inRecordLogs[butce].Contains(detail) == false)
                                    inRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                inRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (inRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = Accountancy.AccountancyNO + " " + Accountancy.Name;
                        int countOfRow = inLog.Value.Count;
                        if (this.IsPTSAction == true)
                        {
                            countOfRow = this.PTSStockActionDetails.Count;
                        }

                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, countOfRow, place, inLog.Key);
                        _documentRecordLogContents.Add(logContent);
                    }
                }

                return _documentRecordLogContents;
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Giris_Kayit)]
        public static ChattelDocumentInputWithAccountancy GetWaybillForInputDocumentTS(ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy)
        {
            ChattelDocumentInputWithAccountancy.QueryMkysAction queryMkysAction = new ChattelDocumentInputWithAccountancy.QueryMkysAction();
            queryMkysAction.MKYSUserName = "";
            queryMkysAction.MKYSUserPassword = "";
            //Eğer mkys işlemi yapılacaksa buraya ts tarafında şifre isteyip buraya göndermek gerekiyor.! şuanda fastoff kullanılıyor ondan bu şekilde yapıldı.
            return chattelDocumentInputWithAccountancy.GetWaybillForInputDocument(chattelDocumentInputWithAccountancy, queryMkysAction);
        }

        public class QueryMkysAction
        {
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

        public ChattelDocumentInputWithAccountancy GetWaybillForInputDocument(ChattelDocumentInputWithAccountancy chattelDocumentInputWithAccountancy, ChattelDocumentInputWithAccountancy.QueryMkysAction queryMkysAction)
        {
            ChattelDocumentInputWithAccountancy chattelDocumentInput = new ChattelDocumentInputWithAccountancy(chattelDocumentInputWithAccountancy.ObjectContext);
            List<TTObjectClasses.MkysServis.devirFisiItem> devirFisiItems = MkysServis.WebMethods.devirFisiGetSync(Sites.SiteLocalHost, queryMkysAction.MKYSUserName, queryMkysAction.MKYSUserPassword, Int32.Parse(Waybill)).ToList();
            //MkysServis.devirFisiItem[] devirFisiItems = MkysServis.WebMethods.devirFisiGetSync(Sites.SiteLocalHost, Int32.Parse(this.Waybill));
            if (devirFisiItems.Count > 0)
            {
                foreach (MkysServis.devirFisiItem tif in devirFisiItems)
                {
                    ChattelDocumentInputDetailWithAccountancy detail = new ChattelDocumentInputDetailWithAccountancy(chattelDocumentInputWithAccountancy.ObjectContext);
                    IBindingList mat = null;
                    if (!String.IsNullOrEmpty(tif.urunBarkodu))
                        mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + tif.urunBarkodu + "' AND MKYSMALZEMEKODU ='" + tif.malzemeKayitID + "'"); //ISACTIVE ÖZELLİĞİ VERİ BOZUK OLDUGUNDAN KOYULDU KALDIRILACAK.
                    else
                        mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND  MKYSMALZEMEKODU ='" + tif.malzemeKayitID + "'");
                    if (mat.Count == 1)
                    {
                        Material material = (Material)mat[0];
                        detail.Material = material;
                        detail.SentAmount = tif.miktar;
                        detail.Amount = tif.miktar;
                        detail.NotDiscountedUnitPrice = tif.vergiliBirimFiyat;
                        detail.VatRate = 0;
                        detail.ProductionDate = tif.uretimTarihi;
                        detail.ExpirationDate = tif.sonKullanmaTarihi;
                        detail.RetrievalYear = tif.edinmeYili;
                    }

                    chattelDocumentInput.ChattelDocumentInputDetailsWithAccountancy.Add(detail);
                }
            }

            return chattelDocumentInput;
        }

        private bool KontrolTasinirMalGirisTurleri(int selected)
        {
            List<int> items = new List<int>();
            items.Add((int)TasinirMalGirisTurEnum.bagliSaglikTesisindenDevir);
            items.Add((int)TasinirMalGirisTurEnum.devirAlinan);
            items.Add((int)TasinirMalGirisTurEnum.duzeltme);
            items.Add((int)TasinirMalGirisTurEnum.ihtiyacFazlasiDevir);
            items.Add((int)TasinirMalGirisTurEnum.sgkTarafindanTedarikEdilenUrun);
            items.Add((int)TasinirMalGirisTurEnum.stokFazlasiDevir);
            items.Add((int)TasinirMalGirisTurEnum.tedarikPaylasimDevirGiris);
            items.Add((int)MKYS_ETedarikTurEnum.satinalma);
            return items.Any(p => p == selected);
        }

        public static string CreateFromDTO(StockActionDTO model)
        {
            string result = string.Empty;
            using (TTObjectContext context = new TTObjectContext(false))
            {
                ChattelDocumentInputWithAccountancy stockAction;
                if (model.StockActionObjectId.HasValue)
                {
                    stockAction = context.GetObject<ChattelDocumentInputWithAccountancy>(model.StockActionObjectId.Value);
                }
                else
                {
                    stockAction = new ChattelDocumentInputWithAccountancy(context);
                }
                stockAction.Accountancy = context.GetObject<Accountancy>(model.CompanyId);
                stockAction.Store = context.GetObject<Store>(model.MainStoreId);
                stockAction.MKYS_ETedarikTuru = (MKYS_ETedarikTurEnum)model.SupplyType;
                stockAction.MKYS_EAlimYontemi = (MKYS_EAlimYontemiEnum)model.BuyMethod;
                stockAction.Description = model.Description;
                stockAction.Waybill = model.BreederDocumentNumber;
                stockAction.WaybillDate = model.BreederDocumentDate;
                stockAction.BudgetTypeDefinition = context.GetObject<BudgetTypeDefinition>(model.BudgetType.Value);
                stockAction.MKYS_TeslimAlanObjID = model.Deliverer;
                stockAction.MKYS_TeslimAlan = model.DelivererName;
                stockAction.MKYS_TeslimEdenObjID = model.TakenBy;
                stockAction.MKYS_TeslimEden = model.TakenByName;
                stockAction.TransactionDate = model.TicketDate;
                if (model.InPatientPhysicianApplication.HasValue)
                {
                    stockAction.InPatientPhysicianApplication = context.GetObject<InPatientPhysicianApplication>(model.InPatientPhysicianApplication.Value);
                }
                stockAction.MKYS_EMalzemeGrup = model.MaterialGroup;
                foreach (var materialDTO in model.MaterialList)
                {
                    ChattelDocumentInputDetailWithAccountancy stockActionDetail;
                    if (materialDTO.ObjectID != null && materialDTO.ObjectID != Guid.Empty)
                    {
                        stockActionDetail = context.GetObject<ChattelDocumentInputDetailWithAccountancy>(materialDTO.ObjectID);
                    }
                    else
                    {
                        stockActionDetail = new ChattelDocumentInputDetailWithAccountancy(context);
                    }


                    stockActionDetail.Material = context.GetObject<Material>(materialDTO.MaterialID);
                    stockActionDetail.Amount = materialDTO.Amount;
                    stockActionDetail.SentAmount = materialDTO.Amount;
                    stockActionDetail.VatRate = Convert.ToInt64(materialDTO.VatRate);
                    stockActionDetail.DiscountRate = materialDTO.DiscountRate;
                    stockActionDetail.DiscountAmount = materialDTO.DiscountAmount;
                    stockActionDetail.NotDiscountedUnitPrice = materialDTO.NotDiscountedUnitPrice; //TODO
                    stockActionDetail.Price = materialDTO.Price;
                    stockActionDetail.UnitPrice = materialDTO.UnitPrice; //TODO
                    stockActionDetail.ExpirationDate = materialDTO.ExpirationDate;
                    stockActionDetail.LotNo = materialDTO.LotNo;
                    stockActionDetail.StockLevelType = StockLevelType.NewStockLevel;
                    stockActionDetail.Status = StockActionDetailStatusEnum.New;
                    stockActionDetail.RetrievalYear = Common.RecTime().Year;
                    if (materialDTO.MaterialSupplierId.HasValue)
                    {
                        stockActionDetail.Supplier = context.GetObject<Supplier>(materialDTO.MaterialSupplierId.Value);
                    }
                    stockAction.ChattelDocumentInputDetailsWithAccountancy.Add(stockActionDetail);
                }
                stockAction.CurrentStateDefID = States.New;
                context.Save();
                if (model.RecordType == 1)
                {
                    stockAction.CurrentStateDefID = States.Completed;
                    context.Save();
                    if (model.SendToMKYS)
                    {
                        result = stockAction.SendMKYSForInputDocument(model.MKYSPassword);
                    }
                    AfterContextSaveScript(stockAction);
                }
            }
            return result;
        }

        public static void AfterContextSaveScript(ChattelDocumentInputWithAccountancy stockAction)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (var item in stockAction?.ChattelDocumentInputDetailsWithAccountancy)
                {
                    if (item.Material.IsIndividualTrackingRequired != null && item.Material.IsIndividualTrackingRequired.Value)
                    {
                        item.ReceiveNotificationID = MakeUTSReceiveNotification(item);
                        item.StockTransactions[0].ReceiveNotificationID = item.ReceiveNotificationID;
                        objectContext.Save();
                    }
                }

                if (stockAction.InPatientPhysicianApplication != null)
                {
                    foreach (ChattelDocumentInputDetailWithAccountancy detail in stockAction.ChattelDocumentInputDetailsWithAccountancy)
                    {
                        BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                        baseTreatmentMaterial.Material = detail.Material;
                        baseTreatmentMaterial.Amount = detail.Amount;
                        baseTreatmentMaterial.Patient = detail.Patient;
                        baseTreatmentMaterial.Store = stockAction.Store;
                        stockAction.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                    }
                }
            }
        }

        private static string MakeUTSReceiveNotification(ChattelDocumentInputDetailWithAccountancy item)
        {
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
            {
                ADT = item.Amount,
                VBI = item.IncomingDeliveryNotifID
            };

            UTSServis.BildirimCevap almaBildirimiCevap = null;
            try
            {
                almaBildirimiCevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(siteID), almaBildirimiIstek);
            }
            catch (Exception e)
            {
                // todo
            }

            if (almaBildirimiCevap != null && !string.IsNullOrEmpty(almaBildirimiCevap.SNC))
            {
                return almaBildirimiCevap.SNC;
            }
            return null;
        }

        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChattelDocumentInputWithAccountancy).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ChattelDocumentInputWithAccountancy.States.Completed && toState == ChattelDocumentInputWithAccountancy.States.Cancelled)
                PreTransition_Completed2Cancelled();
            if (fromState == ChattelDocumentInputWithAccountancy.States.New && toState == ChattelDocumentInputWithAccountancy.States.Approved)
                PreTransition_New2Approval();
            if (fromState == ChattelDocumentInputWithAccountancy.States.Approved && toState == ChattelDocumentInputWithAccountancy.States.Completed)
                PreTransition_Approval2Completed();
            if (fromState == ChattelDocumentInputWithAccountancy.States.New && toState == ChattelDocumentInputWithAccountancy.States.Completed)
                PreTransition_New2Completed();
            if (fromState == ChattelDocumentInputWithAccountancy.States.Completed && toState == ChattelDocumentInputWithAccountancy.States.FixDocument)
                PreTransition_Completed2FixDocument();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChattelDocumentInputWithAccountancy).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ChattelDocumentInputWithAccountancy.States.Completed && toState == ChattelDocumentInputWithAccountancy.States.FixDocument)
                PostTransition_Completed2FixDocument();
        }

    }
}