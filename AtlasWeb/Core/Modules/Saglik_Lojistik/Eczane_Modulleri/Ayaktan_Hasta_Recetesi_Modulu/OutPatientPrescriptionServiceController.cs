//$A06BBEFD
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
    public partial class OutPatientPrescriptionServiceController : Controller
    {
        public class GetOutPatientDrugPrescriptionTotalReportQuery_Input
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
        }

        [HttpPost]
        public BindingList<OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery_Class> GetOutPatientDrugPrescriptionTotalReportQuery(GetOutPatientDrugPrescriptionTotalReportQuery_Input input)
        {
            var ret = OutPatientPrescription.GetOutPatientDrugPrescriptionTotalReportQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetReceiptNoNQL_Input
        {
            public string RECEIPTNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription> GetReceiptNoNQL(GetReceiptNoNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OutPatientPrescription.GetReceiptNoNQL(objectContext, input.RECEIPTNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOutpatientPrescriptionReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription.GetOutpatientPrescriptionReportQuery_Class> GetOutpatientPrescriptionReportQuery(GetOutpatientPrescriptionReportQuery_Input input)
        {
            var ret = OutPatientPrescription.GetOutpatientPrescriptionReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class GetOutPatientPrescriptionByEpisodeIDs_Input
        {
            public Guid OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription> GetOutPatientPrescriptionByEpisodeIDs(GetOutPatientPrescriptionByEpisodeIDs_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OutPatientPrescription.GetOutPatientPrescriptionByEpisodeIDs(objectContext, input.OBJECTIDS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOutPatientPrescriptionByObjectIDs_Input
        {
            public Guid OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs_Class> GetOutPatientPrescriptionByObjectIDs(GetOutPatientPrescriptionByObjectIDs_Input input)
        {
            var ret = OutPatientPrescription.GetOutPatientPrescriptionByObjectIDs(input.OBJECTIDS);
            return ret;
        }

        public class GetDetailOutPresciprtionReportQuery_Input
        {
            public Guid PRESCRIPTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription.GetDetailOutPresciprtionReportQuery_Class> GetDetailOutPresciprtionReportQuery(GetDetailOutPresciprtionReportQuery_Input input)
        {
            var ret = OutPatientPrescription.GetDetailOutPresciprtionReportQuery(input.PRESCRIPTIONID);
            return ret;
        }

        public class GetOutpatientPrescriptionByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<OutPatientPrescription> GetOutpatientPrescriptionByEpisode(GetOutpatientPrescriptionByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OutPatientPrescription.GetOutpatientPrescriptionByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBySubEpisode_Input
        {
            public Guid SUBEPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<OutPatientPrescription> GetBySubEpisode(GetBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = OutPatientPrescription.GetBySubEpisode(objectContext, input.SUBEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}