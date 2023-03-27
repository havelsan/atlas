//$1DE6B165
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
    public partial class DietOrderDetailServiceController : Controller
    {
        public class GetDODByInpaitentPhysicianApp_Input
        {
            public string INPATIENTPHYAPP
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DietOrderDetail> GetDODByInpaitentPhysicianApp(GetDODByInpaitentPhysicianApp_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DietOrderDetail.GetDODByInpaitentPhysicianApp(objectContext, input.INPATIENTPHYAPP);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDODByPhysicianApplication_RQ_Input
        {
            public string INPATIENTPHYAPP
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
        public BindingList<DietOrderDetail.GetDODByPhysicianApplication_RQ_Class> GetDODByPhysicianApplication_RQ(GetDODByPhysicianApplication_RQ_Input input)
        {
            var ret = DietOrderDetail.GetDODByPhysicianApplication_RQ(input.INPATIENTPHYAPP, input.injectionSQL);
            return ret;
        }

        public class GetDietOrderDetailForWorkList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DietOrderDetail.GetDietOrderDetailForWorkList_Class> GetDietOrderDetailForWorkList(GetDietOrderDetailForWorkList_Input input)
        {
            var ret = DietOrderDetail.GetDietOrderDetailForWorkList(input.injectionSQL);
            return ret;
        }
    }
}