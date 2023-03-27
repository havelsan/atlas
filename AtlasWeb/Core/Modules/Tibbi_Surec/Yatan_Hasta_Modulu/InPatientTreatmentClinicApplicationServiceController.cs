//$9C3AE5FD
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
    public partial class InPatientTreatmentClinicApplicationServiceController : Controller
    {
        public class GetActiveByPhysicalStateClinic_Input
        {
            public Guid PHYSICALSTATECLINIC
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetActiveByPhysicalStateClinic(GetActiveByPhysicalStateClinic_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetActiveByPhysicalStateClinic(objectContext, input.PHYSICALSTATECLINIC);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetInpatientListReportNQL_Input
        {
            public Guid PHYSICALSTATECLINIC
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientListReportNQL_Class> GetInpatientListReportNQL(GetInpatientListReportNQL_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientListReportNQL(input.PHYSICALSTATECLINIC);
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientStatistics_Class> GetInpatientStatistics()
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientStatistics();
            return ret;
        }

        public class GetInpatientStatisticsByDate_Input
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

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate_Class> GetInpatientStatisticsByDate(GetInpatientStatisticsByDate_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientStatisticsByDate(input.STARTDATE, input.ENDDATE, input.MASTERRESOURCE);
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetAllActiveInPatientTreatmentClinicApp()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetAllActiveInPatientTreatmentClinicApp(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeAndProcedureSpeciality_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid PROCEDURESPECIALITY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndProcedureSpeciality(GetByEpisodeAndProcedureSpeciality_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetByEpisodeAndProcedureSpeciality(objectContext, input.EPISODE, input.PROCEDURESPECIALITY);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByEpisodeAndMasterResourceReport_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport_Class> GetByEpisodeAndMasterResourceReport(GetByEpisodeAndMasterResourceReport_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResourceReport(input.EPISODE, input.MASTERRESOURCE);
            return ret;
        }

        public class GetByEpisodeAndProcedureSpecialityASC_Input
        {
            public Guid PROCEDURESPECIALITY
            {
                get;
                set;
            }

            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndProcedureSpecialityASC(GetByEpisodeAndProcedureSpecialityASC_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetByEpisodeAndProcedureSpecialityASC(objectContext, input.PROCEDURESPECIALITY, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllClinicDischargeDatesByEpisode_Input
        {
            public string EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetAllClinicDischargeDatesByEpisode(GetAllClinicDischargeDatesByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetAllClinicDischargeDatesByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetpatientListReportByDaysNQL_Input
        {
            public int INPATIENTDAYS
            {
                get;
                set;
            }

            public Guid PHYSICALSTATECLINIC
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL_Class> GetpatientListReportByDaysNQL(GetpatientListReportByDaysNQL_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetpatientListReportByDaysNQL(input.INPATIENTDAYS, input.PHYSICALSTATECLINIC);
            return ret;
        }

        public class GetpatientListReportByInpatientDayNQL_Input
        {
            public Guid PHYSICALSTATECLINIC
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public int INPATIENTDAYS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL_Class> GetpatientListReportByInpatientDayNQL(GetpatientListReportByInpatientDayNQL_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetpatientListReportByInpatientDayNQL(input.PHYSICALSTATECLINIC, input.STARTDATE, input.INPATIENTDAYS);
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientByPatientGroup_Class> GetInpatientByPatientGroup()
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientByPatientGroup();
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.OLAP_YatanHasta_Class> OLAP_YatanHasta()
        {
            var ret = InPatientTreatmentClinicApplication.OLAP_YatanHasta();
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInPatientBeds_Class> GetInPatientBeds()
        {
            var ret = InPatientTreatmentClinicApplication.GetInPatientBeds();
            return ret;
        }

        public class GetpatientListReportByDateNQL_Input
        {
            public Guid PHYSICALSTATECLINIC
            {
                get;
                set;
            }

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
        public BindingList<InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL_Class> GetpatientListReportByDateNQL(GetpatientListReportByDateNQL_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetpatientListReportByDateNQL(input.PHYSICALSTATECLINIC, input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetInpatientBedsByResWard_Input
        {
            public Guid SELECTEDWARD
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientBedsByResWard_Class> GetInpatientBedsByResWard(GetInpatientBedsByResWard_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientBedsByResWard(input.SELECTEDWARD);
            return ret;
        }

        public class GetInpatientInformation_RQ_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetInpatientInformation_RQ_Class> GetInpatientInformation_RQ(GetInpatientInformation_RQ_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetInpatientInformation_RQ(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetJustInpatientStatistic_Class> GetJustInpatientStatistic()
        {
            var ret = InPatientTreatmentClinicApplication.GetJustInpatientStatistic();
            return ret;
        }

        public class GetByEpisodeAndMasterResource_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetByEpisodeAndMasterResource(GetByEpisodeAndMasterResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetByEpisodeAndMasterResource(objectContext, input.EPISODE, input.MASTERRESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetActiveInpatientTrtClinicAppByMasterResource_Input
        {
            public Guid MASTERRESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class> GetActiveInpatientTrtClinicAppByMasterResource(GetActiveInpatientTrtClinicAppByMasterResource_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource(input.MASTERRESOURCE);
            return ret;
        }

        public class GetBySubEpisodeAndProcedureSpeciality_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }

            public Guid SUBEPISODE
            {
                get;
                set;
            }

            public Guid PROCEDURESPECIALITY
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<InPatientTreatmentClinicApplication> GetBySubEpisodeAndProcedureSpeciality(GetBySubEpisodeAndProcedureSpeciality_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = InPatientTreatmentClinicApplication.GetBySubEpisodeAndProcedureSpeciality(objectContext, input.EPISODE, input.SUBEPISODE, input.PROCEDURESPECIALITY);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetInPatientInfoByPatients_Input
        {
            public IList<Guid> PATIENTS
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<InPatientTreatmentClinicApplication.GetInPatientInfoByPatients_Class> GetInPatientInfoByPatients(GetInPatientInfoByPatients_Input input)
        {
            var ret = InPatientTreatmentClinicApplication.GetInPatientInfoByPatients(input.PATIENTS);
            return ret;
        }
    }
}