
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
    public partial class XXXXXXMedulaServices : TTObject
    {
        #region Methods
        [Serializable]
        public class BasvuruTakipOkuParam : AsyncBase, IWebMethodCallback
        {
            public BasvuruTakipOkuParam() { }

            public BasvuruTakipOkuParam(TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuDVO basvuruTakipOkuDVO)
            {

                _basvuruTakipOkuDVO = basvuruTakipOkuDVO;

            }

            public TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuDVO _basvuruTakipOkuDVO;

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.basvuruTakipOkuCevapDVO)returnValue;
                    HastaBasvuruTakipOkuCompletedInternal(result, SubEpisodeProtocolObjectID, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }
            public void HastaBasvuruTakipOkuCompletedInternal(HastaKabulIslemleri.basvuruTakipOkuCevapDVO result, string SubEpisodeProtocolObjectID, TTObjectContext objectcontext)
            {

                if (result.sonucKodu != null && result.sonucKodu == "0000")
                {
                    for (int i = 0; i < result.basvuruTakip.Length; i++)
                    {
                        TTObjectClasses.HastaKabulIslemleri.basvuruTakipDVO takip = result.basvuruTakip[i];
                        SubEpisodeProtocol sep = MedulaHelper.GetSubEpisodeProtocolByProvisionNo(takip.takipNo, objectcontext);
                        if (sep != null)
                        {
                            sep.MedulaSonucKodu = result.sonucKodu;  //" Fatura Takip Durumu " + takip.takipFaturaDurumu + "  Takip No :" + takip.takipNo;
                            sep.MedulaSonucMesaji = result.sonucMesaji + " Fatura Takip Durumu " + takip.takipFaturaDurumu;
                        }
                    }
                }
                else
                {
                    SubEpisodeProtocol sep = MedulaHelper.GetSubEpisodeProtocolByObjectID(SubEpisodeProtocolObjectID, objectcontext);
                    if (sep != null)
                    {
                        sep.MedulaSonucKodu = result.sonucKodu; // " Basvuru No " + result.hastaBasvuruNo + " Okuma Sonucu Ba�ar�s�z Sonuc Kodu " + result.sonucKodu + "  Sonuc Aciklama " + result.sonucMesaji;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                    }
                }
            }



            #endregion

            #region IAttributeInterface Members

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #endregion
        }

        [Serializable]
        public class AsyncBase
        {
            [NonSerialized]
            protected TTObjectContext objectcontext;

            private string _subEpisodeProtocolObjectID;

            private string _messageObjectID;

            public string MessageObjectID
            {
                get { return _messageObjectID; }
                set { _messageObjectID = value; }
            }

            public string SubEpisodeProtocolObjectID
            {
                get { return _subEpisodeProtocolObjectID; }
                set { _subEpisodeProtocolObjectID = value; }
            }

            public AsyncBase()
            {
                MessageObjectID = Guid.NewGuid().ToString();
            }
        }

        [Serializable]
        public class HastaKabulParam : AsyncBase, IWebMethodCallback
        {
            public HastaKabulParam() { }

            public HastaKabulParam(TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO, string sepObjectID)
            {
                _provizyonGirisDVO = provizyonGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
            }
            public TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO _provizyonGirisDVO;

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO)returnValue;
                    if (result.sonucKodu.Equals("0000") || result.sonucKodu.Equals("9000") || result.sonucKodu.Equals("0008"))
                    {
                        string subEpisodeProtocolObjectID = SubEpisodeProtocolObjectID;
                        HastaKabulCompletedInternal(result, _provizyonGirisDVO, subEpisodeProtocolObjectID, ObjectContext);
                        MedulaHelper.SaveAndDisposeContext(ObjectContext);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    return true;

            }

            #endregion

            #region IAttributeInterface Members

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            public void HastaKabulCompletedInternal(TTObjectClasses.HastaKabulIslemleri.provizyonCevapDVO result, TTObjectClasses.HastaKabulIslemleri.provizyonGirisDVO provizyonGirisDVO,
                                                    string subEpisodeProtocolObjectID, TTObjectContext _context)
            {
                SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(subEpisodeProtocolObjectID), typeof(SubEpisodeProtocol));
                if (result.sonucKodu.Equals("0000") || result.sonucKodu.Equals("9000") || result.sonucKodu.Equals("0008"))
                {
                    sep.CurrentStateDefID = MedulaProvision.States.New;
                    sep.MedulaTakipNo = result.takipNo;

                    if (string.IsNullOrEmpty(provizyonGirisDVO.takipNo) == false)
                    {
                        sep.ParentSEP = SubEpisodeProtocol.GetSEPByProvisionNo(provizyonGirisDVO.takipNo);

                        if (sep.ParentSEP != null && sep.ParentSEP.MedulaProvizyonTipi != null)
                            sep.MedulaProvizyonTipi = sep.ParentSEP.MedulaProvizyonTipi;

                    }


                    //TODO: AAE buras� kontrol edilmeli.
                    if (sep.Brans == null)
                        sep.Brans = SpecialityDefinition.GetBrans(provizyonGirisDVO.bransKodu);
                    else
                    {
                        if (sep.Brans.Code != provizyonGirisDVO.bransKodu)
                            sep.Brans = SpecialityDefinition.GetBrans(provizyonGirisDVO.bransKodu);
                        else
                        {
                            if (provizyonGirisDVO.bransKodu != "9900") // 9900 (Di�er) kodlu birden �ok tan�m oldu�u i�in, de�i�tirmesin diye kontrol
                                sep.Brans = SpecialityDefinition.GetBrans(provizyonGirisDVO.bransKodu);
                        }
                    }

                    if (provizyonGirisDVO.donorTCKimlikNo != null && provizyonGirisDVO.donorTCKimlikNo != "")
                        sep.MedulaDonorTCKimlikNo = Convert.ToInt64(provizyonGirisDVO.donorTCKimlikNo);
                    sep.MedulaProvizyonTarihi = Convert.ToDateTime(provizyonGirisDVO.provizyonTarihi);
                    sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi(provizyonGirisDVO.provizyonTipi);

                    if (result.hastaBilgileri != null && !string.IsNullOrEmpty(result.hastaBilgileri.sigortaliTuru))
                        sep.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru(result.hastaBilgileri.sigortaliTuru);
                    else
                        sep.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru(provizyonGirisDVO.sigortaliTuru);

                    if (result.hastaBilgileri != null && !string.IsNullOrEmpty(result.hastaBilgileri.devredilenKurum))
                        sep.MedulaDevredilenKurum = DevredilenKurum.GetDevredilenKurum(result.hastaBilgileri.devredilenKurum);
                    else
                        sep.MedulaDevredilenKurum = DevredilenKurum.GetDevredilenKurum(provizyonGirisDVO.devredilenKurum);

                    sep.MedulaTakipTipi = TakipTipi.GetTakipTipi(provizyonGirisDVO.takipTipi);
                    sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi(provizyonGirisDVO.tedaviTipi);
                    sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru(provizyonGirisDVO.tedaviTuru);
                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryNotCompleted;
                    sep.MedulaSonucKodu = result.sonucKodu;
                    sep.MedulaSonucMesaji = result.sonucMesaji;
                    sep.MedulaBasvuruNo = result.hastaBasvuruNo;

                    sep.MedulaPlakaNo = provizyonGirisDVO.plakaNo;
                    //md.GreenCardSendingFacilityCode = provizyonGirisDVO.yesilKartSevkEdenTesisKodu.ToString();

                    if (result.hastaBilgileri != null && !string.IsNullOrEmpty(result.hastaBilgileri.katilimPayindanMuaf))
                        sep.MedulaKatilimPayindanMuaf = result.hastaBilgileri.katilimPayindanMuaf;

                    if (!sep.MedulaYupassNo.HasValue && provizyonGirisDVO.yardimHakkiID.HasValue)
                        sep.MedulaYupassNo = provizyonGirisDVO.yardimHakkiID;
                }
                else
                {
                    sep.MedulaSonucKodu = result.sonucKodu;
                    sep.MedulaSonucMesaji = result.sonucMesaji;
                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                }
            }



            #endregion
        }

        [Serializable]
        public class HastaKabulIptalParam : AsyncBase, IWebMethodCallback
        {
            public HastaKabulIptalParam() { }

            public HastaKabulIptalParam(TTObjectClasses.HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO, string subEpisodeProtocolObjectID)
            {
                _takipSilGirisDVO = takipSilGirisDVO;
                SubEpisodeProtocolObjectID = subEpisodeProtocolObjectID;
            }
            public TTObjectClasses.HastaKabulIslemleri.takipSilGirisDVO _takipSilGirisDVO;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.takipSilCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.takipSilCevapDVO)returnValue;
                    HastaKabulIptalCompletedInternal(result, _takipSilGirisDVO, SubEpisodeProtocolObjectID, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }


            public void HastaKabulIptalCompletedInternal(TTObjectClasses.HastaKabulIslemleri.takipSilCevapDVO result, TTObjectClasses.HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO,
                                                         string sepObjectID, TTObjectContext _context)
            {
                if (result != null)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(sepObjectID), typeof(SubEpisodeProtocol));
                    //0535 sonu� kodu sistemde bulunan fakat meduladan silinmi� provizyonno hatas�d�r
                    if (result.sonucKodu.Equals("0000") || result.sonucKodu.Equals("0535"))
                    {
                        sep.MedulaTakipNo = null;
                        sep.MedulaBasvuruNo = null;
                        sep.MedulaFaturaTutari = null;
                        //md.InvoiceDescription = null;
                        //md.MedulaInvoice = null;
                        //md.ProvizyonTipi = null;

                        //sep.ParentSEP = null;
                        sep.InvoiceCancelCount = null;
                        //md.TaburcuKodu = null;
                        //md.TakipTipi = null;
                        //md.TedaviTipi = null;
                        //md.ProvisionDate = null;
                        //md.LicensePlateNo = null;
                        //md.DonorUniqueRefno = null;
                        //md.GreenCardSendingFacilityCode = null;

                        BindingList<AccountTransaction> acctxList = (BindingList<AccountTransaction>)_context.QueryObjects("AccountTransaction", " SUBEPISODEPROTOCOL = '" + sep.ObjectID.ToString() + "' AND MEDULAPROCESSNO IS NOT NULL");
                        foreach (AccountTransaction acctx in acctxList)
                        {
                            if (acctx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                            {
                                acctx.MedulaProcessNo = null;
                                acctx.MedulaResultCode = null;
                                acctx.MedulaResultMessage = null;
                                acctx.MedulaPrice = null;
                                acctx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                        }

                        BindingList<SEPDiagnosis> sdList = SEPDiagnosis.GetBySEP(_context, sep.ObjectID);
                        foreach (SEPDiagnosis sd in sdList)
                        {
                            sd.MedulaProcessNo = null;
                            sd.MedulaResultCode = null;
                            sd.MedulaResultMessage = null;
                            sd.CurrentStateDefID = SEPDiagnosis.States.New;
                        }

                        sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
                    }

                    sep.MedulaSonucKodu = result.sonucKodu;
                    sep.MedulaSonucMesaji = result.sonucMesaji;
                }
            }

            #endregion
        }

        [Serializable]
        public class HastaKabulOkuParam : AsyncBase, IWebMethodCallback
        {
            public HastaKabulOkuParam() { }

            public HastaKabulOkuParam(TTObjectClasses.HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO, string sepObjectID, string createdBy, SubEpisodeProtocol sep)
            {
                _takipOkuGirisDVO = takipOkuGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
                _createdBy = createdBy;
                _sep = sep;
            }
            public TTObjectClasses.HastaKabulIslemleri.takipOkuGirisDVO _takipOkuGirisDVO;
            public string _createdBy;

            public SubEpisodeProtocol _sep;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.takipDVO result = (TTObjectClasses.HastaKabulIslemleri.takipDVO)returnValue;

                    if (_createdBy == "UpdateTedaviTipi")
                        UpdateTedaviTipiCompletedInternal(result, SubEpisodeProtocolObjectID, _takipOkuGirisDVO, ObjectContext);
                    else if (_createdBy == "HastaKabulOku")
                        HastaKabulOkuCompletedInternal(result, _takipOkuGirisDVO);

                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }


            public void HastaKabulOkuCompletedInternal(TTObjectClasses.HastaKabulIslemleri.takipDVO result, TTObjectClasses.HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO)
            {
                if (result != null && result.sonucKodu == "0000")
                {
                    InvoiceLog.AddInfo("Meduladan takip ba�ar� bir �ekilde okundu. Takip No:" + result.takipNo, _sep.ObjectID, InvoiceOperationTypeEnum.TakipOku, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    _sep.MedulaSonucKodu = result.sonucKodu;
                    _sep.MedulaSonucMesaji = result.sonucMesaji;

                    _sep.MedulaBasvuruNo = result.hastaBasvuruNo;
                    _sep.MedulaTakipNo = result.takipNo;

                    _sep.MedulaDevredilenKurum = DevredilenKurum.GetDevredilenKurum(result.hastaBilgileri.devredilenKurum);
                    _sep.ChangePayerByMedulaDevredilenKurum();

                    if (!string.IsNullOrEmpty(result.donorTCKimlikNo))
                        _sep.MedulaDonorTCKimlikNo = Convert.ToInt64(result.donorTCKimlikNo);

                    if (!string.IsNullOrEmpty(result.takipTarihi))
                        _sep.MedulaProvizyonTarihi = Convert.ToDateTime(result.takipTarihi);

                    _sep.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru(result.hastaBilgileri.sigortaliTuru);
                    _sep.Brans = SpecialityDefinition.GetBrans(result.bransKodu);

                    _sep.MedulaTakipTipi = TakipTipi.GetTakipTipi(result.takipTipi);
                    _sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi(result.tedaviTipi);
                    _sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi(result.provizyonTipi);
                    _sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru(result.tedaviTuru);

                    _sep.MedulaKapsamAdi = result.hastaBilgileri.kapsamAdi;
                    _sep.MedulaKatilimPayindanMuaf = result.hastaBilgileri.katilimPayindanMuaf;
                    _sep.MedulaSigortaliTuru = SigortaliTuru.GetSigortaliTuru(result.hastaBilgileri.sigortaliTuru);
                    _sep.MedulaIstisnaiHal = IstisnaiHal.GetIstisnaiHal(result.istisnaiHal);

                    _sep.InvoiceCancelCount = 3 - result.fatutaIptalHakki;

                    if (!string.IsNullOrEmpty(result.faturaTarihi))
                        _sep.MedulaFaturaTarihi = Convert.ToDateTime(result.faturaTarihi);

                    _sep.MedulaFaturaTeslimNo = result.faturaTeslimNo;

                    if (!string.IsNullOrEmpty(result.ilkTakipNo))
                    {
                        _sep.ParentSEP = SubEpisodeProtocol.GetSEPByProvisionNo(result.ilkTakipNo);

                        if (_sep.ParentSEP != null)
                            _sep.SEPMaster = _sep.ParentSEP.SEPMaster;
                    }
                    else
                        _sep.ParentSEP = null;
                }
            }

            public void UpdateTedaviTipiCompletedInternal(HastaKabulIslemleri.takipDVO result,
                                                          string sepObjectID, TTObjectClasses.HastaKabulIslemleri.takipOkuGirisDVO takipOkuGirisDVO, TTObjectContext _context)
            {
                if (result != null)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(sepObjectID), typeof(SubEpisodeProtocol));
                    if (result.sonucKodu.Equals("0000"))
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        string eskiDeger = sep.MedulaTedaviTipi.tedaviTipiAdi;
                        if (result.tedaviTipi != null)
                            sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi(result.tedaviTipi.ToString());
                        else
                            sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi(takipOkuGirisDVO.yeniTedaviTipi.ToString());
                        string yeniDeger = sep.MedulaTedaviTipi.tedaviTipiAdi;
                        InvoiceLog.AddInfo(string.Format("Tedavi Tipi De�i�tirme ��lemi Ba�ar�l�. Takip No: {0} (Eski De�er: {1} , Yeni De�er: {2})", takipOkuGirisDVO.takipNo, eskiDeger, yeniDeger), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTedaviTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                    else
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        InvoiceLog.AddErr(string.Format("Tedavi Tipi De�i�tirme ��lemi Ba�ar�s�z. Takip No: {0} Sonuc Kodu: {1} , Sonuc Aciklama: {2}", takipOkuGirisDVO.takipNo, result.sonucKodu, result.sonucMesaji), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTedaviTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                }
            }

            #endregion
        }

        [Serializable]
        public class UpdateProvizyonTipiParam : AsyncBase, IWebMethodCallback
        {
            public UpdateProvizyonTipiParam() { }

            public UpdateProvizyonTipiParam(TTObjectClasses.HastaKabulIslemleri.provizyonDegistirGirisDVO provizyonDegistirGirisDVO, string sepObjectID)
            {
                _provizyonDegistirGirisDVO = provizyonDegistirGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
            }
            public TTObjectClasses.HastaKabulIslemleri.provizyonDegistirGirisDVO _provizyonDegistirGirisDVO;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.provizyonDegistirCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.provizyonDegistirCevapDVO)returnValue;
                    UpdateProvizyonTipiCompletedInternal(result, _provizyonDegistirGirisDVO, SubEpisodeProtocolObjectID, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }

            public void UpdateProvizyonTipiCompletedInternal(TTObjectClasses.HastaKabulIslemleri.provizyonDegistirCevapDVO result, TTObjectClasses.HastaKabulIslemleri.provizyonDegistirGirisDVO provizyonDegistirGirisDVO,
                                                             string sepObjectID, TTObjectContext _context)
            {
                if (result != null)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(sepObjectID), typeof(SubEpisodeProtocol));
                    if (result.sonucKodu.Equals("0000"))
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        string eskiDeger = sep.MedulaProvizyonTipi.provizyonTipiAdi;
                        if (result.yeniProvizyonTipi != null)
                            sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi(result.yeniProvizyonTipi.ToString());
                        else
                            sep.MedulaProvizyonTipi = ProvizyonTipi.GetProvizyonTipi(provizyonDegistirGirisDVO.yeniProvizyonTipi.ToString());
                        string yeniDeger = sep.MedulaProvizyonTipi.provizyonTipiAdi;
                        InvoiceLog.AddInfo(string.Format("Provizyon Tipi De�i�tirme ��lemi Ba�ar�l�. Takip No: {0} (Eski De�er: {1} , Yeni De�er: {2})", provizyonDegistirGirisDVO.takipNo, eskiDeger, yeniDeger), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateProvizyonTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                    else
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        InvoiceLog.AddErr(string.Format("Provizyon Tipi De�i�tirme ��lemi Ba�ar�s�z. Takip No: {0} Sonuc Kodu: {1} , Sonuc Aciklama: {2}", provizyonDegistirGirisDVO.takipNo, result.sonucKodu, result.sonucMesaji), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateProvizyonTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                }
            }

            #endregion
        }

        [Serializable]
        public class UpdateTakipTipiParam : AsyncBase, IWebMethodCallback
        {
            public UpdateTakipTipiParam() { }

            public UpdateTakipTipiParam(TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO, string sepObjectID)
            {
                _takipTipiDegistirGirisDVO = takipTipiDegistirGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
            }
            public TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirGirisDVO _takipTipiDegistirGirisDVO;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirCevapDVO)returnValue;
                    UpdateTakipTipiCompletedInternal(result, _takipTipiDegistirGirisDVO, SubEpisodeProtocolObjectID, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }


            public void UpdateTakipTipiCompletedInternal(TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirCevapDVO result, TTObjectClasses.HastaKabulIslemleri.takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO,
                string sepObjectID, TTObjectContext _context)
            {
                if (result != null)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(sepObjectID), typeof(SubEpisodeProtocol));
                    if (result.sonucKodu.Equals("0000"))
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        string eskiDeger = sep.MedulaTakipTipi.takipTipiAdi;
                        if (result.yeniTakipTipi != null)
                            sep.MedulaTakipTipi = TakipTipi.GetTakipTipi(result.yeniTakipTipi.ToString());
                        else
                            sep.MedulaTakipTipi = TakipTipi.GetTakipTipi(takipTipiDegistirGirisDVO.yeniTakiTipi.ToString());
                        string yeniDeger = sep.MedulaTakipTipi.takipTipiAdi;
                        InvoiceLog.AddInfo(string.Format("Takip Tipi De�i�tirme ��lemi Ba�ar�l�. Takip No: {0} (Eski De�er: {1} , Yeni De�er: {2})", _takipTipiDegistirGirisDVO.takipNo, eskiDeger, yeniDeger), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTakipTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                    else
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        InvoiceLog.AddErr(string.Format("Takip Tipi De�i�tirme ��lemi Ba�ar�s�z. Takip No: {0} Sonuc Kodu: {1} , Sonuc Aciklama: {2}", _takipTipiDegistirGirisDVO.takipNo, result.sonucKodu, result.sonucMesaji), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTakipTipi, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                }
            }


            #endregion
        }



        [Serializable]
        public class UpdateTedaviTuruParam : AsyncBase, IWebMethodCallback
        {
            public UpdateTedaviTuruParam() { }

            public UpdateTedaviTuruParam(TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirGirisDVO tedaviTuruDegistirGirisDVO, string sepObjectID)
            {
                _tedaviTuruDegistirGirisDVO = tedaviTuruDegistirGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
            }
            public TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirGirisDVO _tedaviTuruDegistirGirisDVO;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (returnValue != null)
                {
                    TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirCevapDVO result = (TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirCevapDVO)returnValue;
                    UpdateTedaviTuruCompletedInternal(result, _tedaviTuruDegistirGirisDVO, SubEpisodeProtocolObjectID, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }


            public void UpdateTedaviTuruCompletedInternal(TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirCevapDVO result, TTObjectClasses.HastaKabulIslemleri.tedaviTuruDegistirGirisDVO tedaviTuruDegistirGirisDVO,
                string sepObjectID, TTObjectContext _context)
            {
                if (result != null)
                {
                    SubEpisodeProtocol sep = (SubEpisodeProtocol)_context.GetObject(new Guid(sepObjectID), typeof(SubEpisodeProtocol));
                    if (result.sonucKodu.Equals("0000"))
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        string eskiDeger = sep.MedulaTedaviTuru.tedaviTuruAdi;
                        if (result.yeniTedaviTuru != null)
                            sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru(result.yeniTedaviTuru.ToString());
                        else
                            sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru(tedaviTuruDegistirGirisDVO.yeniTedaviTuru.ToString());
                        string yeniDeger = sep.MedulaTedaviTuru.tedaviTuruAdi;
                        InvoiceLog.AddInfo(string.Format("Tedavi T�r� De�i�tirme ��lemi Ba�ar�l�. Takip No: {0} (Eski De�er: {1} , Yeni De�er: {2})", _tedaviTuruDegistirGirisDVO.takipNo, eskiDeger, yeniDeger), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTedaviTuru, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                    else
                    {
                        sep.MedulaSonucKodu = result.sonucKodu;
                        sep.MedulaSonucMesaji = result.sonucMesaji;
                        InvoiceLog.AddErr(string.Format("Tedavi T�r� De�i�tirme ��lemi Ba�ar�s�z. Takip No: {0} Sonuc Kodu: {1} , Sonuc Aciklama: {2}", _tedaviTuruDegistirGirisDVO.takipNo, result.sonucKodu, result.sonucMesaji), new Guid(sepObjectID), InvoiceOperationTypeEnum.UpdateTedaviTuru, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                    }
                }
            }



            #endregion
        }


        [Serializable]
        public class HizmetKayitParam : AsyncBase, IWebMethodCallback
        {
            public HizmetKayitParam() { }

            public HizmetKayitParam(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO, List<Guid> accountTransactionIDs)
            {
                _hizmetKayitGirisDVO = hizmetKayitGirisDVO;
                _accountTransactionIDs = accountTransactionIDs;
                //SubEpisodeProtocolObjectID = subEpisodeProtocolObjectID;

            }


            public HizmetKayitParam(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO, string subEpisodeProtocolObjectID)
            {
                _hizmetKayitGirisDVO = hizmetKayitGirisDVO;
                SubEpisodeProtocolObjectID = subEpisodeProtocolObjectID;

            }

            public TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO _hizmetKayitGirisDVO;
            public List<Guid> _accountTransactionIDs;
            public string _subEpisodeObjectID;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }



            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {

                    TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO result = (TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO)returnValue;
                    HizmetKayitCompletedInternal(result, _hizmetKayitGirisDVO, ObjectContext, true);

                }
                return true;
            }

            public void HizmetKayitCompletedInternal(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO result,
                                                     TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO, TTObjectContext _context, bool setMedulaProvisionStatus)
            {
                // Meduladan d�nen sonu� kodu ve sonu� mesaj� set edilir
                //MedulaProvision mp = MedulaHelper.GetMedulaProvisionByProvisionNo(hizmetKayitGirisDVO.takipNo, _context);

                ControlErrorCode(result.sonucKodu, result.sonucMesaji, _context);

                SubEpisodeProtocol sep = SubEpisodeProtocol.GetSEPByProvisionNo(hizmetKayitGirisDVO.takipNo);
                sep.MedulaSonucKodu = result.sonucKodu;
                sep.MedulaSonucMesaji = result.sonucMesaji;

                // Toplu olarak hizmet kayd� g�nderimi yap�ld� ise, gelen ba�ar�l� veya ba�ar�s�z kay�tlarda d�n�l�yor
                if (result.sonucKodu.Equals("0000"))
                    MedulaHelper.setBasariliIslem(result, _context);
                else
                {
                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    //if(result.hataliKayitlar != null && result.hataliKayitlar.Length == 1 && result.hataliKayitlar[0] == null)
                    //{
                    //    MedulaHelper.setHataliIslemFromHizmetKayitGirisDVO(hizmetKayitGirisDVO, _context,result.sonucKodu,result.sonucMesaji);
                    //}
                    //else 
                    if (result.hataliKayitlar != null)
                    {
                        MedulaHelper.setHataliIslem(result, _context);
                        // Senkron hizmet kayd�nda gerek olmad��� i�in kapat�ld�, asenkron i�in gerekirse a��lacak
                        //MedulaHelper.setStateNewAgainIslem(hizmetKayitGirisDVO, result, _context);
                    }

                }
                _context.Save();

                if (setMedulaProvisionStatus)
                {
                    MedulaHelper.SetMedulaProvisionStatusAfterProcedureEntryByProvisionNo(result.takipNo, _context);
                    _context.Save();
                }
            }



            #endregion
        }

        public static void ControlErrorCode(string errorCode, string errorMessage, TTObjectContext _context = null)
        {
            if (_context == null)
                _context = new TTObjectContext(false);

            List<string> errorCodeList = new List<string>();
            errorCodeList.Add(errorCode);
            BindingList<MedulaErrorCodeDefinition> resultList = MedulaErrorCodeDefinition.GetMedulaErrorByCodes(_context, errorCodeList);
            if (resultList.Count == 0)
            {
                MedulaErrorCodeDefinition.AddNewInstance(errorCode, errorMessage);
            }
        }

        [Serializable]
        public class HizmetKayitOkuParam : AsyncBase, IWebMethodCallback
        {
            public HizmetKayitOkuParam() { }
            public HizmetKayitOkuParam(TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO, List<string> accountTransactionIDs, string sepObjectID)
            {
                _hizmetOkuGirisDVO = hizmetOkuGirisDVO;
                _accountTransactionIDs = accountTransactionIDs;
                SubEpisodeProtocolObjectID = sepObjectID;
            }


            public HizmetKayitOkuParam(TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO, string sepObjectID)
            {
                _hizmetOkuGirisDVO = hizmetOkuGirisDVO;
                SubEpisodeProtocolObjectID = sepObjectID;
            }

            public TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO _hizmetOkuGirisDVO;
            public List<string> _accountTransactionIDs;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }



            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    TTObjectClasses.HizmetKayitIslemleri.hizmetOkuCevapDVO result = (TTObjectClasses.HizmetKayitIslemleri.hizmetOkuCevapDVO)returnValue;
                    HizmetOkuCompletedInternal(result, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }

            public void HizmetOkuCompletedInternal(TTObjectClasses.HizmetKayitIslemleri.hizmetOkuCevapDVO hizmetOkuCevapDVO, TTObjectContext _objectcontext)
            {
                try
                {

                    if (hizmetOkuCevapDVO != null)
                    {
                        if (hizmetOkuCevapDVO.sonucKodu == "0000")
                        {

                            if (hizmetOkuCevapDVO.hizmetler != null)
                            {
                            }

                        }
                        else
                        {

                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }


            #endregion
        }

        [Serializable]
        public class HizmetIptalParam : AsyncBase, IWebMethodCallback
        {
            public HizmetIptalParam() { }
            public HizmetIptalParam(TTObjectClasses.HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO, List<Guid> accountTransactionIDs, string sepObjectID, bool isAccountTransactionList)
            {
                _hizmetIptalGirisDVO = hizmetIptalGirisDVO;
                _accountTransactionIDs = accountTransactionIDs;
                _isAccountTransactionList = isAccountTransactionList;
                SubEpisodeProtocolObjectID = sepObjectID;
            }

            public TTObjectClasses.HizmetKayitIslemleri.hizmetIptalGirisDVO _hizmetIptalGirisDVO;
            public List<Guid> _accountTransactionIDs;
            public bool _isAccountTransactionList = true;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    TTObjectClasses.HizmetKayitIslemleri.hizmetIptalCevapDVO result = (TTObjectClasses.HizmetKayitIslemleri.hizmetIptalCevapDVO)returnValue;
                    HizmetIptalCompletedInternal(result, _hizmetIptalGirisDVO, _accountTransactionIDs, ObjectContext);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }


            public void HizmetIptalCompletedInternal(TTObjectClasses.HizmetKayitIslemleri.hizmetIptalCevapDVO result,
                                                     TTObjectClasses.HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO, List<Guid> accountTransactionIDs, TTObjectContext _context)
            {
                SubEpisodeProtocol sep = null;
                if (result != null)
                {
                    if (result.sonucKodu == "0000")
                    {
                        if (_isAccountTransactionList)
                        {
                            if (accountTransactionIDs != null && accountTransactionIDs.Count > 0)
                            {
                                foreach (Guid acctrxID in accountTransactionIDs)
                                {
                                    AccountTransaction acctrx = _context.GetObject<AccountTransaction>(acctrxID, false);
                                    if (acctrx != null)
                                    {
                                        if (acctrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                        {
                                            acctrx.MedulaProcessNo = "";
                                            acctrx.MedulaResultCode = null;
                                            acctrx.MedulaResultMessage = null;
                                            acctrx.CurrentStateDefID = AccountTransaction.States.New;
                                        }
                                        sep = acctrx.SubEpisodeProtocol;
                                    }
                                }
                            }
                            else
                            {
                                if (hizmetIptalGirisDVO.islemSiraNumaralari != null)
                                {
                                    foreach (string islemSiraNumarasi in hizmetIptalGirisDVO.islemSiraNumaralari)
                                    {
                                        AccountTransaction acctrx = MedulaHelper.GetAccountTransactionByMedulaProcessNo(islemSiraNumarasi, _context);
                                        if (acctrx != null)
                                        {
                                            if (acctrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                            {
                                                acctrx.MedulaProcessNo = "";
                                                acctrx.MedulaResultCode = null;
                                                acctrx.MedulaResultMessage = null;
                                                acctrx.CurrentStateDefID = AccountTransaction.States.New;
                                            }
                                            sep = acctrx.SubEpisodeProtocol;
                                        }
                                    }
                                }
                                else
                                {
                                    List<Guid> list = new List<Guid>();
                                    list.Add(AccountTransaction.States.MedulaEntrySuccessful);
                                    IList<AccountTransaction> acctrxList = AccountTransaction.GetMedulaTransactionsByProvisionNoAndState(_context, hizmetIptalGirisDVO.takipNo, list);
                                    foreach (AccountTransaction acctrx in acctrxList)
                                    {
                                        if (acctrx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                        {
                                            acctrx.MedulaProcessNo = "";
                                            acctrx.MedulaResultCode = null;
                                            acctrx.MedulaResultMessage = null;
                                            acctrx.CurrentStateDefID = AccountTransaction.States.New;
                                        }
                                        sep = acctrx.SubEpisodeProtocol;
                                    }

                                    list.Clear();
                                    list.Add(SEPDiagnosis.States.MedulaEntrySuccessful);
                                    IList<SEPDiagnosis> sdList = SEPDiagnosis.GetByProvisionNoAndState(_context, hizmetIptalGirisDVO.takipNo, list);
                                    foreach (SEPDiagnosis sd in sdList)
                                    {
                                        sd.MedulaProcessNo = "";
                                        sd.MedulaResultCode = null;
                                        sd.MedulaResultMessage = null;
                                        sd.CurrentStateDefID = SEPDiagnosis.States.New;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Actually SEPDiagnosis
                            if (accountTransactionIDs != null && accountTransactionIDs.Count > 0)
                            {
                                foreach (Guid sdID in accountTransactionIDs)
                                {
                                    SEPDiagnosis sd = _context.GetObject<SEPDiagnosis>(sdID, false);
                                    if (sd != null)
                                    {
                                        sd.MedulaProcessNo = "";
                                        sd.MedulaResultCode = null;
                                        sd.MedulaResultMessage = null;
                                        sd.CurrentStateDefID = SEPDiagnosis.States.New;
                                    }
                                }
                            }
                            else
                            {
                                if (hizmetIptalGirisDVO.islemSiraNumaralari != null)
                                {
                                    foreach (string islemSiraNumarasi in hizmetIptalGirisDVO.islemSiraNumaralari)
                                    {
                                        SEPDiagnosis sd = MedulaHelper.GetSEPDiagnosisByMedulaProcessNo(islemSiraNumarasi, _context);
                                        if (sd != null)
                                        {
                                            sd.MedulaProcessNo = "";
                                            sd.MedulaResultCode = null;
                                            sd.MedulaResultMessage = null;
                                            sd.CurrentStateDefID = SEPDiagnosis.States.New;
                                        }
                                    }
                                }
                                else
                                {
                                    List<Guid> list = new List<Guid>();
                                    list.Add(SEPDiagnosis.States.MedulaEntrySuccessful);
                                    IList<SEPDiagnosis> sdList = SEPDiagnosis.GetByProvisionNoAndState(_context, hizmetIptalGirisDVO.takipNo, list);
                                    foreach (SEPDiagnosis sd in sdList)
                                    {
                                        sd.MedulaProcessNo = "";
                                        sd.MedulaResultCode = null;
                                        sd.MedulaResultMessage = null;
                                        sd.CurrentStateDefID = SEPDiagnosis.States.New;
                                    }
                                }
                            }
                        }
                    }
                }
                _context.Save();

                if (sep != null)
                    sep.SetInvoiceStatusAfterProcedureEntry();

                _context.Save();

            }



            #endregion
        }

        [Serializable]
        public class FaturaTutarOkuParam : AsyncBase, IWebMethodCallback
        {
            public FaturaTutarOkuParam() { }


            public FaturaTutarOkuParam(TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO faturaGirisDVO, List<SubEpisodeProtocol> sepList, DateTime invoiceDate)
            {
                _faturaGirisDVO = faturaGirisDVO;
                _sepList = sepList;
                _invoiceDate = invoiceDate;
            }

            public TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO _faturaGirisDVO;
            public List<SubEpisodeProtocol> _sepList;
            public DateTime _invoiceDate;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }


            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    FaturaKayitIslemleri.faturaCevapDVO result = (FaturaKayitIslemleri.faturaCevapDVO)returnValue;
                    FaturaTutarOkuCompletedInternal(result);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;
            }

            public void FaturaTutarOkuCompletedInternal(FaturaKayitIslemleri.faturaCevapDVO result)
            {
                List<MedulaSubEpisodeStatusEnum> tempList = new List<MedulaSubEpisodeStatusEnum>();
                tempList.Add(MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted);
                tempList.Add(MedulaSubEpisodeStatusEnum.InvoiceRead);
                tempList.Add(MedulaSubEpisodeStatusEnum.InvoiceReadWithError);
                tempList.Add(MedulaSubEpisodeStatusEnum.InvoiceEntryWithError);


                if (result.faturaDetaylari != null && result.faturaDetaylari.Length > 0)
                {
                    foreach (var fd in result.faturaDetaylari)
                    {
                        if (fd != null)
                        {
                            SubEpisodeProtocol sep = _sepList.Where(s => s.MedulaTakipNo.Equals(fd.takipNo)).FirstOrDefault();
                            if (sep != null)
                            {
                                InvoiceLog.AddInfo("Fatura tutar okuma i�lemi ba�ar� ile yap�ld�.Okuma tutar�: " + fd.takipToplamTutar, sep.ObjectID, InvoiceOperationTypeEnum.FaturaTutarOku, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaSonucKodu = result.sonucKodu;
                                sep.MedulaSonucMesaji = result.sonucMesaji;
                                if (tempList.Contains(sep.InvoiceStatus.Value))
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceRead;

                                sep.MedulaFaturaTutari = fd.takipToplamTutar;

                                //TODO: AAE �ok hizmeti olan bir SEP denk gelirse bu fonksiyon denenecek. YAva� oldu�u i�in kapat�ld�. Loglar incelendi.
                                //XXXXXXMedulaServices.setIslemTutari(sep, fd);
                                List<AccountTransaction> actrxList = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").ToList();
                                if (fd.islemDetaylari != null)
                                {
                                    foreach (var islem in fd.islemDetaylari)
                                    {
                                        AccountTransaction acctx = actrxList.Where(x => x.MedulaProcessNo == islem.islemSiraNo).FirstOrDefault();

                                        if (acctx != null && acctx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                            acctx.MedulaPrice = islem.islemTutari;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (result.hataliKayitlar != null && result.hataliKayitlar.Length > 0)
                {
                    foreach (var hk in result.hataliKayitlar)
                    {
                        SubEpisodeProtocol sep = _sepList.Where(s => s.MedulaTakipNo.Equals(hk.takipNo)).FirstOrDefault();
                        InvoiceLog.AddErr("Fatura tutar okuma i�lemi s�ras�nda hatalar olu�tu. Hata Kodu:" + hk.hataKodu + " Hata Mesaj�:" + hk.hataMesaji, sep.ObjectID, InvoiceOperationTypeEnum.FaturaTutarOku, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                        if (sep != null)
                        {
                            if (sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").Count() > 0)
                            {
                                if (tempList.Contains(sep.InvoiceStatus.Value))
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceReadWithError;
                                sep.MedulaSonucKodu = hk.hataKodu;
                                sep.MedulaSonucMesaji = hk.hataMesaji;

                                ControlErrorCode(hk.hataKodu, hk.hataMesaji);
                            }
                        }
                    }
                }
                else if (result.hataliKayitlar == null && result.sonucKodu != "0000")
                {
                    foreach (var sep in _sepList)
                    {
                        if (sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").Count() > 0)
                        {
                            InvoiceLog.AddErr("Fatura tutar okuma i�lemi s�ras�nda hatalar olu�tu. Hata Kodu:" + result.sonucKodu + " Hata Mesaj�:" + result.sonucMesaji, sep.ObjectID, InvoiceOperationTypeEnum.FaturaTutarOku, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            if (tempList.Contains(sep.InvoiceStatus.Value))
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceReadWithError;
                            sep.MedulaSonucKodu = result.sonucKodu;
                            sep.MedulaSonucMesaji = result.sonucMesaji;

                            ControlErrorCode(result.sonucKodu, result.sonucMesaji);
                        }
                    }
                }
            }
            #endregion
        }




        [Serializable]
        public class FaturaGirisParam : AsyncBase, IWebMethodCallback
        {
            public FaturaGirisParam() { }

            public FaturaGirisParam(TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO faturaGirisDVO, List<SubEpisodeProtocol> sepList, DateTime invoiceDate, string description, Dictionary<Guid, InvoiceCollection> invoiceCollectionList)
            {
                _faturaGirisDVO = faturaGirisDVO;
                _sepList = sepList;
                _invoiceDate = invoiceDate;
                _description = description;
                _invoiceCollectionList = invoiceCollectionList;
            }

            public TTObjectClasses.FaturaKayitIslemleri.faturaGirisDVO _faturaGirisDVO;

            public List<SubEpisodeProtocol> _sepList;
            public DateTime _invoiceDate;
            public string _description;
            public Dictionary<Guid, InvoiceCollection> _invoiceCollectionList;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    FaturaKayitIslemleri.faturaCevapDVO result = (FaturaKayitIslemleri.faturaCevapDVO)returnValue;
                    FaturaGirisCompletedInternal(result, ObjectContext, 13);//
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;

            }

            public void FaturaGirisCompletedInternal(FaturaKayitIslemleri.faturaCevapDVO result, TTObjectContext _context, int type)
            {
                if (result.faturaDetaylari != null && result.faturaDetaylari.Length > 0)
                {
                    PayerInvoiceDocument pid = new PayerInvoiceDocument(_context, _invoiceDate, result.faturaTeslimNo, result.faturaRefNo, _description, result.faturaTutari, _sepList[0].Payer);

                    foreach (var fd in result.faturaDetaylari)
                    {
                        if (fd != null)
                        {

                            SubEpisodeProtocol sep = _sepList.Where(s => s.MedulaTakipNo.Equals(fd.takipNo)).FirstOrDefault();
                            InvoiceLog.AddInfo("Fatura kay�t i�lemi ba�ar� ile yap�ld�. Fatura Teslim No: " + result.faturaTeslimNo + " Fatura Tutar�: " + result.faturaTutari, sep.ObjectID, (InvoiceOperationTypeEnum)Common.GetEnumValueDefOfEnumValueV2("InvoiceOperationTypeEnum", type).EnumValue, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            if (sep != null)
                            {
                                sep.MedulaSonucKodu = result.sonucKodu;
                                sep.MedulaSonucMesaji = result.sonucMesaji;

                                double? total = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND INVOICEINCLUSION = 1 ").Sum(x => x.UnitPrice * x.Amount);
                                if (total.HasValue && Math.Round(total.Value, 2) != fd.takipToplamTutar)
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceInconsistent;
                                else
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.Invoiced;

                                sep.CurrentStateDefID = SubEpisodeProtocol.States.Closed;
                                sep.MedulaFaturaTutari = fd.takipToplamTutar;

                                //TODO: AAE �ok hizmeti olan bir SEP denk gelirse bu fonksiyon denenecek. YAva� oldu�u i�in kapat�ld�. Loglar incelendi.
                                //XXXXXXMedulaServices.setIslemTutari(sep, fd);

                                //DateTime logStartDate = DateTime.Now;
                                List<AccountTransaction> actrxList = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").ToList();
                                if (fd.islemDetaylari != null)
                                {
                                    foreach (var islem in fd.islemDetaylari)
                                    {
                                        AccountTransaction acctx = actrxList.Where(x => x.MedulaProcessNo == islem.islemSiraNo).FirstOrDefault();

                                        if (acctx != null && acctx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                        {
                                            acctx.MedulaPrice = islem.islemTutari;
                                            //TODO: AAE bu k�s�m �ok kay�t olu�tu�unda a��l�p performans denemesi yap�lacak.

                                            //E�er medula bir fiyat d�nm�� ve biz bu hizmeti dahil etmemi� isek onu faturaya dahil ediyoruz.
                                            if (acctx.InvoiceInclusion == false && islem.islemTutari > 0)
                                                acctx.InvoiceInclusion = true;

                                            #region fatura kay�t detaylar�

                                            //PayerInvoiceDocumentDetail invdd = new PayerInvoiceDocumentDetail(_context);
                                            //AccountTrxDocument accTrxDoc = new AccountTrxDocument(_context);

                                            //invdd.ExternalCode = acctx.ExternalCode;
                                            //invdd.Description = acctx.Description;
                                            //invdd.Amount = acctx.Amount;
                                            //invdd.UnitPrice = acctx.UnitPrice;
                                            //invdd.TotalDiscountPrice = 0;
                                            //invdd.TotalDiscountedPrice = acctx.MedulaPrice;

                                            //invdd.CurrentStateDefID = PayerInvoiceDocumentDetail.States.Invoiced;

                                            //accTrxDoc.AccountDocumentDetail = invdd;
                                            //accTrxDoc.AccountTransaction = acctx;
                                            //accTrxDoc.AccountTransaction.TotalDiscountPrice = 0;

                                            //string groupCode = string.Empty;
                                            //string groupDescription = string.Empty;
                                            //bool groupExists = false;
                                            //PayerInvoiceDocumentGroup procTempGroup = null;

                                            //if (acctx.PricingDetail != null && acctx.PricingDetail.PricingListGroup != null)
                                            //{
                                            //    groupCode = acctx.PricingDetail.PricingListGroup.ExternalCode;
                                            //    groupDescription = acctx.PricingDetail.PricingListGroup.Description;
                                            //}
                                            //else if (acctx.SubActionProcedure != null && acctx.SubActionProcedure.ProcedureObject != null && acctx.SubActionProcedure.ProcedureObject.ProcedureTree != null)
                                            //{
                                            //    groupCode = acctx.SubActionProcedure.ProcedureObject.ProcedureTree.ExternalCode;
                                            //    groupDescription = acctx.SubActionProcedure.ProcedureObject.ProcedureTree.Description;
                                            //}

                                            //if (string.IsNullOrEmpty(groupCode))
                                            //    groupCode = "-";
                                            //if (string.IsNullOrEmpty(groupDescription))
                                            //    groupDescription = "D��ER";

                                            //foreach (PayerInvoiceDocumentGroup pg in pid.PayerInvoiceDocumentGroups)
                                            //{
                                            //    if (pg.GroupCode == groupCode && pg.GroupDescription == groupDescription)
                                            //    {
                                            //        groupExists = true;
                                            //        procTempGroup = pg;
                                            //        break;
                                            //    }
                                            //}

                                            //if (groupExists == false)
                                            //{
                                            //    PayerInvoiceDocumentGroup invdg = new PayerInvoiceDocumentGroup(_context);
                                            //    invdg.GroupCode = groupCode;
                                            //    invdg.GroupDescription = groupDescription;
                                            //    invdg.PayerInvoiceDocumentDetails.Add(invdd);
                                            //    invdg.AccountDocument = pid;
                                            //}
                                            //else
                                            //    procTempGroup.PayerInvoiceDocumentDetails.Add(invdd);
                                            #endregion
                                        }
                                    }
                                }
                                //DateTime logEndDate = DateTime.Now;
                                //InvoiceLog.AddInfo("setIslemTutari totalMilisecond: " + (logEndDate.TimeOfDay.TotalMilliseconds - logStartDate.TimeOfDay.TotalMilliseconds), sep.ObjectID, InvoiceOperationTypeEnum.FaturaOkuveBilgileriGuncelle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);

                                //InvoiceCollection ic = sep.GetMyInvoiceCollection(_invoiceDate);

                                InvoiceCollection ic;
                                if (_invoiceCollectionList.TryGetValue(sep.ObjectID, out ic))
                                {
                                    sep.CreateInvoiceCollectionDetail(ic, InvoiceCollectionDetail.States.Invoiced, pid);
                                }

                            }
                        }
                    }
                }
                else if (result.hataliKayitlar != null && result.hataliKayitlar.Length > 0)
                {
                    foreach (var hk in result.hataliKayitlar)
                    {
                        SubEpisodeProtocol sep = _sepList.Where(s => s.MedulaTakipNo.Equals(hk.takipNo)).FirstOrDefault();
                        if (sep != null)
                        {
                            if (sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").Count() > 0)
                            {
                                InvoiceLog.AddErr("Fatura kay�t i�lemi hata ile sonu�land�.", sep.ObjectID, (InvoiceOperationTypeEnum)Common.GetEnumValueDefOfEnumValueV2("InvoiceOperationTypeEnum", type).EnumValue, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceEntryWithError;
                                sep.MedulaSonucKodu = hk.hataKodu;
                                sep.MedulaSonucMesaji = hk.hataMesaji;
                                if (hk.hataKodu.Equals("1692"))
                                {
                                    string[] splitted = hk.hataMesaji.Trim().Split(' ');
                                    if (splitted.Length > 0)
                                    {
                                        AccountTransaction acc = sep.AccountTransactions.Select("ID =" + splitted[0].Replace('H', ' ').Trim()).FirstOrDefault();
                                        if (acc != null)
                                        {
                                            acc.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                            acc.NabizResultCode = hk.hataKodu;
                                            acc.NabizResultMessage = hk.hataMesaji;
                                        }
                                    }
                                }
                                ControlErrorCode(hk.hataKodu, hk.hataMesaji, _context);
                            }
                        }
                    }
                }
                else if (result.hataliKayitlar == null && result.sonucKodu != "0000")
                {
                    foreach (var sep in _sepList)
                    {
                        if (sep != null && sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").Count() > 0)
                        {
                            InvoiceLog.AddErr("Fatura kay�t i�lemi hata ile sonu�land�.", sep.ObjectID, (InvoiceOperationTypeEnum)Common.GetEnumValueDefOfEnumValueV2("InvoiceOperationTypeEnum", type).EnumValue, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                            sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceEntryWithError;
                            sep.MedulaSonucKodu = result.sonucKodu;
                            sep.MedulaSonucMesaji = result.sonucMesaji;

                            ControlErrorCode(result.sonucKodu, result.sonucMesaji, _context);
                        }
                    }
                }
            }


            #endregion
        }

        public static void setIslemTutari(SubEpisodeProtocol sep, FaturaKayitIslemleri.faturaDetayDVO faturaDetayDVO)
        {
            DateTime logStartDate = DateTime.Now;
            var orderedAcctrx = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' ").Where(x => x.MedulaProcessNo != "" && x.MedulaProcessNo != null).OrderBy(k => k.MedulaProcessNo).ToList();
            var orderedFaturaDetay = faturaDetayDVO.islemDetaylari.OrderBy(k => k.islemSiraNo).ToList();
            var allIn = orderedAcctrx.Select(x => x.MedulaProcessNo).Equals(orderedFaturaDetay.Select(x => x.islemSiraNo));

            if (orderedAcctrx.Count == orderedFaturaDetay.Count && allIn)
            {
                for (int i = 0; i < orderedFaturaDetay.Count; i++)
                {
                    if (orderedAcctrx[i].MedulaProcessNo == orderedFaturaDetay[i].islemSiraNo)
                        orderedAcctrx[i].MedulaPrice = orderedFaturaDetay[i].islemTutari;
                }
            }
            else
            {
                for (int i = 0; i < orderedFaturaDetay.Count; i++)
                {
                    for (int j = 0; j < orderedAcctrx.Count; j++)
                    {
                        if (orderedFaturaDetay[i].islemSiraNo == orderedAcctrx[i].MedulaProcessNo)
                            orderedAcctrx[i].MedulaPrice = orderedFaturaDetay[i].islemTutari;
                    }
                }
            }
            DateTime logEndDate = DateTime.Now;
            InvoiceLog.AddInfo("setIslemTutari totalMilisecond: " + (logEndDate.TimeOfDay.TotalMilliseconds - logStartDate.TimeOfDay.TotalMilliseconds), sep.ObjectID, InvoiceOperationTypeEnum.FaturaOkuveBilgileriGuncelle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
        }


        [Serializable]
        public class FaturaKaydiIptalParam : AsyncBase, IWebMethodCallback
        {
            public FaturaKaydiIptalParam() { }

            public FaturaKaydiIptalParam(TTObjectClasses.FaturaKayitIslemleri.faturaIptalGirisDVO faturaIptalGirisDVO, PayerInvoiceDocument pid)
            {
                _pid = pid;
                _faturaIptalGirisDVO = faturaIptalGirisDVO;
            }

            public TTObjectClasses.FaturaKayitIslemleri.faturaIptalGirisDVO _faturaIptalGirisDVO;
            public PayerInvoiceDocument _pid;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    FaturaKayitIslemleri.faturaIptalCevapDVO result = (FaturaKayitIslemleri.faturaIptalCevapDVO)returnValue;
                    FaturaKaydiIptalCompletedInternal(result);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;

            }


            public void FaturaKaydiIptalCompletedInternal(FaturaKayitIslemleri.faturaIptalCevapDVO result)
            {
                if (result.sonucKodu == "0000")
                {
                    DateTime nw = DateTime.Now;
                    if (_faturaIptalGirisDVO.faturaTeslimNo.Length > 0 && _pid.DocumentNo == _faturaIptalGirisDVO.faturaTeslimNo[0])
                    {
                        _pid.CurrentStateDefID = PayerInvoiceDocument.States.Cancelled;
                        _pid.CancelDate = DateTime.Now;
                        //_pid.CancelDescription = string.Empty; // Fatura iptal a��klamas� istenirse yaz�lacak. Ayr�ca PAYINVCANCELREASONDEF objesinde iptal nedeni tan�mlar� da var.
                        var ICDs = _pid.InvoiceCollectionDetails.ToList();
                        foreach (var icd in ICDs)
                        {
                            icd.CurrentStateDefID = InvoiceCollectionDetail.States.Cancelled;
                            icd.PayerInvoiceDocument = null;
                            var SEPs = icd.SubEpisodeProtocols.ToList();
                            foreach (var sep in SEPs)
                            {
                                sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryCompleted;
                                sep.CurrentStateDefID = SubEpisodeProtocol.States.Open;
                                sep.MedulaFaturaTutari = null;
                                //TODO: AAE Fatura A��klamas� koyulacak (�ptal A��klamas� Olabilir.)
                                //sep.InvoiceDescription = null;
                                sep.InvoiceCollectionDetail = null;
                                InvoiceLog.AddInfo("Meduladan fatura iptal edildi. Fatura teslim no:" + _faturaIptalGirisDVO.faturaTeslimNo[0], sep.ObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                if (sep.InvoiceCancelCount == null)
                                    sep.InvoiceCancelCount = 0;

                                sep.InvoiceCancelCount++;

                                CancelledInvoice ci = new CancelledInvoice(_pid.ObjectContext);
                                ci.SEP = sep;
                                ci.ICD = icd;
                                ci.PID = _pid;
                                ci.Date = nw;
                                ci.Type = CancelledInvoiceTypeEnum.Cancelled;
                                ci.User = Common.CurrentResource;
                            }
                        }
                    }
                }
                else
                {
                    if (result.hataliKayitlar != null)
                    {
                        for (int i = 0; i < result.hataliKayitlar.Length; i++)
                        {
                            if (_pid.DocumentNo == result.hataliKayitlar[i].faturaTeslimNo)
                            {
                                foreach (var icd in _pid.InvoiceCollectionDetails)
                                {
                                    foreach (var sep in icd.SubEpisodeProtocols)
                                    {
                                        InvoiceLog.AddErr("Fatura iptal edilirken hata olu�tu", sep.ObjectID, InvoiceOperationTypeEnum.FaturaSil, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                        sep.MedulaSonucKodu = result.hataliKayitlar[i].hataKodu;
                                        sep.MedulaSonucMesaji = result.hataliKayitlar[i].hataMesaji;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        [Serializable]
        public class FaturaOkuParam : AsyncBase, IWebMethodCallback
        {
            public FaturaOkuParam() { }

            public FaturaOkuParam(TTObjectClasses.FaturaKayitIslemleri.faturaOkuGirisDVO faturaOkuGirisDVO, PayerInvoiceDocument pid)
            {
                _pid = pid;
                _faturaOkuGirisDVO = faturaOkuGirisDVO;
            }

            public TTObjectClasses.FaturaKayitIslemleri.faturaOkuGirisDVO _faturaOkuGirisDVO;
            public PayerInvoiceDocument _pid;

            public TTObjectContext ObjectContext
            {
                get
                {
                    if (objectcontext == null)
                        objectcontext = new TTObjectContext(false);
                    return objectcontext;
                }
            }

            #region IWebMethodCallback Members

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {
                if (returnValue != null)
                {
                    FaturaKayitIslemleri.faturaOkuCevapDVO result = (FaturaKayitIslemleri.faturaOkuCevapDVO)returnValue;
                    FaturaOkuCompletedInternal(result);
                    MedulaHelper.SaveAndDisposeContext(ObjectContext);
                }
                return true;

            }


            public void FaturaOkuCompletedInternal(FaturaKayitIslemleri.faturaOkuCevapDVO result)
            {
                if (result.sonucKodu == "0000" && result.faturaDetaylari != null && result.faturaDetaylari.Length > 0)
                {
                    _pid.DocumentDate = Convert.ToDateTime(result.faturaTarihi);
                    _pid.DocumentNo = result.faturaTeslimNo;
                    _pid.DocumentID = Convert.ToInt64(result.faturaRefNo);
                    _pid.TotalPrice = result.faturaTutari;

                    foreach (var fd in result.faturaDetaylari)
                    {
                        if (fd != null)
                        {
                            SubEpisodeProtocol sep = _pid.SEPs.Where(s => s.MedulaTakipNo.Equals(fd.takipNo)).FirstOrDefault();

                            if (sep != null)
                            {
                                InvoiceLog.AddInfo("Meduladan fatura ba�ar�l� bir �ekilde okundu. Takip no:" + fd.takipNo, sep.ObjectID, InvoiceOperationTypeEnum.FaturaOkuveBilgileriGuncelle, InvoiceLogObjectTypeEnum.SubEpisodeProtocol);
                                sep.MedulaSonucKodu = result.sonucKodu;
                                sep.MedulaSonucMesaji = result.sonucMesaji;

                                double? total = sep.AccountTransactions.Select(" CURRENTSTATEDEFID = '" + AccountTransaction.States.MedulaEntrySuccessful + "' AND INVOICEINCLUSION = 1 ").Sum(x => x.UnitPrice * x.Amount);
                                if (total.HasValue && Math.Round(total.Value, 2) != fd.takipToplamTutar)
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.InvoiceInconsistent;
                                else
                                    sep.InvoiceStatus = MedulaSubEpisodeStatusEnum.Invoiced;

                                sep.MedulaFaturaTutari = fd.takipToplamTutar;
                                if (fd.islemDetaylari != null)
                                {
                                    foreach (var islem in fd.islemDetaylari)
                                    {
                                        AccountTransaction acctx = sep.AccountTransactions.Select("").Where(x => x.MedulaProcessNo == islem.islemSiraNo).FirstOrDefault();

                                        //TODO: Buradaki kapal� kod ilerleyen zamanlarda ihtiya� duyuldu�unda a��lacak ve �al���r duruma getirilecek. 
                                        //if (acctx.CurrentStateDefID != AccountTransaction.States.MedulaEntrySuccessful)
                                        //{
                                        //    acctx.CurrentStateDefID = AccountTransaction.States.MedulaEntrySuccessful;
                                        //    _pid.ObjectContext.Save();
                                        //}
                                        if (acctx != null)
                                        {
                                            if (acctx.CurrentStateDefID != AccountTransaction.States.Cancelled)
                                                acctx.MedulaPrice = islem.islemTutari;
                                            else
                                                throw new TTException("�ptal durumunda olup medula i�lem numaras� olan kay�t bulundu. ID: " + acctx.Id);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        public HastaKabulIslemleri.takipSilCevapDVO fazlaTakipSil(string takipNo)
        {
            SubEpisodeProtocol sep = SubEpisodeProtocol.GetSEPByProvisionNo(takipNo);
            if (sep == null || (sep != null && !string.IsNullOrEmpty(sep.MedulaTakipNo) && sep.CurrentStateDefID == SubEpisodeProtocol.States.Cancelled))
            {
                HastaKabulIslemleri.takipSilGirisDVO takipSilGirisDVO = new HastaKabulIslemleri.takipSilGirisDVO();
                takipSilGirisDVO.takipNo = takipNo;
                takipSilGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                takipSilGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();

                HastaKabulIslemleri.takipSilCevapDVO takipSilCevapDVO = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(TTObjectClasses.Sites.SiteLocalHost, takipSilGirisDVO);

                if (takipSilCevapDVO != null && takipSilCevapDVO.sonucKodu.Equals("0000") && sep != null && !string.IsNullOrEmpty(sep.MedulaTakipNo))
                {
                    sep.MedulaTakipNo = "";
                    sep.MedulaBasvuruNo = "";
                    sep.ObjectContext.Save();
                }

                return takipSilCevapDVO;
            }
            else
                throw new TTException("HBYS ye kay�tl� takipler fatura kart� �zerinden takip sil methoduna tabi silinmelidir.");
        }

        #region DoktorAra
        public class DoktorAraGirisDVO
        {
            public string drAdi;
            public string drSoyadi;
            public string drBransKodu;
            public string drDiplomaNo;
            public string drTescilNo;
        }
        public MedulaYardimciIslemler.doktorAraCevapDVO DoktorAra(DoktorAraGirisDVO doktorAraGiris)
        {
            MedulaYardimciIslemler.doktorAraGirisDVO doktorAraGirisDVO = new MedulaYardimciIslemler.doktorAraGirisDVO();
            doktorAraGirisDVO.drAdi = doktorAraGiris.drAdi;
            doktorAraGirisDVO.drSoyadi = doktorAraGiris.drSoyadi;
            doktorAraGirisDVO.drBransKodu = doktorAraGiris.drBransKodu;
            doktorAraGirisDVO.drDiplomaNo = doktorAraGiris.drDiplomaNo;
            doktorAraGirisDVO.drTescilNo = doktorAraGiris.drTescilNo;
            doktorAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            MedulaYardimciIslemler.doktorAraCevapDVO doktorAraCevapDVO = MedulaYardimciIslemler.WebMethods.doktorAraSync(TTObjectClasses.Sites.SiteLocalHost, doktorAraGirisDVO);

            return doktorAraCevapDVO;
        }
        #endregion DoktorAra

        #region �la�Ara
        public class IlacAraGirisDVO
        {
            //�lac�n barkod numaras�
            public string barkod;
            public string ilacAdi;
        }
        public MedulaYardimciIslemler.ilacAraCevapDVO IlacAra(IlacAraGirisDVO ilacAraGiris)
        {
            MedulaYardimciIslemler.ilacAraGirisDVO ilacAraGirisDVO = new MedulaYardimciIslemler.ilacAraGirisDVO();
            ilacAraGirisDVO.barkod = ilacAraGiris.barkod;
            ilacAraGirisDVO.ilacAdi = ilacAraGiris.ilacAdi;
            ilacAraGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            MedulaYardimciIslemler.ilacAraCevapDVO ilacAraCevapDVO = MedulaYardimciIslemler.WebMethods.ilacAraSync(TTObjectClasses.Sites.SiteLocalHost, ilacAraGirisDVO);
            //ilacAraCevapDVO.ilaclar = new MedulaYardimciIslemler.ilacListDVO[1];
            //ilacAraCevapDVO.ilaclar[0] = new MedulaYardimciIslemler.ilacListDVO() { ayaktanOdenme = "1", barkod = "B1", eczAktifPasif = "A", hasAktifPasif = "P", ilacAdi = "�la� Ad�", kullanimBirimi = 1, yatanOdenme = "Yatan �deme" };
            //ilacAraCevapDVO.ilaclar[0].ilacFiyatlari = new MedulaYardimciIslemler.fiyatListDVO[1];
            //ilacAraCevapDVO.ilaclar[0].ilacFiyatlari[0] = new MedulaYardimciIslemler.fiyatListDVO() { fiyat = 10, gecerlilikTarihi = DateTime.Now.ToString() };
            //ilacAraCevapDVO.ilaclar[0].ilacIndirimleri = new MedulaYardimciIslemler.ilacIndirimDVO[1];
            //ilacAraCevapDVO.ilaclar[0].ilacIndirimleri[0] = new MedulaYardimciIslemler.ilacIndirimDVO() { gecerlilikTarihi = "11.11.2011", ilac_id = 1, indirimOrani1 = 1, indirimOrani2 = 2, indirimOrani3 = 3, indirimOrani4 = 4, kamuIndOranAlt = 5, kamuIndOranUst = 6 };
            return ilacAraCevapDVO;
        }
        #endregion �la�Ara

        #region �la�Ara
        public class TesisYatakSorguGirisDVO
        {
            //�lac�n barkod numaras�
            public string tarih;
        }
        public MedulaYardimciIslemler.tesisYatakSorguCevapDVO TesisYatakSorgu(TesisYatakSorguGirisDVO tesisYatakSorguGiris)
        {
            MedulaYardimciIslemler.tesisYatakSorguGirisDVO tesisYatakSorguGirisDVO = new MedulaYardimciIslemler.tesisYatakSorguGirisDVO();
            tesisYatakSorguGirisDVO.tarih = tesisYatakSorguGiris.tarih;
            tesisYatakSorguGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            MedulaYardimciIslemler.tesisYatakSorguCevapDVO tesisYatakSorguCevapDVO = MedulaYardimciIslemler.WebMethods.tesisYatakSorguSync(TTObjectClasses.Sites.SiteLocalHost, tesisYatakSorguGirisDVO);

            return tesisYatakSorguCevapDVO;
        }
        #endregion �la�Ara

        //public class MedulaResult
        //{
        //    public string MedulaResultCode { get; set; }
        //    public string MedulaMessage { get; set; }
        //}

        #endregion Methods

    }
}