using Infrastructure.Filters;
using System;
using System.Collections.Generic;

using System.Linq;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class CommonController : Controller
    {
        [HttpGet]
        public ResUser CurrentResource()
        {
            return Common.CurrentResource;
        }

        [HttpGet]
        public DateTime RecTime()
        {
            return Common.RecTime();
        }
    }
}