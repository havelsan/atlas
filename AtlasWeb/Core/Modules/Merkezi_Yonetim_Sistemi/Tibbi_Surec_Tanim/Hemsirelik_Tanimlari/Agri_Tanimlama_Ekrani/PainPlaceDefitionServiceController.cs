//$6C40D682
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class PainPlaceDefitionServiceController : Controller
    {
        public class GetPainPlaceDefition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PainPlaceDefition.GetPainPlaceDefition_Class> GetPainPlaceDefition(GetPainPlaceDefition_Input input)
        {
            var ret = PainPlaceDefition.GetPainPlaceDefition(input.injectionSQL);
            return ret;
        }
    }
}