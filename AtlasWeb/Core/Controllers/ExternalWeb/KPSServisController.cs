//$89EC4DE0
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.KPSServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class KPSServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public KPSServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ServisUTCZamaniSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public DateTime ServisUTCZamaniSync(ServisUTCZamaniSyncInput input)
        {
            var result = KPSServis.WebMethods.ServisUTCZamaniSync(input.siteID);
            return result;
        }

        public class IstekIpAdresSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public string IstekIpAdresSync(IstekIpAdresSyncInput input)
        {
            var result = KPSServis.WebMethods.IstekIpAdresSync(input.siteID);
            return result;
        }

        public class KullanilabilirMetodListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public string[] KullanilabilirMetodListesiSync(KullanilabilirMetodListesiSyncInput input)
        {
            var result = KPSServis.WebMethods.KullanilabilirMetodListesiSync(input.siteID);
            return result;
        }

        public class IlListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public KPSServisSonucuArrayOfIl IlListesiSync(IlListesiSyncInput input)
        {
            var result = KPSServis.WebMethods.IlListesiSync(input.siteID);
            return result;
        }

        public class IleAitIlceistesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public int ilKod
            {
                get;
                set;
            }
        }

        public KPSServisSonucuArrayOfIlce IleAitIlceistesiSync(IleAitIlceistesiSyncInput input)
        {
            var result = KPSServis.WebMethods.IleAitIlceistesiSync(input.siteID, input.ilKod);
            return result;
        }

        public class TcKimlikNoIleKisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiTemelBilgisi TcKimlikNoIleKisiSorgulaSync(TcKimlikNoIleKisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleKisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string ad
            {
                get;
                set;
            }

            public string soyad
            {
                get;
                set;
            }

            public string babaAdi
            {
                get;
                set;
            }

            public string anaAdi
            {
                get;
                set;
            }

            public string dogumYeri
            {
                get;
                set;
            }

            public string dogumTarihi
            {
                get;
                set;
            }

            public string cinsiyet
            {
                get;
                set;
            }
        }

        public KPSServisSonucuArrayOfKisiTemelBilgisi TcKimlikNoSorgulaSync(TcKimlikNoSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoSorgulaSync(input.siteID, input.ad, input.soyad, input.babaAdi, input.anaAdi, input.dogumYeri, input.dogumTarihi, input.cinsiyet);
            return result;
        }

        public class TcKimlikNoIleNufusCuzdanBilgisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiCuzdanBilgisi TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync(TcKimlikNoIleNufusCuzdanBilgisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleNufusCuzdanBilgisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class YabanciTcKimlikNoIleKisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long yabaciKimlikNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuYabanciKisiBilgisi YabanciTcKimlikNoIleKisiSorgulaSync(YabanciTcKimlikNoIleKisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.YabanciTcKimlikNoIleKisiSorgulaSync(input.siteID, input.yabaciKimlikNo);
            return result;
        }

        public class TcKimlikNoIleNufusKayitOrnegiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuNufusKayitOrnegi TcKimlikNoIleNufusKayitOrnegiSorgulaSync(TcKimlikNoIleNufusKayitOrnegiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleNufusKayitOrnegiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoIleAdresBilgisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleAdresBilgisiSorgulaSync(TcKimlikNoIleAdresBilgisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleAdresBilgisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoIleKoyAdresBilgisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleKoyAdresBilgisiSorgulaSync(TcKimlikNoIleKoyAdresBilgisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleKoyAdresBilgisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoIleBeldeAdresBilgisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleBeldeAdresBilgisiSorgulaSync(TcKimlikNoIleBeldeAdresBilgisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleBeldeAdresBilgisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKisiAdresBilgisi TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync(TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoIleIlceMerkeziAdresBilgisiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class TcKimlikNoAdresTipiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuAdresTipi TcKimlikNoAdresTipiSorgulaSync(TcKimlikNoAdresTipiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.TcKimlikNoAdresTipiSorgulaSync(input.siteID, input.tcNo);
            return result;
        }

        public class KimlikNoIleMaviKartGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long tcNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuMaviKartKisiBilgisi KimlikNoIleMaviKartGetirSync(KimlikNoIleMaviKartGetirSyncInput input)
        {
            var result = KPSServis.WebMethods.KimlikNoIleMaviKartGetirSync(input.siteID, input.tcNo);
            return result;
        }

        public class MaviKartKisiDegisenListeleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime tarih
            {
                get;
                set;
            }

            public long ? sayfa
            {
                get;
                set;
            }
        }

        public KPSServisSonucuMaviKartDegisimListesi MaviKartKisiDegisenListeleSync(MaviKartKisiDegisenListeleSyncInput input)
        {
            var result = KPSServis.WebMethods.MaviKartKisiDegisenListeleSync(input.siteID, input.tarih, input.sayfa);
            return result;
        }

        public class MaviKartAdresDegisenListeleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime tarih
            {
                get;
                set;
            }

            public long ? sayfa
            {
                get;
                set;
            }
        }

        public KPSServisSonucuMaviKartDegisimListesi MaviKartAdresDegisenListeleSync(MaviKartAdresDegisenListeleSyncInput input)
        {
            var result = KPSServis.WebMethods.MaviKartAdresDegisenListeleSync(input.siteID, input.tarih, input.sayfa);
            return result;
        }

        public class MaviKartDegisenListeleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public DateTime tarih
            {
                get;
                set;
            }

            public long ? sayfa
            {
                get;
                set;
            }
        }

        public KPSServisSonucuMaviKartDegisimListesi MaviKartDegisenListeleSync(MaviKartDegisenListeleSyncInput input)
        {
            var result = KPSServis.WebMethods.MaviKartDegisenListeleSync(input.siteID, input.tarih, input.sayfa);
            return result;
        }

        public class GenelKimlikNoIleKisiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long kimlikNo
            {
                get;
                set;
            }
        }

        public KPSServisSonucuKimlikNoSonuc GenelKimlikNoIleKisiSorgulaSync(GenelKimlikNoIleKisiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.GenelKimlikNoIleKisiSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }

        public class GenelKimlikNoIleNufusKayitOrnegiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public long kimlikNo
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public KPSServisSonucuNkoSonuc GenelKimlikNoIleNufusKayitOrnegiSorgulaSync(GenelKimlikNoIleNufusKayitOrnegiSorgulaSyncInput input)
        {
            var result = KPSServis.WebMethods.GenelKimlikNoIleNufusKayitOrnegiSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }
    }
}