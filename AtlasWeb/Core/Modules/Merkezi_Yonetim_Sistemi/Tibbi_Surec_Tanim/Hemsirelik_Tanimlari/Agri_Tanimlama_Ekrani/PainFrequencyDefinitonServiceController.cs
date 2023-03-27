//$25511741
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
    public partial class PainFrequencyDefinitonServiceController : Controller
    {
        public class GetPainFrequency_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PainFrequencyDefiniton.GetPainFrequency_Class> GetPainFrequency(GetPainFrequency_Input input)
        {
            var ret = PainFrequencyDefiniton.GetPainFrequency(input.injectionSQL);
            return ret;
        }
    }
}