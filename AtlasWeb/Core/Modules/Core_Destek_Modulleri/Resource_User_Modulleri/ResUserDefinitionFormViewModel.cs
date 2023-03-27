//$294C769C
using System;
using Core.Models;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTStorageManager.Security;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ResUserServiceController
    {
        partial void PreScript_ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel, ResUser resUser, TTObjectContext objectContext)
        {
            TTUser _TTUser = new TTUser();
            if (((ITTObject)resUser).IsNew == false)//obje yeni deðilse kullanýcý adý set edilir.
            {
                _TTUser = resUser.GetMyTTUser();
                if (_TTUser != null)
                {
                    viewModel.UserLogonName = _TTUser.Name != null ? _TTUser.Name : "";
                    viewModel.Userid = _TTUser.UserID;
                }
            }

            viewModel.resUserTakeOffFromWork = Common.PersonelIzinKontrol(resUser.ObjectID.ToString(), Common.RecTime(), objectContext) == true ? "Ýzinli" : "Çalýþýyor";

            viewModel.CurrentUserRoleList = GetCurrentUserRoleList(_TTUser);

            FillRoleDef(viewModel);

            if (resUser.IsClinician.HasValue == false)
                resUser.IsClinician = false;

            var RessectionList= ResSection.GetResSections(objectContext, "Where enabledtype<>5");
            viewModel.ResSectionDataSource = new List<UserResourceInfo>();
            foreach (var ressectionItem in RessectionList)
            {
                string depName = "";
                if (ressectionItem.GetType() == typeof(ResClinic))
                {
                    depName = (ressectionItem as ResClinic).Department != null ? (ressectionItem as ResClinic).Department.Name : "";
                }
                else if (ressectionItem.GetType() == typeof(ResPoliclinic))
                {
                    depName = (ressectionItem as ResPoliclinic).Department != null ? (ressectionItem as ResPoliclinic).Department.Name : "";
                }
                else if (ressectionItem.GetType() == typeof(ResSurgeryDepartment))
                {
                    depName = (ressectionItem as ResSurgeryDepartment).Department != null ? (ressectionItem as ResSurgeryDepartment).Department.Name : "";
                }
                else if (ressectionItem.GetType() == typeof(ResTreatmentDiagnosisUnit))
                {
                    depName = (ressectionItem as ResTreatmentDiagnosisUnit).Department != null ? (ressectionItem as ResTreatmentDiagnosisUnit).Department.Name : "";
                }
                else if (ressectionItem.GetType() == typeof(ResDepartment))
                {
                    depName = (ressectionItem as ResDepartment).MainDepartment != null ? (ressectionItem as ResDepartment).MainDepartment.Name : "";
                }
                UserResourceInfo info = new UserResourceInfo
                {
                    UserResourceId = ressectionItem.ObjectID,
                    RessectionId = ressectionItem.ObjectID,
                    RessectionName = ressectionItem.Name,
                    RessectionDefname = ressectionItem.ObjectDef.Description,
                    RessectionDepartmentName = depName,
                    ResSectionItem=ressectionItem
                };
                viewModel.ResSectionDataSource.Add(info);
            }
            viewModel.UserResourceInfoList = new List<UserResourceInfo>();
            foreach (var userResourceItem in resUser.UserResources)
            {
                string depName = "";
                if (userResourceItem.Resource.GetType() == typeof(ResClinic))
                {
                    depName = (userResourceItem.Resource as ResClinic).Department != null ? (userResourceItem.Resource as ResClinic).Department.Name : "";
                }
                else if (userResourceItem.Resource.GetType() == typeof(ResPoliclinic))
                {
                    depName = (userResourceItem.Resource as ResPoliclinic).Department != null ? (userResourceItem.Resource as ResPoliclinic).Department.Name : "";
                }
                else if (userResourceItem.Resource.GetType() == typeof(ResSurgeryDepartment))
                {
                    depName = (userResourceItem.Resource as ResSurgeryDepartment).Department != null ? (userResourceItem.Resource as ResSurgeryDepartment).Department.Name : "";
                }
                else if (userResourceItem.Resource.GetType() == typeof(ResTreatmentDiagnosisUnit))
                {
                    depName = (userResourceItem.Resource as ResTreatmentDiagnosisUnit).Department != null ? (userResourceItem.Resource as ResTreatmentDiagnosisUnit).Department.Name : "";
                }
                else if (userResourceItem.Resource.GetType() == typeof(ResDepartment))
                {
                    depName = (userResourceItem.Resource as ResDepartment).MainDepartment != null ? (userResourceItem.Resource as ResDepartment).MainDepartment.Name : "";
                }
                UserResourceInfo info = new UserResourceInfo
                {
                    UserResourceId = userResourceItem.ObjectID,
                    RessectionId = userResourceItem.Resource.ObjectID,
                    RessectionName = userResourceItem.Resource.Name,
                    RessectionDefname = userResourceItem.Resource.ObjectDef.Description,
                    RessectionDepartmentName = depName
                };
                viewModel.UserResourceInfoList.Add(info);
            }
        }

        private Guid _objectDefID = new Guid("299c1e6d-dd23-4c09-8e60-b6c448c9a32e");

        partial void PostScript_ResUserDefinitionForm(ResUserDefinitionFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            TTUser CurrentUser = new TTUser();
            if (((ITTObject)resUser).IsNew == true)//kullanýcý yeni ise
            {
                //CurrentUser = TTUser.CreateNewUser("Kullanýcý Adý","Þifre", "Geçerlilik Tarihi","Durumu", "Seçili Kullanýcý", _objectDefID); 
                //public static Tuple<AuthenticationResultEnum, TTUser> CheckAuthenticate(string username, string password)
                CurrentUser = TTUser.CreateNewUser(viewModel.UserLogonName, "1", Common.RecTime().AddDays(-1), UserStatusEnum.Normal, resUser.ObjectID, _objectDefID);
            }
            else
            {
                CurrentUser = resUser.GetMyTTUser();
                CurrentUser = TTUser.UpdateUser(CurrentUser.UserID, "1", CurrentUser.PwdExpireDate.Value, CurrentUser.Status, viewModel.UserLogonName);//Þifre nereden alýnacak
            }
            if (resUser.UserType != null)
            {
                if (resUser.UserType != UserTypeEnum.Doctor && resUser.UserType != UserTypeEnum.Dentist)
                {
                    if (resUser.IsClinician.HasValue == true && resUser.IsClinician.Value == true)
                        throw new Exception("Mesleði Doktor veya Diþ Hekimi olmayan kullanýcýlar için 'Klinisyen Hekim' kutucuðu iþaretli olamaz.");
                }
                else
                {
                    if (resUser.IsClinician.HasValue == false)
                        throw new Exception("Mesleði Doktor veya Diþ Hekimi olan kullanýcýlar için 'Klinisyen Hekim' kutucuðu boþ geçilemez.");
                }
            }
            foreach (var resourceItem in viewModel.UserResourceInfoList)
            {
                if (resourceItem.IsDeleted == true)
                {
                    UserResource resourceObj = objectContext.GetObject(resourceItem.UserResourceId, "USERRESOURCE") as UserResource;
                    ((ITTObject)resourceObj).Delete();
                }
                else if (resourceItem.IsNew == true)
                {
                    UserResource resourceObj = new UserResource(objectContext);
                    resourceObj.User = resUser;
                    resourceObj.Resource = objectContext.GetObject(resourceItem.RessectionId, "RESSECTION") as ResSection;
                }
            }

        }

        public List<RoleDefinitionList> GetCurrentUserRoleList(TTUser _TTUser)
        {

            List<RoleDefinitionList> CurrentUserRoleList = new List<RoleDefinitionList>();
            if (_TTUser != null && _TTUser.AllRoles.Count > 0)
            {
                foreach (TTRoleMemberBase role in _TTUser.AllRoles)//kullanýcýnýn atanmýþ rollerinin listesi
                {
                    RoleDefinitionList CurrentUserRole = new RoleDefinitionList();
                    CurrentUserRole.RoleId = role.RoleID;
                    CurrentUserRole.RoleName = role.Name;
                    CurrentUserRole.RoleSubTypeEnum = RoleSubTypeEnum.User;
                    CurrentUserRoleList.Add(CurrentUserRole);
                }
            }

            return CurrentUserRoleList;
        }

        public void FillRoleDef(ResUserDefinitionFormViewModel viewModel)
        {
            List<RoleDefinitionList> UserRoleDefinitionList = new List<RoleDefinitionList>();
            List<RoleDefinitionList> SystemRoleDefinitionList = new List<RoleDefinitionList>();
            List<RoleDefinitionList> CoreRoleDefinitionList = new List<RoleDefinitionList>();
            List<RoleDefinitionList> AllRoleDefinitionList = new List<RoleDefinitionList>();

            GetRoleDefinitions(out UserRoleDefinitionList, out SystemRoleDefinitionList, out CoreRoleDefinitionList, out AllRoleDefinitionList, viewModel.CurrentUserRoleList);

            viewModel.TTUserRoleList = UserRoleDefinitionList;
            viewModel.TTSystemRoleList = SystemRoleDefinitionList;
            viewModel.TTCoreRoleList = CoreRoleDefinitionList;
            viewModel.TTAllRoleList = AllRoleDefinitionList;
        }

        public void GetRoleDefinitions(out List<RoleDefinitionList> TTUserRoleList, out List<RoleDefinitionList> TTSystemRoleList, out List<RoleDefinitionList> TTCoreRoleList, out List<RoleDefinitionList> TTAllRoleList, List<RoleDefinitionList> CurrentUserRoleList)
        {
            TTUserRoleList = new List<RoleDefinitionList>();
            TTSystemRoleList = new List<RoleDefinitionList>();
            TTCoreRoleList = new List<RoleDefinitionList>();
            TTAllRoleList = new List<RoleDefinitionList>();

            foreach (TTRole role in TTObjectDefManager.Instance.AllRoles)
            {
                if (role.Subtype != RoleSubTypeEnum.BuiltIn && !CurrentUserRoleList.Exists(x => x.RoleId == role.RoleID)) //Kullanýcýya atanmýþ olan roller listede gösterilmeyecek.
                {
                    if (role.Subtype == RoleSubTypeEnum.User)
                    {
                        RoleDefinitionList roleDef = new RoleDefinitionList();
                        roleDef.RoleId = role.RoleID;
                        roleDef.RoleName = role.Name;
                        roleDef.RoleSubTypeEnum = RoleSubTypeEnum.User;

                        TTUserRoleList.Add(roleDef);
                        TTAllRoleList.Add(roleDef);
                    }
                    if (role.Subtype == RoleSubTypeEnum.System)
                    {
                        RoleDefinitionList roleDef = new RoleDefinitionList();
                        roleDef.RoleId = role.RoleID;
                        roleDef.RoleName = role.Name;
                        roleDef.RoleSubTypeEnum = RoleSubTypeEnum.System;

                        TTSystemRoleList.Add(roleDef);
                        TTAllRoleList.Add(roleDef);
                    }
                    if (role.Subtype == RoleSubTypeEnum.Core)
                    {
                        RoleDefinitionList roleDef = new RoleDefinitionList();
                        roleDef.RoleId = role.RoleID;
                        roleDef.RoleName = role.Name;
                        roleDef.RoleSubTypeEnum = RoleSubTypeEnum.Core;

                        TTCoreRoleList.Add(roleDef);
                        TTAllRoleList.Add(roleDef);
                    }
                }
            }
        }

        public void PasswordReset(Guid Userid)
        {
            TTUser.ChangeUserPassword(Userid, "1");
            var t = new TTUserPersistManager();
            t.ChangeUserPwdExpireDate(Userid, Common.RecTime().AddDays(-1));//Þifre expireDate bir gün öncesine set edilerek kullanýcý ilk giriþ yaptýðýnda þifre deðiþtirme ekranýna yönlenmesi saðlanýyor.

        }


        public ResUserDefinitionFormViewModel AddCurrentUserRole(ResUserDefinitionFormViewModel viewModel)
        {
            TTUser _TTUser = viewModel._ResUser.GetMyTTUser();
            if (_TTUser != null)
            {
                List<Guid> roleIdList = new List<Guid>();
                foreach (var role in viewModel.selectedRoleValue)
                {
                    roleIdList.Add(role.RoleId);
                }
                if (roleIdList.Count > 0)
                {
                    TTUser.AddUserRoles(_TTUser.UserID, roleIdList, 0);
                }

                viewModel.CurrentUserRoleList = GetCurrentUserRoleList(_TTUser);
                FillRoleDef(viewModel);
            }
            else
            {
                throw new Exception();
            }

            return viewModel;
        }
    }
}

