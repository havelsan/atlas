
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


using static TTObjectClasses.SubEpisodeProtocol;
using System.Threading;

namespace TTObjectClasses
{
    /// <summary>
    /// Kurum Faturası Dökümanı
    /// </summary>
    public partial class PayerInvoiceDocument : AccountDocument
    {
        public partial class OLAP_GetPayerInvoiceDocument_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledPayerInvoiceDocument_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerInvoiceDocumentByPayer_Class : TTReportNqlObject
        {
        }

        #region Methods

        public PayerInvoiceDocument(TTObjectContext objectContext, DateTime documentDate, string documentNo, string documentID, string description, Currency totalPrice, PayerDefinition payer) : this(objectContext)
        {
            CreateDate = DateTime.Now;
            DocumentDate = documentDate;
            DocumentNo = documentNo;
            DocumentID = Convert.ToInt64(documentID);
            Description = description;
            TotalPrice = totalPrice;
            ResUser = Common.CurrentResource;
            Payer = payer;
            CurrentStateDefID = PayerInvoiceDocument.States.Invoiced;
            //TODO: AAE CashOffice set edilmeli.
        }

        public PayerInvoice MyPayerInvoice()
        {
            if (PayerInvoice == null)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(219, new string[] { DocumentNo }));
            else if (PayerInvoice.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(219, new string[] { DocumentNo }));
            else
                return PayerInvoice[0];

        }

        public FaturaKayitIslemleri.faturaOkuCevapDVO Read()
        {

            FaturaKayitIslemleri.faturaOkuGirisDVO faturaOkuGirisDVO = GetFaturaOkuGirisDVO();
            TTObjectClasses.XXXXXXMedulaServices.FaturaOkuParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.FaturaOkuParam(faturaOkuGirisDVO, this);
            FaturaKayitIslemleri.faturaOkuCevapDVO result = FaturaKayitIslemleri.WebMethods.faturaOkuSync(TTObjectClasses.Sites.SiteLocalHost, faturaOkuGirisDVO);
            inputParam.FaturaOkuCompletedInternal(result);

            return result;
        }

