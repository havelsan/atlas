//$370F0C95
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.MkysServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class MkysServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public MkysServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class saglik_Calisani_MiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string kisiTCKimlikNo
            {
                get;
                set;
            }
        }

        public string saglik_Calisani_MiSync(saglik_Calisani_MiSyncInput input)
        {
            var result = MkysServis.WebMethods.saglik_Calisani_MiSync(input.siteID, input.kisiTCKimlikNo);
            return result;
        }

        public class universiteXXXXXXleriGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public universiteXXXXXXleriSonucItem[] universiteXXXXXXleriGetDataSync(universiteXXXXXXleriGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.universiteXXXXXXleriGetDataSync(input.siteID);
            return result;
        }

        public class tibbiCihazTeknikOzellikInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public teknikOzellikInsertItem[] item
            {
                get;
                set;
            }

            public int birimDepoID
            {
                get;
                set;
            }
        }

        public malzemeTeknikOzellikResult tibbiCihazTeknikOzellikInsertSync(tibbiCihazTeknikOzellikInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.tibbiCihazTeknikOzellikInsertSync(input.siteID, input.item, input.birimDepoID);
            return result;
        }

        public class devirGerceklestiIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public devirGerceklestiYapItem[] devirListesi
            {
                get;
                set;
            }
        }

        public devirGerceklestiriciSonuc devirGerceklestiIptalSync(devirGerceklestiIptalSyncInput input)
        {
            var result = MkysServis.WebMethods.devirGerceklestiIptalSync(input.siteID, input.devirListesi);
            return result;
        }

        public class zimmetListesiDetayGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public zimmetListesiGetItem item
            {
                get;
                set;
            }
        }

        public zimmetListesiGetDataResultItem[] zimmetListesiDetayGetDataSync(zimmetListesiDetayGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.zimmetListesiDetayGetDataSync(input.siteID, input.item);
            return result;
        }

        public class servisYetkiKontrolSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public yetkiKontrolSonuc servisYetkiKontrolSync(servisYetkiKontrolSyncInput input)
        {
            var result = MkysServis.WebMethods.servisYetkiKontrolSync(input.siteID);
            return result;
        }

        public class ihaleTarihiVeNumarasiUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ihaleTarihiUpdateInsertItem item
            {
                get;
                set;
            }
        }

        public ihaleTarihiUpdateResult ihaleTarihiVeNumarasiUpdateSync(ihaleTarihiVeNumarasiUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.ihaleTarihiVeNumarasiUpdateSync(input.siteID, input.item);
            return result;
        }

        public class ntKodGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public ntKodItem[] ntKodGetDataSync(ntKodGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.ntKodGetDataSync(input.siteID);
            return result;
        }

        public class devirBirimleriGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string ilKodu
            {
                get;
                set;
            }

            public int bagliOlduguBirimKodu
            {
                get;
                set;
            }
        }

        public birimItem[] devirBirimleriGetDataSync(devirBirimleriGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.devirBirimleriGetDataSync(input.siteID, input.ilKodu, input.bagliOlduguBirimKodu);
            return result;
        }

        public class disKurumlarListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string ilKodu
            {
                get;
                set;
            }

            public int bagliOlduguBirimKodu
            {
                get;
                set;
            }
        }

        public birimItem[] disKurumlarListesiSync(disKurumlarListesiSyncInput input)
        {
            var result = MkysServis.WebMethods.disKurumlarListesiSync(input.siteID, input.ilKodu, input.bagliOlduguBirimKodu);
            return result;
        }

        public class birimDepoGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public birimDepoItem[] birimDepoGetDataSync(birimDepoGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.birimDepoGetDataSync(input.siteID);
            return result;
        }

        public class depoInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public depoInsertItem insertItem
            {
                get;
                set;
            }
        }

        public depoKayitIslemleriSonuc depoInsertSync(depoInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.depoInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class depoUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public depoUpdateItem updateItem
            {
                get;
                set;
            }
        }

        public depoKayitIslemleriSonuc depoUpdateSync(depoUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.depoUpdateSync(input.siteID, input.updateItem);
            return result;
        }

        public class makbuzInsertGirisSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public makbuzInsertGirisItem insertItem
            {
                get;
                set;
            }
        }

        public makbuzInsertGirisSonuc makbuzInsertGirisSync(makbuzInsertGirisSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzInsertGirisSync(input.siteID, Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, input.insertItem);
            return result;
        }

        public class makbuzInsertCikisSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public makbuzInsertCikisItem insertItem
            {
                get;
                set;
            }
        }

        public makbuzInsertCikisSonuc makbuzInsertCikisSync(makbuzInsertCikisSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzInsertCikisSync(input.siteID, Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, input.insertItem);
            return result;
        }

        public class makbuzDetayInsertGirisSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public makbuzDetayInsertGirisItem insertItem
            {
                get;
                set;
            }
        }

        public makbuzDetayInsertGirisSonuc makbuzDetayInsertGirisSync(makbuzDetayInsertGirisSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzDetayInsertGirisSync(input.siteID, input.insertItem);
            return result;
        }

        public class girisMakbuzDeleteSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }
        }

        //public makbuzSilmeSonuc girisMakbuzDeleteSync(girisMakbuzDeleteSyncInput input)
        //{
        //    var result = MkysServis.WebMethods.girisMakbuzDeleteSync(input.siteID, input.ayniyatMakbuzID);
        //    return result;
        //}

        public class girisMakbuzIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }
        }

        public makbuzIptalSonuc girisMakbuzIptalSync(girisMakbuzIptalSyncInput input)
        {
            var result = MkysServis.WebMethods.girisMakbuzIptalSync(input.siteID, input.ayniyatMakbuzID);
            return result;
        }

        public class cikisMakbuzDeleteSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int islemKayitNo
            {
                get;
                set;
            }
        }

        //public makbuzSilmeSonuc cikisMakbuzDeleteSync(cikisMakbuzDeleteSyncInput input)
        //{
        //    var result = MkysServis.WebMethods.cikisMakbuzDeleteSync(input.siteID, input.islemKayitNo);
        //    return result;
        //}

        public class stokHareketDeleteSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }
        }

        public stokHareketSilSonuc stokHareketDeleteSync(stokHareketDeleteSyncInput input)
        {
            var result = MkysServis.WebMethods.stokHareketDeleteSync(input.siteID, input.stokHareketID);
            return result;
        }

        public class birimGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public birimItem[] birimGetDataSync(birimGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.birimGetDataSync(input.siteID);
            return result;
        }

        public class birimInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public birimInsertItem insertItem
            {
                get;
                set;
            }
        }

        public birimKayitIslemleriSonuc birimInsertSync(birimInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.birimInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class birimUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public birimUpdateItem updateItem
            {
                get;
                set;
            }
        }

        public birimKayitIslemleriSonuc birimUpdateSync(birimUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.birimUpdateSync(input.siteID, input.updateItem);
            return result;
        }

        public class tumBirimlerGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string birimAdi
            {
                get;
                set;
            }
        }

        public birimItem[] tumBirimlerGetDataSync(tumBirimlerGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.tumBirimlerGetDataSync(input.siteID, input.birimAdi);
            return result;
        }

        public class kurumlardanGelenDevirlerGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kurumlardanGelenDevirKriter kriter
            {
                get;
                set;
            }
        }

        public kurumlardanGelenDevirItem[] kurumlardanGelenDevirlerGetDataSync(kurumlardanGelenDevirlerGetDataSyncInput input)
        {
            string username = Common.CurrentResource.MkysUserName;
            string password = Common.CurrentResource.MkysPassword;
            var result = MkysServis.WebMethods.kurumlardanGelenDevirlerGetDataSync(input.siteID, username, password, input.kriter);
            return result;
        }

        public class malzemeGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime gunlemeTarihi
            {
                get;
                set;
            }
        }

        public malzemeItem[] malzemeGetDataSync(malzemeGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemeGetDataSync(input.siteID, input.gunlemeTarihi);
            return result;
        }

        public class malzemetibbiSarfGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime degisiklikTarihi
            {
                get;
                set;
            }
            public string MKYSUserName { get; set; }
            public string MKYSUserPassword { get; set; }
        }

        public malzemeTibbiSarfItem[] malzemetibbiSarfGetDataSync(malzemetibbiSarfGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemetibbiSarfGetDataSync(input.siteID,input.MKYSUserName,input.MKYSUserPassword, input.degisiklikTarihi);
            return result;
        }

        public class malzemeSiniflandirmaGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime degisiklikTarihi
            {
                get;
                set;
            }

            public EDepoTurId depoTuru
            {
                get;
                set;
            }
        }

        public malzemeSiniflandirmaItem[] malzemeSiniflandirmaGetDataSync(malzemeSiniflandirmaGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemeSiniflandirmaGetDataSync(input.siteID, input.degisiklikTarihi, input.depoTuru);
            return result;
        }

        public class devirFisiGetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int islemKayitNo
            {
                get;
                set;
            }
        }

        public devirFisiItem[] devirFisiGetSync(devirFisiGetSyncInput input)
        {
            var result = MkysServis.WebMethods.devirFisiGetSync(Sites.SiteLocalHost, "", "", input.islemKayitNo);
            //var result = MkysServis.WebMethods.devirFisiGetSync(input.siteID, input.islemKayitNo);
            return result;
        }

        public class devirGerceklestiYapSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public devirGerceklestiYapItem[] devirListesi
            {
                get;
                set;
            }
        }

        public devirGerceklestiriciSonuc devirGerceklestiYapSync(devirGerceklestiYapSyncInput input)
        {
            var result = MkysServis.WebMethods.devirGerceklestiYapSync(input.siteID, input.devirListesi);
            return result;
        }

        public class ihtiyacFazlasiInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ihtiyacFazlasiInsertItem insertItem
            {
                get;
                set;
            }
        }

        public ihtiyacFazlasiSonuc ihtiyacFazlasiInsertSync(ihtiyacFazlasiInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.ihtiyacFazlasiInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class ihtiyacFazlasiIadeSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ihtiyacFazlasiIadeItem iadeItem
            {
                get;
                set;
            }
        }

        public ihtiyacFazlasiSonuc ihtiyacFazlasiIadeSync(ihtiyacFazlasiIadeSyncInput input)
        {
            var result = MkysServis.WebMethods.ihtiyacFazlasiIadeSync(input.siteID, input.iadeItem);
            return result;
        }

        public class stokHareketGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public stokHareketKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketItem[] stokHareketGetDataSync(stokHareketGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.stokHareketGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class makbuzVarMiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }
        }

        public makbuzKontrolSonuc makbuzVarMiSync(makbuzVarMiSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzVarMiSync(input.siteID, input.ayniyatMakbuzID);
            return result;
        }

        public class kisiVarMiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string kisiTCKimlikNo
            {
                get;
                set;
            }
        }

        public kisiKontrolSonuc kisiVarMiSync(kisiVarMiSyncInput input)
        {
            var result = MkysServis.WebMethods.kisiVarMiSync(input.siteID, input.kisiTCKimlikNo);
            return result;
        }

        public class kisiInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kisiInsertItem insertItem
            {
                get;
                set;
            }
        }

        public kisiInsertSonuc kisiInsertSync(kisiInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.kisiInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class makbuzSelectSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }
        }

        public girisMakbuzItem makbuzSelectSync(makbuzSelectSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzSelectSync(input.siteID, input.ayniyatMakbuzID);
            return result;
        }

        public class depoGirisMakbuzGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public depoGirisMakbuzGetKriter kriter
            {
                get;
                set;
            }
        }

        public girisMakbuzItem[] depoGirisMakbuzGetDataSync(depoGirisMakbuzGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.depoGirisMakbuzGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class depoCikisMakbuzGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public cikisFisleriKriter kriter
            {
                get;
                set;
            }
        }

        public cikisFisiItem[] depoCikisMakbuzGetDataSync(depoCikisMakbuzGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.depoCikisMakbuzGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class cikisFisGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public cikisFisleriKriter kriter
            {
                get;
                set;
            }
        }

        public cikisFisiItem[] cikisFisGetDataSync(cikisFisGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.cikisFisGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class makbuzDetayGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }

            public int butceYili
            {
                get;
                set;
            }

            public EButceTurID butceTuru
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        public girisMakbuzDetayItem[] makbuzDetayGetDataSync(makbuzDetayGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzDetayGetDataSync(input.siteID, Common.CurrentResource.MkysUserName, input.mkysPwd, input.ayniyatMakbuzID, input.butceYili, input.butceTuru);
            return result;
        }

        public class cikisFisDetayGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int islemKayitNo
            {
                get;
                set;
            }
            public string mkysPwd { get; set; }
        }

        public cikisFisDetayItem[] cikisFisDetayGetDataSync(cikisFisDetayGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.cikisFisDetayGetDataSync(input.siteID, Common.CurrentResource.MkysUserName, input.mkysPwd, input.islemKayitNo);
            return result;
        }

        public class aracInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public aracInsertItem insertItem
            {
                get;
                set;
            }
        }

        public aracInsertSonuc aracInsertSync(aracInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.aracInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class degerArtisiInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public degerArtisiInsertItem insertItem
            {
                get;
                set;
            }
        }

        public degerArtisiSonuc degerArtisiInsertSync(degerArtisiInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.degerArtisiInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class demirbaslariDevretSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public demirbasDevirItem insertItem
            {
                get;
                set;
            }
        }

        public demirbasDevirSonuc demirbaslariDevretSync(demirbaslariDevretSyncInput input)
        {
            var result = MkysServis.WebMethods.demirbaslariDevretSync(input.siteID, input.insertItem);
            return result;
        }

        public class kayittanDusmeInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kayittanDusmeInsertItem insertItem
            {
                get;
                set;
            }
        }

        public kayittanDusmeSonuc kayittanDusmeInsertSync(kayittanDusmeInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.kayittanDusmeInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class kitapInsertUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public kitapInsertUpdateItem insertUpdateItem
            {
                get;
                set;
            }
        }

        public kitapInsertUpdateSonuc kitapInsertUpdateSync(kitapInsertUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.kitapInsertUpdateSync(input.siteID, input.insertUpdateItem);
            return result;
        }

        public class girisStokHareketGetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int makbuzDetayID
            {
                get;
                set;
            }

            public int butceYili
            {
                get;
                set;
            }

            public EButceTurID butceTuru
            {
                get;
                set;
            }
        }

        public stokHareketItem[] girisStokHareketGetSync(girisStokHareketGetSyncInput input)
        {
            var result = MkysServis.WebMethods.girisStokHareketGetSync(input.siteID, input.makbuzDetayID, input.butceYili, input.butceTuru);
            return result;
        }

        public class zimmetInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public zimmetInsertItem insertItem
            {
                get;
                set;
            }
        }

        public zimmetInsertSonuc zimmetInsertSync(zimmetInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.zimmetInsertSync(input.siteID, input.insertItem);
            return result;
        }

        public class zimmettenAlSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public zimmettenAlInsertItem insertItem
            {
                get;
                set;
            }
        }

        public zimmettenAlSonuc zimmettenAlSync(zimmettenAlSyncInput input)
        {
            var result = MkysServis.WebMethods.zimmettenAlSync(input.siteID, input.insertItem);
            return result;
        }

        public class zimmetListesiGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public zimmetItem[] zimmetListesiGetDataSync(zimmetListesiGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.zimmetListesiGetDataSync(input.siteID);
            return result;
        }

        public class ihtiyacFazlasiGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ihtiyacFazlasiKriterItem kriter
            {
                get;
                set;
            }
        }

        public ihtiyacFazlasiItem[] ihtiyacFazlasiGetDataSync(ihtiyacFazlasiGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.ihtiyacFazlasiGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class firmaSifreDegistirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string kullaniciAdi
            {
                get;
                set;
            }

            public string eskiSifre
            {
                get;
                set;
            }

            public string yeniSifre
            {
                get;
                set;
            }
        }

        public sifreDegistirSonuc firmaSifreDegistirSync(firmaSifreDegistirSyncInput input)
        {
            var result = MkysServis.WebMethods.firmaSifreDegistirSync(input.siteID, input.kullaniciAdi, input.eskiSifre, input.yeniSifre);
            return result;
        }

        public class girisMakbuzundanCikisYapilmisMi2SyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }
        }

        public cikisKontrolSonuc girisMakbuzundanCikisYapilmisMi2Sync(girisMakbuzundanCikisYapilmisMi2SyncInput input)
        {
            var result = MkysServis.WebMethods.girisMakbuzundanCikisYapilmisMi2Sync(input.siteID, input.stokHareketID);
            return result;
        }

        public class girisMakbuzundanCikisYapilmisMiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }
        }

        public cikisKontrolSonuc girisMakbuzundanCikisYapilmisMiSync(girisMakbuzundanCikisYapilmisMiSyncInput input)
        {
            var result = MkysServis.WebMethods.girisMakbuzundanCikisYapilmisMiSync(input.siteID, input.ayniyatMakbuzID);
            return result;
        }

        public class stokSeviyesiInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public stokSeviyesiInsertItem item
            {
                get;
                set;
            }
        }

        public stokSeviyesiInsertSonuc stokSeviyesiInsertSync(stokSeviyesiInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.stokSeviyesiInsertSync(input.siteID, input.item);
            return result;
        }

        public class aracModelGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string markaID
            {
                get;
                set;
            }
        }

        public aracModelItem[] aracModelGetDataSync(aracModelGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.aracModelGetDataSync(input.siteID, input.markaID);
            return result;
        }

        public class depoYetkiKontrolSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public depoYetkiKontrolItem kontrol
            {
                get;
                set;
            }
        }

        public depoYetkiKontrolSonuc depoYetkiKontrolSync(depoYetkiKontrolSyncInput input)
        {
            var result = MkysServis.WebMethods.depoYetkiKontrolSync(input.siteID, input.kontrol);
            return result;
        }

        public class cikisFisiVarMiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int islemKayitNo
            {
                get;
                set;
            }

            public string hbysID
            {
                get;
                set;
            }
        }

        public bool cikisFisiVarMiSync(cikisFisiVarMiSyncInput input)
        {
            var result = MkysServis.WebMethods.cikisFisiVarMiSync(input.siteID, input.islemKayitNo, input.hbysID);
            return result;
        }

        public class stokHareketUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public stokHareketUpdateItem[] stok
            {
                get;
                set;
            }
            public string MKYSUserName { get; set; }
            public string MKYSUserPassword { get; set; }
        }

        public mkysSonuc stokHareketUpdateSync(stokHareketUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.stokHareketUpdateSync(input.siteID, input.MKYSUserName, input.MKYSUserPassword, input.stok);
            return result;
        }

        public class unvanTurGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string unvanAdi
            {
                get;
                set;
            }
        }

        public unvanTurItem[] unvanTurGetDataSync(unvanTurGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.unvanTurGetDataSync(input.siteID, input.unvanAdi);
            return result;
        }

        public class firmaBilgileriGetVergiNoSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string firmaVergiNo
            {
                get;
                set;
            }
        }

        public firmaBilgileriGetVergiNoSonuc[] firmaBilgileriGetVergiNoSync(firmaBilgileriGetVergiNoSyncInput input)
        {
            var result = MkysServis.WebMethods.firmaBilgileriGetVergiNoSync(input.siteID, input.firmaVergiNo);
            return result;
        }

        public class firmaBilgileriGetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int firmaKodu
            {
                get;
                set;
            }
        }

        public firmaBilgileriGetItem[] firmaBilgileriGetSync(firmaBilgileriGetSyncInput input)
        {
            var result = MkysServis.WebMethods.firmaBilgileriGetSync(input.siteID, input.firmaKodu);
            return result;
        }

        public class eksiBakiyeStoklarGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] eksiBakiyeStoklarGetDataSync(eksiBakiyeStoklarGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.eksiBakiyeStoklarGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class fiyatiFarkliOlanStoklarGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] fiyatiFarkliOlanStoklarGetDataSync(fiyatiFarkliOlanStoklarGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.fiyatiFarkliOlanStoklarGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class butceTuruFarkliOlanStoklarGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] butceTuruFarkliOlanStoklarGetDataSync(butceTuruFarkliOlanStoklarGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.butceTuruFarkliOlanStoklarGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class deposuFarkliOlanStoklarGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] deposuFarkliOlanStoklarGetDataSync(deposuFarkliOlanStoklarGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.deposuFarkliOlanStoklarGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class malzemeIDFarkliStoklarGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] malzemeIDFarkliStoklarGetDataSync(malzemeIDFarkliStoklarGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemeIDFarkliStoklarGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class stokDurumGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuKriter kriter
            {
                get;
                set;
            }
        }

        public stokHareketYilSonuItem[] stokDurumGetDataSync(stokDurumGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.stokDurumGetDataSync(input.siteID, input.kriter);
            return result;
        }

        public class stokHareketLogGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }
        }

        public stokHareketLogItem[] stokHareketLogGetDataSync(stokHareketLogGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.stokHareketLogGetDataSync(input.siteID, input.stokHareketID);
            return result;
        }

        public class barkodUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }

            public string barkod
            {
                get;
                set;
            }
        }

        public mkysSonuc barkodUpdateSync(barkodUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.barkodUpdateSync(input.siteID, input.stokHareketID, input.barkod);
            return result;
        }

        public class makbuzUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ayniyatMakbuzuUpdateItem[] makbuz
            {
                get;
                set;
            }
            public string MKYSUserName { get; set; }
            public string MKYSUserPassword { get; set; }
        }

        public mkysSonuc makbuzUpdateSync(makbuzUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.makbuzUpdateSync(input.siteID, input.MKYSUserName, input.MKYSUserPassword, input.makbuz);
            return result;
        }

        public class yonetimHesabiCetveliGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yonetimHesabiKriter kriter
            {
                get;
                set;
            }
            public string MKYSUserName { get; set; }
            public string MKYSUserPassword { get; set; }
        }

        public yonetimHesabiCetveliItem[] yonetimHesabiCetveliGetDataSync(yonetimHesabiCetveliGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.yonetimHesabiCetveliGetDataSync(input.siteID,input.MKYSUserName,input.MKYSUserPassword, input.kriter);
            return result;
        }

        public class ilacSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string barkod
            {
                get;
                set;
            }

            public string ilacAdi
            {
                get;
                set;
            }
        }

        public ilacSorgulamaSonuc ilacSorgulaSync(ilacSorgulaSyncInput input)
        {
            var result = MkysServis.WebMethods.ilacSorgulaSync(input.siteID, input.barkod, input.ilacAdi);
            return result;
        }

        public class mukerrerCikisGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int butceYili
            {
                get;
                set;
            }

            public int depoKayitNo
            {
                get;
                set;
            }

            public string butceTurID
            {
                get;
                set;
            }
        }

        public mukerrerStokHareketItem[] mukerrerCikisGetDataSync(mukerrerCikisGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.mukerrerCikisGetDataSync(input.siteID, input.butceYili, input.depoKayitNo, input.butceTurID);
            return result;
        }

        public class stokTedarikTuruUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniyatMakbuzID
            {
                get;
                set;
            }

            public ETedarikTurID tedarikTuru
            {
                get;
                set;
            }

            public EGirisStokHareketTurID stokHareketTuru
            {
                get;
                set;
            }
        }

        public mkysSonuc stokTedarikTuruUpdateSync(stokTedarikTuruUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.stokTedarikTuruUpdateSync(input.siteID, input.ayniyatMakbuzID, input.tedarikTuru, input.stokHareketTuru);
            return result;
        }

        public class girisiOlmayanCikislarSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int birimKayitID
            {
                get;
                set;
            }

            public int butceYili
            {
                get;
                set;
            }

            public int depoKayitNo
            {
                get;
                set;
            }

            public string butceTurID
            {
                get;
                set;
            }

            public string tasinirKodu
            {
                get;
                set;
            }
        }

        public girisiOlmayanCikislarItem[] girisiOlmayanCikislarSync(girisiOlmayanCikislarSyncInput input)
        {
            var result = MkysServis.WebMethods.girisiOlmayanCikislarSync(input.siteID, input.birimKayitID, input.butceYili, input.depoKayitNo, input.butceTurID, input.tasinirKodu);
            return result;
        }

        public class firmaBilgileriGetTumuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public firmaBilgileriGetTumuSonuc[] firmaBilgileriGetTumuSync(firmaBilgileriGetTumuSyncInput input)
        {
            var result = MkysServis.WebMethods.firmaBilgileriGetTumuSync(input.siteID);
            return result;
        }

        public class malzemeBilgileriUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public malzemeBilgileriUpdateItem[] item
            {
                get;
                set;
            }
        }

        public mkysSonuc malzemeBilgileriUpdateSync(malzemeBilgileriUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemeBilgileriUpdateSync(input.siteID, input.item);
            return result;
        }

        public class sonKullanmaTarihiUpdateSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sonKullanmaUpdateInsertItem insertItem
            {
                get;
                set;
            }
        }

        public mkysSonuc sonKullanmaTarihiUpdateSync(sonKullanmaTarihiUpdateSyncInput input)
        {
            var result = MkysServis.WebMethods.sonKullanmaTarihiUpdateSync(input.siteID, Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, input.insertItem);
            return result;
        }

        public class birimBilgileriGetiriciSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int birimKayitID
            {
                get;
                set;
            }
        }

        public birimItem[] birimBilgileriGetiriciSync(birimBilgileriGetiriciSyncInput input)
        {
            var result = MkysServis.WebMethods.birimBilgileriGetiriciSync(input.siteID, input.birimKayitID);
            return result;
        }

        public class stokHareketGirisLogGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ayniatMakbuzID
            {
                get;
                set;
            }
        }

        public stokHareketLogItem[] stokHareketGirisLogGetDataSync(stokHareketGirisLogGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.stokHareketGirisLogGetDataSync(input.siteID, Common.CurrentResource.MkysUserName, Common.CurrentResource.MkysPassword, input.ayniatMakbuzID);
            return result;
        }

        public class amortismanInsertSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public amortismanInsertItem item
            {
                get;
                set;
            }
        }

        public amortismanInsertSonuc amortismanInsertSync(amortismanInsertSyncInput input)
        {
            var result = MkysServis.WebMethods.amortismanInsertSync(input.siteID, input.item);
            return result;
        }

        public class guncelMalzemeGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime guncellemeTarihi
            {
                get;
                set;
            }
        }

        public malzemeItem[] guncelMalzemeGetDataSync(guncelMalzemeGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.guncelMalzemeGetDataSync(input.siteID, input.guncellemeTarihi);
            return result;
        }

        public class demirbasGetDataSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int depoKayitNo
            {
                get;
                set;
            }

            public int butceyili
            {
                get;
                set;
            }
        }

        public demirbasGetDataResult[] demirbasGetDataSync(demirbasGetDataSyncInput input)
        {
            var result = MkysServis.WebMethods.demirbasGetDataSync(input.siteID, input.depoKayitNo, input.butceyili);
            return result;
        }

        public class malzemeZimmetBilgisiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int depoKayitNo
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }

            public int butceYili
            {
                get;
                set;
            }
        }

        public malzemeZimmetBilgisiResult[] malzemeZimmetBilgisiSync(malzemeZimmetBilgisiSyncInput input)
        {
            var result = MkysServis.WebMethods.malzemeZimmetBilgisiSync(input.siteID, input.depoKayitNo, input.stokHareketID, input.butceYili);
            return result;
        }

        public class giriseAitCikislarSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int stokHareketID
            {
                get;
                set;
            }
        }

        public giriseAitCikislarResultItem[] giriseAitCikislarSync(giriseAitCikislarSyncInput input)
        {
            var result = MkysServis.WebMethods.giriseAitCikislarSync(input.siteID, input.stokHareketID);
            return result;
        }

        public class yilSonuDevirDetayBilgileriSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yilSonuDevriItem item
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public yilSonuDevriSonucItem[] yilSonuDevirDetayBilgileriSync(yilSonuDevirDetayBilgileriSyncInput input)
        {
            var result = MkysServis.WebMethods.yilSonuDevirDetayBilgileriSync(input.siteID, input.item);
            return result;
        }
    }
}