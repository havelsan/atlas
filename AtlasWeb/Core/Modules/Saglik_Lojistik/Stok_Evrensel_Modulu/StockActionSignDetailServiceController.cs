//$AE648100
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
    public partial class StockActionSignDetailServiceController : Controller
    {
        public class StockActionSignUsersMethod_Input
        {
            public TTObjectClasses.SignUserTypeEnum[] signUserTypes
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public System.Collections.Generic.List<TTObjectClasses.StockActionSignDetail> StockActionSignUsersMethod(StockActionSignUsersMethod_Input input)
        {
            var ret = StockActionSignDetail.StockActionSignUsersMethod(input.signUserTypes);
            return ret;
        }
    }
}