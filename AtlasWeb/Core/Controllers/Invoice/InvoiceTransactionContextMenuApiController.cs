using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;

using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Net.Http;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections;

namespace Core.Controllers.Invoice
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class InvoiceTransactionContextMenuApiController : Controller
    {
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void hizmetKayit(List<InvoiceSEPTransactionListModel> selectedTransactions)
        {
            try
            {
                List<Guid> ssList = new List<Guid>();
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID);
                }
                if (ssList.Count > 999)
                {
                    throw new Exception("Hizmet kayıt sırasında tek seferde en fazla 1000 kayıt gönderilebilir! Toplu hizmet kaydını deneyiniz.");
                }
                string resultMessage = string.Empty;
                //if (HasDifferentStateControl(selectedTransactions, ref resultMessage))
                //{
                //    throw new Exception(resultMessage);
                //}
                //int maxHizmetSayisi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                //if (ssList.Count > maxHizmetSayisi)
                //{
                //    throw new Exception("Hizmet kayıt sırasında tek seferde en fazla " + maxHizmetSayisi + " kayıt gönderilebilir! Toplu hizmet kaydını deneyiniz.");
                //}
                //else
                //{
                if (ssList.Count > 0)
                {
                    TTObjectContext objectcontext = new TTObjectContext(false);
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(ssList[0], typeof(AccountTransaction));
                    MedulaResult medulaResult = acctrx.SubEpisodeProtocol.HizmetKayitSync(true, ssList);
                    if (medulaResult != null && !medulaResult.SonucKodu.Equals("0000"))
                    {
                        throw new Exception("[" + medulaResult.SonucKodu + "] " + medulaResult.SonucMesaji);
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetKayit: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void hizmetKayitIptal(InvoiceSEPHizmetKayitIptalModel Ishkim)
        {
            try
            {
                List<string> ssList = new List<string>();
                List<Guid> accountTransactionIDs = new List<Guid>();
                foreach (var item in Ishkim.TransactionList)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && !string.IsNullOrEmpty(item.MedulaProcessNo))
                    {
                        ssList.Add(item.MedulaProcessNo.ToString());
                        accountTransactionIDs.Add(item.ObjectID);
                    }
                }
                if (ssList.Count > 999)
                {
                    throw new Exception("Hizmet kayıt iptal sırasında tek seferde en fazla 1000 kayıt gönderilebilir! Toplu hizmet kayıt iptalini deneyiniz.");
                }
                string resultMessage = string.Empty;
                //int maxHizmetSayisi = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                //if (ssList.Count > maxHizmetSayisi)
                //{
                //    throw new Exception("Hizmet kayıt iptal sırasında tek seferde en fazla " + maxHizmetSayisi + " kayıt gönderilebilir! Toplu hizmet kayıt iptalini deneyiniz.");
                //}
                //else
                //{
                if (ssList.Count > 0)
                {
                    TTObjectContext objectcontext = new TTObjectContext(false);
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(Ishkim.SEPObjectID, typeof(SubEpisodeProtocol));
                    MedulaResult medulaResult = sep.HizmetKayitIptalSync(ssList, accountTransactionIDs, true);
                    if (medulaResult != null && medulaResult.SonucKodu != null)
                    {
                        if (!medulaResult.SonucKodu.Equals("0000"))
                        {
                        }
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetKayitIptal: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void hizmetDurumGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, bool state)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmet durumu değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.ToBeNew || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateTransactionState(ssList, state);
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetDurumGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void hizmetDahillikGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, bool state)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmet dahilliği değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateTransactionInvoiceInclusion(ssList, state);
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetDahillikGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void tarihGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string date)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateTransactionDate(ssList, Convert.ToDateTime(date));
            }
            catch (Exception ex)
            {
                throw new Exception(" tarihGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Hizmet_Fiyat_Guncelleme)]
        public void fiyatGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string price)
        {
            try
            {
                price = price.Replace('.', ',');
                List<Guid> accTrxObjectIDList = new List<Guid>();

                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        accTrxObjectIDList.Add(item.ObjectID);
                }

                if (accTrxObjectIDList.Count > 0)
                    Utils.UpdateTransactionPrice(accTrxObjectIDList, Convert.ToDouble(price));
            }
            catch (Exception ex)
            {
                throw new Exception(" fiyatGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void medulaRaporNoGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string raporNo)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateMedulaReportNo(ssList, raporNo);
            }
            catch (Exception ex)
            {
                throw new Exception(" medulaRaporNoGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void medulaAccessionNoGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string accessionNo)
        {
            try
            {
                List<string> ssList = new List<string>();
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateMedulaAccessionNo(ssList, accessionNo);
            }
            catch (Exception ex)
            {
                throw new Exception(" medulaAccessionNoGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void medulaBayiNoGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string bayiNo)
        {
            try
            {
                List<string> ssList = new List<string>();
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateMedulaBayiNo(ssList, bayiNo);
            }
            catch (Exception ex)
            {
                throw new Exception(" medulaBayiNoGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void medulaYatakNoGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string yatakNo)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateMedulaYatakNo(ssList, yatakNo);
            }
            catch (Exception ex)
            {
                throw new Exception(" medulaYatakNoGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void satinAlmaTarihiGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string date)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateSatinAlmaTarihi(ssList, Convert.ToDateTime(date));
            }
            catch (Exception ex)
            {
                throw new Exception(" satinAlmaTarihiGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void barkodGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string barkod)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateBarkod(ssList, barkod);
            }
            catch (Exception ex)
            {
                throw new Exception(" barkodGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void firmaTanimlayiciNumarasiGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string fTNo)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateFirmaTanimlayiciNumarasi(ssList, fTNo);
            }
            catch (Exception ex)
            {
                throw new Exception(" firmaTanimlayiciNumarasiGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void adetGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string amount)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateTransactionAmount(ssList, amount);
            }
            catch (Exception ex)
            {
                throw new Exception(" adetGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void doktorGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string doctor)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateTransactionDoctor(ssList, new Guid(doctor));
            }
            catch (Exception ex)
            {
                throw new Exception(" doktorGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void ozelDurumGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string ozelDurum)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateOzelDurum(ssList, ozelDurum);
            }
            catch (Exception ex)
            {
                throw new Exception(" ozelDurumGuncelle: " + ex.Message, ex);
            }
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void kesiGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string kesi)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateKesi(ssList, kesi);
            }
            catch (Exception ex)
            {
                throw new Exception(" kesiGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void sagSolGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, int? sagSolEnum)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin tarihinin değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateSagSol(ssList, sagSolEnum);
            }
            catch (Exception ex)
            {
                throw new Exception(" kesiGuncelle: " + ex.Message, ex);
            }
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void altVakaGuncelle(List<InvoiceSEPTransactionListModel> selectedTransactions, string altVaka)
        {
            try
            {
                List<string> ssList = new List<string>();
                //TODO: AAE Faturalandı durumundaki SEP in hizmetin SEP i  değiştirilmemesi lazım.
                foreach (var item in selectedTransactions)
                {
                    if (item.CurrentStateDefID == AccountTransaction.States.New || item.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful || item.CurrentStateDefID == AccountTransaction.States.MedulaDontSend || item.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                        ssList.Add(item.ObjectID.ToString());
                }

                if (ssList.Count > 0)
                    Utils.UpdateAltVaka(ssList, altVaka);
            }
            catch (Exception ex)
            {
                throw new Exception(" altVakaGuncelle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public HizmetOkuCevapModel hizmetKayitOku(List<InvoiceSEPTransactionListModel> selectedTransactions, Guid? sepObjectID)
        {
            try
            {
                HizmetOkuCevapModel result = new HizmetOkuCevapModel();
                List<string> mpList = new List<string>();
                List<string> hsrnList = new List<string>();
                if (selectedTransactions != null && selectedTransactions.Count > 0)
                {
                    foreach (var item in selectedTransactions)
                    {
                        if (item.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && item.MedulaProcessNo != "" && item.MedulaProcessNo != null)
                            mpList.Add(item.MedulaProcessNo);
                        hsrnList.Add(item.Id);
                    }
                }

                string takipNo = "";
                TTObjectContext objectcontext = new TTObjectContext(false);
                SubEpisodeProtocol sep;
                if (sepObjectID.HasValue)
                    sep = (SubEpisodeProtocol)objectcontext.GetObject(sepObjectID.Value, typeof(SubEpisodeProtocol));
                else if (selectedTransactions != null && selectedTransactions.Count > 0)
                    sep = ((AccountTransaction)objectcontext.GetObject(selectedTransactions[0].ObjectID, typeof(AccountTransaction))).SubEpisodeProtocol;
                else
                    throw new Exception(TTUtils.CultureService.GetText("M25316", "Bu işlem yapılırken en az bir veri gönrderilmesi lazım. (TakipNo/IslemSıraNo)"));
                takipNo = sep.MedulaTakipNo;
                if (!string.IsNullOrEmpty(takipNo))
                {
                    HizmetKayitIslemleri.hizmetOkuCevapDVO hizmetOkuCevapDVO = sep.HizmetKayitOkuSync(hsrnList, mpList);
                    if (hizmetOkuCevapDVO.sonucKodu.Equals("0000"))
                    {
                        HizmetOkuCevapHizmetlerModel hochm = new HizmetOkuCevapHizmetlerModel();
                        if (hizmetOkuCevapDVO.hizmetler.muayeneBilgisi != null)
                        {
                            CopyPropertyValues(hizmetOkuCevapDVO.hizmetler.muayeneBilgisi, hochm); //MUAYENE 
                            if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                            {
                                hochm.type = "MUAYENE";
                                hochm.islemTarihi = hizmetOkuCevapDVO.hizmetler.muayeneBilgisi.muayeneTarihi;
                                result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.hastaYatisBilgileri != null)
                        {
                            hochm = new HizmetOkuCevapHizmetlerModel();
                            CopyPropertyValues(hizmetOkuCevapDVO.hizmetler.hastaYatisBilgileri, hochm); //YATIŞ 
                            hochm.type = "YATIŞ";
                            if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                result.tumHizmetler.Add(hochm);
                        }

                        if (hizmetOkuCevapDVO.hizmetler.ameliyatveGirisimBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.ameliyatveGirisimBilgileri) //AMELİYAT 
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "AMELİYAT";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.digerIslemBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.digerIslemBilgileri) //DİĞER
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "DİĞER";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.disBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.disBilgileri) //DİŞ
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "DİŞ";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.ilacBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.ilacBilgileri) //İLAÇ
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "İLAÇ";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                {
                                    hochm.sutKodu = item.barkod;
                                    result.tumHizmetler.Add(hochm);
                                }
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.kanBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.kanBilgileri) //KAN
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "KAN";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.konsultasyonBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.konsultasyonBilgileri) //KONSULTASYON
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "KONSULTASYON";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.malzemeBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.malzemeBilgileri) //MALZEME
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "MALZEME";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                {
                                    hochm.sutKodu = item.barkod;
                                    result.tumHizmetler.Add(hochm);
                                }
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.tahlilBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.tahlilBilgileri) //TAHLİL
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "TAHLİL";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        if (hizmetOkuCevapDVO.hizmetler.tetkikveRadyolojiBilgileri != null)
                        {
                            foreach (var item in hizmetOkuCevapDVO.hizmetler.tetkikveRadyolojiBilgileri) //RADYOLOJİ
                            {
                                hochm = new HizmetOkuCevapHizmetlerModel();
                                hochm.type = "RADYOLOJİ";
                                CopyPropertyValues(item, hochm);
                                if (!string.IsNullOrEmpty(hochm.islemSiraNo))
                                    result.tumHizmetler.Add(hochm);
                            }
                        }

                        CopyPropertyValues(hizmetOkuCevapDVO, result); // ORTAK BİLGİ
                        CopyPropertyValues(hizmetOkuCevapDVO.hizmetler, result); // ORTAK BİLGİ
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetKayitOku: " + ex.Message, ex);
            }

            return null;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string hizmetXMLOku(List<InvoiceSEPTransactionListModel> selectedTransactions)
        {
            try
            {
                if (selectedTransactions.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27200", "XML Okuma yapılacak işlemi seçiniz."));
                StringBuilder sb = new StringBuilder();
                TTObjectContext context = new TTObjectContext(true);
                AccountTransaction accTrx = context.GetObject(selectedTransactions[0].ObjectID, typeof(AccountTransaction)) as AccountTransaction;
                SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new SubEpisodeProtocol.HizmetKayitGirisDVOWithList();
                accTrx.SubEpisodeProtocol.loadHizmetTakipBilgileriFromAcctrx(hizmetKayitGirisDVOWithList, accTrx);
                SubEpisodeProtocol.MedulaResult result = SubEpisodeProtocol.LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, accTrx, true);

                if (accTrx.SubActionProcedure != null)
                {
                    sb.AppendLine("SubActionProcedure ObjectDef Name : " + accTrx.SubActionProcedure.ObjectDef.Name);
                    if (accTrx.SubActionProcedure.ProcedureObject != null)
                    {
                        sb.AppendLine("ProcedureDefinition ObjectDef Name : " + accTrx.SubActionProcedure.ProcedureObject.ObjectDef.Name);
                        if (accTrx.SubActionProcedure.ProcedureObject.MedulaProcedureType.HasValue)
                            sb.AppendLine("ProcedureDefinition Medula Group : " + Common.GetDisplayTextOfEnumValue("MedulaSUTGroupEnum", (int)accTrx.SubActionProcedure.ProcedureObject.MedulaProcedureType.Value));
                        else
                            sb.AppendLine("ProcedureDefinition Medula Group : ");
                    }
                }
                else if (accTrx.SubActionMaterial != null && accTrx.SubActionMaterial.Material != null)
                    sb.AppendLine("ObjectDef Name : " + accTrx.SubActionMaterial.Material.ObjectDef.Name);

                sb.AppendLine();
                sb.AppendLine(Utils.XmlSerializer.Serialize<TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO>(hizmetKayitGirisDVOWithList.HizmetKayitGirisDVO));

                string hizmetXML = sb.ToString();
                string ktsHbysKodu = TTObjectClasses.SystemParameter.GetKtsHbysKodu();

                if (!string.IsNullOrEmpty(ktsHbysKodu)) // ktsHbysKodu görünmesin diye silinir
                    hizmetXML = hizmetXML.Replace(ktsHbysKodu, string.Empty);

                return hizmetXML;
            }
            catch (Exception ex)
            {
                throw new Exception(" hizmetXMLOku: " + ex.Message, ex);
            }
        }

        private static void CopyPropertyValues(object source, object destination)
        {
            var destProperties = destination.GetType().GetProperties();
            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name) //&& destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(destination, sourceProperty.GetValue(source, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<SGKHizmetSorgulamaResultDTOModel> SGKHizmetSorgulama(SGKHizmetSorgulamaModel shsm)
        {
            List<SGKHizmetSorgulamaResultDTOModel> result = new List<SGKHizmetSorgulamaResultDTOModel>();
            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);


                foreach (var item in shsm.TransactionList)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(item.ObjectID, typeof(AccountTransaction));
                    string sysTakipNo = acctrx.SubEpisodeProtocol.SubEpisode.SYSTakipNo;
                    string islemReferansNumarasi = string.Empty;

                    if (acctrx.SubActionProcedure != null)
                        islemReferansNumarasi = acctrx.SubActionProcedure.ObjectID.ToString();
                    else
                        islemReferansNumarasi = (acctrx.ENabizMaterial != null && acctrx.ENabizMaterial.Count > 0) ? acctrx.ENabizMaterial[0].ObjectID.ToString() : "";

                    HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/genel/SGKHizmetSorgulama?sysTakipNo=" + sysTakipNo + "&islemReferansNumarasi=" + islemReferansNumarasi).Result;

                    if (message.IsSuccessStatusCode)
                    {
                        string rresult = message.Content.ReadAsStringAsync().Result;
                        SGKHizmetSorgulamaResponse response = JsonConvert.DeserializeObject<SGKHizmetSorgulamaResponse>(rresult);
                        if (response.sonuc.Count > 0)
                        {
                            SGKHizmetSorgulamaResultDTOModel tempItem = new SGKHizmetSorgulamaResultDTOModel();

                            foreach (PropertyInfo responseItem in response.sonuc[0].GetType().GetProperties())
                            {
                                foreach (PropertyInfo resultItem in tempItem.GetType().GetProperties())
                                {
                                    if (responseItem.Name == resultItem.Name)
                                    {
                                        resultItem.SetValue(tempItem, responseItem.GetValue(response.sonuc[0]));
                                        break;
                                    }
                                }
                            }
                            tempItem.durum = response.durum;
                            tempItem.mesaj = response.mesaj;
                            result.Add(tempItem);
                        }
                    }
                }
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool NabizGonder(List<InvoiceSEPTransactionListModel> selectedTransactions)
        {
            try
            {
                if (selectedTransactions.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27200", "Nabız gönderilecek işlemi seçiniz."));

                TTObjectContext context = new TTObjectContext(true);
                SendToENabiz sendToENabiz = new SendToENabiz();
                foreach (InvoiceSEPTransactionListModel item in selectedTransactions)
                {
                    AccountTransaction accTrx = context.GetObject(item.ObjectID, typeof(AccountTransaction)) as AccountTransaction;
                    string outherSysTakipNo = null;

                    if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.SubEpisode.SYSTakipNo))
                        outherSysTakipNo = accTrx.SubEpisodeProtocol.SubEpisode.SYSTakipNo;

                    if (accTrx.SubActionProcedure != null)
                        sendToENabiz.ENABIZSend102(accTrx.SubActionProcedure.ObjectID.ToString(), true, outherSysTakipNo);
                    else if (accTrx.SubActionMaterial != null)
                    {
                        if (accTrx.ENabizMaterial != null && accTrx.ENabizMaterial.Count > 0)
                            sendToENabiz.ENABIZSend102(accTrx.ENabizMaterial[0].ObjectID.ToString(), true, outherSysTakipNo);
                        else
                            throw new Exception(" NabizGonder: ENabizMaterial bulunamadı.");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(" NabizGonder: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool NabizSil(List<InvoiceSEPTransactionListModel> selectedTransactions)
        {
            try
            {
                if (selectedTransactions.Count == 0)
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27200", "Nabızdan silinecek işlemi seçiniz."));

                TTObjectContext context = new TTObjectContext(false);
                SendToENabiz sendToENabiz = new SendToENabiz();

                foreach (InvoiceSEPTransactionListModel item in selectedTransactions)
                {
                    AccountTransaction accTrx = context.GetObject(item.ObjectID, typeof(AccountTransaction)) as AccountTransaction;

                    if (accTrx.SubActionProcedure != null)
                    {
                        sendToENabiz.ControlAndCreatePackageToSendToENabiz(context, accTrx.SubEpisodeProtocol.SubEpisode, accTrx.SubActionProcedure.ObjectID, accTrx.SubActionProcedure.ObjectDef.Name, "302");
                        sendToENabiz.ENABIZSend302(accTrx.SubActionProcedure.ObjectID.ToString());
                    }
                    else if (accTrx.SubActionMaterial != null)
                    {
                        if (accTrx.ENabizMaterial != null && accTrx.ENabizMaterial.Count > 0)
                        {
                            sendToENabiz.ControlAndCreatePackageToSendToENabiz(context, accTrx.SubEpisodeProtocol.SubEpisode, accTrx.ENabizMaterial[0].ObjectID, accTrx.ENabizMaterial[0].ObjectDef.Name, "302");
                            sendToENabiz.ENABIZSend302(accTrx.ENabizMaterial[0].ObjectID.ToString());
                        }
                        else
                            throw new Exception(" NabizSil: ENabizMaterial bulunamadı.");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(" NabizSil: " + ex.Message, ex);
            }
        }



        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public bool NabizYatakDuzenle(List<InvoiceSEPTransactionListModel> selectedTransactions)
        {
            try
            {
                if (selectedTransactions.Count == 0)
                    throw new TTException("Düzenlenecek yatak hizmetini seçiniz.");

                if (selectedTransactions.Count > 1)
                    throw new TTException("Sadece bir tane yatak hizmeti seçiniz.");

                TTObjectContext context = new TTObjectContext(false);

                AccountTransaction accTrx = context.GetObject<AccountTransaction>(selectedTransactions[0].ObjectID, false);

                if (accTrx.SubEpisodeProtocol.IsSGKAll == false)
                    throw new TTException("Bu işlem sadece SGK takiplerinde yapılabilir.");

                if (accTrx.SubActionProcedure == null)
                    throw new TTException("Bir yatak hizmeti seçiniz.");

                BaseBedProcedure bedProcedure = accTrx.SubActionProcedure as BaseBedProcedure;
                if (bedProcedure == null)
                    throw new TTException("BaseBedProcedure türünde bir yatak hizmeti seçiniz.");

                if (bedProcedure.IsNewPricingType == true)
                    throw new TTException("Yeni yatak ücretlenme yapısındaki (IsNewPricingType) BaseBedProcedure için yatak düzenleme işlemi yapılamaz.");

                if (bedProcedure.Amount == 1)
                    throw new TTException("Yatak hizmetinin miktarı 1, düzenleme yapılamaz.");

                List<AccountTransaction> actList = bedProcedure.AccountTransactions.Where(x => x.CurrentStateDefID != AccountTransaction.States.Cancelled && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER).OrderBy(x => x.TransactionDate).ToList();

                if (bedProcedure.Amount != actList.Count)
                    throw new TTException("Yatak hizmetinin miktarı (" + bedProcedure.Amount + ") ile fatura kalemi sayısı(" + actList.Count + ") farklı, düzenleme yapılamaz, kontrol ediniz.");

                List<BaseBedProcedure> newBedProcedures = new List<BaseBedProcedure>();
                bool isFirstAct = true;

                foreach (AccountTransaction act in actList)
                {
                    if (isFirstAct) // İlk AccountTransaction atlanır
                    {
                        isFirstAct = false;
                        continue;
                    }

                    BaseBedProcedure newBedProcedure = bedProcedure.Clone() as BaseBedProcedure;
                    newBedProcedure.MasterSubActionProcedure = bedProcedure;
                    TTSequence.allowSetSequenceValue = true;
                    newBedProcedure.ID.SetSequenceValue(0);
                    newBedProcedure.ID.GetNextValue();
                    newBedProcedure.CreationDate = act.TransactionDate;
                    newBedProcedure.PerformedDate = act.TransactionDate;
                    newBedProcedure.Amount = 1;
                    act.SubActionProcedure = newBedProcedure;

                    newBedProcedures.Add(newBedProcedure);
                }

                bedProcedure.Amount = 1;

                context.Save();
                context.Dispose();

                // Yeni oluşturulan BaseBedProcedure ler Nabız a gönderilir
                SendToENabiz sendToENabiz = new SendToENabiz();
                foreach (BaseBedProcedure bedProc in newBedProcedures)
                    sendToENabiz.ENABIZSend102(bedProc.ObjectID.ToString(), true);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("NabizYatakDuzenle: " + ex.Message, ex);
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void turnBetweenPayerAndPatient(InvoiceSEPTurnTypeModel tbpap)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    // tbpap.TurnType false "Kurum Payına Çevir", true "Hasta Payına Çevir"
                    List<InvoiceSEPTransactionListModel> tempList = tbpap.TransactionList;
                    foreach (var item in tempList)
                    {
                        if (item.CurrentStateDefID != AccountTransaction.States.Paid && item.CurrentStateDefID != AccountTransaction.States.Cancelled && item.CurrentStateDefID != AccountTransaction.States.Invoiced && item.CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful)
                        {
                            AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(item.ObjectID, typeof(AccountTransaction));
                            if (tbpap.TurnType)
                                acctrx.TurnToPatientShare(true, true);
                            else
                                acctrx.TurnToPayerShare(true);
                            objectContext.Save();
                        }
                    }

                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw new TTException("turnBetweenPayerAndPatient: " + ex.Message);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public string getMedulaAciklama([FromQuery] Guid acctrx)
        {
            string result = "";
            using (var objectContext = new TTObjectContext(true))
            {
                AccountTransaction actx = (AccountTransaction)objectContext.GetObject(acctrx, typeof(AccountTransaction));
                result = actx.GetDescriptionInfoFromDVO();
            }

            return result;
        }

        public class SaveMedulaAciklamaModel
        {
            public string Description
            {
                get;
                set;
            }

            public Guid accTrxObjectID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public void saveMedulaAciklama(SaveMedulaAciklamaModel smam)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(smam.accTrxObjectID, typeof(AccountTransaction));
                    if (acctrx.CurrentStateDefID != AccountTransaction.States.Paid && acctrx.CurrentStateDefID != AccountTransaction.States.Cancelled && acctrx.CurrentStateDefID != AccountTransaction.States.Invoiced && acctrx.CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful)
                    {
                        acctrx.MedulaDescription = smam.Description;
                        objectContext.Save();
                        objectContext.FullPartialllyLoadedObjects();
                    }
                }
                catch (Exception ex)
                {
                    throw new TTException("saveMedulaAciklama: " + ex.Message);
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<InvoiceLogModel> getTransactionHistory([FromQuery] Guid trxObjectID)
        {
            List<InvoiceLogModel> result = new List<InvoiceLogModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                BindingList<InvoiceLog.GetInvoiceLog_Class> items = InvoiceLog.GetInvoiceLog(objectContext, trxObjectID, InvoiceLogObjectTypeEnum.AccountTransaction);
                var query =
                    from i in items
                    orderby i.Date descending
                    select new InvoiceLogModel { Date = i.Date.Value.ToString("dd/MM/yyyy HH:mm:ss"), UserName = i.Name, LogType = i.Mtype.ToString(), Message = i.Message, Operation = i.Optype.ToString() };
                result = query.ToList();
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<Infrastructure.Models.ComboListItem> getSEPListFromUniqueRefNo([FromQuery] string UniqueRefNo)
        {
            List<Infrastructure.Models.ComboListItem> result = new List<Infrastructure.Models.ComboListItem>();

            using (var objectContext = new TTObjectContext(true))
            {
                BindingList<Patient> pList = Patient.GetPatientsByUniqueRefNo(objectContext, Convert.ToInt64(UniqueRefNo));

                if (pList.Count > 0)
                {
                    Patient p = pList[0];
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" AND SUBEPISODE.EPISODE.PATIENT  = '" + p.ObjectID + "' ");
                    BindingList<SubEpisodeProtocol.GetSEPByInjection_Class> tempList = SubEpisodeProtocol.GetSEPByInjection(objectContext, (int)APRTypeEnum.PAYER, sb.ToString());
                    foreach (var sep in tempList)
                    {
                        if (sep.Statusenum.Value != MedulaSubEpisodeStatusEnum.Invoiced && sep.Statusenum.Value != MedulaSubEpisodeStatusEnum.InvoiceInconsistent)
                        {
                            result.Add(new Infrastructure.Models.ComboListItem(sep.ObjectID, sep.MedulaProvizyonTarihi.Value.ToString("dd/MM/yyyy") + " / " + sep.Id + "-" + sep.MedulaTakipNo + " / " + sep.Specialityname));
                        }
                    }
                }
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Islemleri)]
        public List<InfoModel> malzemeSatinalmaBilgileri([FromQuery] Guid trxObjectID)
        {
            TTObjectContext context = new TTObjectContext(true);
            AccountTransaction accTrx = context.GetObject<AccountTransaction>(trxObjectID);

            if (accTrx.SubActionMaterial == null)
                throw new TTException("Malzeme seçiniz");

            if (accTrx.StockOutTransaction == null)
                throw new TTException("Malzeme satın alma bilgilerine ulaşılamadı");

            List<InfoModel> result = new List<InfoModel>();
            StockTransaction.InFirstStockTransactionInvoceDetailDVO purchaseInfo = accTrx.StockOutTransaction.GetInFirstStockTransactionInvoceDetailDVO();

            if (purchaseInfo != null)
            {
                result.Add(new InfoModel("Giriş İşlem Tipi", purchaseInfo.GirisIslemTipi));
                result.Add(new InfoModel("İşlem Tarihi", purchaseInfo.IslemTarihi.HasValue ? purchaseInfo.IslemTarihi.Value.ToString("dd.MM.yyyy") : null));
                result.Add(new InfoModel("İhale Tarihi", purchaseInfo.IhaleTarihi.HasValue ? purchaseInfo.IhaleTarihi.Value.ToString("dd.MM.yyyy") : null));
                result.Add(new InfoModel("Karar Tarihi", purchaseInfo.KararTarihi.HasValue ? purchaseInfo.KararTarihi.Value.ToString("dd.MM.yyyy") : null));
                result.Add(new InfoModel("Dayanak Belge Tarihi", purchaseInfo.DayanakBelgeTarihi.HasValue ? purchaseInfo.DayanakBelgeTarihi.Value.ToString("dd.MM.yyyy") : null));
                result.Add(new InfoModel("Alım Yöntemi", purchaseInfo.AlimYontemi.HasValue ? Common.GetDisplayTextOfDataTypeEnum(purchaseInfo.AlimYontemi) : null));
                result.Add(new InfoModel("Hastaya Özel Malzeme", purchaseInfo.HastayaOzel ? "Evet" : "Hayır"));
                result.Add(new InfoModel("Firma", purchaseInfo.Firma));
                result.Add(new InfoModel("İhale No", purchaseInfo.IhaleNo));
                result.Add(new InfoModel("Dayanak Belge No", purchaseInfo.DayanakBelgeNo));
                result.Add(new InfoModel("Satın Alış Miktarı", purchaseInfo.SatinAlisMiktari.HasValue ? purchaseInfo.SatinAlisMiktari.Value.ToString() : null));
                result.Add(new InfoModel("KDV", purchaseInfo.KDV.HasValue ? purchaseInfo.KDV.Value.ToString() : null));
                result.Add(new InfoModel("KDV'siz Fiyat", purchaseInfo.KDVsizFiyat.HasValue ? purchaseInfo.KDVsizFiyat.Value.ToString() : null));
                result.Add(new InfoModel("KDV'li Fiyat", purchaseInfo.KDVliFiyat.HasValue ? purchaseInfo.KDVliFiyat.Value.ToString() : null));
                result.Add(new InfoModel("Maliyet", null));
            }

            return result;
        }
    }
}