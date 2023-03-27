
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
    /// Taşınır Mal İşlemi Çıkış
    /// </summary>
    public partial class ChattelDocumentOutputWithAccountancy : BaseChattelDocument, IAutoDocumentRecordLog, IAutoDocumentNumber, IStockOutTransaction, IStockReservation, IChattelDocumentOutputWithAccountancy, ICheckStockActionOutDetail
    {


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
            ChangeAccountancyType();
            if (Store is MainStoreDefinition)
            {
                if (MKYS_CikisStokHareketTuru != MKYS_ECikisStokHareketTurEnum.ckDevirIhtiyacFazlasiDevir)
                {
                    Guid InvoiceNumber = new Guid("ed852276-bc44-4587-b8fc-0bb23e68da38");
                    InvoiceNumberSec = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[InvoiceNumber], null, null).ToString();
                }
            }
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed         
            ChangeAccountancyType();
            if (Store is MainStoreDefinition)
            {
                if (MKYS_CikisStokHareketTuru != MKYS_ECikisStokHareketTurEnum.ckDevirIhtiyacFazlasiDevir)
                {
                    Guid InvoiceNumber = new Guid("ed852276-bc44-4587-b8fc-0bb23e68da38");
                    InvoiceNumberSec = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[InvoiceNumber], null, null).ToString();
                }
            }
        }

        #region Methods
        #region IChattelDocumentOutputWithAccountancy Member
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
        #region ICheckStockActionOutDetail Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #region IStockOutTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        private void ChangeAccountancyType()
        {
            if (outputStockMovementType != null)
            {
                MKYS_CikisStokHareketTuru = (MKYS_ECikisStokHareketTurEnum)Enum.Parse(typeof(MKYS_ECikisStokHareketTurEnum), ((int)outputStockMovementType.Value).ToString());
            }
            else
            {
                throw new TTException(TTUtils.CultureService.GetText("M25379", "Çıkış haraket türü seçilmeden işleme devam edilemez!"));
            }
        }


        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> outRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ChattelDocumentOutputDetailWithAccountancy detail in ChattelDocumentOutputDetailsWithAccountancy)
                {
                    foreach (StockTransaction outTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (outTrx.InOut == TransactionTypeEnum.Out)
                        {
                            if (outTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(outTrx.BudgetTypeDefinition.Name + " bütcesi MKYS ile eşleştirilmemiştir. Lütfen eşleştirip işleme öyle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)outTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (outRecordLogs.ContainsKey(butce))
                            {
                                if (outRecordLogs[butce].Contains(detail) == false)
                                    outRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                outRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (outRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> outLog in outRecordLogs)
                    {
                        string place = Accountancy.AccountancyNO + " " + Accountancy.Name;
                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.Out, this, outLog.Value.Count, place, outLog.Key);

                        _documentRecordLogContents.Add(logContent);
                    }
                }
                return _documentRecordLogContents;
            }
        }


        public void SendDocumentToTargetSite()
        {
            //            TTObjectContext ctx = new TTObjectContext(true);
            //            MainStoreDefinition mainStore = (MainStoreDefinition)ctx.GetObject(this.Store.ObjectID, typeof(MainStoreDefinition));
            //            if (mainStore == null)
            //                return;
            //
            //            if (this.Accountancy.AccountancyMilitaryUnit == null)
            //                return;
            //
            //            if (this.Accountancy.AccountancyMilitaryUnit.IsSupported == null)
            //                return;
            //
            //            if ((bool)this.Accountancy.AccountancyMilitaryUnit.IsSupported)
            //            {
            //                List<TTObject> list = new List<TTObject>();
            //                list.Add(((StockAction)this).AccountingTerm.Accountancy);
            //                list.Add(this.Accountancy);
            //                list.Add((TTObject)this);
            //                foreach (ChattelDocumentOutputDetailWithAccountancy chatDet in this.ChattelDocumentOutputDetailsWithAccountancy)
            //                {
            //                    foreach (FixedAssetOutDetail fixedAssetOutDetail in chatDet.FixedAssetOutDetails)
            //                    {
            //                        list.Add(fixedAssetOutDetail);
            //                        FixedAssetMaterialDefinition fixedAssetMaterialDefinition = fixedAssetOutDetail.FixedAssetMaterialDefinition;
            //                        fixedAssetMaterialDefinition.Resource = null;
            //                        fixedAssetMaterialDefinition.Stock = null;
            //                        list.Add(fixedAssetMaterialDefinition);
            //                    }
            //                    
            //                    foreach(OuttableLot outtableLot in chatDet.OuttableLots)
            //                        if ((bool)outtableLot.isUse)
            //                        list.Add(outtableLot);
            //
            //                    foreach (InvoiceDetail invoice in chatDet.InvoiceDetails)
            //                        list.Add(invoice);
            //                    
            //                    list.Add((TTObject)chatDet);
            //                }
            //
            //
            //
            //                Sites site = (Sites)this.Accountancy.AccountancyMilitaryUnit.Site;
            //                ChattelDocumentOutputWithAccountancy.RemoteMethods.CreateInputSendingDoc(site.ObjectID, list);
            //            }
        }

        public void CreateInputDocumentSameSite(ChattelDocumentOutputWithAccountancy outputDocument, TTObjectContext context)
        {
            Dictionary<StockTransaction, Currency> inTransaction = new Dictionary<StockTransaction, Currency>();
            foreach (ChattelDocumentOutputDetailWithAccountancy outDetail in outputDocument.ChattelDocumentOutputDetailsWithAccountancy)
            {
                foreach (StockTransaction outTRX in outDetail.StockTransactions.Select(string.Empty))
                {
                    if (outTRX.GetFirstInTransaction() != null)
                        if (inTransaction.ContainsKey(outTRX.GetFirstInTransaction()) == false)
                            inTransaction.Add(outTRX.GetFirstInTransaction(), (Currency)outTRX.Amount);
                        else
                            inTransaction[outTRX.GetFirstInTransaction()] = inTransaction[outTRX.GetFirstInTransaction()] + (Currency)outTRX.Amount;
                }
            }
            IList inputDoceuments = outputDocument.GenerateInputDocumentForRemote(outputDocument, context);
            foreach (ChattelDocumentInputWithAccountancy inputDoc in inputDoceuments)
            {
                ChattelDocumentInputWithAccountancy chatIn = inputDoc;
                chatIn.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
                chatIn.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
                chatIn.Store = outputDocument.Accountancy.MainStores[0];
                chatIn.IsEntryOldMaterial = true;
                outputDocument.InputDocumentObjectID = chatIn.ObjectID;
            }

        }

        public BindingList<ChattelDocumentInputWithAccountancy> GenerateInputDocumentForRemote(ChattelDocumentOutputWithAccountancy outputDocument, TTObjectContext context)
        {
            int detailCount = 0;
            BindingList<ChattelDocumentInputWithAccountancy> inputDocuments = new BindingList<ChattelDocumentInputWithAccountancy>();
            Dictionary<Guid, Currency> inTransaction = new Dictionary<Guid, Currency>();
            Queue<QRCodeTransaction> qRCodeOuts = new Queue<QRCodeTransaction>();
            Queue<FixedAssetMaterialDefinition> fixedAssetOuts = new Queue<FixedAssetMaterialDefinition>();
            //ChattelDocumentInputWithAccountancy chatIn = new ChattelDocumentInputWithAccountancy(context);
            //chatIn.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
            //chatIn.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
            //chatIn.IsEntryOldMaterial = true;
            //List<TTObject> chatInDetails = new List<TTObject>();
            foreach (ChattelDocumentOutputDetailWithAccountancy outDetail in outputDocument.ChattelDocumentOutputDetailsWithAccountancy.Select(string.Empty, "CHATTELDOCDETAILORDERNO"))
            {
                //if (detailCount == 21)
                //{
                //inputDocuments.Add(chatIn);
                //chatIn = new ChattelDocumentInputWithAccountancy(context);
                //chatIn.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
                //chatIn.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
                //chatIn.IsEntryOldMaterial = true;
                //detailCount = 0;
                //}

                if (outDetail.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                {
                    if (outDetail.QRCodeOutDetails.Count > 0)
                    {
                        foreach (QRCodeOutDetail qc in outDetail.QRCodeOutDetails)
                        {
                            qRCodeOuts.Enqueue(qc.QRCodeTransaction);
                        }
                    }
                }

                if (outDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    if (outDetail.FixedAssetOutDetails.Count > 0)
                    {
                        foreach (FixedAssetOutDetail fd in outDetail.FixedAssetOutDetails)
                        {
                            fixedAssetOuts.Enqueue(fd.FixedAssetMaterialDefinition);
                        }
                    }
                }


                foreach (StockTransaction transaction in outDetail.StockTransactions.Select(string.Empty))
                {
                    if (transaction.GetFirstInTransaction() != null)
                    {
                        if (inTransaction.ContainsKey(transaction.GetFirstInTransaction().ObjectID) == false)
                            inTransaction.Add(transaction.GetFirstInTransaction().ObjectID, (Currency)transaction.Amount);
                        else
                            inTransaction[transaction.GetFirstInTransaction().ObjectID] = inTransaction[transaction.GetFirstInTransaction().ObjectID] + (Currency)transaction.Amount;
                    }
                }

            }
            double documentCount = Math.Ceiling(((Double)inTransaction.Count / 20));

            for (int i = 0; i < documentCount; i++)
            {
                ChattelDocumentInputWithAccountancy chatDocument = new ChattelDocumentInputWithAccountancy(context);
                chatDocument.CurrentStateDefID = ChattelDocumentInputWithAccountancy.States.New;
                chatDocument.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
                chatDocument.ChattelOutDocumentGuid = outputDocument.ObjectID;
                chatDocument.IsEntryOldMaterial = true;
                inputDocuments.Add(chatDocument);
            }

            int d = 0;
            ChattelDocumentInputWithAccountancy chatIn = null;
            int orderNo = 0;
            foreach (KeyValuePair<Guid, Currency> detailObjectid in inTransaction)
            {
                TTObjectContext readOnlyContext = new TTObjectContext(true);
                StockTransaction detail = (StockTransaction)readOnlyContext.GetObject(detailObjectid.Key, typeof(StockTransaction));

                if (detailCount == 0)
                {
                    chatIn = inputDocuments[d];
                    d++;
                }
                ChattelDocumentInputDetailWithAccountancy chatDetIn = new ChattelDocumentInputDetailWithAccountancy(context);
                if (chatIn == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25898", "Hatalı bir işlem oluştu XXXXXX Çözüm Merkezine haber veriniz."));
                chatDetIn.StockAction = chatIn;
                detailCount++;
                if (detailCount == 20)
                    detailCount = 0;
                orderNo++;
                chatDetIn.ChattelDocDetailOrderNo = orderNo;
                chatDetIn.Material = detail.Stock.Material;
                chatDetIn.SentAmount = detailObjectid.Value;
                chatDetIn.Amount = detailObjectid.Value;
                chatDetIn.UnitPrice = detail.UnitPrice;
                chatDetIn.StockLevelType = detail.StockLevelType;
                if (detail.LotNo != null)
                    chatDetIn.LotNo = detail.LotNo;
                if (detail.ExpirationDate != null)
                    chatDetIn.ExpirationDate = detail.ExpirationDate;

                if (detail.StockActionDetail.StockAction is IChattelDocumentWithPurchase)
                {
                    InvoiceDetail invoiceDetail = chatDetIn.InvoiceDetails.AddNew();
                    invoiceDetail.InvoicePicture = detail.StockActionDetail.StockAction.InvoicePicture;
                    invoiceDetail.InvoiceDate = ((IChattelDocumentWithPurchase)detail.StockActionDetail.StockAction).GetBaseDateTime();
                    invoiceDetail.AuctionDate = ((IChattelDocumentWithPurchase)detail.StockActionDetail.StockAction).GetAuctionDate();
                    invoiceDetail.RegistrationAuctionNo = ((IChattelDocumentWithPurchase)detail.StockActionDetail.StockAction).GetRegistrationAuctionNo();
                }
                else
                {
                    if (detail.StockActionDetail.InvoiceDetails.Count == 1)
                    {
                        InvoiceDetail invoiceDetail = chatDetIn.InvoiceDetails.AddNew();
                        invoiceDetail.InvoicePicture = detail.StockActionDetail.InvoiceDetails[0].InvoicePicture;
                        invoiceDetail.InvoiceDate = detail.StockActionDetail.InvoiceDetails[0].InvoiceDate;
                        invoiceDetail.AuctionDate = detail.StockActionDetail.InvoiceDetails[0].AuctionDate;
                        invoiceDetail.RegistrationAuctionNo = detail.StockActionDetail.InvoiceDetails[0].RegistrationAuctionNo;
                    }
                }

                if (detail.Stock.Material.StockCard.StockMethod == StockMethodEnum.QRCodeUsed)
                {
                    int qrcodeCount = 0;
                    for (int i = 0; i < qrcodeCount; i++)
                    {
                        if (qRCodeOuts.Count == 0)
                            break;
                        QRCodeTransaction qRCodeTransaction = qRCodeOuts.Dequeue();
                        QRCodeInDetail qRCodeInDetail = new QRCodeInDetail(context);
                        qRCodeInDetail.Barcode = qRCodeTransaction.Barcode;
                        qRCodeInDetail.BoxNo = qRCodeTransaction.BoxNo;
                        qRCodeInDetail.BunchNo = qRCodeTransaction.BunchNo;
                        qRCodeInDetail.LotNo = qRCodeTransaction.LotNo;
                        qRCodeInDetail.OrderNo = qRCodeTransaction.OrderNo;
                        qRCodeInDetail.PackageNo = qRCodeTransaction.PackageNo;
                        qRCodeInDetail.PalletNo = qRCodeTransaction.PalletNo;
                        qRCodeInDetail.SmallBunchNo = qRCodeTransaction.SmallBunchNo;
                        qRCodeInDetail.StockActionDetail = (StockActionDetail)chatDetIn;
                    }
                }


                if (detail.Stock.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    FixedAssetDefinition fixedAssetDefinition = null;
                    for (int i = 0; i < detailObjectid.Value; i++)
                    {
                        if (fixedAssetOuts.Count == 0)
                            break;

                        FixedAssetMaterialDefinition fam = fixedAssetOuts.Dequeue();
                        if (fixedAssetDefinition == null)
                            fixedAssetDefinition = fam.FixedAssetDefinition;

                        FixedAssetInDetail fin = new FixedAssetInDetail(context);
                        fin.Description = fam.Description;
                        fin.FixedAssetNO = fam.FixedAssetNO;
                        fin.Frequency = fam.Frequency;
                        fin.GuarantyEndDate = fam.GuarantyEndDate;
                        fin.GuarantyStartDate = fam.GuarantyStartDate;
                        fin.Mark = fam.Mark;
                        fin.Model = fam.Model;
                        fin.Power = fam.Power;
                        fin.ProductionDate = fam.ProductionDate;
                        fin.SerialNumber = fam.SerialNumber;
                        fin.Status = fam.Status;
                        fin.Voltage = fam.Voltage;
                        fin.TransferredFromXXXXXXSite = true;
                        fin.TransferedFixedAssetMaterial = fam;
                        fin.StockActionDetail = (StockActionDetail)chatDetIn;
                        fam.Accountancy = ((MainStoreDefinition)outputDocument.Store).Accountancy;
                    }
                }
            }
            return inputDocuments;
        }

        public void SendGeneratedDocumentToTargetSite(IList chatInputDocuments, Accountancy sourceAccountancy, Sites targetSite)
        {
            //            List<TTObject> list = new List<TTObject>();
            //            bool senddable = false;
            //            foreach (ChattelDocumentInputWithAccountancy chatIn in chatInputDocuments)
            //            {
            //                if (sourceAccountancy.AccountancyMilitaryUnit == null)
            //                    return;
            //
            //                if (sourceAccountancy.AccountancyMilitaryUnit.IsSupported == null)
            //                    return;
            //
            //                if ((bool)sourceAccountancy.AccountancyMilitaryUnit.IsSupported)
            //                {
            //                    senddable = true;
            //                    list.Add(chatIn.Accountancy);
            //                    if (chatIn.ChattelDocumentInputDetailsWithAccountancy.Count > 0)
            //                    {
            //                        list.Add((TTObject)chatIn);
            //                        foreach (ChattelDocumentInputDetailWithAccountancy chatDet in chatIn.ChattelDocumentInputDetailsWithAccountancy)
            //                        {
            //                            foreach (FixedAssetInDetail fixedAssetInDetail in chatDet.FixedAssetInDetails)
            //                            {
            //                                list.Add(fixedAssetInDetail);
            //                                FixedAssetMaterialDefinition fixedAssetMaterialDefinition = fixedAssetInDetail.TransferedFixedAssetMaterial;
            //                                fixedAssetMaterialDefinition.Resource = null;
            //                                fixedAssetMaterialDefinition.Stock = null;
            //                                list.Add(fixedAssetMaterialDefinition);
            //                            }
            //
            //                            foreach (InvoiceDetail invoice in chatDet.InvoiceDetails)
            //                                list.Add(invoice);
            //
            //                            list.Add((TTObject)chatDet);
            //                        }
            //                    }
            //                }
            //            }
            //
            //            if (senddable)
            //            {
            //                Sites site = (Sites)sourceAccountancy.AccountancyMilitaryUnit.Site;
            //                ChattelDocumentOutputWithAccountancy.RemoteMethods.GenerateInputSendingDoc(site.ObjectID, list, sourceAccountancy);
            //            }
        }

        public void SetMKYSProperties()
        {
            MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;

            MainStoreDefinition mainStoreDefinition = Store as MainStoreDefinition; // Deponun bütçe türünden alınır
            if (mainStoreDefinition != null)
                MKYS_EButceTur = mainStoreDefinition.MKYS_ButceTuru;

            MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckDevirKurumDisiMalzemeCikis;

            if (Store != null && Store.UnitStoreGetData != null)
                MKYS_DepoKayitNo = Store.UnitStoreGetData.StoreRecordNo;

            if (Accountancy != null && Accountancy.UnitStoreGetData != null)
                MKYS_CikisYapilanDepoKayitNo = Accountancy.UnitStoreGetData.StoreRecordNo;

            MKYS_MakbuzTarihi = TransactionDate; // TODO : Alınabilecek bir yer varsa alınacak
            MKYS_MakbuzNo = GetNextMKYS_MakbuzNo();

            foreach (StockActionSignDetail stockActionSignDetail in StockActionSignDetails)
            {
                if (stockActionSignDetail.SignUser != null)
                {
                    MKYS_TeslimEden = stockActionSignDetail.SignUser.Name;
                    break;
                }
            }

            SubStoreDefinition subStoreDefinition = DestinationStore as SubStoreDefinition;
            if (subStoreDefinition != null && subStoreDefinition.StoreResponsible != null)
            {
                MKYS_TeslimAlan = subStoreDefinition.StoreResponsible.Name;
                if (subStoreDefinition.StoreResponsible.Person != null && subStoreDefinition.StoreResponsible.Person.UniqueRefNo.HasValue)
                    MKYS_CikisYapilanKisiTCNo = subStoreDefinition.StoreResponsible.Person.UniqueRefNo.Value.ToString();
            }
        }

        public string ITSForOutDocument()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            ChattelDocumentOutputWithAccountancy stockAction = (ChattelDocumentOutputWithAccountancy)objectContext.GetObject(ObjectID, ObjectDef);

            if (String.IsNullOrEmpty(stockAction.PTSNumber) == true)
            {
                return this.SendITSTransferNotification(stockAction, objectContext);
            }
            else
            {
                return this.SendITSTransferCancellation(stockAction, objectContext);
            }
        }

        public string SendITSTransferNotification(ChattelDocumentOutputWithAccountancy stockAction, TTObjectContext objectContext)
        {
            TransferNotification.ItsRequest itsRequest = new TransferNotification.ItsRequest();
            var products = new List<TransferNotification.ItsRequestPRODUCT>();
            List<StockTransaction> trxs = new List<StockTransaction>();

            foreach (ChattelDocumentOutputDetailWithAccountancy outDetail in stockAction.ChattelDocumentOutputDetailsWithAccountancy)
            {
                foreach (ManuelReadQRCode qrcode in outDetail.ManuelReadQRCodes.Select(string.Empty))
                {
                    TransferNotification.ItsRequestPRODUCT itsRequestPRODUCT = new TransferNotification.ItsRequestPRODUCT();
                    itsRequestPRODUCT.GTIN = qrcode.Barcode;
                    itsRequestPRODUCT.SN = qrcode.SerialNo;
                    itsRequestPRODUCT.XD = (DateTime)qrcode.ExpirationDate;
                    itsRequestPRODUCT.BN = qrcode.LotNo;
                    products.Add(itsRequestPRODUCT);
                }
            }

            itsRequest.PRODUCTS = products.ToArray();
            itsRequest.TOGLN = ((IChattelDocumentOutputWithAccountancy)this).GetAccountancy().GetAccountancyNO().ToString(); // Gönderilen birimin kayıt numarası,**

            var response = TransferNotification.WebMethods.sendTransferNotificationSync(Sites.SiteLocalHost, itsRequest);
            if (string.IsNullOrEmpty(response.NOTIFICATIONID) == false)
            {
                stockAction.PTSNumber = response.NOTIFICATIONID;
                objectContext.Save();
                objectContext.Dispose();
                return response.NOTIFICATIONID;
            }
            else
            {
                return string.Empty;
            }

        }

        public string SendITSTransferCancellation(ChattelDocumentOutputWithAccountancy stockAction, TTObjectContext objectContext)
        {
            TransferCancellation.ItsPlainRequest itsPlainRequest = new TransferCancellation.ItsPlainRequest();
            List<StockTransaction> trxs = new List<StockTransaction>();
            var products = new List<TransferCancellation.ItsPlainRequestPRODUCT>();

            foreach (ChattelDocumentOutputDetailWithAccountancy outDetail in stockAction.ChattelDocumentOutputDetailsWithAccountancy)
            {
                foreach (ManuelReadQRCode qrcode in outDetail.ManuelReadQRCodes.Select(string.Empty))
                {
                    TransferCancellation.ItsPlainRequestPRODUCT itsRequestPRODUCT = new TransferCancellation.ItsPlainRequestPRODUCT();
                    itsRequestPRODUCT.GTIN = qrcode.Barcode;
                    itsRequestPRODUCT.SN = qrcode.SerialNo;
                    itsRequestPRODUCT.XD = (DateTime)qrcode.ExpirationDate;
                    itsRequestPRODUCT.BN = qrcode.LotNo;
                    products.Add(itsRequestPRODUCT);
                }
            }

            itsPlainRequest.PRODUCTS = products.ToArray();
            var response = TransferCancellation.WebMethods.sendTransferCancellationSync(Sites.SiteLocalHost, itsPlainRequest);
            if (string.IsNullOrEmpty(response.NOTIFICATIONID) == false)
            {
                stockAction.PTSNumber = null;
                objectContext.Save();
                objectContext.Dispose();
                return response.NOTIFICATIONID;
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChattelDocumentOutputWithAccountancy).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ChattelDocumentOutputWithAccountancy.States.Completed && toState == ChattelDocumentOutputWithAccountancy.States.Cancelled)
                PreTransition_Completed2Cancelled();
            if (fromState == ChattelDocumentOutputWithAccountancy.States.New && toState == ChattelDocumentOutputWithAccountancy.States.Approved)
                PreTransition_New2Approval();
            if (fromState == ChattelDocumentOutputWithAccountancy.States.Approved && toState == ChattelDocumentOutputWithAccountancy.States.Completed)
                PreTransition_Approval2Completed();
            if (fromState == ChattelDocumentOutputWithAccountancy.States.New && toState == ChattelDocumentOutputWithAccountancy.States.Completed)
                PreTransition_New2Completed();
        }

    }
}