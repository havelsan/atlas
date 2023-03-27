//$5C16AAD4
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.Acil112Servis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class Acil112ServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public Acil112ServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class KayitNoProtokolNoDonusumSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string kayitNo
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public string sorguYili
            {
                get;
                set;
            }
        }

        public int KayitNoProtokolNoDonusumSync(KayitNoProtokolNoDonusumSyncInput input)
        {
            var result = Acil112Servis.WebMethods.KayitNoProtokolNoDonusumSync(input.siteID, input.webServisUri, input.kayitNo, input.protokolNo, input.sorguYili);
            return result;
        }

        public class NobetciPersonelGonder_ArraySyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public PersonelBilgileri[] personelListesi
            {
                get;
                set;
            }
        }

        public int NobetciPersonelGonder_ArraySync(NobetciPersonelGonder_ArraySyncInput input)
        {
            var result = Acil112Servis.WebMethods.NobetciPersonelGonder_ArraySync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.personelListesi);
            return result;
        }

        public class NobetciPersonelGondermeMetodu_ArraySyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public NobetciPersonelBilgileri[] nobetciler
            {
                get;
                set;
            }
        }

        public int NobetciPersonelGondermeMetodu_ArraySync(NobetciPersonelGondermeMetodu_ArraySyncInput input)
        {
            var result = Acil112Servis.WebMethods.NobetciPersonelGondermeMetodu_ArraySync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.nobetciler);
            return result;
        }

        public class EUYSTaniGonderASyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IWebMethodCallback callerObject
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public HastaBilgileri hasta
            {
                get;
                set;
            }

            public string ICD10Kodu
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage EUYSTaniGonderASync(EUYSTaniGonderASyncInput input)
        {
            var result = Acil112Servis.WebMethods.EUYSTaniGonderASync(input.siteID, input.callerObject, input.webServisUri, input.userName1, input.userPassword1, input.hasta, input.ICD10Kodu);
            return result;
        }

        public class VakaSonlandirmaMetoduASyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IWebMethodCallback callerObject
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public string tarih
            {
                get;
                set;
            }

            public string hastaKabulTarihi
            {
                get;
                set;
            }

            public string hastaAyrilisTarihi
            {
                get;
                set;
            }

            public string vakaSonuc
            {
                get;
                set;
            }

            public string aciklama
            {
                get;
                set;
            }

            public string XXXXXXSonucTanisi
            {
                get;
                set;
            }

            public string sosyalGuvenlikKurumu
            {
                get;
                set;
            }

            public string sosyalGuvenlikNo
            {
                get;
                set;
            }

            public string tcKimlikNo
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage VakaSonlandirmaMetoduASync(VakaSonlandirmaMetoduASyncInput input)
        {
            var result = Acil112Servis.WebMethods.VakaSonlandirmaMetoduASync(input.siteID, input.callerObject, input.webServisUri, input.userName1, input.userPassword1, input.protokolNo, input.tarih, input.hastaKabulTarihi, input.hastaAyrilisTarihi, input.vakaSonuc, input.aciklama, input.XXXXXXSonucTanisi, input.sosyalGuvenlikKurumu, input.sosyalGuvenlikNo, input.tcKimlikNo);
            return result;
        }

        public class NobetciPersonelGondermeMetoduSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public NobetciPersonelBilgileri nobetci
            {
                get;
                set;
            }
        }

        public int NobetciPersonelGondermeMetoduSync(NobetciPersonelGondermeMetoduSyncInput input)
        {
            var result = Acil112Servis.WebMethods.NobetciPersonelGondermeMetoduSync(input.siteID, input.webServisUri, input.nobetci);
            return result;
        }

        public class NobetciPersonelGonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public object personelListesi
            {
                get;
                set;
            }
        }

        public int NobetciPersonelGonderSync(NobetciPersonelGonderSyncInput input)
        {
            throw new NotSupportedException();
        }

        public class ProtokolDetaylariDonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public string sene
            {
                get;
                set;
            }

            public string hastaAdiSoyadi
            {
                get;
                set;
            }

            public string TCKimlikNo
            {
                get;
                set;
            }
        }

        public int ProtokolDetaylariDonderSync(ProtokolDetaylariDonderSyncInput input)
        {
            var result = Acil112Servis.WebMethods.ProtokolDetaylariDonderSync(input.siteID, input.webServisUri, input.protokolNo, input.sene, input.hastaAdiSoyadi, input.TCKimlikNo);
            return result;
        }

        public class ServiceTestSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }
        }

        public string ServiceTestSync(ServiceTestSyncInput input)
        {
            var result = Acil112Servis.WebMethods.ServiceTestSync(input.siteID, input.webServisUri);
            return result;
        }

        public class SonlandirilmamisVakalarListesiDetayliSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public VakaBilgileri[] acikVakalar
            {
                get;
                set;
            }
        }

        public int SonlandirilmamisVakalarListesiDetayliSync(SonlandirilmamisVakalarListesiDetayliSyncInput input)
        {
            var result = Acil112Servis.WebMethods.SonlandirilmamisVakalarListesiDetayliSync(input.siteID, input.webServisUri, input.acikVakalar);
            return result;
        }

        public class SonlandirilmamisVakalarListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public int[] protokoller
            {
                get;
                set;
            }
        }

        public int SonlandirilmamisVakalarListesiSync(SonlandirilmamisVakalarListesiSyncInput input)
        {
            var result = Acil112Servis.WebMethods.SonlandirilmamisVakalarListesiSync(input.siteID, input.webServisUri, input.protokoller);
            return result;
        }

        public class SosyalGuvenceKodlariDonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string[] kurumKodlari
            {
                get;
                set;
            }
        }

        public int SosyalGuvenceKodlariDonderSync(SosyalGuvenceKodlariDonderSyncInput input)
        {
            var result = Acil112Servis.WebMethods.SosyalGuvenceKodlariDonderSync(input.siteID, input.webServisUri, input.kurumKodlari);
            return result;
        }

        public class VakaGuncellemeMetoduSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public string tarih
            {
                get;
                set;
            }

            public string XXXXXXKabulTarihi
            {
                get;
                set;
            }

            public string aciklama
            {
                get;
                set;
            }

            public string ip
            {
                get;
                set;
            }
        }

        public int VakaGuncellemeMetoduSync(VakaGuncellemeMetoduSyncInput input)
        {
            var result = Acil112Servis.WebMethods.VakaGuncellemeMetoduSync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.protokolNo, input.tarih, input.XXXXXXKabulTarihi, input.aciklama, input.ip);
            return result;
        }

        public class VakaSonlandirmaMetoduSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public string protokolNo
            {
                get;
                set;
            }

            public string tarih
            {
                get;
                set;
            }

            public string hastaKabulTarihi
            {
                get;
                set;
            }

            public string hastaAyrilisTarihi
            {
                get;
                set;
            }

            public string vakaSonuc
            {
                get;
                set;
            }

            public string aciklama
            {
                get;
                set;
            }

            public string XXXXXXSonucTanisi
            {
                get;
                set;
            }

            public string sosyalGuvenlikKurumu
            {
                get;
                set;
            }

            public string sosyalGuvenlikNo
            {
                get;
                set;
            }

            public string tcKimlikNo
            {
                get;
                set;
            }
        }

        public int VakaSonlandirmaMetoduSync(VakaSonlandirmaMetoduSyncInput input)
        {
            var result = Acil112Servis.WebMethods.VakaSonlandirmaMetoduSync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.protokolNo, input.tarih, input.hastaKabulTarihi, input.hastaAyrilisTarihi, input.vakaSonuc, input.aciklama, input.XXXXXXSonucTanisi, input.sosyalGuvenlikKurumu, input.sosyalGuvenlikNo, input.tcKimlikNo);
            return result;
        }

        public class AdetleriGonder_ArraySyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public BolumBilgisi[] bolumler
            {
                get;
                set;
            }

            public string ipAddr
            {
                get;
                set;
            }
        }

        public int AdetleriGonder_ArraySync(AdetleriGonder_ArraySyncInput input)
        {
            var result = Acil112Servis.WebMethods.AdetleriGonder_ArraySync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.bolumler, input.ipAddr);
            return result;
        }

        public class AdetleriGonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public BolumBilgileri acilEriskin
            {
                get;
                set;
            }

            public BolumBilgileri acilCocuk
            {
                get;
                set;
            }

            public BolumBilgileri ybKoroner
            {
                get;
                set;
            }

            public BolumBilgileri ybKalpDamar
            {
                get;
                set;
            }

            public BolumBilgileri ybAnestezi
            {
                get;
                set;
            }

            public BolumBilgileri ybNoroloji
            {
                get;
                set;
            }

            public BolumBilgileri ybBeyinCerrahi
            {
                get;
                set;
            }

            public BolumBilgileri ybGenelCerrahi
            {
                get;
                set;
            }

            public BolumBilgileri ybDahiliye
            {
                get;
                set;
            }

            public BolumBilgileri ybGogusHastaliklari
            {
                get;
                set;
            }

            public BolumBilgileri ybKadinDogum
            {
                get;
                set;
            }

            public BolumBilgileri ybPediatri
            {
                get;
                set;
            }

            public BolumBilgileri ybYenidogan
            {
                get;
                set;
            }

            public BolumBilgileri ybYanik
            {
                get;
                set;
            }

            public BolumBilgileri srvPediatri
            {
                get;
                set;
            }

            public BolumBilgileri srvDahiliye
            {
                get;
                set;
            }

            public BolumBilgileri srvKalpDamar
            {
                get;
                set;
            }

            public BolumBilgileri srvKadinDogum
            {
                get;
                set;
            }

            public BolumBilgileri srvGenelCerrahi
            {
                get;
                set;
            }

            public BolumBilgileri srvOrtopedi
            {
                get;
                set;
            }

            public BolumBilgileri srvKalpDamarCerrahi
            {
                get;
                set;
            }

            public BolumBilgileri srvBeyinCerrahi
            {
                get;
                set;
            }

            public BolumBilgileri srvYenidogan
            {
                get;
                set;
            }

            public BolumBilgileri srvDializ
            {
                get;
                set;
            }

            public BolumBilgileri srvDiger
            {
                get;
                set;
            }

            public BolumBilgileri ameliyathane
            {
                get;
                set;
            }

            public BolumBilgileri morg
            {
                get;
                set;
            }

            public string ipAddr
            {
                get;
                set;
            }
        }

        public int AdetleriGonderSync(AdetleriGonderSyncInput input)
        {
            var result = Acil112Servis.WebMethods.AdetleriGonderSync(input.siteID, input.webServisUri, input.acilEriskin, input.acilCocuk, input.ybKoroner, input.ybKalpDamar, input.ybAnestezi, input.ybNoroloji, input.ybBeyinCerrahi, input.ybGenelCerrahi, input.ybDahiliye, input.ybGogusHastaliklari, input.ybKadinDogum, input.ybPediatri, input.ybYenidogan, input.ybYanik, input.srvPediatri, input.srvDahiliye, input.srvKalpDamar, input.srvKadinDogum, input.srvGenelCerrahi, input.srvOrtopedi, input.srvKalpDamarCerrahi, input.srvBeyinCerrahi, input.srvYenidogan, input.srvDializ, input.srvDiger, input.ameliyathane, input.morg, input.ipAddr);
            return result;
        }

        public class EUYSTaniGonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public HastaBilgileri hasta
            {
                get;
                set;
            }

            public string ICD10Kodu
            {
                get;
                set;
            }
        }

        public int EUYSTaniGonderSync(EUYSTaniGonderSyncInput input)
        {
            var result = Acil112Servis.WebMethods.EUYSTaniGonderSync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.hasta, input.ICD10Kodu);
            return result;
        }

        public class GetVersionNoSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }
        }

        public string GetVersionNoSync(GetVersionNoSyncInput input)
        {
            var result = Acil112Servis.WebMethods.GetVersionNoSync(input.siteID, input.webServisUri);
            return result;
        }

        public class XXXXXXPersoneliniDonderSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public TTUtils.TTWebServiceUri webServisUri
            {
                get;
                set;
            }

            public string userName1
            {
                get;
                set;
            }

            public string userPassword1
            {
                get;
                set;
            }

            public PersonelBilgileri[] personelListesi
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public int XXXXXXPersoneliniDonderSync(XXXXXXPersoneliniDonderSyncInput input)
        {
            var result = Acil112Servis.WebMethods.XXXXXXPersoneliniDonderSync(input.siteID, input.webServisUri, input.userName1, input.userPassword1, input.personelListesi);
            return result;
        }
    }
}