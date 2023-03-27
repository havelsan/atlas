//$80065F25
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
    public partial class InpatientPrescriptionServiceController : Controller
    {
        public class GetDrugsFromExternalPharmacyReportQuery_Input
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

            public string PHARMACYID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class> GetDrugsFromExternalPharmacyReportQuery(GetDrugsFromExternalPharmacyReportQuery_Input input)
        {
            var ret = InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery(input.STARTDATE, input.ENDDATE, input.PHARMACYID);
            return ret;
        }

        public class GetInPatientDrugPrescriptionTotalReportQuery_Input
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
        public BindingList<InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery_Class> GetInPatientDrugPrescriptionTotalReportQuery(GetInPatientDrugPrescriptionTotalReportQuery_Input input)
        {
            var ret = InpatientPrescription.GetInPatientDrugPrescriptionTotalReportQuery(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetInpatientPrescriptionDrugsQuery_Input
        {
            public Guid PRESCRIPTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class> GetInpatientPrescriptionDrugsQuery(GetInpatientPrescriptionDrugsQuery_Input input)
        {
            var ret = InpatientPrescription.GetInpatientPrescriptionDrugsQuery(input.PRESCRIPTIONID);
            return ret;
        }

        public class GetInpatientPrescriptionReportQuery_Input
        {
            public Guid TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientPrescription.GetInpatientPrescriptionReportQuery_Class> GetInpatientPrescriptionReportQuery(GetInpatientPrescriptionReportQuery_Input input)
        {
            var ret = InpatientPrescription.GetInpatientPrescriptionReportQuery(input.TTOBJECTID);
            return ret;
        }

        public class GetDetailInPresciprtionReportQuery_Input
        {
            public Guid PRESCRIPTIONID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientPrescription.GetDetailInPresciprtionReportQuery_Class> GetDetailInPresciprtionReportQuery(GetDetailInPresciprtionReportQuery_Input input)
        {
            var ret = InpatientPrescription.GetDetailInPresciprtionReportQuery(input.PRESCRIPTIONID);
            return ret;
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
        public BindingList<InpatientPrescription> GetBySubEpisode(GetBySubEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InpatientPrescription.GetBySubEpisode(objectContext, input.SUBEPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}