        public List<MedulaResult> Cancel()
        {
            // Sadece Kilitli veya Açık durumdaki İcmal içerisindeki faturalar iptal edilebilir (Hasta Faturası hariç)
            if (Payer.Type.PayerType != PayerTypeEnum.Paid)
            {
                foreach (InvoiceCollectionDetail icd in InvoiceCollectionDetails)
                {
                    if (icd.InvoiceCollection.CurrentStateDefID != InvoiceCollection.States.Locked && icd.InvoiceCollection.CurrentStateDefID != InvoiceCollection.States.Open)
                        throw new TTException(TTUtils.CultureService.GetText("M26779", "Sadece 'Kilitli' veya 'Açık' durumdaki İcmal içerisindeki fatura iptal edilebilir."));
                }
            }

            List<MedulaResult> result = new List<MedulaResult>();
            MedulaResult mr = null;
            if (Payer.Type.PayerType == PayerTypeEnum.SGK && Payer.OnlineInvoice.HasValue && Payer.OnlineInvoice.Value)
            {
                FaturaKayitIslemleri.faturaIptalCevapDVO ficd = new FaturaKayitIslemleri.faturaIptalCevapDVO();
                ficd = CancelMedulaInvoice();
                if (ficd.sonucKodu != null && (ficd.sonucKodu.Equals("9102") || ficd.sonucKodu.Equals("9103")))
                {
                    Thread.Sleep(500);
                    return Cancel();
                }
                if (ficd != null && ficd.hataliKayitlar != null)
                {
                    foreach (var hk in ficd.hataliKayitlar)
                    {
                        mr = new MedulaResult();
                        mr.TakipNo = hk.faturaTeslimNo;
                        mr.Succes = false;
                        mr.SonucKodu = hk.hataKodu;
                        mr.SonucMesaji = hk.hataMesaji;
                       
                        result.Add(mr);
                    }
                }
                mr = new MedulaResult();

                if (ficd.sonucKodu.Equals("0000"))
                    mr.Succes = true;
                else
                    mr.Succes = false;

                mr.SonucKodu = ficd.sonucKodu;
                mr.SonucMesaji = ficd.sonucMesaji;
                result.Add(mr);
            }
            else
            {
                if (CurrentStateDefID != PayerInvoiceDocument.States.Cancelled)
                {
                    DateTime nw = DateTime.Now;

                    if (InvoiceCollectionDetails.Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.PartialPaid || x.CurrentStateDefID == InvoiceCollectionDetail.States.Paid).Count() > 0)
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(218, new string[] { TTUtils.CultureService.GetText("M26990", "Tahsilat")}));

                    Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
                    int i = 1;
                    foreach (APRTrx myAPRTrx in APRTrx)
                    {
                        dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
                        i++;
                    }
                    foreach (KeyValuePair<string, APRTrx> myAPRTrx in dict)
                    {
                        APRTrx app = myAPRTrx.Value;
                        AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1), APRTrxType.GetByType(ObjectContext, 10)[0]); // 10 Belge Iptali
                    }

                    bool isPaid = false;
                    if (Payer.Type.PayerType == PayerTypeEnum.Paid)
                        isPaid = true;

                    foreach (PayerInvoiceDocumentGroup invGroup in PayerInvoiceDocumentGroups)
                    {
                        foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
                        {
                            if (!isPaid)
                                invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;
                            else
                                invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.Paid;

                            //invDetail.AccountTrxDocument[0].AccountTransaction.TotalDiscountPrice = 0;//İndirim uygulaması başlar ise açılacak
                            //invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Cancelled;
                        }
                    }

                    CurrentStateDefID = PayerInvoiceDocument.States.Cancelled;
                    CancelDate = DateTime.Now;
                    //CancelDescription = string.Empty; // Fatura iptal açıklaması istenirse yazılacak. Ayrıca PAYINVCANCELREASONDEF objesinde iptal nedeni tanımları da var.

                    List<InvoiceCollectionDetail> icdList = InvoiceCollectionDetails.ToList();
                    foreach (var icd in icdList)
                    {
                        icd.PayerInvoiceDocument = null;
                        icd.CurrentStateDefID = InvoiceCollectionDetail.States.New;
                        var SEPs = icd.SubEpisodeProtocols.ToList();
                        foreach (var sep in SEPs)
                        {
                            InvoiceLog.AddInfo(TTUtils.CultureService.GetText("M25631", "Fatura iptal edildi."), sep.ObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            if (!isPaid)
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InsideInvoiceCollection;
                            else
                            {
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                                sep.InvoiceCollectionDetail = null;
                            }

                            sep.CurrentStateDefID = SubEpisodeProtocol.States.Open;
                            sep.MedulaFaturaTutari = null;
                            //TODO: AAE Fatura Açıklaması koyulacak (İptal Açıklaması Olabilir.)
                            //sep.InvoiceDescription = null;
                            //sep.InvoiceCollectionDetail = null;

                            if (sep.InvoiceCancelCount == null)
                                sep.InvoiceCancelCount = 0;

                            sep.InvoiceCancelCount++;

                            CancelledInvoice ci = new CancelledInvoice(ObjectContext);
                            ci.SEP = sep;
                            ci.ICD = icd;
                            ci.PID = this;
                            ci.Date = nw;
                            ci.Type = CancelledInvoiceTypeEnum.Cancelled;
                            ci.User = Common.CurrentResource;
                        }
                    }
                }

                mr = new MedulaResult();
                mr.SonucKodu = "0000";
                mr.SonucMesaji = TTUtils.CultureService.GetText("M25633", "Fatura iptal işlemi başarı ile tamamlandı");
                result.Add(mr);
            }
            return result;
        }

        public List<SubEpisodeProtocol> SEPs
        {
            get
            {
                List<SubEpisodeProtocol> result = new List<SubEpisodeProtocol>();

                foreach (var icd in InvoiceCollectionDetails)
                {
                    foreach (var sep in icd.SubEpisodeProtocols)
                    {
                        if (sep.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled)
                            result.Add(sep);
                    }
                }

                return result;
            }

        }

        public string ControlAndGetInvoiceNumber()
        {
            InvoiceCollectionDetail icd = InvoiceCollectionDetails?.FirstOrDefault();

            if (icd == null)
                throw new TTException(TTUtils.CultureService.GetText("M25672", "Faturanın icmal detay bilgisine ulaşılamadığı için numara alınamadı."));

            if (icd.InvoiceCollection == null)
                throw new TTException("İcmal Detay ın İcmal bilgisine ulaşılamadığı için numara alınamadı.");

            if (icd.InvoiceCollection.Type == null)
                throw new TTException(TTUtils.CultureService.GetText("M26004", "İcmal in icmal tipi alanı boş. Fatura numarası alınamaz."));


            if (icd.InvoiceCollection.Type == InvoiceCollectionTypeEnum.SeperateInvoice)
                DocumentNo = GetInvoiceNumber();
            else if (icd.InvoiceCollection.Type == InvoiceCollectionTypeEnum.CollectedInvoice)
            {
                InvoiceCollectionDetail icdInner = icd.InvoiceCollection.InvoiceCollectionDetails.
                                                                    Where(x => x.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced
                                                                    && x.PayerInvoiceDocument != null && x.PayerInvoiceDocument.ObjectID != ObjectID).
                                                                    FirstOrDefault();
                if (icdInner != null)
                {
                    if (!string.IsNullOrEmpty(icdInner.PayerInvoiceDocument.DocumentNo))
                        DocumentNo = icdInner.PayerInvoiceDocument.DocumentNo;
                    else
                        throw new TTException(TTUtils.CultureService.GetText("M26003", "İcmal içerisindeki numarası boş olan fatura bulundu. Kontrol ediniz."));
                }
                else
                    DocumentNo = GetInvoiceNumber();
            }


            return DocumentNo;
        }

        public string GetInvoiceNumber()
        {
            //var cocud = this.ObjectContext.QueryObjects<CashOfficeComputerUserDefinition>().Where(x => x.ResUser.ObjectID == Common.CurrentResource.ObjectID 
            //                                                                                        && x.CashOffice.Type == CashOfficeTypeEnum.InvoicingService).FirstOrDefault();
            //if(cocud == null)
            //    throw new TTException(SystemMessage.GetMessage(121));

            //InvoiceCashOfficeDefinition myInvoiceCashOffice = (InvoiceCashOfficeDefinition)InvoiceCashOfficeDefinition.GetByCashOffice(this.ObjectContext, cocud.CashOffice.ObjectID.ToString())[0];

            //if(myInvoiceCashOffice == null)
            //    throw new TTException(cocud.CashOffice.Name + " için fatura numarası tanımlanmamıştır.");


            //string result = InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(myInvoiceCashOffice);

            //InvoiceCashOfficeDefinition.SetNextInvoiceNumber(myInvoiceCashOffice);

            Guid InvoiceNumber = new Guid("ed852276-bc44-4587-b8fc-0bb23e68da38");

            return TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[InvoiceNumber], null, null).ToString(); ;
        }


        #region MEDULA INVOICE
        public FaturaKayitIslemleri.faturaIptalCevapDVO CancelMedulaInvoice()
        {
            FaturaKayitIslemleri.faturaIptalGirisDVO faturaIptalGirisDVO = GetFaturaIptalGirisDVO();
            TTObjectClasses.XXXXXXMedulaServices.FaturaKaydiIptalParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.FaturaKaydiIptalParam(faturaIptalGirisDVO, this);
            FaturaKayitIslemleri.faturaIptalCevapDVO result = FaturaKayitIslemleri.WebMethods.faturaIptalSync(TTObjectClasses.Sites.SiteLocalHost, faturaIptalGirisDVO);
            inputParam.FaturaKaydiIptalCompletedInternal(result);
            return result;
        }

        public FaturaKayitIslemleri.faturaIptalGirisDVO GetFaturaIptalGirisDVO()
        {
            FaturaKayitIslemleri.faturaIptalGirisDVO result = new FaturaKayitIslemleri.faturaIptalGirisDVO();
            result.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            result.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            result.faturaTeslimNo = new string[] { DocumentNo };
            return result;
        }

        public FaturaKayitIslemleri.faturaOkuGirisDVO GetFaturaOkuGirisDVO()
        {
            FaturaKayitIslemleri.faturaOkuGirisDVO result = new FaturaKayitIslemleri.faturaOkuGirisDVO();
            result.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            result.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            result.faturaTeslimNo = DocumentNo;
            result.faturaRefNo = DocumentID.ToString();
            result.faturaTarihi = DocumentDate.Value.ToString("dd.MM.yyyy");
            return result;
        }

        #endregion

        //TODO: AAE Resmi kurum faturaları için kullanılabilir. Geçici olarak kapatıldı.
        //public void Cancel(EpisodeProtocol ep)
        //{
        //    if (this.CurrentStateDefID != PayerInvoiceDocument.States.Cancelled)
        //    {
        //        //Document APR larına ters kayıt olustur

        //        Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
        //        int i = 1;
        //        foreach(APRTrx myAPRTrx in this.APRTrx)
        //        {
        //            dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
        //            i ++;
        //        }
        //        foreach(KeyValuePair<string, APRTrx> myAPRTrx in dict)
        //        {
        //            APRTrx app = myAPRTrx.Value;
        //            this.AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1),APRTrxType.GetByType(this.ObjectContext, 10)[0]); // 10 Belge Iptali
        //        }

        //        foreach (PayerInvoiceDocumentGroup invGroup in this.PayerInvoiceDocumentGroups)
        //        {
        //            foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
        //            {
        //                if(invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure != null && invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure is OrthesisProsthesisProcedure)
        //                {
        //                    if(this.EpisodeAccountAction.Episode.IsMedulaEpisode()) // SGK'lı hasta ise Ortez-Protez işlemi Medulaya Gönderilmeyecek durumuna alınır
        //                        invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
        //                    else
        //                        invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;
        //                }
        //                else
        //                    invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;

        //                invDetail.AccountTrxDocument[0].AccountTransaction.TotalDiscountPrice = 0;
        //                invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Cancelled;
        //            }
        //        }
        //        this.CurrentStateDefID = PayerInvoiceDocument.States.Cancelled;

        //        // Paket içindeki AccountTransaction ların durumunu New e döndürür
        //        PayerInvoice pInvoice;
        //        pInvoice = this.PayerInvoice[0];

        //        if (pInvoice.PayerInvoicePackages.Count > 0)
        //        {
        //            foreach (PayerInvoicePackage invpack in pInvoice.PayerInvoicePackages)
        //            {
        //                if (invpack.Paid == true)
        //                {
        //                   /* TODO:SEP
        //                    foreach (AccountTransaction accTrx in ep.GetTransactionsForInvoice(AccountTransaction.States.Invoiced, ep.Payer.MyAPR()))
        //                    {
        //                        if (accTrx.PackageDefinition != null)
        //                        {
        //                            if (accTrx.PackageDefinition == invpack.PackageAccountTransaction[0].SubActionProcedure.PackageDefinition)
        //                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                        }
        //                    }
        //                    */
        //                }
        //            }
        //        }
        //        //this.CreateInvoiceInfoAndSendToAccounting(); // ters hareket için
        //    }
        //}

        //public void CancelSend(EpisodeProtocol ep)
        //{
        //    if (this.CurrentStateDefID != PayerInvoiceDocument.States.Cancelled)
        //    {
        //        // Fatura Gönderme işlemindeki satırın Send i false yapılıp
        //        foreach(InvoicePostDetail postDetail in this.InvoicePostDetail)
        //        {
        //            if(postDetail.Send == true && postDetail.InvoicePosting.CurrentStateDefID == InvoicePosting.States.InvoicePosted)
        //            {
        //                postDetail.Send = false;
        //                postDetail.InvoicePosting.TotalPrice -= this.GeneralTotalPrice;
        //                break;
        //            }
        //        }

        //        //Document APR larına ters kayıt olustur
        //        Dictionary<string, APRTrx> dict = new Dictionary<string, APRTrx>();
        //        int i = 1;
        //        foreach(APRTrx myAPRTrx in this.APRTrx)
        //        {
        //            dict.Add("myAPRTrx" + i.ToString(), myAPRTrx);
        //            i ++;
        //        }
        //        foreach(KeyValuePair<string, APRTrx> myAPRTrx in dict)
        //        {
        //            APRTrx app = myAPRTrx.Value;
        //            this.AddAPRTransaction(app.AccountPayableReceivable, (double)(app.Price * -1),APRTrxType.GetByType(this.ObjectContext, 10)[0]); // 10 Belge Iptali
        //        }

        //        foreach (PayerInvoiceDocumentGroup invGroup in this.PayerInvoiceDocumentGroups)
        //        {
        //            foreach (PayerInvoiceDocumentDetail invDetail in invGroup.PayerInvoiceDocumentDetails)
        //            {
        //                if(invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure != null && invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure is OrthesisProsthesisProcedure)
        //                {
        //                    if(this.EpisodeAccountAction.Episode.IsMedulaEpisode()) // SGK'lı hasta ise Ortez-Protez işlemi Medulaya Gönderilmeyecek durumuna alınır
        //                        invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
        //                    else
        //                        invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;
        //                }
        //                else
        //                    invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;

        //                invDetail.AccountTrxDocument[0].AccountTransaction.TotalDiscountPrice = 0;
        //                invDetail.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Cancelled;
        //            }
        //        }
        //        this.CurrentStateDefID = PayerInvoiceDocument.States.Cancelled;

        //        // Paket içindeki AccountTransaction ların durumunu New e döndürür
        //        PayerInvoice pInvoice;
        //        pInvoice = this.PayerInvoice[0];

        //        if (pInvoice.PayerInvoicePackages.Count > 0)
        //        {
        //            foreach (PayerInvoicePackage invpack in pInvoice.PayerInvoicePackages)
        //            {
        //                if (invpack.Paid == true)
        //                {
        //                   /* TODO:SEP
        //                    foreach (AccountTransaction accTrx in ep.GetTransactionsForInvoice(AccountTransaction.States.Send, ep.Payer.MyAPR()))
        //                    {
        //                        if (accTrx.PackageDefinition != null)
        //                        {
        //                            if (accTrx.PackageDefinition == invpack.PackageAccountTransaction[0].SubActionProcedure.PackageDefinition)
        //                                accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                        }
        //                    }
        //                    */
        //                }
        //            }
        //        }
        //    }
        //}

        //public AccountDocument.InvoiceInfo CreateInvoiceInfoForAccounting()
        //{
        //    AccountDocument.InvoiceInfo II = null;

        //    if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
        //    {
        //        if ((this.CurrentStateDefID == PayerInvoiceDocument.States.Invoiced || this.CurrentStateDefID == PayerInvoiceDocument.States.Send || this.CurrentStateDefID == PayerInvoiceDocument.States.Paid) && this.SendToAccounting == false)
        //        {
        //            II = new AccountDocument.InvoiceInfo();
        //            this.CreateBasicInvoiceInfo(ref II);
        //            II.PayerName = ((PayerInvoice)this.EpisodeAccountAction).Payer.Code + " " + ((PayerInvoice)this.EpisodeAccountAction).Payer.Name;
        //            II.TotalPrice = (double)this.EpisodeAccountAction.TotalPrice;

        //            II.Lines = new List<AccountDocument.InvoiceLine>();

        //            if (this.EpisodeAccountAction.TotalDiscountPrice != null) // indirim
        //            {
        //                if (this.EpisodeAccountAction.TotalDiscountPrice > 0)
        //                {
        //                    AccountDocument.InvoiceLine iLine1 = new AccountDocument.InvoiceLine();
        //                    iLine1.Description = "İndirim Hesabı";
        //                    iLine1.AccountCode = this.GetAccountCode(AccountEntegrationAccountTypeEnum.IndirimHesabi);
        //                    iLine1.IsDebt = true;
        //                    iLine1.Price = (double)this.EpisodeAccountAction.TotalDiscountPrice;
        //                    iLine1.CurrencyRate = 1;
        //                    II.Lines.Add(iLine1);
        //                }
        //            }

        //            if (this.EpisodeAccountAction.GeneralTotalPrice != null) // indirimden sonraki (net) fatura tutarı kadar kurum borçlandırılır
        //            {
        //                if (this.EpisodeAccountAction.GeneralTotalPrice > 0)
        //                {
        //                    AccountDocument.InvoiceLine iLine2 = new AccountDocument.InvoiceLine();
        //                    iLine2.Description = "Kurum Hesabı";
        //                    iLine2.AccountCode = ((PayerInvoice)this.EpisodeAccountAction).Payer.GetAccountCode();
        //                    iLine2.IsDebt = true;
        //                    iLine2.Price = (double)this.EpisodeAccountAction.GeneralTotalPrice;
        //                    iLine2.CurrencyRate = 1;
        //                    II.Lines.Add(iLine2);
        //                }
        //            }

        //            // hizmet ve malzemeler gelir hesaplarına göre gruplanır

        //            string accountCodeStart = "";
        //            string accountCode = "";
        //            bool addLine = true;
        //            double lineTotal = 0;
        //            RevenueSubAccountCodeDefinition revenueCode = null;

        //            if (this.EpisodeAccountAction.Episode.Patient.Foreign == true)
        //                accountCodeStart = "601."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";
        //            else
        //                accountCodeStart = "600."; // + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + ".";

        //            // malzemeleri ekler
        //            foreach (PayerInvoiceMaterial invMat in ((PayerInvoice)this.EpisodeAccountAction).PayerInvoiceMaterials)
        //            {
        //                if (invMat.Paid == true)
        //                    lineTotal = lineTotal + (double)invMat.TotalPrice;
        //            }

        //            if (lineTotal > 0)
        //            {
        //                AccountDocument.InvoiceLine iLine3 = new AccountDocument.InvoiceLine();
        //                iLine3.Description = "İlaç ve Tıbbi Sarf Malzemesi Gelirleri";
        //                iLine3.AccountCode = accountCodeStart + "08";
        //                iLine3.IsDebt = false;
        //                iLine3.Price = (double)lineTotal;
        //                iLine3.CurrencyRate = 1;
        //                II.Lines.Add(iLine3);
        //            }

        //            // hizmetleri ekler
        //            foreach (PayerInvoiceProcedure invProc in ((PayerInvoice)this.EpisodeAccountAction).PayerInvoiceProcedures)
        //            {
        //                if (invProc.Paid == true)
        //                {
        //                    accountCode = "";
        //                    addLine = true;
        //                    revenueCode = null;
        //                    revenueCode = invProc.AccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();

        //                    if (revenueCode == null)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(127, new string[] {invProc.ExternalCode , invProc.Description}));
        //                    else
        //                    {
        //                        if ((double)invProc.TotalPrice > 0)
        //                        {
        //                            accountCode = accountCodeStart + revenueCode.AccountCode;

        //                            foreach (AccountDocument.InvoiceLine iLine in II.Lines)
        //                            {
        //                                if (iLine.AccountCode == accountCode)
        //                                {
        //                                    iLine.Price = iLine.Price + (double)invProc.TotalPrice; // line larda var, fiyata ekle
        //                                    addLine = false;
        //                                    break;
        //                                }
        //                            }
        //                            if (addLine)  // line larda yok, yeni line ekle
        //                            {
        //                                AccountDocument.InvoiceLine iLine4 = new AccountDocument.InvoiceLine();
        //                                iLine4.Description = revenueCode.Description;
        //                                iLine4.AccountCode = accountCode;
        //                                iLine4.IsDebt = false;
        //                                iLine4.Price = (double)invProc.TotalPrice;
        //                                iLine4.CurrencyRate = 1;
        //                                II.Lines.Add(iLine4);
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            // paketleri ekler
        //            foreach (PayerInvoicePackage invPack in ((PayerInvoice)this.EpisodeAccountAction).PayerInvoicePackages)
        //            {
        //                if (invPack.Paid == true)
        //                {
        //                    accountCode = "";
        //                    addLine = true;
        //                    revenueCode = null;
        //                    revenueCode = invPack.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();

        //                    if (revenueCode == null)
        //                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(220, new string[] {invPack.PackageCode , invPack.PackageName}));
        //                    else
        //                    {
        //                        if ((double)invPack.TotalPrice > 0)
        //                        {
        //                            accountCode = accountCodeStart + revenueCode.AccountCode;

        //                            foreach (AccountDocument.InvoiceLine iLine in II.Lines)
        //                            {
        //                                if (iLine.AccountCode == accountCode)
        //                                {
        //                                    iLine.Price = iLine.Price + (double)invPack.TotalPrice; // line larda var, fiyata ekle
        //                                    addLine = false;
        //                                    break;
        //                                }
        //                            }
        //                            if (addLine)  // line larda yok, yeni line ekle
        //                            {
        //                                AccountDocument.InvoiceLine iLine5 = new AccountDocument.InvoiceLine();
        //                                iLine5.Description = revenueCode.Description;
        //                                iLine5.AccountCode = accountCode;
        //                                iLine5.IsDebt = false;
        //                                iLine5.Price = (double)invPack.TotalPrice;
        //                                iLine5.CurrencyRate = 1;
        //                                II.Lines.Add(iLine5);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            this.CreateInvoiceLineObjectIDs(II);
        //            this.ControlInvoiceInfo(II, "Kurum Faturası");
        //        }
        //    }
        //    return II;
        //}


        #endregion Methods

    }
}