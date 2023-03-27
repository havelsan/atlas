//$8087F937
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
    public partial class ReceiptDocumentServiceController : Controller
    {
        public class GetPatientPaymentDetail_Input
        {
            public System.Guid accTrxGuid
            {
                get;
                set;
            }

            public TTObjectClasses.ReceiptDocument receiptDoc
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.PatientPaymentDetail GetPatientPaymentDetail(GetPatientPaymentDetail_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.receiptDoc != null)
                    input.receiptDoc = (TTObjectClasses.ReceiptDocument)objectContext.AddObject(input.receiptDoc);
                var ret = ReceiptDocument.GetPatientPaymentDetail(input.accTrxGuid, input.receiptDoc);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetCancelledReceiptDocument_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReceiptDocument.OLAP_GetCancelledReceiptDocument_Class> OLAP_GetCancelledReceiptDocument(OLAP_GetCancelledReceiptDocument_Input input)
        {
            var ret = ReceiptDocument.OLAP_GetCancelledReceiptDocument(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetReceiptDocument_Input
        {
            public string ROBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReceiptDocument.GetReceiptDocument_Class> GetReceiptDocument(GetReceiptDocument_Input input)
        {
            var ret = ReceiptDocument.GetReceiptDocument(input.ROBJECTID);
            return ret;
        }

        public class GetByDocumentNoAndState_Input
        {
            public string PARAMDOCNO
            {
                get;
                set;
            }

            public string PARAMSTATE
            {
                get;
                set;
            }

            public string PARAMEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReceiptDocument> GetByDocumentNoAndState(GetByDocumentNoAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ReceiptDocument.GetByDocumentNoAndState(objectContext, input.PARAMDOCNO, input.PARAMSTATE, input.PARAMEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetReceiptDocument_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ReceiptDocument.OLAP_GetReceiptDocument_Class> OLAP_GetReceiptDocument(OLAP_GetReceiptDocument_Input input)
        {
            var ret = ReceiptDocument.OLAP_GetReceiptDocument(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetByCreditCardDocumentNoAndState_Input
        {
            public string PARAMDOCNO
            {
                get;
                set;
            }

            public string PARAMSTATE
            {
                get;
                set;
            }

            public string PARAMEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ReceiptDocument> GetByCreditCardDocumentNoAndState(GetByCreditCardDocumentNoAndState_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ReceiptDocument.GetByCreditCardDocumentNoAndState(objectContext, input.PARAMDOCNO, input.PARAMSTATE, input.PARAMEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}