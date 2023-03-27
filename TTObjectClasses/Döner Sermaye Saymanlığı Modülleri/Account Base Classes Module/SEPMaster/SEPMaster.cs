
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
    public partial class SEPMaster : TTObject
    {

        public void loadParameters(List<SubEpisodeProtocol> _SEPs, DateTime _invoiceDate, string _description)
        {
            SEPs = _SEPs;
            invoiceDate = _invoiceDate;
            description = _description;
        }

        public void loadParameters(List<SubEpisodeProtocol> _SEPs)
        {
            SEPs = _SEPs;
        }

        public List<SubEpisodeProtocol> SEPs;
        DateTime invoiceDate;
        string description;

        public Dictionary<Guid, InvoiceCollection> invoiceCollectionList;

        private bool ControlAndChangeExaminationOperation(string medulaTakipNo, bool vakaToHizmet)
        {
            var objectContext = ObjectContext;

            SubEpisodeProtocol sep = objectContext.QueryObjects<SubEpisodeProtocol>(" MEDULATAKIPNO = '" + medulaTakipNo + "'").FirstOrDefault();
            if (sep != null)
            {
                AccountTransaction actx = sep.AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful &&
                x.SubActionProcedure != null && ((vakaToHizmet && x.SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
                                                    || (!vakaToHizmet && !string.IsNullOrEmpty(x.ExternalCode) && x.ExternalCode.Equals("520030")))).FirstOrDefault();

                List<string> ssList = new List<string>();
                List<Guid> accountTransactionIDs = new List<Guid>();

                if (!string.IsNullOrEmpty(actx.MedulaProcessNo))
                {
                    ssList.Add(actx.MedulaProcessNo.ToString());
                    accountTransactionIDs.Add(actx.ObjectID);
                }

                MedulaResult medulaResult = sep.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                if (medulaResult != null && medulaResult.SonucKodu != null)
                {
                    if (medulaResult.SonucKodu.Equals("0000"))
                    {
                        actx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;

                        objectContext.Save();

                        AccountTransaction actxToMedula = sep.AccountTransactions.Select("").Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled &&
                                                    x.SubActionProcedure != null && ((!vakaToHizmet && x.SubActionProcedure.ProcedureObject is BulletinProcedureDefinition)
                                                                                    || (vakaToHizmet && !string.IsNullOrEmpty(x.ExternalCode) && x.ExternalCode.Equals("520030")))).FirstOrDefault();
                        if (actxToMedula != null)
                        {
                            List<Guid> actrxGuidList = new List<Guid>();
                            actrxGuidList.Add(actxToMedula.ObjectID);
                            actxToMedula.CurrentStateDefID = AccountTransaction.States.New;
                            objectContext.Save();
                            sep.HizmetKayitSync(true, actrxGuidList);

                            //if (sep != null)
                            //    sep.SetInvoiceStatusAfterProcedureEntry();
                            //objectContext.Save();
                            return true;
                        }
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        public MedulaResult deleteAllMedulaProvision()
        {
            List<SubEpisodeProtocol> sepList = SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && !string.IsNullOrEmpty(x.MedulaTakipNo)).OrderByDescending(x => x.MedulaTakipNo).ToList();
            MedulaResult mr = new MedulaResult();
            foreach (SubEpisodeProtocol sep in sepList)
            {
                if (!string.IsNullOrEmpty(sep.MedulaTakipNo))
                    mr = sep.DeleteProvisionFromMedulaRecursive(0);
            }
            return mr;
        }

        public MedulaResult getProvisionToAllSEP()
        {
            List<SubEpisodeProtocol> sepList = SubEpisodeProtocols.Where(x => x.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled && string.IsNullOrEmpty(x.MedulaTakipNo)).OrderBy(x => x.CreationDate).ToList();
            MedulaResult mr = new MedulaResult();
            foreach (SubEpisodeProtocol sep in sepList)
            {
                mr = sep.GetProvisionFromMedula();
                sep.ObjectContext.Save();
            }
            return mr;
        }

        public List<MedulaResult> SaveInvoice(List<SubEpisodeProtocol> _SEPs, DateTime _invoiceDate, string _description, Guid _invoiceCollection, int type)
        {
            loadParameters(_SEPs, _invoiceDate, _description);
            List<MedulaResult> result = new List<MedulaResult>();
            FaturaKayitIslemleri.faturaCevapDVO fcd = new FaturaKayitIslemleri.faturaCevapDVO();
            try
            {
                if (SEPs != null && SEPs.Count > 0 && SEPs[0].Payer.Type.PayerType == PayerTypeEnum.SGK && (SEPs[0].Payer.OnlineInvoice.HasValue && SEPs[0].Payer.OnlineInvoice.Value))
                {
                    fcd = SaveMedulaInvoice(type);
                    if (fcd.sonucKodu != null && (fcd.sonucKodu.Equals("9102") || fcd.sonucKodu.Equals("9103")))
                    {
                        Thread.Sleep(5000);
                        return SaveInvoice(_SEPs, _invoiceDate, _description, _invoiceCollection, type);
                    }
                    MedulaResult mr = null;
                    if (fcd != null && fcd.hataliKayitlar != null)
                    {
                        foreach (var hk in fcd.hataliKayitlar)
                        {
                            if (hk.hataKodu != null && hk.hataKodu.Equals("1544"))
                            {
                                ControlAndChangeExaminationOperation(hk.takipNo, true);
                                return SaveInvoice(_SEPs, _invoiceDate, _description, _invoiceCollection, type);
                            }
                            else if (hk.hataKodu != null && hk.hataKodu.Equals("1376"))
                            {
                                ControlAndChangeExaminationOperation(hk.takipNo, false);
                                return SaveInvoice(_SEPs, _invoiceDate, _description, _invoiceCollection, type);
                            }
                            mr = new MedulaResult();
                            mr.TakipNo = hk.takipNo;
                            mr.Succes = false;
                            mr.SonucKodu = hk.hataKodu;
                            mr.SonucMesaji = hk.hataMesaji;
                            mr.SEPObjectID = SEPs[0].ObjectID;
                            result.Add(mr);
                        }
                    }
                    mr = new MedulaResult();

                    if (fcd.sonucKodu.Equals("0000"))
                        mr.Succes = true;
                    else
                        mr.Succes = false;

                    mr.SEPObjectID = SEPs[0].ObjectID;
                    mr.SonucKodu = fcd.sonucKodu;
                    mr.SonucMesaji = fcd.sonucMesaji;
                    result.Add(mr);
                }
                else
                    result = SaveOfficialInvoice(_invoiceCollection);
            }
            catch (Exception ex)
            {
                throw new TTException(ex.Message);
            }
            return result;
        }


        public bool ArrangeInvoice(List<SubEpisodeProtocol> _SEPs)
        {
            loadParameters(_SEPs);
            List<HastaKabulIslemleri.takipDVO> listOfTakip = new List<HastaKabulIslemleri.takipDVO>();
            Dictionary<string, string> listOfFaturaTeslimNoDate = new Dictionary<string, string>();
            invoiceCollectionList = new Dictionary<Guid, InvoiceCollection>();
            foreach (var sep in SEPs)
            {
                try
                {
                    HastaKabulIslemleri.takipDVO tempTakip = sep.ReadProvisionFromMedula();
                    if (tempTakip != null)
                    {
                        listOfTakip.Add(tempTakip);

                        if (!string.IsNullOrEmpty(tempTakip.faturaTeslimNo) && tempTakip.faturaTeslimNo != "0")
                        {
                            bool addToList = false;
                            if (!sep.IsInvoiced || sep.InvoiceCollectionDetail == null) // Faturalandı durumda değil veya InvoiceCollectionDetail null
                            {
                                addToList = true;
                            }
                            else if (!string.IsNullOrWhiteSpace(sep.MedulaTakipNo)) // Medula ve Atlas'taki fatura tutarı uyumsuz mu ?
                            {
                                FaturaKayitIslemleri.faturaOkuGirisDVO faturaOkuGirisDVO = new FaturaKayitIslemleri.faturaOkuGirisDVO();
                                faturaOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                                faturaOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                                faturaOkuGirisDVO.faturaTeslimNo = tempTakip.faturaTeslimNo;
                                faturaOkuGirisDVO.faturaTarihi = tempTakip.faturaTarihi;

                                FaturaKayitIslemleri.faturaOkuCevapDVO result = FaturaKayitIslemleri.WebMethods.faturaOkuSync(Sites.SiteLocalHost, faturaOkuGirisDVO);

                                if (result.faturaDetaylari != null && result.faturaDetaylari.Length > 0)
                                {
                                    foreach (var fd in result.faturaDetaylari)
                                    {
                                        if (fd != null && fd.takipNo == sep.MedulaTakipNo)
                                        {
                                            if (fd.takipToplamTutar != sep.MedulaFaturaTutari)
                                                addToList = true;
                                            else
                                            {
                                                List<AccountTransaction> SEPAccTrxList = sep.AccountTransactions.Select("CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND MEDULAPRICE IS NOT NULL").ToList();
                                                decimal sepAccTrxTotal = SEPAccTrxList.Select(x => (decimal)x.MedulaPrice.Value).Sum();

                                                if ((decimal)fd.takipToplamTutar != sepAccTrxTotal)
                                                    addToList = true;
                                            }
                                            break;
                                        }
                                    }
                                }
                            }

                            if (addToList)
                            {
                                if (!listOfFaturaTeslimNoDate.ContainsKey(tempTakip.faturaTeslimNo))
                                    listOfFaturaTeslimNoDate.Add(tempTakip.faturaTeslimNo, tempTakip.faturaTarihi);

                                InvoiceCollection ic = sep.GetMyInvoiceCollection(Convert.ToDateTime(tempTakip.faturaTarihi), true);
                                invoiceCollectionList.Add(sep.ObjectID, ic);
                            }
                        }
                        else if (sep.IsInvoiced && (string.IsNullOrEmpty(tempTakip.faturaTeslimNo) || tempTakip.faturaTeslimNo == "0"))
                        {
                            CancelledInvoice ci = new CancelledInvoice(sep.ObjectContext);
                            ci.SEP = sep;
                            ci.ICD = sep.InvoiceCollectionDetail;
                            ci.PID = sep.InvoiceCollectionDetail.PayerInvoiceDocument;
                            ci.Date = DateTime.Now; ;
                            ci.Type = CancelledInvoiceTypeEnum.Cancelled;
                            ci.User = Common.CurrentResource;

                            sep.InvoiceCollectionDetail.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.Cancelled;
                            sep.InvoiceCollectionDetail.PayerInvoiceDocument.CancelDate = DateTime.Now;
                            //_pid.CancelDescription = string.Empty; // Fatura iptal açıklaması istenirse yazılacak. Ayrıca PAYINVCANCELREASONDEF objesinde iptal nedeni tanımları da var.

                            sep.InvoiceCollectionDetail.CurrentStateDefID = InvoiceCollectionDetail.States.Cancelled;
                            sep.InvoiceCollectionDetail.PayerInvoiceDocument = null;

                            sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted;
                            sep.CurrentStateDefID = SubEpisodeProtocol.States.Open;
                            sep.MedulaFaturaTutari = null;
                            //TODO: AAE Fatura Açıklaması koyulacak (İptal Açıklaması Olabilir.)
                            //sep.InvoiceDescription = null;
                            sep.InvoiceCollectionDetail = null;
                            InvoiceLog.AddInfo("Fatura düzeltme sırasında medulada fatura kaydı bulunumadı ve HBYS fatura kayıtları iptal edildi. ", sep.ObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            if (sep.InvoiceCancelCount == null)
                                sep.InvoiceCancelCount = 0;

                            sep.InvoiceCancelCount++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            foreach (var ftnd in listOfFaturaTeslimNoDate)
            {
                FaturaKayitIslemleri.faturaOkuGirisDVO faturaOkuGirisDVO = new FaturaKayitIslemleri.faturaOkuGirisDVO();
                faturaOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                faturaOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
                faturaOkuGirisDVO.faturaTeslimNo = ftnd.Key;
                faturaOkuGirisDVO.faturaTarihi = ftnd.Value;

                FaturaKayitIslemleri.faturaOkuCevapDVO result = FaturaKayitIslemleri.WebMethods.faturaOkuSync(Sites.SiteLocalHost, faturaOkuGirisDVO);

                if (result.sonucKodu.Equals("0000"))
                {
                    try
                    {
                        ArrangeInvoiceCompletedInternal(result, ObjectContext);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                else
                    throw new TTException("Fatura okuma sırasında hata oluştu. " + result.sonucMesaji);
            }

            return true;
        }

        public void ArrangeInvoiceCompletedInternal(FaturaKayitIslemleri.faturaOkuCevapDVO result, TTObjectContext _context)
        {
            if (result.faturaDetaylari != null && result.faturaDetaylari.Length > 0)
            {
                PayerInvoiceDocument pid = null;

                BindingList<PayerInvoiceDocument> pidList = _context.QueryObjects<PayerInvoiceDocument>("CURRENTSTATE <> STATES.CANCELLED AND DOCUMENTNO = '" + result.faturaTeslimNo + "'");
                if (pidList != null && pidList.Count > 0)
                    pid = pidList.First();
                else
                    pid = new PayerInvoiceDocument(_context, Convert.ToDateTime(result.faturaTarihi), result.faturaTeslimNo, result.faturaRefNo, string.Empty, result.faturaTutari, SEPs[0].Payer);

                foreach (var fd in result.faturaDetaylari)
                {
                    if (fd != null)
                    {
                        SubEpisodeProtocol sep = SEPs.Where(s => s.MedulaTakipNo.Equals(fd.takipNo)).FirstOrDefault();
                        if (sep != null)
                        {
                            InvoiceLog.AddInfo("Fatura kayıt düzenleme işlemi başarı ile yapıldı. Fatura Teslim No: " + result.faturaTeslimNo, sep.ObjectID, InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol, _context);

                            sep.MedulaSonucKodu = result.sonucKodu;
                            sep.MedulaSonucMesaji = result.sonucMesaji;
                            double? total = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND INVOICEINCLUSION = 1 ").Sum(x => x.UnitPrice * x.Amount);
                            if (total.HasValue && Math.Round(total.Value, 2) != fd.takipToplamTutar)
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceInconsistent;
                            else
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.Invoiced;

                            sep.MedulaFaturaTutari = fd.takipToplamTutar;

                            List<AccountTransaction> accTrxList = sep.AccountTransactions.Select("").ToList();

                            foreach (var islem in fd.islemDetaylari)
                            {
                                AccountTransaction acctrx = accTrxList.Where(x => x.MedulaProcessNo == islem.islemSiraNo).FirstOrDefault();

                                // islemSiraNo dan bulamazsa, hizmetSunucuRefNo dan bulmaya çalışılır
                                if (acctrx == null)
                                {
                                    List<string> mpList = new List<string>() { islem.islemSiraNo };
                                    string hizmetSunucuRefNo = null;

                                    HizmetKayitIslemleri.hizmetOkuCevapDVO hizmetOkuCevapDVO = sep.HizmetKayitOkuSync(new List<string>(), mpList);
                                    if (hizmetOkuCevapDVO.sonucKodu.Equals("0000"))
                                    {
                                        if (hizmetOkuCevapDVO.hizmetler.muayeneBilgisi != null)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.muayeneBilgisi.hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.hastaYatisBilgileri != null && hizmetOkuCevapDVO.hizmetler.hastaYatisBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.hastaYatisBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.ameliyatveGirisimBilgileri != null && hizmetOkuCevapDVO.hizmetler.ameliyatveGirisimBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.ameliyatveGirisimBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.digerIslemBilgileri != null && hizmetOkuCevapDVO.hizmetler.digerIslemBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.digerIslemBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.disBilgileri != null && hizmetOkuCevapDVO.hizmetler.disBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.disBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.ilacBilgileri != null && hizmetOkuCevapDVO.hizmetler.ilacBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.ilacBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.kanBilgileri != null && hizmetOkuCevapDVO.hizmetler.kanBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.kanBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.konsultasyonBilgileri != null && hizmetOkuCevapDVO.hizmetler.konsultasyonBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.konsultasyonBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.malzemeBilgileri != null && hizmetOkuCevapDVO.hizmetler.malzemeBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.malzemeBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.tahlilBilgileri != null && hizmetOkuCevapDVO.hizmetler.tahlilBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.tahlilBilgileri[0].hizmetSunucuRefNo;
                                        else if (hizmetOkuCevapDVO.hizmetler.tetkikveRadyolojiBilgileri != null && hizmetOkuCevapDVO.hizmetler.tetkikveRadyolojiBilgileri.Count() > 0)
                                            hizmetSunucuRefNo = hizmetOkuCevapDVO.hizmetler.tetkikveRadyolojiBilgileri[0].hizmetSunucuRefNo;

                                        if (!string.IsNullOrWhiteSpace(hizmetSunucuRefNo))
                                        {
                                            long acctrxId = Convert.ToInt64(hizmetSunucuRefNo.Substring(1, hizmetSunucuRefNo.Length - 1));
                                            acctrx = accTrxList.Where(x => x.Id.Value == acctrxId).FirstOrDefault();
                                        }
                                    }
                                }

                                if (acctrx != null && acctrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                {
                                    acctrx.MedulaPrice = islem.islemTutari;
                                    acctrx.MedulaProcessNo = islem.islemSiraNo;

                                    if (acctrx.CurrentStateDefID == AccountTransaction.States.MedulaDontSend)  // MedulaDontSend ten MedulaEntrySuccessful a geçiş yok
                                    {
                                        acctrx.CurrentStateDefID = AccountTransaction.States.New;
                                        _context.Update();
                                    }

                                    acctrx.CurrentStateDefID = AccountTransaction.States.MedulaEntrySuccessful;

                                    if (acctrx.InvoiceInclusion == false && islem.islemTutari > 0)
                                        acctrx.InvoiceInclusion = true;
                                }
                            }

                            InvoiceCollection ic;
                            if (invoiceCollectionList.TryGetValue(sep.ObjectID, out ic))
                            {
                                if (sep.InvoiceCollectionDetail != null)
                                {
                                    sep.InvoiceCollectionDetail.CurrentStateDefID = InvoiceCollectionDetail.States.Cancelled;
                                    sep.InvoiceCollectionDetail = null;
                                }
                                sep.CreateInvoiceCollectionDetail(ic, InvoiceCollectionDetail.States.Invoiced, pid);
                            }
                        }
                    }
                }
            }
        }

        public List<MedulaResult> ReadInvoicePrice(List<SubEpisodeProtocol> _SEPs, DateTime _invoiceDate, string _description)
        {
            loadParameters(_SEPs, _invoiceDate, _description);
            if (SEPs != null && SEPs.Count > 0)
            {
                List<MedulaResult> result = new List<MedulaResult>();
                FaturaKayitIslemleri.faturaCevapDVO fcd = new FaturaKayitIslemleri.faturaCevapDVO();
                try
                {
                    UTSUsageCommitment(); // ÜTS Kullanım Kesinleştirme

                    TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO faturaGirisDVO = GetFaturaGirisDVO("Read");
                    TTObjectClasses.XXXXXXMedulaServices.FaturaTutarOkuParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.FaturaTutarOkuParam(faturaGirisDVO, SEPs, invoiceDate);
                    fcd = FaturaKayitIslemleri.WebMethods.faturaTutarOkuSync(TTObjectClasses.Sites.SiteLocalHost, faturaGirisDVO); // Değişecek 
                    if (fcd.sonucKodu != null && (fcd.sonucKodu.Equals("9102") || fcd.sonucKodu.Equals("9103")))
                    {
                        Thread.Sleep(5000);
                        return ReadInvoicePrice(_SEPs, _invoiceDate, _description);
                    }
                    inputParam.FaturaTutarOkuCompletedInternal(fcd);

                    MedulaResult mr = null;
                    if (fcd != null && fcd.hataliKayitlar != null)
                    {
                        foreach (var hk in fcd.hataliKayitlar)
                        {
                            if (hk.hataKodu != null && hk.hataKodu.Equals("1544"))
                            {
                                ControlAndChangeExaminationOperation(hk.takipNo, true);
                                return ReadInvoicePrice(_SEPs, _invoiceDate, _description);
                            }
                            else if (hk.hataKodu != null && hk.hataKodu.Equals("1376"))
                            {
                                ControlAndChangeExaminationOperation(hk.takipNo, false);
                                return ReadInvoicePrice(_SEPs, _invoiceDate, _description);
                            }

                            mr = new MedulaResult();
                            mr.TakipNo = hk.takipNo;
                            mr.SEPObjectID = _SEPs[0].ObjectID;
                            mr.Succes = false;
                            mr.SonucKodu = hk.hataKodu;
                            mr.SonucMesaji = hk.hataMesaji;
                            result.Add(mr);
                        }
                    }
                    mr = new MedulaResult();

                    if (fcd.sonucKodu.Equals("0000"))
                        mr.Succes = true;
                    else
                        mr.Succes = false;

                    mr.SEPObjectID = _SEPs[0].ObjectID; ;
                    mr.SonucKodu = fcd.sonucKodu;
                    mr.SonucMesaji = fcd.sonucMesaji;
                    result.Add(mr);

                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception(TTUtils.CultureService.GetText("M26894", "Sistemsel Bir Hata Oluştu, hata yönetime iletildi."), new NullReferenceException("SEPs is NULL or Count = 0"));
            }

        }

        #region MEDULA INVOICE
        public FaturaKayitIslemleri.faturaCevapDVO SaveMedulaInvoice(int type)
        {
            checkSEPStatusForSaveMedulaInvoice();

            UTSUsageCommitment(); // ÜTS Kullanım Kesinleştirme

            TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO faturaGirisDVO = GetFaturaGirisDVO("Invoice");

            TTObjectClasses.XXXXXXMedulaServices.FaturaGirisParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.FaturaGirisParam(faturaGirisDVO, SEPs, invoiceDate, description, invoiceCollectionList);
            FaturaKayitIslemleri.faturaCevapDVO result = FaturaKayitIslemleri.WebMethods.faturaKayitSync(TTObjectClasses.Sites.SiteLocalHost, faturaGirisDVO); // Değişecek 
            inputParam.FaturaGirisCompletedInternal(result, ObjectContext, type);

            return result;
        }

        private void checkSEPStatusForSaveMedulaInvoice()
        {
            List<Guid> states = new List<Guid>();
            states.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
            states.Add(AccountTransaction.States.New);
            invoiceCollectionList = new Dictionary<Guid, InvoiceCollection>();

            if (SystemParameter.GetParameterValue("INVOICEBLOCKINGACTIVE", "FALSE") == "TRUE")
            {
                List<Guid> SEPGuidList = SEPs.Select(x => x.ObjectID).ToList();
                List<Guid> blockStates = InvoiceBlockingDefinition.GetBlockStateIDs((int)APRTypeEnum.PAYER, ObjectContext);
                BindingList<AccountTransaction.GetBlockTransactionsCountBySEPs_Class> blockResultList = AccountTransaction.GetBlockTransactionsCountBySEPs(ObjectContext, blockStates, SEPGuidList);
                if (blockResultList.Count > 0 && Convert.ToInt32(blockResultList[0].Blockingcount) > 0)
                {
                    throw new TTException("İşlem durumlarından kaynaklı sistem bazlı otomatik fatura engeli bulundu. Fatura edilemez.");
                }
            }

            foreach (SubEpisodeProtocol sep in SEPs)
            {
                string exMessage = "";

                sep.ControlInvoiceBlocking();

                InvoiceCollection ic = sep.GetMyInvoiceCollection(invoiceDate);

                invoiceCollectionList.Add(sep.ObjectID, ic);

                if (sep.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted && sep.InvoiceStatus != MedulaSubEpisodeStatusEnum.InvoiceRead && sep.InvoiceStatus != MedulaSubEpisodeStatusEnum.InvoiceReadWithError && sep.InvoiceStatus != MedulaSubEpisodeStatusEnum.InvoiceEntryWithError)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M25662", "Faturalandırabilmeniz için takibin durumu 'Hizmet Kaydı Tamamlanmış', 'Fatura Tutar Okundu' veya 'Fatura Kaydı Hatalı' olmalıdır.") +
                        "\r\n\r\nTakip No : " + sep.MedulaTakipNo + " Kabul No: " + sep.SubEpisode.ProtocolNo + " ,  Takip Durumu: " + Common.GetDisplayTextOfEnumValue("MedulaSubEpisodeStatusEnum", (int)sep.InvoiceStatus));
                }

                if (SystemParameter.GetParameterValue("CONTROLSEPINVOICEINPATIENTSTATUS", "FALSE") == "TRUE" && sep.SubEpisode.InpatientStatus == InpatientStatusEnum.Predischarged)
                    throw new TTException("Ön taburcu statüsündeki hastanın faturası kesilemez. Lütfen yattığı birim ile iletişime geçiniz.");

                //if (sep.MedulaTedaviTuru.tedaviTuruKodu.Trim().Equals("A") && DateTime.Now.Subtract(sep.MedulaProvizyonTarihi.Value).Days < 10 && sep.SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.Kontrol)
                //    throw new TTException("Faturalandırabilmeniz için ayaktan takipli kabulun üzerinden 10 gün geçmiş olmalı. Takip No: " + sep.MedulaTakipNo + ",  Provizyon Tarihi: " + sep.MedulaProvizyonTarihi.Value.ToString("dd.MM.yyyy"));

                BindingList<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class> rcount = AccountTransaction.GetMedulaTransactionCountBySEPAndState(sep.ObjectID, states);
                if (rcount != null && rcount.Count > 0 && Convert.ToInt32(rcount[0].Acctrxcount) > 0)
                    throw new TTException("Faturalandırabilmeniz için takip altında Yeni veya Hatalı durumunda işlem olmamalıdır, Takip No: " + sep.MedulaTakipNo + ", Tahhakkuk/Yeni durumunda olan işlem sayısı: " + Convert.ToInt32(rcount[0].Acctrxcount));

            }


            // Hasta üzerinde kullanılmamış 22F Malzemesi varsa fatura kaydetmeye izin verilmez
            if (SEPs != null && SEPs.Count > 0 && SEPs[0].SubEpisode != null && SEPs[0].SubEpisode.Episode != null && SEPs[0].SubEpisode.Episode.Patient != null)
            {
                List<DirectPurchaseActionDetail> notUsedDirectPurchaseActionDetails = SEPs[0].SubEpisode.Episode.Patient.GetNotUsedDirectPurchaseProducts();
                if (notUsedDirectPurchaseActionDetails.Count > 0)
                {
                    string SUTNames = string.Empty;

                    foreach (DirectPurchaseActionDetail directPurchaseActionDetail in notUsedDirectPurchaseActionDetails)
                        SUTNames += directPurchaseActionDetail.SUTName + "\r\n";

                    throw new TTException(TTUtils.CultureService.GetText("M25784", "Hasta için 22F Doğrudan Temin İşlemi ile alınmış ama kullanılmamış olan malzeme vardır, faturalandırabilmeniz için bu malzemenin kullanılması gerekmektedir.\r\nKullanılmamış Malzemeler :\r\n") + SUTNames);
                }
            }
        }

        public List<MedulaResult> SavePatientInvoice(List<SubEpisodeProtocol> sepList, DateTime invoiceDate, string invoiceDescription, List<Guid> transList, int type)
        {

            string paidPayerObjectID = SystemParameter.GetParameterValue("PAIDPAYERDEFINITION ", "4d7b28c8-4f48-4452-afe2-98a30c376b80");

            PayerDefinition paidPayer = ObjectContext.GetObject(new Guid(paidPayerObjectID), typeof(PayerDefinition)) as PayerDefinition;

            if (paidPayer == null)
                throw new TTException(TTUtils.CultureService.GetText("M27157", "Ücretli hastalar kurumu bulunamadı.Sistem parametrelerini kontrol ediniz.(Bknz: PAIDPAYERDEFINITION )"));

            ProtocolDefinition paidProtocol = paidPayer.FirstValidProtocol();

            if (paidProtocol == null)
                throw new TTException(TTUtils.CultureService.GetText("M27158", "Ücretli hastalar kurumuna ait bir anlaşma bulunamadı.Anlaşma tanımlarını kontrol ediniz."));



            List<AccountTransaction> accTrxList = new List<AccountTransaction>();
            foreach (Guid item in transList)
            {
                AccountTransaction actTrx = ObjectContext.GetObject(item, typeof(AccountTransaction)) as AccountTransaction;

                accTrxList.Add(actTrx);
            }

            //SEP ler klonlanır ve hizmetler klon SEP lere atılır.
            int countOfTrx = 0;
            List<SubEpisodeProtocol> clonedOrInvoicedSEPList = new List<SubEpisodeProtocol>();
            SEPMaster sepMaster = new SEPMaster(ObjectContext);
            foreach (SubEpisodeProtocol sep in sepList)
            {

                if (SystemParameter.GetParameterValue("CONTROLSEPINVOICEINPATIENTSTATUS", "FALSE") == "TRUE" && sep.SubEpisode.InpatientStatus == InpatientStatusEnum.Predischarged)
                    throw new TTException("Ön taburcu statüsündeki hastanın faturası kesilemez. Lütfen yattığı birim ile iletişime geçiniz.");

                sep.ControlInvoiceBlocking();
                //if (sep.Payer.Type.PayerType != PayerTypeEnum.Paid)
                //int countOfListAcctrx = accTrxList.Where(x => x.SubEpisodeProtocol == sep && x.CurrentStateDefID == AccountTransaction.States.Paid).Count() ;
                SubEpisodeProtocol newSEP = null;
                // if (true)//Şimdilik her seferinde clone oluşturacak şekilde yazıldı.
                {
                    newSEP = sep.CloneMe(SEPCloneTypeEnum.PatientInvoice);
                    newSEP.MedulaProvizyonTarihi = sep.MedulaProvizyonTarihi;
                    if (sep.Payer.Type.PayerType == PayerTypeEnum.Paid)
                        newSEP.LastIIM = sep.LastIIM;

                    newSEP.Payer = paidPayer;
                    newSEP.Protocol = paidProtocol;
                    newSEP.SEPMaster = sepMaster;

                    InvoiceLog.AddInfo("Hasta faturası oluşturuldu. Kopya takip satırı oluşturuldu: Mevcut: " + sep.Id + " Kopya: " + newSEP.Id, newSEP.ObjectID, InvoiceOperationTypeEnum.Faturalandir, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);

                    List<AccountTransaction> accTrxListInner = accTrxList.Where(x => x.SubEpisodeProtocol == sep).ToList();

                    foreach (AccountTransaction accTrxInner in accTrxListInner)
                    {
                        countOfTrx++;
                        accTrxInner.SubEpisodeProtocol = newSEP;
                    }
                }
                // else
                //    newSEP = sep;

                clonedOrInvoicedSEPList.Add(newSEP);
            }

            ObjectContext.Update();

            if (countOfTrx != accTrxList.Count)
                throw new TTException("Seçili hizmetler ile SEP'ler arasında uyumsuzluk var. Lütfen yetkililer ile iletişime geçiniz. ");


            InvoiceCollection ic = null;
            if (clonedOrInvoicedSEPList.Count > 0)
                ic = clonedOrInvoicedSEPList.FirstOrDefault().GetMyInvoiceCollection(invoiceDate);
            else
                throw new TTException("Seçili SEP'ler arasında uyumsuzluk var. Lütfen yetkililer ile iletişime geçiniz. ");

            InvoiceCollectionDetail icd = null;
            icd = ic.AddInvoiceCollectionDetail(clonedOrInvoicedSEPList.FirstOrDefault());

            icd.CreatePayerInvoice(invoiceDate, description);

            List<MedulaResult> mrList = new List<MedulaResult>();
            MedulaResult mr = new MedulaResult();
            mr.SEPObjectID = clonedOrInvoicedSEPList.FirstOrDefault().ObjectID;
            mr.SonucKodu = "0000";
            mr.SonucMesaji = TTUtils.CultureService.GetText("M25660", "Faturalama işlemi başarı ile tamamlandı");
            mr.Succes = true;

            mrList.Add(mr);
            return mrList;

        }

        public TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO GetFaturaGirisDVO(string type)
        {
            FaturaKayitIslemleri.faturaGirisDVO faturaGirisDVO = new FaturaKayitIslemleri.faturaGirisDVO();
            faturaGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            faturaGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            faturaGirisDVO.faturaTarihi = invoiceDate.ToString("dd.MM.yyyy");

            Guid medulaInvoiceReferenceNumber = new Guid("15a270ae-3037-4f28-9aee-7dc671372c03");
            faturaGirisDVO.faturaRefNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[medulaInvoiceReferenceNumber], null, null).ToString();

            if (SEPs != null && SEPs.Count > 0)
            {
                faturaGirisDVO.hastaBasvuruNo = SEPs[0].MedulaBasvuruNo;
                faturaGirisDVO.hizmetDetaylari = new FaturaKayitIslemleri.hizmetDetayDVO[SEPs.Count];
            }
            for (int i = 0; i < SEPs.Count; i++)
            {
                faturaGirisDVO.hizmetDetaylari[i] = new FaturaKayitIslemleri.hizmetDetayDVO();
                if (SEPs[i].Epicrisis != null && SEPs[i].Epicrisis.Description != null)
                {
                    if (SEPs[i].Epicrisis.Description.Length > 2000)
                        faturaGirisDVO.hizmetDetaylari[i].aciklama = SEPs[i].Epicrisis.Description.Substring(0, 2000);
                    else
                        faturaGirisDVO.hizmetDetaylari[i].aciklama = SEPs[i].Epicrisis.Description;
                }
                else
                {
                    Dictionary<string, string> tempEpicrisis = SEPs[i].GetSEPEpicrisisInfo();
                    string tempDescription = SEPs[i].GetSEPEpicrisisDescription(tempEpicrisis);
                    if (!string.IsNullOrEmpty(Common.GetTextOfRTFString(tempDescription)))
                    {
                        if (type == "Invoice")
                        {
                            SEPEpicrisis sepE = new SEPEpicrisis(ObjectContext, Common.GetTextOfRTFString(tempDescription));
                            SEPs[i].Epicrisis = sepE;
                            faturaGirisDVO.hizmetDetaylari[i].aciklama = sepE.Description;
                        }
                        else
                        {
                            string readInvoiceDesc = Common.GetTextOfRTFString(tempDescription);
                            if (readInvoiceDesc.Length > 2000)
                                faturaGirisDVO.hizmetDetaylari[i].aciklama = readInvoiceDesc.Substring(0, 2000);
                            else
                                faturaGirisDVO.hizmetDetaylari[i].aciklama = readInvoiceDesc;

                        }
                    }
                    else
                        faturaGirisDVO.hizmetDetaylari[i].aciklama = "";
                }
                faturaGirisDVO.hizmetDetaylari[i].protokolNo = SEPs[i].SubEpisode.Episode.HospitalProtocolNo.ToString(); // + "-" + tempSEP.OrderNo;
                faturaGirisDVO.hizmetDetaylari[i].taburcuKodu = SEPs[i].DischargeCode();
                faturaGirisDVO.hizmetDetaylari[i].takipNo = SEPs[i].MedulaTakipNo;
            }

            return faturaGirisDVO;
        }

        private bool checkSEPStatusForReadMedulaInvoice()
        {
            return true;
        }

        #endregion

        // ÜTS Kullanım Kesinleştirme Metodu
        public MedulaResult UTSUsageCommitment(List<AccountTransaction> accTrxList = null)
        {
            MedulaResult medulaResult = new MedulaResult();

            if (accTrxList == null) // AccTrx listesi verilmemişse, tüm ÜTS malzemeleri için kesinleştirme yapılır
            {
                if (SEPs == null || SEPs.Count == 0)
                    return medulaResult;
                else
                    accTrxList = AccountTransaction.GetTrxsForUTSUsageCommitment(ObjectContext, SEPs.Select(x => x.ObjectID).ToList(), 0).ToList<AccountTransaction>();
            }

            if (accTrxList.Count > 0)
            {
                List<FaturaKayitIslemleri.utsKesinlestirmeKayitMalzemeDVO> UTSMaterialList = new List<FaturaKayitIslemleri.utsKesinlestirmeKayitMalzemeDVO>();

                foreach (AccountTransaction accTrx in accTrxList)
                {
                    FaturaKayitIslemleri.utsKesinlestirmeKayitMalzemeDVO UTSMaterial = new FaturaKayitIslemleri.utsKesinlestirmeKayitMalzemeDVO();
                    UTSMaterial.hizmetSunucuRefNo = accTrx.MedulaReferenceNumber;
                    UTSMaterial.takipNo = accTrx.SubEpisodeProtocol.MedulaTakipNo;
                    UTSMaterialList.Add(UTSMaterial);
                }

                FaturaKayitIslemleri.utsKesinlestirmeKayitGirisDVO utsKesinlestirmeGirisDVO = new FaturaKayitIslemleri.utsKesinlestirmeKayitGirisDVO();
                utsKesinlestirmeGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                utsKesinlestirmeGirisDVO.utsKesinlestirmeKayitMalzemeDVO = UTSMaterialList.ToArray();

                FaturaKayitIslemleri.utsKesinlestirmeKayitCevapDVO result = FaturaKayitIslemleri.WebMethods.utsKullanimKesinlestirmeSync(Sites.SiteLocalHost, utsKesinlestirmeGirisDVO);

                if (result != null && !string.IsNullOrEmpty(result.sonucKodu))
                {
                    if (result.sonucKodu.Equals("0000"))
                    {
                        foreach (AccountTransaction accTrx in accTrxList)
                        {
                            accTrx.UTSUsageCommitment = true;
                            InvoiceLog.AddInfo("ÜTS Kullanım Kesinleştirme başarılı.", accTrx.ObjectID, InvoiceOperationTypeEnum.UXXXXXXullanimKesinlestirme, InvoiceLogObjectTypeEnum.AccountTransaction, ObjectContext);
                        }
                        medulaResult.Succes = true;
                    }
                    else
                    {
                        if (result.hataliKayitlar != null)
                        {
                            foreach (FaturaKayitIslemleri.hataliIslemBilgisiDVO hataliIslem in result.hataliKayitlar)
                            {
                                if (!string.IsNullOrEmpty(hataliIslem.hizmetSunucuRefNo))
                                {
                                    AccountTransaction accTrx = accTrxList.FirstOrDefault(x => x.MedulaReferenceNumber == hataliIslem.hizmetSunucuRefNo);
                                    if (accTrx != null)
                                    {
                                        accTrx.MedulaResultCode = hataliIslem.hataKodu;
                                        accTrx.MedulaResultMessage = hataliIslem.hataMesaji;
                                        InvoiceLog.AddErr("ÜTS Kullanım Kesinleştirme başarısız. (" + hataliIslem.hataKodu + " " + hataliIslem.hataMesaji + ")", accTrx.ObjectID, InvoiceOperationTypeEnum.UXXXXXXullanimKesinlestirme, InvoiceLogObjectTypeEnum.AccountTransaction, ObjectContext);
                                    }
                                }
                            }
                        }

                        medulaResult.Succes = false;
                    }

                    medulaResult.SonucKodu = result.sonucKodu;
                    medulaResult.SonucMesaji = result.sonucMesaji;
                }
            }

            return medulaResult;
        }

        private List<MedulaResult> SaveOfficialInvoice(Guid _invoiceCollection)
        {
            InvoiceCollection ic = ObjectContext.GetObject(_invoiceCollection, typeof(InvoiceCollection)) as InvoiceCollection;

            List<MedulaResult> result = new List<MedulaResult>();
            MedulaResult mr = new MedulaResult();
            SubEpisodeProtocol sep = SubEpisodeProtocols.Where(x => x.CurrentStateDefID == SubEpisodeProtocol.States.Open && x.Payer.ObjectID == ic.Payer.ObjectID).FirstOrDefault();

            if (sep != null)
            {
                InvoiceCollectionDetail icd = null;
                if (sep.InvoiceCollectionDetail == null)
                    icd = ic.AddInvoiceCollectionDetail(sep);
                else
                    icd = sep.InvoiceCollectionDetail;

                if (icd.CurrentStateDefID == InvoiceCollectionDetail.States.New && icd.PayerInvoiceDocument == null)
                    icd.CreatePayerInvoice(invoiceDate, description);

                mr.SonucKodu = "0000";
                mr.SonucMesaji = TTUtils.CultureService.GetText("M25660", "Faturalama işlemi başarı ile tamamlandı");
                mr.Succes = true;
            }
            else
            {
                mr.SonucKodu = "0001";
                mr.SonucMesaji = TTUtils.CultureService.GetText("M25661", "Faturalamaya uygun veri bulunamadı.");
                mr.Succes = false;
            }
            if (SEPs != null && SEPs.Count > 0)
            {
                mr.SEPObjectID = SEPs[0].ObjectID;
            }

            result.Add(mr);
            return result;
        }

        public static HastaKabulIslemleri.basvuruTakipOkuCevapDVO basvuruOku(string medulaBasvuruNo)
        {
            TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuDVO basvuruTakipOkuDVO = new TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuDVO();
            basvuruTakipOkuDVO.hastaBasvuruNo = medulaBasvuruNo;
            basvuruTakipOkuDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            TTObjectClasses.XXXXXXMedulaServices.BasvuruTakipOkuParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.BasvuruTakipOkuParam(basvuruTakipOkuDVO);
            HastaKabulIslemleri.basvuruTakipOkuCevapDVO result = HastaKabulIslemleri.WebMethods.basvuruTakipOkuSync(TTObjectClasses.Sites.SiteLocalHost, basvuruTakipOkuDVO);
            return result;
        }

        public class ForbiddenSUTOperation
        {
            public Guid sepObjectID { get; set; }
            public string provisionNo { get; set; }
            public string protocolNo { get; set; }
            public string sutCode { get; set; }
            public string sutName { get; set; }
            public double? totalAmount { get; set; }
            public double? totalPrice { get; set; }
        }

        public static List<SEPMaster.ForbiddenSUTOperation> GetTransactionTotalAmountAndPrice(List<SubEpisodeProtocol> sepList, string firstSUTCode, string secondSUTCode)
        {
            List<SEPMaster.ForbiddenSUTOperation> result = new List<SEPMaster.ForbiddenSUTOperation>();
            using (var objectContext = new TTObjectContext(false))
            {
                SEPMaster.ForbiddenSUTOperation ffso = new SEPMaster.ForbiddenSUTOperation();
                ffso.sutCode = firstSUTCode;
                ffso.totalAmount = 0;
                ffso.totalPrice = 0;

                SEPMaster.ForbiddenSUTOperation sfso = new SEPMaster.ForbiddenSUTOperation();
                sfso.sutCode = secondSUTCode;
                sfso.totalAmount = 0;
                sfso.totalPrice = 0;

                result.Add(ffso);
                result.Add(sfso);

                foreach (SubEpisodeProtocol singleSEP in sepList)
                {
                    List<AccountTransaction> firstActxList = singleSEP.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND SUBACTIONPROCEDURE IS NOT NULL AND EXTERNALCODE = '" + firstSUTCode + "'  ").ToList();
                    List<AccountTransaction> secondActxList = singleSEP.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND SUBACTIONPROCEDURE IS NOT NULL AND EXTERNALCODE = '" + secondSUTCode + "'  ").ToList();

                    if (firstActxList != null && firstActxList.Count > 0)
                    {
                        ffso.sutName = firstActxList.Select(x => x.Description).FirstOrDefault();
                        ffso.totalAmount += firstActxList.Sum(x => x.Amount);
                        ffso.totalPrice += firstActxList.Sum(x => x.Amount * x.UnitPrice);
                    }
                    if (secondActxList != null && secondActxList.Count > 0)
                    {
                        sfso.sutName = secondActxList.Select(x => x.Description).FirstOrDefault();
                        sfso.totalAmount += secondActxList.Sum(x => x.Amount);
                        sfso.totalPrice += secondActxList.Sum(x => x.Amount * x.UnitPrice);
                    }
                }
            }
            return result;
        }

        public List<SubEpisodeProtocol.MedulaResult> Fix1108MedulaErrorCodeAndSaveInvoice(List<SubEpisodeProtocol.MedulaResult> paramaterResult, List<SubEpisodeProtocol> sepList, DateTime invoiceDate, string invoiceDescription, Guid invoiceCollection, int type, int invoiceOrInvoiceRead, string sonucMesaji)
        {
            List<SubEpisodeProtocol.MedulaResult> result = new List<MedulaResult>();
            string[] splittedMessage;

            if (paramaterResult != null && paramaterResult.Count > 0)
                splittedMessage = paramaterResult.FirstOrDefault().SonucMesaji.Split(' ');
            else
                splittedMessage = sonucMesaji.Split(' ');

            List<SEPMaster.ForbiddenSUTOperation> transactionList = GetTransactionTotalAmountAndPrice(sepList, splittedMessage[7], splittedMessage[14]);
            SEPMaster.ForbiddenSUTOperation tempFSO = null;
            if (transactionList.FirstOrDefault().totalPrice > transactionList.LastOrDefault().totalPrice)
                tempFSO = transactionList.LastOrDefault();
            else
                tempFSO = transactionList.FirstOrDefault();

            bool control = SubEpisodeProtocol.HizmetKayitIptalWithSEPAndSutCode(sepList, tempFSO.sutCode);

            if (control && invoiceOrInvoiceRead != 2)
            {
                if (invoiceOrInvoiceRead == 0)
                    result = SaveInvoice(sepList, invoiceDate, invoiceDescription, invoiceCollection, type);
                else
                    result = ReadInvoicePrice(sepList, invoiceDate, invoiceDescription);

                if (result.FirstOrDefault().SonucKodu == "1108")
                    result = Fix1108MedulaErrorCodeAndSaveInvoice(result, sepList, invoiceDate, invoiceDescription, invoiceCollection, type, invoiceOrInvoiceRead, "");
            }
            return result;
        }

    }
}