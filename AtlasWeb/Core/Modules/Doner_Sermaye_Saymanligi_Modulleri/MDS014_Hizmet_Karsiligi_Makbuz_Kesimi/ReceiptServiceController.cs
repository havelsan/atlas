//$33B126BC
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
    public partial class ReceiptServiceController : Controller
    {
        public class ReceiptReportQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.ReceiptReportQuery_Class> ReceiptReportQuery(ReceiptReportQuery_Input input)
        {
            var ret = Receipt.ReceiptReportQuery(input.PARAMDEBFOLOBJID);
            return ret;
        }

        public class EmergentPatientRecordFormQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.EmergentPatientRecordFormQuery_Class> EmergentPatientRecordFormQuery(EmergentPatientRecordFormQuery_Input input)
        {
            var ret = Receipt.EmergentPatientRecordFormQuery(input.PARAMDEBFOLOBJID);
            return ret;
        }

        public class ReceiptCreditCardReportQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.ReceiptCreditCardReportQuery_Class> ReceiptCreditCardReportQuery(ReceiptCreditCardReportQuery_Input input)
        {
            var ret = Receipt.ReceiptCreditCardReportQuery(input.PARAMDEBFOLOBJID);
            return ret;
        }

        public class GetByObjectID_Input
        {
            public string PARAMOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt> GetByObjectID(GetByObjectID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Receipt.GetByObjectID(objectContext, input.PARAMOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ReceiptDetailsQuery_Input
        {
            public string PARAMDEBFOLOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.ReceiptDetailsQuery_Class> ReceiptDetailsQuery(ReceiptDetailsQuery_Input input)
        {
            var ret = Receipt.ReceiptDetailsQuery(input.PARAMDEBFOLOBJID);
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
        public BindingList<Receipt> GetByEpisode(GetByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Receipt.GetByEpisode(objectContext, input.PARAMEPISODE, input.PARAMSTATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetReceiptDebentures_Input
        {
            public string PARAMOBJID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.GetReceiptDebentures_Class> GetReceiptDebentures(GetReceiptDebentures_Input input)
        {
            var ret = Receipt.GetReceiptDebentures(input.PARAMOBJID);
            return ret;
        }

        public class GetReceipts_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.GetReceipts_Class> GetReceipts(GetReceipts_Input input)
        {
            var ret = Receipt.GetReceipts(input.injectionSQL);
            return ret;
        }

        public class OrthesisToothIVFPatientParticipationReport_Input
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

            public int RESOURCEFLAG
            {
                get;
                set;
            }

            public IList<string> RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.OrthesisToothIVFPatientParticipationReport_Class> OrthesisToothIVFPatientParticipationReport(OrthesisToothIVFPatientParticipationReport_Input input)
        {
            var ret = Receipt.OrthesisToothIVFPatientParticipationReport(input.STARTDATE, input.ENDDATE, input.RESOURCEFLAG, input.RESOURCE);
            return ret;
        }

        public class GetForeignSgkPatientParticipationByDate_Input
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

            public IList<string> RESOURCE
            {
                get;
                set;
            }

            public int RESOURCEFLAG
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt.GetForeignSgkPatientParticipationByDate_Class> GetForeignSgkPatientParticipationByDate(GetForeignSgkPatientParticipationByDate_Input input)
        {
            var ret = Receipt.GetForeignSgkPatientParticipationByDate(input.STARTDATE, input.ENDDATE, input.RESOURCE, input.RESOURCEFLAG);
            return ret;
        }

        public class GetByEpisodeStateAndDocumentNo_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string STATE
            {
                get;
                set;
            }

            public string DOCUMENTNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Receipt> GetByEpisodeStateAndDocumentNo(GetByEpisodeStateAndDocumentNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Receipt.GetByEpisodeStateAndDocumentNo(objectContext, input.EPISODE, input.STATE, input.DOCUMENTNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeStateAndCreditCardDocumentNo_Input
        {
            public string EPISODE
            {
                get;
                set;
            }

            public string STATE
            {
                get;
                set;
            }

            public string DOCUMENTNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Receipt> GetByEpisodeStateAndCreditCardDocumentNo(GetByEpisodeStateAndCreditCardDocumentNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Receipt.GetByEpisodeStateAndCreditCardDocumentNo(objectContext, input.EPISODE, input.STATE, input.DOCUMENTNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}