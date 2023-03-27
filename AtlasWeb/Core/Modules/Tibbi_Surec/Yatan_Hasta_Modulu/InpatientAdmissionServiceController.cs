//$FAA51576
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
    public partial class InpatientAdmissionServiceController : Controller
    {
        public class GetDischargedConclusion_Input
        {
            public TTObjectClasses.InpatientAdmission inpatientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetDischargedConclusion(GetDischargedConclusion_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.inpatientAdmission != null)
                    input.inpatientAdmission = (TTObjectClasses.InpatientAdmission)objectContext.AddObject(input.inpatientAdmission);
                var ret = InpatientAdmission.GetDischargedConclusion(input.inpatientAdmission);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetExcessOfRealBedDayToBedProcedure_Input
        {
            public TTObjectClasses.InpatientAdmission inpatientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public int GetExcessOfRealBedDayToBedProcedure(GetExcessOfRealBedDayToBedProcedure_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.inpatientAdmission != null)
                    input.inpatientAdmission = (TTObjectClasses.InpatientAdmission)objectContext.AddObject(input.inpatientAdmission);
                var ret = InpatientAdmission.GetExcessOfRealBedDayToBedProcedure(input.inpatientAdmission);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetLatestDischargeDate_Input
        {
            public TTObjectClasses.InpatientAdmission inpatientAdmission
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetLatestDischargeDate(GetLatestDischargeDate_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.inpatientAdmission != null)
                    input.inpatientAdmission = (TTObjectClasses.InpatientAdmission)objectContext.AddObject(input.inpatientAdmission);
                var ret = InpatientAdmission.GetLatestDischargeDate(input.inpatientAdmission);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetInpatientFolderInfo_Input
        {
            public string INPATIENTADMISSION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetInpatientFolderInfo_Class> GetInpatientFolderInfo(GetInpatientFolderInfo_Input input)
        {
            var ret = InpatientAdmission.GetInpatientFolderInfo(input.INPATIENTADMISSION);
            return ret;
        }

        public class GetInpatientDischargeInfo_Input
        {
            public string INPATIENTADMISSION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetInpatientDischargeInfo_Class> GetInpatientDischargeInfo(GetInpatientDischargeInfo_Input input)
        {
            var ret = InpatientAdmission.GetInpatientDischargeInfo(input.INPATIENTADMISSION);
            return ret;
        }

        public class GetInpatientPrisonerDelivery_Input
        {
            public string INPATIENTADMISSION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetInpatientPrisonerDelivery_Class> GetInpatientPrisonerDelivery(GetInpatientPrisonerDelivery_Input input)
        {
            var ret = InpatientAdmission.GetInpatientPrisonerDelivery(input.INPATIENTADMISSION);
            return ret;
        }

        public class GetInpatientAdmissionDeclaration_Input
        {
            public string INPATIENTADMISSION
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetInpatientAdmissionDeclaration_Class> GetInpatientAdmissionDeclaration(GetInpatientAdmissionDeclaration_Input input)
        {
            var ret = InpatientAdmission.GetInpatientAdmissionDeclaration(input.INPATIENTADMISSION);
            return ret;
        }

        public class OLAP_GetLastTreatmentClinic_Input
        {
            public string EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.OLAP_GetLastTreatmentClinic_Class> OLAP_GetLastTreatmentClinic(OLAP_GetLastTreatmentClinic_Input input)
        {
            var ret = InpatientAdmission.OLAP_GetLastTreatmentClinic(input.EPISODEID);
            return ret;
        }

        public class OLAP_GetDischargedInpatient_Input
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
        public BindingList<InpatientAdmission.OLAP_GetDischargedInpatient_Class> OLAP_GetDischargedInpatient(OLAP_GetDischargedInpatient_Input input)
        {
            var ret = InpatientAdmission.OLAP_GetDischargedInpatient(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class OLAP_GetFirstTreatmentClinic_Input
        {
            public string EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.OLAP_GetFirstTreatmentClinic_Class> OLAP_GetFirstTreatmentClinic(OLAP_GetFirstTreatmentClinic_Input input)
        {
            var ret = InpatientAdmission.OLAP_GetFirstTreatmentClinic(input.EPISODEID);
            return ret;
        }

        public class GetUnacceptedInLimitedTime_Input
        {
            public DateTime LIMITREQUESTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission> GetUnacceptedInLimitedTime(GetUnacceptedInLimitedTime_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InpatientAdmission.GetUnacceptedInLimitedTime(objectContext, input.LIMITREQUESTDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDischargeNumberForEtiquetteOffice_Input
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
        public BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class> GetDischargeNumberForEtiquetteOffice(GetDischargeNumberForEtiquetteOffice_Input input)
        {
            var ret = InpatientAdmission.GetDischargeNumberForEtiquetteOffice(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetUrgentPatientListByDate_Input
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
        public BindingList<InpatientAdmission.GetUrgentPatientListByDate_Class> GetUrgentPatientListByDate(GetUrgentPatientListByDate_Input input)
        {
            var ret = InpatientAdmission.GetUrgentPatientListByDate(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class OLAP_GetCancelledDischargedInpatient_Input
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
        public BindingList<InpatientAdmission.OLAP_GetCancelledDischargedInpatient_Class> OLAP_GetCancelledDischargedInpatient(OLAP_GetCancelledDischargedInpatient_Input input)
        {
            var ret = InpatientAdmission.OLAP_GetCancelledDischargedInpatient(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetDischargedPatientListByDischargeNumber_Input
        {
            public long DISCHARGESTARTNO
            {
                get;
                set;
            }

            public long DISCHARGEENDNO
            {
                get;
                set;
            }

            public int FILTER
            {
                get;
                set;
            }

            public string CLINIC
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class> GetDischargedPatientListByDischargeNumber(GetDischargedPatientListByDischargeNumber_Input input)
        {
            var ret = InpatientAdmission.GetDischargedPatientListByDischargeNumber(input.DISCHARGESTARTNO, input.DISCHARGEENDNO, input.FILTER, input.CLINIC, input.STARTDATE);
            return ret;
        }

        public class GetDischargedPatientListByDate_Input
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

            public string CLINIC
            {
                get;
                set;
            }

            public int FILTER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetDischargedPatientListByDate_Class> GetDischargedPatientListByDate(GetDischargedPatientListByDate_Input input)
        {
            var ret = InpatientAdmission.GetDischargedPatientListByDate(input.STARTDATE, input.ENDDATE, input.CLINIC, input.FILTER);
            return ret;
        }

        public class GetDischargeNumberForEtiquetteUnit_Input
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
        public BindingList<InpatientAdmission.GetDischargeNumberForEtiquetteUnit_Class> GetDischargeNumberForEtiquetteUnit(GetDischargeNumberForEtiquetteUnit_Input input)
        {
            var ret = InpatientAdmission.GetDischargeNumberForEtiquetteUnit(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        [HttpPost]
        public BindingList<InpatientAdmission> GetDischargedInPatientAdmissions()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InpatientAdmission.GetDischargedInPatientAdmissions(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class PlastikCerrahiIstatistik_Input
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

            public string CLINIC
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.PlastikCerrahiIstatistik_Class> PlastikCerrahiIstatistik(PlastikCerrahiIstatistik_Input input)
        {
            var ret = InpatientAdmission.PlastikCerrahiIstatistik(input.STARTDATE, input.ENDDATE, input.CLINIC);
            return ret;
        }

        public class SelectActiveInpatientAdmissionCollectedInvoiceRQ_Input
        {
            public Guid EPISODEID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ_Class> SelectActiveInpatientAdmissionCollectedInvoiceRQ(SelectActiveInpatientAdmissionCollectedInvoiceRQ_Input input)
        {
            var ret = InpatientAdmission.SelectActiveInpatientAdmissionCollectedInvoiceRQ(input.EPISODEID);
            return ret;
        }

        public class GetForeignInpatientsNQL_Input
        {
            public DateTime ACTIONENDDATE
            {
                get;
                set;
            }

            public DateTime ACTIONSTARTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetForeignInpatientsNQL_Class> GetForeignInpatientsNQL(GetForeignInpatientsNQL_Input input)
        {
            var ret = InpatientAdmission.GetForeignInpatientsNQL(input.ACTIONENDDATE, input.ACTIONSTARTDATE);
            return ret;
        }

        public class GetInPatientEtiquette_Input
        {
            public string OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InpatientAdmission.GetInPatientEtiquette_Class> GetInPatientEtiquette(GetInPatientEtiquette_Input input)
        {
            var ret = InpatientAdmission.GetInPatientEtiquette(input.OBJECTID);
            return ret;
        }

        public class GetDoctorFaultAmount_Input
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
        public BindingList<InpatientAdmission.GetDoctorFaultAmount_Class> GetDoctorFaultAmount(GetDoctorFaultAmount_Input input)
        {
            var ret = InpatientAdmission.GetDoctorFaultAmount(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetInpatientAdmissionByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<InpatientAdmission> GetInpatientAdmissionByEpisode(GetInpatientAdmissionByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InpatientAdmission.GetInpatientAdmissionByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
    }
}