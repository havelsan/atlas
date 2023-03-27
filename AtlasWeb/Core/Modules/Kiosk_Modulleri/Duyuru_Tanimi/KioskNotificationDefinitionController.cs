using Core.Models;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTDefinitionManagement;
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
    public class KioskNotificationDefinitionController : Controller
    {

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public GetNotificationDefinition getAllNotificationDefinition()
        {
            GetNotificationDefinition notificationDefinition = new GetNotificationDefinition();
            notificationDefinition.notificationDefinitionListDTOs = new List<NotificationDefinitionListDTO>();
            notificationDefinition.notificationDefinitionListDTOs = KioskNotificationDef.GetKioskNotificationDefList(string.Empty).Select(x => new NotificationDefinitionListDTO()
            {
                Notification = x.Notification,
                ObjectID = x.ObjectID.Value,
                IsActive = x.IsActive.Value,

            }).ToList();
         
            notificationDefinition.deviceListDTOs = KioskDeviceDefinition.GetKioskDeviceDefinitionList(string.Empty).Select(x => new KioskDevice()
            {
                DeviceName = x.DeviceName,
                ObjectID = x.ObjectID.Value,
            }).ToList();

            return notificationDefinition;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public NotificationDefinitionOutputItem getNotificationDefinitionItem(GetNotificationDefinition_Input input)
        {
            using (var objectContect = new TTObjectContext(false))
            {
                NotificationDefinitionOutputItem outputItem = new NotificationDefinitionOutputItem();

                KioskNotificationDef notificationDefinition = objectContect.GetObject<KioskNotificationDef>(input.ObjectID);
                outputItem.Notification = notificationDefinition.Notification;
                outputItem.IsActive = notificationDefinition.IsActive.Value;
                outputItem.isNew = false;
                outputItem.ObjectID = notificationDefinition.ObjectID;
                outputItem.StartDate = notificationDefinition.StartDate.Value;
                outputItem.EndDate = notificationDefinition.EndDate.Value;
                
                outputItem.Devices = new List<KioskDevice>();
                var devices = NotificationDevice.GetDeviceForNotification(notificationDefinition.ObjectID).Select(x => new KioskDevice()
                {
                    DeviceName = x.DeviceName,
                    ObjectID = x.Deviceobjectid.Value
                }).ToList();
                outputItem.Devices = devices;
                return outputItem;
            }
        }

        [HttpPost]
        public string saveObject(NotificationDefinitionOutputItem input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                KioskNotificationDef notificationDefinition = null;
                if (input.isNew == true)
                {
                    notificationDefinition = new KioskNotificationDef(objectContext);
                 
                }
                else
                {
                    notificationDefinition = objectContext.GetObject<KioskNotificationDef>(input.ObjectID);
                    foreach (var device in NotificationDevice.GetDeviceForNotification(notificationDefinition.ObjectID))
                    {
                        NotificationDevice deletedNotDevice = objectContext.GetObject<NotificationDevice>(device.ObjectID.Value);
                        ((ITTObject)deletedNotDevice).Delete();
                    }
                }

                notificationDefinition.StartDate = input.StartDate;
                notificationDefinition.EndDate = input.EndDate;
                notificationDefinition.Notification = input.Notification;
                notificationDefinition.IsActive = input.IsActive;

                if (input.Devices != null)
                {
                    foreach (var device in input.Devices)
                    {
                        NotificationDevice notificationDevice = new NotificationDevice(objectContext);
                        notificationDevice.Notification = notificationDefinition;
                        notificationDevice.Device = objectContext.GetObject<KioskDeviceDefinition>(device.ObjectID);
                    }
                }


                objectContext.Save();
                objectContext.Dispose();
                return "Duyuru Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return " Duyuru Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }


        public class NotificationDefinitionListDTO
        {
            public Guid ObjectID { get; set; }
            public string Notification { get; set; }
            public bool IsActive { get; set; }
        }

        public class GetNotificationDefinition
        {
            public List<NotificationDefinitionListDTO> notificationDefinitionListDTOs { get; set; }
            public List<KioskDevice> deviceListDTOs { get; set; }
        }


        public class GetNotificationDefinition_Input
        {
            public Guid ObjectID { get; set; }
        }

        public class NotificationDefinitionOutputItem
        {
            public bool isNew { get; set; }
            public Guid ObjectID { get; set; }
            public string Notification { get; set; }
            public bool IsActive { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<KioskDevice> Devices { get; set; }

        }

        public class KioskDevice
        {
            public Guid ObjectID { get; set; }
            public string DeviceName { get; set; }
        }
    }
}
