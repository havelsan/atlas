//$15E0B2F9
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.EReceteIslemleri;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class EReceteIslemleriController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public EReceteIslemleriController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        public class ereceteAciklamaEkleInput
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

            public EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO
            {
                get;
                set;
            }
        }

        public EReceteIslemleri.ereceteAciklamaEkleCevapDVO ereceteAciklamaEkle(ereceteAciklamaEkleInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteAciklamaEkle(input.siteID, input.userName, input.password, input.ereceteAciklamaEkleIstekDVO);
            return result;
        }

        public class imzaliEreceteGirisSyncInput
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

            public imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteGirisCevapDVO imzaliEreceteGirisSync(imzaliEreceteGirisSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(input.siteID, input.userName, input.password, input.imzaliEreceteGirisIstekDVO);
            return result;
        }

        public class imzaliEreceteSilSyncInput
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

            public imzaliEreceteSilIstekDVO imzaliEreceteSilIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteSilCevapDVO imzaliEreceteSilSync(imzaliEreceteSilSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteSilSync(input.siteID, input.userName, input.password, input.imzaliEreceteSilIstekDVO);
            return result;
        }

        public class imzaliEreceteOnaySyncInput
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

            public imzaliEreceteOnayIstekDVO imzaliEreceteOnayIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteOnayCevapDVO imzaliEreceteOnaySync(imzaliEreceteOnaySyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(input.siteID, input.userName, input.password, input.imzaliEreceteOnayIstekDVO);
            return result;
        }

        public class imzaliEreceteOnayIptalSyncInput
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

            public imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteOnayIptalCevapDVO imzaliEreceteOnayIptalSync(imzaliEreceteOnayIptalSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalSync(input.siteID, input.userName, input.password, input.imzaliEreceteOnayIptalIstekDVO);
            return result;
        }

        public class imzaliEreceteTaniEkleSyncInput
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

            public imzaliEreceteTaniEkleIstekDVO imzaliEreceteTaniEkleIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteTaniEkleCevapDVO imzaliEreceteTaniEkleSync(imzaliEreceteTaniEkleSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteTaniEkleSync(input.siteID, input.userName, input.password, input.imzaliEreceteTaniEkleIstekDVO);
            return result;
        }

        public class ereceteEhuOnayiInput
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

            public ereceteEhuOnayiIstekDVO ereceteEhuOnayiIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteEhuOnayiCevapDVO ereceteEhuOnayi(ereceteEhuOnayiInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteEhuOnayi(input.siteID, input.userName, input.password, input.ereceteEhuOnayiIstekDVO);
            return result;
        }

        public class ereceteEhuOnayiIptalInput
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

            public ereceteEhuOnayiIptalIstekDVO ereceteEhuOnayiIptalIstekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage ereceteEhuOnayiIptal(ereceteEhuOnayiIptalInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteEhuOnayiIptal(input.siteID, input.userName, input.password, input.callerObject, input.ereceteEhuOnayiIptalIstekDVO);
            return result;
        }

        public class ereceteGirisInput
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

            public EReceteIslemleri.ereceteGirisIstekDVO ereceteGirisIstekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage ereceteGiris(ereceteGirisInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteGiris(input.siteID, input.userName, input.password, input.callerObject, input.ereceteGirisIstekDVO);
            return result;
        }

        public class ereceteGirisSynCallInput
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

            public EReceteIslemleri.ereceteGirisIstekDVO ereceteGirisIstekDVO
            {
                get;
                set;
            }
        }

        public EReceteIslemleri.ereceteGirisCevapDVO ereceteGirisSynCall(ereceteGirisSynCallInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteGirisSynCall(input.siteID, input.userName, input.password, input.ereceteGirisIstekDVO);
            return result;
        }

        public class ereceteIlacAciklamaEkleInput
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

            public ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteIlacAciklamaEkleCevapDVO ereceteIlacAciklamaEkle(ereceteIlacAciklamaEkleInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteIlacAciklamaEkle(input.siteID, input.userName, input.password, input.ereceteIlacAciklamaEkleIstekDVO);
            return result;
        }

        public class ereceteListeSorgulaSyncInput
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

            public ereceteListeSorguIstekDVO ereceteListeSorguIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteListeSorguCevapDVO ereceteListeSorgulaSync(ereceteListeSorgulaSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteListeSorgulaSync(input.siteID, input.userName, input.password, input.ereceteListeSorguIstekDVO);
            return result;
        }

        public class ereceteOnayInput
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

            public ereceteOnayIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public ereceteOnayCevapDVO ereceteOnay(ereceteOnayInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteOnay(input.siteID, input.userName, input.password, input.istekDVO);
            return result;
        }

        public class ereceteOnayIptalInput
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

            public ereceteOnayIptalIstekDVO istekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage ereceteOnayIptal(ereceteOnayIptalInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteOnayIptal(input.siteID, input.userName, input.password, input.callerObject, input.istekDVO);
            return result;
        }

        public class ereceteSilInput
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

            public EReceteIslemleri.ereceteSilIstekDVO ereceteSilIstekDVO
            {
                get;
                set;
            }
        }

        public EReceteIslemleri.ereceteSilCevapDVO ereceteSil(ereceteSilInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteSil(input.siteID, input.userName, input.password, input.ereceteSilIstekDVO);
            return result;
        }

        public class ereceteSorgulaSyncInput
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

            public EReceteIslemleri.ereceteSorguIstekDVO ereceteSorguIstekDVO
            {
                get;
                set;
            }
        }

        public EReceteIslemleri.ereceteSorguCevapDVO ereceteSorgulaSync(ereceteSorgulaSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteSorgulaSync(input.siteID, input.userName, input.password, input.ereceteSorguIstekDVO);
            return result;
        }

        public class ereceteTaniEkleInput
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

            public ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteTaniEkleCevapDVO ereceteTaniEkle(ereceteTaniEkleInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteTaniEkle(input.siteID, input.userName, input.password, input.ereceteTaniEkleIstekDVO);
            return result;
        }

        public class ereceteYatanHastaOnayiInput
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

            public ereceteYatanHastaOnayiIstekDVO ereceteYatanHastaOnayiIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteYatanHastaOnayiCevapDVO ereceteYatanHastaOnayi(ereceteYatanHastaOnayiInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteYatanHastaOnayi(input.siteID, input.userName, input.password, input.ereceteYatanHastaOnayiIstekDVO);
            return result;
        }

        public class ereceteYatanHastaOnayiIptalInput
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

            public ereceteYatanHastaOnayiIptalIstekDVO ereceteYatanHastaOnayiIptalIstekDVO
            {
                get;
                set;
            }
        }

        public ereceteYatanHastaOnayiIptalCevapDVO ereceteYatanHastaOnayiIptal(ereceteYatanHastaOnayiIptalInput input)
        {
            var result = EReceteIslemleri.WebMethods.ereceteYatanHastaOnayiIptal(input.siteID, input.userName, input.password, input.ereceteYatanHastaOnayiIptalIstekDVO);
            return result;
        }

        public class imzaliEreceteGirisInput
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

            public imzaliEreceteGirisIstekDVO imzaliEreceteGirisIstekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage imzaliEreceteGiris(imzaliEreceteGirisInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteGiris(input.siteID, input.callerObject, input.imzaliEreceteGirisIstekDVO);
            return result;
        }

        public class imzaliEreceteOnayIptalAsyncInput
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

            public imzaliEreceteOnayIptalIstekDVO imzaliEreceteOnayIptalIstekDVO
            {
                get;
                set;
            }
        }

        public TTStorageManager.TTMessage imzaliEreceteOnayIptalAsync(imzaliEreceteOnayIptalAsyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteOnayIptalAsync(input.siteID, input.userName, input.password, input.callerObject, input.imzaliEreceteOnayIptalIstekDVO);
            return result;
        }

        public class imzaliEreceteAciklamaEkleSyncInput
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

            public imzaliEreceteAciklamaEkleIstekDVO imzaliEreceteAciklamaEkleIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteAciklamaEkleCevapDVO imzaliEreceteAciklamaEkleSync(imzaliEreceteAciklamaEkleSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteAciklamaEkleSync(input.siteID, input.userName, input.password, input.imzaliEreceteAciklamaEkleIstekDVO);
            return result;
        }

        public class imzaliEreceteIlacAciklamaEkleSyncInput
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

            public imzaliEreceteIlacAciklamaEkleIstekDVO imzaliEreceteIlacAciklamaEkleIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteIlacAciklamaEkleCevapDVO imzaliEreceteIlacAciklamaEkleSync(imzaliEreceteIlacAciklamaEkleSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteIlacAciklamaEkleSync(input.siteID, input.userName, input.password, input.imzaliEreceteIlacAciklamaEkleIstekDVO);
            return result;
        }

        public class imzaliEreceteSorguSyncInput
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

            public imzaliEreceteSorguIstekDVO imzaliEreceteSorguIstekDVO
            {
                get;
                set;
            }
        }

        public imzaliEreceteSorguCevapDVO imzaliEreceteSorguSync(imzaliEreceteSorguSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteSorguSync(input.siteID, input.userName, input.password, input.imzaliEreceteSorguIstekDVO);
            return result;
        }

        public class imzaliEreceteListeSorguSyncInput
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

            public imzaliEreceteListeSorguIstekDVO imzaliEreceteListeSorguIstekDVO
            {
                get;
                set;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public imzaliEreceteListeSorguCevapDVO imzaliEreceteListeSorguSync(imzaliEreceteListeSorguSyncInput input)
        {
            var result = EReceteIslemleri.WebMethods.imzaliEreceteListeSorguSync(input.siteID, input.userName, input.password, input.imzaliEreceteListeSorguIstekDVO);
            return result;
        }
    }
}