using System;
using System.Linq;
using System.Net.Http;

using TTUtils;
using Core.Services;
using TTObjectClasses;
using static TTObjectClasses.SKRSObjects;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    public class SKRSObjectsController : Controller
    {
        private WebMethodCallerService _webMethodCallerService
        {
            get;
            set;
        }

        public SKRSObjectsController(WebMethodCallerService webMethodCallerService)
        {
            _webMethodCallerService = webMethodCallerService;
        }
    }
}