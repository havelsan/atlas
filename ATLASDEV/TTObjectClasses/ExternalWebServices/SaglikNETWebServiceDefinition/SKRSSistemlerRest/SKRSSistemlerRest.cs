
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
using Newtonsoft.Json;

namespace TTObjectClasses
{
    public partial class SKRSSistemlerRest : TTObject, IRestServiceObject
    {
        public IRestCallParameters GetRestCallParameters(string methodName, HttpVerbMethod httpVerb)
        {
            var restCallParamaters = new TTUtils.RestCallParameters();

            restCallParamaters.Headers = new Dictionary<string, string>();
            string UserName = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
            string Password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            string ApplicationCode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");
            string SKRSRestApiURL = TTObjectClasses.SystemParameter.GetParameterValue("SKRSRESTAPIURL", "http://xxxxxx.com/api/SkrsService");

            restCallParamaters.Headers.Add("content-type", "application/json");
            restCallParamaters.Headers.Add("KullaniciAdi", UserName);
            restCallParamaters.Headers.Add("Sifre", Password);
            restCallParamaters.Headers.Add("UygulamaKodu", ApplicationCode);

            string baseAddress = SKRSRestApiURL;

            restCallParamaters.HttpVerb = httpVerb;
            restCallParamaters.MethodUrl = $"{baseAddress}/{methodName}";

            return restCallParamaters;
        }

        public static partial class WebMethods
        {

        }

        #region Methods

