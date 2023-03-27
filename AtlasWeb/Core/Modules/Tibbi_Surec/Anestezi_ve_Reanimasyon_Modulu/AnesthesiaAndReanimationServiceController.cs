//$974ED907
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class AnesthesiaAndReanimationServiceController : Controller
    {
        public class AnesthesiaReportNQL_Input
        {
            public string ANESTHESIA
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class> AnesthesiaReportNQL(AnesthesiaReportNQL_Input input)
        {
            var ret = AnesthesiaAndReanimation.AnesthesiaReportNQL(input.ANESTHESIA);
            return ret;
        }

        public class OLAP_GetAnesthesiaOfSurgery_Input
        {
            public string SURGERYID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class> OLAP_GetAnesthesiaOfSurgery(OLAP_GetAnesthesiaOfSurgery_Input input)
        {
            var ret = AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery(input.SURGERYID);
            return ret;
        }

        public class GetByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<AnesthesiaAndReanimation> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = AnesthesiaAndReanimation.GetByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}