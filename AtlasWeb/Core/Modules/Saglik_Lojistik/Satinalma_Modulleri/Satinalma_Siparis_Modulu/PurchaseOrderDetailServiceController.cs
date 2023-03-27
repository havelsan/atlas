//$E64658A6
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
    public partial class PurchaseOrderDetailServiceController : Controller
    {
        public class GetByStatus_Input
        {
            public int STATUS
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PurchaseOrderDetail> GetByStatus(GetByStatus_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = PurchaseOrderDetail.GetByStatus(objectContext, input.STATUS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}