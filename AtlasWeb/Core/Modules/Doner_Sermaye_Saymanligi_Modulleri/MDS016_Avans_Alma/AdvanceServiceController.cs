//$94379869
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
    public partial class AdvanceServiceController : Controller
    {
        public class AdvanceDocumentCreditCardReportQuery_Input
        {
            public string PARAMADVANCEOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Advance.AdvanceDocumentCreditCardReportQuery_Class> AdvanceDocumentCreditCardReportQuery(AdvanceDocumentCreditCardReportQuery_Input input)
        {
            var ret = Advance.AdvanceDocumentCreditCardReportQuery(input.PARAMADVANCEOBJID);
            return ret;
        }

        public class GetAdvanceDebentures_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Advance.GetAdvanceDebentures_Class> GetAdvanceDebentures(GetAdvanceDebentures_Input input)
        {
            var ret = Advance.GetAdvanceDebentures(input.PARAMOBJID);
            return ret;
        }

        public class GetByEpisode_Input
        {
            public string PARAMEPISODE
            {
                get;
                set;
            }

            public string PARAMSTATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Advance> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Advance.GetByEpisode(objectContext, input.PARAMEPISODE, input.PARAMSTATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class AdvanceDocumentCashReportQuery_Input
        {
            public string PARAMADVANCEOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Advance.AdvanceDocumentCashReportQuery_Class> AdvanceDocumentCashReportQuery(AdvanceDocumentCashReportQuery_Input input)
        {
            var ret = Advance.AdvanceDocumentCashReportQuery(input.PARAMADVANCEOBJID);
            return ret;
        }
    }
}