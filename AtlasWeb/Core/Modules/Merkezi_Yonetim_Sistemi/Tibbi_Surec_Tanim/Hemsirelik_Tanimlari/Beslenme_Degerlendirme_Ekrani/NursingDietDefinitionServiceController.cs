//$7369B3E4
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
    public partial class NursingDietDefinitionServiceController : Controller
    {
        public class GetNursingDietList_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<NursingDietDefinition.GetNursingDietList_Class> GetNursingDietList(GetNursingDietList_Input input)
        {
            var ret = NursingDietDefinition.GetNursingDietList(input.injectionSQL);
            return ret;
        }
    }
}