
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NotificationUser")] 

    public  partial class NotificationUser : TTObject
    {
        public class NotificationUserList : TTObjectCollection<NotificationUser> { }
                    
        public class ChildNotificationUserCollection : TTObject.TTChildObjectCollection<NotificationUser>
        {
            public ChildNotificationUserCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNotificationUserCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<NotificationUser> GetUserNotificationsBy(TTObjectContext objectContext, DateTime LastMonth, DateTime LastTime, Guid ResUser)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NOTIFICATIONUSER"].QueryDefs["GetUserNotificationsBy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTMONTH", LastMonth);
            paramList.Add("LASTTIME", LastTime);
            paramList.Add("RESUSER", ResUser);

            return ((ITTQuery)objectContext).QueryObjects<NotificationUser>(queryDef, paramList);
        }

    /// <summary>
    /// IsRead
    /// </summary>
        public bool? IsRead
        {
            get { return (bool?)this["ISREAD"]; }
            set { this["ISREAD"] = value; }
        }

    /// <summary>
    /// ReadTime
    /// </summary>
        public DateTime? ReadTime
        {
            get { return (DateTime?)this["READTIME"]; }
            set { this["READTIME"] = value; }
        }

    /// <summary>
    /// Notification
    /// </summary>
        public Notification Notification
        {
            get { return (Notification)((ITTObject)this).GetParent("NOTIFICATION"); }
            set { this["NOTIFICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ResUser (ALICI)
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NotificationUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NotificationUser(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NotificationUser(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NotificationUser(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NotificationUser(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NOTIFICATIONUSER", dataRow) { }
        protected NotificationUser(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NOTIFICATIONUSER", dataRow, isImported) { }
        public NotificationUser(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NotificationUser(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NotificationUser() : base() { }

    }
}