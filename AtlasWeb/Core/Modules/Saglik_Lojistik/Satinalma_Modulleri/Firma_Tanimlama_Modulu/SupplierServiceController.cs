//$D27A7538
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
    public partial class SupplierServiceController : Controller
    {
        public class SupplierDefFormNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Supplier.SupplierDefFormNQL_Class> SupplierDefFormNQL(SupplierDefFormNQL_Input input)
        {
            var ret = Supplier.SupplierDefFormNQL(input.injectionSQL);
            return ret;
        }

        public class GetSupplierRecordReportQuery_Input
        {
            public SupplierTypeEnum SUPPLIERTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Supplier.GetSupplierRecordReportQuery_Class> GetSupplierRecordReportQuery(GetSupplierRecordReportQuery_Input input)
        {
            var ret = Supplier.GetSupplierRecordReportQuery(input.SUPPLIERTYPE);
            return ret;
        }
    }
}