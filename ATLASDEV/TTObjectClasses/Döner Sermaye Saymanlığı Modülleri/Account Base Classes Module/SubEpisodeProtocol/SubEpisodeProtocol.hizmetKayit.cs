
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


using System.Threading;

namespace TTObjectClasses
{
    /// <summary>
    /// Bu class hizmet kayıt methodlarını barındırır.
    /// </summary>
    public partial class SubEpisodeProtocol : TTObject
    {
        public TTObjectClasses.SubEpisodeProtocol.MedulaResult HizmetKayitSync(bool unsuccessfulProceduresIncluded, List<Guid> accountTransactionObjectIDList = null)
        {
            if (!IsSGK)
                throw new TTException(TTUtils.CultureService.GetText("M26870", "SGK olmayan kurumlar için hizmet kayıt işlemi yapılamaz."));

            if (string.IsNullOrEmpty(MedulaTakipNo))
                throw new TTException(TTUtils.CultureService.GetText("M27013", "Takip numarası olmayan hastalar için hizmet kayıt işlemi yapılamaz."));

            if (IsInvoiced || InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
                throw new TTException("Hizmet kayıt yapılmaya çalışılan protokolün durumu hizmet kayıt yapmaya uygun değildir. Lütfen kontrol ediniz.");

            string subEpisodeProtocolObjectID = "";
            subEpisodeProtocolObjectID = ObjectID.ToString();

            //TTObjectContext objectcontext = this.ObjectContext;
            HizmetKayitIslemleri.hizmetKayitCevapDVO hataliResult = null;
            int transactionsCount = 0;
            int diagnosisCount = 0;
            int maxHizmetSayisi = 0;
            int maxTryCount = 0;
            int tryCount = 0;

            //SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(new Guid(subEpisodeProtocolObjectID), typeof(SubEpisodeProtocol));

            // Hatalılar Dahil ise önce, hatalı hizmet ve tanılar Yeni durumuna alınır
            if (unsuccessfulProceduresIncluded)
            {
                SetStateToNewForUnsuccessfulAccTrx(accountTransactionObjectIDList);
                if (accountTransactionObjectIDList == null)
                    SetMedulaStatusToNewForUnsuccessfulDiagnosis();
            }

            if (accountTransactionObjectIDList == null)
            {
                // Gerekli durumlarda tanı oluşturulur (Kapatıldı, TFS No: 56694. Mustafa)
                //CreateDiagnosis();

                // Mükerer tanıları Medulaya Gönderilmeyecek durumuna alır
                ControlRepeatedDiagnosis();

                // Gündüz yatak hizmetini kontrol eder ve yoksa oluşturur
                ArrangeDailyBedProcedure();
            }

            int controlParam = 0;
            List<Guid> tempAcctrxList = new List<Guid>();
            tempAcctrxList.Add(Guid.Empty);
            bool tryAllTransSend = Convert.ToString(SystemParameter.GetParameterValue("MEDULATEKRARHIZMETKAYIT", "H")).Equals("E");
            if (tryAllTransSend)
            {
                if (accountTransactionObjectIDList != null && accountTransactionObjectIDList.Count > 0)
                {
                    controlParam = 1;
                    tempAcctrxList = accountTransactionObjectIDList;
                }

                IList<AccountTransaction> actxList = AccountTransaction.GetTrxForProcedureEntry(ObjectContext, ObjectID, tempAcctrxList, controlParam);

                transactionsCount = actxList.Count;
                if (accountTransactionObjectIDList == null)
                    diagnosisCount = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.New).Count();
                maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                maxTryCount = ((((transactionsCount + diagnosisCount) / maxHizmetSayisi) * 2) == 0 ? 1 : (((transactionsCount + diagnosisCount) / maxHizmetSayisi) * 2)) + 1;
            }

            DateTime? sendingTime = null;
            do
            {
                SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new SubEpisodeProtocol.HizmetKayitGirisDVOWithList();
                if (!tryAllTransSend || (tryAllTransSend && diagnosisCount > 0) && accountTransactionObjectIDList == null)
                    GetHizmetKayitGirisDVODiagnosisGridList(hizmetKayitGirisDVOWithList, false);
                var hizmetGirisList = GetHizmetKayitGirisDVOAccountTransactionList(hizmetKayitGirisDVOWithList, false, accountTransactionObjectIDList);

                foreach (var oneHizmetKayitGirisDVO in hizmetGirisList)
                {
                    tryCount++;
                    TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam(oneHizmetKayitGirisDVO.HizmetKayitGirisDVO, subEpisodeProtocolObjectID);

                    DateTime sendingAgain = DateTime.Now;

                    if (sendingTime.HasValue && sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.Value.TimeOfDay.TotalMilliseconds < 2000)
                        Thread.Sleep(2000 - Convert.ToInt32((sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.Value.TimeOfDay.TotalMilliseconds)));

                    HizmetKayitIslemleri.hizmetKayitCevapDVO hizmetKayitCevapDVO = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, null, oneHizmetKayitGirisDVO.HizmetKayitGirisDVO);
                    sendingTime = DateTime.Now;

                    if (hizmetKayitCevapDVO.sonucKodu != "0000")
                        hataliResult = hizmetKayitCevapDVO;

                    inputParam.HizmetKayitCompletedInternal(hizmetKayitCevapDVO, oneHizmetKayitGirisDVO.HizmetKayitGirisDVO, this.ObjectContext, false);
                }

                ObjectContext.Save();
                //TTObjectClasses.MedulaHelper.SetMedulaProvisionStatusAfterProcedureEntryByObjectID(subEpisodeProtocolObjectID, objectcontext);
                if (tryAllTransSend)
                {
                    if (accountTransactionObjectIDList != null && accountTransactionObjectIDList.Count > 0)
                    {
                        controlParam = 1;
                        tempAcctrxList = accountTransactionObjectIDList;
                    }

                    IList<AccountTransaction> actxList = AccountTransaction.GetTrxForProcedureEntry(ObjectContext, ObjectID, tempAcctrxList, controlParam);

                    transactionsCount = actxList.Count;


                    if (accountTransactionObjectIDList == null)
                        diagnosisCount = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.New).Count();
                }
            } while ((transactionsCount + diagnosisCount) > 0 && tryAllTransSend && tryCount < maxTryCount);

