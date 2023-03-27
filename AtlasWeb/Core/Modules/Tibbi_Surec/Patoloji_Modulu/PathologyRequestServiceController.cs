//$48A7DF04
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
    public partial class PathologyRequestServiceController : Controller
    {
        public class PathologyReqStateInfoNQL_Input
        {
            public string PARAMPATHOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.PathologyReqStateInfoNQL_Class> PathologyReqStateInfoNQL(PathologyReqStateInfoNQL_Input input)
        {
            var ret = PathologyRequest.PathologyReqStateInfoNQL(input.PARAMPATHOBJID);
            return ret;
        }

        public class PathologyResultReportQuery_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.PathologyResultReportQuery_Class> PathologyResultReportQuery(PathologyResultReportQuery_Input input)
        {
            var ret = PathologyRequest.PathologyResultReportQuery(input.PARAMOBJID);
            return ret;
        }

        public class PathologyRequestPatientInfoReportQuery_Input
        {
            public string PARAMPATOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class> PathologyRequestPatientInfoReportQuery(PathologyRequestPatientInfoReportQuery_Input input)
        {
            var ret = PathologyRequest.PathologyRequestPatientInfoReportQuery(input.PARAMPATOBJID);
            return ret;
        }

        public class PathologyRequestInfoStickerNQL_Input
        {
            public string PARAMPATHOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.PathologyRequestInfoStickerNQL_Class> PathologyRequestInfoStickerNQL(PathologyRequestInfoStickerNQL_Input input)
        {
            var ret = PathologyRequest.PathologyRequestInfoStickerNQL(input.PARAMPATHOBJID);
            return ret;
        }

        public class PathologyResultPatientInfoReportQuery_Input
        {
            public string PARAMPATOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.PathologyResultPatientInfoReportQuery_Class> PathologyResultPatientInfoReportQuery(PathologyResultPatientInfoReportQuery_Input input)
        {
            var ret = PathologyRequest.PathologyResultPatientInfoReportQuery(input.PARAMPATOBJID);
            return ret;
        }

        public class SearchPathologies_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<PathologyRequest.SearchPathologies_Class> SearchPathologies(SearchPathologies_Input input)
        {
            var ret = PathologyRequest.SearchPathologies(input.injectionSQL);
            return ret;
        }

        public class PathologyRequestBarcodeNQL_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<PathologyRequest.PathologyRequestBarcodeNQL_Class> PathologyRequestBarcodeNQL(PathologyRequestBarcodeNQL_Input input)
        {
            var ret = PathologyRequest.PathologyRequestBarcodeNQL(input.PARAMOBJID);
            return ret;
        }
    }
}