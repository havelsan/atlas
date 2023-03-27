
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
using Core.Security;


namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class SubEpisodeProtocolServiceController : Controller
    {
        public class UpdateInvoiceSEPDetail_Input
        {
            public System.Guid id
            {
                get;
                set;
            }

            public System.Guid? newData
            {
                get;
                set;
            }

            public int type
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool UpdateInvoiceSEPDetail(UpdateInvoiceSEPDetail_Input input)
        {
            var ret = SubEpisodeProtocol.UpdateInvoiceSEPDetail(input.id, input.newData, input.type);
            return ret;
        }

        public class GetChildSEP_Input
        {
            public TTObjectClasses.SubEpisodeProtocol sep
            {
                get;
                set;
            }

            public bool childSEPHasProvisionNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.SubEpisodeProtocol GetChildSEP(GetChildSEP_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.sep != null)
                    input.sep = (TTObjectClasses.SubEpisodeProtocol)objectContext.AddObject(input.sep);
                var ret = SubEpisodeProtocol.GetChildSEP(input.sep, input.childSEPHasProvisionNo);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSEPByProvisionNo_Input
        {
            public string ProvisionNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.SubEpisodeProtocol GetSEPByProvisionNo(GetSEPByProvisionNo_Input input)
        {
            var ret = SubEpisodeProtocol.GetSEPByProvisionNo(input.ProvisionNo);
            return ret;
        }

        public class GetSEPByEpisode_Input
        {
            public Guid EPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol> GetSEPByEpisode(GetSEPByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisodeProtocol.GetSEPByEpisode(objectContext, input.EPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByObjectID_Input
        {
            public Guid OBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol.GetByObjectID_Class> GetByObjectID(GetByObjectID_Input input)
        {
            var ret = SubEpisodeProtocol.GetByObjectID(input.OBJECTID);
            return ret;
        }

        public class GetSEPByPatient_Input
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

            public Guid PATIENT
            {
                get;
                set;
            }

            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol> GetSEPByPatient(GetSEPByPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisodeProtocol.GetSEPByPatient(objectContext, input.STARTDATE, input.ENDDATE, input.PATIENT, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetBySEPMaster_Input
        {
            public Guid SEPMASTER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol.GetBySEPMaster_Class> GetBySEPMaster(GetBySEPMaster_Input input)
        {
            var ret = SubEpisodeProtocol.GetBySEPMaster(input.SEPMASTER);
            return ret;
        }

        public class GetSEPBySEPMaster_Input
        {
            public Guid SEPMASTER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol> GetSEPBySEPMaster(GetSEPBySEPMaster_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = SubEpisodeProtocol.GetSEPBySEPMaster(objectContext, input.SEPMASTER);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllPatientInfoByDate_Input
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public BindingList<SubEpisodeProtocol.GetAllPatientInfoByDate_Class> GetAllPatientInfoByDate(GetAllPatientInfoByDate_Input input)
        {
            var ret = SubEpisodeProtocol.GetAllPatientInfoByDate(input.STARTDATE, input.ENDDATE, Common.CurrentResource.ObjectID);
            return ret;
        }

        public class GetAllPatientInfoByDateWithoutUser_Input
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public BindingList<SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser_Class> GetAllPatientInfoByDateWithoutUser(GetAllPatientInfoByDateWithoutUser_Input input)
        {
            var ret = SubEpisodeProtocol.GetAllPatientInfoByDateWithoutUser(input.STARTDATE, input.ENDDATE);
            return ret;
        }

        public class GetPAInfoByDateWithoutProvision_Input
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public BindingList<SubEpisodeProtocol.GetPAInfoByDateWithoutProvision_Class> GetPAInfoByDateWithoutProvision(GetPAInfoByDateWithoutProvision_Input input)
        {
            var ret = SubEpisodeProtocol.GetPAInfoByDateWithoutProvision(input.STARTDATE, input.ENDDATE, Common.CurrentResource.ObjectID);
            return ret;
        }

        public class GetPAInfoByDateWithProvision_Input
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public BindingList<SubEpisodeProtocol.GetPAInfoByDateWithProvision_Class> GetPAInfoByDateWithProvision(GetPAInfoByDateWithProvision_Input input)
        {
            var ret = SubEpisodeProtocol.GetPAInfoByDateWithProvision(input.STARTDATE, input.ENDDATE, Common.CurrentResource.ObjectID);
            return ret;
        }

        public class GetSepCountByDate_Input
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
        [AtlasRequiredRoles(TTRoleNames.Hasta_Kabul_Gorme)]
        public int GetSepCountByDate(GetSepCountByDate_Input input)
        {
            var ret = SubEpisodeProtocol.GetSepCountByDate(input.STARTDATE, input.ENDDATE);
            return Convert.ToInt32(ret[0].Totalcount);
        }
        public class GetPaBySearchPatient_Input
        {
            public Guid PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol.GetPaBySearchPatient_Class> GetPaBySearchPatient(GetPaBySearchPatient_Input input)
        {
            var ret = SubEpisodeProtocol.GetPaBySearchPatient(input.PATIENT);
            return ret;
        }

        public class GetSEPByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol.GetSEPByInjection_Class> GetSEPByInjection(GetSEPByInjection_Input input)
        {
            var ret = SubEpisodeProtocol.GetSEPByInjection(-1, input.injectionSQL);
            return ret;
        }

        public class GetPaBySearchPatientForTreatmentReport_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport_Class> GetPaBySearchPatientForTreatmentReport(GetPaBySearchPatientForTreatmentReport_Input input)
        {
            var ret = SubEpisodeProtocol.GetPaBySearchPatientForTreatmentReport(input.injectionSQL);
            return ret;
        }

        public class GetEpisodeByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<SubEpisodeProtocol.GetEpisodeByInjection_Class> GetEpisodeByInjection(GetEpisodeByInjection_Input input)
        {
            var ret = SubEpisodeProtocol.GetEpisodeByInjection(-1, input.injectionSQL);
            return ret;
        }
    }
}