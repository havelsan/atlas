//$05544C44
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.HastaKabulIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class HastaKabulIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public HastaKabulIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class updateTakipTipiASyncInput
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

            public takipTipiDegistirGirisDVO takipTipiDegistirGirisDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage updateTakipTipiASync(updateTakipTipiASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTakipTipiASync(input.siteID, input.callerObject, input.takipTipiDegistirGirisDVO);
            return result;
        }

        public class updateTakipTipiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipTipiDegistirGirisDVO takipTipiDegistirDVO
            {
                get;
                set;
            }
        }

        public takipTipiDegistirCevapDVO updateTakipTipiSync(updateTakipTipiSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTakipTipiSync(input.siteID, input.takipTipiDegistirDVO);
            return result;
        }

        public class updateTedaviTipiASyncInput
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

            public takipOkuGirisDVO takipOkuGirisDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage updateTedaviTipiASync(updateTedaviTipiASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTedaviTipiASync(input.siteID, input.callerObject, input.takipOkuGirisDVO);
            return result;
        }

        public class updateTedaviTipiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipOkuGirisDVO takipOkuDVO
            {
                get;
                set;
            }
        }

        public takipDVO updateTedaviTipiSync(updateTedaviTipiSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTedaviTipiSync(input.siteID, input.takipOkuDVO);
            return result;
        }

        public class updateTedaviTuruASyncInput
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

            public tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage updateTedaviTuruASync(updateTedaviTuruASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTedaviTuruASync(input.siteID, input.callerObject, input.tedaviTuruDegistirDVO);
            return result;
        }

        public class updateTedaviTuruSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public tedaviTuruDegistirGirisDVO tedaviTuruDegistirDVO
            {
                get;
                set;
            }
        }

        public tedaviTuruDegistirCevapDVO updateTedaviTuruSync(updateTedaviTuruSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateTedaviTuruSync(input.siteID, input.tedaviTuruDegistirDVO);
            return result;
        }

        public class basvuruTakipOkuASyncInput
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

            public basvuruTakipOkuDVO basvuruTakipOkuDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage basvuruTakipOkuASync(basvuruTakipOkuASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.basvuruTakipOkuASync(input.siteID, input.callerObject, input.basvuruTakipOkuDVO);
            return result;
        }

        public class basvuruTakipOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public basvuruTakipOkuDVO basvuruTakipOkuDVO
            {
                get;
                set;
            }
        }

        public basvuruTakipOkuCevapDVO basvuruTakipOkuSync(basvuruTakipOkuSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.basvuruTakipOkuSync(input.siteID, input.basvuruTakipOkuDVO);
            return result;
        }

        public class getMustehaklikKapsamKoduSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public mustehaklikGirisDVO mustehaklikGirisDVO
            {
                get;
                set;
            }
        }

        public mustehaklikCevapDVO getMustehaklikKapsamKoduSync(getMustehaklikKapsamKoduSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.getMustehaklikKapsamKoduSync(input.siteID, input.mustehaklikGirisDVO);
            return result;
        }

        public class getYesilKartliSevkliHastaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yesilKartliSevkliHastaGirisDVO yesilKartliSevkliHastaGiris
            {
                get;
                set;
            }
        }

        public yesilKartliSevkliHastaCevapDVO getYesilKartliSevkliHastaSync(getYesilKartliSevkliHastaSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.getYesilKartliSevkliHastaSync(input.siteID, input.yesilKartliSevkliHastaGiris);
            return result;
        }

        public class hastaCikisIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public hastaCikisIptalDVO hastaCikisIptal
            {
                get;
                set;
            }
        }

        public hastaCikisCevapDVO hastaCikisIptalSync(hastaCikisIptalSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaCikisIptalSync(input.siteID, input.hastaCikisIptal);
            return result;
        }

        public class hastaCikisKayitSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public hastaCikisDVO hastaCikis
            {
                get;
                set;
            }
        }

        public hastaCikisCevapDVO hastaCikisKayitSync(hastaCikisKayitSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaCikisKayitSync(input.siteID, input.hastaCikis);
            return result;
        }

        public class hastaKabulASyncInput
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

            public provizyonGirisDVO provizyonGiris
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage hastaKabulASync(hastaKabulASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulASync(input.siteID, input.callerObject, input.provizyonGiris);
            return result;
        }

        public class hastaKabulIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipSilGirisDVO takipSilGiris
            {
                get;
                set;
            }
        }

        public takipSilCevapDVO hastaKabulIptalSync(hastaKabulIptalSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(input.siteID, input.takipSilGiris);
            return result;
        }

        public class hastaKabulKimlikDogrulamaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public provizyonGirisDVO provizyonGiris
            {
                get;
                set;
            }
        }

        public provizyonCevapDVO hastaKabulKimlikDogrulamaSync(hastaKabulKimlikDogrulamaSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulKimlikDogrulamaSync(input.siteID, input.provizyonGiris);
            return result;
        }

        public class hastaKabulOkuASyncInput
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

            public takipOkuGirisDVO takipOkuGirisDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage hastaKabulOkuASync(hastaKabulOkuASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulOkuASync(input.siteID, input.callerObject, input.takipOkuGirisDVO);
            return result;
        }

        public class hastaKabulOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipOkuGirisDVO takipOkuGirisDVO
            {
                get;
                set;
            }
        }

        public takipDVO hastaKabulOkuSync(hastaKabulOkuSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulOkuSync(input.siteID, input.takipOkuGirisDVO);
            return result;
        }

        public class hastaKabulSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public provizyonGirisDVO provizyonGiris
            {
                get;
                set;
            }
        }

        public provizyonCevapDVO hastaKabulSync(hastaKabulSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaKabulSync(input.siteID, input.provizyonGiris);
            return result;
        }

        public class hastaYatisOkuSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public hastaYatisOkuDVO hastaYatisOkuDVO
            {
                get;
                set;
            }
        }

        public hastaYatisOkuCevapDVO hastaYatisOkuSync(hastaYatisOkuSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.hastaYatisOkuSync(input.siteID, input.hastaYatisOkuDVO);
            return result;
        }

        public class sevkBildirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public sevkBildirGirisDVO sevkBildirGiris
            {
                get;
                set;
            }
        }

        public sevkBildirSonucDVO sevkBildirSync(sevkBildirSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.sevkBildirSync(input.siteID, input.sevkBildirGiris);
            return result;
        }

        public class updateProvizyonTipiASyncInput
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

            public provizyonDegistirGirisDVO provizyonDegistirGirisDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage updateProvizyonTipiASync(updateProvizyonTipiASyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateProvizyonTipiASync(input.siteID, input.callerObject, input.provizyonDegistirGirisDVO);
            return result;
        }

        public class updateProvizyonTipiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public provizyonDegistirGirisDVO provizyonDegistirDVO
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public provizyonDegistirCevapDVO updateProvizyonTipiSync(updateProvizyonTipiSyncInput input)
        {
            var result = HastaKabulIslemleri.WebMethods.updateProvizyonTipiSync(input.siteID, input.provizyonDegistirDVO);
            return result;
        }
    }
}