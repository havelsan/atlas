//$05238581
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
    public partial class CostActionMaterialServiceController : Controller
    {
        public class GetPreviousCostAction_Input
        {
            public Guid MATERIALOBJECTID
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public Guid STOREID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Maliyet_Analiz_Yeni, TTRoleNames.Maliyet_Analiz_Onay)]
        public BindingList<CostActionMaterial.GetPreviousCostAction_Class> GetPreviousCostAction(GetPreviousCostAction_Input input)
        {
            var ret = CostActionMaterial.GetPreviousCostAction(input.MATERIALOBJECTID, input.ENDDATE, input.STOREID);
            return ret;
        }
    }
}