        public class GetSkrsObjectResponse
        {
            public int durum { get; set; }
            public SkrsObjectsResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SkrsObjectsResult
        {
            public SkrsObject[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SkrsObject
        {
            public string KODTIPIADI { get; set; }
            public bool AKTIF { get; set; }
            public string ADI { get; set; }
            public string KODU { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
        }


        public class AddOlayAfetBilgisiResponse
        {
            public int durum { get; set; }
            public bool sonuc { get; set; }
            public string mesaj { get; set; }
        }


        public class AddOlayAfetBilgisiRequest
        {
            public int olayNo { get; set; }
            public int? bagliOlayNo { get; set; }
            public string olayIsmi { get; set; }
            public int olayIlKodu { get; set; }
            public string lokasyon { get; set; }
            public DateTime? tarihSaat { get; set; }
            public DateTime? kapatilmaTarihi { get; set; }
            public int durum { get; set; }
            public int olayTipi { get; set; }
            public string bilgiNotu { get; set; }
            public string etkilenenIller { get; set; }
        }


        public class GetSkrsListResponse
        {
            public int durum { get; set; }
            public SkrsList[] sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SkrsList
        {
            public string KODU { get; set; }
            public string ADI { get; set; }
            public string ACIKLAMA { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
        }


        public class GetICD10Response
        {
            public int durum { get; set; }
            public SKRSICD10Result sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSICD10Result
        {
            public SKRSICD10[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSICD10
        {
            public string ADI { get; set; }
            public string KODU { get; set; }
            public string USTKODU { get; set; }
            public int SEVIYE { get; set; }
            public bool ANNEOLUMU { get; set; }
            public bool BILDIRIMIZORUNLU { get; set; }
            public bool OLUMNEDENI { get; set; }
            public bool AKTIF { get; set; }
            public bool YUKSEKRISKLIGEBELIK { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetSKRSIlacResponse
        {
            public int durum { get; set; }
            public SKRSIlacResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSIlacResult
        {
            public SKRSIlac[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSIlac
        {
            public string ADI { get; set; }
            public string BARKODU { get; set; }
            public bool GERIODEME { get; set; }
            public int RECETETURU { get; set; }
            public string FIRMAADI { get; set; }
            public string ATCKODU { get; set; }
            public string ATCADI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetLOINCResponse
        {
            public int durum { get; set; }
            public SKRSLOINCResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSLOINCResult
        {
            public SKRSLOINC[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSLOINC
        {
            [JsonProperty("NUMARASI")]
            public string LOINCNUMARASI { get; set; }
            [JsonProperty("LOINCINGILIZCEUZUNADI")]
            public string LOINCCOMMONNAME { get; set; }
            [JsonProperty("TURKCEKARSILIGI")]
            public string LOINCTURKCEKARSILIGI { get; set; }
            [JsonProperty("GRUPADI")]
            public string GRUPNAME { get; set; }
            [JsonProperty("GRUPTURKCEADI")]
            public string GRUPADI { get; set; }
            public string BILESEN { get; set; }
            public string OZELLIK { get; set; }
            public string ZAMANLAMA { get; set; }
            public string MATERYAL { get; set; }
            public string SKALA { get; set; }
            [JsonProperty("METOT")]
            public string METOD { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetKurumResponse
        {
            public int durum { get; set; }
            public SKRSKurumResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSKurumResult
        {
            public SKRSKurum[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSKurum
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKODU { get; set; }
            public int ILCEKODU { get; set; }
            public string KURUMTIPI { get; set; }
            public int KURUMTURKODU { get; set; }
            public int BASAMAKSEVIYESI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetSUTResponse
        {
            public int durum { get; set; }
            public SKRSSUTResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSSUTResult
        {
            public SKRSSUT[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSSUT
        {
            public string ADI { get; set; }
            public string KODU { get; set; }
            public float FIYAT { get; set; }
            public int IDUSTNO { get; set; }
            public string TIP { get; set; }
            public int? PUAN { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetBucakResponse
        {
            public int durum { get; set; }
            public SKRSBucakResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSBucakResult
        {
            public SKRSBucak[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSBucak
        {
            public int ILCEKODU { get; set; }
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetGunSonuOzetAciklamaResponse
        {
            public int durum { get; set; }
            public GunSonuOzetAciklamaResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class GunSonuOzetAciklamaResult
        {
            public SKRSGunSonuOzetAciklama[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSGunSonuOzetAciklama
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool AKTIF { get; set; }
            public string REFERANSVERI { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetTeletipKurumOnekBilgileriResponse
        {
            public int durum { get; set; }
            public TeletipKurumOnekBilgileriResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class TeletipKurumOnekBilgileriResult
        {
            public SKRSTeletipKurumOnekBilgileri[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSTeletipKurumOnekBilgileri
        {
            public int KURUMKODU { get; set; }
            public string KURUMADI { get; set; }
            public string TELETIPONEK { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetKoyResponse
        {
            public int durum { get; set; }
            public KoyResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class KoyResult
        {
            public SKRSKoy[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSKoy
        {
            public int BUCAKKODU { get; set; }
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool Aktif { get; set; }
            public int SIRANO { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetMahalleResponse
        {
            public int durum { get; set; }
            public MahalleResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class MahalleResult
        {
            public SKRSMahalle[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSMahalle
        {
            public int KOYKODU { get; set; }
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool AKTIF { get; set; }
            public int? TANITIMKODU { get; set; }
            public int TIPI { get; set; }
            public int YETKILIIDAREKODU { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetICD10MSVSIliskisiResponse
        {
            public int durum { get; set; }
            public ICD10MSVSIliskisiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class ICD10MSVSIliskisiResult
        {
            public SKRSICD10MSVSIliskisi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSICD10MSVSIliskisi
        {
            public string ICDKODU { get; set; }
            public int MSVSKODU { get; set; }
            public bool AKTIF { get; set; }
            public string MSVSADI { get; set; }
            public string CINSIYETKODU { get; set; }
            public string CINSIYETADI { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetTibbiBiyokimyaAkilciTestIstemiListesiResponse
        {
            public int durum { get; set; }
            public TibbiBiyokimyaAkilciTestIstemiListesiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class TibbiBiyokimyaAkilciTestIstemiListesiResult
        {
            public SKRSTibbiBiyokimyaAkilciTestIstemiListesi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSTibbiBiyokimyaAkilciTestIstemiListesi
        {
            public string SUTKODU { get; set; }
            public string ADI { get; set; }
            public int ISTEMSURESI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class RadyolojikTetkikIstemPeriyoduListesiResponse
        {
            public int durum { get; set; }
            public RadyolojikTetkikIstemPeriyoduListesiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class RadyolojikTetkikIstemPeriyoduListesiResult
        {
            public SKRSRadyolojikTetkikIstemPeriyoduListesi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSRadyolojikTetkikIstemPeriyoduListesi
        {
            public string SUTKODU { get; set; }
            public string ADI { get; set; }
            public int ISTEMSURESI { get; set; }
            public bool AKTIF { get; set; }
            public string ACIKLAMA { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
        }


        public class GetSKRSSUTVSResponse
        {
            public int durum { get; set; }
            public SKRSSUTVSResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSSUTVSResult
        {
            public SKRSSUTVS[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSSUTVS
        {
            public int MSVSKODU { get; set; }
            public string SUTKODU { get; set; }
            public string MSVSADI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
        }


        public class GetOkulCagiGenclikIzlemTakvimiResponse
        {
            public int durum { get; set; }
            public OkulCagiGenclikIzlemTakvimiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class OkulCagiGenclikIzlemTakvimiResult
        {
            public SKRSOkulCagiGenclikIzlemTakvimi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSOkulCagiGenclikIzlemTakvimi
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool AKTIF { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            public bool PERFDAHILMI { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetIlceResponse
        {
            public int durum { get; set; }
            public SKRSIlceResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class SKRSIlceResult
        {
            public SKRSIlce[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSIlce
        {
            public int ILKODU { get; set; }
            public string ADI { get; set; }
            public int KODU { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }

        public class GetOlayAfetBilgisiResponse
        {
            public int durum { get; set; }
            public OlayAfetBilgisiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class OlayAfetBilgisiResult
        {
            public SKRSOlayAfetBilgisi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSOlayAfetBilgisi
        {
            public int? BAGLIOLAYNO { get; set; }
            public int OLAYNO { get; set; }
            public string OLAYISMI { get; set; }
            public int OLAYILKODU { get; set; }
            public string LOKASYON { get; set; }
            public DateTime? TARIHSAAT { get; set; }
            public int AKTIF { get; set; }
            public int OLAYTIPI { get; set; }
            public string BILGINOTU { get; set; }
            public string ETKILENENILLER { get; set; }
            public DateTime? KAPATILMATARIHI { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetEgitimKurumlariResponse
        {
            public int durum { get; set; }
            public EgitimKurumlariResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class EgitimKurumlariResult
        {
            public SKRSEgitimKurumlari[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSEgitimKurumlari
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKODU { get; set; }
            public int ILCEKODU { get; set; }
            public string TURADI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetTibbiIslemPuanBilgisiResponse
        {
            public int durum { get; set; }
            public TibbiIslemPuanBilgisiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class TibbiIslemPuanBilgisiResult
        {
            public SKRSTibbiIslemPuanBilgisi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSTibbiIslemPuanBilgisi
        {
            public string ADI { get; set; }
            public string KODU { get; set; }
            public string ACIKLAMA { get; set; }
            public float ISLEMPUANI { get; set; }
            public string OZELLIKLIISLEM { get; set; }
            public string AMELIYATGRUPLARI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }

        public class GetAsiTakvimiResponse
        {
            public int durum { get; set; }
            public AsiTakvimiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class AsiTakvimiResult
        {
            public SKRSAsiTakvimi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSAsiTakvimi
        {
            public string ADI { get; set; }
            public int ASITURUKODU { get; set; }
            public int DOZKODU { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            [JsonProperty("PERFORMANSADAHILMI")]
            public bool PERFDAHILMI { get; set; }
            public bool AKTIF { get; set; }
            public int TAKVIMTIPI { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetBebekIzlemTakvimiResponse
        {
            public int durum { get; set; }
            public BebekIzlemTakvimiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class BebekIzlemTakvimiResult
        {
            public SKRSBebekIzlemTakvimi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSBebekIzlemTakvimi
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            [JsonProperty("PERFORMANSADAHILMI")]
            public bool PERFDAHILMI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetCocukIzlemTakvimiResponse
        {
            public int durum { get; set; }
            public CocukIzlemTakvimiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class CocukIzlemTakvimiResult
        {
            public SKRSCocukIzlemTakvimi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSCocukIzlemTakvimi
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            [JsonProperty("PERFORMANSADAHILMI")]
            public bool PERFDAHILMI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetGebeIzlemTakvimiResponse
        {
            public int durum { get; set; }
            public GebeIzlemTakvimiResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class GebeIzlemTakvimiResult
        {
            public SKRSGebeIzlemTakvimi[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSGebeIzlemTakvimi
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            [JsonProperty("PERFORMANSADAHILMI")]
            public bool PERFDAHILMI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetMeslekHastaliklariResponse
        {
            public int durum { get; set; }
            public MeslekHastaliklariResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class MeslekHastaliklariResult
        {
            public SKRSMeslekHastaliklari[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSMeslekHastaliklari
        {
            public string ADI { get; set; }
            public int? KODU { get; set; }
            public string ICDADI { get; set; }
            public string ICDKODU { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetICDOResponse
        {
            public int durum { get; set; }
            public ICDOResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class ICDOResult
        {
            public SKRSICDO[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSICDO
        {
            public int SKRSKODU { get; set; }
            public string TOPOGRAFIKODU { get; set; }
            public string KODTANIMI { get; set; }
            public string KODACIKLAMA { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetMesleklerResponse
        {
            public int durum { get; set; }
            public MesleklerResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class MesleklerResult
        {
            public SKRSMeslekler[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSMeslekler
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ISKURKODU { get; set; }
            public int IDUSTNO { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetPersentilResponse
        {
            public int durum { get; set; }
            public PersentilResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class PersentilResult
        {
            public SKRSPersentil[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSPersentil
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public float ALTSINIR { get; set; }
            public int AY { get; set; }
            public string BIRIM { get; set; }
            public int SEVIYE { get; set; }
            public int USTBOLUMKODU { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetYasGruplariResponse
        {
            public int durum { get; set; }
            public YasGruplariResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class YasGruplariResult
        {
            public SKRSYasGruplari[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSYasGruplari
        {
            public string ADI { get; set; }
            public int BASLANGICYASI { get; set; }
            public int BITISYASI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetUlkeResponse
        {
            public int durum { get; set; }
            public UlkeResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class UlkeResult
        {
            public SKRSUlke[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSUlke
        {
            public string ADI { get; set; }
            public string KODU { get; set; }
            public int MERNISKODU { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetGETATUygulandigiDurumlarResponse
        {
            public int durum { get; set; }
            public GETATUygulandigiDurumlarResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class GETATUygulandigiDurumlarResult
        {
            public SKRSGETATUygulandigiDurumlar[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSGETATUygulandigiDurumlar
        {
            public string UYGULANACAKDURUMLAR { get; set; }
            public int KODU { get; set; }
            public bool MERKEZDEUYGULANABILMESI { get; set; }
            public bool UNITEDEUYGULANABILMESI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetKacinciLohusaIzlemResponse
        {
            public int durum { get; set; }
            public KacinciLohusaIzlemResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class KacinciLohusaIzlemResult
        {
            public SKRSKacinciLohusaIzlem[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSKacinciLohusaIzlem
        {
            public string ADI { get; set; }
            public int KODU { get; set; }
            public int ILKUYGULANMATARIHI { get; set; }
            public int SONUYGULANMATARIHI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetICDOMorfolojiKoduResponse
        {
            public int durum { get; set; }
            public ICDOMorfolojiKoduResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class ICDOMorfolojiKoduResult
        {
            public SKRSICDOMorfolojiKodu[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSICDOMorfolojiKodu
        {
            public string MORFOLOJIKOD { get; set; }
            public string MORFOLOJIKODTANIM { get; set; }
            public string MORFOLOJIKODACIKLAMA { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }


        public class GetASALHastalikResponse
        {
            public int durum { get; set; }
            public ASALHastalikResult sonuc { get; set; }
            public string mesaj { get; set; }
        }

        public class ASALHastalikResult
        {
            public SKRSASALHastalik[] kayit { get; set; }
            public int sonrakiSayfa { get; set; }
        }

        public class SKRSASALHastalik
        {
            [JsonProperty("KODU")]
            public string KOD { get; set; }
            public int ASALKOD { get; set; }
            public string ASALKODADI { get; set; }
            public bool AKTIF { get; set; }
            public DateTime? OLUSTURULMATARIHI { get; set; }
            public DateTime? GUNCELLEMETARIHI { get; set; }
            public DateTime? PASIFEALINMATARIHI { get; set; }
        }

        public class LogWriter
        {
            private string m_exePath = string.Empty;
            public LogWriter(string logMessage)
            {
                LogWrite(logMessage);
            }
            public void LogWrite(string logMessage)
            {
                m_exePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                try
                {
                    using (System.IO.StreamWriter w = System.IO.File.AppendText(m_exePath + "\\" + "skrslog.txt"))
                    {
                        Log(logMessage, w);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            public void Log(string logMessage, System.IO.TextWriter txtWriter)
            {
                try
                {
                    txtWriter.Write("\r\nLog Entry : ");
                    txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    txtWriter.WriteLine("  :");
                    txtWriter.WriteLine("  :{0}", logMessage);
                    txtWriter.WriteLine("-------------------------------");
                }
                catch (Exception ex)
                {
                }
            }
        }

        #endregion

    }
}