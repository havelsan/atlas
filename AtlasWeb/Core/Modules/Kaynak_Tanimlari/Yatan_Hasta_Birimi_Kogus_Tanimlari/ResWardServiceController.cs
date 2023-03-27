//$93AB3120
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
    public partial class ResWardServiceController : Controller
    {
        public class SendResWardToDietRationSystem_Input
        {
            public TTObjectClasses.ResWard resWard
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendResWardToDietRationSystem(SendResWardToDietRationSystem_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.resWard != null)
                    input.resWard = (TTObjectClasses.ResWard)objectContext.AddObject(input.resWard);
                ResWard.SendResWardToDietRationSystem(input.resWard);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetSimpleResUserInfoOfWard_Input
        {
            public System.Guid? ResWardcGuid
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.ResUser> GetSimpleResUserInfoOfWard(GetSimpleResUserInfoOfWard_Input input)
        {
            var ret = ResWard.GetSimpleResUserInfoOfWard(input.ResWardcGuid);
            return ret;
        }

        public class GetSimpleResUserInfoByUserType_Input
        {
            public TTObjectClasses.UserTypeEnum userTypeEnum
            {
                get;
                set;
            }

            public System.Guid? resRectionGuid
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.ResUser> GetSimpleResUserInfoByUserType(GetSimpleResUserInfoByUserType_Input input)
        {
            var ret = ResWard.GetSimpleResUserInfoByUserType(input.userTypeEnum, input.resRectionGuid);
            return ret;
        }

        public class GetWardDefinition_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResWard.GetWardDefinition_Class> GetWardDefinition(GetWardDefinition_Input input)
        {
            var ret = ResWard.GetWardDefinition(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<ResWard.OLAP_ResWard_Class> OLAP_ResWard()
        {
            var ret = ResWard.OLAP_ResWard();
            return ret;
        }

        [HttpPost]
        public BindingList<ResWard> OLAP_ResWard_OQ()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResWard.OLAP_ResWard_OQ(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResWards_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResWard> GetResWards(GetResWards_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResWard.GetResWards(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResWard> GetResWardWityEmtyBed()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResWard.GetResWardWityEmtyBed(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByID_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public BindingList<ResWard> GetByID(GetByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResWard.GetByID(objectContext, input.OBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}