//$68170C12
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.IlacRaporuServis;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class IlacRaporuServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public IlacRaporuServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class eraporAciklamaEkleInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporAciklamaEkleIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporAciklamaEkleCevapDVO eraporAciklamaEkle(eraporAciklamaEkleInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporAciklamaEkle(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporBashekimOnayInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporBashekimOnayIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayCevapDVO eraporBashekimOnay(eraporBashekimOnayInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporBashekimOnay(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporBashekimOnayBekleyenListeSorguInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public eraporBashekimOnayBekleyenListeSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu(eraporBashekimOnayBekleyenListeSorguInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporBashekimOnayBekleyenListeSorgu(input.siteID, input.istekDVO);
            return result;
        }

        public class eraporBashekimOnayRedInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public eraporBashekimOnayRedIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed(eraporBashekimOnayRedInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporBashekimOnayRed(input.siteID, input.istekDVO);
            return result;
        }

        public class eraporEtkinMaddeEkleInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporEtkinMaddeEkleIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporEtkinMaddeEkleCevapDVO eraporEtkinMaddeEkle(eraporEtkinMaddeEkleInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporEtkinMaddeEkle(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporGirisInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporGirisIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporGirisCevapDVO eraporGiris(eraporGirisInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporGiris(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporListeSorgulaInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporListeSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporListeSorguCevapDVO eraporListeSorgula(eraporListeSorgulaInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporListeSorgula(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporOnayInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporOnayIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporOnayCevapDVO eraporOnay(eraporOnayInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporOnay(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporOnayBekleyenListeSorguInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public eraporOnayBekleyenListeSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu(eraporOnayBekleyenListeSorguInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporOnayBekleyenListeSorgu(input.siteID, input.istekDVO);
            return result;
        }

        public class eraporOnayRedInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporOnayRedIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporOnayRedCevapDVO eraporOnayRed(eraporOnayRedInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporOnayRed(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporSilInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporSilIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporSilCevapDVO eraporSil(eraporSilInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporSil(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporSorgulaInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public eraporSorguIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporSorguCevapDVO eraporSorgula(eraporSorgulaInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporSorgula(input.siteID, input.istekDVO);
            return result;
        }

        public class eraporTaniEkleInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporTaniEkleIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public eraporTaniEkleCevapDVO eraporTaniEkle(eraporTaniEkleInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporTaniEkle(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class eraporTeshisEkleInput
        {
            public Guid siteID
            {
                get;
                set;
            }

            public string userName
            {
                get;
                set;
            }

            public string password
            {
                get;
                set;
            }

            public eraporTeshisEkleIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public eraporTeshisEkleCevapDVO eraporTeshisEkle(eraporTeshisEkleInput input)
        {
            var result = IlacRaporuServis.WebMethods.eraporTeshisEkle(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }
    }
}