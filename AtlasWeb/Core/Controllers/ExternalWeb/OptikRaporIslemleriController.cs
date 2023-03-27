//$E197D8F8
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.OptikRaporIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class OptikRaporIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public OptikRaporIslemleriController(WebMethodCallerService webMethodCallerService)
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

            public eraporAciklamaEkleIstekDVO eraporAciklamaEkleIstek
            {
                get;
                set;
            }
        }

        public eraporAciklamaEkleCevapDVO eraporAciklamaEkle(eraporAciklamaEkleInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporAciklamaEkle(input.siteID, input.userName, input.password, input.eraporAciklamaEkleIstek);
            return result;
        }

        public class eraporBashekimOnayBekleyenListeSorguInput
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

            public eraporBashekimOnayBekleyenListeSorguIstekDVO eraporBashekimOnayBekleyenListeSorguIstek
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayBekleyenListeSorguCevapDVO eraporBashekimOnayBekleyenListeSorgu(eraporBashekimOnayBekleyenListeSorguInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporBashekimOnayBekleyenListeSorgu(input.siteID, input.userName, input.password, input.eraporBashekimOnayBekleyenListeSorguIstek);
            return result;
        }

        public class eraporBashekimOnayRedInput
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

            public eraporBashekimOnayRedIstekDVO eraporBashekimOnayRedIstek
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayRedCevapDVO eraporBashekimOnayRed(eraporBashekimOnayRedInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporBashekimOnayRed(input.siteID, input.userName, input.password, input.eraporBashekimOnayRedIstek);
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

            public eraporBashekimOnayIstekDVO eraporBashekimOnayIstek
            {
                get;
                set;
            }
        }

        public eraporBashekimOnayCevapDVO eraporBashekimOnay(eraporBashekimOnayInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporBashekimOnay(input.siteID, input.userName, input.password, input.eraporBashekimOnayIstek);
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

            public raporTesisDVO raporTesis
            {
                get;
                set;
            }
        }

        public eRaporSonucDVO eraporGiris(eraporGirisInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporGiris(input.siteID, input.userName, input.password, input.raporTesis);
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

            public eraporListeSorguIstekDVO eraporListeSorguIstek
            {
                get;
                set;
            }
        }

        public eraporListeSorguCevapDVO eraporListeSorgula(eraporListeSorgulaInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporListeSorgula(input.siteID, input.userName, input.password, input.eraporListeSorguIstek);
            return result;
        }

        public class eraporOnayBekleyenListeSorguInput
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

            public eraporOnayBekleyenListeSorguIstekDVO eraporOnayBekleyenListeSorguIstek
            {
                get;
                set;
            }
        }

        public eraporOnayBekleyenListeSorguCevapDVO eraporOnayBekleyenListeSorgu(eraporOnayBekleyenListeSorguInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporOnayBekleyenListeSorgu(input.siteID, input.userName, input.password, input.eraporOnayBekleyenListeSorguIstek);
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

            public eraporOnayRedIstekDVO eraporOnayRedIstek
            {
                get;
                set;
            }
        }

        public eraporOnayRedCevapDVO eraporOnayRed(eraporOnayRedInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporOnayRed(input.siteID, input.userName, input.password, input.eraporOnayRedIstek);
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

            public eraporOnayIstekDVO eraporOnayIstek
            {
                get;
                set;
            }
        }

        public eraporOnayCevapDVO eraporOnay(eraporOnayInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporOnay(input.siteID, input.userName, input.password, input.eraporOnayIstek);
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

            public eraporSilDVO eraporSil
            {
                get;
                set;
            }
        }

        public eRaporSonucDVO eraporSil(eraporSilInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporSil(input.siteID, input.userName, input.password, input.eraporSil);
            return result;
        }

        public class eraporSorgulaInput
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

            public eraporSorguIstekDVO eraporSorguIstek
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public eraporSorguCevapDVO eraporSorgula(eraporSorgulaInput input)
        {
            var result = OptikRaporIslemleri.WebMethods.eraporSorgula(input.siteID, input.userName, input.password, input.eraporSorguIstek);
            return result;
        }
    }
}