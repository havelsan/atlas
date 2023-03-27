//$7FC69CF2
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
    public partial class PatientServiceController : Controller
    {
        public class PatientHasDebt_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string PatientHasDebt(PatientHasDebt_Input input)
        {
            using (var ObjectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)ObjectContext.AddObject(input.patient);
                var ret = Patient.PatientHasDebt(input.patient, ObjectContext);
                ObjectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public bool IsAdmittingAllPatientGroupFromSiteAllowed()
        {
            var ret = Patient.IsAdmittingAllPatientGroupFromSiteAllowed();
            return ret;
        }

        public class Search_Input
        {
            public string searchString
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTInstanceManagement.TTList Search(Search_Input input)
        {
            var ret = Patient.Search(input.searchString);
            return ret;
        }

        public class IsGuid_Input
        {
            public string str
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsGuid(IsGuid_Input input)
        {
            var ret = Patient.IsGuid(input.str);
            return ret;
        }

        public class SendPatientToPACS_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void SendPatientToPACS(SendPatientToPACS_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                Patient.SendPatientToPACS(input.patient);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        public class GetInpatientList_Input
        {
            public System.Guid? PhysicalStateClinicGuid
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.Patient.InPatientListItem> GetInpatientList(GetInpatientList_Input input)
        {
            var ret = Patient.GetInpatientList(input.PhysicalStateClinicGuid);
            return ret;
        }

        public class GetPatient_Input
        {
            public System.Guid ObjectId
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Patient.InPatientInfo GetPatient(GetPatient_Input input)
        {
            var ret = Patient.GetPatient(input.ObjectId);
            return ret;
        }

        public class GetSrcTableType_Input
        {
            public string srctable
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Patient.SrcTableType? GetSrcTableType(GetSrcTableType_Input input)
        {
            var ret = Patient.GetSrcTableType(input.srctable);
            return ret;
        }

        public class AddOrUpdatePatientWithLocalID_Input
        {
            public TTObjectClasses.Patient sourcePatient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.Patient AddOrUpdatePatientWithLocalID(AddOrUpdatePatientWithLocalID_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.sourcePatient != null)
                    input.sourcePatient = (TTObjectClasses.Patient)objectContext.AddObject(input.sourcePatient);
                var ret = Patient.AddOrUpdatePatientWithLocalID(objectContext, input.sourcePatient);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class IsAllRequiredPropertiesExists_Input
        {
            public bool throwException
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool IsAllRequiredPropertiesExists(IsAllRequiredPropertiesExists_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                var ret = Patient.IsAllRequiredPropertiesExists(input.throwException, input.patient);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetSGKSEPs_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }

            public System.DateTime? startDate
            {
                get;
                set;
            }

            public System.DateTime? endDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.SubEpisodeProtocol> GetSGKSEPs(GetSGKSEPs_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                var ret = Patient.GetSGKSEPs(input.patient, input.startDate, input.endDate);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetActiveSGKSEPs_Input
        {
            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }

            public System.DateTime? startDate
            {
                get;
                set;
            }

            public System.DateTime? endDate
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.SubEpisodeProtocol> GetActiveSGKSEPs(GetActiveSGKSEPs_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                var ret = Patient.GetActiveSGKSEPs(input.patient, input.startDate, input.endDate);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class CoverPatientInformation_Input
        {
            public bool ? isPrivacy
            {
                get;
                set;
            }

            public TTObjectClasses.Patient patient
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void CoverPatientInformation(CoverPatientInformation_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.patient != null)
                    input.patient = (TTObjectClasses.Patient)objectContext.AddObject(input.patient);
                Patient.CoverPatientInformation(input.isPrivacy, input.patient);
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        [HttpPost]
        public BindingList<Patient> GetAllPatients()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetAllPatients(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<Patient.OLAP_deneme_Class> OLAP_deneme()
        {
            var ret = Patient.OLAP_deneme();
            return ret;
        }

        public class GetPatientByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient.GetPatientByInjection_Class> GetPatientByInjection(GetPatientByInjection_Input input)
        {
            var ret = Patient.GetPatientByInjection(input.injectionSQL);
            return ret;
        }

        public class GetPatientsByIdentityInfo_Input
        {
            public string Name
            {
                get;
                set;
            }

            public string FatherName
            {
                get;
                set;
            }

            public string SurName
            {
                get;
                set;
            }

            public string MotherName
            {
                get;
                set;
            }

            public string CityOfBirth
            {
                get;
                set;
            }

            public string TownOfBirth
            {
                get;
                set;
            }

            public DateTime BirthDate
            {
                get;
                set;
            }

            public SexEnum Sex
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatientsByIdentityInfo(GetPatientsByIdentityInfo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientsByIdentityInfo(objectContext, input.Name, input.FatherName, input.SurName, input.MotherName, input.CityOfBirth, input.TownOfBirth, input.BirthDate, input.Sex);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetImportantMedicalInformationByPatient_Input
        {
            public string PATIENT
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetImportantMedicalInformationByPatient(GetImportantMedicalInformationByPatient_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetImportantMedicalInformationByPatient(objectContext, input.PATIENT);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientByPID_Input
        {
            public long ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatientByPID(GetPatientByPID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientByPID(objectContext, input.ID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientsByUniqueRefNo_Input
        {
            public long UNIQUEREFNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatientsByUniqueRefNo(GetPatientsByUniqueRefNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientsByUniqueRefNo(objectContext, input.UNIQUEREFNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientByID_Input
        {
            public string ID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatientByID(GetPatientByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientByID(objectContext, input.ID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientsBetweenUniqueRefNo_Input
        {
            public long UNIQUEREFNO1
            {
                get;
                set;
            }

            public long UNIQUEREFNO2
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatientsBetweenUniqueRefNo(GetPatientsBetweenUniqueRefNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientsBetweenUniqueRefNo(objectContext, input.UNIQUEREFNO1, input.UNIQUEREFNO2);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientsBetweenIDExceptFamily_Input
        {
            public int ID1
            {
                get;
                set;
            }

            public int ID2
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
        public BindingList<Patient> GetPatientsBetweenIDExceptFamily(GetPatientsBetweenIDExceptFamily_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientsBetweenIDExceptFamily(objectContext, input.ID1, input.ID2, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientIdentityAddress_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient.GetPatientIdentityAddress_Class> GetPatientIdentityAddress(GetPatientIdentityAddress_Input input)
        {
            var ret = Patient.GetPatientIdentityAddress(input.injectionSQL);
            return ret;
        }

        public class GetPatientsBetweenIDOnlyFamily_Input
        {
            public int ID1
            {
                get;
                set;
            }

            public int ID2
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
        public BindingList<Patient> GetPatientsBetweenIDOnlyFamily(GetPatientsBetweenIDOnlyFamily_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatientsBetweenIDOnlyFamily(objectContext, input.ID1, input.ID2, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetInpatientPatientsByPatientGroup()
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetInpatientPatientsByPatientGroup(objectContext);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientExistsByUniqueRefNO_RQ_Input
        {
            public long RFN
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient.GetPatientExistsByUniqueRefNO_RQ_Class> GetPatientExistsByUniqueRefNO_RQ(GetPatientExistsByUniqueRefNO_RQ_Input input)
        {
            var ret = Patient.GetPatientExistsByUniqueRefNO_RQ(input.RFN);
            return ret;
        }

        public class GetPatientObjectIDByInjection_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient.GetPatientObjectIDByInjection_Class> GetPatientObjectIDByInjection(GetPatientObjectIDByInjection_Input input)
        {
            var ret = Patient.GetPatientObjectIDByInjection(input.injectionSQL);
            return ret;
        }

        public class GetPatientInformation_RQ_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient.GetPatientInformation_RQ_Class> GetPatientInformation_RQ(GetPatientInformation_RQ_Input input)
        {
            var ret = Patient.GetPatientInformation_RQ(input.injectionSQL);
            return ret;
        }

        public class GetPatients_Input
        {
            public IList<Guid> OBJECTIDS
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Patient> GetPatients(GetPatients_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Patient.GetPatients(objectContext, input.OBJECTIDS);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<Patient.VEM_HASTA_Class> VEM_HASTA()
        {
            var ret = Patient.VEM_HASTA();
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Patient.VEM_HASTA_ARSIV_Class> VEM_HASTA_ARSIV()
        {
            var ret = Patient.VEM_HASTA_ARSIV();
            return ret;
        }
    }
}