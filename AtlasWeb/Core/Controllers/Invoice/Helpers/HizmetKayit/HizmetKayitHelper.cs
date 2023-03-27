using System.Reflection;
using Core.Controllers.Invoice.Helpers;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using Core.Controllers.Invoice.Helpers.HizmetKayit;

namespace Core.Controllers.Invoice.Helpers
{
    public class HizmetKayitHelper
    {
        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult HizmetKayitTopluSync(string subEpisodeProtocolObjectID, bool unsuccessfulProceduresIncluded)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            HizmetKayitIslemleri.hizmetKayitCevapDVO hataliResult = null;
            int transactionsCount = 0;
            int diagnosisCount = 0;
            int maxHizmetSayisi = 0;
            int maxTryCount = 0;
            int tryCount = 0;
            List<Guid> newAccTrxState = GetNewAccTrxState();
            List<Guid> newDiagnosisState = GetNewDiagnosisState();
            SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(new Guid(subEpisodeProtocolObjectID), typeof (SubEpisodeProtocol));
            // Hatalılar Dahil ise önce, hatalı hizmet ve tanılar Yeni durumuna alınır
            if (unsuccessfulProceduresIncluded)
            {
                SetStateToNewForUnsuccessfulAccTrx(subEpisodeProtocolObjectID);
                TaniHizmetKayitHelper.SetMedulaStatusToNewForUnsuccessfulDiagnosis(subEpisodeProtocolObjectID, objectcontext);
            }

            // Mükerer tanıları Medulaya Gönderilmeyecek durumuna alır
            TaniHizmetKayitHelper.ControlRepeatedDiagnosis(subEpisodeProtocolObjectID);
            // Gündüz yatak hizmetini kontrol eder ve yoksa oluşturur
            ArrangeDailyBedProcedure(subEpisodeProtocolObjectID);
            bool tryAllTransSend = Convert.ToString(SystemParameter.GetParameterValue("MEDULATEKRARHIZMETKAYIT", "H")).Equals("E");
            if (tryAllTransSend)
            {
                transactionsCount = Utils.GetMedulaTransactionCountBySEPAndState(objectcontext, subEpisodeProtocolObjectID, newAccTrxState);
                diagnosisCount = Utils.GetMedulaDiagnosisCountBySEPAndState(objectcontext, subEpisodeProtocolObjectID, newDiagnosisState);
                maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                maxTryCount = ((((transactionsCount + diagnosisCount) / maxHizmetSayisi) * 2) == 0 ? 1 : (((transactionsCount + diagnosisCount) / maxHizmetSayisi) * 2)) + 1;
            }

            DateTime? sendingTime = null;
            do
            {
                HizmetKayit.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new HizmetKayit.HizmetKayitGirisDVOWithList();
                if (!tryAllTransSend || (tryAllTransSend && diagnosisCount > 0))
                    TaniHizmetKayitHelper.GetHizmetKayitGirisDVODiagnosisGridList(subEpisodeProtocolObjectID, hizmetKayitGirisDVOWithList, objectcontext, newDiagnosisState, false);
                var hizmetGirisList = GetHizmetKayitGirisDVOAccountTransactionList(subEpisodeProtocolObjectID, hizmetKayitGirisDVOWithList, objectcontext, newAccTrxState, false);
                foreach (var oneHizmetKayitGirisDVO in hizmetGirisList)
                {
                    tryCount++;
                    TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam(oneHizmetKayitGirisDVO.HizmetKayitGirisDVO, subEpisodeProtocolObjectID);
                    DateTime sendingAgain = DateTime.Now;
                    if (sendingTime.HasValue && sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.Value.TimeOfDay.TotalMilliseconds < 2000)
                        Thread.Sleep(2000 - Convert.ToInt32((sendingAgain.TimeOfDay.TotalMilliseconds - sendingTime.Value.TimeOfDay.TotalMilliseconds)));
                    HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, null, oneHizmetKayitGirisDVO.HizmetKayitGirisDVO);
                    sendingTime = DateTime.Now;
                    if (result.sonucKodu != "0000")
                        hataliResult = result;
                    inputParam.HizmetKayitCompletedInternal(result, oneHizmetKayitGirisDVO.HizmetKayitGirisDVO, objectcontext, false);
                }

