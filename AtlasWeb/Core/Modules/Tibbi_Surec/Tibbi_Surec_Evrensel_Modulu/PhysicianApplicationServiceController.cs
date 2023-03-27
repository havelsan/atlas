//$2D2C11CB
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
using TTStorageManager.Security;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class PhysicianApplicationServiceController : Controller
    {
        public class GetExaminationDetailsBySubepisodeId_Input
        {
            public string SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PhysicianApplication.GetExaminationDetailsBySubepisodeId_Class> GetExaminationDetailsBySubepisodeId(GetExaminationDetailsBySubepisodeId_Input input)
        {
            var ret = PhysicianApplication.GetExaminationDetailsBySubepisodeId(input.SUBEPISODE);
            return ret;
        }

        public class GetOldInfoForPoliclinic_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PhysicianApplication.GetOldInfoForPoliclinic_Class> GetOldInfoForPoliclinic(GetOldInfoForPoliclinic_Input input)
        {
            var ret = PhysicianApplication.GetOldInfoForPoliclinic(input.PATIENT);
            return ret;
        }


        
    }
}