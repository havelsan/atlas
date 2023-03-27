
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
    public partial class UTSServis : TTObject, IRestServiceObject
    {
        public IRestCallParameters GetRestCallParameters(string methodName, HttpVerbMethod httpVerb)
        {
            string UTSTOKEN = TTObjectClasses.SystemParameter.GetParameterValue("UTSTOKEN", "System61a6242b-8dcc-47fe-bff1-d828a3091969");
            var restCallParamaters = new TTUtils.RestCallParameters();
            restCallParamaters.Headers = new Dictionary<string, string>();
            restCallParamaters.Headers.Add("Content-type", "application/json; charset=utf-8");
            /////////////////////////////////////////////////////////////

            string baseAddress = TTObjectClasses.SystemParameter.GetParameterValue("UTSWEBSERVISLERIBASEADDRESS", "");

            //Just for TEST     Comment out later
            //baseAddress = TTObjectClasses.SystemParameter.GetParameterValue("UTSWEBSERVISLERITESTBASEADDRESS", "");            

            restCallParamaters.Headers.Add("utsToken", UTSTOKEN);

            if (methodName == "tibbiCihaz/tibbiCihazSorgula")
                baseAddress = baseAddress.Replace("/uh/", "/");
            if(methodName == "kurum/firmaSorgula")
                baseAddress = baseAddress.Replace("/uh/", "/");
            if (methodName == "tibbiCihaz/urunSorgula")
                baseAddress = baseAddress.Replace("/uh/", "/");
            restCallParamaters.HttpVerb = httpVerb;
            restCallParamaters.MethodUrl = $"{baseAddress}/{methodName}";
            return restCallParamaters;
        }

        public static partial class WebMethods
        {

            public static UrunSorgulaCevap UrunSorgulaSync_ServerSide1(UrunSorgulaIstek urunSorgulaIstek)
            {

                #region UrunSorgulaSync_Body
                TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                header.Namespace = "TTObjectClasses.UTSServis";
                header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                header.MethodName = "tibbiCihaz/urunSorgula";
                header.CallTimeout = 30;
                header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                header.ServiceType = ServiceType.REST;
                IList<Tuple<string, object>> callParameters = new List<Tuple<string, object>>
                    {
                        Tuple.Create("urunSorgulaIstek", (object)urunSorgulaIstek),
                    };

                var classInstance = new UTSServis();
                header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                UrunSorgulaCevap cevap = default(UrunSorgulaCevap);
                var cevapJson = Common.CallWebMethodWithHeader(header, credential, callParameters) as string;
                cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<UrunSorgulaCevap>(cevapJson);
                return cevap;

                #endregion UrunSorgulaSync_Body

            }

            public static UrunSorgulaCevap UrunSorgulaSync_ServerSide2(UrunSorgulaIstek urunSorgulaIstek)
            {

                #region UrunSorgulaSync_Body
                TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                header.Namespace = "TTObjectClasses.UTSServis";
                header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                header.MethodName = "tibbiCihaz/urunSorgula";
                header.CallTimeout = 600;
                header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                header.ServiceType = ServiceType.REST;

                var classInstance = new UTSServis();
                header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                UrunSorgulaCevap cevap = default(UrunSorgulaCevap);
                var cevapJson = Common.CallWebMethodWithHeader(header, credential, urunSorgulaIstek) as string;
                cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<UrunSorgulaCevap>(cevapJson);
                return cevap;

                #endregion UrunSorgulaSync_Body

            }

            public static List<FirmaSorgulaCevap> FirmaSorgulaSonucSync_ServerSide2(FirmaSorgulaIstek firmaSorgulaIstek)
            {

                #region FirmaSorgulaSonucSync_Body
                TTUtils.WebMethodCallHeader header = new TTUtils.WebMethodCallHeader();
                header.Namespace = "TTObjectClasses.UTSServis";
                header.ServiceId = "56bab21b-b5ec-4b54-94d4-511ebece5981";
                header.MethodName = "kurum/firmaSorgula";
                header.CallTimeout = 600;
                header.CallerId = TTUser.CurrentUser.UniqueRefNo;
                header.SiteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                header.ServiceType = ServiceType.REST;

                var classInstance = new UTSServis();
                header.RestCallParameters = classInstance.GetRestCallParameters(header.MethodName, HttpVerbMethod.POST);

                TTUtils.WebMethodCredential credential = new TTUtils.WebMethodCredential();

                List<FirmaSorgulaCevap> cevap = new List<FirmaSorgulaCevap>();
                var cevapJson = Common.CallWebMethodWithHeader(header, credential, firmaSorgulaIstek) as string;
                cevap = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FirmaSorgulaCevap>>(cevapJson);
                return cevap;

                #endregion FirmaSorgulaSonucSync_Body

            }


        }

        #region Methods
        [Serializable]
        public class UrunSorgulaIstek
        {
            public string UNO { get; set; }
        }

        [Serializable]
        public class FirmaSorgulaIstek
        {
            public string MRS { get; set; }
            public string VRG { get; set; }
            public string UNV { get; set; }
        }


        [Serializable]
        public class VidAlmaBildirimiIstek
        {
            public string VBI { get; set; }
            public int? ADT { get; set; }
        }

        [Serializable]
        public class VermeBildirimiIstek
        {
            public string UNO { get; set; }
            public string LNO { get; set; }
            public string SNO { get; set; }
            public int? ADT { get; set; }
            public long? KUN { get; set; }
            public string BNO { get; set; }
        }

        [Serializable]
        public class UnoAlmaBildirimiIstek
        {
            public string UNO { get; set; }
            public string LNO { get; set; }
            public int? ADT { get; set; }
            public long? GKK { get; set; }
        }

        [Serializable]
        public class KullanimBildirimiIstek
        {
            public string UNO { get; set; }
            public string LNO { get; set; }
            public string SNO { get; set; }
            public int? ADT { get; set; }
            public string HAA { get; set; }
            public string HAS { get; set; }
            public long? TKN { get; set; }
            public double? YKN { get; set; }
            public string PAN { get; set; }
            public string GIT { get; set; }
            public string KTN { get; set; }
            public string TUR { get; set; }
            public string DTA { get; set; }
        }

        [Serializable]
        public class KullanimIptalBildirimiIstek
        {
            public string BID { get; set; }
        }

        [Serializable]
        public class KabulEdilecekTekilUrunSorgulaIstek
        {
            public long GKK { get; set; }
            public int SAN { get; set; }
        }

        [Serializable]
        public class SayiIleKabulEdilecekTekilUrunSorgulaIstek
        {
            public long GKK { get; set; }
            public int ADT { get; set; }
            public string OFF { get; set; }
        }

        [Serializable]
        public class ButunUrunleriSorgulaIstek
        {
            public int sayfaBuyuklugu { get; set; }
            public int sayfaIndeksi { get; set; }
            public string baslangicTarihi { get; set; }
            public string bitisTarihi { get; set; }
        }

        [Serializable]
        public class UrunSorgulaCevap
        {
            public int Sonuc { get; set; }
            public string SonucMesaji { get; set; }
            public List<UrunSorgulaUrunBilgi> UrunDetayList { get; set; }
        }

        [Serializable]
        public class UrunSorgulaUrunBilgi
        {
            public string BirincilUrunNumarasi { get; set; }
            public string MarkaAdi { get; set; }
            public string VersiyonModel { get; set; }
            public string EtiketAdi { get; set; }
            public string KalibrasyonaTabiMi { get; set; }
            public int? KalibrasyonPeriyodu { get; set; }
            public string BakimaTabiMi { get; set; }
            public int? BakimPeriyodu { get; set; }
            public string TakipDurumu { get; set; }
            public string UreticiFirma { get; set; }
            public int BransKodu { get; set; }
            public int? BransTurKodu { get; set; }
            public int? GmdnKodu { get; set; }
            public int UrunSayisi { get; set; }
        }

        [Serializable]
        public class BildirimCevap
        {
            public string SNC { get; set; }
            public List<Mesaj> MSJ { get; set; }

        }

        [Serializable]
        public class Mesaj
        {
            public string TIP { get; set; }
            public string MET { get; set; }
            public string KOD { get; set; }
            public List<object> MPA { get; set; }
        }

        [Serializable]
        public class KabulEdilecekTekilUrunSorgulaCevap
        {
            public List<KabulEdilecekTekilUrunSorgulaSonuc> SNC { get; set; }
            public List<Mesaj> MSJ { get; set; }
        }

        [Serializable]
        public class FirmaSorgulaCevap
        {
            public long KRN { get; set; }
            public string GAD { get; set; }
            public string DRM { get; set; }
            public string MRS { get; set; }
            public string VRG { get; set; }
        }

       
        [Serializable]
        public class SayiIleKabulEdilecekTekilUrunSorgulaCevap
        {
            public SayiIleKabulEdilecekTekilUrunSorgulaSonuc SNC { get; set; }
            public List<Mesaj> MSJ { get; set; }
        }

        [Serializable]
        public class SayiIleKabulEdilecekTekilUrunSorgulaSonuc
        {
            public List<KabulEdilecekTekilUrunSorgulaSonuc> LST { get; set; }
            public string OFF { get; set; }
        }

        [Serializable]
        public class KabulEdilecekTekilUrunSorgulaSonuc
        {
            public long GKK { get; set; }
            public string UNO { get; set; }
            public string LNO { get; set; }
            public string SNO { get; set; }
            public int ADT { get; set; }
            public string BID { get; set; }
            public string BNO { get; set; }
            public DateTime BZA { get; set; }
            public string BTI { get; set; }
            public long UIK { get; set; }
            public string GKU { get; set; }
            public string MME { get; set; }
        }

        [Serializable]
        public class ButunUrunleriSorgulaCevap
        {
            public List<UrunDetay> urunDetayList { get; set; }
        }

        [Serializable]
        public class UrunDetay
        {
            public object sinif { get; set; }
            public object takipDurumu { get; set; }
            public object birincilUrunNumarasi { get; set; }
            public object urunTipi { get; set; }
            public object durum { get; set; }
            public object durumBaslagicTarihi { get; set; }
            public object markaAdi { get; set; }
            public object etiketAdi { get; set; }
            public object versiyonModel { get; set; }
            public object katalogNo { get; set; }
            public object ithalImalBilgisi { get; set; }
            public object guncellenmeTarihi { get; set; }
        }

        public static class KullanimBildirimiTur
        {
            public const string TC_KIMLIK_NUMARASI_VAR = "TC_KIMLIK_NUMARASI_VAR";
            public const string YABANCI_KIMLIK_NUMARASI_VAR = "YABANCI_KIMLIK_NUMARASI_VAR";
            public const string PASAPORT_NUMARASI_VAR = "PASAPORT_NUMARASI_VAR";
            public const string YENI_DOGAN = "YENI_DOGAN";
            public const string KIMLIGI_BELIRSIZ = "KIMLIGI_BELIRSIZ";
            public const string DIGER = "DIGER";
        }

        #endregion
    }
}