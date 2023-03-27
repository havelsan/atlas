//$1C52B9EB
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
    public partial class BloodBankBloodProductsServiceController : Controller
    {
        public class GetBloodProductBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }

            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BloodBankBloodProducts.GetBloodProductBySubEpisode_Class> GetBloodProductBySubEpisode(GetBloodProductBySubEpisode_Input input)
        {
            var ret = BloodBankBloodProducts.GetBloodProductBySubEpisode(input.SUBEPISODE, input.EPISODE);
            return ret;
        }

        public class GetExpiredBloodProductsToCancel_Input
        {
            public DateTime CHECKDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BloodBankBloodProducts> GetExpiredBloodProductsToCancel(GetExpiredBloodProductsToCancel_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BloodBankBloodProducts.GetExpiredBloodProductsToCancel(objectContext, input.CHECKDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBloodProductByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BloodBankBloodProducts.GetBloodProductByEpisode_Class> GetBloodProductByEpisode(GetBloodProductByEpisode_Input input)
        {
            var ret = BloodBankBloodProducts.GetBloodProductByEpisode(input.EPISODE);
            return ret;
        }

        public class OLAP_GetBloodProducts_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<BloodBankBloodProducts.OLAP_GetBloodProducts_Class> OLAP_GetBloodProducts(OLAP_GetBloodProducts_Input input)
        {
            var ret = BloodBankBloodProducts.OLAP_GetBloodProducts(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetExpiredBloodProducts_Input
        {
            public DateTime CHECKDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<BloodBankBloodProducts> GetExpiredBloodProducts(GetExpiredBloodProducts_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = BloodBankBloodProducts.GetExpiredBloodProducts(objectContext, input.CHECKDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}