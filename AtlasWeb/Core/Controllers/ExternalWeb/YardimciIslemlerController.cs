//$0086BC22
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.YardimciIslemler;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class YardimciIslemlerController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public YardimciIslemlerController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class aktifIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO aktifIlacListesiSorgulaSync(aktifIlacListesiSorgulaSyncInput input)
        {
            string userName = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAUSERNAME", "XXXXXX");
            string password = TTObjectClasses.SystemParameter.GetParameterValue("MEDULAPASSWORD", "XXXXXX");

            var result = YardimciIslemler.WebMethods.aktifIlacListesiSorgulaSync(input.siteID,userName,password, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class etkinMaddeListesiSorgulaInput
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

            public etkinMaddeListesiSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage etkinMaddeListesiSorgula(etkinMaddeListesiSorgulaInput input)
        {
            var result = YardimciIslemler.WebMethods.etkinMaddeListesiSorgula(input.siteID, input.callerObject, input.istekDVO);
            return result;
        }

        public class etkinMaddeSutListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public etkinMaddeSutListesiSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public etkinMaddeSutListesiSorguCevapDVO etkinMaddeSutListesiSorgulaSync(etkinMaddeSutListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.etkinMaddeSutListesiSorgulaSync(input.siteID, input.istekDVO);
            return result;
        }

        public class kirmiziReceteIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO kirmiziReceteIlacListesiSorgulaSync(kirmiziReceteIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.kirmiziReceteIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class morReceteIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO morReceteIlacListesiSorgulaSync(morReceteIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.morReceteIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class normalReceteIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO normalReceteIlacListesiSorgulaSync(normalReceteIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.normalReceteIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class pasifIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO pasifIlacListesiSorgulaSync(pasifIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.pasifIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class raporTeshisListesiSorgulaInput
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

            public raporTeshisListesiSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage raporTeshisListesiSorgula(raporTeshisListesiSorgulaInput input)
        {
            var result = YardimciIslemler.WebMethods.raporTeshisListesiSorgula(input.siteID, input.callerObject, input.istekDVO);
            return result;
        }

        public class turuncuReceteIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ilacListesiSorguCevapDVO turuncuReceteIlacListesiSorgulaSync(turuncuReceteIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.turuncuReceteIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }

        public class yesilReceteIlacListesiSorgulaSyncInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public ilacListesiSorguIstekDVO ilacListesiSorguIstekDVO
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public ilacListesiSorguCevapDVO yesilReceteIlacListesiSorgulaSync(yesilReceteIlacListesiSorgulaSyncInput input)
        {
            var result = YardimciIslemler.WebMethods.yesilReceteIlacListesiSorgulaSync(input.siteID, input.ilacListesiSorguIstekDVO);
            return result;
        }
    }
}