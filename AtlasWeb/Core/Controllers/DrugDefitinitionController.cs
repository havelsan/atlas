using Core.Models;
using Core.Services;
using Infrastructure.Filters;
using Infrastructure.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Controllers
{

    public class DrugDefinitionsController : Microsoft.AspNet.OData.ODataController
    {
        [AllowAnonymous]
        [HttpGet]
        
        [EnableQuery()]

        public IActionResult Get(string info)
        {

            var context = AtlasContextFactory.Instance.CreateContext();
            return Ok(context.GetType().GetProperty(info).GetValue(context));

        }


    }
    
}