//$1EE3DB1F
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
    public partial class BaseNursingDataEntryServiceController : Controller
    {
        public class GetBaseNursingDataByType_Input
        {
            public string OBJECTDEFNAME
            {
                get;
                set;
            }

            public Guid NURSINGAPPLICATION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BaseNursingDataEntry> GetBaseNursingDataByType(GetBaseNursingDataByType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseNursingDataEntry.GetBaseNursingDataByType(objectContext, input.OBJECTDEFNAME, input.NURSINGAPPLICATION);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByInPatientPhysicianApplication_Input
        {
            public Guid INPATIENTPHYSICIANAPPLICATION
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<BaseNursingDataEntry> GetByInPatientPhysicianApplication(GetByInPatientPhysicianApplication_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BaseNursingDataEntry.GetByInPatientPhysicianApplication(objectContext, input.INPATIENTPHYSICIANAPPLICATION);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}