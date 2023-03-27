//$3C0DA5A5
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.KPSV2;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class KPSV2Controller : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public KPSV2Controller(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class BilesikKisiSorgulaSyncInput
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

        public KpsServisSonucuBilesikKisiBilgisi BilesikKisiSorgulaSync(BilesikKisiSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.BilesikKisiSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }

        public class BilesikKisiveAdresSorgulaSyncInput
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

        public KpsServisSonucuBilesikKisiBilgisi BilesikKisiveAdresSorgulaSync(BilesikKisiveAdresSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.BilesikKisiveAdresSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }

        public class TcKimlikNoSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public KisiSorgulaKisiBilgileriCO kriter
            {
                get;
                set;
            }
        }

        public KpsServisSonucuKisiTemelBilgisi TcKimlikNoSorgulaSync(TcKimlikNoSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.TcKimlikNoSorgulaSync(input.siteID, input.kriter);
            return result;
        }

        public class KimlikNoIleAdresBilgisiSorgulaSyncInput
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

        public KpsServisSonucuKisiAdresBilgisi KimlikNoIleAdresBilgisiSorgulaSync(KimlikNoIleAdresBilgisiSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.KimlikNoIleAdresBilgisiSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }

        public class AileBireyleriSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public AileBireyleriSorgulaKriter kriter
            {
                get;
                set;
            }
        }

        public KpsServisSonucuAileBilgisi AileBireyleriSorgulaSync(AileBireyleriSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.AileBireyleriSorgulaSync(input.siteID, input.kriter);
            return result;
        }

        public class KimlikNoIleNufusKayitOrnegiSorgulaSyncInput
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

        public KpsServisSonucuGenelNufusKayitOrnegi KimlikNoIleNufusKayitOrnegiSorgulaSync(KimlikNoIleNufusKayitOrnegiSorgulaSyncInput input)
        {
            var result = KPSV2.WebMethods.KimlikNoIleNufusKayitOrnegiSorgulaSync(input.siteID, input.kimlikNo);
            return result;
        }

        public class YetkiListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public KpsServisSonucuYetkiListesi YetkiListesiSync(YetkiListesiSyncInput input)
        {
            var result = KPSV2.WebMethods.YetkiListesiSync(input.siteID);
            return result;
        }
    }
}