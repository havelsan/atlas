//$E1A26799
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
    public partial class CensusFixedServiceController : Controller
    {
        public class GetCensusFixedCensusReportQuery_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<CensusFixed.GetCensusFixedCensusReportQuery_Class> GetCensusFixedCensusReportQuery(GetCensusFixedCensusReportQuery_Input input)
        {
            var ret = CensusFixed.GetCensusFixedCensusReportQuery(input.TERMID);
            return ret;
        }

        public class CensusFixedReportForReportQuery_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<CensusFixed.CensusFixedReportForReportQuery_Class> CensusFixedReportForReportQuery(CensusFixedReportForReportQuery_Input input)
        {
            var ret = CensusFixed.CensusFixedReportForReportQuery(input.OBJECTID);
            return ret;
        }
    }
}