                objectcontext.Save();
                //TTObjectClasses.MedulaHelper.SetMedulaProvisionStatusAfterProcedureEntryByObjectID(subEpisodeProtocolObjectID, objectcontext);
                if (tryAllTransSend)
                {
                    transactionsCount = Utils.GetMedulaTransactionCountBySEPAndState(objectcontext, subEpisodeProtocolObjectID, newAccTrxState);
                    diagnosisCount = Utils.GetMedulaDiagnosisCountBySEPAndState(objectcontext, subEpisodeProtocolObjectID, newDiagnosisState);
                }
            }
            while ((transactionsCount + diagnosisCount) > 0 && tryAllTransSend && tryCount < maxTryCount);
            if (hataliResult == null)
            {
                hataliResult = new HizmetKayitIslemleri.hizmetKayitCevapDVO();
                hataliResult.sonucKodu = "0000";
                hataliResult.sonucMesaji = TTUtils.CultureService.GetText("M26172", "İşlem Başarılı");
            }

            sep.SetInvoiceStatusAfterProcedureEntry();
            Utils.SaveAndDisposeContext(objectcontext);
            return Utils.GetMedulaResult(hataliResult);
        }

        private static List<Guid> GetNewDiagnosisState()
        {
            List<Guid> diagnosisStateList = new List<Guid>();
            diagnosisStateList.Add(SEPDiagnosis.States.New);
            return diagnosisStateList;
        }

        private static List<Guid> GetNewAccTrxState()
        {
            List<Guid> acctrxStateList = new List<Guid>();
            acctrxStateList.Add(AccountTransaction.States.New);
            return acctrxStateList;
        }

        public static void SetStateToNewForUnsuccessfulAccTrx(string subEpisodeProtocolObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);

            List<Guid> stateList = new List<Guid>();
            stateList.Add(AccountTransaction.States.MedulaEntryUnsuccessful);
            IList<AccountTransaction> acctrxList = AccountTransaction.GetTransactionsToSendMedulaBySEP(objectcontext, new Guid(subEpisodeProtocolObjectID), stateList);

            foreach (AccountTransaction acctrx in acctrxList)
                acctrx.CurrentStateDefID = AccountTransaction.States.New;

            Utils.SaveAndDisposeContext(objectcontext);
        }

        public static void ArrangeDailyBedProcedure(string sepObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(new Guid(sepObjectID), typeof (SubEpisodeProtocol));
            sep.ArrangeDailyBedProcedure();
            Utils.SaveAndDisposeContext(objectcontext);
        }

        public static void AddDailyBedProcedure(string sepObjectID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(new Guid(sepObjectID), typeof (SubEpisodeProtocol));
            sep.AddDailyBedProcedure();
            Utils.SaveAndDisposeContext(objectContext);
        }

        private static IEnumerable<HizmetKayitGirisDVOWithList> GetHizmetKayitGirisDVOAccountTransactionList(string subEpisodeProtocolObjectID, HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, TTObjectContext objectcontext, List<Guid> states, bool ASync)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult getDvoResult = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            IList<AccountTransaction> actxList = AccountTransaction.GetTransactionsToSendMedulaBySEP(objectcontext, new Guid(subEpisodeProtocolObjectID), states);
            if (actxList.Count > 0)
            {
                int maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
                for (int i = 0; i < actxList.Count; i++)
                {
                    if (i == 0)
                        loadHizmetTakipBilgileri(hizmetKayitGirisDVOWithList, actxList[i]);
                    AccountTransaction actx = actxList[i];
                    getDvoResult = LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, actx);
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
                            hizmetKayitGirisDVOWithList = new HizmetKayitGirisDVOWithList();
                            loadHizmetTakipBilgileri(hizmetKayitGirisDVOWithList, actxList[i]);
                        }
                    }
                    else if (i == actxList.Count - 1)
                    {
                        yield return hizmetKayitGirisDVOWithList;
                    }
                }
            }

            //TODO: AAE Burası kapatıldı hataya sebep olmuş olabilir.
            //if (hizmetKayitGirisDVOWithList.HizmetSayisi > 0)
            //{
            //    yield return hizmetKayitGirisDVOWithList;
            //}
            yield break;
        }

        /// <summary>
        /// Tanı hizmet kaydı sırasında gerekli olan HastaBaşvuru Numarası, Takip Numarası ve Tesis kodu bilgilerinin bulunduğu metod
        /// </summary>
        /// <param name = "hizmetKayitGirisDVOWithList"></param>
        /// <param name = "sepDiagnosis"></param>
        public static void loadHizmetTakipBilgileri(HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, SEPDiagnosis sepDiagnosis)
        {
            hizmetKayitGirisDVOWithList.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetKayitGirisDVOWithList.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetKayitGirisDVOWithList.hastaBasvuruNo = sepDiagnosis.SubEpisodeProtocol.MedulaBasvuruNo;
            hizmetKayitGirisDVOWithList.takipNo = sepDiagnosis.SubEpisodeProtocol.MedulaTakipNo;
            hizmetKayitGirisDVOWithList.triajBeyani = sepDiagnosis.SubEpisodeProtocol.Triaj;
        }

        /// <summary>
        /// Oluşturulacak olan HizmetKayitGirisDVO nesnesinin bazı bilgilerini(HastaBasvuruNo,SaglikTesisKodu,TakipNo,TedaviTuru) doldurmak için kullanılır 
        /// </summary>
        /// <param name = "hizmetKayitGirisDVOWithList"></param>
        /// <param name = "acctrx"></param>
        public static void loadHizmetTakipBilgileri(HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, AccountTransaction acctrx)
        {
            hizmetKayitGirisDVOWithList.hastaBasvuruNo = acctrx.SubEpisodeProtocol.MedulaBasvuruNo;
            hizmetKayitGirisDVOWithList.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetKayitGirisDVOWithList.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetKayitGirisDVOWithList.takipNo = acctrx.SubEpisodeProtocol.MedulaTakipNo;
            hizmetKayitGirisDVOWithList.TedaviTuru = acctrx.SubEpisodeProtocol.MedulaTedaviTuru;
            hizmetKayitGirisDVOWithList.triajBeyani = acctrx.SubEpisodeProtocol.Triaj;
        }

        /// <summary>
        /// Tanıların hizmet kaydını yapmak için kullanılır
        /// </summary>
        /// <param name = "hizmetKayitGirisDVOWithList"></param>
        /// <param name = "sepDiagnosis"></param>
        public static void LoadHizmetBilgileri(HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList, SEPDiagnosis sepDiagnosis)
        {
            object obj = getDVO(sepDiagnosis);
            if (obj is TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO)
                hizmetKayitGirisDVOWithList.tanilar.Add((TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO)obj);
        }

        /// <summary>
        /// Temel amacı kabulun hareketinin HizmetKayitGirisDVO nesnesi içerisinde ilgili DVO arrayine atmaktır.Ayrıca XXXXXX'dan gelen DVO nun boş olup olmaması, 
        /// DVO tipi ile işlemin "MEDULA DVO" tipi arasındaki farklılık kontrolu
        /// DVO içerisindeki zorunlu alanların doluluk kontrollerinin yapıldığı işlevdir.
        /// </summary>
        /// <param name = "hizmetKayitGirisDVO">Medualya gönderilecek olan HizmetKayitGirisDVO tipindeki nesneyi üretecek, hizmetlerin listesini tutan nesne</param>
        /// <param name = "actx">AccountTransaction nesnesi</param>
        /// <returns>Kontroller sonrası AccountTransaction nesnesinin HizmetKayitGirisDVO nesnesine dahil edilip edilmediğini gösterir</returns>
        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult LoadHizmetBilgileri(HizmetKayitGirisDVOWithList hizmetKayitGirisDVO, AccountTransaction actx)
        {
            return LoadHizmetBilgileri(hizmetKayitGirisDVO, actx, false);
        }

        /// <summary>
        /// Temel amacı kabulun hareketinin HizmetKayitGirisDVO nesnesi içerisinde ilgili DVO arrayine atmaktır.Ayrıca XXXXXX'dan gelen DVO nun boş olup olmaması, 
        /// DVO tipi ile işlemin "MEDULA DVO" tipi arasındaki farklılık kontrolu
        /// DVO içerisindeki zorunlu alanların doluluk kontrollerinin yapıldığı işlevdir.
        /// </summary>
        /// <param name = "hizmetKayitGirisDVO">Medualya gönderilecek olan HizmetKayitGirisDVO tipindeki nesneyi üretecek, hizmetlerin listesini tutan nesne</param>
        /// <param name = "actx">AccountTransaction nesnesi</param>
        /// <param name = "isReadDVOXML">Bu işlevin oluşan DVO nesnesinin sadece XML bilgisini görüntülemek için mi kullanılacağını belirtir değişken, eğer true ise kontroller sonucu işlem yarıda kesilmez oluşan nesnenin XML bilgisi geri döndürülür</param>
        /// <returns>Kontroller sonrası AccountTransaction nesnesinin HizmetKayitGirisDVO nesnesine dahil edilip edilmediğini gösterir</returns>
        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult LoadHizmetBilgileri(HizmetKayitGirisDVOWithList hizmetKayitGirisDVO, AccountTransaction actx, bool isReadDVOXML)
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
                    if (HizmetKayitHelper.IsMedulaProcedureTypeControlActive)
                    {
                        // DVO tipi ile medula işlem tipi kontrolu , sonra kaldırılacak
                        result = hizmetKayitGirisDVO.DVOMedulaProcedureTypeKontrol(obj, actx);
                        if (!result.SonucKodu.Equals("0000") && !isReadDVOXML)
                        {
                            //MedulaLog.AddErr(string.Format("DVOMedulaProcedureTypeKontrol Sonuc Kodu:{0}  Sonuc Mesajı: {1} ", result.SonucKodu, result.MedulaMessage), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                            return result;
                        }
                    }

                    // Zorunlu Alan Kontrolleri, sonra kaldırılacak 
                    result = hizmetKayitGirisDVO.ZorunluAlanKontrolu(obj);
                    if (!result.SonucKodu.Equals("0000") && !isReadDVOXML)
                    {
                        //MedulaLog.AddErr(string.Format("ZorunluAlanKontrolu Sonuc Kodu:{0}  Sonuc Mesajı: {1} ", result.SonucKodu, result.MedulaMessage), actx.SubEpisodeProtocol.ObjectID.ToString(), MedulaOperationTypeEnum.HizmetKayit);
                        return result;
                    }

                    ////Özel Durum Ezmesi
                    if (actx.OzelDurum != null)
                        Utils.DVODegerEzici(obj, actx);
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

        /// <summary>
        /// Silinecek Gereksi bir metot
        /// </summary>
        /// <param name = "sepDiagnosis"></param>
        /// <returns></returns>
         //TODO (Şadi) Silinecek
        private static object getDVO(SEPDiagnosis sepDiagnosis)
        {
            object obj = sepDiagnosis.GetDVO();
            if (obj is HizmetKayitIslemleri.taniBilgisiDVO)
            {
                HizmetKayitIslemleri.taniBilgisiDVO XXXXXXTani = (HizmetKayitIslemleri.taniBilgisiDVO)obj;
                TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO result = new TTObjectClasses.HizmetKayitIslemleri.taniBilgisiDVO();
                Utils.SetMedulaObjectValues(result, XXXXXXTani);
                return result;
            }

            return null;
        }

        public static bool IsMedulaProcedureTypeControlActive
        {
            get
            {
                return TTObjectClasses.SystemParameter.GetParameterValue("DVOMEDULAPROCEDURETYPECONTROLACTIVE", "FALSE").Equals("TRUE");
            }
        }

        //public static TTObjectClasses.SubEpisodeProtocol.MedulaResult HizmetKayitSync(List<string> accountTransactionIDs)
        //{
        //    if (accountTransactionIDs.Count > 0)
        //    {
        //        Guid? procedureID;
        //        TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO = GetHizmetKayitGirisDVO(accountTransactionIDs, false, out procedureID);
        //        if (HasHizmetKayitGirisDVOValue(hizmetKayitGirisDVO))
        //        {
        //            TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetKayitParam(hizmetKayitGirisDVO, accountTransactionIDs);
        //            TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetKayitSync(TTObjectClasses.Sites.SiteLocalHost, procedureID, hizmetKayitGirisDVO);
        //            TTObjectContext _context = new TTObjectContext(false);
        //            inputParam.HizmetKayitCompletedInternal(result, hizmetKayitGirisDVO, _context, true);
        //            Utils.SaveAndDisposeContext(_context);
        //            return Utils.GetMedulaResult(result);
        //        }
        //        else
        //        {
        //            return Utils.GetMedulaResult("A0001", "Gönderilecek Hizmet Bulunamadı");
        //        }
        //    }
        //    return null;
        //}
        private static TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO GetHizmetKayitGirisDVO(List<string> accountTransactionIDs, bool ASync, out Guid? procedureID)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            HizmetKayit.HizmetKayitGirisDVOWithList hizmetKayitGirisDVOWithList = new HizmetKayit.HizmetKayitGirisDVOWithList();
            TTObjectClasses.SubEpisodeProtocol.MedulaResult getDvoResult = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            procedureID = null;
            int maxHizmetSayisi = Convert.ToInt32(SystemParameter.GetParameterValue("MEDULAHIZMETKAYITUSTLIMIT", "20"));
            for (int i = 0; i < accountTransactionIDs.Count; i++)
            {
                AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                if (procedureID == null && acctrx.SubActionProcedure != null)
                    procedureID = acctrx.SubActionProcedure.ProcedureObject.ObjectID;
                if (i == 0)
                    loadHizmetTakipBilgileri(hizmetKayitGirisDVOWithList, acctrx);
                getDvoResult = LoadHizmetBilgileri(hizmetKayitGirisDVOWithList, acctrx);
                if (!getDvoResult.SonucKodu.Equals("0000"))
                {
                    acctrx.MedulaResultCode = getDvoResult.SonucKodu;
                    acctrx.MedulaResultMessage = getDvoResult.SonucMesaji;
                    // BaseTreatmentMaterial.GetDVO() da bazı eski malzemeler için accTrx MedulaDontSend durumuna alındığı için
                    // burada tekrar MedulaEntryUnsuccessful yapılmasın diye kontrol eklendi
                    if (acctrx.CurrentStateDefID != AccountTransaction.States.MedulaDontSend)
                    {
                        acctrx.CurrentStateDefID = AccountTransaction.States.MedulaEntryUnsuccessful;
                        if (acctrx.SubEpisodeProtocol.InvoiceStatus != MedulaSubEpisodeStatusEnum.ProcedureEntryWithError)
                            acctrx.SubEpisodeProtocol.InvoiceStatus = MedulaSubEpisodeStatusEnum.ProcedureEntryWithError;
                    }

                    continue;
                }

                if (ASync)
                    acctrx.CurrentStateDefID = AccountTransaction.States.MedulaSentServer; // Sonra kaldırılacak
                if ((hizmetKayitGirisDVOWithList.HizmetSayisi % maxHizmetSayisi) == 0 && i > 0)
                    hizmetKayitGirisDVOWithList = new HizmetKayit.HizmetKayitGirisDVOWithList();
            }

            Utils.SaveAndDisposeContext(objectcontext);
            return hizmetKayitGirisDVOWithList.HizmetKayitGirisDVO;
        }

        private static bool HasHizmetKayitGirisDVOValue(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO objMedula)
        {
            bool result = false;
            foreach (System.Reflection.PropertyInfo item in objMedula.GetType().GetProperties())
            {
                if (item.PropertyType.IsArray)
                {
                    Array val = ((Array)item.GetValue(objMedula, null));
                    if (val != null && val.Length > 0)
                        result = true;
                }
            }

            if (objMedula.muayeneBilgisi != null)
                result = true;
            return result;
        }

        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult HizmetKayitIptalSync(List<string> islemSiraNoList, List<Guid> accountTransactionIDs, string sepObjectID, bool isAccountTransactionList)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            SubEpisodeProtocol sep = (SubEpisodeProtocol)objectcontext.GetObject(new Guid(sepObjectID), typeof (SubEpisodeProtocol));
            if (string.IsNullOrEmpty(sep.MedulaTakipNo))
            {
                objectcontext.Dispose();
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M27011", "Takip numarası boş olamaz."));
            }

            TTObjectClasses.HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO = GetHizmetIptalGirisDVO(islemSiraNoList, sep.MedulaTakipNo);
            TTObjectClasses.XXXXXXMedulaServices.HizmetIptalParam inputParam = new TTObjectClasses.XXXXXXMedulaServices.HizmetIptalParam(hizmetIptalGirisDVO, accountTransactionIDs, sepObjectID, isAccountTransactionList);
            HizmetKayitIslemleri.hizmetIptalCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetIptalSync(TTObjectClasses.Sites.SiteLocalHost, hizmetIptalGirisDVO);
            inputParam.HizmetIptalCompletedInternal(result, hizmetIptalGirisDVO, accountTransactionIDs, objectcontext);
            Utils.SaveAndDisposeContext(objectcontext);
            return Utils.GetMedulaResult(result);
        }

        private static HizmetKayitIslemleri.hizmetIptalGirisDVO GetHizmetIptalGirisDVO(List<string> islemSiraNoList, string takipNo)
        {
            HizmetKayitIslemleri.hizmetIptalGirisDVO hizmetIptalGirisDVO = new HizmetKayitIslemleri.hizmetIptalGirisDVO();
            hizmetIptalGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetIptalGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetIptalGirisDVO.takipNo = takipNo;

            if (islemSiraNoList != null)
                hizmetIptalGirisDVO.islemSiraNumaralari = islemSiraNoList.ToArray();
           
            return hizmetIptalGirisDVO;
        }

        //public static TTObjectClasses.HizmetKayitIslemleri.hizmetOkuCevapDVO HizmetKayitOkuSync(List<string> hizmetSunucuReferansNoList, List<string> islemSiraNoList, string takipNo, string sepObjectID)
        //{
        //    TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO = GetHizmetOkuGirisDVO(hizmetSunucuReferansNoList, islemSiraNoList, takipNo);
        //    TTObjectClasses.XXXXXXMedulaServices.HizmetKayitOkuParam inputParam = new XXXXXXMedulaServices.HizmetKayitOkuParam(hizmetOkuGirisDVO, sepObjectID);
        //    HizmetKayitIslemleri.hizmetOkuCevapDVO result = HizmetKayitIslemleri.WebMethods.hizmetOkuSync(TTObjectClasses.Sites.SiteLocalHost, hizmetOkuGirisDVO);
        //    TTObjectContext objectcontext = new TTObjectContext(false);
        //    inputParam.HizmetOkuCompletedInternal(result, objectcontext);
        //    return result;
        //}
        private static TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO GetHizmetOkuGirisDVO(List<string> hizmetSunucuReferansNoList, List<string> islemSiraNoList, string takipNo)
        {
            TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO hizmetOkuGirisDVO = new TTObjectClasses.HizmetKayitIslemleri.hizmetOkuGirisDVO();
            hizmetOkuGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
            hizmetOkuGirisDVO.ktsHbysKodu = SystemParameter.GetKtsHbysKodu();
            hizmetOkuGirisDVO.takipNo = takipNo;

            if (hizmetSunucuReferansNoList != null && hizmetSunucuReferansNoList.Count > 0 && hizmetSunucuReferansNoList.Count > islemSiraNoList.Count)
                hizmetOkuGirisDVO.hizmetSunucuRefNolari = hizmetSunucuReferansNoList.ToArray();
            else if (islemSiraNoList != null && islemSiraNoList.Count > 0)
                hizmetOkuGirisDVO.islemSiraNumaralari = islemSiraNoList.ToArray();

            return hizmetOkuGirisDVO;
        }
    }
}