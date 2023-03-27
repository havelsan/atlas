//$3A1BFF48
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
    public partial class MainCashOfficeOperationServiceController : Controller
    {
        public class CashOfficeReceiptDocumentReportQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class> CashOfficeReceiptDocumentReportQuery(CashOfficeReceiptDocumentReportQuery_Input input)
        {
            var ret = MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery(input.PARAMDEBFOLOBJID);
            return ret;
        }

        public class ChattelReceiptReportQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<MainCashOfficeOperation.ChattelReceiptReportQuery_Class> ChattelReceiptReportQuery(ChattelReceiptReportQuery_Input input)
        {
            var ret = MainCashOfficeOperation.ChattelReceiptReportQuery(input.PARAMDEBFOLOBJID);
            return ret;
        }

        public class GetCashOfficeOpsByDateAndType_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public IList<string> TYPE
            {
                get;
                set;
            }

            public int TYPECONTROL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class> GetCashOfficeOpsByDateAndType(GetCashOfficeOpsByDateAndType_Input input)
        {
            var ret = MainCashOfficeOperation.GetCashOfficeOpsByDateAndType(input.STARTDATE, input.ENDDATE, input.TYPE, input.TYPECONTROL);
            return ret;
        }
    }
}