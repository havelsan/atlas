//$016CA88B
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
    public partial class RadiologyServiceController : Controller
    {
        public class RadiologyRequestPatientInfoReportQuery_Input
        {
            public string PARAMRADOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Radiology.RadiologyRequestPatientInfoReportQuery_Class> RadiologyRequestPatientInfoReportQuery(RadiologyRequestPatientInfoReportQuery_Input input)
        {
            var ret = Radiology.RadiologyRequestPatientInfoReportQuery(input.PARAMRADOBJID);
            return ret;
        }

        public class GetByEpisodeAndClonedObjectID_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid CLONEDOBJECTID
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Radiology> GetByEpisodeAndClonedObjectID(GetByEpisodeAndClonedObjectID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Radiology.GetByEpisodeAndClonedObjectID(objectContext, input.EPISODE, input.CLONEDOBJECTID, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Radiology.VEM_RADYOLOJI_ORNEK_Class> VEM_RADYOLOJI_ORNEK()
        {
            var ret = Radiology.VEM_RADYOLOJI_ORNEK();
            return ret;
        }
    }
}