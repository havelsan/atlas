//$B1BCEF5B
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class LaboratoryTestDefinitionServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public Boolean GetLaboratoryTestDefinitionFromLIS()
        {
            var ret = LaboratoryTestDefinition.GetLaboratoryTestDefinitionFromLIS();
            return ret;
        }
    }
}