            if (hataliResult == null)
            {
                hataliResult = new HizmetKayitIslemleri.hizmetKayitCevapDVO();
                hataliResult.sonucKodu = "0000";
                hataliResult.sonucMesaji = TTUtils.CultureService.GetText("M26172", "İşlem Başarılı");
            }
            this.SetInvoiceStatusAfterProcedureEntry();
            this.ObjectContext.Save();
            MedulaResult result = GetMedulaResult(hataliResult);
            result.ProtocolNo = this.SubEpisode?.ProtocolNo;
            return result;
        }

        public SubEpisodeProtocol.MedulaResult TaniHizmetKayitSync(List<Guid> diagnosisGridIDs)
        {
            // GetDVO Deneme
            if (diagnosisGridIDs.Count > 0)
            {
                TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = GetTaniHizmetKayitGirisDVO(diagnosisGridIDs);
                TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam(hizmetKayitGirisDVO, diagnosisGridIDs);
                HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, null, hizmetKayitGirisDVO);
                inputParam.HizmetKayitCompletedInternal(result, hizmetKayitGirisDVO, ObjectContext, true);
                ObjectContext.Save();
                return GetMedulaResult(result);
            }
            return null;
        }

        public TTObjectClasses.SubEpisodeProtocol.MedulaResult HizmetKayitIptalSync(List<string> islemSiraNoList, List<Guid> accountTransactionIDs, bool isAccountTransactionList)
        {
            if (!IsSGK)
                throw new TTException(TTUtils.CultureService.GetText("M26869", "SGK olmayan kurumlar için hizmet kayıt iptal işlemi yapılamaz."));

            if (string.IsNullOrEmpty(MedulaTakipNo))
                throw new TTException(TTUtils.CultureService.GetText("M27012", "Takip numarası olmayan hastalar için hizmet kayıt iptal işlemi yapılamaz."));

            if (IsInvoiced || InvoiceStatus == MedulaSubEpisodeStatusEnum.ProvisionNoNotExists)
                throw new TTException("Hizmet kayıt iptali yapılmaya çalışılan protokolün durumu hizmet kayıt iptal yapmaya uygun değildir. Lütfen kontrol ediniz.");

            // UTS Kullanım Kesinleştirme İptal edilir
            //if (isAccountTransactionList)
            //    DoUTSUsageCommitmentCancel(accountTransactionIDs);

            TTObjectClasses.HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO = GetHizmetIptalGirisDVO(islemSiraNoList, MedulaTakipNo);
            TTObjectClasses.XXXXXXMedulaServices.HizmetIptalParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetIptalParam(hizmetIptalGirisDVO, accountTransactionIDs, ObjectID.ToString(), isAccountTransactionList);
            HizmetKayitIslemleri.hizmetIptalCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptalGirisDVO);

            inputParam.HizmetIptalCompletedInternal(result, hizmetIptalGirisDVO, accountTransactionIDs, this.ObjectContext);
            this.ObjectContext.Save();
            MedulaResult medulaResult = GetMedulaResult(result);
            medulaResult.ProtocolNo = this.SubEpisode?.ProtocolNo;
            return medulaResult;
        }

        private HizmetKayitIslemleri.hizmetIptalGirisDVO GetHizmetIptalGirisDVO(List<string> islemSiraNoList, string takipNo)
        {
            HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO = new HizmetKayitIslemleri.hizmetIptalGirisDVO();
            hizmetIptalGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetIptalGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetIptalGirisDVO.takipNo = takipNo;

            if (islemSiraNoList != null)
                hizmetIptalGirisDVO.islemSiraNumaralari = islemSiraNoList.ToArray();

            return hizmetIptalGirisDVO;
        }

        public TTObjectClasses.HizmetKayitIslemleri.hizmetOkuCevapDVO HizmetKayitOkuSync(List<string> hizmetSunucuReferansNoList, List<string> islemSiraNoList)
        {
            TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO = GetHizmetOkuGirisDVO(hizmetSunucuReferansNoList, islemSiraNoList, MedulaTakipNo);
            TTObjectClasses.XXXXXXMedulaServices.HizmetKayitOkuParam inputParam = new XXXXXXMedulaServices.HizmetKayitOkuParam(hizmetOkuGirisDVO, ObjectID.ToString());
            HizmetKayitIslemleri.hizmetOkuCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetOkuSync(TTObjectClasses.Sites.SiteLocalHost, hizmetOkuGirisDVO);
            TTObjectContext objectcontext = new TTObjectContext(false);
            inputParam.HizmetOkuCompletedInternal(result, objectcontext);

            return result;
        }
        private TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO GetHizmetOkuGirisDVO(List<string> hizmetSunucuReferansNoList, List<string> islemSiraNoList, string takipNo)
        {
            HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO = new HizmetKayitIslemleri.hizmetOkuGirisDVO();
            hizmetOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetOkuGirisDVO.takipNo = takipNo;

            if (hizmetSunucuReferansNoList != null && hizmetSunucuReferansNoList.Count > 0 && islemSiraNoList != null && hizmetSunucuReferansNoList.Count > islemSiraNoList.Count)
                hizmetOkuGirisDVO.hizmetSunucuRefNolari = hizmetSunucuReferansNoList.ToArray();
            else if (islemSiraNoList != null && islemSiraNoList.Count > 0)
                hizmetOkuGirisDVO.islemSiraNumaralari = islemSiraNoList.ToArray();

            return hizmetOkuGirisDVO;
        }

        public void SetStateToNewForUnsuccessfulAccTrx(List<Guid> accountTransactionObjectIDList)
        {
            IList<AccountTransaction> acctrxList = AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntryUnsuccessful && ((accountTransactionObjectIDList != null && accountTransactionObjectIDList.Contains(x.ObjectID)) || accountTransactionObjectIDList == null)).ToList();

            foreach (AccountTransaction acctrx in acctrxList)
                acctrx.CurrentStateDefID = AccountTransaction.States.New;

            ObjectContext.Save();
        }

        public void SetMedulaStatusToNewForUnsuccessfulDiagnosis()
        {
            IList<SEPDiagnosis> sdList = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.MedulaEntryUnsuccessful).ToList();

            foreach (SEPDiagnosis sd in sdList)
                sd.CurrentStateDefID = SEPDiagnosis.States.New;

            ObjectContext.Save();
        }

        public void ControlRepeatedDiagnosis()
        {
            IList<SEPDiagnosis> sdList = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.New).ToList();

            if (sdList.Count > 0)
            {

                IList<SEPDiagnosis> exsdList = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.MedulaEntryUnsuccessful || x.CurrentStateDefID == SEPDiagnosis.States.MedulaEntryUnsuccessful).ToList();
                for (int i = 0; i < sdList.Count && exsdList.Count > 0; i++)
                {
                    for (int k = 0; k < exsdList.Count; k++)
                    {
                        if (sdList[i].DiagnoseCode == exsdList[k].DiagnoseCode)
                            sdList[i].CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                    }
                }

                for (int i = 0; i < sdList.Count; i++)
                {
                    for (int k = 0; k < sdList.Count; k++)
                    {
                        if (k > i && sdList[i].DiagnoseCode == sdList[k].DiagnoseCode && sdList[k].CurrentStateDefID != SEPDiagnosis.States.MedulaDontSend)
                            sdList[k].CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                    }
                }
            }

            ObjectContext.Save();
        }

        public void CreateDiagnosis()
        {
            if (SEPDiagnoses.Count == 0)
            {
                // Kontrol Muayenesi kabullerinde oluşturulan ayaktan SEP ler için episode daki ayaktan takiplerdeki tanılardan SEPDiagnosis kopyalanır.
                // Kontrol muayenesinde tanı girilmesi zorunlu olmadığı için.
                if (MedulaTedaviTuru.tedaviTuruKodu.Equals("A") && SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                {
                    List<SubEpisodeProtocol> sepList = Episode.AllSGKSubEpisodeProtocols().Where(x => x.SEPDiagnoses.Count > 0 && x.MedulaTedaviTuru.tedaviTuruKodu.Equals("A")).ToList();
                    foreach (SubEpisodeProtocol sep in sepList)
                    {
                        foreach (SEPDiagnosis sd in sep.SEPDiagnoses)
                        {
                            if (SEPDiagnoses.Any(x => x.DiagnoseCode.Equals(sd.DiagnoseCode)) == false)
                                sd.CopySEPDiagnosis(this, true);
                        }
                    }

                    ObjectContext.Save();
                }
            }
        }

        public void GetHizmetKayitGirisDVODiagnosisGridList(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, bool ASync)
        {
            // Tanılarıın hızmet kaydını yapmak ıcın gerekli kod parçası
            IList<SEPDiagnosis> sdList = SEPDiagnoses.Where(x => x.CurrentStateDefID == SEPDiagnosis.States.New).ToList();
            if (sdList.Count > 0)
            {
                LoadHizmetTakipBilgileriFromDiagnosis(hizmetKayitGirisDVOWithList, sdList[0]);
                // Maximumda 19 tane tanı ilk seferde hizmet kaydına gönderilebilir
                int maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                for (int i = 0; i < sdList.Count && i < (maxHizmetSayisi - 1); i++)
                {
                    LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, sdList[i]);
                    if (ASync)
                        sdList[i].CurrentStateDefID = SEPDiagnosis.States.MedulaSentServer;
                }
            }
        }

        public void LoadHizmetTakipBilgileriFromDiagnosis(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, SEPDiagnosis sepDiagnosis)
        {
            hizmetKayitGirisDVOWithList.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetKayitGirisDVOWithList.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetKayitGirisDVOWithList.hastaBasvuruNo = sepDiagnosis.SubEpisodeProtocol.MedulaBasvuruNo;
            hizmetKayitGirisDVOWithList.takipNo = sepDiagnosis.SubEpisodeProtocol.MedulaTakipNo;
            hizmetKayitGirisDVOWithList.triajBeyani = sepDiagnosis.SubEpisodeProtocol.Triaj;
        }
        public void loadHizmetTakipBilgileriFromAcctrx(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, AccountTransaction acctrx)
        {
            hizmetKayitGirisDVOWithList.hastaBasvuruNo = acctrx.SubEpisodeProtocol.MedulaBasvuruNo;
            hizmetKayitGirisDVOWithList.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetKayitGirisDVOWithList.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetKayitGirisDVOWithList.takipNo = acctrx.SubEpisodeProtocol.MedulaTakipNo;
            hizmetKayitGirisDVOWithList.TedaviTuru = acctrx.SubEpisodeProtocol.MedulaTedaviTuru;
            hizmetKayitGirisDVOWithList.triajBeyani = acctrx.SubEpisodeProtocol.Triaj;
        }

        public void LoadHizmetBilgileri(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, SEPDiagnosis sepDiagnosis)
        {
            object obj = getDVO(sepDiagnosis);
            if (obj is TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO)
                hizmetKayitGirisDVOWithList.tanilar.Add((TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO)obj);
        }

        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult LoadHizmetBilgileri(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVO, AccountTransaction actx)
        {
            return LoadHizmetBilgileri(hizmetKayitGirisDVO, actx, false);
        }

        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult LoadHizmetBilgileri(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVO, AccountTransaction actx, bool isReadDVOXML)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            try
            {
                object obj = null;
                if (actx.SubActionProcedure != null)
                    obj = actx.SubActionProcedure.GetDVO(actx);
                else if (actx.SubActionMaterial != null)
                    obj = actx.SubActionMaterial.GetDVO(actx);

                if (obj == null)
                {
                    if (actx.SubActionProcedure != null)
                    {
                        // MedulaLog.AddErr(string.Format("GetDVO Boş Geliyor. Kodu : {0} , Adı : {1} , SubActionProcedure : {2} ", actx.ExternalCode, actx.Description, actx.SubActionProcedure.GetType().Name), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                        result.SonucMesaji = string.Format("GetDVO Boş Geliyor. Kodu : {0} , Adı : {1}  SubActionProcedure : {2}", actx.ExternalCode, actx.Description, actx.SubActionProcedure.GetType().Name);
                        result.SonucKodu = "A0001";
                        return result;
                    }
                    else if (actx.SubActionMaterial != null)
                    {
                        // MedulaLog.AddErr(string.Format("GetDVO Boş Geliyor. Kodu : {0} , Adı : {1} , SubActionMaterial : {2} ", actx.ExternalCode, actx.Description, actx.SubActionMaterial.GetType().Name), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                        result.SonucMesaji = string.Format("GetDVO Boş Geliyor. Kodu : {0} , Adı : {1}  SubActionMaterial : ", actx.ExternalCode, actx.Description, actx.SubActionMaterial.GetType().Name);
                        result.SonucKodu = "A0001";
                        return result;
                    }
                    else
                    {
                        //MedulaLog.AddErr(string.Format("İlaç, Sarf veya Hizmet Degil. Kodu : {0} , Adı : {1}", actx.ExternalCode, actx.Description), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                        result.SonucMesaji = string.Format("İlaç, Sarf veya Hizmet Degil. Kodu : {0} , Adı : {1}", actx.ExternalCode, actx.Description);
                        result.SonucKodu = "A0001";
                        return result;
                    }

                }
                else
                {
                    if (IsMedulaProcedureTypeControlActive)
                    {
                        // DVO tipi ile medula işlem tipi kontrolu , sonra kaldırılacak
                        result = hizmetKayitGirisDVO.DVOMedulaProcedureTypeKontrol(obj, actx);
                        if (!result.SonucKodu.Equals("0000") && !isReadDVOXML)
                        {
                            //MedulaLog.AddErr(string.Format("DVOMedulaProcedureTypeKontrol Sonuc Kodu:{0}  Sonuc Mesajı: {1} ", result.SonucKodu, result.MedulaMessage), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                            return result;
                        }
                    }
                    ////Özel Durum Ezmesi // Doktor Ezmesi
                    DVODegerEzici(obj, actx);
                    // Zorunlu Alan Kontrolleri, sonra kaldırılacak 
                    result = hizmetKayitGirisDVO.ZorunluAlanKontrolu(obj);
                    if (!result.SonucKodu.Equals("0000") && !isReadDVOXML)
                    {
                        //MedulaLog.AddErr(string.Format("ZorunluAlanKontrolu Sonuc Kodu:{0}  Sonuc Mesajı: {1} ", result.SonucKodu, result.MedulaMessage), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                        return result;
                    }

                    if (obj is TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.muayeneBilgisi = (TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO)obj;
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.ameliyatveGirisimBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.digerIslemBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.disBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.hastaYatisBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.ilacBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.kanBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.konsultasyonBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.malzemeBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.tahlilBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO)obj);
                    }
                    else if (obj is TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)
                    {
                        hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri.Add((TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)obj);
                    }
                    else
                    {
                        result.SonucKodu = "A0002";
                        result.SonucMesaji = TTUtils.CultureService.GetText("M25688", "Geçerli bir medula nesnesi değil.");
                    }
                }
            }
            catch (Exception ex)
            {
                result.SonucKodu = "A9999";
                result.SonucMesaji = ex.Message;
                //if (actx.SubEpisodeProtocol != null)
                //    MedulaLog.AddException(string.Format("LoadHizmetBilgileri Exception :{0}  ", ex.Message), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                //else
                //    MedulaLog.AddException(string.Format("LoadHizmetBilgileri Exception :{0}  ", ex.Message), null, MedulaOperationTypeEnum.HizmetKayit);
            }
            return result;
        }

        private static object getDVO(SEPDiagnosis sepDiagnosis)
        {
            object obj = sepDiagnosis.GetDVO();
            if (obj is HizmetKayitIslemleri.taniBilgisiDVO)
            {
                HizmetKayitIslemleri.taniBilgisiDVO XXXXXXTani = (HizmetKayitIslemleri.taniBilgisiDVO)obj;
                TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO result = new TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO();
                SetMedulaObjectValues(result, XXXXXXTani);
                return result;
            }
            return null;
        }

        public static void DVODegerEzici(object objMedula, AccountTransaction AccTrx)
        {
            if (objMedula != null)
            {
                foreach (PropertyInfo item in objMedula.GetType().GetProperties())
                {
                    if (item.PropertyType.IsArray)
                    {
                        object[] array = (object[])item.GetValue(objMedula, null);
                        if (array != null)
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                DVODegerEzici(array[i], AccTrx);
                            }
                        }
                    }
                    else
                    {
                        // Saçmalık ama başka yapacak birşey bulamadım
                        if (item.PropertyType.Name.EndsWith("DVO"))
                        {
                            object itemValue = (object)item.GetValue(objMedula, null);
                            DVODegerEzici(itemValue, AccTrx);
                        }
                        else
                        {
                            if (item.Name == "ozelDurum")
                            {
                                if (AccTrx.OzelDurum != null && !string.IsNullOrEmpty(AccTrx.OzelDurum.ozelDurumKodu))
                                    item.SetValue(objMedula, AccTrx.OzelDurum.ozelDurumKodu, null);  // AccTrx in Özel Durum Kodu set ediliyor
                            }
                            else if (item.Name == "drTescilNo" || (item.Name == "istemYapanDrTescilNo" && item.GetValue(objMedula) == null))
                            {
                                if (!string.IsNullOrEmpty(AccTrx?.Doctor?.DiplomaRegisterNo))
                                    item.SetValue(objMedula, AccTrx.Doctor.DiplomaRegisterNo, null);  // AccTrx in doktor bilgisi set ediliyor
                                else if (item.GetValue(objMedula) == null && !string.IsNullOrEmpty(AccTrx?.SubActionProcedure?.ProcedureDoctor?.DiplomaRegisterNo)) // Burayı sadece tescil no boşsa yapsın
                                    item.SetValue(objMedula, AccTrx.SubActionProcedure.ProcedureDoctor.DiplomaRegisterNo, null);  // AccTrx in doktor bilgisi set ediliyor
                            }
                            else if (item.Name == "aciklama")
                            {
                                if (!string.IsNullOrEmpty(AccTrx.MedulaDescription))
                                    item.SetValue(objMedula, AccTrx.MedulaDescription, null);  // AccTrx medula açıklama bilgisi dolu ise o set ediliyor.
                            }
                            else if (item.Name == "yatakKodu")
                            {
                                if (!string.IsNullOrEmpty(AccTrx.MedulaBedNo))
                                    item.SetValue(objMedula, AccTrx.MedulaBedNo, null);  // AccTrx medula yatak kodu bilgisi dolu ise o set ediliyor.
                            }
                            else if (item.Name == "ayniFarkliKesi")
                            {
                                if (AccTrx.AyniFarkliKesi != null && !string.IsNullOrEmpty(AccTrx.AyniFarkliKesi.ayniFarkliKesiKodu))
                                    item.SetValue(objMedula, AccTrx.AyniFarkliKesi.ayniFarkliKesiKodu, null);  // AccTrx kesi bilgisi dolu ise o set ediliyor.
                            }
                            else if (item.Name == "raporTakipNo")
                            {
                                if (AccTrx.SubActionProcedure != null && !string.IsNullOrEmpty(AccTrx.SubActionProcedure.MedulaReportNo))
                                    item.SetValue(objMedula, AccTrx.SubActionProcedure.MedulaReportNo, null);  // SubactionProcedure ün rapor no bilgisi set ediliyor
                                else if (AccTrx.SubActionMaterial != null && !string.IsNullOrEmpty(AccTrx.SubActionMaterial.MedulaReportNo))
                                    item.SetValue(objMedula, AccTrx.SubActionMaterial.MedulaReportNo, null);  // SubactionMaterial ün rapor no bilgisi set ediliyor
                            }
                            else if (item.Name == "accession")
                            {
                                if (!string.IsNullOrEmpty(AccTrx.MedulaAccessionNo))
                                    item.SetValue(objMedula, AccTrx.MedulaAccessionNo, null);  // AccTrx medula accession no bilgisi dolu ise o set ediliyor.
                            }
                            else if (item.Name == "sagSol")
                            {
                                if (AccTrx.Position.HasValue) // AccTrx medula sağ sol bilgisi dolu ise o set ediliyor.
                                {
                                    string sagSol = string.Empty;
                                    if (objMedula is HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)   // ameliyatveGirisimBilgileri ise sagSol "1, 2 veya 3" set edilir
                                        sagSol = ((int)AccTrx.Position.Value).ToString();
                                    else                                                                 // Diğer tipler için "L veya R" set edilir
                                        sagSol = SubActionProcedure.MedulaSagSol_LR(AccTrx.Position);

                                    if (!string.IsNullOrWhiteSpace(sagSol))
                                        item.SetValue(objMedula, sagSol, null);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void SetMedulaObjectValues(object objMedula, object objXXXXXX)
        {
            foreach (PropertyInfo item in objMedula.GetType().GetProperties())
            {
                if (objXXXXXX.GetType().GetProperty(item.Name) != null)
                {
                    objMedula.GetType().GetProperty(item.Name).SetValue(objMedula, objXXXXXX.GetType().GetProperty(item.Name).GetValue(objXXXXXX, null), null);
                }
            }
        }

        private IEnumerable<SubEpisodeProtocol.HizmetKayitGirisDVOWithList> GetHizmetKayitGirisDVOAccountTransactionList(SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, bool ASync, List<Guid> accTrxList)
        {

            TTObjectClasses.SubEpisodeProtocol.MedulaResult getDvoResult = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            int controlParam = 0;
            List<Guid> tempAccTrxList = new List<Guid>();
            tempAccTrxList.Add(Guid.Empty);
            if (accTrxList != null && accTrxList.Count > 0)
            {
                controlParam = 1;
                tempAccTrxList = accTrxList;
            }

            IList<AccountTransaction> actxList = AccountTransaction.GetTrxForProcedureEntry(ObjectContext, ObjectID, tempAccTrxList, controlParam);
            //IList<AccountTransaction> actxList = this.AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.New && x.AccountPayableReceivable.Type == APRTypeEnum.PAYER && ((accTrxList != null && accTrxList.Contains(x.ObjectID)) || accTrxList == null)).ToList();
            if (actxList.Count > 0)
            {
                int maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));

                for (int i = 0; i < actxList.Count; i++)
                {
                    if (i == 0)
                        loadHizmetTakipBilgileriFromAcctrx(hizmetKayitGirisDVOWithList, actxList[i]);

                    AccountTransaction actx = actxList[i];
                    getDvoResult = LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, actx);
                    //InvoiceLog.AddInfo("Hizmet kayıt işlemine başlandı", actx.ObjectID, InvoiceOperationTypeEnum.HizmetKayit, InvoiceLogObjectTypeEnum.AccountTransaction);
                    if (!getDvoResult.SonucKodu.Equals("0000"))
                    {
                        actx.MedulaResultCode = getDvoResult.SonucKodu;
                        actx.MedulaResultMessage = getDvoResult.SonucMesaji;
                        // BaseTreatmentMaterial.GetDVO() da bazı eski malzemeler için accTrx MedulaDontSend durumuna alındığı için
                        // burada tekrar MedulaEntryUnsuccessful yapılmasın diye kontrol eklendi
                        if (actx.CurrentStateDefID != AccountTransaction.States.MedulaDontSend)
                        {
                            actx.CurrentStateDefID = AccountTransaction.States.MedulaEntryUnsuccessful;
                            if (actx.SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)
                                actx.SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                        }
                        continue;
                    }
                    // AccountTransaction state değerleri sunucuya gönderildiye çekiliyor.
                    if (ASync)
                        actx.CurrentStateDefID = AccountTransaction.States.MedulaSentServer;
                    // Şuan için statik 20 değerini koyduk bunu sistem parametresi haline getirmemiz daha uygun olur
                    //TODO(Şadi) Medula gönderilecek bir seferdeki en fazla hizmet sayısı
                    if (hizmetKayitGirisDVOWithList.HizmetSayisi == maxHizmetSayisi)
                    {
                        yield return hizmetKayitGirisDVOWithList;
                        if (i < actxList.Count - 1)
                        {
                            hizmetKayitGirisDVOWithList = new SubEpisodeProtocol.HizmetKayitGirisDVOWithList();
                            loadHizmetTakipBilgileriFromAcctrx(hizmetKayitGirisDVOWithList, actxList[i]);
                        }
                    }
                    else if (i == actxList.Count - 1)
                    {
                        yield return hizmetKayitGirisDVOWithList;
                    }
                }
            }
            //TODO: AAE Alttaki if bloğu kapatılmıştı . Sonsuz döngüye girdiği için tekrar açıldı. 
            //Kapatılma sebebini hatırlamıyorum ama açılma sebebi sonsuz döngü ve hizmet kayıt edilmiş takipte üst menüden hizmet kayıt dendiğinde
            //Hiç bir hizmet yok ise bile tanıları kayıt edebilsin.
            else if (hizmetKayitGirisDVOWithList.HizmetSayisi > 0)
            {
                yield return hizmetKayitGirisDVOWithList;
            }
            yield break;
        }
        public static bool IsMedulaProcedureTypeControlActive
        {
            get
            {
                return TTObjectClasses.SystemParameter.GetParameterValue("DVOMEDULAPROCEDURETYPECONTROLACTIVE", "FALSE").Equals("TRUE");
            }
        }

        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult GetMedulaResult(object objMedula)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            if (objMedula != null)
            {
                PropertyInfo item = objMedula.GetType().GetProperty("sonucKodu");
                object val = (object)item.GetValue(objMedula, null);
                if (val != null)
                    result.SonucKodu = val.ToString();

                item = objMedula.GetType().GetProperty("sonucMesaji");
                val = (object)item.GetValue(objMedula, null);
                if (val != null)
                    result.SonucMesaji = val.ToString();

                if (result.SonucKodu.Equals("0000"))
                    result.Succes = true;
                else
                    result.Succes = false;
            }
            return result;

        }
        private TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO GetTaniHizmetKayitGirisDVO(List<Guid> SEPDiagnosisIDs)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            SubEpisodeProtocol.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new SubEpisodeProtocol.HizmetKayitGirisDVOWithList();

            List<SEPDiagnosis> listSEPDia = SEPDiagnoses.Where(x => SEPDiagnosisIDs.Contains(x.ObjectID)).ToList();

            int i = 0;
            foreach (SEPDiagnosis SEPDia in listSEPDia)
            {
                if (i == 0)
                    LoadHizmetTakipBilgileriFromDiagnosis(hizmetKayitGirisDVOWithList, SEPDia);

                LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, SEPDia);
                i++;
            }
            return hizmetKayitGirisDVOWithList.HizmetKayitGirisDVO;
        }

        #region Classes

        public class HizmetKayitGirisDVOWithList
        {
            public HizmetKayitGirisDVOWithList()
            {
                ameliyatveGirisimBilgileri = new List<HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO>();
                digerIslemBilgileri = new List<HizmetKayitIslemleri.digerIslemBilgisiDVO>();
                disBilgileri = new List<HizmetKayitIslemleri.disBilgisiDVO>();
                ilacBilgileri = new List<HizmetKayitIslemleri.ilacBilgisiDVO>();
                kanBilgileri = new List<HizmetKayitIslemleri.kanBilgisiDVO>();
                konsultasyonBilgileri = new List<HizmetKayitIslemleri.konsultasyonBilgisiDVO>();
                malzemeBilgileri = new List<HizmetKayitIslemleri.malzemeBilgisiDVO>();
                tahlilBilgileri = new List<HizmetKayitIslemleri.tahlilBilgisiDVO>();
                tanilar = new List<HizmetKayitIslemleri.taniBilgisiDVO>();
                tetkikveRadyolojiBilgileri = new List<HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO>();
                hastaYatisBilgileri = new List<HizmetKayitIslemleri.hastaYatisBilgisiDVO>();
            }

            private TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = new HizmetKayitIslemleri.hizmetKayitGirisDVO();

            public TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO HizmetKayitGirisDVO
            {
                get
                {
                    return GetHizmetKayitGirisDVO();
                }
            }

            public List<HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO> ameliyatveGirisimBilgileri { get; set; }
            public string asaKodu { get; set; }
            public List<HizmetKayitIslemleri.digerIslemBilgisiDVO> digerIslemBilgileri { get; set; }
            public List<HizmetKayitIslemleri.disBilgisiDVO> disBilgileri { get; set; }
            public string hastaBasvuruNo { get; set; }
            public List<HizmetKayitIslemleri.hastaYatisBilgisiDVO> hastaYatisBilgileri { get; set; }
            public List<HizmetKayitIslemleri.ilacBilgisiDVO> ilacBilgileri { get; set; }
            public List<HizmetKayitIslemleri.kanBilgisiDVO> kanBilgileri { get; set; }
            public List<HizmetKayitIslemleri.konsultasyonBilgisiDVO> konsultasyonBilgileri { get; set; }
            public List<HizmetKayitIslemleri.malzemeBilgisiDVO> malzemeBilgileri { get; set; }
            public HizmetKayitIslemleri.muayeneBilgisiDVO muayeneBilgisi { get; set; }
            public int saglikTesisKodu { get; set; }
            public string ktsHbysKodu { get; set; }
            public List<HizmetKayitIslemleri.tahlilBilgisiDVO> tahlilBilgileri { get; set; }
            public string takipNo { get; set; }
            public List<HizmetKayitIslemleri.taniBilgisiDVO> tanilar { get; set; }
            public List<HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO> tetkikveRadyolojiBilgileri { get; set; }
            public string triajBeyani { get; set; }
            public TedaviTuru TedaviTuru { get; set; }


            private int HizmetSayisiBul()
            {
                int result = 0;

                if (muayeneBilgisi != null)
                    result = 1;
                if (ameliyatveGirisimBilgileri != null)
                    result = result + ameliyatveGirisimBilgileri.Count;
                if (digerIslemBilgileri != null)
                    result = result + digerIslemBilgileri.Count;
                if (disBilgileri != null)
                    result = result + disBilgileri.Count;
                if (hastaYatisBilgileri != null)
                    result = result + hastaYatisBilgileri.Count;
                if (ilacBilgileri != null)
                    result = result + ilacBilgileri.Count;
                if (kanBilgileri != null)
                    result = result + kanBilgileri.Count;
                if (konsultasyonBilgileri != null)
                    result = result + konsultasyonBilgileri.Count;
                if (malzemeBilgileri != null)
                    result = result + malzemeBilgileri.Count;
                if (tahlilBilgileri != null)
                    result = result + tahlilBilgileri.Count;
                if (tanilar != null)
                    result = result + tanilar.Count;
                if (tetkikveRadyolojiBilgileri != null)
                    result = result + tetkikveRadyolojiBilgileri.Count;

                return result;
            }
            /// <summary>
            /// Medulaya gönderilecek olan hizmet sayısını ifade etmektedir.
            /// </summary>
            public int HizmetSayisi
            {
                get { return HizmetSayisiBul(); }
            }
            /// <summary>
            /// XXXXXX'dan gelen DVO'nun tipi ile o işlemin tanımındaki Medula DVO tipinin karşılaştırılması yapılmakta.
            /// </summary>
            /// <param name="objMedula">XXXXXX DVO Nesnesi</param>
            /// <param name="actx">AccountTransaction Nesnesi</param>
            /// <returns>Kontrol sonucunun başarılı olup olmadığı</returns>
            public TTObjectClasses.SubEpisodeProtocol.MedulaResult DVOMedulaProcedureTypeKontrol(object objMedula, AccountTransaction actx)
            {
                TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
                if (actx.SubActionProcedure != null && actx.SubActionProcedure.ProcedureObject != null && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != null)
                {
                    if
                        ((objMedula is TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.muayeneBilgisi)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.digerIslemBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.disBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.hastaYatisBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.konsultasyonBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.tahlilBilgileri)
                        || (objMedula is TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO && actx.SubActionProcedure.ProcedureObject.MedulaProcedureType != MedulaSUTGroupEnum.kanBilgileri)
                        )
                    {
                        result.SonucKodu = "AXXX1";
                        result.SonucMesaji = string.Format(" SutKodu:{0}  Gelen Nesne:{1}  Olması Gereken {2}  ", actx.ExternalCode, objMedula.GetType().Name, actx.SubActionProcedure.ProcedureObject.MedulaProcedureType.ToString());
                    }
                }
                else if (actx.SubActionProcedure == null && actx.SubActionMaterial != null)
                {
                    if (GetAccountTransactionType(actx) != "İLAÇ" && objMedula is TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)
                    {
                        result.SonucKodu = "AXXX2";
                        result.SonucMesaji = string.Format(" Kodu {0},  Gelen Nesne {1}, Olması Gereken MALZEME {2} ", actx.ExternalCode, objMedula.GetType().Name);
                    }
                    else if (GetAccountTransactionType(actx) != "MALZEME" && objMedula is TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)
                    {
                        result.SonucKodu = "AXXX3";
                        result.SonucMesaji = string.Format(" Kodu {0},  Gelen Nesne {1}, Olması Gereken İLAÇ {2} ", actx.ExternalCode, objMedula.GetType().Name);
                    }
                }
                return result;
            }
            /// <summary>
            /// Zorunlu alanların belirtildiği tanım ekranındaki değerlere göre nesne üzerinde kontrol yapılmakta ayrıca "BransKodu,İslemTarihi,DrTescilNo" gibi değerlerin boş  olarak medulaya gönderilmemesi için kontrol yapılmakta.
            /// </summary>
            /// <param name="objMedula">Medulaya gönderilecek olan DVO nesnesi</param>
            /// <returns>Kontrol sonucunun başarılı olup olmadığı</returns>
            public TTObjectClasses.SubEpisodeProtocol.MedulaResult ZorunluAlanKontrolu(object objMedula)
            {
                TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
                result.SonucKodu = "0000";
                if (objMedula != null)
                {

                    TTInstanceManagement.TTObjectContext context = new TTInstanceManagement.TTObjectContext(true);
                    string dvoTypeName = objMedula.GetType().FullName;

                    BindingList<MedulaMustDVOPropertyDef> list = TTObjectClasses.MedulaMustDVOPropertyDef.GetMedulaMustDVOPropertiesByDVOName(context, dvoTypeName);
                    foreach (MedulaMustDVOPropertyDef defItem in list)
                    {

                        PropertyInfo propitem = objMedula.GetType().GetProperty(defItem.PropertyName);
                        object val = propitem.GetValue(objMedula, null);
                        if ((val == null ||
                            (propitem.GetType().FullName.IndexOf("String") > -1 && val.ToString().Equals("")))
                            && (defItem.TedaviTuru == null || defItem.TedaviTuru == TedaviTuru))
                        {
                            result.SonucKodu = "AXXXX";
                            result.SonucMesaji = dvoTypeName + "  " + defItem.PropertyName + " değeri boş olamaz!";
                        }
                    }

                    if (result.SonucKodu == "0000")
                    {
                        foreach (PropertyInfo item in objMedula.GetType().GetProperties())
                        {
                            if (item.Name == "bransKodu")
                            {
                                string val = (string)item.GetValue(objMedula, null);
                                if (string.IsNullOrEmpty(val))
                                {
                                    result.SonucKodu = "A0515";
                                    result.SonucMesaji = TTUtils.CultureService.GetText("M25295", "Branş Kodu bilgisi boş olamaz!");
                                }
                            }
                            else if (item.Name == "islemTarihi")
                            {
                                string val = (string)item.GetValue(objMedula, null);
                                if (string.IsNullOrEmpty(val))
                                {
                                    result.SonucKodu = "A0720";
                                    result.SonucMesaji = TTUtils.CultureService.GetText("M26214", "İşlem Tarihi bugünün tarihinden ileri bir tarih olamaz!");
                                }
                            }
                            // 01.04.2019 tarihli Medula kullanım kılavuzu değişikliğinden; "Hizmet alımı yapılan Tahlil veya Tektik ve radyoloji işlemlerinde
                            // drTescilNo alanı boş gönderilecektir" dolayı aşağıdaki kontrol kapatıldı ) 
                            //else if (item.Name == "drTescilNo")
                            //{
                            //    string val = (string)item.GetValue(objMedula, null);
                            //    if (string.IsNullOrEmpty(val))
                            //    {
                            //        result.SonucKodu = "A1176";
                            //        result.SonucMesaji = TTUtils.CultureService.GetText("M25527", "Doktor Tescil Numarası boş olamaz!");
                            //    }
                            //}
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// Medulaya gönderilecek olan HizmetKayitGirisDVO nesnesini oluşturan metot
            /// </summary>
            /// <returns>Medula Hizmet Kayıt Nesnesi</returns>
            private TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO GetHizmetKayitGirisDVO()
            {
                //hizmetKayitGirisDVO.asaKodu = this.asaKodu;
                hizmetKayitGirisDVO.hastaBasvuruNo = hastaBasvuruNo;
                hizmetKayitGirisDVO.muayeneBilgisi = muayeneBilgisi;
                hizmetKayitGirisDVO.saglikTesisKodu = saglikTesisKodu;
                hizmetKayitGirisDVO.ktsHbysKodu = ktsHbysKodu;
                hizmetKayitGirisDVO.takipNo = takipNo;
                hizmetKayitGirisDVO.triajBeyani = triajBeyani;

                if (ameliyatveGirisimBilgileri != null && ameliyatveGirisimBilgileri.Count > 0)
                    hizmetKayitGirisDVO.ameliyatveGirisimBilgileri = ameliyatveGirisimBilgileri.ToArray();

                if (digerIslemBilgileri != null && digerIslemBilgileri.Count > 0)
                    hizmetKayitGirisDVO.digerIslemBilgileri = digerIslemBilgileri.ToArray();

                if (disBilgileri != null && disBilgileri.Count > 0)
                    hizmetKayitGirisDVO.disBilgileri = disBilgileri.ToArray();

                if (ilacBilgileri != null && ilacBilgileri.Count > 0)
                    hizmetKayitGirisDVO.ilacBilgileri = ilacBilgileri.ToArray();

                if (kanBilgileri != null && kanBilgileri.Count > 0)
                    hizmetKayitGirisDVO.kanBilgileri = kanBilgileri.ToArray();

                if (konsultasyonBilgileri != null && konsultasyonBilgileri.Count > 0)
                    hizmetKayitGirisDVO.konsultasyonBilgileri = konsultasyonBilgileri.ToArray();

                if (malzemeBilgileri != null && malzemeBilgileri.Count > 0)
                    hizmetKayitGirisDVO.malzemeBilgileri = malzemeBilgileri.ToArray();

                if (tahlilBilgileri != null && tahlilBilgileri.Count > 0)
                    hizmetKayitGirisDVO.tahlilBilgileri = tahlilBilgileri.ToArray();

                if (tanilar != null && tanilar.Count > 0)
                    hizmetKayitGirisDVO.tanilar = tanilar.ToArray();

                if (tetkikveRadyolojiBilgileri != null && tetkikveRadyolojiBilgileri.Count > 0)
                    hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri = tetkikveRadyolojiBilgileri.ToArray();

                if (hastaYatisBilgileri != null && hastaYatisBilgileri.Count > 0)
                    hizmetKayitGirisDVO.hastaYatisBilgileri = hastaYatisBilgileri.ToArray();

                return hizmetKayitGirisDVO;
            }
        }

        public static string GetAccountTransactionType(TTObjectClasses.AccountTransaction act)
        {
            string result = string.Empty;
            if (act != null)
            {
                if (act.SubActionProcedure != null)
                    result = "HİZMET";
                else
                {
                    if (act.SubActionMaterial != null && act.SubActionMaterial.Material != null)
                    {
                        if (act.SubActionMaterial.Material is TTObjectClasses.DrugDefinition || act.SubActionMaterial.Material is TTObjectClasses.MagistralPreparationDefinition)
                            result = "İLAÇ";
                        else
                            result = "MALZEME";
                    }
                    //else
                    //    Medula.MedulaLog.AddErr(string.Format("NebulaXXXXXXHelper.NebulaXXXXXXHelper Metodu SubActionProcedure ve SubActionMaterial Acctrx :{0} ", act.ObjectID.ToString()), null, TTObjectClasses.MedulaOperationTypeEnum.Genel);
                }
            }
            return result;
        }


        #endregion


    }
}