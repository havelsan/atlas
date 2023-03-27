//$CD15676F
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.IsGormezlikServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class IsGormezlikServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public IsGormezlikServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class mevcutRaporGetirSyncInput
        {
            public Guid siteID
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

        public CevapDTO mevcutRaporGetirSync(mevcutRaporGetirSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.mevcutRaporGetirSync(input.siteID, input.tcKimlikNo);
            return result;
        }

        public class rapor2VerIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string rtn
            {
                get;
                set;
            }
        }

        public CevapDTO rapor2VerIptalSync(rapor2VerIptalSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.rapor2VerIptalSync(input.siteID, input.rtn);
            return result;
        }

        public class rapor2VerSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string rtn
            {
                get;
                set;
            }

            public int rsn
            {
                get;
                set;
            }

            public string rapordurum
            {
                get;
                set;
            }

            public string duzenlemeTuru
            {
                get;
                set;
            }
        }

        public CevapDTO rapor2VerSync(rapor2VerSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.rapor2VerSync(input.siteID, input.rtn, input.rsn, input.rapordurum, input.duzenlemeTuru);
            return result;
        }

        public class raporGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string raporTakipNo
            {
                get;
                set;
            }
        }

        public CevapDTO raporGetirSync(raporGetirSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporGetirSync(input.siteID, input.raporTakipNo);
            return result;
        }

        public class raporGuncelleSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IsGormezlikServis.IsgoremezlikRaporDVO isgoremezlikRaporDVO
            {
                get;
                set;
            }
        }

        public CevapDTO raporGuncelleSync(raporGuncelleSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporGuncelleSync(input.siteID, input.isgoremezlikRaporDVO);
            return result;
        }

        public class raporKaydetSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IsGormezlikServis.IsgoremezlikRaporDVO isgoremezlikRaporDVO
            {
                get;
                set;
            }
        }

        public CevapDTO raporKaydetSync(raporKaydetSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporKaydetSync(input.siteID, input.isgoremezlikRaporDVO);
            return result;
        }

        public class raporListeGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string date1
            {
                get;
                set;
            }

            public string tesisKodu
            {
                get;
                set;
            }

            public string pass
            {
                get;
                set;
            }
        }

        public CevapDTO raporListeGetirSync(raporListeGetirSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporListeGetirSync(input.siteID, input.date1, input.tesisKodu, input.pass);
            return result;
        }

        public class raporListesiGetirSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string tcNo
            {
                get;
                set;
            }

            public string tesisKodu
            {
                get;
                set;
            }
        }

        public CevapDTO raporListesiGetirSync(raporListesiGetirSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporListesiGetirSync(input.siteID, input.tcNo, input.tesisKodu);
            return result;
        }

        public class raporOnaylaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string raporTakipNo
            {
                get;
                set;
            }

            public string raporSiraNo
            {
                get;
                set;
            }

            public string tesisKodu
            {
                get;
                set;
            }

            public string bashekimTcNo
            {
                get;
                set;
            }

            public string pass
            {
                get;
                set;
            }
        }

        public CevapDTO raporOnaylaSync(raporOnaylaSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporOnaylaSync(input.siteID, input.raporTakipNo, input.raporSiraNo, input.tesisKodu, input.bashekimTcNo, input.pass);
            return result;
        }

        public class raporOnSecimSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public IsGormezlikServis.IsgoremezlikRaporDVO isgoremezlikRaporDVO
            {
                get;
                set;
            }
        }

        public CevapDTO raporOnSecimSync(raporOnSecimSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporOnSecimSync(input.siteID, input.isgoremezlikRaporDVO);
            return result;
        }

        public class raporSilSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string rtn
            {
                get;
                set;
            }

            public int rsn
            {
                get;
                set;
            }

            public int vaka
            {
                get;
                set;
            }

            public string tesisKodu
            {
                get;
                set;
            }
        }

        public CevapDTO raporSilSync(raporSilSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.raporSilSync(input.siteID, input.rtn, input.rsn, input.vaka, input.tesisKodu);
            return result;
        }

        public class saglikKurulunaSevketSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string rtn
            {
                get;
                set;
            }

            public int rsn
            {
                get;
                set;
            }

            public string rapordurum
            {
                get;
                set;
            }
        }

        public CevapDTO saglikKurulunaSevketSync(saglikKurulunaSevketSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.saglikKurulunaSevketSync(input.siteID, input.rtn, input.rsn, input.rapordurum);
            return result;
        }

        public class saglikKurulunaSevkIptalSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string rtn
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public CevapDTO saglikKurulunaSevkIptalSync(saglikKurulunaSevkIptalSyncInput input)
        {
            var result = IsGormezlikServis.WebMethods.saglikKurulunaSevkIptalSync(input.siteID, input.rtn);
            return result;
        }
    }
}