namespace Core.Models
{
    public partial class ResUserDefinitionFormViewModel : BaseViewModel
    {
        public string UserLogonName { get; set; }

        public Guid Userid { get; set; }

        public List<RoleDefinitionList> CurrentUserRoleList { get; set; }//Kullanýcýya atanmýþ olan rollerin listesi

        public List<RoleDefinitionList> TTUserRoleList { get; set; }
        public List<RoleDefinitionList> TTSystemRoleList { get; set; }
        public List<RoleDefinitionList> TTCoreRoleList { get; set; }
        public List<RoleDefinitionList> TTAllRoleList { get; set; }

        public List<RoleDefinitionList> selectedRoleValue { get; set; }
        public string resUserTakeOffFromWork { get; set; }//Personel izinli ya da çalýþýyor durumunu belirtmek için

        public List<UserResourceInfo> UserResourceInfoList { get; set; }

        public List<UserResourceInfo> ResSectionDataSource { get; set; }
        public List<UserResourceInfo> ResSectionList { get; set; }//Eklenen Birimler
    }

    public class RoleDefinitionList
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public RoleSubTypeEnum RoleSubTypeEnum { get; set; }
    }

    public class UserResourceInfo
    {
        public string RessectionName { get; set; }
        public string RessectionDefname { get; set; }
        public string RessectionDepartmentName { get; set; }
        public Guid RessectionId { get; set; }
        public Guid UserResourceId { get; set; }
        public bool IsNew { get; set; }//Eklenen Birim
        public bool IsDeleted { get; set; }//Silinen Birim
        public ResSection ResSectionItem { get; set; }
    }
}
