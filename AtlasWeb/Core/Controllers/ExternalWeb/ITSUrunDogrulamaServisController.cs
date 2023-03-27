//$0688FA11
using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class ITSUrunDogrulamaServisController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public ITSUrunDogrulamaServisController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }

        //public class UrunDogrulamaBildirInput
        //{
        //    public Guid siteID
        //    {
        //        get;
        //        set;
        //    }

        //    public IWebMethodCallback callerObject
        //    {
        //        get;
        //        set;
        //    }

        //    public ITSUrunDogrulamaServis.UrunDogrulamaBildirimType urun
        //    {
        //        get;
        //        set;
        //    }
        //}

        //[Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        //public TTStorageManager.TTMessage UrunDogrulamaBildir(UrunDogrulamaBildirInput input)
        //{
        //    var result = ITSUrunDogrulamaServis.WebMethods.UrunDogrulamaBildir(input.siteID, input.callerObject, input.urun);
        //    return result;
        //}
    }
}