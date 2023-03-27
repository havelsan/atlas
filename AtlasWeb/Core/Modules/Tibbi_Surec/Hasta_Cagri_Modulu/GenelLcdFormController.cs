using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using Core.Security;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class GenelLcdFormController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GenelLcdFormViewModel GenelLcdFormOpen([FromQuery] GenelLcdFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                viewModel.queueList = ExaminationQueueDefinition.GetExaminationQueueDefs(objectContext, "WHERE ISACTIVEQUEUE=1").OrderBy(x => x.Name).ToList();
                return viewModel;
            }
        }

    }
    public class GenelLcdFormViewModel
    {
        public List<ExaminationQueueDefinition> queueList = new List<ExaminationQueueDefinition>();
    }
}