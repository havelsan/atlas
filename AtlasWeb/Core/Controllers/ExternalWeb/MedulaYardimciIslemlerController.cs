//$04A36416
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.MedulaYardimciIslemler;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class MedulaYardimciIslemlerController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public MedulaYardimciIslemlerController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class doktorAraSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public doktorAraGirisDVO doktorAraGiris
            {
                get;
                set;
            }
        }

        public doktorAraCevapDVO doktorAraSync(doktorAraSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.doktorAraSync(input.siteID, input.doktorAraGiris);
            return result;
        }

        public class getOrneklenmisTakiplerSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public orneklenmisGirisDVO orneklenmisGirisDVO
            {
                get;
                set;
            }
        }

        public orneklenmisCevapDVO getOrneklenmisTakiplerSync(getOrneklenmisTakiplerSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.getOrneklenmisTakiplerSync(input.siteID, input.orneklenmisGirisDVO);
            return result;
        }

        public class getRemoteAddrSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }
        }

        public string getRemoteAddrSync(getRemoteAddrSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.getRemoteAddrSync(input.siteID);
            return result;
        }

        public class ilacAraSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacAraGirisDVO ilacAraGiris
            {
                get;
                set;
            }
        }

        public ilacAraCevapDVO ilacAraSync(ilacAraSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.ilacAraSync(input.siteID, input.ilacAraGiris);
            return result;
        }

        public class katilimPayiUcretiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public katilimPayiGirisDVO katilimPayiGiris
            {
                get;
                set;
            }
        }

        public katilimPayiCevapDVO katilimPayiUcretiSync(katilimPayiUcretiSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.katilimPayiUcretiSync(input.siteID, input.katilimPayiGiris);
            return result;
        }

        public class kesintiYapilmisIslemlerSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public evrakKesintiGirisDVO evrakKesintiGiris
            {
                get;
                set;
            }
        }

        public evrakKesintiCevapDVO kesintiYapilmisIslemlerSync(kesintiYapilmisIslemlerSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.kesintiYapilmisIslemlerSync(input.siteID, input.evrakKesintiGiris);
            return result;
        }

        public class saglikTesisiAraSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public saglikTesisiAraGirisDVO saglikTesisiAraGiris
            {
                get;
                set;
            }
        }

        public saglikTesisiAraCevapDVO saglikTesisiAraSync(saglikTesisiAraSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.saglikTesisiAraSync(input.siteID, input.saglikTesisiAraGiris);
            return result;
        }

        public class takipAraSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipAraGirisDVO takipAraGiris
            {
                get;
                set;
            }
        }

        public takipAraCevapDVO takipAraSync(takipAraSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.takipAraSync(input.siteID, input.takipAraGiris);
            return result;
        }

        public class takipBilgileriListesiSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public takipBilgisiGirisDVO takipBilgisiGirisDVO
            {
                get;
                set;
            }
        }

        public takipBilgisiCevapDVO takipBilgileriListesiSync(takipBilgileriListesiSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.takipBilgileriListesiSync(input.siteID, input.takipBilgisiGirisDVO);
            return result;
        }

        public class yurtDisiYardimHakkiGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public yurtDisiYardimHakkiGetirGirisDVO yurtDisiYardimHakkiGetirGiris
            {
                get;
                set;
            }
        }

        public yurtDisiYardimHakkiGetirCevapDVO yurtDisiYardimHakkiGetirSync(yurtDisiYardimHakkiGetirSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.yurtDisiYardimHakkiGetirSync(input.siteID, input.yurtDisiYardimHakkiGetirGiris);
            return result;
        }

        public class tesisYatakSorguSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public tesisYatakSorguGirisDVO tesisYatakSorguGiris
            {
                get;
                set;
            }
        }

        public tesisYatakSorguCevapDVO tesisYatakSorguSync(tesisYatakSorguSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.tesisYatakSorguSync(input.siteID, input.tesisYatakSorguGiris);
            return result;
        }

        public class barkodSutEslesmeSorguSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public barkodSutEslesmeSorguGirisDVO barkodSutEslesmeSorguGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public barkodSutEslesmeSorguCevapDVO barkodSutEslesmeSorguSync(barkodSutEslesmeSorguSyncInput input)
        {
            var result = MedulaYardimciIslemler.WebMethods.barkodSutEslesmeSorguSync(input.siteID, input.barkodSutEslesmeSorguGiris);
            return result;
        }
    }
}