using Core.Models.Notification;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;

namespace Core.AtlasWebSocketManager.Containers
{
    public class NotificationService
    {
        internal static NotificationDto AddNotification(I_AtlasWebSocketContainer data)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                Notification notification = new Notification(_context);
                notification.ActionData = JsonConvert.SerializeObject(data.actionData);
                notification.Content = data.content;
                notification.ResUser = Common.CurrentResource;
                notification.CreateTime = Common.RecTime();
                notification.SourceType = (int)data.sourceType;
                notification.ContentType = (int)data.contentType;
                notification.HeaderDefinition = data.headerDefinition;

                
                foreach (var item in data.users)
                {
                    NotificationUser notificationUser = new NotificationUser(_context);
                    notificationUser.Notification = notification;
                    notificationUser["RESUSER"] = item;
                    notificationUser.IsRead = false;
                    notificationUser.ReadTime = null;
                }
                _context.Save();


                NotificationDto result = new NotificationDto();
                result.Notification =_context.QueryObjects<Notification>("ObjectID = '" + notification.ObjectID + "'").FirstOrDefault();
                result.NotificationUsers =_context.QueryObjects<NotificationUser>("Notification.ObjectID = '" + notification.ObjectID + "'").ToList();
                foreach (var item in result.NotificationUsers)
                {
                    item.UserID = item.ResUser.ObjectID.ToString();
                }
                return result;
            }
        }

        internal static object GetNotifications(DateTime lastTime, int size)
        {
            var currentResourceObjId = Common.CurrentResource.ObjectID;
            var startDate = DateTime.Now.AddMonths(-1);
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                var items = context.NotificationUser.Where(p => p.ResUserRef == currentResourceObjId
                    && p.Notification.CreateTime < lastTime && p.Notification.CreateTime > startDate).Select(p => new NotificationResponseDTO
                    {
                        Notification = new NotificationDTO()
                        {
                            ActionData = p.Notification.ActionData,
                            Content = p.Notification.Content,
                            ContentType = p.Notification.ContentType,
                            CreateTime = p.Notification.CreateTime,
                            ObjectID = p.Notification.ObjectId.ToString(),
                            ResUser = p.Notification.ResUserRef.HasValue ? p.Notification.ResUserRef.ToString() : "",
                            SourceType = p.Notification.SourceType
                        },
                        NotificationUser = new NotificationUserDTO()
                        {
                            ResUser = p.ResUserRef.HasValue ? p.ResUserRef.ToString() : "",
                            Notification = p.NotificationRef.HasValue ? p.NotificationRef.ToString() : "",
                            IsRead = p.IsRead,
                            ObjectID = p.ObjectId.ToString()
                        }
                    }).OrderByDescending(p => p.Notification.CreateTime).Take(size).ToList();
                return items;
            }
        }

        internal static bool SetRead(string notificationID, bool read)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var item = (NotificationUser)_context.GetObject(new Guid(notificationID), typeof(NotificationUser));
                item.IsRead = read;
                _context.Save();
            }
            return true;
        }
        internal static bool ReadAll()
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var items = _context.QueryObjects<NotificationUser>().Where(x =>
                x.IsRead == false &&
                x.ResUser.ObjectID == Common.CurrentResource.ObjectID).ToList();
                foreach (var item in items)
                {
                    item.IsRead = true;
                }
                _context.Save();
                return true;
            }
        }
    }

    public class NotificationDto
    {
        public Notification Notification { get; set; }
        public NotificationUser NotificationUser { get; set; }
        public List<NotificationUser> NotificationUsers { get; set; }
    }
}
