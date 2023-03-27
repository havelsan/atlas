//$F53F8A72
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.RaporIslemleri;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class RaporIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public RaporIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ilacRaporDuzeltSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacRaporDuzeltDVO raporDuzelt
            {
                get;
                set;
            }
        }

        public raporCevapDVO ilacRaporDuzeltSync(ilacRaporDuzeltSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.ilacRaporDuzeltSync(input.siteID, input.raporDuzelt);
            return result;
        }

        public class raporBilgisiBulRaporTakipNodanSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporOkuRaporTakipNodanDVO raporOku
            {
                get;
                set;
            }
        }

        public raporCevapDVO raporBilgisiBulRaporTakipNodanSync(raporBilgisiBulRaporTakipNodanSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.raporBilgisiBulRaporTakipNodanSync(input.siteID, input.raporOku);
            return result;
        }

        public class raporBilgisiBulSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporSorguDVO raporBilgisi
            {
                get;
                set;
            }
        }

        public raporCevapDVO raporBilgisiBulSync(raporBilgisiBulSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.raporBilgisiBulSync(input.siteID, input.raporBilgisi);
            return result;
        }

        public class raporBilgisiBulTCKimlikNodanSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporOkuTCKimlikNodanDVO raporOku
            {
                get;
                set;
            }
        }

        public raporCevapTCKimlikNodanDVO raporBilgisiBulTCKimlikNodanSync(raporBilgisiBulTCKimlikNodanSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.raporBilgisiBulTCKimlikNodanSync(input.siteID, input.raporOku);
            return result;
        }

        public class raporBilgisiKaydetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporGirisDVO raporGiris
            {
                get;
                set;
            }
        }

        public raporCevapDVO raporBilgisiKaydetSync(raporBilgisiKaydetSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.raporBilgisiKaydetSync(input.siteID, input.raporGiris);
            return result;
        }

        public class raporBilgisiSilSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporSorguDVO raporBilgisi
            {
                get;
                set;
            }
        }

        public raporCevapDVO raporBilgisiSilSync(raporBilgisiSilSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.raporBilgisiSilSync(input.siteID, input.raporBilgisi);
            return result;
        }

        public class takipNoileRaporBilgisiKaydetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public raporGirisDVO raporGiris
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public raporCevapDVO takipNoileRaporBilgisiKaydetSync(takipNoileRaporBilgisiKaydetSyncInput input)
        {
            var result = RaporIslemleri.WebMethods.takipNoileRaporBilgisiKaydetSync(input.siteID, input.raporGiris);
            return result;
        }
    }
}