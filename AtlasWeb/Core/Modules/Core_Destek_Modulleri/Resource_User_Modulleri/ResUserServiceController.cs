//$C094CBB1
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
    public partial class ResUserServiceController : Controller
    {
        public class GetUserOptionTypes_Input
        {
            public TTObjectClasses.UserOptionGroupType userOptionGroupType
            {
                get;
                set;
            }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public List<TTObjectClasses.UserOptionType> GetUserOptionTypes(GetUserOptionTypes_Input input)
        {
            var ret = ResUser.GetUserOptionTypes(input.userOptionGroupType);
            return ret;
        }

        public class SelectCurrentUserCashOffice_Input
        {
            public TTObjectClasses.CashOfficeTypeEnum cashOfficeType
            {
                get;
                set;
            }

            public TTObjectClasses.ResUser currentUser
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public TTObjectClasses.CashOfficeDefinition SelectCurrentUserCashOffice(SelectCurrentUserCashOffice_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.currentUser != null)
                    input.currentUser = (TTObjectClasses.ResUser)objectContext.AddObject(input.currentUser);
                var ret = ResUser.SelectCurrentUserCashOffice(input.cashOfficeType, input.currentUser);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAnaUzmanlikBrans_Input
        {
            public TTObjectClasses.ResUser user
            {
                get;
                set;
            }

            public string type
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public string GetAnaUzmanlikBrans(GetAnaUzmanlikBrans_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.user != null)
                    input.user = (TTObjectClasses.ResUser)objectContext.AddObject(input.user);
                var ret = ResUser.GetAnaUzmanlikBrans(input.user, input.type);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class HasRole_Input
        {
            public TTObjectClasses.ResUser resUser
            {
                get;
                set;
            }

            public Guid roleID
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public bool HasRole(HasRole_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.resUser != null)
                    input.resUser = (TTObjectClasses.ResUser)objectContext.AddObject(input.resUser);
                var ret = ResUser.HasRole(input.resUser, input.roleID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetByUserResourceAndUserType_Input
        {
            public UserTypeEnum USERTYPE
            {
                get;
                set;
            }

            public string USERRESOURCE
            {
                get;
                set;
            }
        }

        #region eski kodlar

        [HttpPost]
        public BindingList<ResUser> GetByUserResourceAndUserType(GetByUserResourceAndUserType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetByUserResourceAndUserType(objectContext, input.USERTYPE, input.USERRESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResUser.OLAP_GetResDoctor_Class> OLAP_GetResDoctor()
        {
            var ret = ResUser.OLAP_GetResDoctor();
            return ret;
        }

        public class GetResUserByObjectID_Input
        {
            public string TTOBJECTID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByObjectID(GetResUserByObjectID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByObjectID(objectContext, input.TTOBJECTID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class ClinicDoctorListNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.ClinicDoctorListNQL_Class> ClinicDoctorListNQL(ClinicDoctorListNQL_Input input)
        {
            var ret = ResUser.ClinicDoctorListNQL(input.injectionSQL);
            return ret;
        }

        public class GetResUserByID_Input
        {
            public string USERID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByID(GetResUserByID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByID(objectContext, input.USERID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResUserByExternalID_Input
        {
            public string EXTERNALID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByExternalID(GetResUserByExternalID_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByExternalID(objectContext, input.EXTERNALID);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllUser_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetAllUser(GetAllUser_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetAllUser(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        [HttpPost]
        public BindingList<ResUser.OLAP_GetDoctorCount_Class> OLAP_GetDoctorCount()
        {
            var ret = ResUser.OLAP_GetDoctorCount();
            return ret;
        }

        public class GetUserByID_Input
        {
            public string USERID
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.GetUserByID_Class> GetUserByID(GetUserByID_Input input)
        {
            var ret = ResUser.GetUserByID(input.USERID);
            return ret;
        }

        [HttpPost]
        public BindingList<ResUser.OLAP_GetNurseCount_Class> OLAP_GetNurseCount()
        {
            var ret = ResUser.OLAP_GetNurseCount();
            return ret;
        }

        public class GetUserInfoNQL_Input
        {
            public string USER
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.GetUserInfoNQL_Class> GetUserInfoNQL(GetUserInfoNQL_Input input)
        {
            var ret = ResUser.GetUserInfoNQL(input.USER);
            return ret;
        }

        public class GetResUser_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.GetResUser_Class> GetResUser(GetResUser_Input input)
        {
            var ret = ResUser.GetResUser(input.injectionSQL);
            return ret;
        }

        public class GetByUserResourceAndUserTypes_Input
        {
            public string USERRESOURCE
            {
                get;
                set;
            }

            public IList<UserTypeEnum> USERTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetByUserResourceAndUserTypes(GetByUserResourceAndUserTypes_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetByUserResourceAndUserTypes(objectContext, input.USERRESOURCE, input.USERTYPE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResUserByUserType_Input
        {
            public UserTypeEnum USERTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByUserType(GetResUserByUserType_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByUserType(objectContext, input.USERTYPE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DoctorListNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.DoctorListNQL_Class> DoctorListNQL(DoctorListNQL_Input input)
        {
            var ret = ResUser.DoctorListNQL(input.injectionSQL);
            return ret;
        }

        public class GetResUserByUniqeRefNo_Input
        {
            public string UNIQUEREFNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByUniqeRefNo(GetResUserByUniqeRefNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByUniqeRefNo(objectContext, input.UNIQUEREFNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetResUserByUserTypeAndResource_Input
        {
            public UserTypeEnum USERTYPE
            {
                get;
                set;
            }

            public Guid RESOURCE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetResUserByUserTypeAndResource(GetResUserByUserTypeAndResource_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByUserTypeAndResource(objectContext, input.USERTYPE, input.RESOURCE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetActiveResUserByUniqeRefNo_Input
        {
            public string UNIQUEREFNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> GetActiveResUserByUniqeRefNo(GetActiveResUserByUniqeRefNo_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetActiveResUserByUniqeRefNo(objectContext, input.UNIQUEREFNO);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class DoctorListObjectNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser> DoctorListObjectNQL(DoctorListObjectNQL_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.DoctorListObjectNQL(objectContext, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetAllUserReportNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.GetAllUserReportNQL_Class> GetAllUserReportNQL(GetAllUserReportNQL_Input input)
        {
            var ret = ResUser.GetAllUserReportNQL(input.injectionSQL);
            return ret;
        }

        public class GetResUserByName_Input
        {
            public string NAME
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
        public BindingList<ResUser> GetResUserByName(GetResUserByName_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = ResUser.GetResUserByName(objectContext, input.NAME, input.injectionSQL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetConsultationUserNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<ResUser.GetConsultationUserNQL_Class> GetConsultationUserNQL(GetConsultationUserNQL_Input input)
        {
            var ret = ResUser.GetConsultationUserNQL(input.injectionSQL);
            return ret;
        }

        [HttpPost]
        public BindingList<ResUser.VEM_PERSONEL_Class> VEM_PERSONEL()
        {
            var ret = ResUser.VEM_PERSONEL();
            return ret;
        }

        [HttpPost]
        public BindingList<ResUser.GetdoctorsForMHRS_Class> GetdoctorsForMHRS()
        {
            var ret = ResUser.GetdoctorsForMHRS();
            return ret;
        }

        public class SpecialistDoctorListNQL_Input
        {
            public string injectionSQL
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<ResUser.SpecialistDoctorListNQL_Class> SpecialistDoctorListNQL(SpecialistDoctorListNQL_Input input)
        {
            var ret = ResUser.SpecialistDoctorListNQL(input.injectionSQL);
            return ret;
        }

        #endregion eski kodlar kapatýldý


        public class MyActiveQueues_Input
        {
            public TTObjectClasses.Resource outPatientResource { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<TTObjectClasses.ExaminationQueueDefinition> MyActiveQueues(MyActiveQueues_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.outPatientResource != null)
                    input.outPatientResource = (TTObjectClasses.Resource)objectContext.AddObject(input.outPatientResource);
                var ret = ResUser.MyActiveQueues(input.outPatientResource);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }
        public class GetResUsersByRoleID_Input
        {
            public TTObjectContext context { get; set; }
            public Guid roleID { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public BindingList<TTObjectClasses.ResUser> GetResUsersByRoleID(GetResUsersByRoleID_Input input)
        {
            var ret = ResUser.GetResUsersByRoleID(input.context, input.roleID);
            return ret;
        }
        public class ChangeKPSPassword_Input
        {
            public Guid userID { get; set; }
            public string oldPassword { get; set; }
            public string newPassword { get; set; }

        }
        [HttpPost]
        [Core.Security.AtlasRequiredRoles()]
        public bool ChangeKPSPassword(ChangeKPSPassword_Input input)
        {
            var ret = ResUser.ChangeKPSPassword(input.userID, input.oldPassword, input.newPassword);
            return ret;
        }
    }
}