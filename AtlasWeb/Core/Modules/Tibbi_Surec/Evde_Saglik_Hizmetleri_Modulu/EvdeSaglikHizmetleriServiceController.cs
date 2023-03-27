//$A76AD523
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
    public partial class EvdeSaglikHizmetleriServiceController : Controller
    {
        public class GetHomeCarePatientsByDateNQL_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<EvdeSaglikHizmetleri> GetHomeCarePatientsByDateNQL(GetHomeCarePatientsByDateNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = EvdeSaglikHizmetleri.GetHomeCarePatientsByDateNQL(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}