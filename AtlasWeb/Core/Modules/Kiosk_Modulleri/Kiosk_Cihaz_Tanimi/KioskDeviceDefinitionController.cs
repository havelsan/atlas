using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using TTConnectionManager;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class KioskDeviceDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetDeviceDefinition getAllDeviceDefinition()
        {
            GetDeviceDefinition deviceDefinition = new GetDeviceDefinition();
            deviceDefinition.deviceDefinitionListDTOs = new List<DeviceDefinitionListDTO>();
            deviceDefinition.ResUserDataSources = new List<ResUserDataSource>();
            deviceDefinition.deviceDefinitionListDTOs = KioskDeviceDefinition.GetKioskDeviceDefinitionList(string.Empty).Select(x => new DeviceDefinitionListDTO()
            {
                Name = x.DeviceName,
                Code = x.DeviceCode,
                ObjectID = x.ObjectID.Value,
                IsActive = x.IsActive.Value,

            }).ToList();
            BindingList<ResUser.GetAllUserReportNQL_Class> users = ResUser.GetAllUserReportNQL("ORDER BY NAME");
            foreach (ResUser.GetAllUserReportNQL_Class user in users)
            {
                ResUserDataSource userItem = new ResUserDataSource();
                userItem.ObjectID = user.ObjectID.Value;
                userItem.ResUserName = user.Name;
                deviceDefinition.ResUserDataSources.Add(userItem);
            }
            return deviceDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DeviceDefinitionOutputItem getDeviceDefinitionItem(GetDeviceDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                DeviceDefinitionOutputItem outputItem = new DeviceDefinitionOutputItem();

                KioskDeviceDefinition deviceDefinition = objectContect.GetObject<KioskDeviceDefinition>(input.ObjectID);
                outputItem.DeviceName = deviceDefinition.DeviceName;
                outputItem.DeviceCode = deviceDefinition.DeviceCode;
                outputItem.IsActive = deviceDefinition.IsActive;
                outputItem.isNew = false;
                outputItem.ObjectID = deviceDefinition.ObjectID;
                outputItem.HasMernisVerification = deviceDefinition.HasMernisVerification;
                outputItem.HasPatientAdmission = deviceDefinition.HasPatientAdmission;
                outputItem.HasPatientResult = deviceDefinition.HasPatientResult;
                outputItem.HasAppointmentAvailable = deviceDefinition.HasAppointmentAvailable;

                KioskMemberDTO memberDTO = new KioskMemberDTO();
                if (deviceDefinition.ResUser != null)
                {
                    memberDTO.ReUserObjectID = deviceDefinition.ResUser.ObjectID;
                    memberDTO.ResUserName = deviceDefinition.ResUser.Name;
                    outputItem.KioskMember = memberDTO;
                }


                return outputItem;
            }
        }

        [HttpPost]
        public string saveObject(DeviceDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                KioskDeviceDefinition deviceDefinition = null;
                if (input.isNew == true)
                {
                    deviceDefinition = new KioskDeviceDefinition(objectContext);
                    ResUser resUser = (ResUser)objectContext.GetObject(input.KioskMember.ReUserObjectID, typeof(ResUser));
                    deviceDefinition.ResUser = resUser;
                }
                else
                {
                    deviceDefinition = objectContext.GetObject<KioskDeviceDefinition>(input.ObjectID);
                    ResUser resUser = (ResUser)objectContext.GetObject(input.KioskMember.ReUserObjectID, typeof(ResUser));
                    deviceDefinition.ResUser = resUser;
                }

                List<KioskDeviceDefinition.GetKioskDeviceDefinitionList_Class> controlOfDeviceCode =
                KioskDeviceDefinition.GetKioskDeviceDefinitionList(" WHERE DEVICECODE ='" + input.DeviceCode + "'").ToList();
                if (controlOfDeviceCode.Count == 1)
                {
                    if (controlOfDeviceCode[0].ObjectID != deviceDefinition.ObjectID)
                        throw new TTException(" Aynı Cihaz Kodu Sistemde Vardır Lütfen Kodu Kontrol Ediniz.");
                }

                deviceDefinition.DeviceCode = input.DeviceCode;
                deviceDefinition.DeviceName = input.DeviceName;
                deviceDefinition.HasMernisVerification = input.HasMernisVerification;
                deviceDefinition.HasPatientAdmission = input.HasPatientAdmission;
                deviceDefinition.HasPatientResult = input.HasPatientResult;
                deviceDefinition.IsActive = input.IsActive;
                deviceDefinition.HasAppointmentAvailable = input.HasAppointmentAvailable;
                objectContext.Save();
                objectContext.Dispose();
                return "Kiosk Cihaz Kayıt İşlemi Yapılmıştır";
            }
            catch (Exception ex)
            {
                return ex.Message + "-- Kiosk Cihaz Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public DeviceDefinitionOutputItem getDeviceDefinitionFromAtlas(GetDeviceDefinitionKiosk_Input input)
        {
            DeviceDefinitionOutputItem outputItem = new DeviceDefinitionOutputItem();
            var deviceDef = KioskDeviceDefinition.GetKioskDeviceDefinitionList(" WHERE DEVICECODE ='" + input.DeviceCode + "'").FirstOrDefault();
            if (deviceDef != null)
            {
                outputItem.ObjectID = deviceDef.ObjectID.Value;
                outputItem.DeviceCode = deviceDef.DeviceCode;
                outputItem.DeviceName = deviceDef.DeviceName;
                outputItem.HasMernisVerification = deviceDef.HasMernisVerification;
                outputItem.HasPatientAdmission = deviceDef.HasPatientAdmission;
                outputItem.HasPatientResult = deviceDef.HasPatientResult;
                outputItem.HasAppointmentAvailable = deviceDef.HasAppointmentAvailable;

                KioskMemberDTO memberDTO = new KioskMemberDTO();
                if (deviceDef.ResUser != null)
                {
                    string username = GetResUser(deviceDef.ResUser.Value);
                    if (username != input.Name.ToUpper())
                    {
                        throw new Exception("Kullanıcı adı ile cihaz eşleşmedi.");
                    }
                    memberDTO.ReUserObjectID = deviceDef.ResUser.Value;
                    memberDTO.ResUserName = username;
                    outputItem.KioskMember = memberDTO;
                }
            }
            return outputItem;
        }

        private string GetResUser (Guid objectId)
        {
            using (DbConnection dbConnection = ConnectionManager.CreateConnection())
            {
                DbCommand cmd = ConnectionManager.CreateCommand("SELECT NAME FROM TTUSER WHERE TTOBJECTID =" + "'" + objectId + "'", dbConnection);

                DbDataAdapter adapter = ConnectionManager.CreateDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tbl = ds.Tables[0];
                string name = string.Empty;
                if (tbl.Rows.Count != 0)
                {
                    DataRow dr = tbl.Rows[0];
                    name = dr["NAME"].ToString();
                }
                return name;
            }
        }


        public class KioskDeviceDefinitionDTO
        {
            public string DeviceCode { get; set; }

        }

        public class DeviceDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public bool IsActive { get; set; }
        }

        public class GetDeviceDefinition
        {
            public List<DeviceDefinitionListDTO> deviceDefinitionListDTOs { get; set; }
            public List<ResUserDataSource> ResUserDataSources { get; set; }
        }
        public class GetDeviceDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class GetDeviceDefinitionKiosk_Input
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string DeviceCode { get; set; }
        }

        public class DeviceDefinitionOutputItem
        {
            public bool? isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string DeviceName { get; set; }
            public string DeviceCode { get; set; }
            public bool? IsActive { get; set; }
            public bool? HasMernisVerification { get; set; }
            public bool? HasPatientAdmission { get; set; }
            public bool? HasPatientResult { get; set; }
            public bool? HasAppointmentAvailable { get; set; }
            public KioskMemberDTO KioskMember { get; set; }

        }

        public class KioskMemberDTO
        {

            public Guid ReUserObjectID { get; set; }
            public string ResUserName { get; set; }
        }

        public class ResUserDataSource
        {

            public Guid ObjectID { get; set; }
            public string ResUserName { get; set; }
        }
    }
}
