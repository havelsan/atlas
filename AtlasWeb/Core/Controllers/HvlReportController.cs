using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class HvlReportController : Controller
    {
        public class ReportInput
        {
            public string ReportName { get; set; }
            public string JSONParameters { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public BindingList<ResUser.GetDoctorAndNurseNQL_Class> RenderReportTest()
        {

            BindingList<ResUser.GetDoctorAndNurseNQL_Class> result = null;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                result = ResUser.GetDoctorAndNurseNQL(objectContext, "");
            }

            return result;
        }
    }
}