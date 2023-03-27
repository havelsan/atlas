//$2872FDBF
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
    public partial class DeleteRecordDocumentDestroyableServiceController : Controller
    {
        public class GetDeleteRecordDocDestroyableCensusReportQuery_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DeleteRecordDocumentDestroyable.GetDeleteRecordDocDestroyableCensusReportQuery_Class> GetDeleteRecordDocDestroyableCensusReportQuery(GetDeleteRecordDocDestroyableCensusReportQuery_Input input)
        {
            var ret = DeleteRecordDocumentDestroyable.GetDeleteRecordDocDestroyableCensusReportQuery(input.TERMID);
            return ret;
        }

        public class CensusReportNQL_DeleteRecordDocument_Input
        {
            public string TERMID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DeleteRecordDocumentDestroyable.CensusReportNQL_DeleteRecordDocument_Class> CensusReportNQL_DeleteRecordDocument(CensusReportNQL_DeleteRecordDocument_Input input)
        {
            var ret = DeleteRecordDocumentDestroyable.CensusReportNQL_DeleteRecordDocument(input.TERMID);
            return ret;
        }

        public class DeleteRecordDocumentDestroyableDestroyedReportRQ_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ_Class> DeleteRecordDocumentDestroyableDestroyedReportRQ(DeleteRecordDocumentDestroyableDestroyedReportRQ_Input input)
        {
            var ret = DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableDestroyedReportRQ(input.TTOBJECTID);
            return ret;
        }
    }
}